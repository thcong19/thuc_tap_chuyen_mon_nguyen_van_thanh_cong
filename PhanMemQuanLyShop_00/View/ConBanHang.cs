using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PhanMemQuanLyShop_00.View;
using PhanMemQuanLyShop_00.Controller;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;


namespace PhanMemQuanLyShop_00.View
{
    public partial class ConBanHang : DevExpress.XtraEditors.XtraForm
    {
        BanHangControl BHangConTrol = new BanHangControl();
        ulong khachTra, slMua, gia, khuyenMai, giamGia, thanhtien, sLuongBan, sLuongNhan;
        public void ThoiTien()
        {
            try
            {
                if (txtKhachTra.Text != "0")
                {
                    slMua = ulong.Parse(txtKhachTra.Text);
                    gia = ulong.Parse(txtTongTien.Text);
                    thanhtien = slMua - gia;
                    txtTraLai.Text = Convert.ToString(thanhtien);
                }
                else
                    txtTraLai.Text = "0";
            }
            catch { return; }
        }
        public ConBanHang()
        {
            InitializeComponent();
        }
        private void ConBanHang_Load(object sender, EventArgs e)
        {
            HienThiBanDau(false);
            txtNgayMua.Text = DateTime.Today.ToString().Split(' ')[0];//Thêm ngày hiện tại vào
            //hiển thị thông tin cho grid hàng hóa
            txtMaHang.Properties.NullText = "";
            txtSoLuongMua.Text = txtThanhTien.Text = txtTheThanhVien.Text = txtLienHe.Text = "";
            //Hiển thị thông tin tất cả hàng hóa
            DataTable dtThongTinHang = new DataTable();
            dtThongTinHang = BHangConTrol.HienThiThongTinHang();
            gridControl1.DataSource = dtThongTinHang;
            KhongChoNhapDuLieu(true);
            //Combobox mã khách
            HienThiComboBox();
            //Combobox mã nhân viên
            HienThiComboBoxNV();
            btnThemHoaDon.Enabled = btnThanhToan.Enabled = false;
            txtTongTien.Text = txtTraLai.Text = "0đ";
            txtKhachTra.Text = "0";
            SapXepPieuNhap();//Xếp phiếu mới lên đầu
        }
        public void KhongChoNhapDuLieu(bool kt)
        {
            txtMaHang.Properties.ReadOnly = txtTenHang.Properties.ReadOnly = txtSoLuongHang.Properties.ReadOnly = txtLoaiHang.Properties.ReadOnly = txtGiaBanHang.Properties.ReadOnly = txtDonViHang.Properties.ReadOnly = kt;
            txtTenNVHienThi.Properties.ReadOnly = txtMaKhach.Properties.ReadOnly = txtTheThanhVien.Properties.ReadOnly = txtLienHe.Properties.ReadOnly = txtMaChiTienNhap.Properties.ReadOnly = kt;
            cbMaNVHienThi.Enabled = true;
        }
        //Sắp xếp lại dữ liệu từ trên xuống
        public void SapXepPieuNhap()
        {
            
            gridView3.BeginSort();
            try
            {
                gridView3.ClearSorting();
                gridView3.Columns["MaNhap"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            }
            catch { }
            finally
            {
                gridView3.EndSort();
            }
        }
        //Bin dữ liệu
        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                txtTenHang.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenHang").ToString();
                txtDonViHang.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DonVi").ToString();
                txtGiaBanHang.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GiaBan").ToString();
                txtLoaiHang.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LoaiHang").ToString();
                txtSoLuongHang.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SoLuongHang").ToString();
                txtMaHang.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaHang").ToString();
                txtMaChiTienNhap.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaChiTietNhap").ToString();
            }
            catch { return; }
        }
        //Tìm kiếm nhanh hàng hóa
        private void btnTimKiemNhanh_Click(object sender, EventArgs e)
        {
            gridControl1.Enabled = true;
            DataTable dtTimKiem = new DataTable();
            dtTimKiem = BHangConTrol.HienThiThongTinTimKiem(txtTimNhanh.Text.Trim());
            gridControl1.DataSource = dtTimKiem;
            
        }
        //Load cho combobox khách hàng
        public void HienThiComboBox()
        {
            DataTable dtCBbox;
            dtCBbox = BHangConTrol.HienThiDuLieuComBoBox();
            cb_makhach.DataSource = dtCBbox;
            cb_makhach.DisplayMember = "TenDonVi";
        }
        //Load cho combobox mã nhân viên
        public void HienThiComboBoxNV()
        {
            DataTable dtCBboxNV;
            dtCBboxNV = BHangConTrol.HienThiDuLieuComboBoxNV();
            cbMaNVHienThi.DataSource = dtCBboxNV;
            cbMaNVHienThi.DisplayMember = "MaNhanVien";
        }
        //bắt sự kiện thay đổi combo khách hàng
        private void cb_makhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaKhach.Text = BHangConTrol.HienThiTenKhach(cb_makhach.Text.Trim());
            txtLienHe.Text = BHangConTrol.HienThiThongTinLienHe(cb_makhach.Text.Trim());
            txtTheThanhVien.Text = BHangConTrol.HienThiThongTinThe(cb_makhach.Text.Trim());
        }

        private void cbMaNVHienThi_SelectedValueChanged(object sender, EventArgs e)
        {
            txtTenNVHienThi.Text = BHangConTrol.HienThiTenNhanVien(cbMaNVHienThi.Text);
        }

        private void btnChonMua_Click(object sender, EventArgs e)
        {
            DataTable dtHoadon = new DataTable();
            dtHoadon = BHangConTrol.HienThiFullHoaDon();
            gridControl2.DataSource = dtHoadon;
            TangMaTuDongHoaDon();
            txtSoLuongMua.Text = "1";
            gridControl1.Enabled = false;
            txtMaHangBan.Text = txtMaHang.Text;
            txtGiaHangBan.Text = txtGiaBanHang.Text;
            txtTenHangBan.Text = txtTenHang.Text;
            GRMuaHang_ThanhToan.Enabled = true;
            gridControl2.Enabled = false;
            txtMaPhieuMuaHang.Enabled=txtMaHangBan.Enabled=txtGiaHangBan.Enabled=txtTimNhanh.Enabled = btnTimKiemNhanh.Enabled = btnLamMoi.Enabled =txtMaHoaDon.Enabled=txtTenHangBan.Enabled=txtNgayMua.Enabled = false;
            //btnThemGioHang.Enabled = btnTraLaiHang.Enabled = txtSoLuongMua.Enabled = txtKhuyenMai.Enabled = txtGiamGia.Enabled = true;
        }

        private void btnHoanTac_Click(object sender, EventArgs e)
        {
            txtMaHangBan.Text = "";
            txtGiaHangBan.Text = "";
            txtTenHangBan.Text = "";
            txtSoLuongMua.Text = "";
            gridControl1.Enabled = true;
        }

        private void btnSuaPhieuMuaHang_Click(object sender, EventArgs e)
        {
            ConPhieuMuaHang c = new ConPhieuMuaHang();
            c.ShowDialog();
        }
        //Tăng mã tự động cho mã nhập
        string chuoi1, chuoi; //các chuổi để làm sinh mã tự động
        int dodai;
        public void TangMaTuDongPhieuMuaHang()
        {
            try
            {
                dodai = gridView3.RowCount;
                if (dodai < 10)
                {
                    chuoi = "PMH000";
                    chuoi1 = Convert.ToString(dodai);
                    txtMaPhieuMuaHang.Text = string.Concat(chuoi, chuoi1);
                }
                else
                    if (dodai < 100)
                    {
                        chuoi = "PMH00";
                        chuoi1 = Convert.ToString(dodai);
                        txtMaPhieuMuaHang.Text = string.Concat(chuoi, chuoi1);
                    }
                    else
                        if (dodai < 1000)
                        {
                            chuoi = "PMH0";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaPhieuMuaHang.Text = string.Concat(chuoi, chuoi1);
                        }
                        else
                        {
                            chuoi = "PMH";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaPhieuMuaHang.Text = string.Concat(chuoi, chuoi1);
                        }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnThemGioHang_Click(object sender, EventArgs e)
        {
            if ((txtMaPhieuMuaHang.Text == "") || (txtMaHoaDon.Text == "") || (txtMaHangBan.Text == "") || (txtTenHangBan.Text == "") || (txtSoLuongMua.Text == "") || (txtGiaHangBan.Text == ""))
            {
                MessageBox.Show("Chưa có thông tin hàng", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                slMua = ulong.Parse(txtSoLuongMua.Text.Trim());
                sLuongBan = ulong.Parse(txtSoLuongHang.Text.Trim());
                gia = ulong.Parse(txtGiaHangBan.Text.Trim());
                giamGia = ulong.Parse(txtGiamGia.Text.Trim());
                khuyenMai = ulong.Parse(txtKhuyenMai.Text.Trim());
                if (slMua > sLuongBan)
                    MessageBox.Show("Không đủ '" + txtTenHang.Text.Trim() + "' cung cấp, chỉ còn " + txtSoLuongHang.Text.Trim() + " sản phẩm");
                else
                {
                    thanhtien = (slMua * gia) - (giamGia * slMua) - (khuyenMai * slMua);
                    slMua = ulong.Parse(txtSoLuongMua.Text.Trim());
                    sLuongBan = ulong.Parse(txtSoLuongHang.Text.Trim());
                    sLuongNhan = sLuongBan - slMua;
                    txtSoLuongHang.Text = Convert.ToString(sLuongNhan);
                    txtThanhTien.Text = Convert.ToString(thanhtien);
                    if (BHangConTrol.ThemPhieuMuaHang(txtMaHoaDon.Text.Trim(), txtMaPhieuMuaHang.Text.Trim(), txtMaHangBan.Text.Trim(), txtSoLuongMua.Text.Trim(), txtGiaHangBan.Text.Trim(), txtThanhTien.Text.Trim(), txtTenHangBan.Text.Trim()))
                    {
                        if (BHangConTrol.SuaSoluongHang(txtMaHang.Text.Trim(), txtTenHang.Text.Trim(), txtDonViHang.Text.Trim(), txtLoaiHang.Text.Trim(), txtMaChiTienNhap.Text.Trim(), txtGiaBanHang.Text.Trim(), txtSoLuongHang.Text.Trim()))
                        {
                            DataTable dtThongTinHang = new DataTable();
                            dtThongTinHang = BHangConTrol.HienThiThongTinHang();
                            gridControl1.DataSource = dtThongTinHang;
                            KhongChoNhapDuLieu(true);
                            btnBanHang.Enabled = false;
                            gridControl1.Enabled = true;
                            btnThanhToan.Enabled = true;
                            LoadSauChonHangHoa();
                            DataTable dtHoaDon = new DataTable();
                            dtHoaDon = BHangConTrol.HienThiDuLieuHoaDon(txtMaPhieuMuaHang.Text.Trim());
                            gridControl2.Enabled = true;
                            //MessageBox.Show(BHangConTrol.HienThiDuLieuHoaDon(txtMaPhieuMuaHang.Text.Trim()).Rows.Count.ToString());
                            gridControl2.DataSource = dtHoaDon;
                            //Tính tổng tiền         
                            txtTongTien.EditValue = colThanhTien.SummaryItem.SummaryValue;
                            btnThanhToan.Enabled = true;
                        }
                        else
                            MessageBox.Show("Chưa thêm được hàng");
                    }
                    else
                        MessageBox.Show("Thêm thất bại. Mã hóa đơn '" + txtMaHoaDon.Text.Trim() + "' đã tồn tại ", "Thông báo");
                }
            }

        }

        private void gridControl2_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaHoaDon.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MaHoaDon").ToString();
                txtSoLuongMua.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "SoLuong").ToString();
                txtGiaHangBan.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "GiaBan").ToString();
                txtThanhTien.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ThanhTien").ToString();
            }
            catch { return; }
        }

        private void gridView3_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaPhieuMuaHang.Text = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "MaBanHang").ToString();
                txtNgayMua.Text = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "NgayBanHang").ToString();
            }
            catch { return; }
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaHoaDon.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MaChiTietHoaDon").ToString();
                txtSoLuongMua.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "SoLuong").ToString();
                txtGiaHangBan.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "GiaBan").ToString();
                txtGiaHangBan.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ThanhTien").ToString();
                txtTenHangBan.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "TenHang").ToString();
            }
            catch { return; }
        }
        //Tăng mã tự động cho hóa đơn bán hàng
        public void TangMaTuDongHoaDon()
        {
            try
            {
                dodai = gridView2.RowCount;
                if (dodai <= 100000)
                {
                    chuoi = "0";
                    chuoi1 = Convert.ToString(dodai);
                    txtMaHoaDon.Text = string.Concat(chuoi, chuoi1);
                }

            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            XtraReport rp = new XtraReport();
            rp.DataSource = BHangConTrol.HienThiDuLieuHoaDon(txtMaPhieuMuaHang.Text.Trim());
            rp.LoadLayout(Application.StartupPath + @"\HoaDonBanHang.repx");
            rp.ShowPreviewDialog();
        }

        private void labelControl19_Click(object sender, EventArgs e)
        {
            try
            {
                slMua = ulong.Parse(txtSoLuongMua.Text.Trim());
                gia = ulong.Parse(txtGiaHangBan.Text.Trim());
                thanhtien = slMua * gia;
                txtThanhTien.Text = Convert.ToString(thanhtien);
            }
            catch { }
        }

        private void btnXemPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                btnThanhToan.Enabled = btnBanHang.Enabled = false;
                gridControl1.Enabled = true;
                DataTable dtPhieuMuaHang = new DataTable();
                dtPhieuMuaHang = BHangConTrol.HienThiFullPhieuHang();
                gridControl3.DataSource = dtPhieuMuaHang;
                TangMaTuDongPhieuMuaHang();
                if ((txtMaPhieuMuaHang.Text == "") || (txtNgayMua.Text == "") || (txtMaKhach.Text == ""))
                {
                    MessageBox.Show("Thiếu thông tin");
                }
                else
                {
                    if (BHangConTrol.ThemPhieuMuaHang(txtMaPhieuMuaHang.Text.Trim(), txtNgayMua.Text, txtMaKhach.Text.Trim(), cbMaNVHienThi.Text.Trim()))
                    {
                        DataTable dtPhieuMua = new DataTable();
                        dtPhieuMua = BHangConTrol.HienThiDuLieuPhieuMuaHang(txtMaKhach.Text.Trim());
                        gridControl3.DataSource = dtPhieuMua;
                        //
                        btnThemHoaDon.Enabled = false;
                        gridControl1.Enabled = true;
                        GRMuaHang_ThanhToan.Enabled=gridControl3.Enabled = false;
                        HienThiBanDau(true);
                        
                    }
                    else
                        MessageBox.Show("Thêm thất bại. Phiếu hàng '" + txtMaPhieuMuaHang.Text.Trim() + "' đã tồn tại hoặc mã nhân viên '" + txtTenNVHienThi.Text.Trim() + "' và mã khách '" + cbMaNVHienThi.Text.Trim() + "' chưa tồn tại  ", "Thông báo");
                }
                
            }
            catch { }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            //tính tiền cho khách
            gia = ulong.Parse(txtTongTien.Text);
            khachTra = ulong.Parse(txtKhachTra.Text);
            if ((khachTra == 0)||(khachTra>gia))
            {
                ThoiTien();
                gridControl1.Enabled = true;
                btnLamMoi.Enabled = btnThemHoaDon.Enabled = true;
                groupControl5.Enabled = true;
                //Những thông tin không cho hiển thị sau thanh toán
                LoadSauThanhToan();
                btnTimKiemNhanh.Enabled = txtTimNhanh.Enabled = btnChonMua.Enabled = btnTraLaiHang.Enabled = cbMaNVHienThi.Enabled = false;
                gridControl1.Enabled = GRThongTinHang.Enabled = GrKhachHang.Enabled = groupControl5.Enabled = btnThemGioHang.Enabled = btnTraLaiHang.Enabled = btnBanHang.Enabled = false;
            }
            else
                    MessageBox.Show("Số tiền khách trả chưa đủ điền.");      
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                slMua = ulong.Parse(txtSoLuongMua.Text.Trim());
                sLuongBan = ulong.Parse(txtSoLuongHang.Text.Trim());
                sLuongNhan = sLuongBan + slMua;
                txtSoLuongHang.Text = Convert.ToString(sLuongNhan);
                if (BHangConTrol.SuaSoluongHang(txtMaHang.Text.Trim(), txtTenHang.Text.Trim(), txtDonViHang.Text.Trim(), txtLoaiHang.Text.Trim(), txtMaChiTienNhap.Text.Trim(), txtGiaBanHang.Text.Trim(), txtSoLuongHang.Text.Trim()))
                {
                    DataTable dtThongTinHang = new DataTable();
                    dtThongTinHang = BHangConTrol.HienThiThongTinHang();
                    gridControl1.DataSource = dtThongTinHang;
                    KhongChoNhapDuLieu(true);
                    BHangConTrol.TraLaiHangHoa(txtMaHoaDon.Text.Trim());
                    //hiển thị thông tin cho grid hóa đơn
                    DataTable dtHoaDon = new DataTable();
                    dtHoaDon = BHangConTrol.HienThiDuLieuHoaDon(txtMaPhieuMuaHang.Text.Trim());
                    gridControl2.DataSource = dtHoaDon;
                }
                else
                    MessageBox.Show("Trả hàng không thành công!");
            }
            catch { }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ConBanHang_Load(sender, e);
            LoadSauThanhToan();
            GrKhachHang.Enabled=btnBanHang.Enabled = true;
        }
        public void LoadSauThanhToan()
        {
            txtMaHoaDon.Text = txtMaHangBan.Text = txtSoLuongMua.Text = txtGiaHangBan.Text = txtTenHangBan.Text = "";
        }
        public void HienThiBanDau(bool ht)
        {
            gridControl1.Enabled = ht; //false
            btnThanhToan.Enabled = !ht;//ẩn nút thanh toán
            btnThemGioHang.Enabled = btnTraLaiHang.Enabled = btnChonMua.Enabled = btnHoanTac.Enabled = ht;
            groupControl5.Enabled = GrDuLieuHoaDon.Enabled = ht;
        }
        public void LoadSauChonHangHoa()
        {
            txtMaHoaDon.Text = txtSoLuongMua.Text = txtMaHangBan.Text = txtSoLuongMua.Text = txtGiaHangBan.Text = txtTenHangBan.Text = "";
            txtGiamGia.Text = txtKhuyenMai.Text = txtThanhTien.Text = "0";
        }
    }
}