using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace PhanMemQuanLyShop_00.Model
{
    class ChamCongMod
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
        public DataTable HienThiThongTin() //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT * FROM [ShopChoMeo].[dbo].[ChamCong]";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
        public DataTable LayTenNhanVien() //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT [HoTen] FROM [ShopChoMeo].[dbo].[NhanVien]";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
        //Lấy thông tin liên hệ
        public string LayMaNhanVien(string ten)
        {
            ConnectToSql con = new ConnectToSql();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("SELECT [MaNhanVien] FROM [ShopChoMeo].[dbo].[NhanVien] WHERE [HoTen] = N'" + ten + "'");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.openCon();
                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                cmd.Dispose();
                con.closeCon();
            }
            return "";
        }
        //Thêm lương
        public bool ThemLuongMoi(string maChamCong, string maNhaVien, string tenNhanVien, string thang, string nam, string tangCa, string nghiLam, string luongCung, string luongNhan, string tienThuong, string tienPhat)
        {
            string sqlSua = "INSERT INTO [ShopChoMeo].[dbo].[ChamCong] ([MaChamCong],[MaNhanVien],[TenNhanVien],[Thang],[Nam],[TangCa],[NghiLam],[LuongCung],[LuongNhan],[TienThuong],[TienPhat]) VALUES ('" + maChamCong + "','" + maNhaVien + "',N'" + tenNhanVien + "','" + thang + "','" + nam + "','" + tangCa + "','" + nghiLam + "','" + luongCung + "','" + luongNhan + "','" + tienThuong + "','" + tienPhat + "')";
            bool kt = false;
            if (ExecuteNonQuery(sqlSua) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //sửa lương
        public bool SuaLuong(string maChamCong, string maNhaVien, string tenNhanVien, string thang, string nam, string tangCa, string nghiLam, string luongCung, string luongNhan, string tienThuong, string tienPhat)
        {
            string sqlSua = "UPDATE [ShopChoMeo].[dbo].[ChamCong] SET [MaChamCong] = '" + maChamCong + "',[MaNhanVien] = '" + maNhaVien + "',[TenNhanVien] = N'" + tenNhanVien + "',[Thang] = '" + thang + "',[Nam] = '" + nam + "',[TangCa] = '" + tangCa + "',[NghiLam] = '" + nghiLam + "',[LuongCung] = '" + luongCung + "',[LuongNhan] = '" + luongNhan + "',[TienThuong] = '" + tienThuong + "',[TienPhat] = '" + tienPhat + "' WHERE [MaChamCong] = '" + maChamCong + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlSua) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Xóa lương
        public bool XoaLuong(string maChamCong)
        {
            string sqlSua = "DELETE FROM [ShopChoMeo].[dbo].[ChamCong] WHERE [MaChamCong] = '" + maChamCong + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlSua) > 0)
            {
                kt = true;
            }
            return kt;
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
        //Xem luong
        public DataTable XemLuong(string thang, string nam) //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT * FROM [ShopChoMeo].[dbo].[ChamCong] WHERE Thang ='" + thang + "' AND Nam = '" + nam + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
    }
}
