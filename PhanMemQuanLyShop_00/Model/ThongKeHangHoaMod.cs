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
    class ThongKeHangHoaMod
    {
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
        //Load dữ liệu cho datagidview
        public DataTable HangHoaBanChay(string soLuong) //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT NhaCungCap.TenNhaCungCap, NhaCungCap.DiaChi, HangHoa.TenHang, HangHoa.LoaiHang, HangHoa.GiaBan, ChiTietHoaDon.SoLuong FROM ChiTietHoaDon INNER JOIN HangHoa ON ChiTietHoaDon.MaHang = HangHoa.MaHang CROSS JOIN NhaCungCap WHERE (ChiTietHoaDon.SoLuong > '"+soLuong+"')";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
        public DataTable HangHoaBanCham(string soLuong) //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT NhaCungCap.TenNhaCungCap, NhaCungCap.DiaChi, HangHoa.TenHang, HangHoa.LoaiHang, HangHoa.GiaBan, ChiTietHoaDon.SoLuong FROM ChiTietHoaDon INNER JOIN HangHoa ON ChiTietHoaDon.MaHang = HangHoa.MaHang CROSS JOIN NhaCungCap WHERE (ChiTietHoaDon.SoLuong < '" + soLuong + "')";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
    }
}
