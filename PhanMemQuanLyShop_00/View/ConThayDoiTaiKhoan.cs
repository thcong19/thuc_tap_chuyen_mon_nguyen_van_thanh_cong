using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PhanMemQuanLyShop_00.Model;
using PhanMemQuanLyShop_00.Controller;

namespace PhanMemQuanLyShop_00.View
{
    public partial class ConThayDoiTaiKhoan : Form
    {
        ThayDoiTaiKhoanControl ThayDoiTkControl = new ThayDoiTaiKhoanControl();
        string kt;
        public ConThayDoiTaiKhoan()
        {
            InitializeComponent();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConThayDoiTaiKhoan_Load(object sender, EventArgs e)
        {
            DataTable dtThayDoiTk = new DataTable();
            dtThayDoiTk = ThayDoiTkControl.HienThiDuLieu();
            dtGVTaiKhoan.DataSource = dtThayDoiTk;
            Gan_Co(false);
            XoaTrang();
        }

        private void dtGVTaiKhoan_Click(object sender, EventArgs e)
        {
            int index = dtGVTaiKhoan.CurrentRow.Index;
            txtTaiKhoan.Text= dtGVTaiKhoan.Rows[index].Cells[0].Value.ToString();
            txtMatKhau.Text = dtGVTaiKhoan.Rows[index].Cells[1].Value.ToString();
            cbLoaiTk.Text = dtGVTaiKhoan.Rows[index].Cells[2].Value.ToString();
        }
        public void Gan_Co(bool kt)
        {
            btnHuy.Enabled = btnluu.Enabled = grThongtin.Enabled = kt;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = !kt;
            btnThoat.Enabled = true;
        }
        public void XoaTrang()
        {
            cbLoaiTk.Text = txtMatKhau.Text = txtTaiKhoan.Text =cbLoaiTk.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Gan_Co(true);
            kt = "Thêm mới";
            XoaTrang();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Gan_Co(true);
            XoaTrang();
            kt = "Sửa";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ConThayDoiTaiKhoan_Load(sender, e);
            return;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn chắc chắn xóa tài khoản?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                ThayDoiTkControl.XoaTaiKhoan(txtTaiKhoan.Text);
                MessageBox.Show("Đã xóa");
                ConThayDoiTaiKhoan_Load(sender, e);
            }
            else
                return;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (kt == "Thêm mới")
            {
                if ((txtTaiKhoan.Text == "") || (txtMatKhau.Text == "") || (cbLoaiTk.Text == ""))
                {
                    MessageBox.Show("Bạn cần nhập đầy đủ thông tin");
                }
                else
                {
                    if ((cbLoaiTk.Text == "Admin") || (cbLoaiTk.Text == "Nhân viên"))
                    {
                        if (ThayDoiTkControl.ThemDuLieu(txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim(), cbLoaiTk.Text))
                        {
                            MessageBox.Show("Đã tạo thành công tài khoản '" + txtTaiKhoan.Text.Trim() + "'", "Thông báo");
                            ConThayDoiTaiKhoan_Load(sender, e);
                        }
                        else
                            MessageBox.Show("Thêm thất bại. Tài khoản '" + txtTaiKhoan.Text + "' đã tồn tại ", "Thông báo");
                    }
                    else
                        MessageBox.Show("Tài khoản '" + txtTaiKhoan.Text + "' không khả dụng với loại tài khoản '" + cbLoaiTk.Text + "'","Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            if (kt == "Sửa")
            {
                if (ThayDoiTkControl.SuaDuLieu(txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim(), cbLoaiTk.Text))
                {
                    MessageBox.Show("Đã thay đổi thông tin", "Thông báo");
                    ConThayDoiTaiKhoan_Load(sender, e);
                }
                else
                    MessageBox.Show("Không thể chỉnh sửa tên đăng nhập.", "Thông báo");
            }
        }
    }
}
