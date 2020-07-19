using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

namespace PhanMemQuanLyShop_00.Model
{
    class KetNoi
    {
        public static SqlConnection conn;
        public static SqlDataReader dr;
        public static SqlCommand cmd;
        public static DataTable dt;
        public static SqlDataAdapter da;
        public static SqlCommandBuilder cmb;
        public static string path;

        public static void MoKetNoi()
        {
            try
            {
                if (conn == null)
                {
                    path = Path.GetFullPath(Environment.CurrentDirectory);
                    conn = new SqlConnection(@"Data Source=DESKTOP-GNVB183\SQLEXPRESS;Initial Catalog=ShopChoMeo;Integrated Security=True");
                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu");
            }
        }
        public static void DongKetNoi()
        {
            try
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch { MessageBox.Show("Lỗi cơ sở dữ liệu"); }
        }
        public static DataTable DuLieuTable(string sql)
        {
            try
            {
                MoKetNoi();
                da = new SqlDataAdapter(sql, conn);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch
            { }
            return dt;
        }
        public static int ExeCuteNonQuery(String sql)
        {
            int re = 0;
            try
            {
                MoKetNoi();
                cmd = new SqlCommand(sql, conn);
                re = cmd.ExecuteNonQuery();
                DongKetNoi();
            }
            catch
            {

            }
            return re;
        }
        public string LoadDuLieu(string sql)
        {
            string ketQua = "";
            MoKetNoi();
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ketQua = dr[0].ToString();
            }
            DongKetNoi();
            return ketQua;
        }
        public void Update(String sql, DataTable table)
        {
            try
            {
                da = new SqlDataAdapter(sql, conn);
                cmb = new SqlCommandBuilder(da);
                da.Update(table);
            }
            catch
            { MessageBox.Show("Lỗi"); }
        }
    }
}
