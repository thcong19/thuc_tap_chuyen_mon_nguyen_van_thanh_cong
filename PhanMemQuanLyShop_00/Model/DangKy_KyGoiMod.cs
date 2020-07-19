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
    class DangKy_KyGoiMod
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
        //Thêm 1 thông tin ksy gởi mới
        public bool ThemTTKyGoi(string maThongTinKyGui, string tenChu, string lienHe, string cMND, string tenThuCung, string soLuong, string ngayGoi, string ngayTra, string giaComBo, string maNhanVien, string tenChuong, string giayTo)
        {
            string sqlSua = "INSERT INTO [ShopChoMeo].[dbo].[ThongTinKyGoi] ([MaThongTinKyGui],[TenChu],[LienHe],[CMND],[TenThuCung],[SoLuong],[NgayGoi],[NgayTra],[GiaComBo],[MaNhanVien],[TenChuong],[GiayTo]) VALUES ('" + maThongTinKyGui + "',N'" + tenChu + "',N'" + lienHe + "','" + cMND + "',N'" + tenThuCung + "','" + soLuong + "', '" + Convert.ToDateTime(ngayGoi) + "','" + Convert.ToDateTime(ngayTra) + "'" + giaComBo + "','" + maNhanVien + "','" + tenChuong + "','" + giayTo + "')";
            bool kt = false;
            if (ExecuteNonQuery(sqlSua) > 0)
            {
                kt = true;
            }
            return kt;
        }
        public DataTable LoadChoGrid() //trả về 1 bảng
        {
            MoKetNoi();
            string sql = "SELECT * FROM [ShopChoMeo].[dbo].[ThongTinKyGoi]";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKetNoi();
            return dt;
        }
        //Xóa sau khi thanh toán
        public bool XoaTTKyGoi(string maThongTinKyGoi)
        {
            string sqlXoa = "DELETE FROM [ShopChoMeo].[dbo].[ThongTinKyGoi] WHERE [MaThongTinKyGui]='" + maThongTinKyGoi + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlXoa) > 0)
            {
                kt = true;
            }
            return kt;
        }
    }
}
