using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid;
using PhanMemQuanLyShop_00.View;

namespace PhanMemQuanLyShop_00.Report
{
    public partial class ThongKeTheoThang : DevExpress.XtraReports.UI.XtraReport
    {
        public ThongKeTheoThang()
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

        private void ThongKeTheoThang_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel3.Text = ConDoanhThuThang.luudoanhthu.doanhthu;
            xrLabel4.Text = ConDoanhThuThang.luudoanhthu.thang;

        }
    }
}
