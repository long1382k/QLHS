using CrystalDecisions.CrystalReports.Engine;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHS.SubForms
{
    public partial class fr_InThongTinHoSo : Office2007RibbonForm
    {
        // Khai báo các biến để nhận giá trị từ form ngoài
        private DataTable dttable;

        // đối tượng reportDocument
        ReportDocument rpt;
        public fr_InThongTinHoSo()
        {
            InitializeComponent();

        }

        private void fr_InThongTinHoSo_Load(object sender, EventArgs e)
        {
            LoadReport();
        }
        public void LoadReport()
        {
            // khai báo đối tượng crystalReport
            rpt = new ReportDocument();
            rpt.Load(Application.StartupPath + @"\Reports\rptThongTinDuAn.rpt");
            //rpt.SetDataSource(this.dttable);

            // khởi tạo các biến và gọi hàm set các value parameters
            //setParameters();

            // gán dữ liệu vào crviewer
            //crystalReportViewer.ReportSource = rpt;

        }
        // Thủ tục truyền các Parameters
        private void setParameters()
        {
            
        }
    }
}
