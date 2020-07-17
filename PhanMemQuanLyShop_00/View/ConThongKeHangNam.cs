using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PhanMemQuanLyShop_00.Controller;
using DevExpress.XtraReports.UI;

namespace PhanMemQuanLyShop_00.View
{
    public partial class ConThongKeHangNam : DevExpress.XtraEditors.XtraForm
    {
        ThongKeHangHoaControl TKHangControl = new ThongKeHangHoaControl();
        public ConThongKeHangNam()
        {
            InitializeComponent();
        }
        private void btnThongKe_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataTable dtThongKeNam = new DataTable();
                dtThongKeNam = TKHangControl.ThongKeHangTheoNam(txtnam.Text.Trim());
                gridControl1.DataSource = dtThongKeNam;
            }
            catch { MessageBox.Show("Lỗi"); }
        }

        private void btnInThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                XtraReport rp = new XtraReport();
                rp.DataSource = TKHangControl.ThongKeHangTheoNam(txtnam.Text.Trim());
                rp.LoadLayout(Application.StartupPath + @"\ThongKeHangNam.repx");
                rp.ShowPreviewDialog();
            }
            catch { MessageBox.Show("Lỗi"); }
        }

    }
}