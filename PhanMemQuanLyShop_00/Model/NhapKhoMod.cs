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
    class NhapKhoMod
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
        //Load dữ liệu cho gidcontrol1 
        public DataTable HienThiDuLieu1() //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT * FROM [ShopChoMeo].[dbo].[NhapKho]";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
        //Load dữ liệu cho gidcontrol2
        public DataTable HienThiDuLieu2() //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT * FROM [ShopChoMeo].[dbo].[ChiTietNhapKho]";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
        //Load dữ liệu cho gidcontrol3
        public DataTable HienThiDuLieu3() //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT * FROM [ShopChoMeo].[dbo].[HangHoa]";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }

        //Load dữ liệu cho lookedit Mã nhập
        public DataTable HienThiLookeditMaNhap() //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT [MaNhap] FROM [ShopChoMeo].[dbo].[NhapKho]";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }

        //Load dữ liệu cho lookedit mã nhà cung cấp
        public DataTable HienThiLookeditMaNhaCungCap() //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT [MaNhaCungCap]FROM [ShopChoMeo].[dbo].[NhaCungCap]";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }

        //Load dữ liệu cho lookedit mã chi tiết nhập
        public DataTable HienThiLookeditMaChiTietNhap() //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT [MaChiTietNhap] FROM [ShopChoMeo].[dbo].[ChiTietNhapKho]";
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
        //**PHIẾU NHẬP**
        //Thêm 1 Phiếu nhập hàng mới
        public bool ThemPhieuNhap(string maNhap, string maNhaCungCap, string ngayNhap)
        {
            string sqlThem = "INSERT INTO [ShopChoMeo].[dbo].[NhapKho] ([MaNhap] ,[MaNhaCungCap] ,[NgayNhap]) VALUES ('" + maNhap + "','" + maNhaCungCap + "', '" + Convert.ToDateTime(ngayNhap) + "')";
            bool kt = false;
            if (ExecuteNonQuery(sqlThem) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Sửa thông tin phiếu nhập
        public bool SuaPhieuNhap(string maNhap, string maNhaCungCap, string ngayNhap)
        {
            string sqlSua = "UPDATE [ShopChoMeo].[dbo].[NhapKho] SET [MaNhap] = N'" + maNhap + "',[MaNhaCungCap] = N'" + maNhaCungCap + "' ,[NgayNhap] = '" + Convert.ToDateTime(ngayNhap) + "' WHERE MaNhap='" + maNhap + "'";

            bool kt = false;
            if (ExecuteNonQuery(sqlSua) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Xóa bỏ phiếu nhập
        public bool XoaPhieuNhap(string maNhap)
        {
            string sqlXoa = "DELETE FROM [ShopChoMeo].[dbo].[NhapKho] WHERE MaNhap='" + maNhap + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlXoa) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //**CHI TIẾT NHẬP**
        //Thêm chi tiết phiếu nhập
        public bool ThemChiTietPhieuNhap(string maChiTietNhap,string goiHang, string maNhap, string soLuong, string giaNhap)
        {
            string sqlThem = "INSERT INTO [ShopChoMeo].[dbo].[ChiTietNhapKho] ([MaChiTietNhap],[GoiHang], [MaNhap], [SoLuong], [GiaNhap]) VALUES ('" + maChiTietNhap + "',N'" + goiHang + "','" + maNhap + "','" + soLuong + "','" + giaNhap + "')";
            bool kt = false;
            if (ExecuteNonQuery(sqlThem) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Sửa thông tin chi tiết nhập hàng
        public bool SuaChiTietPhieuNhap(string maChiTietNhap,string goiHang ,string maNhap, string soLuong, string giaNhap)
        {
            string sqlSua = "UPDATE [ShopChoMeo].[dbo].[ChiTietNhapKho] SET [MaChiTietNhap] = '" + maChiTietNhap + "',[GoiHang]=N'" + goiHang + "',[MaNhap] = N'" + maNhap + "' ,[SoLuong] = '" + soLuong + "',[GiaNhap]='" + giaNhap + "' WHERE MaChiTietNhap='" + maChiTietNhap + "'";

            bool kt = false;
            if (ExecuteNonQuery(sqlSua) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Xóa chi tiết phiếu nhập
        public bool XoaChiTietPhieuNhap(string maChiTietNhap)
        {
            string sqlXoa = "DELETE FROM [ShopChoMeo].[dbo].[ChiTietNhapKho] WHERE  MaChiTietNhap='" + maChiTietNhap + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlXoa) > 0)
            {
                kt = true;
            }
            return kt;
        }

        //**THÔNG TIN HÀNG**
        //Thêm thông tin hàng mới
        public bool ThemThongTinHang(string maHang, string tenHang, string DonVi, string loaiHang, string maChitiet,string giaBan,string soLuong)
        {
            string sqlThem = "INSERT INTO [ShopChoMeo].[dbo].[HangHoa]([MaHang],[TenHang],[DonVi],[LoaiHang],[MaChiTietNhap],[Giaban],[SoLuongHang]) VALUES ('" + maHang + "',N'" + tenHang + "',N'" + DonVi + "',N'" + loaiHang + "','" + maChitiet + "','" + giaBan + "','"+soLuong+"')";
            bool kt = false;
            if (ExecuteNonQuery(sqlThem) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Sửa thông tin phiếu nhập
        public bool SuaThongTinHang(string maHang, string tenHang, string donVi, string loaiHang, string maChitiet, string giaBan, string soLuong)
        {
            string sqlSua = "UPDATE [ShopChoMeo].[dbo].[HangHoa] SET [MaHang] =N'" + maHang + "',[TenHang] =N'" + tenHang + "',[DonVi] = N'" + donVi + "',[LoaiHang] = N'" + loaiHang + "',[MaChiTietNhap] = '" + maChitiet + "',[GiaBan] = '" + giaBan + "',[SoLuongHang] = '"+soLuong+"' WHERE MaHang='" + maHang + "'";

            bool kt = false;
            if (ExecuteNonQuery(sqlSua) > 0)
            {
                kt = true;
            }
            return kt;
        }
        //Xóa bỏ phiếu nhập
        public bool XoaThongTinHang(string maHang)
        {
            string sqlXoa = "DELETE FROM [ShopChoMeo].[dbo].[HangHoa] WHERE MaHang='" + maHang + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlXoa) > 0)
            {
                kt = true;
            }
            return kt;
        }
    }
}
