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
    public partial class ConThongBao : DevExpress.XtraEditors.XtraForm
    {
        ChamCongControl CCong = new ChamCongControl();
        public ConThongBao()
        {
            InitializeComponent();
        }

        private void btnXemLuong_Click(object sender, EventArgs e)
        {
            DataTable dtXemluong = new DataTable();
            dtXemluong = CCong.HienThiLuong(cbThang.Text,txtNam.Text.Trim());
            gridControl1.DataSource = dtXemluong;
            txtTenNhanVien.Visible = txtLuongNhan.Visible = labelControl3.Visible = labelControl4.Visible = btnXemLuong.Visible = simpleButton1.Visible = true;
            labelControl1.Visible = labelControl2.Visible = txtNam.Visible = cbThang.Visible = false;
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                txtLuongNhan.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LuongNhan").ToString();
                txtTenNhanVien.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenNhanVien").ToString();
            }
            catch { return; }
        }

        private void ConThongBao_Load(object sender, EventArgs e)
        {
            labelControl1.Visible = labelControl2.Visible = txtNam.Visible = cbThang.Visible = true;
            txtTenNhanVien.Visible = txtLuongNhan.Visible = labelControl3.Visible = labelControl4.Visible=simpleButton1.Visible =simpleButton1.Visible= false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ConThongBao_Load(sender,e);
            txtTenNhanVien.Text = txtLuongNhan.Text = "";
        }
    }
}