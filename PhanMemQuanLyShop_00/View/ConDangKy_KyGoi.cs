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
    public partial class ConDangKy_KyGoi : DevExpress.XtraEditors.XtraForm
    {
        DangKy_KyGoiControl DK_KyGoi = new DangKy_KyGoiControl();
        public ConDangKy_KyGoi()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DK_KyGoi.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim());
                ConDangKy_KyGoi_Load(sender, e);
            }
            catch
            { MessageBox.Show("thất bại"); }
        }

        private void ConDangKy_KyGoi_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtKyGoi = new DataTable();
                dtKyGoi = DK_KyGoi.ThongTinKyGoi();
                gridControl1.DataSource = dtKyGoi;
            }
            catch
            { }
        }

        private void btnXoaThu_Click(object sender, EventArgs e)
        {
            try
            {
                DK_KyGoi.XoaThongTinkyGoi(txtMaKyGoi.Text.Trim());
            }
            catch
            {
                MessageBox.Show("thất bại");
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaKyGoi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaThongTinKyGui").ToString();
                txtKhachHang.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenChu").ToString();
                txtLienHe.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LienHe").ToString();
                txtChungMinh.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CMND").ToString();
                txtTenCun.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenThuCung").ToString();
                txtSoLuong.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SoLuong").ToString();
                txtNgayDen.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NgayGoi").ToString();
                txtNgayVe.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NgayTra").ToString();
                txtGiaComBo.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GiaComBo").ToString();
                txtNhanVienLap.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaNhanVien").ToString();
                CbMaChuong.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenChuong").ToString();
                txtGiayTo.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GiayTo").ToString();
            }
            catch
            { }
        }
    }
}