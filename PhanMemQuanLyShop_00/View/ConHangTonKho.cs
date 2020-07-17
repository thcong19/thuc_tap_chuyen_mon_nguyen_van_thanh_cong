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

    public partial class ConHangTonKho : DevExpress.XtraEditors.XtraForm
    {
        KhoHangControl kh = new KhoHangControl();
        public ConHangTonKho()
        {
            InitializeComponent();
        }

        private void ConHangTonKho_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = kh.HangTonKho("100");
            gridControl1.DataSource = dt;
        }
    }
}