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
    public partial class ConChamCong : DevExpress.XtraEditors.XtraForm
    {
        ChamCongControl CCongControl = new ChamCongControl();
        public ConChamCong()
        {
            InitializeComponent();
        }

        private void ConChamCong_Load(object sender, EventArgs e)
        {
            btnGhiLuong.Visible = false;
            DataTable dtCbNhanVien = new DataTable();
            dtCbNhanVien = CCongControl.HienThiTenNhanVien();
            cbNhanVien.DataSource = dtCbNhanVien;
            cbNhanVien.DisplayMember = "HoTen";
            cbNhanVien.ValueMember = "HoTen";
            DataTable dtHienThi = new DataTable();
            dtHienThi = CCongControl.HienThiThongTin();
            gridControl1.DataSource = dtHienThi;
            txtLuongNhan.Enabled = false;
        }
        private void btnCapMa_Click(object sender, EventArgs e)
        {
            try
            {
                btnGhiLuong.Visible = true;
                TangMaTuDongMaLuong();
                float thuong, phat, luong, luongNhan;
                thuong = float.Parse(txtThuongDoanhThu.Text.Trim());
                phat = float.Parse(txtTienPhat.Text.Trim());
                luong = float.Parse(txtLuongCung.Text.Trim());
                luongNhan = (luong - phat) + thuong;
                txtLuongNhan.Text = Convert.ToString(luongNhan);
            }
            catch
            { }
            
        }
        private void cbNhanVien_SelectedValueChanged(object sender, EventArgs e)
        {
            txtmaNhanVien.Text = CCongControl.HienThiMaNhanVien(cbNhanVien.Text);
        }
        //Tăng mã tự động cho mã nhập
        string chuoi1, chuoi; //các chuổi để làm sinh mã tự động
        int dodai;
        public void TangMaTuDongMaLuong()
        {
            try
            {
                dodai = gridView1.RowCount;
                if (dodai < 10)
                {
                    chuoi = "LNV";
                    chuoi1 = Convert.ToString(dodai);
                    txtMaLuong.Text = string.Concat(chuoi, chuoi1);
                }
                else
                    if (dodai < 100)
                    {
                        chuoi = "LNV";
                        chuoi1 = Convert.ToString(dodai);
                        txtMaLuong.Text = string.Concat(chuoi, chuoi1);
                    }
                    else
                        if (dodai < 1000)
                        {
                            chuoi = "LNV";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaLuong.Text = string.Concat(chuoi, chuoi1);
                        }
                        else
                        {
                            chuoi = "LNV";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaLuong.Text = string.Concat(chuoi, chuoi1);
                        }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        private void btnGhiLuong_Click(object sender, EventArgs e)
        {
            if ((txtBuoiNghi.Text == "") || (txtLuongCung.Text == "") || (txtLuongNhan.Text == "") || (txtMaLuong.Text == "") || (txtmaNhanVien.Text == "") || (txtTangCa.Text == "") || (txtTienPhat.Text == "") || (txtThuongDoanhThu.Text == ""))
                MessageBox.Show("Thiếu thông tin");
            else
            {
                if (CCongControl.ThemLuongMoi(txtMaLuong.Text.Trim(), txtmaNhanVien.Text.Trim(), cbNhanVien.Text.Trim(), cbThang.Text.Trim(), txtNam.Text.Trim(), txtTangCa.Text.Trim(), txtBuoiNghi.Text.Trim(), txtLuongCung.Text.Trim(), txtLuongNhan.Text.Trim(),txtThuongDoanhThu.Text.Trim(),txtTienPhat.Text.Trim()))
                {
                    MessageBox.Show("Đã thêm lương cho nhân viên '" + cbNhanVien.Text.Trim() + "'");
                    ConChamCong_Load(sender, e);
                }
                else
                    MessageBox.Show("Không thành công.");
            }
        }

        private void btnSuaDoi_Click(object sender, EventArgs e)
        {
            if (CCongControl.SuaLuong(txtMaLuong.Text.Trim(), txtmaNhanVien.Text.Trim(), cbNhanVien.Text.Trim(), cbThang.Text.Trim(), txtNam.Text.Trim(), txtTangCa.Text.Trim(), txtBuoiNghi.Text.Trim(), txtLuongCung.Text.Trim(), txtLuongNhan.Text.Trim(),txtThuongDoanhThu.Text.Trim(),txtTienPhat.Text.Trim()))
            {
                MessageBox.Show("Đã cập nhật lương cho nhân viên '" + cbNhanVien.Text.Trim() + "'");
                ConChamCong_Load(sender, e);
            }
            else
                MessageBox.Show("Không thành công.");
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                txtBuoiNghi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NghiLam").ToString();
                txtLuongCung.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LuongCung").ToString();
                txtLuongNhan.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LuongNhan").ToString();
                txtMaLuong.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaChamCong").ToString();
                txtmaNhanVien.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaNhanVien").ToString();
                txtNam.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Nam").ToString();
                txtTangCa.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TangCa").ToString();
                txtTienPhat.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TienPhat").ToString();
                txtThuongDoanhThu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TienThuong").ToString();
                cbNhanVien.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenNhanVien").ToString();
                cbThang.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thang").ToString();
            }
            catch { return; }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (CCongControl.XoaLuong(txtMaLuong.Text.Trim()))
            {
                ConChamCong_Load(sender, e);
            }
            else
                MessageBox.Show("Không thành công.");
        }
    }
}