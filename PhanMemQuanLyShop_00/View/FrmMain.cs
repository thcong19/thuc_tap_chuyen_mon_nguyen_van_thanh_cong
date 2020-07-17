using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using PhanMemQuanLyShop_00.View;


namespace PhanMemQuanLyShop_00
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();
            InitSkinGallery();
        }
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }
        //Hiệt thị 1 form ở dạng cửa sổ
        public void OpenForm<T>()
        {
            var f = MdiChildren.FirstOrDefault(i => i is T); //Kiểm tra form có phải là T ko (cái T là tên form)
            if (f == null)
            {
                f = Activator.CreateInstance<T>() as Form;
                f.MdiParent = this;
                f.Show();
            }
            else f.Activate();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
 
            OpenForm<FrmTrangChu>();
            cmt.Caption = FrmDangNhap.LuuNguoiDangNhap.ten;
            if(cmt.Caption=="")
                cmt.Caption = "mèo méo meo mèo meo";
            else
            cmt.Caption = FrmDangNhap.LuuNguoiDangNhap.ten;
            if (FrmDangNhap.LuuNguoiDangNhap.quyen == "Nhân viên")
            {
                GrThongKeDoanhThu.Enabled=grThongKeNhapHang.Enabled=grThongKeNhapHang.Enabled=iFind.Enabled = iClose.Enabled = btnNhapKho.Enabled = btnNhaCungCap.Enabled = btnNhanVien.Enabled =btnChamCong.Enabled= false;
            
            }
            
        }

        private void btnThoatCt_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn thoát khỏi phầm mềm không", "Thống báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Application.Exit();
            }
            else
                return;
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void iNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Bạn đang đăng nhập bằng tài khoản tên '"+cmt.Caption+"'","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void iSaveAs_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Hide();
            FrmDangNhap f = new FrmDangNhap();
            f.ShowDialog();
        }

        private void iSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<FrmTrangChu>();
        }

        private void iClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            ConXemTaiKhoan c = new ConXemTaiKhoan();
            c.ShowDialog();
        }

        private void iFind_ItemClick(object sender, ItemClickEventArgs e)
        {
            ConThayDoiTaiKhoan c = new ConThayDoiTaiKhoan();
            c.ShowDialog();
        }

        public void btnNhaCungCap_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConNhaCungCap>();
        }


        private void btnNhapKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConNhapKho>();
        }

        private void btnKhoHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConKhoHang>();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConNhanVien>();
        }

        private void btnDSNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConDanhSachNhanVien>();
        }

        private void btnBanHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConBanHang>();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConKyGoi>();
        }

        private void BanHangNhanh_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            OpenForm<ConBanHang>();
        }

        private void btnKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            ConKhachHang c = new ConKhachHang();
            c.ShowDialog();
        }

        private void btnKhachHangNhanh_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ConKhachHang c = new ConKhachHang();
            c.ShowDialog();
        }

        private void NhanVienNhanh_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            OpenForm<ConDanhSachNhanVien>();
        }

        private void barButtonItem4_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            ConPhieuMuaHang c = new ConPhieuMuaHang();
            c.ShowDialog();
        }

        private void btnPhanQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
        }
        public void DongButtun()
        {
            btnNhaCungCap.Enabled = false;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            ConHoaDon c = new ConHoaDon();
            c.ShowDialog();
        }

        private void btnDangLy_KyGoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            ConDangKy_KyGoi dk_KyGoi = new ConDangKy_KyGoi();
            dk_KyGoi.ShowDialog();
        }

        private void btnDichVu_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConDichVu>();
        }

        private void btnQuyDinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConQuyDinh>();
        }

        private void btnChinhSach_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConChinhSach>();
        }

        private void btnUuDai_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConUuDai>();
        }

        private void btnThongKeHangHoaTuan_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConThongKeHangTuan>();
        }

        private void btnThongKeHangHoaThang_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConThongKeHangThang>();
        }

        private void btnThongKeHangHoaNam_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConThongKeHangNam>();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            OpenForm<ConKyGoi>();
        }

        private void btnDanhSachKhach_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConDanhSachKhachHang>();
        }

        private void btnKhachHangThuongXuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConKhachHangThanThiet>();
        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConKhachHangThuongXuyen>();
        }

        private void btnHangTonKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConHangTonKho>();
        }

        private void btnHangBanChay_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConHangBanChay>();
        }

        private void btnHangBanCham_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConHangBanCham>();
        }

        private void btnDoanhThuNgay_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConDoanhThuNgay>();
        }

        private void btnDoanhThuThang_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConDoanhThuThang>();
        }

        private void btnDoanhThuNam_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConDoanhThuTheoNam>();
        }

        private void btnHoaDon_ItemClick(object sender, ItemClickEventArgs e)
        {
            ConHoaDonKyGoi hd = new ConHoaDonKyGoi();
            hd.ShowDialog();
        }

        private void btnChamCong_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm<ConChamCong>();
        }

        private void btnThongBao_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ConThongBao tb = new ConThongBao();
            tb.ShowDialog();
        }

        private void btnProfile_ItemClick(object sender, ItemClickEventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau();
            dmk.ShowDialog();
        }
    }
}