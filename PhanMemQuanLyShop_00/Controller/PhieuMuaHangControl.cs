using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PhanMemQuanLyShop_00.Model;

namespace PhanMemQuanLyShop_00.Controller
{
    class PhieuMuaHangControl
    {
        PhieuMuaHangMod PhieuMhMod = new PhieuMuaHangMod();
        public DataTable HienThiDuLieu()
        {
        return PhieuMhMod.HienThiPhieuMuaHang();
        }
        public DataTable HienThiMaKhach()
        {
        return PhieuMhMod.HienThiLookeditMaKhach();
        }
        public DataTable HienThiMaNhanVien()
        {
        return PhieuMhMod.HienThiLookeditMaNhanVien();
        }
        //
        public bool ThemDuLieu(string maPhieuHang, string ngayBan, string maKhachHang, string maNhanVien)
        {
            return PhieuMhMod.ThemPhieuMuaHang(maPhieuHang,ngayBan,maKhachHang,maNhanVien);
        }
        public bool SuaDuLieu(string maPhieuHang, string ngayBan, string maKhachHang, string maNhanVien)
        {
            return PhieuMhMod.SuaPhieuMuaHang(maKhachHang, ngayBan, maKhachHang, maNhanVien);
        }
        public bool XoaDuLieu(string maPhieuHang)
        {
            return PhieuMhMod.XoaNhaCungCap(maPhieuHang);
        }
    }
}
