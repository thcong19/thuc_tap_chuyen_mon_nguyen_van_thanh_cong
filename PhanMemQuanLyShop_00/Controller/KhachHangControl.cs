using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PhanMemQuanLyShop_00.Model;

namespace PhanMemQuanLyShop_00.Controller
{
    class KhachHangControl
    {
        KhachHangMod KhMod = new KhachHangMod();
        public DataTable HienThiDuLieu()
        {
            return KhMod.HienThiDuLieu();
        }
        public bool ThemDuLieu(string maKhachHang, string LienHe, string TenDonVi, string TheThanhVien)
        {
            return KhMod.ThemKhachHang(maKhachHang, LienHe, TenDonVi, TheThanhVien);
        }
        public bool SuaDuLieu(string maKhachHang, string LienHe, string TenDonVi, string TheThanhVien)
        {
            return KhMod.SuaKhachHang(maKhachHang, LienHe, TenDonVi, TheThanhVien);
        }
        public bool XoaDuLieu(string maKhachHang)
        {
            return KhMod.XoaKhachHang(maKhachHang);
        }
        //Thẻ ưu đãi
        public DataTable HienThiDuLieuKH(string loaiThe)
        {
            return KhMod.HienThiKhachUuDai(loaiThe);
        }
    }
}
