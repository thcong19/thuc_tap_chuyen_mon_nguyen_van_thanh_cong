using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid;
using PhanMemQuanLyShop_00.View;

namespace PhanMemQuanLyShop_00.Model
{
    public partial class ThongKeDoanhThu : DevExpress.XtraReports.UI.XtraReport
    {
        public ThongKeDoanhThu()
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
                pccDoanhThu.PrintableComponent = control;
            }
        }

        private void xrLabel3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void ThongKeDoanhThu_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {           
                xrLabel3.Text = ConDoanhThuNgay.luudoanhthu.doanhthu;
                xrLabel4.Text = ConDoanhThuNgay.luudoanhthu.tungay;
                xrLabel5.Text = ConDoanhThuNgay.luudoanhthu.denngay;            
        }
    }
}
