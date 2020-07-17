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
    public partial class ConNhanVien : DevExpress.XtraEditors.XtraForm
    {
        NhanVienControl NVControl = new NhanVienControl();
        string trangThai;
        public ConNhanVien()
        {
            InitializeComponent();
        }

        private void ConNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtNhanVien = new DataTable();
                dtNhanVien = NVControl.HienThiDuLieu();
                gridControl1.DataSource = dtNhanVien;
                Gan_Co(false);
                NhapChoText(true);
                gridView1.FocusedRowHandle = -1;
            }
            catch
            {            
            }
        }
        //
        public void Gan_Co(bool kt)
        {
            //txtChungMinh.Enabled = txtDiaChi.Enabled = txtDienThoai.Enabled = txtMaNhVien.Enabled = txtTen.Enabled = kt;
            btnHuy.Enabled = btnLuu.Enabled = kt;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = !kt;
        
        }
        public void Xoa_Trang()
        {
            txtChungMinh.Text = txtDiaChi.Text = txtDienThoai.Text = txtMaNhVien.Text = txtTen.Text = "";
        }
        //tăng mã tự động
        string chuoi1, chuoi; //các chuổi để làm sinh mã tự động
        int dodai;
        public void TangMatuDong()
        {
            try
            {
                dodai = gridView1.RowCount;
                if (dodai < 10)
                {
                    chuoi = "NV0";
                    chuoi1 = Convert.ToString(dodai);
                    txtMaNhVien.Text = string.Concat(chuoi, chuoi1);
                }
                else
                    if (dodai < 100)
                    {
                        chuoi = "NV";
                        chuoi1 = Convert.ToString(dodai);
                        txtMaNhVien.Text = string.Concat(chuoi, chuoi1);
                    }
                        else
                        {
                            chuoi = "NV";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaNhVien.Text = string.Concat(chuoi, chuoi1);
                        }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            NhapChoText(false);
            Gan_Co(true);
            Xoa_Trang();
            TangMatuDong();
            trangThai = "Thêm";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NhapChoText(false);
            Gan_Co(true);
            trangThai = "Sửa";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn chắc chắn xóa '"+txtTen.Text.Trim()+"'?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    NVControl.XoaDuLieu(txtMaNhVien.Text);
                    MessageBox.Show("Hoàn thành");
                    ConNhanVien_Load(sender, e);
                }
                else
                    return;

            }
            catch { }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (trangThai == "Thêm")
                { 
                    if ((txtChungMinh.Text == "") || (txtDiaChi.Text == "") || (txtDienThoai.Text == "") || (txtMaNhVien.Text == "") || (txtTen.Text == ""))
                    {
                        MessageBox.Show("Bạn cần nhập đầy đủ thông tin");
                    }
                    else
                    {
                        if (NVControl.ThemDuLieu(txtMaNhVien.Text.Trim(), txtTen.Text.Trim(), txtDiaChi.Text.Trim(), txtChungMinh.Text.Trim(),txtDienThoai.Text.Trim()))
                        {
                            MessageBox.Show("Thêm thành công nhân viên'" + txtTen.Text.Trim() + "'", "Thông báo");
                            ConNhanVien_Load(sender, e);
                            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                        }
                        else
                            MessageBox.Show("Thêm thất bại. Mã nhân viên '" + txtMaNhVien.Text.Trim() + "' đã tồn tại ", "Thông báo");
                    }
                }
                if (trangThai == "Sửa")
                {
                    if (NVControl.SuaDuLieu(txtMaNhVien.Text.Trim(), txtTen.Text.Trim(), txtDiaChi.Text.Trim(), txtChungMinh.Text.Trim(), txtDienThoai.Text.Trim()))
                    {
                        MessageBox.Show("Đã thay đổi thông tin", "Thông báo");
                        ConNhanVien_Load(sender, e);
                        btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                    }
                    else
                        MessageBox.Show("Không thể chỉnh sửa tên đăng nhập.", "Thông báo");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ConNhanVien_Load(sender, e);
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaNhVien.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaNhanVien").ToString();
                txtTen.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "HoTen").ToString();
                txtDiaChi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DiaChi").ToString();
                txtDienThoai.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SDT").ToString();
                txtChungMinh.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CMND").ToString();
            }
            catch { MessageBox.Show("Lỗi"); }
        }
        //Khong cho người dùng nhập giá trị
        public void NhapChoText(bool nhap)
        {
            txtChungMinh.Properties.ReadOnly = txtDiaChi.Properties.ReadOnly = txtDienThoai.Properties.ReadOnly = txtMaNhVien.Properties.ReadOnly = txtTen.Properties.ReadOnly = nhap;
        }

    }
}