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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.Drawing;

namespace PhanMemQuanLyShop_00.View
{
    public partial class ConKhoHang : DevExpress.XtraEditors.XtraForm
    {
        KhoHangControl KhoControl = new KhoHangControl();
        public ConKhoHang()
        {
            InitializeComponent();
        }

        private void ConKhoHang_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtKhoHang = new DataTable();
                dtKhoHang = KhoControl.HienThiDuLieu();
                gridControl1.DataSource = dtKhoHang;
                gridView1.OptionsView.ShowGroupPanel = false;
                NhapDuLieuChoText(true);
            }
            catch
            { MessageBox.Show("Lỗi"); }
        }
        //
        public void NhapDuLieuChoText(bool nhap)
        {
            txtDonVi.Properties.ReadOnly = txtGiaNhap.Properties.ReadOnly =
                txtLoaiHang.Properties.ReadOnly = txtMaCTNhap.Properties.ReadOnly =
                txtMaHang.Properties.ReadOnly = txtMaNCC.Properties.ReadOnly = txtMaNhap.Properties.ReadOnly =
                txtNgayNhap.Properties.ReadOnly = txtSoLuong.Properties.ReadOnly = txtTenHang.Properties.ReadOnly =
                txtTenNhaCC.Properties.ReadOnly = nhap;
        }



        #region
        // Code đánh số tựu động cho gridview
        bool indicatorIcon = true;
        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                {
                    string sText = (e.RowHandle + 1).ToString();
                    Graphics gr = e.Info.Graphics;
                    gr.PageUnit = GraphicsUnit.Pixel;
                    GridView gridView = ((GridView)sender);
                    SizeF size = gr.MeasureString(sText, e.Info.Appearance.Font);
                    int nNewSize = Convert.ToInt32(size.Width) + GridPainter.Indicator.ImageSize.Width + 10;
                    if (gridView.IndicatorWidth < nNewSize)
                    {
                        gridView.IndicatorWidth = nNewSize;
                    }

                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Info.DisplayText = sText;
                }
                if (!indicatorIcon)
                    e.Info.ImageIndex = -1;

                if (e.RowHandle == GridControl.InvalidRowHandle)
                {
                    Graphics gr = e.Info.Graphics;
                    gr.PageUnit = GraphicsUnit.Pixel;
                    GridView gridView = ((GridView)sender);
                    SizeF size = gr.MeasureString("STT", e.Info.Appearance.Font);
                    int nNewSize = Convert.ToInt32(size.Width) + GridPainter.Indicator.ImageSize.Width + 10;
                    if (gridView.IndicatorWidth < nNewSize)
                    {
                        gridView.IndicatorWidth = nNewSize;
                    }

                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Info.DisplayText = "STT";
                }
            }
            catch
            {
            }
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            GridView gridview = ((GridView)sender);
            if (!gridview.GridControl.IsHandleCreated) return;
            Graphics gr = Graphics.FromHwnd(gridview.GridControl.Handle);
            SizeF size = gr.MeasureString(gridview.RowCount.ToString(), gridview.PaintAppearance.Row.GetFont());
            gridview.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 10;
        }
        #endregion

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaNCC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaNhaCungCap").ToString();
                txtMaCTNhap.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaChiTietNhap").ToString();
                txtMaHang.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaHang").ToString();
                txtMaNhap.Text = txtMaNCC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaNhap").ToString();
                txtLoaiHang.Text = txtMaNCC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LoaiHang").ToString();
                txtDonVi.Text = txtMaNCC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DonVi").ToString();
                txtGiaNhap.Text = txtMaNCC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GiaNhap").ToString();
                txtNgayNhap.Text = txtMaNCC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NgayNhap").ToString();
                txtSoLuong.Text = txtMaNCC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SoLuong").ToString();
                txtTenNhaCC.Text = txtMaNCC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenNhaCungCap").ToString();
                txtTenHang.Text = txtMaNCC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenHang").ToString();
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ConKhoHang_Load(sender, e);
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            gridView1.FocusedRowHandle = 0;
        }

        private void btnLen_Click(object sender, EventArgs e)
        {
            int dem = gridView1.RowCount;
            int i = gridView1.FocusedRowHandle;
            i = i + 1;
            if (i <= dem - 1)
                gridView1.FocusedRowHandle = i;
        }
        private void btnXuong_Click(object sender, EventArgs e)
        {
            int dem = gridView1.RowCount;
            int i = gridView1.FocusedRowHandle;
            i = i - 1;
            if (i <= dem - 1)
                gridView1.FocusedRowHandle = i;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dtTimKiemHang = new DataTable();
            dtTimKiemHang = KhoControl.HienThiDuLieuTimKiem(txtTimKiem.Text.Trim());
            gridControl1.DataSource = dtTimKiemHang;
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            int dem = gridView1.RowCount;
            gridView1.FocusedRowHandle = dem-1;
        }
    }
}