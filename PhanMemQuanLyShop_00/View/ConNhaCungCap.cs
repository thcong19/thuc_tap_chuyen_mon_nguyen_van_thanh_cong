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
using PhanMemQuanLyShop_00.Model;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid;

namespace PhanMemQuanLyShop_00.View
{
    public partial class ConNhaCungCap : DevExpress.XtraEditors.XtraForm
    {
        NhaCungCapControl NhaccControl = new NhaCungCapControl();
        string trangThai = "";
        public ConNhaCungCap()
        {
            InitializeComponent();
        }

        private void ConNhaCungCap_Load(object sender, EventArgs e)
        {
            Gan_co(false);
            DataTable dtNhaCungCap = new DataTable();
            dtNhaCungCap = NhaccControl.HienThiDuLieu();
            gctNhaCungCap.DataSource = dtNhaCungCap;
            gridView1.OptionsView.ShowGroupPanel = false;
            //

        }

        public void Gan_co(bool kt)
        {
            btnLuu.Enabled = btnHuy.Enabled = kt;
            txtMaNCC.Enabled = txtDiaChi.Enabled = txtLienHe.Enabled = txtNhaCungCap.Enabled = txtSoTaiKhoan.Enabled = kt;
        }

        //Click để hiển thị dữ liệu lên textbox
        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaNCC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaNhaCungCap").ToString();
                txtNhaCungCap.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenNhaCungCap").ToString();
                txtDiaChi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DiaChi").ToString();
                txtLienHe.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LienHe").ToString();
                txtSoTaiKhoan.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SoTaiKhoan").ToString();
            }
            catch
            {
                return;
            }
        }

        //Xóa bỏ các dữ liệu hiển thị trên các textbox
        public void XoaTrang()
        {
            txtMaNCC.Text = txtNhaCungCap.Text = txtLienHe.Text = txtDiaChi.Text = txtSoTaiKhoan.Text = "";
        }
        //
        string chuoi1, chuoi; //các chuổi để làm sinh mã tự động
        int dodai;
        public void TangMatuDong()
        {
            try
            {
                dodai = gridView1.RowCount;
                if (dodai < 10)
                {
                    chuoi = "NCC000";
                    chuoi1 = Convert.ToString(dodai);
                    txtMaNCC.Text = string.Concat(chuoi, chuoi1);
                }
                else
                    if (dodai < 100)
                    {
                        chuoi = "NCC00";
                        chuoi1 = Convert.ToString(dodai);
                        txtMaNCC.Text = string.Concat(chuoi, chuoi1);
                    }
                    else
                        if (dodai < 1000)
                        {
                            chuoi = "NCC0";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaNCC.Text = string.Concat(chuoi, chuoi1);
                        }
                        else
                        {
                            chuoi = "NCC";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaNCC.Text = string.Concat(chuoi, chuoi1);
                        }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        //Sự kiện nút thêm
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //
            Gan_co(true);
            btnSua.Enabled = btnXoa.Enabled = false;
            XoaTrang();
            TangMatuDong();
            trangThai = "Thêm";
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Gan_co(true);
            btnThem.Enabled = btnXoa.Enabled = false;
            XoaTrang();
            trangThai = "Sửa";
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn chắc chắn xóa nhà cung cấp này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    NhaccControl.XoaDuLieu(txtMaNCC.Text);
                    MessageBox.Show("Đã xóa");
                    ConNhaCungCap_Load(sender, e);
                }
                else
                    return;
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
                    if ((txtDiaChi.Text == "") || (txtLienHe.Text == "") || (txtMaNCC.Text == "") || (txtNhaCungCap.Text == "") || (txtSoTaiKhoan.Text == ""))
                    {
                        MessageBox.Show("Bạn cần nhập đầy đủ thông tin");
                    }
                    else
                    {
                        if (NhaccControl.ThemDuLieu(txtMaNCC.Text.Trim(), txtNhaCungCap.Text.Trim(), txtDiaChi.Text.Trim(), txtLienHe.Text.Trim(), txtSoTaiKhoan.Text.Trim()))
                        {
                            MessageBox.Show("Đã tạo thành công tài khoản '" + txtNhaCungCap.Text.Trim() + "'", "Thông báo");
                            ConNhaCungCap_Load(sender, e);
                            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                        }
                        else
                            MessageBox.Show("Thêm thất bại. mã nhà cung cấp '" + txtMaNCC.Text.Trim() + "' đã tồn tại ", "Thông báo");
                    }
                }
                if (trangThai == "Sửa")
                {
                    if (NhaccControl.SuaDuLieu(txtMaNCC.Text.Trim(), txtNhaCungCap.Text.Trim(), txtDiaChi.Text.Trim(), txtLienHe.Text.Trim(), txtSoTaiKhoan.Text.Trim()))
                    {
                        MessageBox.Show("Đã thay đổi thông tin", "Thông báo");
                        ConNhaCungCap_Load(sender, e);
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
            ConNhaCungCap_Load(sender, e);
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
        }
        #region
        //
        bool indicatorIcon = true;
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
    }
}