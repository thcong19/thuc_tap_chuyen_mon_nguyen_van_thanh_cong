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
using PhanMemQuanLyShop_00.Model;

namespace PhanMemQuanLyShop_00.View
{
    public partial class ConDoanhThuNgay : DevExpress.XtraEditors.XtraForm
    {
        ThongKeDoanhThuControl TKdoanhThu = new ThongKeDoanhThuControl();
        public ConDoanhThuNgay()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtTheoNgay = new DataTable();
                dtTheoNgay = TKdoanhThu.HienThiDoanhThuNgay(txtTuNgay.Text.Trim(), txtDenNgay.Text.Trim());
                gridControl1.DataSource = dtTheoNgay;
                txtTong.EditValue = colThanhTien.SummaryItem.SummaryValue;
            }
            catch { }
        }

        private void ConDoanhThuNgay_Load(object sender, EventArgs e)
        {
            txtTong.Text = "0";
        }
        public class luudoanhthu
        {
            public static string doanhthu; //gán tên này cho tên hiển thị trên chương trình, biết người đang dùng phần mềm
            public static string tungay;
            public static string denngay;


        }
        private void btnInThongKe_Click(object sender, EventArgs e)
        {
            luudoanhthu.doanhthu = txtTong.Text.Trim();
            luudoanhthu.tungay = txtTuNgay.Text.Trim();
            luudoanhthu.denngay = txtDenNgay.Text.Trim();
            gridView1.BestFitColumns();
            ThongKeDoanhThu report = new ThongKeDoanhThu();
            report.GridControl = gridControl1;
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}