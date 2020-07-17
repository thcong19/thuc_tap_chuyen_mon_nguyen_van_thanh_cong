using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace PhanMemQuanLyShop_00.Model
{
    class ThongKeDoanhThuMod
    {
        KetNoi kn = new KetNoi();
        SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        string path;
        //đóng mở kết nối csdl
        public void MoKetNoi()
        {
            try
            {
                if (conn == null)
                {
                    path = Path.GetFullPath(Environment.CurrentDirectory);
                    conn = new SqlConnection(@"Data Source=DESKTOP-GNVB183\SQLEXPRESS;Initial Catalog=ShopChoMeo;Integrated Security=True");
                }
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu");
            }
        }
        public void DongKetNoi()
        {
            try
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                    conn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối!!!");
            }
        }
        //Load dữ liệu cho gridview
        public DataTable HienThiThongKeThang(string thang, string nam) //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT ChiTietHoaDon.TenHang, ChiTietHoaDon.SoLuong, ChiTietHoaDon.GiaBan, ChiTietHoaDon.ThanhTien, BanHangCombo.NgayBanHang FROM ChiTietHoaDon INNER JOIN BanHangCombo ON ChiTietHoaDon.MaBanHang = BanHangCombo.MaBanHang WHERE (MONTH(BanHangCombo.NgayBanHang) = '" + thang + "') AND (YEAR(BanHangCombo.NgayBanHang) = '" + nam + "')";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
        //Theo năm
        public DataTable HienThiThongKeNam(string nam) //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT ChiTietHoaDon.TenHang, ChiTietHoaDon.SoLuong, ChiTietHoaDon.GiaBan, ChiTietHoaDon.ThanhTien, BanHangCombo.NgayBanHang FROM ChiTietHoaDon INNER JOIN BanHangCombo ON ChiTietHoaDon.MaBanHang = BanHangCombo.MaBanHang WHERE (YEAR(BanHangCombo.NgayBanHang) = '" + nam + "')";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
        //theo ngày
        public DataTable HienThiThongKeNgay(string ngayTruoc, string ngaySau) //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT ChiTietHoaDon.TenHang, ChiTietHoaDon.SoLuong, ChiTietHoaDon.GiaBan, ChiTietHoaDon.ThanhTien, BanHangCombo.NgayBanHang FROM ChiTietHoaDon INNER JOIN BanHangCombo ON ChiTietHoaDon.MaBanHang = BanHangCombo.MaBanHang WHERE [NgayBanHang] BETWEEN  '" + Convert.ToDateTime(ngayTruoc) + "'  AND  '" + Convert.ToDateTime(ngaySau) + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
    }
}
