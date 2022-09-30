using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHS.SubForms
{
    public partial class InThongTinDuAn : Form
    {
        string _tenduan;
        string _diadiem;
        string _dientich;
        string _nth;
        string _dttc;
        string _gthd;
        string _gttqt;
        string _nbd;
        string _nkt;
        string _ghichu;
        string _gthdchu;
        string _gttqtchu;

        public InThongTinDuAn(string tenduan, string diadiem, string dientich, string nth, string dttc, string gthd, string gttqt, string nbd, string nkt, string ghichu, string gthdchu, string gttqtchu) { 
            _tenduan = tenduan;
            _diadiem = diadiem;
            _dientich = dientich;
            _nth = nth;
            _dttc = dttc;
            _gthd = gthd;
            _gttqt = gttqt;
            _nbd = nbd;
            _nkt = nkt;
            _ghichu = ghichu;
            _gthdchu = gthdchu;
            _gttqtchu = gttqtchu;
            InitializeComponent();
        }

        private void InThongTinDuAn_Load(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
                {
                new Microsoft.Reporting.WinForms.ReportParameter("tenduan",_tenduan),
                 new Microsoft.Reporting.WinForms.ReportParameter("diadiem",_diadiem),
                  new Microsoft.Reporting.WinForms.ReportParameter("dientich",_dientich),
                   new Microsoft.Reporting.WinForms.ReportParameter("nth",_nth),
                    new Microsoft.Reporting.WinForms.ReportParameter("dttc",_dttc),
                     new Microsoft.Reporting.WinForms.ReportParameter("gthd",_gthd),
                     new Microsoft.Reporting.WinForms.ReportParameter("gttqt",_gttqt),
                    new Microsoft.Reporting.WinForms.ReportParameter("nbd",_nbd),
                    new Microsoft.Reporting.WinForms.ReportParameter("nkt",_nkt),
                    new Microsoft.Reporting.WinForms.ReportParameter("ghichu",_ghichu),
                    new Microsoft.Reporting.WinForms.ReportParameter("gthdchu",_gthdchu),
                    new Microsoft.Reporting.WinForms.ReportParameter("gttqtchu",_gttqtchu),
                };



            this.reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.RefreshReport();
        }

    }
}
