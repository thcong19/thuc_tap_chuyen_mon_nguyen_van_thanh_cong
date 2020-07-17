using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyShop_00.Model;
using System.Data;

namespace PhanMemQuanLyShop_00.Controller
{
    class NhaCungCapControl
    {
        NhaCungCapMod NhaccMod = new NhaCungCapMod();
        public DataTable HienThiDuLieu()
        {
            return NhaccMod.HienThiDuLieu();
        }
        //Thêm mới 1 nhà cung cấp
        public bool ThemDuLieu(string maNhaCungCap, string tenNhaCungCap, string diaChi, string lienHe, string soTaiKhoan)
        {
            return NhaccMod.ThemNhaCungCap(maNhaCungCap,tenNhaCungCap,diaChi,lienHe,soTaiKhoan);
        }
        //Sửa đổi thông tin 1 nhà cung cấp
        public bool SuaDuLieu(string maNhaCungCap, string tenNhaCungCap, string diaChi, string lienHe, string soTaiKhoan)
        {
            return NhaccMod.SuaNhaCungCap(maNhaCungCap, tenNhaCungCap, diaChi, lienHe, soTaiKhoan);
        }
        //Xóa bỏ 1 nhà cung cấp
        public bool XoaDuLieu(string maNhaCungCap)
        {
            return NhaccMod.XoaNhaCungCap(maNhaCungCap);
        }
    }
}
