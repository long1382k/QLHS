using DevComponents.DotNetBar;
using QLHS.Subform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLHS.SubForms;

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
        private ToolStripItem itemInHS;
        #endregion

        TabChucNang _page;
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
        public frToanBoHoSo(SuperTabControl spTab, TabChucNang page)
        {
            InitializeComponent();
            this.spTabCtrl = spTab;
            _page = page;

            /* ---------------- menu context cho dgv ----------------------------- */
            conMenu = new System.Windows.Forms.ContextMenuStrip(); // khởi tạo menu context
            //add menu con
            itemXemHS = conMenu.Items.Add("Xem chi tiết thông tin hồ sơ");
            itemSuaHS = conMenu.Items.Add("Sửa thông tin hồ sơ");
            itemInHS = conMenu.Items.Add("In thông tin hồ sơ");
            conMenu.Items.Add(new ToolStripSeparator());
           
           
            itemXoaHS = conMenu.Items.Add("Xóa hồ sơ");


            // gọi phương thức click
            itemXemHS.Click += new EventHandler(xemChiTiet_Click);
            itemSuaHS.Click += new EventHandler(btnSuaHoSo_Click);
            itemInHS.Click += new EventHandler(btnInHoSo_Click);
            itemXoaHS.Click += new EventHandler(btnXoaHoSo_Click);

            // Thêm hình ảnh vào menu context

            itemXemHS.Image = Image.FromFile(Application.StartupPath + @"/icon/openDoc.png");
            itemSuaHS.Image = Image.FromFile(Application.StartupPath + @"/icon/edit.png");
            itemSuaHS.Image = Image.FromFile(Application.StartupPath + @"/icon/edit.png");
            itemXoaHS.Image = Image.FromFile(Application.StartupPath + @"/icon/delete.gif");
            itemInHS.Image = Image.FromFile(Application.StartupPath + @"/icon/print.gif");



        }

        private void frToanBoHoSo_Load(object sender, EventArgs e)
        {
            if (_page == TabChucNang.toanbo) loadToanBoHoSo();
            else if (_page == TabChucNang.theoten) loadTheoTen();
            else loadTheoNam();
            // màu cho row
           
            this.dgvToanBoHoSo.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240);
            this.dgvToanBoHoSo.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
            this.dgvToanBoHoSo.AutoGenerateColumns = false;

            // chữ to cho tiêu đề
            this.dgvToanBoHoSo.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15F, FontStyle.Bold);

        }

        private void loadToanBoHoSo()
        {
            loadDataGrid();
        }

        private void loadTheoTen()
        {
            loadDataGrid();
            dgvToanBoHoSo.Sort(dgvToanBoHoSo.Columns["TenDuAn"], ListSortDirection.Ascending);
        }
        
        private void loadTheoNam()
        {
            DataTable data = new DataTable();
            TaoDataTheoNam(data);
            FillDataTheoNam(data);
        }

        private void TaoDataTheoNam(DataTable data)
        {
            DataColumn stt = new DataColumn();
            data.Columns.Add("MaDuAn", typeof(string));
            data.Columns.Add("TenDuAn", typeof(string));
            data.Columns.Add("DiaDiem", typeof(string));
            data.Columns.Add("DienTich", typeof(string));
            data.Columns.Add("NgayBatDau", typeof(string));
            data.Columns.Add("NgayKetThuc", typeof(string));
            data.Columns.Add("GiaTriHopDong", typeof(string));
            data.Columns.Add("GiaTriThanhQuyetToan", typeof(string));
            data.Columns.Add("TenDoiTruong", typeof(string));
            data.Columns.Add("TenNguoiLapHoSo", typeof(string));
            
        }

        private void FillDataTheoNam(DataTable data)
        {
            var dt = from x in linq.chuyensx() orderby x.NgayBatDau, x.NgayKetThuc select x;

            int sothutu = 1;
            string tenduan, diadiem, dientich, batdau, ketthuc, gthd, gttqt, tendt, tennlhs;
            int madt, manlhs;
            //Load data
            foreach (var d in dt)
            {
                tenduan = linq.lay_tenduan(d.MaDuAn);
                diadiem = linq.lay_diadiem(d.MaDuAn);
                dientich = linq.lay_dientich(d.MaDuAn);
                batdau = linq.lay_ngaybatdau(d.MaDuAn);
                ketthuc = linq.lay_ngayketthuc(d.MaDuAn);
                gthd = linq.lay_giatrihopdong(d.MaDuAn).ToString();
                gttqt = linq.lay_giatrithanhquyettoan(d.MaDuAn).ToString();
                madt = linq.lay_madoitruong(d.MaDuAn).Value;
                manlhs = linq.lay_manguoilaphoso(d.MaDuAn).Value;
                tendt = linq.lay_tennhanvien(madt) + " - " + linq.lay_capbac(madt) + ", " + linq.lay_chucvu(madt);
                tennlhs = linq.lay_tennhanvien(madt) + " - " + linq.lay_capbac(manlhs) + ", " + linq.lay_chucvu(manlhs);
                data.Rows.Add(d.MaDuAn,tenduan, diadiem, dientich, batdau, ketthuc, gthd, gttqt, tendt, tennlhs);
                sothutu++;
            }

            dgvToanBoHoSo.DataSource = data;

        }

        #region Sự kiện cho menucontext
        /******************** Các sự kiện cho menucontext ********************************/
        private void xemChiTiet_Click(object sender, EventArgs e)
        {
            int idHoSo;
            try
            {
                idHoSo = Convert.ToInt32(this.dgvToanBoHoSo.CurrentRow.Cells["MaDuAn"].Value);
                A_ThemHoSo xemhoso = new A_ThemHoSo(idHoSo, Option.xem);
               // MessageBox.Show("")
                xemhoso.ShowDialog();
                //EventForms editHS = new EventForms();
                //editHS.viewToanBoHoSo(idHoSo, this.EnableSaveClose, this.EnableGanFileVaoHS, this.EnableAttachFile, this.EnableDeleteFile);
            }
            
            catch 
            {
                MessageBox.Show("Xem chi tiết thông tin hồ sơ sai!");
            }
        }
        


        // Tạo các sự kiện gọi từ ngoài vào
        
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
                A_ThemHoSo editHS = new A_ThemHoSo(idHoSo, Option.sua);
                editHS.ShowDialog();


                LoadTheoChucNang();
                //Đưa con trỏ về đối tượng vừa sửa
                foreach (DataGridViewRow data in dgvToanBoHoSo.Rows)
                {
                    if (Convert.ToInt32(data.Cells["MaDuAn"].Value) == idHoSo) dgvToanBoHoSo.CurrentCell = data.Cells[1];
                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        
}
        #endregion

        #region Xoá hồ sơ
        private void btnXoaHoSo_Click(object sender, EventArgs e)
        {
            int idHoSo;
            idHoSo = Convert.ToInt32(this.dgvToanBoHoSo.CurrentRow.Cells["MaDuAn"].Value);
            if (MessageBox.Show("Bạn có chắc chắc muốn xóa dự án?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                linq.xoaduan(idHoSo);
                MessageBox.Show("Đã xoá dự án!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTheoChucNang();
            }

        }
        #endregion

        internal void loadDataGrid()
        {
            try
            {
                dgvToanBoHoSo.AutoGenerateColumns = false;
                var x = linq.nlay_bangduan();
                dgvToanBoHoSo.DataSource = x;
                // Hàm lấy toàn bộ hồ sơ
                this.sumHoSo = dgvToanBoHoSo.Rows.Count;
            }

            catch
            {
                MessageBox.Show("Có lỗi khi load dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            A_ThemHoSo addHS = new A_ThemHoSo(0, Option.them);
            addHS.RefreshDgv += new A_ThemHoSo.DoEvent(fr_RefreshDGV);
            addHS.ShowDialog();
            LoadTheoChucNang();
            dgvToanBoHoSo.CurrentCell = dgvToanBoHoSo.Rows[dgvToanBoHoSo.RowCount - 1].Cells[1];
        }
     
        // Close
        private void btnCloseHoSo_Click(object sender, EventArgs e)
        {
            SuperTabItem tab = spTabCtrl.SelectedTab; 
            tab.Close(); 
            //con.Close();
        }

        private void LoadTheoChucNang()
        {
            if (_page == TabChucNang.toanbo) loadToanBoHoSo();
            else if (_page == TabChucNang.theoten) loadTheoTen();
            else loadTheoNam();
        }
        // Refresh data
        internal void btnF5HoSo_Click(object sender, EventArgs e)
        {
            try
            {
                LoadTheoChucNang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            
        }

        private void dgvToanBoHoSo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int column = dgvToanBoHoSo.CurrentCell.ColumnIndex;
           //MessageBox.Show(column.ToString());
        }

        private void panelXemVB_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void txtKeySearch_TextChanged(object sender, EventArgs e)
        {
            if(_page == TabChucNang.toanbo)
            {
                var dt = linq.ntimkiemchung(txtKeySearch.Text.ToString().Trim());
                dgvToanBoHoSo.DataSource = dt;
            }
            else if (_page == TabChucNang.theoten)
            {
                if (txtKeySearch.Text.ToString().Trim() == "")
                {
                    loadTheoTen();
                }
                else
                {
                    var dt = linq.timkiem_tenduan(txtKeySearch.Text.ToString().Trim());
                    dgvToanBoHoSo.DataSource = dt;
                    dgvToanBoHoSo.Sort(dgvToanBoHoSo.Columns["TenDuAn"], ListSortDirection.Ascending);
                }
            }
            else
            {
                try
                {
                    if (txtKeySearch.Text.ToString().Trim() == "")
                    {
                        loadTheoNam();
                    }
                    else
                    {
                        DataTable data = new DataTable();
                        TaoDataTheoNam(data);
                        FillDataTheoNamTim(data);
                    }
                }

                catch
                {
                    if (txtKeySearch.Text.ToString().Trim() == "")
                    {
                        loadTheoNam();
                    }
                }

            }
            
        }

        private void FillDataTheoNamTim(DataTable data)
        {
            var dt = from x in linq.ntimkiem_nam(txtKeySearch.Text.ToString().Trim()) orderby x.NgayBatDau, x.NgayKetThuc select x;

            int sothutu = 1;
            string tenduan, diadiem, dientich, batdau, ketthuc, gthd, gttqt, tendt, tennlhs;
            int madt, manlhs;
            //Load data
            foreach (var d in dt)
            {
                tenduan = linq.lay_tenduan(d.MaDuAn);
                diadiem = linq.lay_diadiem(d.MaDuAn);
                dientich = linq.lay_dientich(d.MaDuAn);
                batdau = linq.lay_ngaybatdau(d.MaDuAn);
                ketthuc = linq.lay_ngayketthuc(d.MaDuAn);
                gthd = linq.lay_giatrihopdong(d.MaDuAn).ToString();
                gttqt = linq.lay_giatrithanhquyettoan(d.MaDuAn).ToString();
                madt = linq.lay_madoitruong(d.MaDuAn).Value;
                manlhs = linq.lay_manguoilaphoso(d.MaDuAn).Value;
                tendt = linq.lay_tennhanvien(madt) + " - " + linq.lay_capbac(madt) + ", " + linq.lay_chucvu(madt);
                tennlhs = linq.lay_tennhanvien(madt) + " - " + linq.lay_capbac(manlhs) + ", " + linq.lay_chucvu(manlhs);
                data.Rows.Add(tenduan, diadiem, dientich, batdau, ketthuc, gthd, gttqt, tendt, tennlhs);
                sothutu++;
            }

            dgvToanBoHoSo.DataSource = data;

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

        private void barToanBoHoSo_ItemClick(object sender, EventArgs e)
        {

        }

        private void dgvToanBoHoSo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == this.dgvToanBoHoSo.Columns["STT"].Index)
            {
                e.Value = e.RowIndex + 1;
            }
        }

        private void txtKeySearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_page == TabChucNang.theonam)
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                
                MessageBoxEx.Show("Đang tìm kiếm theo năm \n Nhâp năm vào ô tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKeySearch.Focus();
            }
        }

        private void btnInHoSo_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvToanBoHoSo.CurrentRow;
            string tenduan = row.Cells[1].Value.ToString().Trim();
            if (tenduan == null || tenduan == "") tenduan = " ";
            string diadiem = row.Cells[2].Value.ToString().Trim(); if (diadiem == null || diadiem == "") diadiem = " ";
            string dientich = row.Cells[3].Value.ToString().Trim(); if (dientich == null || dientich == "") dientich = " ";
            string nbd = row.Cells[4].Value.ToString().Trim(); if (nbd == null || nbd == "") nbd = " ";
            string nkt = row.Cells[5].Value.ToString().Trim(); if (nkt == null || nkt == "") nkt = " ";
            string gthd = row.Cells[6].Value.ToString().Trim();
            int idHoSo = Convert.ToInt32(this.dgvToanBoHoSo.CurrentRow.Cells["MaDuAn"].Value);
            string gthdchu = linq.lay_gthdchu(idHoSo); if (gthdchu == null || gthdchu == "") gthdchu = " ";
            string gttqtchu = linq.lay_gttqtchu(idHoSo); if (gttqtchu == null || gttqtchu == "") gttqtchu = " ";
            if (gthd == null || gthd == "") gthd = " ";
            else 
            {
                try
                {
                    gthd = string.Format("{0:#,##0}", Double.Parse(gthd));
                }
                catch
                {

                }
                gthd += " đồng"; 
            }
            string gttqt = row.Cells[7].Value.ToString().Trim();
            if (gttqt == null || gttqt == "") gttqt = " "; 
            else {
                try
                {
                    gttqt = string.Format("{0:#,##0}", Double.Parse(gttqt));
                }
                catch
                {

                }
                gttqt += " đồng"; 
            }
            string dttc = row.Cells[8].Value.ToString().Trim(); if (dttc == null || dttc == "") dttc = " ";
            string nlhs = row.Cells[9].Value.ToString().Trim(); if (nlhs == null || nlhs =="") nlhs = " ";
            string ghichu = row.Cells[11].Value.ToString().Trim(); if (ghichu == null || ghichu == "") ghichu = " ";
            InThongTinDuAn intt = new InThongTinDuAn(tenduan, diadiem, dientich, nlhs, dttc, gthd, gttqt, nbd, nkt, ghichu,gthdchu,gttqtchu);
            intt.ShowDialog();
           // LoadTheoChucNang();
            foreach (DataGridViewRow data in dgvToanBoHoSo.Rows)
            {
                if (Convert.ToInt32(data.Cells["MaDuAn"].Value) == idHoSo) dgvToanBoHoSo.CurrentCell = data.Cells[1];
            }
        }
    }


}
