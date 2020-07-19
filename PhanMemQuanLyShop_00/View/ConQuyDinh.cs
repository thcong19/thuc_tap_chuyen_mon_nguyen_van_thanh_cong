using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Data.SqlClient;

namespace PhanMemQuanLyShop_00.View
{
    public partial class ConQuyDinh : DevExpress.XtraEditors.XtraForm
    {
        public ConQuyDinh()
        {
            InitializeComponent();
        }

        private void btnLuuAnh_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenHinh.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GNVB183\SQLEXPRESS;Initial Catalog=ShopChoMeo;Integrated Security=True");
                    con.Open();
                    string strCom = "INSERT INTO [ShopChoMeo].[dbo].[HinhNen]([TenHinh],[HinhAnh]) VALUES (@TenHinh,@HinhAnh)";
                    SqlCommand com = new SqlCommand(strCom, con);
                    com.Parameters.AddWithValue("@TenHinh", txtTenHinh.Text);
                    com.Parameters.AddWithValue("@HinhAnh", ChuyenThanhDangByte());
                    com.ExecuteNonQuery();
                    con.Close();
                    txtLinkAnh.Text = txtTenHinh.Text = "";
                    MessageBox.Show("Thay đổi hình đại diện thành công.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = OpenFileDialog1.Filter = "JPG files (*.jpg)|*.jpg|All files (*.*)|*.*";
            OpenFileDialog1.FilterIndex = 1;
            OpenFileDialog1.RestoreDirectory = true;
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = OpenFileDialog1.FileName;
                txtLinkAnh.Text = OpenFileDialog1.FileName;
            }
        }
        private byte[] ChuyenThanhDangByte()
        {
            FileStream fs;
            fs = new FileStream(txtLinkAnh.Text, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;
        }
    }
}
