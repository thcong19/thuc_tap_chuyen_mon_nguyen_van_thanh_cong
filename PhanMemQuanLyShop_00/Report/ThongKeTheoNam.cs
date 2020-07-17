using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid;
using PhanMemQuanLyShop_00.View;

namespace PhanMemQuanLyShop_00.Report
{
    public partial class ThongKeTheoNam : DevExpress.XtraReports.UI.XtraReport
    {
        public ThongKeTheoNam()
        {
            InitializeComponent();
        }
        private GridControl control;
        public GridControl GridControl
        {
            get
            {
                return control;
            }
            set
            {
                control = value;
                pccDTTT.PrintableComponent = control;
            }
        }

        private void ThongKeTheoNam_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel3.Text = ConDoanhThuTheoNam.luudoanhthu.doanhthu;
            xrLabel4.Text = ConDoanhThuTheoNam.luudoanhthu.nam;
        }
    }
}
