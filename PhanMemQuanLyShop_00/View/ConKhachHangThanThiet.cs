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
    public partial class ConKhachHangThanThiet : DevExpress.XtraEditors.XtraForm
    {
        KhachHangControl KHcontrol = new KhachHangControl();
        public ConKhachHangThanThiet()
        {
            InitializeComponent();
        }

        private void ConKhachHangThanThiet_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = KHcontrol.HienThiDuLieuKH("VIP");
            gridControl1.DataSource = dt;
        }
    }
}