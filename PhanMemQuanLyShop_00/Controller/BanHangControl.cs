using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using PhanMemQuanLyShop_00.Model;

namespace PhanMemQuanLyShop_00.Controller
{
    class BanHangControl
    {
        BanHangMod BanHangMod = new BanHangMod();
        public DataTable HienThiThongTinHang()
        {
            return BanHangMod.HienThiThongTinHang();
        }
        public DataTable HienThiThongTinTimKiem(string tenHang)
        {
            return BanHangMod.HienThiTimKiem(tenHang);
        }
        //Combobox mã khách hàng
        public DataTable HienThiDuLieuComBoBox()
        {
            return BanHangMod.Load_Cb();
        }
        //Các text thông tin khách hàng
        public string HienThiTenKhach(string tenKhach)
        {
            return BanHangMod.LayTenKhach(tenKhach);
        }
        public string HienThiThongTinLienHe(string tenKhach)
        {
            return BanHangMod.LayThongTinLienHe(tenKhach);
        }
        public string HienThiThongTinThe(string tenKhach)
        {
            return BanHangMod.LayThongTinThe(tenKhach);
        }
        //Combobox mã nhân viên
        public DataTable HienThiDuLieuComboBoxNV()
        {
            return BanHangMod.Load_CbNhanVien();
        }
        //Các text thông tin nhân viên
        public string HienThiTenNhanVien(string maNV)
        {
            return BanHangMod.LayTenNhanVien(maNV);
        }
        //----------------------------------------------
        public DataTable HienThiDuLieuHoaDon(string maBanHang)
        {
            return BanHangMod.HienThiHoaDon(maBanHang);
        }
        public DataTable HienThiDuLieuPhieuMuaHang(string maKhach)
        {
            return BanHangMod.HienThiPhieuMuaHang(maKhach);
        }
        //Thêm phiếu mua hàng mới
        public bool ThemPhieuMuaHang(string maPhieuHang, string ngayBan, string maKhachHang, string maNhanVien)
        {
            return BanHangMod.ThemPhieuMuaHang(maPhieuHang,ngayBan,maKhachHang,maNhanVien);
        }
        //Thêm hàng vào giỏ hàng
        public bool ThemPhieuMuaHang(string maChiTietHoaDon, string maBanHang, string maHang, string soLuong, string giaBan, string thanhTien,string tenHang)
        {
            return BanHangMod.ThemHoaDon(maChiTietHoaDon, maBanHang, maHang, soLuong,giaBan,thanhTien,tenHang);
        }
        public bool ThemSuaPhieuMuaHang(string maChiTietHoaDon, string maBanHang, string maHang, string soLuong, string giaBan, string thanhTien, string tenHang)
        {
            return BanHangMod.SuaHoaDon(maChiTietHoaDon, maBanHang, maHang, soLuong, giaBan, thanhTien, tenHang);
        }
        public DataTable HienThiFullHoaDon()
        {
            return BanHangMod.HienThiHoaDonFull();
        }
        public DataTable HienThiFullPhieuHang()
        {
            return BanHangMod.HienThiPhieuMuaHangFull();
        }
        //sửa lại số lượng hàng hóa
        public bool SuaSoluongHang(string maHang, string tenHang, string donVi, string loaiHang, string maChiTietNhap, string giaBan, string soLuongHang)
        {
            return BanHangMod.SuaSoLuongHangHoa(maHang, tenHang,donVi, loaiHang, maChiTietNhap, giaBan, soLuongHang);
        }
        public bool TraLaiHangHoa(string maChiTietHoaDon)
        {
            return BanHangMod.TraHangHoa(maChiTietHoaDon);
        }
    }
}
