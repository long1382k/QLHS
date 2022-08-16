 using DevComponents.DotNetBar;
using QLHS.QLHoSo;
using QLHS.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QLHS
{
    public partial class fMainQLHS : Office2007RibbonForm
    {
        private TienIchNghiepVu uCheckTab;
        public fMainQLHS()
        {
            InitializeComponent();
            // đoạn code này để đồng bộ hóa định dạng ngày tháng
            CultureInfo ci = new CultureInfo(Application.CurrentCulture.Name, true);
            DateTimeFormatInfo dfi = new DateTimeFormatInfo();
            dfi.ShortDatePattern = "dd/MM/yyyy";
            ci.DateTimeFormat = dfi;
            Application.CurrentCulture = ci;
            // end
        }
        private void fMainQLHS_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void fMainQLHS_Load(object sender, EventArgs e)
        {
            // Gọi control tạo con trỏ
            this.Cursor = CursorControl.Create(System.IO.Path.Combine(Application.StartupPath, "Pointer.cur"));
            // gọi hàm check tab
            uCheckTab = new Utilities.TienIchNghiepVu();

            // gọi đối tượng Helper để lấy thông tin về server làm giá trị cho status
            Helper h = new Helper(); // khởi tạo


            // lấy ngày giờ hệ thống
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            timerHome.Start(); // khởi động timer
            if (day < 10 && month < 10)
            {
                lblDay.Text = "0" + day.ToString() + "/" + "0" + month.ToString() + "/" + year.ToString();
            }

            else if (day >= 10 && month < 10)
            {
                lblDay.Text = day.ToString() + "/" + "0" + month.ToString() + "/" + year.ToString();
            }
            else
            {
                lblDay.Text = day.ToString() + "/" + month.ToString() + "/" + year.ToString();
            }
        }
        private void timerHome_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            string tabName = "Toàn bộ hồ sơ";
            bool testsata = uCheckTab.checkExitTab(tabName, superTabMain);
            if (!uCheckTab.checkExitTab(tabName, superTabMain))
            {
                try
                {
                    // khởi tạo thread
                    Thread t = new Thread(new ThreadStart(fMainQLHS.frLoading));
                    t.Start();
                    SuperTabItem tabItem = superTabMain.CreateTab(tabName);
                    frToanBoHoSo fToanBoHoSo = new frToanBoHoSo(superTabMain);
                    fToanBoHoSo.TopLevel = false;
                    fToanBoHoSo.Dock = DockStyle.Fill;
                    tabItem.AttachedControl.Controls.Add(fToanBoHoSo);
                    fToanBoHoSo.Show();
                    superTabMain.SelectedTabIndex = superTabMain.Tabs.Count - 1;
                    t.Abort(); // đóng thread
                }
                catch (Exception E) { MessageBoxEx.Show(E.ToString()); }
            }
        }
        // Hàm hiển thị loading
        public static void frLoading()
        {
            Application.Run(new frLoading());
        }
    }
}
