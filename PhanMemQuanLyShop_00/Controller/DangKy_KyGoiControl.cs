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
    class DangKy_KyGoiControl
    {
        DangKy_KyGoiMod dk_KyGoiMod = new DangKy_KyGoiMod();
        //thêm thông tin mới
        public bool ThemDuLieuKyGoi(string maThongTinKyGui, string tenChu, string lienHe, string cMND, string tenThuCung, string soLuong, string NgayGoi, string NgayTra, string giaComBo, string maNhanVien, string tenChuong, string giayTo)
        {
            return dk_KyGoiMod.ThemTTKyGoi(maThongTinKyGui, tenChu, lienHe, cMND, tenThuCung, soLuong, NgayGoi, NgayTra, giaComBo, maNhanVien, tenChuong, giayTo);
        }
        public DataTable ThongTinKyGoi()
        {
            return dk_KyGoiMod.LoadChoGrid();
        }
        public bool XoaThongTinkyGoi(string maThongTin)
        {
            return dk_KyGoiMod.XoaTTKyGoi(maThongTin);
        }
    }
}
