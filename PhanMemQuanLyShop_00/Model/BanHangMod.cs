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
    class BanHangMod
    {
        KetNoi kn = new KetNoi();
        SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        string path;
        //đóng mở kết nối csdl
        //Data Source=.\SQLEXPRESS;AttachDbFilename="D:\phần mềm\Dev\Shop\PhanMemQuanLyShop_01\PhanMemQuanLyShop_00\bin\Debug\Database\QlCuaHang.mdf";Integrated Security=True
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
        public DataTable HienThiThongTinHang() //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT * FROM [ShopChoMeo].[dbo].[HangHoa]";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
        //Thay đổi số lượng hàng hóa
        public bool SuaSoLuongHangHoa(string maHang, string tenHang, string donVi, string loaiHang, string maChiTietNhap, string giaBan, string soLuongHang)
        {
            string sqlSua = " UPDATE [ShopChoMeo].[dbo].[HangHoa] SET [MaHang] = '" + maHang + "',[TenHang] = N'" + tenHang + "' ,[DonVi] = N'" + donVi + "' ,[LoaiHang] = N'" + loaiHang + "',[MaChiTietNhap] = '" + maChiTietNhap + "',[GiaBan] = '" + giaBan + "',[SoLuongHang] = '" + soLuongHang + "' WHERE [MaHang] = '" + maHang + "'";
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
        //Tìm kiếm nhanh hàng hóa
        public DataTable HienThiTimKiem(string tenHang) //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT [MaHang],[TenHang],[DonVi],[LoaiHang],[GiaBan],[SoLuongHang] FROM [ShopChoMeo].[dbo].[HangHoa] WHERE TenHang LIKE N'%" + tenHang + "%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }

        //Load cho combobox khách hàng
        public DataTable Load_Cb()
        {
            DataTable re;
            string lenh = "SELECT [TenDonVi] FROM [ShopChoMeo].[dbo].[KhachHang]";
            re = KetNoi.DuLieuTable(lenh);
            return re;
        }
        //Load cho mã khách hàng
        public string LayTenKhach(string tenKhach)
        {
            ConnectToSql con = new ConnectToSql();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("SELECT [MaKhachHang] FROM [ShopChoMeo].[dbo].[KhachHang] WHERE [TenDonVi] = N'" + tenKhach + "'");
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
        //Lấy thông tin liên hệ
        public string LayThongTinLienHe(string tenKhach)
        {
            ConnectToSql con = new ConnectToSql();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("SELECT [LienHe] FROM [ShopChoMeo].[dbo].[KhachHang] WHERE [TenDonVi] = N'" + tenKhach + "'");
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
        //Lấy thông tin thẻ thành viên
        public string LayThongTinThe(string tenKhach)
        {
            ConnectToSql con = new ConnectToSql();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("SELECT [TheThanhVien] FROM [ShopChoMeo].[dbo].[KhachHang] WHERE [TenDonVi] = N'" + tenKhach + "'");
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
        //Load cho combobox nhân viên
        public DataTable Load_CbNhanVien()
        {
            DataTable re;
            string lenh = "SELECT [MaNhanVien] FROM [ShopChoMeo].[dbo].[NhanVien]";
            re = KetNoi.DuLieuTable(lenh);
            return re;
        }
        //Load cho tên nhân viên
        public string LayTenNhanVien(string maNhanVien)
        {
            ConnectToSql con = new ConnectToSql();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("SELECT [HoTen] FROM [ShopChoMeo].[dbo].[NhanVien] WHERE [MaNhanVien] = '" + maNhanVien + "'");
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
        //-----------------------------
        //Load dữ liệu cho gridview Hóa đơn
        public DataTable HienThiHoaDon(string maBanHang) //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT * FROM [ShopChoMeo].[dbo].[ChiTietHoaDon] WHERE [MaBanHang] = '" + maBanHang + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
        //Load dữ liệu cho gridview phiếu mua hàng full
        public DataTable HienThiPhieuMuaHangFull() //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT * FROM [ShopChoMeo].[dbo].[BanHangCombo]";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
        //Load dữ liệu cho phiếu mua hàng có điều kiện
        public DataTable HienThiPhieuMuaHang(string maKhach) //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT * FROM [ShopChoMeo].[dbo].[BanHangCombo] WHERE [MaKhachHang] = '" + maKhach + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
        //Thêm 1 phiếu mua hàng mới
        public bool ThemPhieuMuaHang(string maPhieuHang, string ngayBan, string maKhachHang, string maNhanVien)
        {
            string sqlThem = "INSERT INTO [ShopChoMeo].[dbo].[BanHangCombo] ([MaBanHang],[NgayBanHang],[MaKhachHang],[MaNhanVien]) VALUES ('" + maPhieuHang + "', '" + Convert.ToDateTime(ngayBan) + "','" + maKhachHang + "','" + maNhanVien + "')";
            bool kt = false;
            if (ExecuteNonQuery(sqlThem) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //thêm hàng vào giỏ
        public bool ThemHoaDon(string maChiTietHoaDon, string maBanHang, string maHang, string soLuong, string giaBan, string thanhTien, string tenHang)
        {
            string sqlThem = "INSERT INTO [ShopChoMeo].[dbo].[ChiTietHoaDon] ([MaChiTietHoaDon],[MaBanHang],[MaHang],[SoLuong],[GiaBan],[ThanhTien],[TenHang]) VALUES ('" + maChiTietHoaDon + "','" + maBanHang + "', '" + maHang + "', '" + soLuong + "','" + giaBan + "','" + thanhTien + "',N'" + tenHang + "')";
            bool kt = false;
            if (ExecuteNonQuery(sqlThem) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Sửa thông tin hóa đơn
        public bool SuaHoaDon(string maChiTietHoaDon, string maBanHang, string maHang, string soLuong, string giaBan, string thanhTien, string tenHang)
        {
            string sqlSua = " UPDATE [ShopChoMeo].[dbo].[ChiTietHoaDon] SET [MaChiTietHoaDon] = '" + maChiTietHoaDon + "',[MaBanHang] = '" + maBanHang + "',[MaHang] = '" + maHang + "',[SoLuong] = '" + soLuong + "',[GiaBan] = '" + giaBan + "',[ThanhTien] = '" + thanhTien + "',[TenHang]=N'" + tenHang + "' WHERE [MachiTietHoaDon] = '" + maChiTietHoaDon + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlSua) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Load full dữ liệu cho gridview Hóa đơn
        public DataTable HienThiHoaDonFull() //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT * FROM [ShopChoMeo].[dbo].[ChiTietHoaDon]";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
        //Xóa 1 hàng hóa đã chọn
        public bool TraHangHoa(string machiTietHoaDon)
        {
            string sqlXoa = "DELETE FROM [ShopChoMeo].[dbo].[ChiTietHoaDon] WHERE MaChiTietHoaDon='" + machiTietHoaDon + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlXoa) > 0)
            {
                kt = true;
            }
            return kt;
        }
    }
}
