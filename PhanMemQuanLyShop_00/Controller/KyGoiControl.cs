using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PhanMemQuanLyShop_00.Model;

namespace PhanMemQuanLyShop_00.Controller
{
    class KyGoiControl
    {
        KyGoiMod KgMod = new KyGoiMod();
        public DataTable laycottrangthai()
        {
            return KgMod.CotTrangThai();
        }
        public DataTable LoadDulieuChoGrid()
        {
            return KgMod.LoadChoGridKyGoi();
        }
        public bool SuaTrangThai(string maChuong,string tenChuong,string trangThai)
        {
            return KgMod.SuaTrangThai(maChuong,tenChuong,trangThai);
        }
        //thêm thông tin mới
        public bool ThemDuLieuKyGoi(string maThongTinKyGui, string tenChu, string lienHe, string cMND, string tenThuCung, string soLuong, string ngayGoi, string ngayTra, string giaComBo, string maNhanVien, string tenChuong, string giayTo)
        {
            return KgMod.ThemTTKyGoi(maThongTinKyGui,tenChu,lienHe,cMND,tenThuCung,soLuong,ngayGoi,ngayTra,giaComBo,maNhanVien,tenChuong,giayTo);
        }
        //thêm 1 hóa đơn mới
        public bool ThemMoiHoaDon(string maThanhToan, string thanhTien, string maNhanVien, string tienPhat, string giaCombo, string ngayLap, string maChuong, string maThongTinKyGoi, string maNVThanhToan)
        {
            return KgMod.ThemHoaDonKyGoi(maThanhToan, thanhTien, maNhanVien, tienPhat, giaCombo, ngayLap, maChuong, maThongTinKyGoi, maNVThanhToan);
        }
        public DataTable LoadChoComBoboxMaChuong(string trangThai)
        {
            return KgMod.Load_CbMaChuong(trangThai);
        }
        //lấy mã nhân viên
        public DataTable LoadChoComBoboxMaNv()
        {
            return KgMod.Load_CbMaNv();
        }
        //sửa thông tin ký gởi
        public bool SuaThongTinKyGoi(string maThongTinKyGui, string tenChu, string lienHe, string cMND, string tenThuCung, string soLuong, string ngayGoi, string ngayTra, string giaComBo, string maNhanVien, string tenChuong, string giayTo)
        {
            return KgMod.SuaTTKyGoi(maThongTinKyGui, tenChu, lienHe, cMND, tenThuCung, soLuong, ngayGoi, ngayTra, giaComBo, maNhanVien, tenChuong, giayTo);
        }
        //load cho 1 mã chuồng
        public DataTable LoadCho1Chuong(string maChuong)
        {
            return KgMod.HienThiThongTinCho1Chuong(maChuong);
        }
        //load cho hóa đơn tăng mã
        public DataTable LoadChoTangMaHoaDon()
        {
            return KgMod.MaHoaDonKyGoi();
        }
        //Xóa thông tin ký gởi
        public bool XoaThongTinKyGoi(string maThongTinKyGoi)
        {
            return KgMod.XoaTTKyGoi(maThongTinKyGoi);
        }
        //hiển thị cho grid hóa đơn lấy thông tin
        public DataTable HIenThiChoHoaDon(string maThongTin)
        {
            return KgMod.HienGridThiChoHoaDon(maThongTin);
        }
        //HIỂN THỊ THÔNG TIN CHO CÁC TEXT KHI BẤM CHUỒNG CÓ THỨ CƯNG
        public DataTable LoadChoCacText(string trangThai)
        {
            return KgMod.LoadTT1ChuongDangDung(trangThai);
        }
        public string LayThongTinMaKG(string maChuong)
        {
            return KgMod.LayMaKyGoi(maChuong);
        }
        //HIỂN THỊ THÔNG TIN CHO HÓA ĐƠN KÝ GỞI
        public DataTable HoaDonKGoi(string maHD)
        {
            return KgMod.HoaDonKyGoi(maHD);
        }
        public DataTable HoDonKyGoiFull()
        {
            return KgMod.HoaDonKyGoiFull();
        }
        //Hien thi in thong tin phieu cho khach
        public DataTable HienThiThongTinIn(string maThongTin)
        {
            return KgMod.LoadThongTinIn(maThongTin);
        }
    }
}
