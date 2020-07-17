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
    public partial class ConKhachHang : DevExpress.XtraEditors.XtraForm
    {
        KhachHangControl KhControl = new KhachHangControl();
        string trangThai;
        public ConKhachHang()
        {
            InitializeComponent();
        }
        //Tăng mã tự động
        string chuoi1, chuoi; //các chuổi để làm sinh mã tự động
        int dodai;
        public void TangMatuDong()
        {
            try
            {
                dodai = gridView1.RowCount;
                if (dodai < 10)
                {
                    chuoi = "KH00";
                    chuoi1 = Convert.ToString(dodai);
                    txtMaKhach.Text = string.Concat(chuoi, chuoi1);
                }
                else
                    if (dodai < 100)
                    {
                        chuoi = "KH0";
                        chuoi1 = Convert.ToString(dodai);
                        txtMaKhach.Text = string.Concat(chuoi, chuoi1);
                    }
                    else
                        if (dodai < 1000)
                        {
                            chuoi = "KH";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaKhach.Text = string.Concat(chuoi, chuoi1);
                        }
                        else
                        {
                            chuoi = "KH";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaKhach.Text = string.Concat(chuoi, chuoi1);
                        }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        private void ConKhachHang_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtKhachHang = new DataTable();
                dtKhachHang = KhControl.HienThiDuLieu();
                gridControl1.DataSource = dtKhachHang;
                gridView1.OptionsView.ShowGroupPanel = false;
                ChoNhapDuLieu(true);
                Gan_Co(true);
                Xoa_Trang();
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        public void Gan_Co(bool co)
        {
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = co;
            btnLưu.Enabled = btnHuy.Enabled = !co;
        }
        public void Xoa_Trang()
        {
            txtTenKhach.Text = txtLoaiThe.Text = txtLienHe.Text = txtMaKhach.Text = "";
        }
        public void ChoNhapDuLieu(bool kt)
        {
            txtLienHe.Properties.ReadOnly = txtMaKhach.Properties.ReadOnly = txtTenKhach.Properties.ReadOnly = kt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Gan_Co(false);
            trangThai = "Thêm";
            ChoNhapDuLieu(false);
            TangMatuDong();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ConKhachHang_Load(sender, e);
            ChoNhapDuLieu(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Gan_Co(false);
            trangThai = "Sửa";
            ChoNhapDuLieu(false);
        }

        private void btnLưu_Click(object sender, EventArgs e)
        {
            try
            {
                if (trangThai == "Thêm")
                {
                    if ((txtLienHe.Text == "") || (txtMaKhach.Text == "") || (txtTenKhach.Text == "") || (txtLoaiThe.Text == ""))
                    {
                        MessageBox.Show("Bạn cần nhập đầy đủ thông tin");
                    }
                    else
                    {
                        if (KhControl.ThemDuLieu(txtMaKhach.Text.Trim(), txtLienHe.Text.Trim(), txtTenKhach.Text.Trim(), txtLoaiThe.Text.Trim()))
                        {
                            {
                                if (DialogResult.Yes == MessageBox.Show("Đã tạo thành công khách hàng '" + txtTenKhach.Text.Trim() + "' Bạn có muốn thêm thiếu mua hàng cho '" + txtTenKhach.Text.Trim() + "' không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                                {
                                    ConKhachHang_Load(sender, e);
                                    ConPhieuMuaHang c = new ConPhieuMuaHang();
                                    c.ShowDialog();
                                }
                                else
                                ConKhachHang_Load(sender, e);
                            }
                        }
                        else
                            MessageBox.Show("Thêm thất bại. mã khách hàng '" + txtMaKhach.Text.Trim() + "' đã tồn tại ", "Thông báo");
                    }
                }
                if (trangThai == "Sửa")
                {
                    if (KhControl.SuaDuLieu(txtMaKhach.Text.Trim(), txtLienHe.Text.Trim(), txtTenKhach.Text.Trim(), txtLoaiThe.Text.Trim()))
                    {
                        MessageBox.Show("Đã thay đổi thông tin", "Thông báo");
                        ConKhachHang_Load(sender, e);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Chắc chắn xóa bỏ khách hàng '" + txtTenKhach.Text.Trim() + "' ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    KhControl.XoaDuLieu(txtMaKhach.Text);
                    MessageBox.Show("Đã xóa");
                    ConKhachHang_Load(sender, e);
                }
                else
                    return;
            }
            catch
            {
                MessageBox.Show("Cần xóa bỏ phiếu mua hàng của '"+txtTenKhach.Text.Trim()+"' trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaKhach.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaKhachHang").ToString();
                txtLienHe.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LienHe").ToString();
                txtTenKhach.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenDonVi").ToString();
                txtLoaiThe.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TheThanhVien").ToString();
            }
            catch
            {
                MessageBox.Show("Không có khách hàng nào");
            }
        }
    }
}