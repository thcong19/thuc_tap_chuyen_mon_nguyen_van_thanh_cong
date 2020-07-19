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
namespace PhanMemQuanLyShop_00.View
{
    public partial class ConDanhSachKhachHang : DevExpress.XtraEditors.XtraForm
    {
        KhachHangControl KHcontrol = new KhachHangControl();
        public ConDanhSachKhachHang()
        {
            InitializeComponent();
        }

        private void ConDanhSachKhachHang_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
           dt = KHcontrol.HienThiDuLieu();
           gridControl1.DataSource = dt;
        }
    }
}