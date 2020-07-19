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
    class ThongKeHangHoaConntrol
    {
        ThongKeHangHoaMod TKHang = new ThongKeHangHoaMod();
        public DataTable HienThiHangbanChay(string soLuong)
        {
            return TKHang.HangHoaBanChay(soLuong);
        }
        public DataTable HienThiHangbanCham(string soLuong)
        {
            return TKHang.HangHoaBanCham(soLuong);
        }
    }
}
