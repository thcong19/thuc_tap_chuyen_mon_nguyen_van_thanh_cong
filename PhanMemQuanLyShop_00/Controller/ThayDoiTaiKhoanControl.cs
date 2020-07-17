using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PhanMemQuanLyShop_00.Model;

namespace PhanMemQuanLyShop_00.Controller
{
    class ThayDoiTaiKhoanControl
    {
        ThayDoiTaiKhoanMod ThayDoiTkMod = new ThayDoiTaiKhoanMod();
        public DataTable HienThiDuLieu()
        {
            return ThayDoiTkMod.HienThiDuLieu();
        }
        public bool ThemDuLieu(string tenTK, string matKhau, string loaiTk)
        {
            return ThayDoiTkMod.ThemTaiKhoan(tenTK, matKhau, loaiTk);
        }
        //Sửa dữ liệu cho tài khoản
        public bool SuaDuLieu(string tenTK, string matKhau, string loaiTk)
        {
            return ThayDoiTkMod.SuaTaiKhoan(tenTK, matKhau, loaiTk);
        }
        //Xóa 1 tài khoản
        public bool XoaTaiKhoan(string tenTK)
        {
            return ThayDoiTkMod.XoaTaiKhoan(tenTK);
        }
    }
}
