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

using DevExpress.XtraReports.UI;

namespace PhanMemQuanLyShop_00.View
{
    public partial class ConHoaDon : DevExpress.XtraEditors.XtraForm
    {
        HoaDonControl HDcontrol = new HoaDonControl();
        string trangThai;
        public ConHoaDon()
        {
            InitializeComponent();
        }
        private void ConHoaDon_Load(object sender, EventArgs e)
        {
            GanCo(false);
            DataTable dtHoaDon = new DataTable();
            dtHoaDon = HDcontrol.HienThiDuLieu();
            gridControl1.DataSource = dtHoaDon;
            Xoa_Trang();
        }
        public void GanCo(bool kt)
        {
            grThongTinHoaDon.Enabled = grThongTinPhieu.Enabled = kt;
            btnHuy.Enabled = btnLuu.Enabled = kt;
            btnCapNhat.Enabled = btnXoa.Enabled = !kt;
        }
        public void Xoa_Trang()
        {
            txtMaHoaDon.Text = txtMaPhieuMua.Text = txtMaHang.Text = txtSoLuong.Text = txtThanhTien.Text = txtGiaBan.Text =txtTenHang.Text= "";
        }
        string chuoi1, chuoi; //các chuổi để làm sinh mã tự động
        int dodai;
        public void TangMaTuDong()
        {
            try
            {
                dodai = gridView1.RowCount;
                if (dodai < 10)
                {
                    chuoi = "HD000";
                    chuoi1 = Convert.ToString(dodai);
                    txtMaHoaDon.Text = string.Concat(chuoi, chuoi1);
                }
                else
                    if (dodai < 100)
                    {
                        chuoi = "HD00";
                        chuoi1 = Convert.ToString(dodai);
                        txtMaHoaDon.Text = string.Concat(chuoi, chuoi1);
                    }
                    else
                        if (dodai < 1000)
                        {
                            chuoi = "KH0";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaHoaDon.Text = string.Concat(chuoi, chuoi1);
                        }
                        else
                        {
                            chuoi = "HD";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaHoaDon.Text = string.Concat(chuoi, chuoi1);
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
                if (DialogResult.Yes == MessageBox.Show("Xóa hóa đơn '" + txtMaHoaDon.Text + "'?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    HDcontrol.XoaHoaDon(txtMaHoaDon.Text.Trim());
                    ConHoaDon_Load(sender, e);
                }
                else
                    return;
            }
            catch { }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            GanCo(true);
            trangThai = "Sửa";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ConHoaDon_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (trangThai == "Sửa")
                {
                    if (HDcontrol.SuaHoaDon(txtMaHoaDon.Text.Trim(), txtMaPhieuMua.Text.Trim(), txtMaHang.Text.Trim(), txtSoLuong.Text.Trim(), txtGiaBan.Text.Trim(), txtThanhTien.Text.Trim(),txtTenHang.Text.Trim()))
                    {
                        MessageBox.Show("Đã thay đổi thông tin", "Thông báo");
                        ConHoaDon_Load(sender, e);
                    }
                    else
                        MessageBox.Show("Không thành công.", "Thông báo");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

            XtraReport rp = new XtraReport();
            rp.DataSource = HDcontrol.HienThiDuLieuHoaDon(txtMaPhieuMua.Text.Trim());
            rp.LoadLayout(Application.StartupPath + @"\HoaDonBanHang.repx");
            rp.ShowPreviewDialog();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaHoaDon.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaChiTietHoaDon").ToString();
                txtMaPhieuMua.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaBanHang").ToString();
                txtMaHang.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaHang").ToString();
                txtSoLuong.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SoLuong").ToString();
                txtGiaBan.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GiaBan").ToString();
                txtThanhTien.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ThanhTien").ToString();
                txtTenHang.Text= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenHang").ToString();
            }
            catch
            { return; }
        }

    }
}