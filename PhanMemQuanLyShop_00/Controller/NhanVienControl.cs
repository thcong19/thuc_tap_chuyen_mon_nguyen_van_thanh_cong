using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using PhanMemQuanLyShop_00.Model;

namespace PhanMemQuanLyShop_00.Controller
{
    class NhanVienControl
    {
        NhanVienMod NVmod = new NhanVienMod();
        public DataTable HienThiDuLieu()
        {
            return NVmod.HienThiDuLieu();
        }
        public bool ThemDuLieu(string maNhanVien, string hoTen, string CMND, string diaChi, string soDienThoai)
        {
            return NVmod.ThemNhanVien(maNhanVien, hoTen, CMND, diaChi, soDienThoai);
        }
        public bool SuaDuLieu(string maNhanVien, string hoTen, string CMND, string diaChi, string soDienThoai)
        {
            return NVmod.SuaNhanVien(maNhanVien, hoTen, CMND, diaChi, soDienThoai);
        }
        public bool XoaDuLieu(string maNhanVien)
        {
            return NVmod.XoaNhanVien(maNhanVien);
        }
    }
}
