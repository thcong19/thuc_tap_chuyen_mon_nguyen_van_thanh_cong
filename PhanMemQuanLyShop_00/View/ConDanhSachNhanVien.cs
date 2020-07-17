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
    public partial class ConDanhSachNhanVien : DevExpress.XtraEditors.XtraForm
    {
        DanhSachNhanVienControl DSnhanVienControl = new DanhSachNhanVienControl();
        public ConDanhSachNhanVien()
        {
            InitializeComponent();
        }
        public void ShowData(bool kt)
        {
            gridControl1.Enabled = kt;
        }
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            ShowData(false);
        }

        private void ConDanhSachNhanVien_Load(object sender, EventArgs e)
        {
            ShowData(true);
            //load thông tin cho text mã nhân viên
            DataTable dtMaNV = new DataTable();
            dtMaNV = DSnhanVienControl.HienThiTextMa();
            txtMaNhanVien.Properties.DataSource = dtMaNV;
            txtMaNhanVien.Properties.NullText = "";
            txtMaNhanVien.Properties.ValueMember = "MaNhanVien";
            txtMaNhanVien.Properties.DisplayMember = "MaNhanVien";
            //load thông tin cho text tên nhân viên
            DataTable dtTenNV = new DataTable();
            dtTenNV = DSnhanVienControl.HienThiTextTen();
            txtTenNhanVien.Properties.DataSource = dtTenNV;
            txtTenNhanVien.Properties.NullText = "";
            txtTenNhanVien.Properties.ValueMember = "HoTen";
            txtTenNhanVien.Properties.DisplayMember = "HoTen";
        }
        private void btnHienThi_DoubleClick(object sender, EventArgs e)
        {
            ShowData(true);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNhanVien.Text == "")
                    return;
                else
                {
                    DataTable dtNhanVien = new DataTable();
                    dtNhanVien = DSnhanVienControl.HienThiTimKiemChung(txtNhanVien.Text.Trim());
                    gridControl1.DataSource = dtNhanVien;
                }
            }
            catch
            { MessageBox.Show("Lỗi"); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtNhanVien.Text = "";
            txtMaNhanVien.Properties.NullText = ""; 
            txtTenNhanVien.Properties.NullText = "";
            ConDanhSachNhanVien_Load(sender, e);
            DataTable dtChung = new DataTable();
            dtChung = DSnhanVienControl.HienThiChung();
            gridControl1.DataSource = dtChung;
        }

        private void btnTimMa_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtNhanVien = new DataTable();
                dtNhanVien = DSnhanVienControl.HienThiTimKiemMa(txtMaNhanVien.Text);
                gridControl1.DataSource = dtNhanVien;
            }
            catch
            { MessageBox.Show("Lỗi"); }
        }

        private void txtTenNhanVien_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtNhanVien = new DataTable();
                dtNhanVien = DSnhanVienControl.HienThiTimKiemTen(txtMaNhanVien.Text);
                gridControl1.DataSource = dtNhanVien;
            }
            catch
            { MessageBox.Show("Lỗi"); }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                txtMa.Text= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaNhanVien").ToString();
                txtTen.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "HoTen").ToString();
                txtCMND.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CMND").ToString();
                txtDiaChi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DiaChi").ToString();
                txtDT.Text= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SDT").ToString();
            }
            catch
            {
                return;
            }
        }
    }
}