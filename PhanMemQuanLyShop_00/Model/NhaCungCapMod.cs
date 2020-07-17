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
    class NhaCungCapMod
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
            string sql = "SELECT * FROM [ShopChoMeo].[dbo].[NhaCungCap]";
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
        public bool ThemNhaCungCap(string maNhaCungCap, string tenNhaCungCap, string diaChi, string lienHe, string soTaiKhoan)
        {
            string sqlThem = "INSERT INTO [ShopChoMeo].[dbo].[NhaCungCap] ([MaNhaCungCap],[TenNhaCungCap],[DiaChi],[LienHe],[SoTaiKhoan]) VALUES (N'" + maNhaCungCap + "',N'" + tenNhaCungCap + "',N'" + diaChi + "',N'" + lienHe + "',N'" + soTaiKhoan + "')";
            bool kt = false;
            if (ExecuteNonQuery(sqlThem) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Sửa thông tin tài khoản
        public bool SuaNhaCungCap(string maNhaCungCap, string tenNhaCungCap, string diaChi, string lienHe, string soTaiKhoan)
        {
            string sqlSua = "UPDATE [ShopChoMeo].[dbo].[NhaCungCap] SET [MaNhaCungCap] =  N'" + maNhaCungCap + "',[TenNhaCungCap] =  N'" + tenNhaCungCap + "',[DiaChi] =  N'" + diaChi + "',[LienHe] =  N'" + lienHe + "',[SoTaiKhoan] =  N'" + soTaiKhoan + "', WHERE MaNhaCungCap='" + maNhaCungCap + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlSua) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Xóa tài khoản
        public bool XoaNhaCungCap(string maNhaCungCap)
        {
            string sqlXoa = "DELETE FROM [ShopChoMeo].[dbo].[NhaCungCap] WHERE MaNhaCungCap='" + maNhaCungCap + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlXoa) > 0)
            {
                kt = true;
            }
            return kt;
        }

    }
}
