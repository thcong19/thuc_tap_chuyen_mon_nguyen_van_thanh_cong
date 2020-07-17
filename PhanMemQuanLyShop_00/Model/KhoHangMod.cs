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
    class KhoHangMod
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
        public DataTable HienThiDuLieu() //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT NhaCungCap.MaNhaCungCap, NhaCungCap.TenNhaCungCap, NhapKho.MaNhap, NhapKho.NgayNhap, ChiTietNhapKho.MaChiTietNhap, ChiTietNhapKho.SoLuong, ChiTietNhapKho.GiaNhap, HangHoa.MaHang, HangHoa.TenHang, HangHoa.DonVi, HangHoa.LoaiHang FROM ChiTietNhapKho INNER JOIN HangHoa ON ChiTietNhapKho.MaChiTietNhap = HangHoa.MaChiTietNhap INNER JOIN NhapKho ON ChiTietNhapKho.MaNhap = NhapKho.MaNhap INNER JOIN NhaCungCap ON NhapKho.MaNhaCungCap = NhaCungCap.MaNhaCungCap";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
        //Tìm kiếm tên hàng
        public DataTable TimKiemTenHang(string tenHang) //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT NhaCungCap.MaNhaCungCap, NhaCungCap.TenNhaCungCap, NhapKho.MaNhap, NhapKho.NgayNhap, ChiTietNhapKho.MaChiTietNhap, ChiTietNhapKho.SoLuong, ChiTietNhapKho.GiaNhap, HangHoa.MaHang, HangHoa.TenHang, HangHoa.DonVi, HangHoa.LoaiHang FROM ChiTietNhapKho INNER JOIN HangHoa ON ChiTietNhapKho.MaChiTietNhap = HangHoa.MaChiTietNhap INNER JOIN NhapKho ON ChiTietNhapKho.MaNhap = NhapKho.MaNhap INNER JOIN NhaCungCap ON NhapKho.MaNhaCungCap = NhaCungCap.MaNhaCungCap WHERE TenHang LIKE '%" + tenHang + "%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
        //HÀNG TỒN KHO
        public DataTable HangTonKho(string soLuong) //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT [MaHang],[TenHang],[DonVi],[LoaiHang],[MaChiTietNhap],[GiaBan],[SoLuongHang] FROM [ShopChoMeo].[dbo].[HangHoa] WHERE [SoLuongHang] > '" + soLuong + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
    }
}
