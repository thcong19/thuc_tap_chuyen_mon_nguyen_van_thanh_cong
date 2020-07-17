using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using PhanMemQuanLyShop_00.Model;

namespace PhanMemQuanLyShop_00.Controller
{
    class ChamCongControl
    {
        ChamCongMod CCongMod = new ChamCongMod();
        public DataTable HienThiTenNhanVien()
        {
            return CCongMod.LayTenNhanVien();
        }
        public string HienThiMaNhanVien(string ten)
        {
            return CCongMod.LayMaNhanVien(ten);
        }
        public DataTable HienThiThongTin()
        {
            return CCongMod.HienThiThongTin();
        }
        public bool ThemLuongMoi(string maChamCong, string maNhaVien, string tenNhanVien, string thang, string nam, string tangCa, string nghiLam, string luongCung, string luongNhan,string tienThuong,string tienPhat)
        {
            return CCongMod.ThemLuongMoi( maChamCong, maNhaVien, tenNhanVien, thang, nam, tangCa, nghiLam, luongCung, luongNhan,tienThuong,tienPhat);
        }
        public bool SuaLuong(string maChamCong, string maNhaVien, string tenNhanVien, string thang, string nam, string tangCa, string nghiLam, string luongCung, string luongNhan, string tienThuong, string tienPhat)
        {
            return CCongMod.SuaLuong(maChamCong, maNhaVien, tenNhanVien, thang, nam, tangCa, nghiLam, luongCung, luongNhan,tienThuong,tienPhat);
        }
        public bool XoaLuong(string maLuong)
        {
           return CCongMod.XoaLuong(maLuong);
        }
        public DataTable HienThiLuong(string thang,string nam)
        {
            return CCongMod.XemLuong(thang,nam);
        }
    }
}
