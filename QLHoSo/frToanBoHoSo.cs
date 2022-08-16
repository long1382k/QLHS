using DevComponents.DotNetBar;
using QLHS.Subform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHS.QLHoSo
{
    public partial class frToanBoHoSo : Office2007Form
    {
        // Tạo các thuộc tính để lấy giá trị là các sự kiện
        #region Properties
        // Các sự kiện r-click-dgv
        private ToolStripItem itemXemHS;
        //private ToolStripItem itemChuyenHS;
        private ToolStripItem itemSuaHS;
        private ToolStripItem itemExportExcel;
        private ToolStripItem itemExportWord;
        private ToolStripItem itemXoaHS;
        #endregion


        LINQDataContext linq = new LINQDataContext();
        #region Các biến cục bộ
        public SuperTabControl spTabCtrl;

        Helper h;
        SqlConnection con;
        private int sumHoSo;
        DataTable dt; // biến toàn cục, lưu dữ liệu của datagrid
        private bool EnableSaveClose;
        private bool EnableGanFileVaoHS;
        private bool EnableAttachFile;
        private bool EnableDeleteFile;
        
        private ContextMenuStrip conMenu; // menu context trên dgv
        #endregion
        public frToanBoHoSo(SuperTabControl spTab)
        {
            InitializeComponent();
            this.spTabCtrl = spTab;
            //h = new Helper();
            //con = h.getConnect();
            //con.Open();

            /* ---------------- menu context cho dgv ----------------------------- */
            conMenu = new System.Windows.Forms.ContextMenuStrip(); // khởi tạo menu context
            //add menu con
            itemXemHS = conMenu.Items.Add("Xem chi tiết thông tin hồ sơ");
            itemSuaHS = conMenu.Items.Add("Sửa thông tin hồ sơ");
            conMenu.Items.Add(new ToolStripSeparator());
            itemExportExcel = conMenu.Items.Add("Xuất danh mục hồ sơ ra tập tin Excel");
            itemExportWord = conMenu.Items.Add("Xuất danh mục hồ sơ ra tập tin Word");
            conMenu.Items.Add(new ToolStripSeparator());
            itemXoaHS = conMenu.Items.Add("Xóa hồ sơ");


            // gọi phương thức click
            itemXemHS.Click += new EventHandler(xemChiTiet_Click);
            itemSuaHS.Click += new EventHandler(btnSuaHoSo_Click);
            itemExportExcel.Click += new EventHandler(btnExcel_Click);
            itemExportWord.Click += new EventHandler(btnWord_Click);
            itemXoaHS.Click += new EventHandler(btnXoaHoSo_Click);

            // Thêm hình ảnh vào menu context

            itemXemHS.Image = Image.FromFile(Application.StartupPath + @"/icon/openDoc.png");
            itemSuaHS.Image = Image.FromFile(Application.StartupPath + @"/icon/edit.png");
            itemExportExcel.Image = Image.FromFile(Application.StartupPath + @"/icon/excel.png");
            itemExportWord.Image = Image.FromFile(Application.StartupPath + @"/icon/word.png");
            itemXoaHS.Image = Image.FromFile(Application.StartupPath + @"/icon/delete.gif");
            
        }

        private void frToanBoHoSo_Load(object sender, EventArgs e)
        {
            loadDataGrid();
            // màu cho row

            this.dgvToanBoHoSo.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240);
            this.dgvToanBoHoSo.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
            this.dgvToanBoHoSo.AutoGenerateColumns = false;
            
        }

        #region Sự kiện cho menucontext
        /******************** Các sự kiện cho menucontext ********************************/
        private void xemChiTiet_Click(object sender, EventArgs e)
        {
            int idHoSo;
            try
            {
                idHoSo = Convert.ToInt32(this.dgvToanBoHoSo.CurrentRow.Cells["MaDuAn"].Value);
                EventForms editHS = new EventForms();
                editHS.viewToanBoHoSo(idHoSo, false, this.EnableGanFileVaoHS, this.EnableAttachFile, this.EnableDeleteFile);
            }
            catch { }
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch { MessageBoxEx.Show("Tập tin đã tồn tại, vui lòng thực hiện lại thao tác xuất tập tin và chọn tên khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void btnWord_Click(object sender, EventArgs e)
        {

        }


        // Tạo các sự kiện gọi từ ngoài vào
        internal void xuatExcel_Click(object sender, EventArgs e)
        {
            this.btnExcel_Click(sender, e);
        }
        internal void xuatWord_Click(object sender, EventArgs e)
        {
            this.btnWord_Click(sender, e);
        }
        internal void printGrid_Click(object sender, EventArgs e)
        {
        }
        /********************* End các sự kiện *******************************/
        #endregion

        #region Sửa hồ sơ
        private void btnSuaHoSo_Click(object sender, EventArgs e)
        {
            int idHoSo;
            try
            {
                idHoSo = Convert.ToInt32(this.dgvToanBoHoSo.CurrentRow.Cells["MaDuAn"].Value);
                A_ThemHoSo editHS = new A_ThemHoSo(idHoSo, true);
                editHS.BtnSaveClose = this.EnableSaveClose;
                editHS.BtnAttachFileVaoHoSo = this.EnableGanFileVaoHS;
                editHS.BtnAttachFile = this.EnableAttachFile;
                editHS.BtnDeleteFile = this.EnableDeleteFile;
                editHS.RefreshDgv += new A_ThemHoSo.DoEvent(fr_RefreshDGV);
                editHS.ShowDialog();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        
}
        #endregion

        #region Xoá hồ sơ
        private void btnXoaHoSo_Click(object sender, EventArgs e)
        {
           
        }
        #endregion

        internal void loadDataGrid()
        {
            dgvToanBoHoSo.AutoGenerateColumns = false;
            var x =linq.lay_bangduan1();
            dgvToanBoHoSo.DataSource = x;
            // Hàm lấy toàn bộ hồ sơ
            this.sumHoSo = dgvToanBoHoSo.Rows.Count;
        }


        // Sự kiện load lại grid dùng delegate
        #region Sự kiện load lại grid khi thêm hoặc cập nhật thành công 1 hồ sơ
        internal void fr_RefreshDGV()
        { 
            loadDataGrid();         
        }


        #endregion
        #region navigation
        /* -------------- Tạo Navigation ------------------ */

        private void loadNumRecord()
        {
            try
            {
                int vitriHienTai = dgvToanBoHoSo.CurrentRow.Index;
                if (vitriHienTai == 0) // ở ngay dòng đầu tiên
                {
                    if (dgvToanBoHoSo.Rows.Count == 1)
                    {
                        btnNext.Enabled = false;
                        btnLast.Enabled = false;
                        btnFirst.Enabled = false;
                        btnPrevous.Enabled = false;
                    }
                    else
                    {
                        btnFirst.Enabled = false;
                        btnPrevous.Enabled = false;
                        btnNext.Enabled = true;
                        btnLast.Enabled = true;
                    }
                }
                else if (vitriHienTai == dgvToanBoHoSo.Rows.Count - 1)
                {
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                    btnFirst.Enabled = true;
                    btnPrevous.Enabled = true;
                }
                else
                {
                    btnFirst.Enabled = true;
                    btnPrevous.Enabled = true;
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                }
                vitriHienTai++;
                txtIDCurrent.Text = vitriHienTai.ToString() + "/" + dgvToanBoHoSo.Rows.Count;
            }
            catch { MessageBoxEx.Show("Không tìm thấy hồ sơ yêu cầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        // các sự kiện khi nhấn nút đầu trước sau cuối
        private int vitri;
        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (dgvToanBoHoSo.Rows.Count > 0)
            {
                vitri = 0; // văn bản đầu tiên
                try
                {
                    txtIDCurrent.Text = (vitri + 1).ToString() + "/" + dgvToanBoHoSo.Rows.Count;
                }
                catch (Exception E)
                {
                    MessageBoxEx.Show(E.ToString());
                }
                btnFirst.Enabled = false;
                btnPrevous.Enabled = false;
                btnLast.Enabled = true;
                btnNext.Enabled = true;
            }

            // đoạn này để move tới các records
            this.BindingContext[dt].Position = 0;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            vitri = dgvToanBoHoSo.Rows.Count - 1;
            try
            {
                txtIDCurrent.Text = (vitri + 1).ToString() + "/" + dgvToanBoHoSo.Rows.Count;
            }
            catch (Exception E)
            {
                MessageBoxEx.Show(E.ToString());
            }
            btnNext.Enabled = false;
            btnLast.Enabled = false;
            btnFirst.Enabled = true;
            btnPrevous.Enabled = true;

            // đoạn này để move tới các records
            this.BindingContext[dt].Position = this.BindingContext[dt].Count - 1;
        }

        private void btnPrevous_Click(object sender, EventArgs e)
        {
            try
            {
                vitri = dgvToanBoHoSo.CurrentRow.Index; // chỉ số dòng hiện tại
                if ((vitri <= dgvToanBoHoSo.Rows.Count - 1) && (vitri >= 0))
                {
                    vitri--;
                    try
                    {
                        txtIDCurrent.Text = (vitri + 1).ToString() + "/" + dgvToanBoHoSo.Rows.Count;
                    }
                    catch (Exception E)
                    {
                        MessageBoxEx.Show(E.ToString());
                    }
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;

                    if (vitri == 0)
                    {
                        btnFirst.Enabled = false;
                        btnPrevous.Enabled = false;
                    }
                }
                // đoạn này để move tới các records
                this.BindingContext[dt].Position -= 1;
            }
            catch
            {
                btnFirst.Enabled = false;
                btnPrevous.Enabled = false;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                vitri = dgvToanBoHoSo.CurrentRow.Index; // chỉ số dòng hiện tại

                if (vitri < dt.Rows.Count - 1)
                {
                    vitri++;
                    try
                    {
                        txtIDCurrent.Text = (vitri + 1).ToString() + "/" + dgvToanBoHoSo.Rows.Count;
                    }
                    catch (Exception E)
                    {
                        MessageBoxEx.Show(E.ToString());
                    }
                    btnFirst.Enabled = true;
                    btnPrevous.Enabled = true;
                    if (vitri == dt.Rows.Count - 1)
                    {
                        btnNext.Enabled = false;
                        btnLast.Enabled = false;
                    }
                }
                // đoạn này để move tới các records
                this.BindingContext[dt].Position += 1;
            }
            catch
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
        }

        private void dgvQLHSKhieuNai_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvToanBoHoSo.CurrentRow.Index != -1)
                {
                    loadNumRecord();
                }
            }
            catch { }
        }

        #endregion

        /* --------------- Xử lý các sự kiện thanh toolbar ------------------ */

        // Thêm hồ sơ
        private void btnThemHoSo_Click(object sender, EventArgs e)
        {
            A_ThemHoSo addHS = new A_ThemHoSo(0,false);
            addHS.RefreshDgv += new A_ThemHoSo.DoEvent(fr_RefreshDGV);
            addHS.ShowDialog();
        }
     
        // Close
        private void btnCloseHoSo_Click(object sender, EventArgs e)
        {
            SuperTabItem tab = spTabCtrl.SelectedTab; 
            tab.Close(); 
            //con.Close();
        }

        // Refresh data
        internal void btnF5HoSo_Click(object sender, EventArgs e)
        {
            try
            {
                loadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            
        }

        private void dgvToanBoHoSo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int column = dgvToanBoHoSo.CurrentCell.ColumnIndex;
            //MessageBox.Show(column.ToString());
        }

        private void panelXemVB_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtKeySearch_TextChanged(object sender, EventArgs e)
        {
            var dt = dgvToanBoHoSo.DataSource;

            //dt.DefaultView.RowFilter = string.Format("TenDuAn LIKE '%{0}%'", txtKeySearch.Text);
        }

        /************************** Add menu context *******************************/
        private int rowIndex = 0;
        private void dgvToanBoHoSo_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    this.dgvToanBoHoSo.Rows[e.RowIndex].Selected = true;
                    this.rowIndex = e.RowIndex;
                    this.dgvToanBoHoSo.CurrentCell = this.dgvToanBoHoSo.Rows[e.RowIndex].Cells[0];
                    this.conMenu.Show(this.dgvToanBoHoSo, e.Location);
                    conMenu.Show(Cursor.Position);
                }
                catch { }
            }
        }
    }


}
