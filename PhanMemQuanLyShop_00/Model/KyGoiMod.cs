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
    class KyGoiMod
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
        //Lấy cột Trạng thái
        public DataTable CotTrangThai() //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT [TrangThai] FROM [ShopChoMeo].[dbo].[ChuongKyGoi]";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
        public DataTable LoadChoGridKyGoi() //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT * FROM [ShopChoMeo].[dbo].[ThongTinKyGoi]";
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
        //sửa lại trạng thái
        public bool SuaTrangThai(string maChuong, string tenChuong, string trangThai)
        {
            string sqlSua = " UPDATE [ShopChoMeo].[dbo].[ChuongKyGoi] SET [MaChuong] = N'" + maChuong + "' ,[TenChuong] = N'" + tenChuong + "' ,[TrangThai] = '" + trangThai + "' WHERE [MaChuong] = '" + maChuong + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlSua) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Thêm 1 thông tin ký gởi mới
        public bool ThemTTKyGoi(string maThongTinKyGui, string tenChu, string lienHe, string cMND, string tenThuCung, string soLuong, string ngayGoi, string ngayTra, string giaComBo, string maNhanVien, string tenChuong, string giayTo)
        {
            string sqlSua = "INSERT INTO [ShopChoMeo].[dbo].[ThongTinKyGoi] ([MaThongTinKyGui],[TenChu],[LienHe],[CMND],[TenThuCung],[SoLuong],[NgayGoi],[NgayTra],[GiaComBo],[MaNhanVien],[TenChuong],[GiayTo]) VALUES ('" + maThongTinKyGui + "',N'" + tenChu + "',N'" + lienHe + "','" + cMND + "',N'" + tenThuCung + "','" + soLuong + "','" + Convert.ToDateTime(ngayGoi) + "','" + Convert.ToDateTime(ngayTra) + "','" + giaComBo + "','" + maNhanVien + "','" + tenChuong + "',N'" + giayTo + "')";
            bool kt = false;
            if (ExecuteNonQuery(sqlSua) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Thêm 1 hóa đơn mới
        public bool ThemHoaDonKyGoi(string maThanhToan, string thanhTien, string maNhanVien, string tienPhat, string giaCombo, string ngayLap, string maChuong, string maThongTinKyGoi, string maNVThanhToan)
        {
            string sqlSua = "INSERT INTO [ShopChoMeo].[dbo].[ThanhToanKyGoi] ([MaThanhToanKG] ,[ThanhTien] ,[MaNhanVien] ,[TienPhat] ,[GiaComBoTT] ,[NgayLap] ,[MaChuong] ,[MaThongTinKyGoi] ,[MaNVThanhToan]) VALUES ('" + maThanhToan + "' ,'" + thanhTien + "' ,'" + maNhanVien + "' ,'" + tienPhat + "' ,'" + giaCombo + "','" + Convert.ToDateTime(ngayLap) + "','" + maChuong + "' ,'" + maThongTinKyGoi + "' ,'" + maNVThanhToan + "') ";
            bool kt = false;
            if (ExecuteNonQuery(sqlSua) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Load cho cbbox mã chuồng
        public DataTable Load_CbMaChuong(string trangThai)
        {
            DataTable re;
            string lenh = "SELECT [MaChuong] FROM [ShopChoMeo].[dbo].[ChuongKyGoi] WHERE [TrangThai]='" + trangThai + "'";
            re = KetNoi.DuLieuTable(lenh);
            return re;
        }
        //Load cho cbbox nhân viên
        public DataTable Load_CbMaNv()
        {
            DataTable re;
            string lenh = "SELECT [MaNhanVien] FROM [ShopChoMeo].[dbo].[NhanVien]";
            re = KetNoi.DuLieuTable(lenh);
            return re;
        }
        //Sửa thông tin ký gởi
        public bool SuaTTKyGoi(string maThongTinKyGui, string tenChu, string lienHe, string cMND, string tenThuCung, string soLuong, string ngayGoi, string ngayTra, string giaComBo, string maNhanVien, string tenChuong, string giayTo)
        {
            string sqlSua = "UPDATE [ShopChoMeo].[dbo].[ThongTinKyGoi] SET [MaThongTinKyGui] = '" + maThongTinKyGui + "',[TenChu] = N'" + tenChu + "',[LienHe] = N'" + lienHe + "',[CMND] = '" + cMND + "',[TenThuCung] = N'" + tenThuCung + "',[SoLuong] = '" + soLuong + "',[NgayGoi] = '" + Convert.ToDateTime(ngayGoi) + "',[NgayTra] ='" + Convert.ToDateTime(ngayTra) + "',[GiaComBo] = '" + giaComBo + "',[MaNhanVien] = '" + maNhanVien + "',[TenChuong] = '" + tenChuong + "',[GiayTo] = N'" + giayTo + "' WHERE [MaThongTinKyGui] = '" + maThongTinKyGui + "' ";
            bool kt = false;
            if (ExecuteNonQuery(sqlSua) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Load những chuồng đang dùng
        public DataTable HienThiThongTinCho1Chuong(string maChuong)
        {
            DataTable re;
            string lenh = "SELECT [TenChuong] FROM [ShopChoMeo].[dbo].[ChuongKyGoi] WHERE [TrangThai]='" + maChuong + "'";
            re = KetNoi.DuLieuTable(lenh);
            return re;
        }
        //lấy về mã ksy gởi
        public DataTable MaHoaDonKyGoi()
        {
            DataTable re;
            string lenh = "SELECT [MaThanhToanKG] FROM [ShopChoMeo].[dbo].[ThanhToanKyGoi]";
            re = KetNoi.DuLieuTable(lenh);
            return re;
        }
        //xóa thông tin ký gởi
        public bool XoaTTKyGoi(string maThongTinKyGoi)
        {
            string sqlSua = "DELETE FROM [ShopChoMeo].[dbo].[ThongTinKyGoi] WHERE [MaThongTinKyGui] = '" + maThongTinKyGoi + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlSua) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Load cho hóa đơn
        public DataTable HienGridThiChoHoaDon(string maThongTin)
        {
            DataTable re;
            string lenh = "SELECT * FROM [ShopChoMeo].[dbo].[ThongTinKyGoi] WHERE [MaThongTin]='" + maThongTin + "'";
            re = KetNoi.DuLieuTable(lenh);
            return re;
        }

        //Load xem thông tin chuồng đang dùng
        public DataTable LoadTT1ChuongDangDung(string maChuong)
        {
            DataTable re;
            string lenh = "SELECT [MaChuong] FROM [ShopChoMeo].[dbo].[ChuongKyGoi] WHERE [TrangThai]='" + maChuong + "'";
            re = KetNoi.DuLieuTable(lenh);
            return re;
        }
        //Lấy mã ký gởi cho thanh toán
        public string LayMaKyGoi(string maChuong)
        {
            ConnectToSql con = new ConnectToSql();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("SELECT [MaThongTinKyGoi] FROM [ShopChoMeo].[dbo].[ThongTinKyGoi] WHERE [MaChuong] = N'" + maChuong+ "'");
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
        //Lấy thông tin cho giá combo
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
        //Load cho hóa đơn ký goi
        public DataTable HoaDonKyGoi(string maHD)
        {
            DataTable re;
            string lenh = "SELECT * FROM [ShopChoMeo].[dbo].[ThanhToanKyGoi] WHERE [MaThanhToanKG] LIKE '%" + maHD+"%'";
            re = KetNoi.DuLieuTable(lenh);
            return re;
        }
        //Load toàn bộ cho hóa don ký gởi
        public DataTable HoaDonKyGoiFull()
        {
            DataTable re;
            string lenh = "SELECT * FROM [ShopChoMeo].[dbo].[ThanhToanKyGoi]";
            re = KetNoi.DuLieuTable(lenh);
            return re;
        }
        //Load thông tin in cho khách
        public DataTable LoadThongTinIn(string maKyGoi)
        {
            DataTable re;
            string lenh = "SELECT * FROM [ShopChoMeo].[dbo].[ThongTinKyGoi] WHERE [MaThongTinKyGui] = '" + maKyGoi + "'";
            re = KetNoi.DuLieuTable(lenh);
            return re;
        }
    }
}
