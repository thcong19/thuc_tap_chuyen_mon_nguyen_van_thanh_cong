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
using PhanMemQuanLyShop_00.Report;
using DevExpress.XtraReports.UI;

namespace PhanMemQuanLyShop_00.View
{
    public partial class ConDoanhThuTheoNam : DevExpress.XtraEditors.XtraForm
    {
        ThongKeDoanhThuControl TKdoanhThu = new ThongKeDoanhThuControl(); 
        public ConDoanhThuTheoNam()
        {
            InitializeComponent();
        }

        private void ConDoanhThuTheoNam_Load(object sender, EventArgs e)
        {

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DataTable dtThongKetheoThang = new DataTable();
            dtThongKetheoThang = TKdoanhThu.HienThiDoanhThuNam(txtnam.Text.Trim());
            gridControl1.DataSource = dtThongKetheoThang;
            txtTong.EditValue = colThanhTien.SummaryItem.SummaryValue;
        }
        public class luudoanhthu
        {
            public static string doanhthu; //gán tên này cho tên hiển thị trên chương trình, biết người đang dùng phần mềm
            public static string nam;



        }
        private void btnInThongKe_Click(object sender, EventArgs e)
        {
            luudoanhthu.doanhthu = txtTong.Text.Trim();
            luudoanhthu.nam = txtnam.Text.Trim();

            gridView1.BestFitColumns();
            ThongKeTheoNam report = new ThongKeTheoNam();
            report.GridControl = gridControl1;
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }
    }
}