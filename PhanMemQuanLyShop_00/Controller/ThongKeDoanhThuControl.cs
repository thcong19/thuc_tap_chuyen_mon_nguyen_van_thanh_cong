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
    class ThongKeDoanhThuControl
    {
        ThongKeDoanhThuMod TkDthu = new ThongKeDoanhThuMod();
        public DataTable HienThiDoanhThuNgay(string ngayTruoc,string ngaySau)
        {
            return TkDthu.HienThiThongKeNgay(ngayTruoc,ngaySau);
        }
        public DataTable HienThiDoanhThuNam(string nam)
        {
            return TkDthu.HienThiThongKeNam(nam);
        }
        public DataTable HienThiDoanhThuThang(string thang,string nam)
        {
            return TkDthu.HienThiThongKeThang(thang,nam);
        }
    }
}
