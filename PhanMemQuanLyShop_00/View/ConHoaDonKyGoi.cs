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
    public partial class ConHoaDonKyGoi : DevExpress.XtraEditors.XtraForm
    {
        KyGoiControl kg = new KyGoiControl();
        public ConHoaDonKyGoi()
        {
            InitializeComponent();
        }

        private void ConHoaDonKyGoi_Load(object sender, EventArgs e)
        {
            DataTable dtKyGoi = new DataTable();
            dtKyGoi= kg.HoDonKyGoiFull();
            gridControl1.DataSource = dtKyGoi;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable dtKyGoi = new DataTable();
            dtKyGoi = kg.HoaDonKGoi(txtMaHoaDon.Text.Trim());
            gridControl1.DataSource = dtKyGoi;
        }

        private void btnIn1_Click(object sender, EventArgs e)
        {
            XtraReport rp = new XtraReport();
            rp.DataSource = kg.HoaDonKGoi(txtMaHoaDon.Text.Trim());
            rp.LoadLayout(Application.StartupPath + @"\HoaDonKyGoi.repx");
            //rp.ShowDesignerDialog();
            rp.ShowPreviewDialog();
        }

        private void btnInHet_Click(object sender, EventArgs e)
        {
            XtraReport rp = new XtraReport();
            rp.DataSource = kg.HoDonKyGoiFull();
            rp.LoadLayout(Application.StartupPath + @"\HoaDonKyGoi.repx");
            //rp.ShowDesignerDialog();
            rp.ShowPreviewDialog();
        }

    }
}