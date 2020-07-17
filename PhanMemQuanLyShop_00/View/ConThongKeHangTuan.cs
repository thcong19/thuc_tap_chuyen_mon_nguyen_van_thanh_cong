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
    public partial class ConThongKeHangTuan : DevExpress.XtraEditors.XtraForm
    {
        ThongKeHangHoaControl TKControl = new ThongKeHangHoaControl();
        public ConThongKeHangTuan()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtThongKeTheoNgay = new DataTable();
                dtThongKeTheoNgay = TKControl.ThongKeHangTheoNgay(txtTuNgay.Text.Trim(), txtDenNgay.Text.Trim());
                gridControl1.DataSource = dtThongKeTheoNgay;
            }
            catch { }
        }

        private void ConThongKeHangTuan_Load(object sender, EventArgs e)
        {
            //txtTuNgay.Text = txtDenNgay.Text = DateTime.Today.ToString().Split(' ')[0];
        }

        private void btnInThongKe_Click(object sender, EventArgs e)
        {
            XtraReport rp = new XtraReport();
            rp.DataSource = TKControl.ThongKeHangTheoNgay(txtTuNgay.Text.Trim(), txtDenNgay.Text.Trim());
            rp.LoadLayout(Application.StartupPath + @"\ThongKeHangNam.repx");
            rp.ShowPreviewDialog();
        }
    }
}