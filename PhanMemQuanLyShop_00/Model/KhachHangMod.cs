using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace PhanMemQuanLyShop_00.Model
{
    class KhachHangMod
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
            string sql = "SELECT * FROM [ShopChoMeo].[dbo].[KhachHang]";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
        //Hiển thị khách ưu đãi
        public DataTable HienThiKhachUuDai(string loaiThe) //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT * FROM [ShopChoMeo].[dbo].[KhachHang] WHERE [TheThanhVien] = '" + loaiThe+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
        //Phương thức sử dụng cho thêm sửa xóa
        public int ExecuteNonQuery(string sql)
        {
            int dung = 0;
            try
            {
                MoKetNoi();
                SqlCommand cmd = new SqlCommand(sql, conn);
                dung = cmd.ExecuteNonQuery();
                DongKetNoi();
            }
            catch
            { }
            return dung;
        }

        //Thêm 1 tài khoản mới
        public bool ThemKhachHang(string maKhachHang, string LienHe, string TenDonVi, string TheThanhVien)
        {
            string sqlThem = "INSERT INTO [ShopChoMeo].[dbo].[KhachHang] ([MaKhachHang],[LienHe],[TenDonVi],[TheThanhVien]) VALUES ('" + maKhachHang + "',N'" + LienHe + "', N'" + TenDonVi + "', N'" + TheThanhVien + "')";
            bool kt = false;
            if (ExecuteNonQuery(sqlThem) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Sửa thông tin khách
        public bool SuaKhachHang(string maKhachHang, string LienHe, string TenDonVi, string TheThanhVien)
        {
            string sqlSua = "UPDATE [ShopChoMeo].[dbo].[KhachHang] SET [MaKhachHang] = '" + maKhachHang + "',[LienHe] =  N'" + LienHe + "',[TenDonVi] =  N'" + TenDonVi + "',[TheThanhVien] = N'" + TheThanhVien + "' WHERE maKhachHang='" + maKhachHang + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlSua) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Xóa khách hàng
        public bool XoaKhachHang(string maKhachHang)
        {
            string sqlXoa = "DELETE FROM [ShopChoMeo].[dbo].[KhachHang] WHERE MaKhachHang='" + maKhachHang + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlXoa) > 0)
            {
                kt = true;
            }
            return kt;
        }
    }
}
