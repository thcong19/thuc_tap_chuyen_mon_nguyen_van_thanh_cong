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
    class HoaDonControl
    {
        HoaDonMod HDmod = new HoaDonMod();
        public DataTable HienThiDuLieu()
        {
            return HDmod.HienThiThongTinHoaDon();
        }
        public DataTable HienThiDuLieuHoaDon(string maBanHang)
        {
            return HDmod.HienThiHoaDon(maBanHang);
        }
        public bool ThemHoaDonMoi(string maChiTietHoaDon, string maBanHang, string maHang, string soLuong, string giaBan, string thanhTien, string tenHang)
        {
            return HDmod.ThemHoaDon(maChiTietHoaDon, maBanHang, maHang, soLuong, giaBan, thanhTien, tenHang);
        }
        public bool SuaHoaDon(string maChiTietHoaDon, string maBanHang, string maHang, string soLuong, string giaBan, string thanhTien, string tenHang)
        {
            return HDmod.SuaHoaDon(maChiTietHoaDon, maBanHang, maHang, soLuong, giaBan, thanhTien, tenHang);
        }
        public bool XoaHoaDon(string maChiTietHoaDon)
        {
            return HDmod.XoaHoaDon(maChiTietHoaDon);
        }
    }
}
