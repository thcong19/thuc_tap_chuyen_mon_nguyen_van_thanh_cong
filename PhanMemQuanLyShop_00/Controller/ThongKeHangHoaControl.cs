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
    class ThongKeHangHoaControl
    {
        ThongKeHangThangMod TKHangMod = new ThongKeHangThangMod();
        public DataTable ThongKeHangTheoThang(string thang, string nam)
        {
            return TKHangMod.HienThiThongKeThang(thang,nam);
        }
        public DataTable ThongKeHangTheoNam(string nam)
        {
            return TKHangMod.HienThiThongKeNan(nam);
        }
        public DataTable ThongKeHangTheoNgay(string ngayTruoc, string ngaySau)
        {
            return TKHangMod.HienThiThongKeNgay(ngayTruoc, ngaySau);
        }
    }
}
