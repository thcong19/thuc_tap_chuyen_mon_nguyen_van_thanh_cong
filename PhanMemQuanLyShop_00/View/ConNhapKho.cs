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
    public partial class ConNhapKho : DevExpress.XtraEditors.XtraForm
    {
        NhapKhoControl NhapControl = new NhapKhoControl();
        string trangThai = "";
        public ConNhapKho()
        {
            InitializeComponent();
        }

        private void ConNhapKho_Load(object sender, EventArgs e)
        {
            //Hiển thị dữ liệu cho phiếu nhập
            DataTable dtPhieuNhapKho = new DataTable();
            dtPhieuNhapKho = NhapControl.HienThiDuLieu1();
            gridControl1.DataSource = dtPhieuNhapKho;
            gridView1.OptionsView.ShowGroupPanel = false;
            Gan_Co_Phieu_Nhap(true);
            SapXepPieuNhap();//Hiển thị giá trị vừa nhập lên đầu tiên

            //Hiển thị dữ liệu cho chi tiết nhập kho
            DataTable dtChiTietNhapKho = new DataTable();
            dtChiTietNhapKho = NhapControl.HienThiDuLieu2();
            gridControl2.DataSource = dtChiTietNhapKho;
            gridView2.OptionsView.ShowGroupPanel = false;
            Gan_Co_Chi_Tiet_Nhap(true);
            SapXepPieuNhapChiTiet();//Hiển thị giá trị vừa nhập lên đầu tiên

            //Hiển thị dữ liệu cho thông tin hàng hóa
            DataTable dtThongTinHang = new DataTable();
            dtThongTinHang = NhapControl.HienThiDuLieu3();
            gridControl3.DataSource = dtThongTinHang;
            gridView3.OptionsView.ShowGroupPanel = false;
            Gan_Co_Thong_Tin_Hang(true);
            SapXepThongTinHang();//Hiển thị giá trị vừa nhập lên đầu tiên

            //Tính tổng số lượng
            textEdit1.EditValue = colSoLuongHang.SummaryItem.SummaryValue;

            //Hiển thị cho lookedit mã nhập
            DataTable dtMaNhap = new DataTable();
            dtMaNhap = NhapControl.HienThiLoockEditMaNhap();
            txtMaNhapKho.Properties.DataSource = dtMaNhap;
            txtMaNhapKho.Properties.NullText = "";
            txtMaNhapKho.Properties.ValueMember = "MaNhap";
            txtMaNhapKho.Properties.DisplayMember = "MaNhap";

            //Hiển thị cho lookedit mã nhà cung cấp
            DataTable dtMaNhaCungCap = new DataTable();
            dtMaNhaCungCap = NhapControl.HienThiLoockEditMaNhaCungCap();
            txtMaNCCPhieu.Properties.DataSource = dtMaNhaCungCap;
            txtMaNCCPhieu.Properties.NullText = "";
            txtMaNCCPhieu.Properties.ValueMember = "MaNhaCungCap";
            txtMaNCCPhieu.Properties.DisplayMember = "MaNhaCungCap";

            //Hiển thị cho lookedit mã chi tiết nhập kho
            DataTable dtMaChiTietNhap = new DataTable();
            dtMaChiTietNhap = NhapControl.HienThiLoockEditMaChiTietNhap();
            txtMaChiTietNhapHang.Properties.DataSource = dtMaChiTietNhap;
            txtMaChiTietNhapHang.Properties.NullText = "";
            txtMaChiTietNhapHang.Properties.ValueMember = "MaChiTietNhap";
            txtMaChiTietNhapHang.Properties.DisplayMember = "MaChiTietNhap";

            //--Thực hiện các thao tác thêm, xóa, sửa--
            //**PHIẾU NHẬP**
        }
        //Tạo phương thức để hiển thị phiếu mới nhập lên đầu
        public void SapXepPieuNhap()
        {
            gridView1.BeginSort();
            try
            {
                gridView1.ClearSorting();

                gridView1.Columns["MaNhap"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            }

            finally
            {
                gridView1.EndSort();
            }
        }
        //Phiếu nhập chi tiết
        public void SapXepPieuNhapChiTiet()
        {
            gridView2.BeginSort();
            try
            {
                gridView2.ClearSorting();

                gridView2.Columns["MaChiTietNhap"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            }
            finally
            {
                gridView2.EndSort();
            }
        }
        //Phiếu thông tin hàng
        public void SapXepThongTinHang()
        {
            gridView3.BeginSort();
            try
            {
                gridView3.ClearSorting();

                gridView3.Columns["MaChiTietNhap"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            }
            finally
            {
                gridView3.EndSort();
            }
        }


        //Tăng mã tự động cho phiếu nhập
        string chuoi1, chuoi; //các chuổi để làm sinh mã tự động
        int dodai;
        public void TangMaTuDongNhapKho()
        {
            try
            {
                dodai = gridView1.RowCount;
                if (dodai < 10)
                {
                    chuoi = "MN000";
                    chuoi1 = Convert.ToString(dodai);
                    txtMaNhapPhieu.Text = string.Concat(chuoi, chuoi1);
                }
                else
                    if (dodai < 100)
                    {
                        chuoi = "MN00";
                        chuoi1 = Convert.ToString(dodai);
                        txtMaNhapPhieu.Text = string.Concat(chuoi, chuoi1);
                    }
                    else
                        if (dodai < 1000)
                        {
                            chuoi = "MN0";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaNhapPhieu.Text = string.Concat(chuoi, chuoi1);
                        }
                        else
                        {
                            chuoi = "MN";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaNhapPhieu.Text = string.Concat(chuoi, chuoi1);
                        }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        //Click chuột vào gidcontrol1
        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaNhapPhieu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaNhap").ToString();
                txtMaNCCPhieu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaNhaCungCap").ToString();
                txtNgayNhapPhieu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NgayNhap").ToString();
            }
            catch
            { return; }
        }
        //Gắn cờ của phiếu nhập
        public void Gan_Co_Phieu_Nhap(bool co)
        {
            btnThemPhieu.Enabled = btnSuaPhieu.Enabled = btnXoaPhieu.Enabled = co;
            txtMaNCCPhieu.Enabled = txtMaNhapPhieu.Enabled = txtNgayNhapPhieu.Enabled = btnLuuPhieu.Enabled = btnHuyPhieu.Enabled = !co;
        }
        //Gắn cờ chung
        public void Gan_Co_Nhom1(bool kt)
        {
            groupHang.Enabled = groupChiTietNhap.Enabled = kt;
        }
        //Xóa trắng dữ liệu trong text box
        public void Xoa_TrangPhieu()
        {
            txtMaNCCPhieu.Text = txtMaNhapPhieu.Text = txtNgayNhapPhieu.Text = "";
        }
        //Thêm mới 1 phiếu nhập
        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            Gan_Co_Nhom1(false);
            Gan_Co_Phieu_Nhap(false);
            Xoa_TrangPhieu();
            TangMaTuDongNhapKho();
            trangThai = "Thêm";
            txtNgayNhapPhieu.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày tháng năm hiện tại vào text
        }
        //Sửa
        private void btnSuaPhieu_Click(object sender, EventArgs e)
        {

            Gan_Co_Nhom1(false);
            Gan_Co_Phieu_Nhap(false);
            trangThai = "Sửa";

            txtNgayNhapPhieu.Text = DateTime.Today.ToString().Split(' ')[0];
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (trangThai == "Thêm")
                {
                    if ((txtMaNCCPhieu.Text == "") || (txtMaNhapPhieu.Text == "") || (txtNgayNhapPhieu.Text == ""))
                    {
                        MessageBox.Show("Bạn cần nhập đầy đủ thông tin");
                    }
                    else
                    {
                        if (NhapControl.ThemDuLieu1(txtMaNhapPhieu.Text.Trim(), txtMaNCCPhieu.Text.Trim(), txtNgayNhapPhieu.Text.Trim()))
                        {
                            MessageBox.Show("Đã tạo thành công phiếu nhập '" + txtMaNhapPhieu.Text.Trim() + "'", "Thông báo");
                            Gan_Co_Nhom1(true);
                            ConNhapKho_Load(sender, e);
                        }
                        else
                            MessageBox.Show("Thêm thất bại. Mã nhà cung cấp '" + txtMaNCCPhieu.Text.Trim() + "' chưa có hoặc mã phiếu '" + txtMaNhapPhieu.Text.Trim() + "' đã tồn tại ", "Thông báo");
                    }
                }
                if (trangThai == "Sửa")
                {
                    if (NhapControl.SuaDuLieu1(txtMaNhapPhieu.Text.Trim(), txtMaNCCPhieu.Text.Trim(), txtNgayNhapPhieu.Text.Trim()))
                    {
                        MessageBox.Show("Đã thay đổi thông tin", "Thông báo");
                        Gan_Co_Nhom1(true);
                        ConNhapKho_Load(sender, e);
                    }
                    else
                        MessageBox.Show("Không thể chỉnh sửa phiếu nhập.", "Thông báo");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            Gan_Co_Nhom1(true);
            ConNhapKho_Load(sender, e);
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn chắc chắn xóa phiếu nhập này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    NhapControl.XoaDuLieu1(txtMaNhapPhieu.Text);
                    MessageBox.Show("Đã xóa");
                    ConNhapKho_Load(sender, e);
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
        #region
        //--Thực hiện các thao tác thêm, xóa, sửa--
        //**Chi tiết nhập kho**
        //Click chuột vào gidcontrol1
        private void gridView2_Click_1(object sender, EventArgs e)
        {
            try
            {
                txtMaChiTietNhapKho.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MaChiTietNhap").ToString();
                txtGoiHang.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "GoiHang").ToString();
                txtMaNhapKho.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MaNhap").ToString();
                txtSoLuongKho.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "SoLuong").ToString();
                txtGiaNhapKho.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "GiaNhap").ToString();
            }
            catch
            { return; }
        }
        public void TangMaTuDongChiTietNhap()
        {
            try
            {
                dodai = gridView2.RowCount;
                if (dodai < 10)
                {
                    chuoi = "CTN000";
                    chuoi1 = Convert.ToString(dodai);
                    txtMaChiTietNhapKho.Text = string.Concat(chuoi, chuoi1);
                }
                else
                    if (dodai < 100)
                    {
                        chuoi = "CTN00";
                        chuoi1 = Convert.ToString(dodai);
                        txtMaChiTietNhapKho.Text = string.Concat(chuoi, chuoi1);
                    }
                    else
                        if (dodai < 1000)
                        {
                            chuoi = "CTN0";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaChiTietNhapKho.Text = string.Concat(chuoi, chuoi1);
                        }
                        else
                        {
                            chuoi = "CTN";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaChiTietNhapKho.Text = string.Concat(chuoi, chuoi1);
                        }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        //Gắn cờ của phiếu nhập
        public void Gan_Co_Chi_Tiet_Nhap(bool co)
        {
            btnThemKho.Enabled = btnSuaKho.Enabled = btnXoaKho.Enabled = co;
            txtSoLuongKho.Enabled = txtMaChiTietNhapKho.Enabled = txtMaNhapKho.Enabled = txtGiaNhapKho.Enabled = txtGoiHang.Enabled = !co;
        }
        //Gắn cờ chung
        public void Gan_Co_Nhom2(bool kt)
        {
            groupHang.Enabled = panelPhieuNhap.Enabled = kt;
        }
        //Xóa trắng dữ liệu trong text box
        public void Xoa_Trang1()
        {
            txtMaChiTietNhapKho.Text = txtGiaNhapKho.Text = txtMaNhapKho.Text = txtSoLuongKho.Text = "";
        }
        //Thêm chi tiết nhập
        private void btnThemKho_Click(object sender, EventArgs e)
        {
            Gan_Co_Nhom2(false);
            Gan_Co_Chi_Tiet_Nhap(false);
            Xoa_Trang1();
            TangMaTuDongChiTietNhap();
            trangThai = "Thêm";
        }
        //Sửa chi tiết nhập
        private void btnSuaKho_Click(object sender, EventArgs e)
        {
            Gan_Co_Nhom2(false);
            Gan_Co_Chi_Tiet_Nhap(false);
            trangThai = "Sửa";
        }

        private void btnLuuKho_Click(object sender, EventArgs e)
        {
            try
            {
                if (trangThai == "Thêm")
                {
                    if ((txtMaChiTietNhapKho.Text == "") || (txtGiaNhapKho.Text == "") || (txtMaNhapKho.Text == "") || (txtSoLuongKho.Text == ""))
                    {
                        MessageBox.Show("Bạn cần nhập đầy đủ thông tin");
                    }
                    else
                    {
                        if (NhapControl.ThemDuLieu2(txtMaChiTietNhapKho.Text.Trim(), txtGoiHang.Text.Trim(), txtMaNhapKho.Text.Trim(), txtSoLuongKho.Text.Trim(), (txtGiaNhapKho.Text.Trim())))
                        {
                            MessageBox.Show("Đã tạo thành công phiếu chi tiết nhập nhập '" + txtMaChiTietNhapKho.Text.Trim() + "'", "Thông báo");
                            Gan_Co_Nhom2(true);
                            ConNhapKho_Load(sender, e);
                        }
                        else
                            MessageBox.Show("Thêm thất bại.Mã nhập '" + txtMaNhapKho.Text.Trim() + "' chưa có hoặc mã chi tiết phiếu '" + txtMaChiTietNhapKho.Text.Trim() + "' đã tồn tại ", "Thông báo");
                    }
                }
                if (trangThai == "Sửa")
                {
                    if (NhapControl.SuaDuLieu2(txtMaChiTietNhapKho.Text.Trim(), txtGoiHang.Text.Trim(), txtMaNhapKho.Text.Trim(), (txtSoLuongKho.Text.Trim()), (txtGiaNhapKho.Text.Trim())))
                    {
                        MessageBox.Show("Đã thay đổi thông tin", "Thông báo");
                        Gan_Co_Nhom2(true);
                        ConNhapKho_Load(sender, e);
                    }
                    else
                        MessageBox.Show("Không thể chỉnh sửa chi tiết phiếu nhập.", "Thông báo");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnHuyKho_Click(object sender, EventArgs e)
        {
            Gan_Co_Nhom2(true);
            ConNhapKho_Load(sender, e);
        }

        private void btnXoaKho_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Xóa thông tin chi tiết của phiếu nhập này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    NhapControl.XoaDuLieu2(txtMaChiTietNhapKho.Text);
                    MessageBox.Show("Đã xóa");
                    ConNhapKho_Load(sender, e);
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
        #endregion
        //**Thông tin hàng nhập**
        //Click chuột vào gidcontrol1
        private void gridView3_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaHang.Text = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "MaHang").ToString();
                txtMaChiTietNhapHang.Text = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "MaChiTietNhap").ToString();
                txtTenHang.Text = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "TenHang").ToString();
                txtLoaiHang.Text = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "LoaiHang").ToString();
                txtDonViHang.Text = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "DonVi").ToString();
                txtGiaBanHang.Text = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "GiaBan").ToString();
                txtSoLuongHang.Text = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "SoLuongHang").ToString();
            }
            catch
            {
                return;
            }
        }
        private void gridView2_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaChiTietNhapKho.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MaChiTietNhap").ToString();
                txtGoiHang.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "GoiHang").ToString();
                txtMaNhapKho.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MaNhap").ToString();
                txtSoLuongKho.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "SoLuong").ToString();
                txtGiaNhapKho.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "GiaNhap").ToString();
            }
            catch
            { }
        }
        //tăng mã tự động cho thông tin hàng
        public void TangMaTuDongThongTinHang()
        {
            try
            {
                dodai = gridView3.RowCount;
                if (dodai < 10)
                {
                    chuoi = "MH000";
                    chuoi1 = Convert.ToString(dodai);
                    txtMaHang.Text= string.Concat(chuoi, chuoi1);
                }
                else
                    if (dodai < 100)
                    {
                        chuoi = "MH00";
                        chuoi1 = Convert.ToString(dodai);
                        txtMaHang.Text = string.Concat(chuoi, chuoi1);
                    }
                    else
                        if (dodai < 1000)
                        {
                            chuoi = "MH0";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaHang.Text = string.Concat(chuoi, chuoi1);
                        }
                        else
                        {
                            chuoi = "MH";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaHang.Text = string.Concat(chuoi, chuoi1);
                        }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        public void Gan_Co_Thong_Tin_Hang(bool co)
        {
            btnThemHang.Enabled = btnSuaHang.Enabled = btnXoaHang.Enabled = co;
            txtSoLuongHang.Enabled=txtGiaBanHang.Enabled = txtTenHang.Enabled = txtDonViHang.Enabled = txtLoaiHang.Enabled = txtMaChiTietNhapHang.Enabled = txtMaHang.Enabled = btnLuuHang.Enabled = btnHuyHang.Enabled = !co;
        }
        public void Gan_Co_Nhom3(bool kt)
        {
            panelPhieuNhap.Enabled = groupChiTietNhap.Enabled = kt;
        }
        public void Xoa_Trang_2()
        {
            txtSoLuongHang.Text = txtMaHang.Text = txtLoaiHang.Text = txtMaChiTietNhapHang.Text = txtDonViHang.Text = txtGiaNhapKho.Text = txtTenHang.Text = txtGiaBanHang.Text = "";
        }

        private void btnThemHang_Click(object sender, EventArgs e)
        {
            Gan_Co_Thong_Tin_Hang(false);
            Gan_Co_Nhom3(false);
            Xoa_Trang_2();
            TangMaTuDongThongTinHang();
            trangThai = "Thêm";
        }

        private void btnSuaHang_Click(object sender, EventArgs e)
        {
            Gan_Co_Thong_Tin_Hang(false);
            Gan_Co_Nhom3(false);
            trangThai = "Sửa";
        }

        private void btnHuyHang_Click(object sender, EventArgs e)
        {
            Gan_Co_Nhom3(true);
            ConNhapKho_Load(sender, e);
        }

        private void btnLuuHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (trangThai == "Thêm")
                {
                    if ((txtGiaBanHang.Text == "") || (txtMaHang.Text == "") || (txtLoaiHang.Text == "") || (txtMaChiTietNhapHang.Text == "") || (txtDonViHang.Text == "") || (txtTenHang.Text == ""))
                    {
                        MessageBox.Show("Bạn cần nhập đầy đủ thông tin");
                    }
                    else
                    {
                        if (NhapControl.ThemDuLieu3(txtMaHang.Text.Trim(), txtTenHang.Text.Trim(), txtDonViHang.Text.Trim(), txtLoaiHang.Text.Trim(), txtMaChiTietNhapHang.Text.Trim(), txtGiaBanHang.Text.Trim(), txtSoLuongHang.Text.Trim()))
                        {
                            MessageBox.Show("Đã thêm thành công '" + txtTenHang.Text.Trim() + "'", "Thông báo");
                            Gan_Co_Nhom3(true);
                            ConNhapKho_Load(sender, e);
                        }
                        else
                            MessageBox.Show("Thêm thất bại. Mã chi tiết hàng hóa '" + txtMaChiTietNhapHang.Text.Trim() + "' chưa có hoặc mã hàng '" + txtTenHang.Text.Trim() + "' đã tồn tại ", "Thông báo");
                    }
                }
                if (trangThai == "Sửa")
                {
                    if (NhapControl.SuaDuLieu3(txtMaHang.Text.Trim(), txtTenHang.Text.Trim(), txtDonViHang.Text.Trim(), txtLoaiHang.Text.Trim(), txtMaChiTietNhapHang.Text.Trim(), txtGiaBanHang.Text.Trim(), txtSoLuongHang.Text.Trim()))
                    {
                        MessageBox.Show("Đã thay đổi thông tin", "Thông báo");
                        Gan_Co_Nhom3(true);
                        ConNhapKho_Load(sender, e);
                    }
                    else
                        MessageBox.Show("Không thể chỉnh sửa hàng hóa.", "Thông báo");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnXoaHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn chắc chắn xóa loại hàng này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    NhapControl.XoaDuLieu3(txtMaHang.Text);
                    MessageBox.Show("Đã xóa");
                    ConNhapKho_Load(sender, e);
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

        

        
    }
}