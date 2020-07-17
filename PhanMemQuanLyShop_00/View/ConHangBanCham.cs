﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PhanMemQuanLyShop_00.Model;

namespace PhanMemQuanLyShop_00.View
{
    public partial class ConHangBanCham : DevExpress.XtraEditors.XtraForm
    {
        ThongKeHangHoaMod TKhang = new ThongKeHangHoaMod();
        public ConHangBanCham()
        {
            InitializeComponent();
        }

        private void ConHangBanCham_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = TKhang.HangHoaBanCham("100");
            gridControl1.DataSource = dt;
        }
    }
}