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

    //public enum Option
    //{
    //    them = 0,
    //    sua = 1,
    //    xem = 2
    //}

    //public enum TabChucNang
    //{
    //    toanbo = 0,
    //    theoten = 1,
    //    theonam = 2
    //}
    public partial class A_ThemNhanSu : Office2007Form
    {
        //Hàm khởi tạo chức năng thêm
        LINQDataContext linq = new LINQDataContext();
        int _ma;
        Option _loai;
        public A_ThemNhanSu(Option loai, int ma, int nguoi)
        {
            InitializeComponent();

            _loai = loai;
            _ma = ma;
            if (nguoi == 0) rdb_nhanvien.Checked = true;
            else rdb_chuyengia.Checked = true;
            if (_loai == Option.them) KhoiTaoThem();
            else if (_loai == Option.sua) KhoiTaoSua();
            else KhoiTaoXem();
            txt_manhanvien.ReadOnly = true;
        }

        private void Fill()
        {
            int loai = linq.lay_trangthai(_ma).Value;
            if (loai == 0) rdb_nhanvien.Checked = true;
            else rdb_chuyengia.Checked = true;
            txt_manhanvien.Text = _ma.ToString();
            txt_tennhanvien.Text = linq.lay_tennhanvien(_ma);
            txt_capbac.Text = linq.lay_capbac(_ma);
            txt_chucvu.Text = linq.lay_chucvu(_ma);
            txt_ghichu.Text = linq.lay_ghichunhanvien(_ma);
        }

        private void KhoiTaoThem()
        {
            txt_manhanvien.Text = (linq.lay_idcuoinhanvien().Value).ToString();
            btnSaveClose.Visible = false;
            //chỉnh vị trí
            btnSaveTiep.Location = btnThemDong.Location;
            btnThemDong.Location = btnSaveClose.Location;
        }

        private void KhoiTaoSua()
        {
            Fill();
            btnSaveTiep.Visible = false;
            btnThemDong.Visible = false;
        }

        private void KhoiTaoXem()
        {
            Fill();
            btnSaveTiep.Visible = false;
            btnThemDong.Visible = false;
            btnSaveClose.Visible = false;
        }

        private void ThemNhanVien()
        {
            try
            {
                string hoten = ToString(txt_tennhanvien);
                string capbac = ToString(txt_capbac);
                string chucvu = ToString(txt_chucvu);
                string ghichu = ToString(txt_ghichu);
                bool chuyengia = rdb_chuyengia.Checked;
                if (chuyengia) linq.nthem_nhanvien(hoten, capbac, chucvu, 1,ghichu);
                else linq.nthem_nhanvien(hoten, capbac, chucvu, 0, ghichu);
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra \n Dự án chưa được thêm!");
            }
        }

        private void btnSaveTiep_Click(object sender, EventArgs e)
        {
            ThemNhanVien();
            MessageBox.Show("Thêm thành công!");
            Refresh();
            ThemVaTiepTucRefresh();
        }

        private void btnThemDong_Click(object sender, EventArgs e)
        {
            ThemNhanVien();
            MessageBox.Show("Thêm thành công!");
            this.Close();
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            try
            {
                string hoten = ToString(txt_tennhanvien);
                string capbac = ToString(txt_capbac);
                string chucvu = ToString(txt_chucvu);
                string ghichu = ToString(txt_ghichu);
                bool chuyengia = rdb_chuyengia.Checked;
                if (MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (chuyengia) linq.nsua_nhanvien(_ma, hoten, capbac, chucvu, 1,ghichu);
                    else linq.nsua_nhanvien(_ma, hoten, capbac, chucvu, 0,ghichu);
                    MessageBox.Show("Sửa thành công!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thông tin nhân sự chưa được sửa! " + ex.ToString());
                this.Close();
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Refresh()
        {
            txt_manhanvien.Text = linq.lay_idcuoinhanvien().Value.ToString();
        }

        private void ThemVaTiepTucRefresh()
        {
            txt_tennhanvien.Text = "";
            txt_capbac.Text = "";
            txt_chucvu.Text = "";
            txt_ghichu.Text = "";
        }
    }
}
 