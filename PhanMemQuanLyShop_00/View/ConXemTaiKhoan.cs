using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PhanMemQuanLyShop_00.Model;
using PhanMemQuanLyShop_00.Control;

namespace PhanMemQuanLyShop_00.View
{
    public partial class ConXemTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        XemTaiKhoanControl XemTkControl = new XemTaiKhoanControl();
        XemtaiKhoanMod XemTkMod = new XemtaiKhoanMod();
        public ConXemTaiKhoan()
        {
            InitializeComponent();
        }


        private void ConXemTaiKhoan_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtXemTk = new DataTable();
                dtXemTk = XemTkControl.HienThiDuLieu();
                gridXemTaiKhoan.DataSource = dtXemTk;
                gridView1.OptionsView.ShowGroupPanel = false; //xóa bỏ tiêu đề gridcontrol
                //gridView1.GroupPanelText = "Danh sách tài khoản"; Thay đổi nội dung tiêu đề gridcontrol
                labelControl1.Enabled = labelControl2.Enabled = labelControl3.Enabled = false;
                //
                txtTenTaiKhoan.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenDangNhap").ToString();
                txtMatKhau.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MatKhau").ToString();
                txtLoaiTk.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LoaiTaiKhoan").ToString();
            }
            catch { return; }
        }

        private void ConXemTaiKhoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtTenTaiKhoan.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenDangNhap").ToString();
            txtMatKhau.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MatKhau").ToString();
            txtLoaiTk.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LoaiTaiKhoan").ToString();

            /* một số cách lấy dữ liệu 1 dòng gán cho texbox
            textBox1.Text = gridView1.GetDataRow(e.FocusedRowHandle)["Tên cột"].ToString();
            textBox1.Text = gridView1.GetFocusedDataRow()["Tên cột"].ToString();
            textBox1.Text = (gridView1.GetFocusedRow() as DataRowView).Row["Tên cột"].ToString();          
            textBox1.Text = gridView1.GetFocusedRowCellValue("Tên cột").ToString();
                   lưu ý: bắt đúng sự kiện trong gridview RowClick (Click 1 hàng)
             */
        }
        //Nháy phải chuột để đồng bộ dữ liệu lên textbox
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            txtTenTaiKhoan.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenDangNhap").ToString();
            txtMatKhau.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MatKhau").ToString();
            txtLoaiTk.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LoaiTaiKhoan").ToString();
        }

    }
}