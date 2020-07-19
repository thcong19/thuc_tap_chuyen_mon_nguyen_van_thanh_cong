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
    class KhoHangControl
    {
        KhoHangMod KhoMod = new KhoHangMod();
        public DataTable HienThiDuLieu()
        {
            return KhoMod.HienThiDuLieu();
        }
        public DataTable HienThiDuLieuTimKiem(string tenHang)
        {
            return KhoMod.TimKiemTenHang(tenHang);
        }
        public DataTable HangTonKho(string soLuong)
        {
            return KhoMod.HangTonKho(soLuong);
        }
    }
}
