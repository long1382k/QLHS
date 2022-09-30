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
using QLHS.SubForms;

namespace QLHS.Subform
{

    public enum Option
    {
        them = 0,
        sua = 1,
        xem = 2
    }

    public enum TabChucNang
    {
        toanbo = 0,
        theoten = 1,
        theonam = 2
    }

    public partial class A_ThemHoSo : Office2007Form
    {
        string _diadiem;
        string _dientich;
        string _dttc_capbac;
        string _dttc_chucvu;
        string _dttc_hoten = "";

        bool _fSetText = true;
        string _ghichu;
        double _gthd;
        double _gttqt;
        string _linkfile;
        int _madttc;
        int _maduan;
        int _manth;
        string _nbd;
        string _nkt;
        string _nth_capbac;
        string _nth_chucvu;
        string _nth_hoten = "";
        int _nth_trangthai;
        int _dttc_trangthai;
        string _tenduan;
        DataTable bangfile = new DataTable();
        List<string> danhsachpath = new List<string>();
        LINQDataContext linq = new LINQDataContext();
        int selectedItem = 0;
        int _loadNLHS;
        int _loadDTTC;
        string _nlhskhac;
        string _dttckhac;
        string _gthdchu;
        string _gttqtchu;

        public A_ThemHoSo(int IDHoSo, Option option)
        {
            InitializeComponent();
            this.idHoSo = IDHoSo;
            this.opThemSua = option; _loadNLHS = 0; _loadDTTC = 0;
            if (this.opThemSua == Option.sua || this.opThemSua == Option.xem) KhoiTaoXemSua();
        }

        public delegate void DoEvent();

        public event DoEvent RefreshDgv;

        private void A_ThemHoSo_Load(object sender, EventArgs e)
        {
            CreateTableFile();
            if (opThemSua == Option.xem)
            {
                CheDoXem();
            }
            else if (opThemSua == Option.sua)
            {
                CheDoSua();
            }

            else
            {
                CheDoThem();
            }



        }

        private void btn_duan_Click(object sender, EventArgs e)
        {
            fr_InThongTinHoSo inHoSo = new fr_InThongTinHoSo();
            inHoSo.ShowDialog();
        }

        private void btn_noiluutru_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            string folderPath = folderBrowser.SelectedPath;
            //txt_noiluutru.Text = folderPath;
        }

        private void btn_themnv_Click(object sender, EventArgs e)
        {
            try
            {
                A_ThemNhanSu them = new A_ThemNhanSu(Option.them, 0,1);
                them.Show();
                int i = cb_loai_dttc.SelectedIndex; LoadComboTenDTTC(i);
                int j = cb_loai_nlhs.SelectedIndex; LoadComboTenNLHS(i);

            }

            catch
            {
                MessageBox.Show("Đã xảy ra lỗi khi hiện form thêm dự án");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            // làm sạch (xóa) những file đính kèm mà không thuộc hồ sơ nào
            // xoaTapTinKhongThuocHoSo();
        }
        
        private void LayDuLieuTuCacTruong()
        {
            _tenduan = ToString(txt_tenduan);
            _diadiem = ToString(txt_diadiem);
            if (cb_donvi.SelectedIndex == 0 || cb_donvi.SelectedIndex == 1) _dientich = ToString(txt_dientich) + " " + ToString(cb_donvi);
            else _dientich = "";
            _ghichu = ToString(txt_ghichu);

            if (rdb_nlhs_nv.Checked)
            {
                string nth_hoten = ToString(cb_nth_hoten);
                string nth_capbac = ToString(label_nth_capbac);
                string nth_chucvu = ToString(txt_nth_chucvu);

                try
                {
                    _manth = linq.lay_manhanvien(nth_hoten, nth_capbac, nth_chucvu).Value;
                    //else _manth = linq.lay_manhanvien(nth_hoten, 1).Value;
                }
                catch
                {
                    _manth = -1;
                    // MessageBoxEx.Show("Tồn tại 2 tên nhân viên hoặc chuyên gia trùng nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                _nlhskhac = "";
            }
            else
            {
                _manth = -1;
                _nlhskhac = ToString(txtNguoiLamHoSo);
            }

            if (rdb_dttc_nv.Checked)
            {
                string dttc_hoten = ToString(cb_dttc_hoten);
                string dttc_capbac = ToString(txt_dttc_capbac);
                string dttc_chucvu = ToString(txt_dttc_chucvu);
                try
                {
                    //if (cb_loai_dttc.SelectedIndex == 0) _madttc = linq.lay_manhanvien(dttc_hoten,).Value;
                    _madttc = linq.lay_manhanvien(dttc_hoten, dttc_capbac, dttc_chucvu).Value;
                }
                catch
                {
                    _madttc = -1;
                    //MessageBoxEx.Show("Tồn tại ít nhất 2 tên nhân viên hoặc chuyên gia trùng nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                _dttckhac = "";
            }

            else
            {
                _madttc = -1;
                _dttckhac = ToString(txtDoiTruongThiCong); 
            }


            string gthd = ToString(txt_gthd);
            string gttqt = ToString(txt_gttqt);
            _gthd = ChuyenSangFloat(gthd);
            _gttqt = ChuyenSangFloat(gttqt);
            _gthdchu = ToString(txt_gthd_bangchu);
            _gttqtchu = ToString(txt_gttqt_bangchu);

            string bd_ngay = ToString(txt_batdau_ngay);
            string bd_thang = ToString(txt_batdau_thang);
            string bd_nam = ToString(txt_batdau_nam);

            string kt_ngay = ToString(txt_ketthuc_ngay);
            string kt_thang = ToString(txt_ketthuc_thang);
            string kt_nam = ToString(txt_ketthuc_nam);

            _nbd = ChuyenThoiGian(bd_ngay, bd_thang, bd_nam);
            _nkt = ChuyenThoiGian(kt_ngay, kt_thang, kt_nam);

            //string noiluutru = ToString(txt_noiluutru);
            //if (noiluutru != "")
            //{
             ChuyenFileSangFolder();
            //}
            _linkfile = ChuyenDanhSachFile();

        }
        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (DienTruongDonVi())
                {
                    MessageBox.Show("Chọn đơn vị cho diện tích!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cb_donvi.Focus();
                }
                else
                {
                    if (!CacTruongBatBuocDien()) MessageBox.Show("Người lập hồ sơ và đội trưởng thi công bắt buộc điền!");
                    else
                    {
                        if (!CacTruongDeuHopLe())
                        {
                            MessageBox.Show("Hãy kiểm tra thông tin các trường nhập vào và nhập lại", "Thông tin chưa đúng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {

                            LayDuLieuTuCacTruong();

                            if (MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin dự án?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                try
                                {
                                    linq.nsua_duan(_maduan, _tenduan, _diadiem, _dientich, _nbd, _nkt, _gthd, _gttqt, _manth, _madttc, _linkfile, _ghichu, _nlhskhac, _dttckhac, _gthdchu, _gttqtchu);
                                    MessageBox.Show("Sửa dự án thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    this.Close();

                                }

                                catch (Exception ex)
                                {
                                    MessageBox.Show("Sửa dự án không thành công!" + ex.Message);
                                }

                            }

                        }
                        this.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Dự án chưa được sửa! " + ex.ToString(),"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


        private void btnSaveTiep_Click(object sender, EventArgs e)
        {
            try
            {
                if (DienTruongDonVi())
                {
                    MessageBox.Show("Chọn đơn vị cho diện tích!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cb_donvi.Focus();
                }
                else
                {
                    if (!CacTruongBatBuocDien()) MessageBox.Show("Người lập hồ sơ và đội trưởng thi công bắt buộc điền!");
                    else
                if (!CacTruongDeuHopLe())
                    {
                        MessageBox.Show("Hãy kiểm tra thông tin các trường nhập vào và nhập lại", "Thông tin chưa đúng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        LayDuLieuTuCacTruong();
                        linq.nthem_duan(_tenduan, _diadiem, _dientich, _nbd, _nkt, _gthd, _gttqt, _manth, _madttc, _linkfile, _ghichu, _nlhskhac, _dttckhac, _gthdchu, _gttqtchu);
                        MessageBox.Show("Thêm dự án thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Refresh();
                        ThemTieptucRefresh();
                    }
                }
                
            }

            catch (Exception ex)
            {
                    MessageBox.Show("Dự án chưa được thêm! " + ex.ToString());
            }

        }

        private void btnThemDong_Click(object sender, EventArgs e)
        {
            try
            {
                if (DienTruongDonVi())
                {
                    MessageBox.Show("Chọn đơn vị cho diện tích!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cb_donvi.Focus();
                }
                else
                {
                    if (!CacTruongBatBuocDien()) MessageBox.Show("Người lập hồ sơ và đội trưởng thi công bắt buộc điền!", "Điền đầy đủ thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else


                if (!CacTruongDeuHopLe())
                    {
                        MessageBox.Show("Hãy kiểm tra thông tin các trường nhập vào và nhập lại", "Thông tin chưa đúng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        LayDuLieuTuCacTruong();
                        linq.nthem_duan(_tenduan, _diadiem, _dientich, _nbd, _nkt, _gthd, _gttqt, _manth, _madttc, _linkfile, _ghichu, _nlhskhac, _dttckhac, _gthdchu, _gttqtchu);
                        MessageBox.Show("Thêm dự án thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Dự án chưa được thêm! " + ex.ToString());
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            int stt = dgvFileAttach.CurrentRow.Index;
            //stt--;
            string path = danhsachpath[stt];
            try
            {
                Process.Start(path);
            }
                
            catch
            {
                int vitrixuathiencuoi = path.LastIndexOf('\\');
                string tenfile = path.Substring(vitrixuathiencuoi + 1);
                string pathroot = Application.StartupPath + "\\" + tenfile;
                try
                {
                    Process.Start(pathroot);
                }
                catch
                {
                    MessageBox.Show("Tài liệu đính kèm không tồn tại");
                }
            }   

            //}
        }

        private bool CacTruongDeuHopLe()
        {
            if (txt_gthd.ForeColor == Color.Red || txt_gttqt.ForeColor == Color.Red || txt_batdau_ngay.ForeColor == Color.Red
                || txt_batdau_thang.ForeColor == Color.Red || txt_batdau_nam.ForeColor == Color.Red
                || txt_ketthuc_ngay.ForeColor == Color.Red || txt_ketthuc_thang.ForeColor == Color.Red || txt_ketthuc_nam.ForeColor == Color.Red)
            {
                return false;
            }
            return true;
        }

        private void cb_dttc_hoten_SelectedIndexChanged(object sender, EventArgs e)
        {

            string tennhanvien = cb_dttc_hoten.Text.ToString().Trim();
            try
            {
                int loai = cb_loai_dttc.SelectedIndex;
                int manhanvien = linq.nlay_manhanvien(tennhanvien, loai).Value;
                string capbac = linq.lay_capbac(manhanvien);
                string chucvu = linq.lay_chucvu(manhanvien);
                txt_dttc_capbac.Text = capbac;
                txt_dttc_chucvu.Text = chucvu;
                
            }

            catch
            {
                //MessageBoxEx.Show("", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cb_loai_nlhs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cb_loai_nlhs.SelectedIndex;
            LoadComboTenNLHS(index);
            if (opThemSua == Option.sua && _loadNLHS < 3)
            {
                if (_nth_trangthai == -1) cb_nth_hoten.Text = _nth_hoten.Trim();
                else
                    for (int i = 0; i < cb_nth_hoten.Items.Count; i++)
                    {
                        cb_nth_hoten.SelectedIndex = i;
                        if (ToString(cb_nth_hoten) == _nth_hoten.Trim())
                        {
                            break;
                        }
                    }
                _loadNLHS++;
            }
        }

        private void cb_nth_hoten_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int loai = cb_loai_nlhs.SelectedIndex;
                string tennhanvien = cb_nth_hoten.Text.ToString().Trim();
                int manhanvien = linq.nlay_manhanvien(tennhanvien, loai).Value;
                string capbac = linq.lay_capbac(manhanvien);
                string chucvu = linq.lay_chucvu(manhanvien);
                label_nth_capbac.Text = capbac;
                txt_nth_chucvu.Text = chucvu;
                //MessageBox.Show(cb_nth_hoten.SelectedText.ToString());
            }
            catch
            {

            }

        }

        private void CheDoSua()
        {
            try
            {
                if (idHoSo > 0)
                {
                    SuaXemLoad();
                    //HienDanhSachFile();
                    #region ẩn một số nút chức năng nếu trường hợp sửa hồ sơ
                    //if (btnSaveClose.Visible == false)
                    //{
                    btnAttachFile.Visible = true;
                    btnDeleteFile.Visible = true;
                    btnSaveTiep.Visible = false;
                    btnSaveClose.Visible = true;
                    btnThemDong.Visible = false;

                    //}
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

        private void CheDoThem()
        {
            //LoadComboTen();
            int i = linq.lay_idcuoi().Value;
            //MessageBox.Show(i.ToString());
            txtMaHS.Text = (linq.lay_idcuoi().Value).ToString();
            txtMaHS.ReadOnly = true;
            //Ẩn hiện 1 số thanh công cụ
            btnAttachFile.Visible = true;
            //btnAttachHS.Visible = false;
            btnDeleteFile.Visible = true;
            //chkAuto.o
            btnSaveTiep.Visible = true;
            btnSaveClose.Visible = false;
            btnThemDong.Visible = true;
            // Chỉnh vị trí button
            btnSaveTiep.Location = btnThemDong.Location;
            btnThemDong.Location = btnSaveClose.Location;
        }

        private void CheDoXem()
        {
            try
            {
                if (idHoSo > 0)
                {
                    SuaXemLoad();
                    #region ẩn một số nút chức năng nếu trường hợp xem hồ sơ
                    btnAttachFile.Visible = false;

                    btnDeleteFile.Visible = false;
                    btnSaveTiep.Visible = false;
                    btnSaveClose.Visible = false;
                    btnThemDong.Visible = false;
                    btn_themnv.Visible = false;
                    btn_themnv1.Visible = false;


                    //sắp xếp vị trí button
                    //}
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

        private void chkAuto_CheckedChanged(object sender, EventArgs e)
        {
        }

        private string ChuyenDanhSachFile()
        {
            string str = "";
            for (int i = 0; i < danhsachpath.Count; i++)
            {
                str += danhsachpath[i] + ",";
            }
            return str;
        }

        private void ChuyenFileSangFolder()
        {
            try
            {
                string fileName;
                string sourcePath;
                //string targetPath;
                //string targetFolder = ToString(txt_noiluutru);
                string fileroot = Application.StartupPath + "\\Storage";
                string rootPath;
                for (int i = 0; i < danhsachpath.Count; i++)
                {
                    fileName = dgvFileAttach.Rows[i].Cells[1].Value.ToString();
                    sourcePath = danhsachpath[i];
                    //targetPath = targetFolder + "\\" + fileName;
                    rootPath = fileroot + "\\" + fileName;
                    //Chuyen sang folder mới kết hợp đổi danh sách path
                    ///danhsachpath[i] = targetPath;
                   // File.Copy(sourcePath, targetPath, true);
                    File.Copy(sourcePath, rootPath, true);
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message.ToString());
            }
        }

        private double ChuyenSangFloat(string str)
        {
            try
            {
                return double.Parse(str);
            }
            catch
            {
                if (str == "") return 0f;
                return -1f;
            }
        }

        private string ChuyenThoiGian(string ngay, string thang, string nam)
        {

            if (ngay == "" && thang == "" && nam == "")
            {
                return "";
            }
            ngay = Them0(ngay);
            thang = Them0(thang);
            nam = Them0(nam);
            string str = "";
            if (ngay == "") str += thang + "/" + nam;
            else str += ngay + "/" + thang + "/" + nam;
            return str;
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cb_loai_dttc.SelectedIndex;

            LoadComboTenDTTC(index);

            if (opThemSua == Option.sua && _loadDTTC < 3)
            {
                //if(_dttc_trangthai == -1)
                //cb_dttc_hoten.Items.Add(_dttc_hoten);
                for (int i = 0; i < cb_dttc_hoten.Items.Count; i++)
                {
                    cb_dttc_hoten.SelectedIndex = i;
                    if (ToString(cb_dttc_hoten) == _dttc_hoten.Trim())
                    {
                        break;
                    }
                }
                _loadDTTC ++;
            }
        }

        private void CreateTableFile()
        {
            DataColumn stt = new DataColumn();
            stt.ColumnName = "STT";
            stt.DataType = System.Type.GetType("System.Int32");
            stt.AutoIncrement = true;
            bangfile.Columns.Add(stt);
            bangfile.Columns.Add("Tên file", typeof(string));
            bangfile.Columns.Add("Đường dẫn", typeof(string));
        }

        private void dgvFileAttach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == this.dgvFileAttach.Columns["STT"].Index)
            {
                e.Value = e.RowIndex + 1;
            }
        }

        private void DinhDangTien(TextBox t)
        {
            try
            {
                if (_fSetText)
                {
                    string strTemp = t.Text.ToString().Trim();
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
                    t.Text = flTienThuong.ToString("#,###.##");
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
                //MessageBox.Show("Hàm định dạng tiền sai");
            }
        }

        private void HienDanhSachFile()
        {
            string strFile = @"SELECT idFile,strFileName, strNgayCapNhat FROM tblAttachFileHS WHERE idHS=" + idHoSo + " ORDER BY idFile desc";
            DataTable dtFile = h.getData(strFile, con);
            dgvFileAttach.DataSource = dtFile;
            //lblSumFileAttack.Text = "Có " + dtFile.Rows.Count + " tập tin được đính kèm trong hồ sơ";
        }


        private void KhoiTaoXemSua()
        {
            _maduan = idHoSo;
            _tenduan = linq.lay_tenduan(idHoSo);
            _diadiem = linq.lay_diadiem(idHoSo);
            _dientich = linq.lay_dientich(idHoSo);
            _nbd = linq.lay_ngaybatdau(idHoSo);
            _nkt = linq.lay_ngayketthuc(idHoSo);
            _gthd = linq.lay_giatrihopdong(idHoSo).Value;
            _gttqt = linq.lay_giatrithanhquyettoan(idHoSo).Value;
            _madttc = linq.lay_madoitruong(idHoSo).Value;
            _manth = linq.lay_manguoilaphoso(idHoSo).Value;
            _linkfile = linq.lay_filedinhkiem(idHoSo);
            _ghichu = linq.lay_ghichuduan(idHoSo);
            _gthdchu = linq.lay_gthdchu(idHoSo);
            _gttqtchu = linq.lay_gttqtchu(idHoSo);
            if(_manth != -1)
            {
                _nth_trangthai = linq.lay_trangthai(_manth).Value;
                _nth_hoten = linq.lay_tennhanvien(_manth);
                _nth_capbac = linq.lay_capbac(_manth);
                _nth_chucvu = linq.lay_chucvu(_manth);
            }

            else
            {
                _nlhskhac = linq.lay_nlhskhac(_maduan);
            }

            if(_madttc != -1)
            {
                _dttc_trangthai = linq.lay_trangthai(_madttc).Value;
                _dttc_hoten = linq.lay_tennhanvien(_madttc);
                _dttc_capbac = linq.lay_capbac(_madttc);
                _dttc_chucvu = linq.lay_chucvu(_madttc);
            }

            else
            {
                _dttckhac = linq.lay_dttckhac(_maduan);
            }

        }

        private bool KiemTraNam(TextBox t)
        {
            string str = ToString(t);
            try
            {
                int x = Convert.ToInt32(str);
                if (x < 2100 && x > 1945) return true;
                return false;
            }
            catch
            {
                if (str == "") return true;
                return false;
            }

        }

        private bool KiemTraNgay(TextBox ngay, TextBox thang, TextBox nam)
        {
            string _ngay = ToString(ngay);
            string _thang = ToString(thang);
            string _nam = ToString(nam);
            try
            {
                if (_ngay == "") return true;
                else
                {
                    if (_thang == "") return Convert.ToInt32(_ngay) < 32;
                    else
                    {

                        int t = Convert.ToInt32(_thang);
                        int n = Convert.ToInt32(_ngay);
                        if (t == 1 || t == 3 || t == 5 || t == 7 || t == 8 || t == 10 || t == 12)
                            if (n <= 31) return true; else return false;
                        else if (t == 4 || t == 6 || t == 9 || t == 11)
                            if (n <= 30) return true; else return false;

                        else if (t == 2)
                        {
                            //Chi co ngay, thang
                            if (_nam == "")
                                if (n <= 29) return true; else return false;
                            //Co ca ngay, thang, nam
                            else
                            {
                                int nn = Convert.ToInt32(_nam);
                                return NamNhuan(n, t, nn);
                            }
                        }

                    }
                }
                return true;
            }

            catch
            {
                return false;
            }


        }

        private bool KiemTraThang(TextBox t)
        {
            string str = ToString(t);
            try
            {
                int x = Convert.ToInt32(str);
                if (x < 13) return true;
                return false;
            }
            catch
            {
                if (str == "") return true;
                return false;
            }

        }

        private void KiemTraTruongNam(TextBox nam)
        {
            if (!KiemTraNam(nam))
                TruongSaiChuyenMau(nam);
            else TruongDungChuyenMau(nam);
        }

        private void KiemTraTruongNgay(TextBox ngay, TextBox thang, TextBox nam)
        {
            if (!KiemTraNgay(ngay, thang, nam))
                TruongSaiChuyenMau(ngay);
            else TruongDungChuyenMau(ngay);
        }

        private void KiemTraTruongThang(TextBox thang)
        {
            if (!KiemTraThang(thang))
                TruongSaiChuyenMau(thang);
            else TruongDungChuyenMau(thang);
        }
        private void LoadComboboxFile()
        {

            if (_linkfile != "" && _linkfile != null)
            {
                string[] dspath = _linkfile.Split(',');

                for (int i = 0; i < dspath.Length; i++)
                {
                    if (dspath[i] != "")
                    {
                        danhsachpath.Add(dspath[i]);
                        int vitrixuathiencuoi = dspath[i].LastIndexOf('\\');
                        string tenfile = dspath[i].Substring(vitrixuathiencuoi + 1);
                        //sttFile++;
                        bangfile.Rows.Add(sttFile, tenfile, dspath[i]);
                    }

                }

                dgvFileAttach.DataSource = bangfile;


            }

        }

        private void LoadComboTenDTTC(int i)
        {
            if (i == 0)
            {
                var v = linq.lay_cottennhanvien();


                cb_dttc_hoten.DataSource = v;
                cb_dttc_hoten.ValueMember = "tennhanvien";
            }
            else if (i == 1)
            {
                var v = linq.lay_cottenchuyengia();
                cb_dttc_hoten.DataSource = v;
                cb_dttc_hoten.ValueMember = "tennhanvien";
            }

            
        }

        private void LoadComboTenNLHS(int i)
        {
            if (i == 0)
            {
                var v = linq.lay_cottennhanvien();
                cb_nth_hoten.DataSource = v;
                cb_nth_hoten.ValueMember = "tennhanvien";
               
            }
            else if (i == 1)
            {
                var v = linq.lay_cottenchuyengia();
                cb_nth_hoten.DataSource = v;
                cb_nth_hoten.ValueMember = "tennhanvien";
            }
        }

        private bool NamNhuan(int ngay, int thang, int nam)
        {
            if (nam % 4 == 0)
            {
                if (nam % 100 == 0 && ngay > 28) return false; //nam không nhuân
                if (ngay > 29) return false;
            }

            else if (ngay > 28) return false;
            return true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtDoiTruongThiCong.Enabled = rdb_dttc_other.Checked;
            txtDoiTruongThiCong.ReadOnly = !rdb_dttc_other.Checked;
        }

        private void rdb_dttc_nv_CheckedChanged(object sender, EventArgs e)
        {
            cb_dttc_hoten.Enabled = rdb_dttc_nv.Checked;
            cb_loai_dttc.Enabled = rdb_dttc_nv.Checked;
            txt_dttc_capbac.ReadOnly = !rdb_dttc_nv.Checked;
            txt_dttc_chucvu.ReadOnly = !rdb_dttc_nv.Checked;
        }

        private void rdb_nlhs_nv_CheckedChanged(object sender, EventArgs e)
        {
            cb_nth_hoten.Enabled = rdb_nlhs_nv.Checked;
            cb_loai_nlhs.Enabled = rdb_nlhs_nv.Checked;
            label_nth_capbac.ReadOnly = !rdb_nlhs_nv.Checked;
            txt_nth_chucvu.ReadOnly = !rdb_nlhs_nv.Checked;
        }

        private void rdb_nlhs_other_CheckedChanged(object sender, EventArgs e)
        {
            txtNguoiLamHoSo.Enabled = rdb_nlhs_other.Checked;
            txtNguoiLamHoSo.ReadOnly = !rdb_nlhs_other.Checked;
        }
        private void SuaXemLoad()
        {
            //LoadComboTen();

            txtMaHS.Text = _maduan.ToString();
            txtMaHS.ReadOnly = true;
            txt_tenduan.Text = _tenduan;
            txt_diadiem.Text = _diadiem;
            txt_dientich.Text = _dientich;
            txt_gthd_bangchu.Text = _gthdchu;
            txt_gttqt_bangchu.Text = _gttqtchu;
            TachDienTich();

            if(_manth != -1)
            {
                rdb_nlhs_nv.Checked = true;
                rdb_nlhs_other.Checked = false;
               if(_nth_trangthai != -1) cb_loai_nlhs.SelectedIndex = _nth_trangthai;
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("tennhanvien", typeof(string));
                    DataRow dr = dt.NewRow();
                    dr["tennhanvien"] = _nth_hoten;
                    dt.Rows.InsertAt(dr, 0);
                    cb_nth_hoten.ValueMember = "tennhanvien";
                    cb_nth_hoten.DisplayMember = "tennhanvien";
                    cb_nth_hoten.DataSource = dt;
                    cb_nth_hoten.SelectedIndex = 0;
                }

                label_nth_capbac.Text = _nth_capbac;
                txt_nth_chucvu.Text = _nth_chucvu;
            }
            else
            {
                rdb_nlhs_nv.Checked = false;
                rdb_nlhs_other.Checked = true;
                txtNguoiLamHoSo.Text = _nlhskhac;
            }

            if(_madttc != -1)
            {
                rdb_dttc_nv.Checked = true;
                rdb_dttc_other.Checked = false;
                if (_dttc_trangthai != -1)
                {


                    cb_loai_dttc.SelectedIndex = _dttc_trangthai;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("tennhanvien", typeof(string));
                    DataRow dr = dt.NewRow();
                    dr["tennhanvien"] = _dttc_hoten;
                    dt.Rows.InsertAt(dr, 0);
                    cb_dttc_hoten.ValueMember = "tennhanvien";
                    cb_dttc_hoten.DisplayMember = "tennhanvien";
                    cb_dttc_hoten.DataSource = dt;
                    cb_dttc_hoten.SelectedIndex = 0;
                }
                txt_dttc_capbac.Text = _dttc_capbac;
                txt_dttc_chucvu.Text = _dttc_chucvu;

            }
            else
            {
                rdb_dttc_nv.Checked = false;
                rdb_dttc_other.Checked = true;
                txtDoiTruongThiCong.Text = _dttckhac;

            }
            txt_gthd.Text = _gthd.ToString();
            DinhDangTien(txt_gthd);
            txt_gttqt.Text = _gttqt.ToString();
            DinhDangTien(txt_gttqt);

            txt_batdau_ngay.Text = TachNgay(_nbd);
            txt_batdau_thang.Text = TachThang(_nbd);
            txt_batdau_nam.Text = TachNam(_nbd);
            txt_ketthuc_ngay.Text = TachNgay(_nkt);
            txt_ketthuc_thang.Text = TachThang(_nkt);
            txt_ketthuc_nam.Text = TachNam(_nkt);
            
            LoadComboboxFile();
            txt_ghichu.Text = _ghichu;
        }

        private void TachDienTich()
        {
            cb_donvi.Text = "";
            string str = txt_dientich.Text.ToString().Trim();
            string[] strs = str.Split(' ');
            string so = ""; string donvi = "";
            for (int i = 0; i < strs.Length; i++)
            {
                if (strs[i] != "")
                {
                    if (so == "") so = strs[i];
                    else donvi = strs[i];
                }

            }
            cb_donvi.SelectedText = donvi;

            txt_dientich.Text = so;
        }

        private string TachNam(string str)
        {

            int leng = str.Length;
            string nam = "";
            if (leng >= 4)
            {
                nam = str.Substring(leng - 4, 4);
            }
            return nam;
        }

        private string TachNgay(string str)
        {
            int leng = str.Length;
            string ngay = "";
            if (leng == 10) ngay = str.Substring(0, 2);
            return ngay;
        }

        private string TachThang(string str)
        {
            int leng = str.Length;
            string thang = "";
            if (leng >= 7)
            {
                thang = str.Substring(leng - 7, 2);
            }
            return thang;
        }

        private string Them0(string str)
        {
            try
            {
                if (str.Length == 1) str = "0" + str;
                return str;
            }
            catch
            {
                MessageBox.Show("Lỗi khi chuyển về đúng định dạng của thời gian!");
            }
            return str;
        }
        private string ToString(TextBox t)
        {
            try
            {
                return t.Text.ToString().Trim();
            }
            catch
            {
                return "";
            }

        }

        private string ToString(ComboBox t)
        {
            try
            {
                return t.Text.ToString().Trim();
            }
            catch
            {
                return "";
            }

        }

        private void TruongDungChuyenMau(TextBox t)
        {
            t.ForeColor = Color.Black;
        }

        private void TruongSaiChuyenMau(TextBox t)
        {
            //VoHieuHoaNutThem();
            t.ForeColor = Color.Red;

            //t.Focus();

        }

        private void txt_batdau_nam_TextChanged(object sender, EventArgs e)
        {
            KiemTraTruongNam(txt_batdau_nam);
            KiemTraTruongNgay(txt_batdau_ngay, txt_batdau_thang, txt_batdau_nam);
        }

        private void txt_batdau_ngay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBoxEx.Show("Có lỗi xảy ra\nGiá trị trường thời gian phải là một số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txt_batdau_ngay.Focus();
            }

        }

        private void txt_batdau_ngay_TextChanged(object sender, EventArgs e)
        {
            KiemTraTruongNgay(txt_batdau_ngay, txt_batdau_thang, txt_batdau_nam);
        }

        private void txt_batdau_thang_TextChanged(object sender, EventArgs e)
        {
            KiemTraTruongThang(txt_batdau_thang);
            KiemTraTruongNgay(txt_batdau_ngay, txt_batdau_thang, txt_batdau_nam);
        }

        private void txt_dientich_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nếu bạn muốn, bạn có thể cho phép nhập số thực với dấu chấm
            if( (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) || ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)))
            {
                e.Handled = true;
                MessageBoxEx.Show("Có lỗi xảy ra\nGiá trị diện tích phải là một số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txt_dientich.Focus();

            }
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //    txt_dientich.Focus();
            //}
            cb_donvi.Text = "";

        }

        private void txt_dientich_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_gthd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBoxEx.Show("Có lỗi xảy ra\nGiá trị hợp đồng phải là một số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_gthd.Focus();

            }
            cb_donvi.Text = "";

        }

        private void txt_gthd_TextChanged(object sender, EventArgs e)
        {
            DinhDangTien(txt_gthd);
        }

        private void txt_gthd_TextChanged_1(object sender, EventArgs e)
        {
            DinhDangTien(txt_gthd);
        }

        private void txt_gttqt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBoxEx.Show("Có lỗi xảy ra\nGiá trị thanh quyết toán phải là một số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_gttqt.Focus();

            }
        }

        private void txt_gttqt_TextChanged(object sender, EventArgs e)
        {
            DinhDangTien(txt_gttqt);
        }

        private void txt_ketthuc_nam_TextChanged(object sender, EventArgs e)
        {
            KiemTraTruongNam(txt_ketthuc_nam);
            KiemTraTruongNgay(txt_ketthuc_ngay, txt_ketthuc_thang, txt_ketthuc_nam);
        }

        private void txt_ketthuc_ngay_TextChanged(object sender, EventArgs e)
        {
            KiemTraTruongNgay(txt_ketthuc_ngay, txt_ketthuc_thang, txt_ketthuc_nam);
        }

        private void txt_ketthuc_thang_TextChanged(object sender, EventArgs e)
        {
            KiemTraTruongThang(txt_ketthuc_thang);
            KiemTraTruongNgay(txt_ketthuc_ngay, txt_ketthuc_thang, txt_ketthuc_nam);
        }

        private void txt_noiluutru_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGiaTriHopDong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGiaTriThanhToan_TextChanged(object sender, EventArgs e)
        {
            DinhDangTien(txt_gthd);
        }

        #region Properties

        public bool BtnSaveClose
        {
            get { return this.btnSaveClose.Visible; }
            set { this.btnSaveClose.Visible = value; }
        }
        // thuộc tính nút gắn file vào hồ sơ

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

        private Option opThemSua;
        private int idHoSo;
        Helper h;
        SqlConnection con;
        TienIchNghiepVu TienIch;
        int sttFile = 0;
        #endregion


        #region AddFileAttack
        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            //if (txt_noiluutru.Text.ToString() != "" ||
                //MessageBox.Show("Bạn có muốn chọn thư mục lưu trữ mới?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
           // {
                OpenFileDialog fDialog = new OpenFileDialog();
                fDialog.Title = "Chọn tập tin đính kèm";
                fDialog.Multiselect = true;
                fDialog.Filter = "PDF Files|*.pdf|All Files|*.*";
                //fDialog.Filter = "Pdf Files|*.pdf";
                if (fDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] dsten = fDialog.SafeFileNames;

                    string[] dspath = fDialog.FileNames;

                    for (int i = 0; i < dsten.Length; i++)
                    {
                        danhsachpath.Add(dspath[i]);
                        sttFile++;
                        bangfile.Rows.Add(sttFile, dsten[i], dspath[i]);

                    }
                    dgvFileAttach.DataSource = bangfile;
                }
          //  }
        }

        private void btnAttachHS_Click(object sender, EventArgs e)
        {


            //Đưa danh sách file được chọn vào list tổng

        }


        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            try
            {
                int row = dgvFileAttach.CurrentRow.Index;
                for (int i = 0; i < danhsachpath.Count; i++)
                {
                    if (i == row)
                    {
                        //MessageBox.Show(row.ToString());
                        danhsachpath.Remove(danhsachpath[i]);

                        break;
                    }
                }
                bangfile.Rows.RemoveAt(row);
                dgvFileAttach.DataSource = bangfile;

            }
            catch
            {
                MessageBox.Show("Loại bỏ file đã xảy ra lỗi!");
            }
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
            //if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            //{
            //    e.Handled = true;
            //    MessageBoxEx.Show("Có lỗi xảy ra\nSố tiền phải là một số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txt_gthd.Focus();
            //}
        }

        private void txtGiaTriThanhToan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBoxEx.Show("Có lỗi xảy ra\nSố tiền phải là một số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_gttqt.Focus();
            }
        }

        private void txtDienTich_Validated(object sender, EventArgs e)
        {
            if (txt_dientich.Text.Trim() != "")
            {
                if (!IsNumber(txt_dientich.Text))
                {
                    MessageBoxEx.Show("Diện tích phải là một số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_dientich.Focus();
                    txt_dientich.Text = "";
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

        private void cb_donvi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool DienTruongDonVi() 
        {
            if(!String.IsNullOrEmpty(txt_dientich.Text) && String.IsNullOrEmpty(cb_donvi.Text))
                {
                    return true;
                }
            return false;
        }
        private bool CacTruongBatBuocDien()
        {
            //if (cb_loai_dttc.SelectedIndex != 0 && cb_loai_dttc.SelectedIndex != 1) return false;
            //if (cb_loai_nlhs.SelectedIndex != 0 && cb_loai_nlhs.SelectedIndex != 1) return false;
            if(ToString(txt_dientich) != "") {
               
                if (rdb_nlhs_nv.Checked)
                {
                    if (cb_nth_hoten.SelectedItem == null) return false;
                }
                else if (ToString(txtNguoiLamHoSo) == "") return false;

                if (rdb_dttc_nv.Checked)
                {
                    if (cb_dttc_hoten.SelectedItem == null) return false;
                }
                else if (ToString(txtDoiTruongThiCong) == "") return false;
            }
           
            return true;
        }

        private void Refresh()
        {
            txtMaHS.Text = linq.lay_idcuoi().Value.ToString();
        }

        private void ThemTieptucRefresh()
        {
            txt_tenduan.Text = "";
            txt_diadiem.Text = "";
            txt_dientich.Text = "";
            cb_donvi.Text = "";
            rdb_dttc_other.Checked = true; txtDoiTruongThiCong.Text = "";
            rdb_nlhs_other.Checked = true; txtNguoiLamHoSo.Text = "";
            txt_gthd.Text = "";
            txt_gttqt.Text = "";
            txt_gthd_bangchu.Text = "";
            txt_gttqt_bangchu.Text = "";
            txt_batdau_ngay.Text = "";
            txt_batdau_thang.Text = "";
            txt_batdau_nam.Text = "";
            txt_ketthuc_ngay.Text = "";
            txt_ketthuc_thang.Text = "";
            txt_ketthuc_nam.Text = "";
            txt_ghichu.Text = "";
            dgvFileAttach.DataSource = null;
        }

        private void dgvFileAttach_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            buttonX1.Enabled = true;
            btnDeleteFile.Enabled = true;
        }

        private void txt_dientich_Validating(object sender, CancelEventArgs e)
        {
        }

        private void txt_dientich_Validated(object sender, EventArgs e)
        {
            DinhDangTien(txt_dientich);

        }

        
    }
}
