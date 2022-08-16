using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace QLHS.Utilities
{
    class TienIchNghiepVu
    {
        
        
        // Hàm kierm tra tab khi active
        public bool checkExitTab(string strNameTab, SuperTabControl strNameSuperTab)
        {
            foreach (SuperTabItem tabPage in strNameSuperTab.Tabs)
            {
                if (tabPage.Text == strNameTab)
                {
                    strNameSuperTab.SelectedTab = tabPage;
                    return true;
                }
            }
            return false;
        }

        // tạo năm
        public void setValueCboNamSinh(DevComponents.DotNetBar.Controls.ComboBoxEx cbo)
        {
            for (int nam = 1930; nam <= Convert.ToInt32(DateTime.Now.Year); nam++)
            {
                cbo.Items.Add(nam);
            }
            // Set năm hiện tại được chọn

        }
        // tạo tháng
        public void setValueCboThang(DevComponents.DotNetBar.Controls.ComboBoxEx cbo)
        {
            for (int thang = 0; thang <= 12; thang++)
            {
                cbo.Items.Add(thang);
            }
        }

        // Hàm kiểm tra năm nhuận
        private bool isNhuan(int year)
        {
            if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0))
                return true;
            else return false;
        }

        // Hàm lấy ngày
        public void setCboNgay(DevComponents.DotNetBar.Controls.ComboBoxEx cbo, int year, int month, int valueDefault)
        {
            int i;

            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    for (i = 0; i <= 31; i++)
                    {
                        cbo.Items.Add(i);
                    }
                    break;
                case 2:
                    if (isNhuan(year))
                    {
                        for (i = 0; i <= 29; i++)
                            cbo.Items.Add(i);
                    }
                    else
                    {
                        for (i = 0; i <= 28; i++)
                            cbo.Items.Add(i);
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    for (i = 0; i <= 30; i++)
                        cbo.Items.Add(i);
                    break;
                case 0:
                    cbo.Items.Add(0);
                    break;
            }

            // Nếu vị trí của giá trị mặc định ở vị trí -1, tức là chọn ngày >=29 mà rơi vào tháng 2 thì sẽ lấy ngày lớn nhát của tháng 2
            // Ngoài ra thì vị trí chọn mặc định ở index
            int index = getIndexValueComb(cbo, valueDefault);
            if (index == -1)
                cbo.SelectedIndex = cbo.Items.Count - 1;
            else cbo.SelectedIndex = index;
        }

        // lấy index được select trong combo
        public int getIndexValueComb(DevComponents.DotNetBar.Controls.ComboBoxEx cbo, int value)
        {
            int vitri = -1;
            for (int i = 0; i < cbo.Items.Count; i++)
                if (value == Convert.ToInt32(cbo.Items[i].ToString()))
                {
                    vitri = i;
                    break;
                }
            return vitri;
        }

        // chuẩn hóa chuỗi họ và tên
        public string ChuanHoa(string strInput)
        {
            strInput = strInput.Trim().ToLower();
            while (strInput.Contains("  "))
                strInput = strInput.Replace("  ", " ");
            string strResult = "";
            string[] arrResult = strInput.Split(' ');
            foreach (string item in arrResult)
                strResult += item.Substring(0, 1).ToUpper() + item.Substring(1) + " ";
            return strResult.TrimEnd();
        }

        // hàm kiểm tra nhập số (diện tích)
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        // Hàm lấy username để tạo mã hồ sơ
        private string getUserName(int idUser, SqlConnection con)
        {
            string kq = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_getUserName_ByID";

            cmd.Parameters.Add("@idUser", SqlDbType.Int);
            cmd.Parameters["@idUser"].Value = idUser;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
                kq = dt.Rows[0]["prefixHoSoVanBan"].ToString();
            else kq = String.Empty;
            return kq;
        }

        // Hàm lấy id lớn nhất hiện thời của Hồ sơ
        private string getIdMaxHoSo(string tblHoSoName, SqlConnection con)
        {
            string sql = @"SELECT MAX(idHS) AS maxID FROM " + tblHoSoName;
            int maxID = 0;
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            object dtMax = dt.Rows[0]["maxID"];
            if (dtMax != DBNull.Value)
                maxID = Convert.ToInt32(dt.Rows[0]["maxID"].ToString());
            maxID++; // tăng lên 1 để cho hs kế tiếp
            return maxID.ToString();
        }

        // Hàm đưa ra strMaHoSoVanBan
        public string getMaHoSoVanBan(int idUser, string tblHoSoName, SqlConnection con)
        {
            return getUserName(idUser, con) + getIdMaxHoSo(tblHoSoName, con);
        }

        // Hàm kiểm tra thông tin hồ sơ đã tồn tại trong hệ thống hay chưa, trả về true OR false
        public bool checkExitsInfoHoSo(int idNhomHoSo, string strTieuDeHoSo, string strChuSuDung, SqlConnection con)
        {
            bool kq = false;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_Check_ThongTin_HoSo_TrungLap";

            cmd.Parameters.Add("@idNhomHoSo", SqlDbType.Int);
            cmd.Parameters["@idNhomHoSo"].Value = idNhomHoSo;

            cmd.Parameters.Add("@strChuSuDung", SqlDbType.NVarChar);
            cmd.Parameters["@strChuSuDung"].Value = strChuSuDung;

            cmd.Parameters.Add("@strTieuDeHoSo", SqlDbType.NVarChar);
            cmd.Parameters["@strTieuDeHoSo"].Value = strTieuDeHoSo;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dta = new DataTable();
            da.Fill(dta);
            if (Convert.ToInt32(dta.Rows[0]["soHoSo"].ToString()) > 0) kq = true;
            else kq = false;
            return kq;
        }

        // Hàm lấy thông tin hồ sơ để hiển thị khi có hồ sơ trùng lặp
        public string HienThiThongTinHoSo_TrungLap(int idNhomHoSo, string strTieuDeHoSo, string strTenChuSuDung, string loaiHoSo, SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetThongTin_HoSo_TrungLap";

            cmd.Parameters.Add("@idNhomHoSo", SqlDbType.Int);
            cmd.Parameters["@idNhomHoSo"].Value = idNhomHoSo;

            cmd.Parameters.Add("@strChuSuDung", SqlDbType.NVarChar);
            cmd.Parameters["@strChuSuDung"].Value = strTenChuSuDung;

            cmd.Parameters.Add("@strTieuDeHoSo", SqlDbType.NVarChar);
            cmd.Parameters["@strTieuDeHoSo"].Value = strTieuDeHoSo;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Hiển thị thông tin ra dialog
            string strThongTin = string.Empty;
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                #region Thông tin chủ sử dụng
                object drThua = dr["strTenThua"];
                object drBanDo = dr["strToBanDo"];
                object drDienTich = dr["intDienTich"];
                i++;
                strThongTin += "\n          - Hồ sơ thứ " + i.ToString() + ": ";
                if (drThua != DBNull.Value)
                {
                    strThongTin += "Tên thửa: " + dr["strTenThua"].ToString();
                }

                if (drBanDo != DBNull.Value)
                {
                    if (drThua != DBNull.Value)
                    {
                        strThongTin += ", Tờ bản đồ: " + dr["strToBanDo"].ToString();
                    }
                    else
                    {
                        strThongTin += "Tờ bản đồ: " + dr["strToBanDo"].ToString();
                    }
                }

                if (drDienTich != DBNull.Value)
                {
                    if (drBanDo != DBNull.Value)
                    {
                        strThongTin += ", Diện tích: " + dr["intDienTich"].ToString() + "m²";
                    }
                    else
                    {
                        strThongTin += "Diện tích: " + dr["intDienTich"].ToString() + "m²";
                    }
                }
                #endregion
            }
            // thông báo
            string kqdgl = "Tiêu đề (tên) hồ sơ và các thông tin về hồ sơ vừa nhập đã tồn tại trong hệ thống:";
            kqdgl += "\n";
            kqdgl += "\n+ Tiêu đề (tên) hồ sơ: " + strTieuDeHoSo;
            kqdgl += "\n+ " + loaiHoSo + ": " + strTenChuSuDung; // chủ sử dụng hoặc chủ đầu tư
            if (strThongTin != "")
                kqdgl += strThongTin;
            kqdgl += "\n";
            kqdgl += "\n1. Nhấn OK để tiếp tục lưu thông tin hồ sơ";
            kqdgl += "\n2. Nhấn Cancel để kiểm tra và sửa lại hoặc hủy bỏ thông tin";

            return kqdgl;
        }
    }
}

