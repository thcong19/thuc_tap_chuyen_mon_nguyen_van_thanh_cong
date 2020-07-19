using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace PhanMemQuanLyShop_00.Model
{
    class PhieuMuaHangMod
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
        public DataTable HienThiPhieuMuaHang() //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT * FROM [ShopChoMeo].[dbo].[BanHangCombo]";
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
            //Thêm 1 phiếu mua hàng mới
        public bool ThemPhieuMuaHang(string maPhieuHang, string ngayBan, string maKhachHang, string maNhanVien)
        {
            string sqlThem = "INSERT INTO [ShopChoMeo].[dbo].[BanHangCombo] ([MaBanHang],[NgayBanHang],[MaKhachHang],[MaNhanVien]) VALUES ('" + maPhieuHang + "','" + Convert.ToDateTime(ngayBan) + "','" + maKhachHang + "','" + maNhanVien + "')";
            bool kt = false;
            if (ExecuteNonQuery(sqlThem) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Sửa thông tin phiếu mua hàng
        public bool SuaPhieuMuaHang(string maPhieuHang, string ngayBan, string maKhachHang, string maNhanVien)
        {
            string sqlSua = "UPDATE [ShopChoMeo].[dbo].[BanHangCombo] SET [MaBanHang] =  '" + maPhieuHang + "',[NgayBanHang] = '" +  Convert.ToDateTime(ngayBan) + "',[MaKhachHang] =  '" + maKhachHang + "',[MaNhanVien] =  '" + maNhanVien + "' WHERE MaBanHang='" + maPhieuHang + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlSua) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Xóa phiếu
        public bool XoaNhaCungCap(string maPhieu)
        {
            string sqlXoa = "DELETE FROM [ShopChoMeo].[dbo].[BanHangCombo] WHERE MaBanHang='" + maPhieu + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlXoa) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Hiển thị cho look mã khách hàng
        public DataTable HienThiLookeditMaKhach() //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT [MaKhachHang] FROM [ShopChoMeo].[dbo].[KhachHang]";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
        //Hiển thị cho look mã nhân viên
        public DataTable HienThiLookeditMaNhanVien() //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT [MaNhanVien] FROM [ShopChoMeo].[dbo].[NhanVien]";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
    }
}
