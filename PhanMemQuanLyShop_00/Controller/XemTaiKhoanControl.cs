using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyShop_00.Model;
using System.Data;

namespace PhanMemQuanLyShop_00.Control
{
    class XemTaiKhoanControl
    {
        XemtaiKhoanMod XemTkMod = new XemtaiKhoanMod();
        public DataTable HienThiDuLieu()
        {
            return XemTkMod.HienThiDuLieu();
        }
    }
}
