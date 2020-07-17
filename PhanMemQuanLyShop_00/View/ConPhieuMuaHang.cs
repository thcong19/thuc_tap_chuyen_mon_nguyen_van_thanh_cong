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
    public partial class ConPhieuMuaHang : DevExpress.XtraEditors.XtraForm
    {
        PhieuMuaHangControl PhieuMhControl = new PhieuMuaHangControl();
        string trangThai;
        public ConPhieuMuaHang()
        {
            InitializeComponent();
        }

        private void ConPhieuMuaHang_Load(object sender, EventArgs e)
        {
            GanCo(false);
            txtNgayBan.Text = DateTime.Today.ToString().Split(' ')[0];//Thêm ngày hiện tại vào
            DataTable dtBanHangCombo = new DataTable();
            dtBanHangCombo = PhieuMhControl.HienThiDuLieu();
            gridControl1.DataSource = dtBanHangCombo;
            //Hiển thị cho lookedit mã khách
            DataTable dtMaKhach = new DataTable();
            dtMaKhach = PhieuMhControl.HienThiMaKhach();
            txtMaKhach.Properties.DataSource = dtMaKhach;
            txtMaKhach.Properties.NullText = "";
            txtMaKhach.Properties.DisplayMember = "MaKhachHang";
            //Hiển thị cho lookedit mã nhân viên
            DataTable dtMaNv = new DataTable();
            dtMaNv = PhieuMhControl.HienThiMaNhanVien();
            txtNhanVien.Properties.DataSource = dtMaNv;
            txtNhanVien.Properties.NullText = "";
            txtNhanVien.Properties.DisplayMember = "MaNhanVien";
        }
        //Tăng mã tự động
        string chuoi1, chuoi; //các chuổi để làm sinh mã tự động
        int dodai;
        public void TangMaTuDongPhieuMuaHang()
        {
            try
            {
                dodai = gridView1.RowCount;
                if (dodai < 10)
                {
                    chuoi = "PMH000";
                    chuoi1 = Convert.ToString(dodai);
                    txtMaPhieu.Text = string.Concat(chuoi, chuoi1);
                }
                else
                    if (dodai < 100)
                    {
                        chuoi = "PMH00";
                        chuoi1 = Convert.ToString(dodai);
                        txtMaPhieu.Text = string.Concat(chuoi, chuoi1);
                    }
                    else
                        if (dodai < 1000)
                        {
                            chuoi = "PMH0";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaPhieu.Text = string.Concat(chuoi, chuoi1);
                        }
                        else
                        {
                            chuoi = "PMH";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaPhieu.Text = string.Concat(chuoi, chuoi1);
                        }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        //
        public void GanCo(bool kt)
        {
            txtMaKhach.Visible = txtMaPhieu.Visible = txtNgayBan.Visible = txtNhanVien.Visible = kt;
            labelControl1.Visible = labelControl2.Visible = labelControl3.Visible = labelControl4.Visible=kt;
            btnHuy.Enabled = btnLuu.Enabled = kt;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = !kt;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            GanCo(true);
            txtMaPhieu.Text = "";
            trangThai = "Thêm";
            TangMaTuDongPhieuMuaHang();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            trangThai = "Sửa";
            GanCo(true);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ConPhieuMuaHang_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn chắc chắn xóa phiếu này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    PhieuMhControl.XoaDuLieu(txtMaPhieu.Text.Trim());
                    MessageBox.Show("Xong");
                    ConPhieuMuaHang_Load(sender, e);
                }
                else
                {
                    return;
                }
            }
            catch
            {
                MessageBox.Show("không thế xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (trangThai == "Thêm")
                {
                    if ((txtMaKhach.Text=="") || (txtMaPhieu.Text == "") || (txtNgayBan.Text == "")|| (txtNhanVien.Text == ""))
                    {
                        MessageBox.Show("Thiếu thông tin");
                    }
                    else
                    {
                        if (PhieuMhControl.ThemDuLieu(txtMaPhieu.Text.Trim(),txtNgayBan.Text,txtMaKhach.Text.Trim(),txtNhanVien.Text.Trim()))
                        {
                            MessageBox.Show("Đã tạo thành công phiếu mua hàng '" +txtMaPhieu.Text.Trim() + "' cho khách hàng mã '"+txtNhanVien.Text.Trim()+"'", "Thông báo");
                            GanCo(true);
                            ConPhieuMuaHang_Load(sender, e);
                        }
                        else
                            MessageBox.Show("Thêm thất bại. Phiếu hàng '" + txtMaPhieu.Text.Trim() + "' đã tồn tại hoặc mã nhân viên '" + txtNhanVien.Text + "' và mã khách '"+txtMaKhach.Text.Trim()+"' chưa tồn tại  ", "Thông báo");
                    }
                }
                if (trangThai == "Sửa")
                {
                    if (PhieuMhControl.SuaDuLieu(txtMaPhieu.Text.Trim(), txtNgayBan.Text, txtMaKhach.Text.Trim(), txtNhanVien.Text.Trim()))
                    {
                        MessageBox.Show("Phiếu hàng đã được thay đổi", "Thông báo");
                        GanCo(true);
                        ConPhieuMuaHang_Load(sender, e);
                    }
                    else
                        MessageBox.Show("Không thể chỉnh sửa phiếu mua hàng.", "Thông báo");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaPhieu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaBanHang").ToString();
                txtMaKhach.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaKhachHang").ToString();
                txtNgayBan.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NgayBanHang").ToString();
                txtNhanVien.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaNhanVien").ToString();
            }
            catch
            { return; }
        }
    }
}