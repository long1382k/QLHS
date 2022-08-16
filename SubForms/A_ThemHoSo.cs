using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevComponents.DotNetBar;
using DevComponents.AdvTree;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using QLHS.Utilities;

namespace QLHS.Subform
{
    public partial class A_ThemHoSo : Office2007Form
    {

        public delegate void DoEvent();
        public event DoEvent RefreshDgv;
        LINQDataContext linq = new LINQDataContext();

        #region Properties

        public bool BtnSaveClose
        {
            get { return this.btnSaveClose.Visible; }
            set { this.btnSaveClose.Visible = value; }
        }
        // thuộc tính nút gắn file vào hồ sơ
        public bool BtnAttachFileVaoHoSo
        {
            get { return this.btnAttachHS.Enabled; }
            set { this.btnAttachHS.Enabled = value; }
        }
        // thuộc tính nút mở hộp thoại chọn file
        public bool BtnAttachFile
        {
            get { return this.btnAttachFile.Enabled; }
            set { this.btnAttachFile.Enabled = value; }
        }
        // thuộc tính gán nút xóa file đính kèm
        public bool BtnDeleteFile
        {
            get { return this.btnDeleteFile.Visible; }
            set { this.btnDeleteFile.Visible = value; }
        }

        #endregion


        // variables
        #region Variables

        private bool opThemSua;
        private int idHoSo;
        Helper h;
        SqlConnection con;
        TienIchNghiepVu TienIch;
        #endregion


        public A_ThemHoSo(int IDHoSo, bool Option)
        {
            InitializeComponent();
            // khởi tạo

            this.idHoSo = IDHoSo;
            this.opThemSua = Option;

            /*Cần thay bằng chuỗi kết nối mới*/

            //h = new Helper();
            //con = h.getConnect();
        }

        //public A_ThemHoSo()
        //{
        //    InitializeComponent();

        //}

        private void btnSaveTiep_Click(object sender, EventArgs e)
        {

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            // làm sạch (xóa) những file đính kèm mà không thuộc hồ sơ nào
            // xoaTapTinKhongThuocHoSo();
        }
        private void btnSaveClose_Click(object sender, EventArgs e)
        {

        }
        private void A_ThemHoSo_Load(object sender, EventArgs e)
        {
            btnDeleteFile.Visible = false;

            // thêm cột vào grid file đính kèm
            DataGridViewLinkColumn dgvlink = new DataGridViewLinkColumn();
            dgvlink.DataPropertyName = "strFileName";//bind to the correct data column
            dgvlink.HeaderText = "Xem chi tiết tập tin";
            dgvlink.Width = 260;
            dgvlink.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvlink.ToolTipText = "Nhấn chuột để xem chi tiết tập tin";
            this.dgvFileAttach.Columns.Add(dgvlink);
            this.dgvFileAttach.AutoGenerateColumns = false; // thuộc tính này đặt cột vào cuối của datagrid

            if (opThemSua == false)
            {
                txtTieuDeHoSo.Focus();
                if (chkAuto.Checked == true)
                {
                    txtMaHS.Enabled = false;
                    // sinh mã số
                    txtMaHS.Text = "123";
                }
                else
                {
                    txtMaHS.Enabled = true;
                }
            }
            else // Hiển thị thông tin cần sửa
            {
                // ẩn node Lưu và thêm mới
                btnSaveTiep.Visible = false;
                txtMaHS.Focus();
                chkAuto.Visible = false;
                txtMaHS.Enabled = true;
                chkTurnOffMessage.Width = 772;
                try
                {
                    // Sửa thành linq
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_KhieuNaiToCao_GetUpdate";

                    cmd.Parameters.Add("@idHS", SqlDbType.Int);
                    cmd.Parameters["@idHS"].Value = idHoSo;
                    // Khai báo DataAdapter
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dtHS = new DataTable();
                    // gán data cho DataTable
                    da.Fill(dtHS);

                    if (dtHS.Rows.Count > 0)
                    {
                        
                        // hiển thị các file đính kèm
                        string strFile = @"SELECT idFile,strFileName, strNgayCapNhat FROM tblAttachFileHS WHERE idHS=" + idHoSo + " ORDER BY idFile desc";
                        DataTable dtFile = h.getData(strFile, con);
                        dgvFileAttach.DataSource = dtFile;
                        lblSumFileAttack.Text = "Có " + dtFile.Rows.Count + " tập tin được đính kèm trong hồ sơ";
                        //xoaTapTinKhongThuocHoSo();

                        #region ẩn một số nút chức năng nếu trường hợp xem hồ sơ
                        if (btnSaveClose.Visible == false)
                        {
                            btnAttachFile.Visible = false;
                            btnAttachHS.Visible = false;
                            btnDeleteFile.Visible = false;
                            chkAuto.Visible = false;
                            //chkNamNu.Visible = false;
                            //chkDefaultNamHS.Visible = false;

                        }
                        #endregion
                    }
                    else
                    {
                        MessageBoxEx.Show("Lỗi không truy vấn được dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi kết nối dữ liệu hoặc dữ liệu của hồ sơ không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // xóa bỏ chế độ select row mặc định trên gridview file đính kèm
                this.dgvFileAttach.ClearSelection();
            }

            var s = linq.lay_cottennhanvien();
            comboBoxEx2.DataSource = s;
            comboBoxEx2.ValueMember = "tennhanvien";
            var v = linq.lay_cottennhanvien();
            comboBoxEx3.DataSource = v;
            comboBoxEx3.ValueMember = "tennhanvien";

        }


        #region AddFileAttack
        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Chọn tập tin đính kèm";
            //fDialog.Filter = "PDF Files|*.pdf|All Files|*.*";
            fDialog.Filter = "All Files|*.*";
            //fDialog.Filter = "PDF Files|*.pdf";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileAttach.Text = fDialog.FileName.ToString();
            }
        }

        private void btnAttachHS_Click(object sender, EventArgs e)
        {
            // đọc thông tin file
            if (txtFileAttach.Text != "")
            {
                string filetype; // kiểu file strType
                string filename; // tên file strTenFile

                filename = txtFileAttach.Text.Substring(Convert.ToInt32(txtFileAttach.Text.LastIndexOf("\\")) + 1, txtFileAttach.Text.Length - (Convert.ToInt32(txtFileAttach.Text.LastIndexOf("\\")) + 1));
                filetype = txtFileAttach.Text.Substring(Convert.ToInt32(txtFileAttach.Text.LastIndexOf(".")) + 1, txtFileAttach.Text.Length - (Convert.ToInt32(txtFileAttach.Text.LastIndexOf(".")) + 1));

                byte[] FileBytes = null; // fileBytes lưu vào trường txtDoc

                try
                {
                    // Mở file để đọc
                    FileStream FS = new FileStream(txtFileAttach.Text, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                    // chuyển file dạng nhị phân
                    BinaryReader BR = new BinaryReader(FS);

                    // lấy kích thước tập tin (số byte)
                    long allbytes = new FileInfo(txtFileAttach.Text).Length;

                    // đọc file vào vùng đệm
                    FileBytes = BR.ReadBytes((Int32)allbytes);

                    // đóng các đối tượng
                    FS.Close();
                    FS.Dispose();
                    BR.Close();
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show("Có lỗi xảy ra: Chưa chọn file đính kèm hoặc file đính kèm không thể đọc:\n" + ex.ToString());
                }
                // kết thúc đọc file

                btnAttachHS.Enabled = true;
                int numFileAttach = 0;

                try
                {
                    // ghi file vào table, tạm thời gán cho văn bản có idVBden=0, sau khi nhấn SAVE thì cập nhật lại cho idVBden= ID của văn bản vừa thêm
                    if (opThemSua == false)
                    { // nếu nhập mới
                        string sqlINSERT = @"INSERT INTO tblAttachFileHS(strFileName,txtDoc,strType,idHS,strNgayCapNhat) ";
                        sqlINSERT += " VALUES(@fileName,@fileDoc,@fileType,0,@datNgayCapNhat)";

                        //DateTime datNgayDen = Convert.ToDateTime(dTNgayDen.Value.ToString()); // lấy ngày không có thời gian
                        DateTime datNgayDen = Convert.ToDateTime(DateTime.Now); // ngày có chính xác thời gian

                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        SqlCommand cmd = new SqlCommand(sqlINSERT, con);
                        cmd.Parameters.AddWithValue("@fileDoc", FileBytes); // file txtDoc
                        cmd.Parameters.AddWithValue("@fileName", filename); // Tên file
                        cmd.Parameters.AddWithValue("@fileType", filetype); // kiểu file
                        cmd.Parameters.AddWithValue("@datNgayCapNhat", datNgayDen);

                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            string strFile = @"SELECT idFile,strFileName, strNgayCapNhat FROM tblAttachFileHS WHERE idHS=0 ORDER BY idFile desc";
                            DataTable dtFile = h.getData(strFile, con);
                            dgvFileAttach.DataSource = dtFile;
                            numFileAttach = dtFile.Rows.Count;
                            txtFileAttach.ResetText();
                            dtFile.Dispose();
                        }
                        if (con != null) con.Close();
                    }
                    else // sửa hồ sơ: thêm / xóa file đính kèm của hồ sơ có id là idHoSo
                    {

                        //DateTime datNgayDen = Convert.ToDateTime(dTNgayDen.Value.ToString()); // lấy ngày không có thời gian
                        DateTime datNgayDen = Convert.ToDateTime(DateTime.Now); // ngày có chính xác thời gian

                        string sqlINSERT = @"INSERT INTO tblAttachFileHS(strFileName,txtDoc,strType,idHS,strNgayCapNhat) ";
                        sqlINSERT += " VALUES(@fileName,@fileDoc,@fileType," + idHoSo + ",@datNgayCapNhat)";
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        SqlCommand cmd = new SqlCommand(sqlINSERT, con);
                        cmd.Parameters.AddWithValue("@fileDoc", FileBytes); // file txtDoc
                        cmd.Parameters.AddWithValue("@fileName", filename); // Tên file
                        cmd.Parameters.AddWithValue("@fileType", filetype); // kiểu file
                        cmd.Parameters.AddWithValue("@datNgayCapNhat", datNgayDen);

                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            string strFile = @"SELECT idFile,strFileName, strNgayCapNhat FROM tblAttachFileHS WHERE idHS=" + idHoSo + " ORDER BY idFile desc";
                            DataTable dtFile = h.getData(strFile, con);
                            dgvFileAttach.DataSource = dtFile;
                            numFileAttach = dtFile.Rows.Count;
                            txtFileAttach.ResetText();
                            dtFile.Dispose();
                        }
                        if (con != null) con.Close();
                    }

                    lblSumFileAttack.Text = "Có " + numFileAttach + " tập tin được đính kèm trong hồ sơ";
                }
                catch (Exception E) { MessageBoxEx.Show(E.ToString()); }
            }
            else // không có file đính kèm
            {
                MessageBoxEx.Show("Chưa chọn file đính kèm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            // thực hiện xóa file khỏi bảng đính kèm
            if (dgvFileAttach.SelectedRows.Count <= 0)
            {
                btnDeleteFile.Visible = false;
                return;
            }
            else
                try
                {
                    int idFileSelected = Convert.ToInt32(dgvFileAttach.CurrentRow.Cells["idFile"].Value);
                    string sql = @"DELETE FROM tblAttachFileHS WHERE idFile=" + idFileSelected;

                    try
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        SqlCommand cmd = new SqlCommand(sql, con);
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            string strFile = "";
                            //Nếu là xóa file của hồ sơ đang được thêm mới
                            if (this.opThemSua == false)
                            {
                                strFile = @"SELECT idFile,strFileName, strNgayCapNhat FROM tblAttachFileHS WHERE idHS=0 ORDER BY idFile desc";
                            }
                            else // sửa hồ sơ và xóa file trong hồ sơ đang sửa
                            {
                                strFile = @"SELECT idFile,strFileName, strNgayCapNhat FROM tblAttachFileHS WHERE idHS=" + idHoSo + " ORDER BY idFile desc";
                            }
                            if (strFile != "")
                            {
                                DataTable dtFile = h.getData(strFile, con);
                                dgvFileAttach.DataSource = dtFile;
                                lblSumFileAttack.Text = "Có " + dtFile.Rows.Count + " tập tin được đính kèm trong văn bản";
                                dtFile.Dispose();
                            }
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                        if (con != null) con.Close();
                    }
                }
                catch
                {
                    btnDeleteFile.Visible = false;
                }
            btnDeleteFile.Visible = false;
        }


        #region Kiểm tra các giá trị nhập vào

        // hàm kiểm tra nhập số (diện tích)
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        private void txtGiaTriHopDong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBoxEx.Show("Có lỗi xảy ra\nSố tiền phải là một số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaTriHopDong.Focus();
            }
        }

        private void txtGiaTriThanhToan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBoxEx.Show("Có lỗi xảy ra\nSố tiền phải là một số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaTriThanhToan.Focus();
            }
        }

        private void txtDienTich_Validated(object sender, EventArgs e)
        {
            if (txtDienTich.Text.Trim() != "")
            {
                if (!IsNumber(txtDienTich.Text))
                {
                    MessageBoxEx.Show("Diện tích phải là một số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDienTich.Focus();
                    txtDienTich.Text = "";
                }
            }
        }

        #endregion

        private void dgvFileAttach_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DevComponents.DotNetBar.Controls.DataGridViewX dgv = (DevComponents.DotNetBar.Controls.DataGridViewX)sender;
            dgv.ClearSelection();
        }




        private void dgvFileAttach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnSaveClose.Visible == true)
            {
                btnDeleteFile.Visible = true;
            }
            else
            {
                btnDeleteFile.Visible = false;
            }
        }

        private void dgvFileAttach_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvFileAttach.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void dgvFileAttach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



            #endregion


        }

        private void chkAuto_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkAuto.Checked == false)
            //{

            //    if (this.opThemSua == false)
            //    {
            //        txtMaHS.ResetText();
            //        txtMaHS.Enabled = true;
            //    }
            //    else
            //    {
            //        txtMaHS.Enabled = true;
            //    }
            //}
            //else
            //{
            //    txtMaHS.Enabled = false;
            //    SinhMaSo(this.idNhomHoSo);
            //}
        }

        bool _fSetText = true;

        private void DinhDangTien(TextBox t)
        {
            try
            {
                if (_fSetText)
                {
                    string strTemp = t.Text;
                    if (String.IsNullOrEmpty(strTemp)) return;
                    int iIndex = strTemp.IndexOf('.');
                    if (iIndex == -1)
                    {
                    }
                    else
                    {
                        string strT = strTemp.Substring(iIndex + 1, 1);
                        if (!String.IsNullOrEmpty(strT))
                        {
                        }
                    }
                    double flTienThuong = double.Parse(t.Text.Trim(','));
                    _fSetText = false;
                    t.Text = flTienThuong.ToString("0,00.##");
                }
                else
                {
                    _fSetText = true;
                    // Đưa con trỏ về cuối chuỗi.
                    t.Select(t.TextLength, 0);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("error: " + ex.Message);
            }
        }
        #region Hàm sinh mã hồ sơ 
        void SinhMaSo()
        {
            //string sql;

            //sql = @"SELECT conMaHSKNTC AS TienTo, conLengthMaHSKNTC AS ChuSo FROM tblConfig";

            //DataTable dt = new DataTable();
            //dt = h.getData(sql, con);

            //TaoNodeDanhMuc makeNode = new TaoNodeDanhMuc();
            //string masoHS = dt.Rows[0]["TienTo"].ToString(); // Lấy mã hs là tiền tố HS0001, HS0002, ... trong đó các con số được lấy từ idmax trong db, giả sử có khoảng vạn hồ sơ
            //int id = makeNode.getTotalHoSo_KhieuNai("tblHoSoTaiNguyen", "idHS", idNhomHoSo) + 1;
            //int chieudaiso = Convert.ToInt32(dt.Rows[0]["ChuSo"].ToString()) - id.ToString().Length;
            //for (int i = 0; i < chieudaiso; i++)
            //    masoHS += "0";

            //masoHS += id.ToString();

            //txtMaHS.Text = masoHS; // gán vào textbox
        }
        #endregion

        private void txtGiaTriThanhToan_TextChanged(object sender, EventArgs e)
        {
            DinhDangTien(txtGiaTriThanhToan);
        }

        private void txtGiaTriHopDong_TextChanged(object sender, EventArgs e)
        {
            DinhDangTien(txtGiaTriThanhToan);
        }
    }
}
