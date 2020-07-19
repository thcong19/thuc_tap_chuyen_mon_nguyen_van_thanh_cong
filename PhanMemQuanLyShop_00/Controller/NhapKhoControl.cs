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
    class NhapKhoControl
    {
        NhapKhoMod NhapMod = new NhapKhoMod();
        //Thực hiện hiển trị các bảng dữ liệu lên gidcontrol
        public DataTable HienThiDuLieu1()
        {
            return NhapMod.HienThiDuLieu1();
        }
        public DataTable HienThiDuLieu2()
        {
            return NhapMod.HienThiDuLieu2();
        }
        public DataTable HienThiDuLieu3()
        {
            return NhapMod.HienThiDuLieu3();
        }

        //Hiển thị cho lookedit mã nhập
        public DataTable HienThiLoockEditMaNhap()
        {
            return NhapMod.HienThiLookeditMaNhap();
        }
        //Hiển thị cho lookedit mã nhà cung cấp
        public DataTable HienThiLoockEditMaNhaCungCap()
        {
            return NhapMod.HienThiLookeditMaNhaCungCap();
        }
        //Hiển thị cho lookedit mã nhà cung cấp
        public DataTable HienThiLoockEditMaChiTietNhap()
        {
            return NhapMod.HienThiLookeditMaChiTietNhap();
        }

        //Thao tác thêm xóa sửa cho phiếu nhập
        public bool ThemDuLieu1(string maNhap, string maNhaCungCap, string ngayNhap)
        {
            return NhapMod.ThemPhieuNhap(maNhap, maNhaCungCap, ngayNhap);
        }
        public bool SuaDuLieu1(string maNhap, string maNhaCungCap, string ngayNhap)
        {
            return NhapMod.SuaPhieuNhap(maNhap, maNhaCungCap, ngayNhap);
        }
        public bool XoaDuLieu1(string maNhap)
        {
            return NhapMod.XoaPhieuNhap(maNhap);
        }
        //Thao tác thêm xóa sửa cho chi tiết phiếu nhập
        public bool ThemDuLieu2(string maChiTietNhap,string goiHang ,string maNhap, string soLuong, string giaNhap)
        {
            return NhapMod.ThemChiTietPhieuNhap(maChiTietNhap, goiHang, maNhap, soLuong, giaNhap);
        }
        public bool SuaDuLieu2(string maChiTietNhap,string goiHang, string maNhap, string soLuong, string giaNhap)
        {
            return NhapMod.SuaChiTietPhieuNhap(maChiTietNhap,goiHang, maNhap, soLuong, giaNhap);
        }
        public bool XoaDuLieu2(string maChiTietNhap)
        {
            return NhapMod.XoaChiTietPhieuNhap(maChiTietNhap);
        }
        //Thao tác thêm xóa sửa cho chi tiết hàng hóa
        public bool ThemDuLieu3(string maHang, string tenHang, string donVi, string loaiHang, string maChitiet,string giaban,string soLuong)
        {
            return NhapMod.ThemThongTinHang(maHang, tenHang, donVi, loaiHang, maChitiet,giaban,soLuong);
        }
        public bool SuaDuLieu3(string maHang, string tenHang, string donVi, string loaiHang, string maChitiet, string giaban, string soLuong)
        {
            return NhapMod.SuaThongTinHang(maHang, tenHang, donVi, loaiHang, maChitiet,giaban,soLuong);
        }
        public bool XoaDuLieu3(string maHang)
        {
            return NhapMod.XoaThongTinHang(maHang);
        }

    }
}
