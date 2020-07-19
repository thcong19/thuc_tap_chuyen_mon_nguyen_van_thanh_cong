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
using System.Threading;
using DevExpress.XtraReports.UI;

namespace PhanMemQuanLyShop_00.View
{
    public partial class ConKyGoi : DevExpress.XtraEditors.XtraForm
    {
        KyGoiControl KgControl = new KyGoiControl();
        public ConKyGoi()
        {
            InitializeComponent();
        }

        private void ConKyGoi_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtHienTTKyGoi = new DataTable();
                dtHienTTKyGoi = KgControl.LoadDulieuChoGrid();
                gridControl1.DataSource = dtHienTTKyGoi;
                HienThiLoad(true);
                GoiKiemTra();
                //hiển thị những chuồng có chó
                DataTable dtChuongDangDung = new DataTable();
                dtChuongDangDung = KgControl.LoadCho1Chuong("1");
                CbChuongDung.DataSource = dtChuongDangDung;
                CbChuongDung.DisplayMember = "TenChuong";
                CbChuongDung.ValueMember = "TenChuong";
                lbThongTin.Text = "THÔNG TIN KÝ GỞI CHÓ - MÈO";
            }
            catch { }
        }
        //Tính thành tiền 
        float giaCb, tienPhat, thanhTien;
        private void btnThanhTien_Click(object sender, EventArgs e)
        {
            try
            {
                giaCb = float.Parse(txtComboTT.Text.Trim());
                tienPhat = float.Parse(txtTienPhat.Text.Trim());
                if (txtTienPhat.Text == "")
                {
                    txtThanhTien.Text = Convert.ToString(giaCb);
                }
                else
                {
                    thanhTien = (giaCb + tienPhat);
                    txtThanhTien.Text = Convert.ToString(thanhTien);
                }
            }
            catch { }
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
            catch { }
        }
        //Load khi hiển thị
        public void HienThiLoad(bool hienThi)
        {
            GrHeThongChuong.Enabled = hienThi;
            GrThongTinChuong.Enabled = GrThanhToan.Enabled = GrDanhSachkyGoi.Enabled = btnInPhieu.Enabled = !hienThi;
        }
        public void HienThiDangKy(bool hienThi)
        {
            GrHeThongChuong.Enabled = GrThanhToan.Enabled = !hienThi;
            GrThongTinChuong.Enabled = GrDanhSachkyGoi.Enabled = hienThi;
        }
        public void HienThiClickSua(bool hienThi)
        {
            GrHeThongChuong.Enabled = GrThanhToan.Enabled = !hienThi;
            GrThongTinChuong.Enabled = GrDanhSachkyGoi.Enabled = hienThi;
        }
        public void HienThiKhiThanhToan(bool hienthi)
        {
            GrThanhToan.Enabled = hienthi;
            GrDanhSachkyGoi.Enabled = GrHeThongChuong.Enabled = GrThongTinChuong.Enabled = !hienthi;
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                btnInPhieu.Enabled = true;
                TangMaTuDongPhieu();
                HienThiDangKy(true);
                btnSua.Enabled = false;
                //Load mã chuồng
                DataTable dtComboBomMaChuong = new DataTable();
                dtComboBomMaChuong = KgControl.LoadChoComBoboxMaChuong("0");
                CbMaChuong.DataSource = dtComboBomMaChuong;
                CbMaChuong.DisplayMember = "MaChuong";
                CbMaChuong.ValueMember = "MaChuong";
                txtNgayDen.Text = txtNgayVe.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại vào text
                //Load mã nhân viên
                DataTable dtComboBomMaNV = new DataTable();
                dtComboBomMaNV = KgControl.LoadChoComBoboxMaNv();
                txtNhanVienLap.Properties.DataSource = dtComboBomMaNV;
                txtNhanVienLap.Properties.DisplayMember = "MaNhanVien";
            }
            catch { }
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                HienThiClickSua(true);
                btnInPhieu.Enabled = false;
                btnChonChuong.Enabled = false;
                btnSua.Enabled = true;
                CbMaChuong.Enabled = txtMaKyGoi.Enabled = txtNgayVe.Enabled = txtNgayDen.Enabled = false;
                txtMaKyGoi.Text = CbMaChuong.Text = txtChungMinh.Text = txtGiaComBo.Text = txtKhachHang.Text = txtLienHe.Text = CbChuongDung.Text = txtNgayDen.Text = txtNgayVe.Text = txtNhanVienLap.Text = txtSoLuong.Text = txtTenCun.Text = "";
            }
            catch { MessageBox.Show("Thất bại"); }
        }
        //Sửa thông tin ký gởi
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                HienThiLoad(true);
                if (KgControl.SuaThongTinKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                    MessageBox.Show("Xong");
                else
                    MessageBox.Show("Thất bại");
            }
            catch { }
        }
        #region TrangThaiCacChuong
        //Code load trạng thái cho các ô có hông có thú cưng
        public void GoiKiemTra()
        {
            try
            {
                DataTable dtTrangThai = new DataTable();
                dtTrangThai = KgControl.laycottrangthai();
                SimpleButton[] bt = new SimpleButton[20] { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20, };
                for (int i = 0; i < 20; i++)
                {
                    if ((int)dtTrangThai.Rows[i][0] == 0)
                    {
                        bt[i].ForeColor = Color.MediumVioletRed;
                        bt[i].Text = ("Chuồng " + (i + 1));
                    }
                    else
                    {
                        bt[i].ForeColor = Color.Black;
                        bt[i].Text = ("Chuồng " + (i + 1) + " (^_^)");
                    }
                }
            }
            catch { }
        }
        #endregion
        #region CHUONG_1
        //BẮT SỰ KIỆN CHO CHUỒNG 1
        private void btn1_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "CHUONG01";
                if ((btn1.Text == "Chuồng 1") && (a == CbMaChuong.Text.Trim()))
                {
                    if (DialogResult.Yes == MessageBox.Show("Đăng ký thông tin ký gởi cho chuồng số 1?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            MessageBox.Show("Thông tin ký gởi chưa đầy đủ!");
                            return;
                        }
                        else
                        {
                            //maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,NgayGoi,NgayTra,giaComBo,maNhanVien,tenChuong,giayTo
                            if (KgControl.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                            {
                                KgControl.SuaTrangThai("CHUONG01", "Chuồng 01", "1");
                                ConKyGoi_Load(sender, e);
                                MessageBox.Show("Chuồng 1 đã được khách '" + txtKhachHang.Text.Trim() + "' chọn sử dụng");
                            }
                            else
                                MessageBox.Show("Không thành công. Phiếu ký gởi đã có khách sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("Đã hủy!");
                }
                else
                {
                    if ((btn1.Text == "Chuồng 1 (^_^)"))
                    {
                        HienThiDangKy(true);
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        CbMaChuong.Text = "CHUONG01";
                        lbThongTin.Text = "THÔNG TIN KÝ GỞI CỦA KHÁCH HÀNG";
                        gridView1.FocusedRowHandle = 0;
                    }
                    else
                    {
                        if ((btn1.Text == "Chuồng 1") && (txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            return;
                        }
                        else
                            MessageBox.Show("Đây là " + btn1.Text.Trim() + " không thể đăng ký thông tin cho " + CbMaChuong.Text.Trim() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }
        //THANH TOÁN
        private void btn1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if ((btn1.Text == "Chuồng 1 (^_^)"))
                {
                    if (DialogResult.Yes == MessageBox.Show("Thanh toán cho chuồng số 1?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if((CbMaChuong.Text.Trim()!="CHUONG01")||(txtNhanVienLap.Text=="")||(txtGiaComBo.Text=="")||(txtMaKyGoi.Text==""))
                        {
                        KgControl.SuaTrangThai("CHUONG01", "Chuồng 01", "0");
                        HienThiKhiThanhToan(true);
                        TangMaTuDongHoaDonThanhToan();
                        //CbMaChuong.Text = "CHUONG01";
                        txtTienPhat.Text = "0";
                        txtNgayThanhToan.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại
                        //hiển thị thông tin cho hóa đơn lấy
                        DataTable dtLoand1Chuong = new DataTable();
                        dtLoand1Chuong = KgControl.HIenThiChoHoaDon(txtMaKyGoi.Text.Trim());
                        gridControl1.DataSource = dtLoand1Chuong;
                        //Hiển thị các text
                        DataTable dtNVThanhToan = new DataTable();
                        dtNVThanhToan = KgControl.LoadChoComBoboxMaNv();
                        txtNhanVienTinhTien.Properties.DataSource = dtNVThanhToan;
                        txtNhanVienTinhTien.Properties.DisplayMember = "MaNhanVien";
                        //
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        txtComboTT.Text = txtGiaComBo.Text;
                        txtNVThanhToan.Text = txtNhanVienLap.Text;
                        }
                        else
                        {
                            MessageBox.Show("Thông tin thanh toán chưa hợp lệ");
                        }
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Chuồng chưa sử dụng.");
            }
            catch { }
        }
        //Kết thúc chuồng 1
        #endregion
        //Chọn chuồng cho thông tin ký gởi
        private void btnChonChuong_Click(object sender, EventArgs e)
        {
            if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
            {
                MessageBox.Show("Thông tin ký gởi chưa đầy đủ");
                return;
            }
            else
                HienThiLoad(true);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtMaHoaDon.Text == "") || (txtNVThanhToan.Text == "") || (txtNgayThanhToan.Text == "") || (txtTienPhat.Text == "") || (txtNhanVienTinhTien.Text == ""))
                {
                    MessageBox.Show("Thông tin hóa đơn phải đầy đủ");
                }
                else
                {
                    //maThanhToan, thanhTien, maNhanVien, tienPhat, giaCombo, ngayLap, maChuong, maThongTinKyGoi, maNVThanhToan
                    if (KgControl.ThemMoiHoaDon(txtMaHoaDon.Text.Trim(), txtThanhTien.Text.Trim(), txtNhanVienLap.Text.Trim(), txtTienPhat.Text.Trim(), txtComboTT.Text.Trim(), txtNgayThanhToan.Value.ToString(), CbMaChuong.Text.Trim(), txtMaKyGoi.Text.Trim(), txtNhanVienTinhTien.Text.Trim()))
                    {
                        if (DialogResult.Yes == MessageBox.Show("Bạn có muốn in hóa đơn không?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            KgControl.XoaThongTinKyGoi(txtMaKyGoi.Text.Trim());
                            KhoaKhiInHoaDon(false);
                            return;
                        }
                        else
                        {
                            KgControl.XoaThongTinKyGoi(txtMaKyGoi.Text.Trim());
                            MessageBox.Show("Đã cập nhật " + CbMaChuong.Text.Trim() + " có thể sử dụng");
                            Xoa_TrangThongTinHoaDon();
                            ConKyGoi_Load(sender, e);
                        }
                    }
                    else
                    { MessageBox.Show("Lỗi, thêm hóa đơn thất bại"); }
                }
            }
            catch { }
        }


        //nút trở lại
        private void btnTroLai_Click(object sender, EventArgs e)
        {
            ConKyGoi_Load(sender, e);
            //Xoa_Trang();
        }
        #region Tăng_mã
        //Tăng mã tự động cho hóa đơn thanh toán
        string chuoi1, chuoi; //các chuổi để làm sinh mã tự động
        int dodai;
        public void TangMaTuDongHoaDonThanhToan()
        {
            try
            {
                DataTable dtHoaDon = new DataTable();
                dtHoaDon = KgControl.LoadChoTangMaHoaDon();
                dodai = dtHoaDon.Rows.Count;
                if (dodai < 10)
                {
                    chuoi = "HDKG00";
                    chuoi1 = Convert.ToString(dodai);
                    txtMaHoaDon.Text = string.Concat(chuoi, chuoi1);
                }
                else
                    if (dodai < 100)
                    {
                        chuoi = "HDKG0";
                        chuoi1 = Convert.ToString(dodai);
                        txtMaHoaDon.Text = string.Concat(chuoi, chuoi1);
                    }
                        else
                        {
                            chuoi = "HDKG";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaHoaDon.Text = string.Concat(chuoi, chuoi1);
                        }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        //Tăng mã tự động cho phiếu ksy gởi
        public void TangMaTuDongPhieu()
        {
            try
            {
                dodai = gridView1.RowCount;
                if (dodai < 10)
                {
                    chuoi = "KG00";
                    chuoi1 = Convert.ToString(dodai);
                    txtMaKyGoi.Text = string.Concat(chuoi, chuoi1);
                }
                else
                    if (dodai < 100)
                    {
                        chuoi = "KG0";
                        chuoi1 = Convert.ToString(dodai);
                        txtMaKyGoi.Text = string.Concat(chuoi, chuoi1);
                    }
                    else
                        {
                            chuoi = "KG";
                            chuoi1 = Convert.ToString(dodai);
                            txtMaKyGoi.Text = string.Concat(chuoi, chuoi1);
                        }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        #endregion
        //Xóa trắng text khi bấm trở về
        public void Xoa_Trang()
        {
            txtNgayDen.Text = txtNgayVe.Text = txtKhachHang.Text = txtChungMinh.Text = txtNhanVienLap.Text = txtGiaComBo.Text = txtTenCun.Text = txtGiayTo.Text = txtSoLuong.Text = txtMaKyGoi.Text = txtLienHe.Text = "";
        }
        public void Xoa_TrangThongTinHoaDon()
        {
            txtMaHoaDon.Text = txtNVThanhToan.Text = txtNgayThanhToan.Text = txtTienPhat.Text = txtThanhTien.Text = txtNhanVienTinhTien.Text = "";
        }
        public void KhoaKhiInHoaDon(bool k)
        {
            txtComboTT.Enabled = txtMaHoaDon.Enabled = txtNVThanhToan.Enabled = txtNgayThanhToan.Enabled = txtTienPhat.Enabled = txtThanhTien.Enabled = txtNhanVienTinhTien.Enabled = k;
            btnXoaBo.Enabled = btnThanhToan.Enabled = k;
        }
        public void Kiem_Tra_ThongTinHoaDon()
        {
            if ((txtMaHoaDon.Text == "") || (txtNVThanhToan.Text == "") || (txtNgayThanhToan.Text == "") || (txtTienPhat.Text == "") || (txtNhanVienTinhTien.Text == ""))
                MessageBox.Show("Thông tin hóa đơn chưa đầy đủ");
            else
                return;
        }
        //btn khi khách hủy bỏ
        private void btnXoaBo_Click(object sender, EventArgs e)
        {

            if (DialogResult.Yes == MessageBox.Show("Bạn chắc chắn hủy ký gởi chuồng này và không thanh toán", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                KgControl.XoaThongTinKyGoi(txtMaKyGoi.Text.Trim());
                MessageBox.Show("Đã cập nhật " + CbMaChuong.Text.Trim() + " có thể sử dụng");
                Xoa_TrangThongTinHoaDon();
                ConKyGoi_Load(sender, e);
            }
            else return;
        }
        //CODE CHO CÁC BUTTON
        #region Chuong_2
        //Chuồng 2
        private void btn2_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "CHUONG02";
                if ((btn2.Text == "Chuồng 2") && (a == CbMaChuong.Text.Trim()))
                {
                    if (DialogResult.Yes == MessageBox.Show("Đăng ký thông tin ký gởi cho chuồng số 2?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            MessageBox.Show("Thiếu thông tin!");
                            return;
                        }
                        else
                        {
                            //maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,NgayGoi,NgayTra,giaComBo,maNhanVien,tenChuong,giayTo
                            if (KgControl.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                            {
                                KgControl.SuaTrangThai("CHUONG02", "Chuồng 02", "1");
                                ConKyGoi_Load(sender, e);
                                MessageBox.Show("Chuồng 2 đã được khách '" + txtKhachHang.Text.Trim() + "' chọn sử dụng");
                            }
                            else
                                MessageBox.Show("Không thành công. Phiếu ký gởi đã có khách sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("Đã hủy!");
                }
                else
                {
                    if ((btn2.Text == "Chuồng 2 (^_^)"))
                    {
                        HienThiDangKy(true);
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        CbMaChuong.Text = "CHUONG02";
                        lbThongTin.Text = "THÔNG TIN KÝ GỞI CỦA KHÁCH HÀNG";
                        gridView1.FocusedRowHandle = 1;
                    }
                    else
                    {
                        if ((btn2.Text == "Chuồng 2") && (txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            return;
                        }
                        else
                            MessageBox.Show("Đây là " + btn2.Text.Trim() + " không thể đăng ký thông tin cho " + CbMaChuong.Text.Trim() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }
        //THANH TOÁN
        private void btn2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if ((btn2.Text == "Chuồng 2 (^_^)"))
                {
                    if (DialogResult.Yes == MessageBox.Show("Thanh toán cho chuồng số 2?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        KgControl.SuaTrangThai("CHUONG02", "Chuồng 02", "0");
                        HienThiKhiThanhToan(true);
                        TangMaTuDongHoaDonThanhToan();
                        CbMaChuong.Text = "CHUONG02";
                        txtNgayThanhToan.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại
                        txtTienPhat.Text = "0";
                        //hiển thị thông tin cho hóa đơn lấy
                        DataTable dtLoand1Chuong = new DataTable();
                        dtLoand1Chuong = KgControl.HIenThiChoHoaDon(txtMaKyGoi.Text.Trim());
                        gridControl1.DataSource = dtLoand1Chuong;
                        //Hiển thị các text
                        DataTable dtNVThanhToan = new DataTable();
                        dtNVThanhToan = KgControl.LoadChoComBoboxMaNv();
                        txtNhanVienTinhTien.Properties.DataSource = dtNVThanhToan;
                        txtNhanVienTinhTien.Properties.DisplayMember = "MaNhanVien";
                        //
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        txtComboTT.Text = txtGiaComBo.Text;
                        txtNVThanhToan.Text = txtNhanVienLap.Text;
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Chuồng chưa sử dụng.");
            }
            catch { }
        }
        //kết thúc chuồng 2
        #endregion
        #region Chuong3
        private void btn3_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "CHUONG03";
                if ((btn3.Text == "Chuồng 3") && (a == CbMaChuong.Text.Trim()))
                {
                    if (DialogResult.Yes == MessageBox.Show("Đăng ký thông tin ký gởi cho chuồng số 3?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            MessageBox.Show("Thiếu thông tin!");
                            return;
                        }
                        else
                        {
                            //maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,NgayGoi,NgayTra,giaComBo,maNhanVien,tenChuong,giayTo
                            if (KgControl.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                            {
                                KgControl.SuaTrangThai("CHUONG03", "Chuồng 03", "1");
                                ConKyGoi_Load(sender, e);
                                MessageBox.Show("Chuồng 3 đã được khách '" + txtKhachHang.Text.Trim() + "' chọn sử dụng");
                            }
                            else
                                MessageBox.Show("Không thành công. Phiếu ký gởi đã có khách sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("Đã hủy!");
                }
                else
                {
                    if ((btn3.Text == "Chuồng 3 (^_^)"))
                    {
                        HienThiDangKy(true);
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        CbMaChuong.Text = "CHUONG03";
                        lbThongTin.Text = "THÔNG TIN KÝ GỞI CỦA KHÁCH HÀNG";
                        gridView1.FocusedRowHandle = 2;
                    }
                    else
                    {
                        if ((btn3.Text == "Chuồng 3") && (txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            return;
                        }
                        else
                            MessageBox.Show("Đây là " + btn3.Text.Trim() + " không thể đăng ký thông tin cho " + CbMaChuong.Text.Trim() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }
        //Thanh toán
        private void btn3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if ((btn3.Text == "Chuồng 3 (^_^)"))
                {
                    if (DialogResult.Yes == MessageBox.Show("Thanh toán cho chuồng số 3?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        KgControl.SuaTrangThai("CHUONG03", "Chuồng 03", "0");
                        HienThiKhiThanhToan(true);
                        TangMaTuDongHoaDonThanhToan();
                        CbMaChuong.Text = "CHUONG03";
                        txtTienPhat.Text = "0";
                        txtNgayThanhToan.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại
                        //hiển thị thông tin cho hóa đơn lấy
                        DataTable dtLoand1Chuong = new DataTable();
                        dtLoand1Chuong = KgControl.HIenThiChoHoaDon(txtMaKyGoi.Text.Trim());
                        gridControl1.DataSource = dtLoand1Chuong;
                        //Hiển thị các text
                        DataTable dtNVThanhToan = new DataTable();
                        dtNVThanhToan = KgControl.LoadChoComBoboxMaNv();
                        txtNhanVienTinhTien.Properties.DataSource = dtNVThanhToan;
                        txtNhanVienTinhTien.Properties.DisplayMember = "MaNhanVien";
                        //
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        txtComboTT.Text = txtGiaComBo.Text;
                        txtNVThanhToan.Text = txtNhanVienLap.Text;
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Chuồng chưa sử dụng.");
            }
            catch { }
        }
        #endregion
        //Chuồng 4
        #region Chuong4
        private void btn4_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "CHUONG04";
                if ((btn4.Text == "Chuồng 4") && (a == CbMaChuong.Text.Trim()))
                {
                    if (DialogResult.Yes == MessageBox.Show("Đăng ký thông tin ký gởi cho chuồng số 4?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            MessageBox.Show("Thiếu thông tin!");
                            return;
                        }
                        else
                        {
                            //maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,NgayGoi,NgayTra,giaComBo,maNhanVien,tenChuong,giayTo
                            if (KgControl.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                            {
                                KgControl.SuaTrangThai("CHUONG04", "Chuồng 04", "1");
                                ConKyGoi_Load(sender, e);
                                MessageBox.Show("Chuồng 4 đã được khách '" + txtKhachHang.Text.Trim() + "' chọn sử dụng");
                            }
                            else
                                MessageBox.Show("Không thành công. Phiếu ký gởi đã có khách sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("Đã hủy!");
                }
                else
                {
                    if (btn4.Text == "Chuồng 4 (^_^)")
                    {
                        HienThiDangKy(true);
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        CbMaChuong.Text = "CHUONG04";
                        lbThongTin.Text = "THÔNG TIN KÝ GỞI CỦA KHÁCH HÀNG";
                        gridView1.FocusedRowHandle = 3;
                    }
                    else
                    {
                        if ((btn4.Text == "Chuồng 4") && (txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            return;
                        }
                        else
                            MessageBox.Show("Đây là " + btn4.Text.Trim() + " không thể đăng ký thông tin cho " + CbMaChuong.Text.Trim() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }
        //THANHTOAN
        private void btn4_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            try
            {
                if ((btn4.Text == "Chuồng 4 (^_^)"))
                {
                    if (DialogResult.Yes == MessageBox.Show("Thanh toán cho chuồng số 4?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        KgControl.SuaTrangThai("CHUONG04", "Chuồng 04", "0");
                        HienThiKhiThanhToan(true);
                        TangMaTuDongHoaDonThanhToan();
                        CbMaChuong.Text = "CHUONG04";
                        txtNgayThanhToan.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại
                        txtTienPhat.Text = "0";
                        //hiển thị thông tin cho hóa đơn lấy
                        DataTable dtLoand1Chuong = new DataTable();
                        dtLoand1Chuong = KgControl.HIenThiChoHoaDon(txtMaKyGoi.Text.Trim());
                        gridControl1.DataSource = dtLoand1Chuong;
                        //Hiển thị các text
                        DataTable dtNVThanhToan = new DataTable();
                        dtNVThanhToan = KgControl.LoadChoComBoboxMaNv();
                        txtNhanVienTinhTien.Properties.DataSource = dtNVThanhToan;
                        txtNhanVienTinhTien.Properties.DisplayMember = "MaNhanVien";
                        //
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        txtComboTT.Text = txtGiaComBo.Text;
                        txtNVThanhToan.Text = txtNhanVienLap.Text;
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Chuồng chưa sử dụng.");
            }
            catch { }
        }
        #endregion
        //Chuồng 5
        #region Chuong5
        private void btn5_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "CHUONG05";
                if ((btn5.Text == "Chuồng 5") && (a == CbMaChuong.Text.Trim()))
                {
                    if (DialogResult.Yes == MessageBox.Show("Đăng ký thông tin ký gởi cho chuồng số 5?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            MessageBox.Show("Thiếu thông tin!");
                            return;
                        }
                        else
                        {
                            //maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,NgayGoi,NgayTra,giaComBo,maNhanVien,tenChuong,giayTo
                            if (KgControl.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                            {
                                KgControl.SuaTrangThai("CHUONG05", "Chuồng 05", "1");
                                ConKyGoi_Load(sender, e);
                                MessageBox.Show("Chuồng 5 đã được khách '" + txtKhachHang.Text.Trim() + "' chọn sử dụng");
                            }
                            else
                                MessageBox.Show("Không thành công. Phiếu ký gởi đã có khách sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("Đã hủy!");
                }
                else
                {
                    if ((btn5.Text == "Chuồng 5 (^_^)"))
                    {
                        HienThiDangKy(true);
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        CbMaChuong.Text = "CHUONG05";
                        lbThongTin.Text = "THÔNG TIN KÝ GỞI CỦA KHÁCH HÀNG";
                        gridView1.FocusedRowHandle = 4;
                    }
                    else
                    {
                        if ((btn5.Text == "Chuồng 5") && (txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            return;
                        }
                        else
                            MessageBox.Show("Đây là " + btn5.Text.Trim() + " không thể đăng ký thông tin cho " + CbMaChuong.Text.Trim() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }
        private void btn5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if ((btn5.Text == "Chuồng 5 (^_^)"))
                {
                    if (DialogResult.Yes == MessageBox.Show("Thanh toán cho chuồng số 2?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        KgControl.SuaTrangThai("CHUONG05", "Chuồng 05", "0");
                        HienThiKhiThanhToan(true);
                        TangMaTuDongHoaDonThanhToan();
                        CbMaChuong.Text = "CHUONG05";
                        txtNgayThanhToan.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại
                        txtTienPhat.Text = "0";
                        //hiển thị thông tin cho hóa đơn lấy
                        DataTable dtLoand1Chuong = new DataTable();
                        dtLoand1Chuong = KgControl.HIenThiChoHoaDon(txtMaKyGoi.Text.Trim());
                        gridControl1.DataSource = dtLoand1Chuong;
                        //Hiển thị các text
                        DataTable dtNVThanhToan = new DataTable();
                        dtNVThanhToan = KgControl.LoadChoComBoboxMaNv();
                        txtNhanVienTinhTien.Properties.DataSource = dtNVThanhToan;
                        txtNhanVienTinhTien.Properties.DisplayMember = "MaNhanVien";
                        //
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        txtComboTT.Text = txtGiaComBo.Text;
                        txtNVThanhToan.Text = txtNhanVienLap.Text;
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Chuồng chưa sử dụng.");
            }
            catch { }
        }
 
        #endregion
        //Chuồng 6
        #region Chuong6
        private void btn6_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "CHUONG06";
                if ((btn6.Text == "Chuồng 6") && (a == CbMaChuong.Text.Trim()))
                {
                    if (DialogResult.Yes == MessageBox.Show("Đăng ký thông tin ký gởi cho chuồng số 2?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            MessageBox.Show("Thiếu thông tin!");
                            return;
                        }
                        else
                        {
                            //maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,NgayGoi,NgayTra,giaComBo,maNhanVien,tenChuong,giayTo
                            if (KgControl.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                            {
                                KgControl.SuaTrangThai("CHUONG06", "Chuồng 06", "1");
                                ConKyGoi_Load(sender, e);
                                MessageBox.Show("Chuồng 6 đã được khách '" + txtKhachHang.Text.Trim() + "' chọn sử dụng");
                            }
                            else
                                MessageBox.Show("Không thành công. Phiếu ký gởi đã có khách sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("Đã hủy!");
                }
                else
                {
                    if ((btn6.Text == "Chuồng 6 (^_^)"))
                    {
                        HienThiDangKy(true);
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        CbMaChuong.Text = "CHUONG06";
                        lbThongTin.Text = "THÔNG TIN KÝ GỞI CỦA KHÁCH HÀNG";
                        gridView1.FocusedRowHandle = 5;
                    }
                    else
                    {
                        if ((btn2.Text == "Chuồng 6") && (txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            return;
                        }
                        else
                            MessageBox.Show("Đây là " + btn6.Text.Trim() + " không thể đăng ký thông tin cho " + CbMaChuong.Text.Trim() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }
        //THANHTOAN
        private void btn6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if ((btn6.Text == "Chuồng 6 (^_^)"))
                {
                    if (DialogResult.Yes == MessageBox.Show("Thanh toán cho chuồng số 2?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        KgControl.SuaTrangThai("CHUONG06", "Chuồng 06", "0");
                        HienThiKhiThanhToan(true);
                        TangMaTuDongHoaDonThanhToan();
                        CbMaChuong.Text = "CHUONG06";
                        txtNgayThanhToan.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại
                        txtTienPhat.Text = "0";
                        //hiển thị thông tin cho hóa đơn lấy
                        DataTable dtLoand1Chuong = new DataTable();
                        dtLoand1Chuong = KgControl.HIenThiChoHoaDon(txtMaKyGoi.Text.Trim());
                        gridControl1.DataSource = dtLoand1Chuong;
                        //Hiển thị các text
                        DataTable dtNVThanhToan = new DataTable();
                        dtNVThanhToan = KgControl.LoadChoComBoboxMaNv();
                        txtNhanVienTinhTien.Properties.DataSource = dtNVThanhToan;
                        txtNhanVienTinhTien.Properties.DisplayMember = "MaNhanVien";
                        //
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        txtComboTT.Text = txtGiaComBo.Text;
                        txtNVThanhToan.Text = txtNhanVienLap.Text;
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Chuồng chưa sử dụng.");
            }
            catch { }
        }
        #endregion
        //Chuồng 7
        #region Chuong7
        private void btn7_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "CHUONG07";
                if ((btn7.Text == "Chuồng 7") && (a == CbMaChuong.Text.Trim()))
                {
                    if (DialogResult.Yes == MessageBox.Show("Đăng ký thông tin ký gởi cho chuồng số 7?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            MessageBox.Show("Thiếu thông tin!");
                            return;
                        }
                        else
                        {
                            //maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,NgayGoi,NgayTra,giaComBo,maNhanVien,tenChuong,giayTo
                            if (KgControl.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                            {
                                KgControl.SuaTrangThai("CHUONG07", "Chuồng 07", "1");
                                ConKyGoi_Load(sender, e);
                                MessageBox.Show("Chuồng 7 đã được khách '" + txtKhachHang.Text.Trim() + "' chọn sử dụng");
                            }
                            else
                                MessageBox.Show("Không thành công. Phiếu ký gởi đã có khách sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("Đã hủy!");
                }
                else
                {
                    if ((btn7.Text == "Chuồng 7 (^_^)"))
                    {
                        HienThiDangKy(true);
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        CbMaChuong.Text = "CHUONG07";
                        lbThongTin.Text = "THÔNG TIN KÝ GỞI CỦA KHÁCH HÀNG";
                        gridView1.FocusedRowHandle = 6;
                    }
                    else
                    {
                        if ((btn7.Text == "Chuồng 7") && (txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            return;
                        }
                        else
                            MessageBox.Show("Đây là " + btn7.Text.Trim() + " không thể đăng ký thông tin cho " + CbMaChuong.Text.Trim() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }
        //THANHTOAN
        private void btn7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if ((btn7.Text == "Chuồng 7 (^_^)"))
                {
                    if (DialogResult.Yes == MessageBox.Show("Thanh toán cho chuồng số 7?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        KgControl.SuaTrangThai("CHUONG07", "Chuồng 07", "0");
                        HienThiKhiThanhToan(true);
                        TangMaTuDongHoaDonThanhToan();
                        CbMaChuong.Text = "CHUONG07";
                        txtNgayThanhToan.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại
                        txtTienPhat.Text = "0";
                        //hiển thị thông tin cho hóa đơn lấy
                        DataTable dtLoand1Chuong = new DataTable();
                        dtLoand1Chuong = KgControl.HIenThiChoHoaDon(txtMaKyGoi.Text.Trim());
                        gridControl1.DataSource = dtLoand1Chuong;
                        //Hiển thị các text
                        DataTable dtNVThanhToan = new DataTable();
                        dtNVThanhToan = KgControl.LoadChoComBoboxMaNv();
                        txtNhanVienTinhTien.Properties.DataSource = dtNVThanhToan;
                        txtNhanVienTinhTien.Properties.DisplayMember = "MaNhanVien";
                        //
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        txtComboTT.Text = txtGiaComBo.Text;
                        txtNVThanhToan.Text = txtNhanVienLap.Text;
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Chuồng chưa sử dụng.");
            }
            catch { }
        }
        #endregion
        //Chuồng 8
        #region Chuong8
        private void btn8_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "CHUONG08";
                if ((btn8.Text == "Chuồng 8") && (a == CbMaChuong.Text.Trim()))
                {
                    if (DialogResult.Yes == MessageBox.Show("Đăng ký thông tin ký gởi cho chuồng số 8?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            MessageBox.Show("Thiếu thông tin!");
                            return;
                        }
                        else
                        {
                            //maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,NgayGoi,NgayTra,giaComBo,maNhanVien,tenChuong,giayTo
                            if (KgControl.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                            {
                                KgControl.SuaTrangThai("CHUONG08", "Chuồng 08", "1");
                                ConKyGoi_Load(sender, e);
                                MessageBox.Show("Chuồng 8 đã được khách '" + txtKhachHang.Text.Trim() + "' chọn sử dụng");
                            }
                            else
                                MessageBox.Show("Không thành công. Phiếu ký gởi đã có khách sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("Đã hủy!");
                }
                else
                {
                    if ((btn8.Text == "Chuồng 8 (^_^)"))
                    {
                        HienThiDangKy(true);
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        CbMaChuong.Text = "CHUONG08";
                        lbThongTin.Text = "THÔNG TIN KÝ GỞI CỦA KHÁCH HÀNG";
                        gridView1.FocusedRowHandle = 7;
                    }
                    else
                    {
                        if ((btn8.Text == "Chuồng 8") && (txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            return;
                        }
                        else
                            MessageBox.Show("Đây là " + btn8.Text.Trim() + " không thể đăng ký thông tin cho " + CbMaChuong.Text.Trim() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }

        private void btn8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if ((btn8.Text == "Chuồng 8 (^_^)"))
                {
                    if (DialogResult.Yes == MessageBox.Show("Thanh toán cho chuồng số 8?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        KgControl.SuaTrangThai("CHUONG08", "Chuồng 08", "0");
                        HienThiKhiThanhToan(true);
                        TangMaTuDongHoaDonThanhToan();
                        CbMaChuong.Text = "CHUONG08";
                        txtTienPhat.Text = "0";
                        txtNgayThanhToan.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại
                        //hiển thị thông tin cho hóa đơn lấy
                        DataTable dtLoand1Chuong = new DataTable();
                        dtLoand1Chuong = KgControl.HIenThiChoHoaDon(txtMaKyGoi.Text.Trim());
                        gridControl1.DataSource = dtLoand1Chuong;
                        //Hiển thị các text
                        DataTable dtNVThanhToan = new DataTable();
                        dtNVThanhToan = KgControl.LoadChoComBoboxMaNv();
                        txtNhanVienTinhTien.Properties.DataSource = dtNVThanhToan;
                        txtNhanVienTinhTien.Properties.DisplayMember = "MaNhanVien";
                        //
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        txtComboTT.Text = txtGiaComBo.Text;
                        txtNVThanhToan.Text = txtNhanVienLap.Text;
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Chuồng chưa sử dụng.");
            }
            catch { }
        }
        #endregion
        //Chuồng 9
        #region Chuong9

        private void btn9_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "CHUONG09";
                if ((btn9.Text == "Chuồng 9") && (a == CbMaChuong.Text.Trim()))
                {
                    if (DialogResult.Yes == MessageBox.Show("Đăng ký thông tin ký gởi cho chuồng số 9?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            MessageBox.Show("Thiếu thông tin!");
                            return;
                        }
                        else
                        {
                            //maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,NgayGoi,NgayTra,giaComBo,maNhanVien,tenChuong,giayTo
                            if (KgControl.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                            {
                                KgControl.SuaTrangThai("CHUONG09", "Chuồng 09", "1");
                                ConKyGoi_Load(sender, e);
                                MessageBox.Show("Chuồng 9 đã được khách '" + txtKhachHang.Text.Trim() + "' chọn sử dụng");
                            }
                            else
                                MessageBox.Show("Không thành công. Phiếu ký gởi đã có khách sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("Đã hủy!");
                }
                else
                {
                    if ((btn9.Text == "Chuồng 9 (^_^)"))
                    {
                        HienThiDangKy(true);
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        CbMaChuong.Text = "CHUONG09";
                        lbThongTin.Text = "THÔNG TIN KÝ GỞI CỦA KHÁCH HÀNG";
                        gridView1.FocusedRowHandle = 8;
                    }
                    else
                    {
                        if ((btn2.Text == "Chuồng 9") && (txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            return;
                        }
                        else
                            MessageBox.Show("Đây là " + btn9.Text.Trim() + " không thể đăng ký thông tin cho " + CbMaChuong.Text.Trim() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }

        private void btn9_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if ((btn9.Text == "Chuồng 9 (^_^)"))
                {
                    if (DialogResult.Yes == MessageBox.Show("Thanh toán cho chuồng số 9?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        KgControl.SuaTrangThai("CHUONG09", "Chuồng 09", "0");
                        HienThiKhiThanhToan(true);
                        TangMaTuDongHoaDonThanhToan();
                        CbMaChuong.Text = "CHUONG09";
                        txtTienPhat.Text = "0";
                        txtNgayThanhToan.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại
                        //hiển thị thông tin cho hóa đơn lấy
                        DataTable dtLoand1Chuong = new DataTable();
                        dtLoand1Chuong = KgControl.HIenThiChoHoaDon(txtMaKyGoi.Text.Trim());
                        gridControl1.DataSource = dtLoand1Chuong;
                        //Hiển thị các text
                        DataTable dtNVThanhToan = new DataTable();
                        dtNVThanhToan = KgControl.LoadChoComBoboxMaNv();
                        txtNhanVienTinhTien.Properties.DataSource = dtNVThanhToan;
                        txtNhanVienTinhTien.Properties.DisplayMember = "MaNhanVien";
                        //
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        txtComboTT.Text = txtGiaComBo.Text;
                        txtNVThanhToan.Text = txtNhanVienLap.Text;
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Chuồng chưa sử dụng.");
            }
            catch { }
        }
        #endregion
        //Chuồng 10
        #region Chuong10

        private void btn10_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "CHUONG10";
                if ((btn10.Text == "Chuồng 10") && (a == CbMaChuong.Text.Trim()))
                {
                    if (DialogResult.Yes == MessageBox.Show("Đăng ký thông tin ký gởi cho chuồng số 10?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            MessageBox.Show("Thiếu thông tin!");
                            return;
                        }
                        else
                        {
                            //maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,NgayGoi,NgayTra,giaComBo,maNhanVien,tenChuong,giayTo
                            if (KgControl.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                            {
                                KgControl.SuaTrangThai("CHUONG10", "Chuồng 10", "1");
                                ConKyGoi_Load(sender, e);
                                MessageBox.Show("Chuồng 10 đã được khách '" + txtKhachHang.Text.Trim() + "' chọn sử dụng");
                            }
                            else
                                MessageBox.Show("Không thành công. Phiếu ký gởi đã có khách sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("Đã hủy!");
                }
                else
                {
                    if ((btn10.Text == "Chuồng 10 (^_^)"))
                    {
                        HienThiDangKy(true);
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        CbMaChuong.Text = "CHUONG10";
                        lbThongTin.Text = "THÔNG TIN KÝ GỞI CỦA KHÁCH HÀNG";
                        gridView1.FocusedRowHandle = 9;
                    }
                    else
                    {
                        if ((btn10.Text == "Chuồng 10") && (txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            return;
                        }
                        else
                            MessageBox.Show("Đây là " + btn10.Text.Trim() + " không thể đăng ký thông tin cho " + CbMaChuong.Text.Trim() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }

        private void btn10_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if ((btn10.Text == "Chuồng 10 (^_^)"))
                {
                    if (DialogResult.Yes == MessageBox.Show("Thanh toán cho chuồng số 10?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        KgControl.SuaTrangThai("CHUONG10", "Chuồng 10", "0");
                        HienThiKhiThanhToan(true);
                        TangMaTuDongHoaDonThanhToan();
                        CbMaChuong.Text = "CHUONG10";
                        txtTienPhat.Text = "0";
                        txtNgayThanhToan.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại
                        //hiển thị thông tin cho hóa đơn lấy
                        DataTable dtLoand1Chuong = new DataTable();
                        dtLoand1Chuong = KgControl.HIenThiChoHoaDon(txtMaKyGoi.Text.Trim());
                        gridControl1.DataSource = dtLoand1Chuong;
                        //Hiển thị các text
                        DataTable dtNVThanhToan = new DataTable();
                        dtNVThanhToan = KgControl.LoadChoComBoboxMaNv();
                        txtNhanVienTinhTien.Properties.DataSource = dtNVThanhToan;
                        txtNhanVienTinhTien.Properties.DisplayMember = "MaNhanVien";
                        //
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        txtComboTT.Text = txtGiaComBo.Text;
                        txtNVThanhToan.Text = txtNhanVienLap.Text;
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Chuồng chưa sử dụng.");
            }
            catch { }
        }
        #endregion
        //Chuồng 11
        #region Chuong11
        private void btn11_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "CHUONG11";
                if ((btn11.Text == "Chuồng 11") && (a == CbMaChuong.Text.Trim()))
                {
                    if (DialogResult.Yes == MessageBox.Show("Đăng ký thông tin ký gởi cho chuồng số 11?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            MessageBox.Show("Thiếu thông tin!");
                            return;
                        }
                        else
                        {
                            //maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,NgayGoi,NgayTra,giaComBo,maNhanVien,tenChuong,giayTo
                            if (KgControl.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                            {
                                KgControl.SuaTrangThai("CHUONG11", "Chuồng 11", "1");
                                ConKyGoi_Load(sender, e);
                                MessageBox.Show("Chuồng 11 đã được khách '" + txtKhachHang.Text.Trim() + "' chọn sử dụng");
                            }
                            else
                                MessageBox.Show("Không thành công. Phiếu ký gởi đã có khách sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("Đã hủy!");
                }
                else
                {
                    if ((btn11.Text == "Chuồng 11 (^_^)"))
                    {
                        HienThiDangKy(true);
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        CbMaChuong.Text = "CHUONG11";
                        lbThongTin.Text = "THÔNG TIN KÝ GỞI CỦA KHÁCH HÀNG";
                        gridView1.FocusedRowHandle = 10;
                    }
                    else
                    {
                        if ((btn11.Text == "Chuồng 11") && (txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            return;
                        }
                        else
                            MessageBox.Show("Đây là " + btn11.Text.Trim() + " không thể đăng ký thông tin cho " + CbMaChuong.Text.Trim() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }
        private void btn11_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if ((btn11.Text == "Chuồng 11 (^_^)"))
                {
                    if (DialogResult.Yes == MessageBox.Show("Thanh toán cho chuồng số 1?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        KgControl.SuaTrangThai("CHUONG11", "Chuồng 11", "0");
                        HienThiKhiThanhToan(true);
                        TangMaTuDongHoaDonThanhToan();
                        CbMaChuong.Text = "CHUONG11";
                        txtTienPhat.Text = "0";
                        txtNgayThanhToan.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại
                        //hiển thị thông tin cho hóa đơn lấy
                        DataTable dtLoand1Chuong = new DataTable();
                        dtLoand1Chuong = KgControl.HIenThiChoHoaDon(txtMaKyGoi.Text.Trim());
                        gridControl1.DataSource = dtLoand1Chuong;
                        //Hiển thị các text
                        DataTable dtNVThanhToan = new DataTable();
                        dtNVThanhToan = KgControl.LoadChoComBoboxMaNv();
                        txtNhanVienTinhTien.Properties.DataSource = dtNVThanhToan;
                        txtNhanVienTinhTien.Properties.DisplayMember = "MaNhanVien";
                        //
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        txtComboTT.Text = txtGiaComBo.Text;
                        txtNVThanhToan.Text = txtNhanVienLap.Text;
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Chuồng chưa sử dụng.");
            }
            catch { }
        }
        #endregion
        //Chuồng 12
        #region Chuong12
        private void btn12_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "CHUONG12";
                if ((btn12.Text == "Chuồng 12") && (a == CbMaChuong.Text.Trim()))
                {
                    if (DialogResult.Yes == MessageBox.Show("Đăng ký thông tin ký gởi cho chuồng số 12?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            MessageBox.Show("Thiếu thông tin!");
                            return;
                        }
                        else
                        {
                            //maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,NgayGoi,NgayTra,giaComBo,maNhanVien,tenChuong,giayTo
                            if (KgControl.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                            {
                                KgControl.SuaTrangThai("CHUONG12", "Chuồng 12", "1");
                                ConKyGoi_Load(sender, e);
                                MessageBox.Show("Chuồng 12 đã được khách '" + txtKhachHang.Text.Trim() + "' chọn sử dụng");
                            }
                            else
                                MessageBox.Show("Không thành công. Phiếu ký gởi đã có khách sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("Đã hủy!");
                }
                else
                {
                    if ((btn12.Text == "Chuồng 12 (^_^)"))
                    {
                        HienThiDangKy(true);
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        CbMaChuong.Text = "CHUONG12";
                        lbThongTin.Text = "THÔNG TIN KÝ GỞI CỦA KHÁCH HÀNG";
                        gridView1.FocusedRowHandle = 11;
                    }
                    else
                    {
                        if ((btn12.Text == "Chuồng 12") && (txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            return;
                        }
                        else
                            MessageBox.Show("Đây là " + btn12.Text.Trim() + " không thể đăng ký thông tin cho " + CbMaChuong.Text.Trim() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }

        private void btn12_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if ((btn12.Text == "Chuồng 12 (^_^)"))
                {
                    if (DialogResult.Yes == MessageBox.Show("Thanh toán cho chuồng số 1?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        KgControl.SuaTrangThai("CHUONG12", "Chuồng 12", "0");
                        HienThiKhiThanhToan(true);
                        TangMaTuDongHoaDonThanhToan();
                        CbMaChuong.Text = "CHUONG12";
                        txtTienPhat.Text = "0";
                        txtNgayThanhToan.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại
                        //hiển thị thông tin cho hóa đơn lấy
                        DataTable dtLoand1Chuong = new DataTable();
                        dtLoand1Chuong = KgControl.HIenThiChoHoaDon(txtMaKyGoi.Text.Trim());
                        gridControl1.DataSource = dtLoand1Chuong;
                        //Hiển thị các text
                        DataTable dtNVThanhToan = new DataTable();
                        dtNVThanhToan = KgControl.LoadChoComBoboxMaNv();
                        txtNhanVienTinhTien.Properties.DataSource = dtNVThanhToan;
                        txtNhanVienTinhTien.Properties.DisplayMember = "MaNhanVien";
                        //
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        txtComboTT.Text = txtGiaComBo.Text;
                        txtNVThanhToan.Text = txtNhanVienLap.Text;
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Chuồng chưa sử dụng.");
            }
            catch { }
        }
        #endregion
        //Chuồng 13
        #region Chuong13
        private void btn13_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "CHUONG13";
                if ((btn13.Text == "Chuồng 13") && (a == CbMaChuong.Text.Trim()))
                {
                    if (DialogResult.Yes == MessageBox.Show("Đăng ký thông tin ký gởi cho chuồng số 13?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            MessageBox.Show("Thiếu thông tin!");
                            return;
                        }
                        else
                        {
                            //maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,NgayGoi,NgayTra,giaComBo,maNhanVien,tenChuong,giayTo
                            if (KgControl.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                            {
                                KgControl.SuaTrangThai("CHUONG13", "Chuồng 13", "1");
                                ConKyGoi_Load(sender, e);
                                MessageBox.Show("Chuồng 13 đã được khách '" + txtKhachHang.Text.Trim() + "' chọn sử dụng");
                            }
                            else
                                MessageBox.Show("Không thành công. Phiếu ký gởi đã có khách sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("Đã hủy!");
                }
                else
                {
                    if ((btn13.Text == "Chuồng 13 (^_^)"))
                    {
                        HienThiDangKy(true);
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        CbMaChuong.Text = "CHUONG13";
                        lbThongTin.Text = "THÔNG TIN KÝ GỞI CỦA KHÁCH HÀNG";
                        gridView1.FocusedRowHandle = 12;
                    }
                    else
                    {
                        if ((btn13.Text == "Chuồng 13") && (txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            return;
                        }
                        else
                            MessageBox.Show("Đây là " + btn13.Text.Trim() + " không thể đăng ký thông tin cho " + CbMaChuong.Text.Trim() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }

        private void btn13_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if ((btn13.Text == "Chuồng 13 (^_^)"))
                {
                    if (DialogResult.Yes == MessageBox.Show("Thanh toán cho chuồng số 13?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        KgControl.SuaTrangThai("CHUONG13", "Chuồng 13", "0");
                        HienThiKhiThanhToan(true);
                        TangMaTuDongHoaDonThanhToan();
                        CbMaChuong.Text = "CHUONG13";
                        txtTienPhat.Text = "0";
                        txtNgayThanhToan.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại
                        //hiển thị thông tin cho hóa đơn lấy
                        DataTable dtLoand1Chuong = new DataTable();
                        dtLoand1Chuong = KgControl.HIenThiChoHoaDon(txtMaKyGoi.Text.Trim());
                        gridControl1.DataSource = dtLoand1Chuong;
                        //Hiển thị các text
                        DataTable dtNVThanhToan = new DataTable();
                        dtNVThanhToan = KgControl.LoadChoComBoboxMaNv();
                        txtNhanVienTinhTien.Properties.DataSource = dtNVThanhToan;
                        txtNhanVienTinhTien.Properties.DisplayMember = "MaNhanVien";
                        //
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        txtComboTT.Text = txtGiaComBo.Text;
                        txtNVThanhToan.Text = txtNhanVienLap.Text;
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Chuồng chưa sử dụng.");
            }
            catch { }
        }
        #endregion
        //Chuồng 14
        #region Chuong14
        private void btn14_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "CHUONG14";
                if ((btn14.Text == "Chuồng 14") && (a == CbMaChuong.Text.Trim()))
                {
                    if (DialogResult.Yes == MessageBox.Show("Đăng ký thông tin ký gởi cho chuồng số 14?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            MessageBox.Show("Thiếu thông tin!");
                            return;
                        }
                        else
                        {
                            //maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,NgayGoi,NgayTra,giaComBo,maNhanVien,tenChuong,giayTo
                            if (KgControl.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                            {
                                KgControl.SuaTrangThai("CHUONG14", "Chuồng 14", "1");
                                ConKyGoi_Load(sender, e);
                                MessageBox.Show("Chuồng 14 đã được khách '" + txtKhachHang.Text.Trim() + "' chọn sử dụng");
                            }
                            else
                                MessageBox.Show("Không thành công. Phiếu ký gởi đã có khách sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("Đã hủy!");
                }
                else
                {
                    if ((btn14.Text == "Chuồng 14 (^_^)"))
                    {
                        HienThiDangKy(true);
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        CbMaChuong.Text = "CHUONG14";
                        lbThongTin.Text = "THÔNG TIN KÝ GỞI CỦA KHÁCH HÀNG";
                        gridView1.FocusedRowHandle = 13;
                        btnInPhieu.Enabled = true;
                    }
                    else
                    {
                        if ((btn14.Text == "Chuồng 14") && (txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            return;
                        }
                        else
                            MessageBox.Show("Đây là " + btn14.Text.Trim() + " không thể đăng ký thông tin cho " + CbMaChuong.Text.Trim() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }

        private void btn14_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if ((btn14.Text == "Chuồng 14 (^_^)"))
                {
                    if (DialogResult.Yes == MessageBox.Show("Thanh toán cho chuồng số 14?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        KgControl.SuaTrangThai("CHUONG14", "Chuồng 14", "0");
                        HienThiKhiThanhToan(true);
                        TangMaTuDongHoaDonThanhToan();
                        CbMaChuong.Text = "CHUONG14";
                        txtTienPhat.Text = "0";
                        txtNgayThanhToan.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại
                        //hiển thị thông tin cho hóa đơn lấy
                        DataTable dtLoand1Chuong = new DataTable();
                        dtLoand1Chuong = KgControl.HIenThiChoHoaDon(txtMaKyGoi.Text.Trim());
                        gridControl1.DataSource = dtLoand1Chuong;
                        //Hiển thị các text
                        DataTable dtNVThanhToan = new DataTable();
                        dtNVThanhToan = KgControl.LoadChoComBoboxMaNv();
                        txtNhanVienTinhTien.Properties.DataSource = dtNVThanhToan;
                        txtNhanVienTinhTien.Properties.DisplayMember = "MaNhanVien";
                        //
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        txtComboTT.Text = txtGiaComBo.Text;
                        txtNVThanhToan.Text = txtNhanVienLap.Text;
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Chuồng chưa sử dụng.");
            }
            catch { }
        }
        #endregion
        //Chuồng 15
        #region Chuong15

        private void btn15_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "CHUONG15";
                if ((btn15.Text == "Chuồng 15") && (a == CbMaChuong.Text.Trim()))
                {
                    if (DialogResult.Yes == MessageBox.Show("Đăng ký thông tin ký gởi cho chuồng số 15?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            MessageBox.Show("Thiếu thông tin!");
                            return;
                        }
                        else
                        {
                            //maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,NgayGoi,NgayTra,giaComBo,maNhanVien,tenChuong,giayTo
                            if (KgControl.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                            {
                                KgControl.SuaTrangThai("CHUONG15", "Chuồng 15", "1");
                                ConKyGoi_Load(sender, e);
                                MessageBox.Show("Chuồng 15 đã được khách '" + txtKhachHang.Text.Trim() + "' chọn sử dụng");
                            }
                            else
                                MessageBox.Show("Không thành công. Phiếu ký gởi đã có khách sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("Đã hủy!");
                }
                else
                {
                    if ((btn15.Text == "Chuồng 15 (^_^)"))
                    {
                        HienThiDangKy(true);
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        CbMaChuong.Text = "CHUONG15";
                        lbThongTin.Text = "THÔNG TIN KÝ GỞI CỦA KHÁCH HÀNG";
                        gridView1.FocusedRowHandle = 14;
                    }
                    else
                    {
                        if ((btn15.Text == "Chuồng 15") && (txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            return;
                        }
                        else
                            MessageBox.Show("Đây là " + btn15.Text.Trim() + " không thể đăng ký thông tin cho " + CbMaChuong.Text.Trim() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }

        private void btn15_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if ((btn15.Text == "Chuồng 15 (^_^)"))
                {
                    if (DialogResult.Yes == MessageBox.Show("Thanh toán cho chuồng số 1?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        KgControl.SuaTrangThai("CHUONG15", "Chuồng 15", "0");
                        HienThiKhiThanhToan(true);
                        TangMaTuDongHoaDonThanhToan();
                        CbMaChuong.Text = "CHUONG15";
                        txtTienPhat.Text = "0";
                        txtNgayThanhToan.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại
                        //hiển thị thông tin cho hóa đơn lấy
                        DataTable dtLoand1Chuong = new DataTable();
                        dtLoand1Chuong = KgControl.HIenThiChoHoaDon(txtMaKyGoi.Text.Trim());
                        gridControl1.DataSource = dtLoand1Chuong;
                        //Hiển thị các text
                        DataTable dtNVThanhToan = new DataTable();
                        dtNVThanhToan = KgControl.LoadChoComBoboxMaNv();
                        txtNhanVienTinhTien.Properties.DataSource = dtNVThanhToan;
                        txtNhanVienTinhTien.Properties.DisplayMember = "MaNhanVien";
                        //
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        txtComboTT.Text = txtGiaComBo.Text;
                        txtNVThanhToan.Text = txtNhanVienLap.Text;
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Chuồng chưa sử dụng.");
            }
            catch { }
        }
        #endregion
        //Chuồng 16
        #region Chuong16
        private void btn16_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "CHUONG16";
                if ((btn16.Text == "Chuồng 16") && (a == CbMaChuong.Text.Trim()))
                {
                    if (DialogResult.Yes == MessageBox.Show("Đăng ký thông tin ký gởi cho chuồng số 16?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            MessageBox.Show("Thiếu thông tin!");
                            return;
                        }
                        else
                        {
                            //maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,NgayGoi,NgayTra,giaComBo,maNhanVien,tenChuong,giayTo
                            if (KgControl.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                            {
                                KgControl.SuaTrangThai("CHUONG16", "Chuồng 16", "1");
                                ConKyGoi_Load(sender, e);
                                MessageBox.Show("Chuồng 16 đã được khách '" + txtKhachHang.Text.Trim() + "' chọn sử dụng");
                            }
                            else
                                MessageBox.Show("Không thành công. Phiếu ký gởi đã có khách sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("Đã hủy!");
                }
                else
                {
                    if ((btn16.Text == "Chuồng 16 (^_^)"))
                    {
                        HienThiDangKy(true);
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        CbMaChuong.Text = "CHUONG16";
                        lbThongTin.Text = "THÔNG TIN KÝ GỞI CỦA KHÁCH HÀNG";
                        gridView1.FocusedRowHandle = 15;
                    }
                    else
                    {
                        if ((btn16.Text == "Chuồng 16") && (txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            return;
                        }
                        else
                            MessageBox.Show("Đây là " + btn16.Text.Trim() + " không thể đăng ký thông tin cho " + CbMaChuong.Text.Trim() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }

        private void btn16_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if ((btn16.Text == "Chuồng 16 (^_^)"))
                {
                    if (DialogResult.Yes == MessageBox.Show("Thanh toán cho chuồng số 16?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        KgControl.SuaTrangThai("CHUONG16", "Chuồng 16", "0");
                        HienThiKhiThanhToan(true);
                        TangMaTuDongHoaDonThanhToan();
                        CbMaChuong.Text = "CHUONG16";
                        txtTienPhat.Text = "0";
                        txtNgayThanhToan.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại
                        //hiển thị thông tin cho hóa đơn lấy
                        DataTable dtLoand1Chuong = new DataTable();
                        dtLoand1Chuong = KgControl.HIenThiChoHoaDon(txtMaKyGoi.Text.Trim());
                        gridControl1.DataSource = dtLoand1Chuong;
                        //Hiển thị các text
                        DataTable dtNVThanhToan = new DataTable();
                        dtNVThanhToan = KgControl.LoadChoComBoboxMaNv();
                        txtNhanVienTinhTien.Properties.DataSource = dtNVThanhToan;
                        txtNhanVienTinhTien.Properties.DisplayMember = "MaNhanVien";
                        //
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        txtComboTT.Text = txtGiaComBo.Text;
                        txtNVThanhToan.Text = txtNhanVienLap.Text;
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Chuồng chưa sử dụng.");
            }
            catch { }
        }
        #endregion
        //Chuồng 17
        #region Chuong17
        private void btn17_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "CHUONG17";
                if ((btn17.Text == "Chuồng 17") && (a == CbMaChuong.Text.Trim()))
                {
                    if (DialogResult.Yes == MessageBox.Show("Đăng ký thông tin ký gởi cho chuồng số 17?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            MessageBox.Show("Thiếu thông tin!");
                            return;
                        }
                        else
                        {
                            //maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,NgayGoi,NgayTra,giaComBo,maNhanVien,tenChuong,giayTo
                            if (KgControl.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                            {
                                KgControl.SuaTrangThai("CHUONG17", "Chuồng 17", "1");
                                ConKyGoi_Load(sender, e);
                                MessageBox.Show("Chuồng 17 đã được khách '" + txtKhachHang.Text.Trim() + "' chọn sử dụng");
                            }
                            else
                                MessageBox.Show("Không thành công. Phiếu ký gởi đã có khách sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("Đã hủy!");
                }
                else
                {
                    if ((btn17.Text == "Chuồng 17 (^_^)"))
                    {
                        HienThiDangKy(true);
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        CbMaChuong.Text = "CHUONG17";
                        lbThongTin.Text = "THÔNG TIN KÝ GỞI CỦA KHÁCH HÀNG";
                        gridView1.FocusedRowHandle = 16;
                    }
                    else
                    {
                        if ((btn17.Text == "Chuồng 17") && (txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            return;
                        }
                        else
                            MessageBox.Show("Đây là " + btn17.Text.Trim() + " không thể đăng ký thông tin cho " + CbMaChuong.Text.Trim() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }

        private void btn17_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if ((btn17.Text == "Chuồng 17 (^_^)"))
                {
                    if (DialogResult.Yes == MessageBox.Show("Thanh toán cho chuồng số 17?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        KgControl.SuaTrangThai("CHUONG17", "Chuồng 17", "0");
                        HienThiKhiThanhToan(true);
                        TangMaTuDongHoaDonThanhToan();
                        CbMaChuong.Text = "CHUONG17";
                        txtTienPhat.Text = "0";
                        txtNgayThanhToan.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại
                        //hiển thị thông tin cho hóa đơn lấy
                        DataTable dtLoand1Chuong = new DataTable();
                        dtLoand1Chuong = KgControl.HIenThiChoHoaDon(txtMaKyGoi.Text.Trim());
                        gridControl1.DataSource = dtLoand1Chuong;
                        //Hiển thị các text
                        DataTable dtNVThanhToan = new DataTable();
                        dtNVThanhToan = KgControl.LoadChoComBoboxMaNv();
                        txtNhanVienTinhTien.Properties.DataSource = dtNVThanhToan;
                        txtNhanVienTinhTien.Properties.DisplayMember = "MaNhanVien";
                        //
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        txtComboTT.Text = txtGiaComBo.Text;
                        txtNVThanhToan.Text = txtNhanVienLap.Text;
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Chuồng chưa sử dụng.");
            }
            catch { }
        }
        #endregion
        //Chuồng 18
        #region Chuong18
        private void btn18_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "CHUONG18";
                if ((btn2.Text == "Chuồng 18") && (a == CbMaChuong.Text.Trim()))
                {
                    if (DialogResult.Yes == MessageBox.Show("Đăng ký thông tin ký gởi cho chuồng số 18?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            MessageBox.Show("Thiếu thông tin!");
                            return;
                        }
                        else
                        {
                            //maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,NgayGoi,NgayTra,giaComBo,maNhanVien,tenChuong,giayTo
                            if (KgControl.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                            {
                                KgControl.SuaTrangThai("CHUONG18", "Chuồng 18", "1");
                                ConKyGoi_Load(sender, e);
                                MessageBox.Show("Chuồng 18 đã được khách '" + txtKhachHang.Text.Trim() + "' chọn sử dụng");
                            }
                            else
                                MessageBox.Show("Không thành công. Phiếu ký gởi đã có khách sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("Đã hủy!");
                }
                else
                {
                    if ((btn18.Text == "Chuồng 18 (^_^)"))
                    {
                        HienThiDangKy(true);
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        CbMaChuong.Text = "CHUONG18";
                        lbThongTin.Text = "THÔNG TIN KÝ GỞI CỦA KHÁCH HÀNG";
                        gridView1.FocusedRowHandle = 17;
                    }
                    else
                    {
                        if ((btn18.Text == "Chuồng 18") && (txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            return;
                        }
                        else
                            MessageBox.Show("Đây là " + btn18.Text.Trim() + " không thể đăng ký thông tin cho " + CbMaChuong.Text.Trim() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }

        private void btn18_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if ((btn18.Text == "Chuồng 18 (^_^)"))
                {
                    if (DialogResult.Yes == MessageBox.Show("Thanh toán cho chuồng số 1?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        KgControl.SuaTrangThai("CHUONG18", "Chuồng 01", "0");
                        HienThiKhiThanhToan(true);
                        TangMaTuDongHoaDonThanhToan();
                        CbMaChuong.Text = "CHUONG18";
                        txtTienPhat.Text = "0";
                        txtNgayThanhToan.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại
                        //hiển thị thông tin cho hóa đơn lấy
                        DataTable dtLoand1Chuong = new DataTable();
                        dtLoand1Chuong = KgControl.HIenThiChoHoaDon(txtMaKyGoi.Text.Trim());
                        gridControl1.DataSource = dtLoand1Chuong;
                        //Hiển thị các text
                        DataTable dtNVThanhToan = new DataTable();
                        dtNVThanhToan = KgControl.LoadChoComBoboxMaNv();
                        txtNhanVienTinhTien.Properties.DataSource = dtNVThanhToan;
                        txtNhanVienTinhTien.Properties.DisplayMember = "MaNhanVien";
                        //
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        txtComboTT.Text = txtGiaComBo.Text;
                        txtNVThanhToan.Text = txtNhanVienLap.Text;
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Chuồng chưa sử dụng.");
            }
            catch { }
        }
        #endregion
        //Chuồng 19
        #region Chuong19
        private void btn19_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "CHUONG19";
                if ((btn19.Text == "Chuồng 19") && (a == CbMaChuong.Text.Trim()))
                {
                    if (DialogResult.Yes == MessageBox.Show("Đăng ký thông tin ký gởi cho chuồng số 19?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            MessageBox.Show("Thiếu thông tin!");
                            return;
                        }
                        else
                        {
                            //maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,NgayGoi,NgayTra,giaComBo,maNhanVien,tenChuong,giayTo
                            if (KgControl.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                            {
                                KgControl.SuaTrangThai("CHUONG19", "Chuồng 19", "1");
                                ConKyGoi_Load(sender, e);
                                MessageBox.Show("Chuồng 19 đã được khách '" + txtKhachHang.Text.Trim() + "' chọn sử dụng");
                            }
                            else
                                MessageBox.Show("Không thành công. Phiếu ký gởi đã có khách sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("Đã hủy!");
                }
                else
                {
                    if ((btn19.Text == "Chuồng 19(^_^)"))
                    {
                        HienThiDangKy(true);
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        CbMaChuong.Text = "CHUONG19";
                        lbThongTin.Text = "THÔNG TIN KÝ GỞI CỦA KHÁCH HÀNG";
                        gridView1.FocusedRowHandle = 18;
                    }
                    else
                    {
                        if ((btn19.Text == "Chuồng 19") && (txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            return;
                        }
                        else
                            MessageBox.Show("Đây là " + btn19.Text.Trim() + " không thể đăng ký thông tin cho " + CbMaChuong.Text.Trim() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }

        private void btn19_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if ((btn19.Text == "Chuồng 19 (^_^)"))
                {
                    if (DialogResult.Yes == MessageBox.Show("Thanh toán cho chuồng số 19?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        KgControl.SuaTrangThai("CHUONG19", "Chuồng 19", "0");
                        HienThiKhiThanhToan(true);
                        TangMaTuDongHoaDonThanhToan();
                        CbMaChuong.Text = "CHUONG19";
                        txtTienPhat.Text = "0";
                        txtNgayThanhToan.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại
                        //hiển thị thông tin cho hóa đơn lấy
                        DataTable dtLoand1Chuong = new DataTable();
                        dtLoand1Chuong = KgControl.HIenThiChoHoaDon(txtMaKyGoi.Text.Trim());
                        gridControl1.DataSource = dtLoand1Chuong;
                        //Hiển thị các text
                        DataTable dtNVThanhToan = new DataTable();
                        dtNVThanhToan = KgControl.LoadChoComBoboxMaNv();
                        txtNhanVienTinhTien.Properties.DataSource = dtNVThanhToan;
                        txtNhanVienTinhTien.Properties.DisplayMember = "MaNhanVien";
                        //
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        txtComboTT.Text = txtGiaComBo.Text;
                        txtNVThanhToan.Text = txtNhanVienLap.Text;
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Chuồng chưa sử dụng.");
            }
            catch { }
        }
        #endregion
        //Chuồng 20
        #region Chuong20

        private void btn20_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "CHUONG20";
                if ((btn20.Text == "Chuồng 20") && (a == CbMaChuong.Text.Trim()))
                {
                    if (DialogResult.Yes == MessageBox.Show("Đăng ký thông tin ký gởi cho chuồng số 20?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        if ((txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            MessageBox.Show("Thiếu thông tin!");
                            return;
                        }
                        else
                        {
                            //maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,NgayGoi,NgayTra,giaComBo,maNhanVien,tenChuong,giayTo
                            if (KgControl.ThemDuLieuKyGoi(txtMaKyGoi.Text.Trim(), txtKhachHang.Text.Trim(), txtLienHe.Text.Trim(), txtChungMinh.Text.Trim(), txtTenCun.Text.Trim(), txtSoLuong.Text.Trim(), txtNgayDen.Text.Trim(), txtNgayVe.Text.Trim(), txtGiaComBo.Text.Trim(), txtNhanVienLap.Text.Trim(), CbMaChuong.Text.Trim(), txtGiayTo.Text.Trim()))
                            {
                                KgControl.SuaTrangThai("CHUONG20", "Chuồng 20", "1");
                                ConKyGoi_Load(sender, e);
                                MessageBox.Show("Chuồng 20 đã được khách '" + txtKhachHang.Text.Trim() + "' chọn sử dụng");
                            }
                            else
                                MessageBox.Show("Không thành công. Phiếu ký gởi đã có khách sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("Đã hủy!");
                }
                else
                {
                    if ((btn20.Text == "Chuồng 20 (^_^)"))
                    {
                        HienThiDangKy(true);
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        CbMaChuong.Text = "CHUONG20";
                        lbThongTin.Text = "THÔNG TIN KÝ GỞI CỦA KHÁCH HÀNG";
                        gridView1.FocusedRowHandle = 19;
                    }
                    else
                    {
                        if ((btn20.Text == "Chuồng 20") && (txtNgayDen.Text.Trim() == "") || (txtNgayVe.Text.Trim() == "") || (txtKhachHang.Text.Trim() == "") || (txtChungMinh.Text.Trim() == "") || (txtNhanVienLap.Text.Trim() == "") || (txtGiaComBo.Text.Trim() == "") || (txtTenCun.Text.Trim() == "") || (txtGiayTo.Text.Trim() == "") || (txtSoLuong.Text.Trim() == "") || (txtMaKyGoi.Text.Trim() == "") || (txtLienHe.Text.Trim() == ""))
                        {
                            return;
                        }
                        else
                            MessageBox.Show("Đây là " + btn20.Text.Trim() + " không thể đăng ký thông tin cho " + CbMaChuong.Text.Trim() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void btn20_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if ((btn20.Text == "Chuồng 20 (^_^)"))
                {
                    if (DialogResult.Yes == MessageBox.Show("Thanh toán cho chuồng số 20?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        KgControl.SuaTrangThai("CHUONG20", "Chuồng 20", "0");
                        HienThiKhiThanhToan(true);
                        TangMaTuDongHoaDonThanhToan();
                        CbMaChuong.Text = "CHUONG20";
                        txtTienPhat.Text = "0";
                        txtNgayThanhToan.Text = DateTime.Today.ToString().Split(' ')[0];//thêm ngày hiện tại
                        //hiển thị thông tin cho hóa đơn lấy
                        DataTable dtLoand1Chuong = new DataTable();
                        dtLoand1Chuong = KgControl.HIenThiChoHoaDon(txtMaKyGoi.Text.Trim());
                        gridControl1.DataSource = dtLoand1Chuong;
                        //Hiển thị các text
                        DataTable dtNVThanhToan = new DataTable();
                        dtNVThanhToan = KgControl.LoadChoComBoboxMaNv();
                        txtNhanVienTinhTien.Properties.DataSource = dtNVThanhToan;
                        txtNhanVienTinhTien.Properties.DisplayMember = "MaNhanVien";
                        //
                        btnChonChuong.Enabled = btnSua.Enabled = false;
                        txtComboTT.Text = txtGiaComBo.Text;
                        txtNVThanhToan.Text = txtNhanVienLap.Text;
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Chuồng chưa sử dụng.");
            }
            catch { }
        }
        #endregion

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            XtraReport rp = new XtraReport();
            rp.DataSource = KgControl.HoaDonKGoi(txtMaHoaDon.Text.Trim());
            rp.LoadLayout(Application.StartupPath + @"\HoaDonKyGoi.repx");
            rp.ShowPreviewDialog();
            ConKyGoi_Load(sender, e);
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            XtraReport rp = new XtraReport();
            rp.DataSource = KgControl.HienThiThongTinIn(txtMaKyGoi.Text.Trim());
            rp.LoadLayout(Application.StartupPath + @"\ThongTinKyGoi.repx");
            //rp.ShowDesignerDialog();
            rp.ShowPreviewDialog();
        }


    }
}