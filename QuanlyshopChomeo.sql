USE [ShopChoMeo]
GO
/****** Object:  Table [dbo].[BanHangCombo]    Script Date: 7/10/2020 3:45:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BanHangCombo](
	[MaBanHang] [nchar](10) NOT NULL,
	[NgayBanHang] [date] NOT NULL,
	[MaKhachHang] [nchar](10) NOT NULL,
	[MaNhanVien] [nchar](10) NOT NULL,
 CONSTRAINT [PK_BanHangCombo] PRIMARY KEY CLUSTERED 
(
	[MaBanHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChamCong]    Script Date: 7/10/2020 3:45:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChamCong](
	[MaChamCong] [nchar](10) NOT NULL,
	[MaNhanVien] [nchar](10) NOT NULL,
	[TenNhanVien] [nvarchar](50) NOT NULL,
	[Thang] [nchar](10) NOT NULL,
	[Nam] [nchar](10) NOT NULL,
	[TangCa] [int] NOT NULL,
	[NghiLam] [int] NOT NULL,
	[LuongCung] [float] NOT NULL,
	[LuongNhan] [float] NOT NULL,
	[TienThuong] [float] NULL,
	[TienPhat] [float] NULL,
 CONSTRAINT [PK_ChamCong] PRIMARY KEY CLUSTERED 
(
	[MaChamCong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 7/10/2020 3:45:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaChiTietHoaDon] [nchar](10) NOT NULL,
	[MaBanHang] [nchar](10) NOT NULL,
	[MaHang] [nchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[GiaBan] [float] NOT NULL,
	[ThanhTien] [float] NOT NULL,
	[TenHang] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaChiTietHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietNhapKho]    Script Date: 7/10/2020 3:45:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietNhapKho](
	[MaChiTietNhap] [nchar](10) NOT NULL,
	[GoiHang] [nvarchar](50) NOT NULL,
	[MaNhap] [nchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[GiaNhap] [float] NOT NULL,
 CONSTRAINT [PK_ChiTietNhapKho] PRIMARY KEY CLUSTERED 
(
	[MaChiTietNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChuongKyGoi]    Script Date: 7/10/2020 3:45:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuongKyGoi](
	[MaChuong] [nchar](10) NOT NULL,
	[TenChuong] [nchar](10) NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_KyGoi] PRIMARY KEY CLUSTERED 
(
	[MaChuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DangNhap]    Script Date: 7/10/2020 3:45:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangNhap](
	[TenDangNhap] [nchar](30) NOT NULL,
	[MatKhau] [nchar](30) NOT NULL,
	[LoaiTaiKhoan] [nchar](10) NOT NULL,
 CONSTRAINT [PK_DangNhap] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HangHoa]    Script Date: 7/10/2020 3:45:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangHoa](
	[MaHang] [nchar](10) NOT NULL,
	[TenHang] [nvarchar](50) NOT NULL,
	[DonVi] [nchar](10) NOT NULL,
	[LoaiHang] [nvarchar](50) NOT NULL,
	[MaChiTietNhap] [nchar](10) NOT NULL,
	[GiaBan] [float] NOT NULL,
	[SoLuongHang] [bigint] NULL,
 CONSTRAINT [PK_HangHoa] PRIMARY KEY CLUSTERED 
(
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HinhNen]    Script Date: 7/10/2020 3:45:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HinhNen](
	[TenHinh] [nchar](10) NOT NULL,
	[HinhAnh] [image] NOT NULL,
 CONSTRAINT [PK_HinhNen] PRIMARY KEY CLUSTERED 
(
	[TenHinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 7/10/2020 3:45:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [nchar](10) NOT NULL,
	[LienHe] [nvarchar](100) NULL,
	[TenDonVi] [nvarchar](100) NULL,
	[TheThanhVien] [nvarchar](50) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 7/10/2020 3:45:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNhaCungCap] [nchar](10) NOT NULL,
	[TenNhaCungCap] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[LienHe] [nvarchar](100) NOT NULL,
	[SoTaiKhoan] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNhaCungCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 7/10/2020 3:45:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [nchar](10) NOT NULL,
	[HoTen] [nvarchar](100) NULL,
	[CMND] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhapKho]    Script Date: 7/10/2020 3:45:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhapKho](
	[MaNhap] [nchar](10) NOT NULL,
	[MaNhaCungCap] [nchar](10) NOT NULL,
	[NgayNhap] [date] NOT NULL,
 CONSTRAINT [PK_NhapKho] PRIMARY KEY CLUSTERED 
(
	[MaNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThanhToanKyGoi]    Script Date: 7/10/2020 3:45:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThanhToanKyGoi](
	[MaThanhToanKG] [nchar](10) NOT NULL,
	[ThanhTien] [float] NOT NULL,
	[MaNhanVien] [nchar](10) NOT NULL,
	[TienPhat] [float] NULL,
	[GiaComBoTT] [nchar](10) NOT NULL,
	[NgayLap] [date] NOT NULL,
	[MaChuong] [nchar](10) NOT NULL,
	[MaThongTinKyGoi] [nchar](10) NOT NULL,
	[MaNVThanhToan] [nchar](10) NOT NULL,
 CONSTRAINT [PK_ThanhToanKyGoi] PRIMARY KEY CLUSTERED 
(
	[MaThanhToanKG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinKyGoi]    Script Date: 7/10/2020 3:45:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinKyGoi](
	[MaThongTinKyGui] [nchar](10) NOT NULL,
	[TenChu] [nvarchar](50) NOT NULL,
	[LienHe] [nvarchar](100) NOT NULL,
	[CMND] [nvarchar](50) NOT NULL,
	[TenThuCung] [nvarchar](50) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[NgayGoi] [date] NOT NULL,
	[NgayTra] [date] NOT NULL,
	[GiaComBo] [nchar](10) NOT NULL,
	[MaNhanVien] [nchar](10) NOT NULL,
	[TenChuong] [nchar](10) NOT NULL,
	[GiayTo] [nvarchar](100) NULL,
 CONSTRAINT [PK_ThongTinKyGoi] PRIMARY KEY CLUSTERED 
(
	[MaThongTinKyGui] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BanHangCombo]  WITH CHECK ADD  CONSTRAINT [FK_BanHangCombo_KhachHang1] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BanHangCombo] CHECK CONSTRAINT [FK_BanHangCombo_KhachHang1]
GO
ALTER TABLE [dbo].[BanHangCombo]  WITH CHECK ADD  CONSTRAINT [FK_BanHangCombo_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BanHangCombo] CHECK CONSTRAINT [FK_BanHangCombo_NhanVien]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_BanHangCombo1] FOREIGN KEY([MaBanHang])
REFERENCES [dbo].[BanHangCombo] ([MaBanHang])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_BanHangCombo1]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HangHoa1] FOREIGN KEY([MaHang])
REFERENCES [dbo].[HangHoa] ([MaHang])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HangHoa1]
GO
ALTER TABLE [dbo].[ChiTietNhapKho]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietNhapKho_NhapKho] FOREIGN KEY([MaNhap])
REFERENCES [dbo].[NhapKho] ([MaNhap])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietNhapKho] CHECK CONSTRAINT [FK_ChiTietNhapKho_NhapKho]
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [FK_HangHoa_ChiTietNhapKho1] FOREIGN KEY([MaChiTietNhap])
REFERENCES [dbo].[ChiTietNhapKho] ([MaChiTietNhap])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [FK_HangHoa_ChiTietNhapKho1]
GO
ALTER TABLE [dbo].[NhapKho]  WITH CHECK ADD  CONSTRAINT [FK_NhapKho_NhaCungCap1] FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([MaNhaCungCap])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NhapKho] CHECK CONSTRAINT [FK_NhapKho_NhaCungCap1]
GO
ALTER TABLE [dbo].[ThanhToanKyGoi]  WITH CHECK ADD  CONSTRAINT [FK_ThanhToanKyGoi_ChuongKyGoi] FOREIGN KEY([MaChuong])
REFERENCES [dbo].[ChuongKyGoi] ([MaChuong])
GO
ALTER TABLE [dbo].[ThanhToanKyGoi] CHECK CONSTRAINT [FK_ThanhToanKyGoi_ChuongKyGoi]
GO
ALTER TABLE [dbo].[ThongTinKyGoi]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinKyGoi_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[ThongTinKyGoi] CHECK CONSTRAINT [FK_ThongTinKyGoi_NhanVien]
GO
