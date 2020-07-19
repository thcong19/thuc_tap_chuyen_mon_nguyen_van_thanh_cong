using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Data.SqlClient;
using PhanMemQuanLyShop_00.Controller;

namespace PhanMemQuanLyShop_00.View
{
    public partial class DoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        ThayDoiTaiKhoanControl ThayDoiTkControl = new ThayDoiTaiKhoanControl();
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        string path;
        private void btnTaiAnh_Click(object sender, EventArgs e)
        {
            path = Path.GetFullPath(Environment.CurrentDirectory);
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-GNVB183\SQLEXPRESS;Initial Catalog=ShopChoMeo;Integrated Security=True");
            try
            {
                string mkm = txtMNk.Text.Trim();
                string xnmk = txtXacNhan.Text.Trim();
                string mk = txtMatKhau.Text.Trim();
                conn.Open();
                string sql = "SELECT *FROM DangNhap where MatKhau='" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    if (!xnmk.Equals(mkm))
                    {
                        MessageBox.Show("Mật khẩu Xác nhận không trung với mật khẩu mới vui lòng kiểm trâ lại", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Question);

                    }
                    else
                    {
                        if (ThayDoiTkControl.SuaDuLieu(txtDangNhap.Text.Trim(), mkm, txtQuyen.Text))
                        {
                            MessageBox.Show("Đã thay đổi thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Không thể chỉnh sửa tên đăng nhập.", "Thông báo");
                    }
                }
                else { MessageBox.Show("Mật khẩu cũ không đúng vui lòng kiểm tra lại nếu quên mật khẩu vui lòng liên hệ với admin để được cấp mật khẩu mới ", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Question); }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            txtDangNhap.Text = FrmDangNhap.LuuNguoiDangNhap.ten;
            txtQuyen.Text = FrmDangNhap.LuuNguoiDangNhap.quyen;
            txtDangNhap.Enabled = false;
            txtQuyen.Enabled = false;
        }
    }
}