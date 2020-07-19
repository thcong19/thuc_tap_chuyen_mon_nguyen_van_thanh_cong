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
    class DanhSachNhanVienControl
    {
        DanhSachNhanVienMod DSnhanVienMod = new DanhSachNhanVienMod();
        public DataTable HienThiChung()
        {
            return DSnhanVienMod.HienThiDuLieu();
        }
        public DataTable HienThiTimKiemChung(string tenNV)
        {
            return DSnhanVienMod.TimKiemNhanVien(tenNV);
        }
        public DataTable HienThiTimKiemMa(string tenNV)
        {
            return DSnhanVienMod.TimKiemTheoMa(tenNV);
        }
        public DataTable HienThiTimKiemTen(string tenNV)
        {
            return DSnhanVienMod.TimKiemTheoTen(tenNV);
        }
        //hien thị cho text
        public DataTable HienThiTextMa()
        {
            return DSnhanVienMod.HienThiLookeditMaNhanVien();
        }
        public DataTable HienThiTextTen()
        {
            return DSnhanVienMod.HienThiLookeditTenNhanVien();
        }
    }
}
