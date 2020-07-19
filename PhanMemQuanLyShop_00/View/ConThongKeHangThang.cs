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
    public partial class ConThongKeHangThang : DevExpress.XtraEditors.XtraForm
    {
        ThongKeHangHoaControl TKHangControl = new ThongKeHangHoaControl();
        public ConThongKeHangThang()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DataTable dtThongKeThang = new DataTable();
            dtThongKeThang = TKHangControl.ThongKeHangTheoThang(cbThang.Text.Trim(), txtNam.Text.Trim());
            gridControl1.DataSource = dtThongKeThang;
        }

        private void btnInThongKe_Click(object sender, EventArgs e)
        {
            XtraReport rp = new XtraReport();
            rp.DataSource = TKHangControl.ThongKeHangTheoThang(cbThang.Text.Trim(),txtNam.Text.Trim());
            rp.LoadLayout(Application.StartupPath + @"\ThongKeHangThang.repx");
            rp.ShowPreviewDialog();
        }

        private void ConThongKeHangThang_Load(object sender, EventArgs e)
        {
 
        }
    }
}