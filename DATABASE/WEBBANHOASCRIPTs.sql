USE [WebBanHoa]
GO
/****** Object:  Table [dbo].[ChiNhanh]    Script Date: 6/22/2020 7:24:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiNhanh](
	[MaChiNhanh] [int] NOT NULL,
	[MaNV] [int] NULL,
	[TenChiNhanh] [nchar](10) NULL,
	[DiaChi] [nchar](10) NULL,
	[NgayHoatDong] [datetime] NULL,
	[GiaThue] [datetime] NULL,
 CONSTRAINT [PK_ChiNhanh] PRIMARY KEY CLUSTERED 
(
	[MaChiNhanh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 6/22/2020 7:24:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[MaDH] [int] NOT NULL,
	[MaHoa] [int] NOT NULL,
	[SoTien] [money] NULL,
	[Soluong] [int] NULL,
	[GiamGia] [nchar](10) NULL,
 CONSTRAINT [PK_ChiTietDonHang_1] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC,
	[MaHoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 6/22/2020 7:24:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDH] [int] NOT NULL,
	[MaKH] [int] NULL,
	[MaNV] [int] NULL,
	[NgayDatHoa] [datetime] NULL,
	[NgayGiaoHoa] [datetime] NULL,
	[NgayNhan] [datetime] NULL,
	[DiaChiNhan] [nchar](10) NULL,
	[NguoiNhan] [nchar](10) NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hoa]    Script Date: 6/22/2020 7:24:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hoa](
	[MaHoa] [int] NOT NULL,
	[TenHoa] [nchar](10) NULL,
	[MaNcc] [int] NULL,
	[GiaMua] [money] NULL,
	[GiaBan] [money] NULL,
	[SoLuong] [int] NULL,
	[TonKho] [int] NULL,
	[Mota] [ntext] NULL,
 CONSTRAINT [PK_Hoa1] PRIMARY KEY CLUSTERED 
(
	[MaHoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 6/22/2020 7:24:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] NOT NULL,
	[HoKH] [nchar](10) NULL,
	[TenKH] [nchar](10) NULL,
	[GioiTinh] [nchar](10) NULL,
	[DiaChi] [nchar](10) NULL,
	[SDT] [int] NULL,
	[Fax] [int] NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 6/22/2020 7:24:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNcc] [int] NOT NULL,
	[TenNcc] [nchar](10) NULL,
	[DiaChi] [nchar](10) NULL,
	[SoDT] [int] NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNcc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 6/22/2020 7:24:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [int] NOT NULL,
	[HoNV] [nchar](10) NULL,
	[TenNV] [nchar](10) NULL,
	[GioiTinh] [nchar](10) NULL,
	[ChucVu] [nchar](10) NULL,
	[NgaySinh] [datetime] NULL,
	[NgayLam] [datetime] NULL,
	[SoCMND] [int] NULL,
	[DiaChi] [nchar](10) NULL,
	[HinhThe] [image] NULL,
	[Luong] [money] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[ChiNhanh] ([MaChiNhanh], [MaNV], [TenChiNhanh], [DiaChi], [NgayHoatDong], [GiaThue]) VALUES (100001, 4, N'Hoa CN2   ', N'3 Le Loi  ', CAST(N'2017-03-05T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[ChiNhanh] ([MaChiNhanh], [MaNV], [TenChiNhanh], [DiaChi], [NgayHoatDong], [GiaThue]) VALUES (100002, 1, N'Hoa CN1   ', N'1 QTrung  ', CAST(N'2016-02-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[ChiNhanh] ([MaChiNhanh], [MaNV], [TenChiNhanh], [DiaChi], [NgayHoatDong], [GiaThue]) VALUES (100003, 1, N'Hoa CN3   ', N'4PVTri    ', CAST(N'2018-10-10T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[ChiNhanh] ([MaChiNhanh], [MaNV], [TenChiNhanh], [DiaChi], [NgayHoatDong], [GiaThue]) VALUES (100004, 2, N'Hoa CN4   ', N'100 Le Loi', CAST(N'2018-10-10T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[ChiNhanh] ([MaChiNhanh], [MaNV], [TenChiNhanh], [DiaChi], [NgayHoatDong], [GiaThue]) VALUES (100005, 3, N'Hoa CN5   ', N'9Ngo Quyen', CAST(N'2018-10-10T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaHoa], [SoTien], [Soluong], [GiamGia]) VALUES (1111, 222, 320.0000, 4, NULL)
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaHoa], [SoTien], [Soluong], [GiamGia]) VALUES (1342, 666, 5345.0000, 66, NULL)
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaHoa], [SoTien], [Soluong], [GiamGia]) VALUES (2222, 111, 230.0000, 1, N'10        ')
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaHoa], [SoTien], [Soluong], [GiamGia]) VALUES (3321, 555, 985.0000, 13, NULL)
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaHoa], [SoTien], [Soluong], [GiamGia]) VALUES (3333, 444, 560.0000, 18, NULL)
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaHoa], [SoTien], [Soluong], [GiamGia]) VALUES (4444, 999, 123.0000, 4, NULL)
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaHoa], [SoTien], [Soluong], [GiamGia]) VALUES (5555, 777, 321.0000, 9, NULL)
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaHoa], [SoTien], [Soluong], [GiamGia]) VALUES (7899, 222, 431.0000, 2, NULL)
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaHoa], [SoTien], [Soluong], [GiamGia]) VALUES (98888, 333, 451.0000, 4, NULL)
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaHoa], [SoTien], [Soluong], [GiamGia]) VALUES (99999, 111, 544.0000, 1, NULL)
GO
INSERT [dbo].[DonHang] ([MaDH], [MaKH], [MaNV], [NgayDatHoa], [NgayGiaoHoa], [NgayNhan], [DiaChiNhan], [NguoiNhan]) VALUES (1111, 101, 4, CAST(N'2019-04-04T00:00:00.000' AS DateTime), CAST(N'2019-04-04T00:00:00.000' AS DateTime), CAST(N'2019-04-04T00:00:00.000' AS DateTime), N'312 QTrung', N'NguyenNam ')
INSERT [dbo].[DonHang] ([MaDH], [MaKH], [MaNV], [NgayDatHoa], [NgayGiaoHoa], [NgayNhan], [DiaChiNhan], [NguoiNhan]) VALUES (1342, 101, 1, CAST(N'2020-06-01T00:00:00.000' AS DateTime), CAST(N'2020-06-01T00:00:00.000' AS DateTime), CAST(N'2020-06-01T00:00:00.000' AS DateTime), N'1 PVT     ', N'Ton Ha    ')
INSERT [dbo].[DonHang] ([MaDH], [MaKH], [MaNV], [NgayDatHoa], [NgayGiaoHoa], [NgayNhan], [DiaChiNhan], [NguoiNhan]) VALUES (2222, 103, 2, CAST(N'2020-02-04T00:00:00.000' AS DateTime), CAST(N'2020-02-05T00:00:00.000' AS DateTime), CAST(N'2020-02-05T00:00:00.000' AS DateTime), N'123 LeLoi ', N'Le Thi    ')
INSERT [dbo].[DonHang] ([MaDH], [MaKH], [MaNV], [NgayDatHoa], [NgayGiaoHoa], [NgayNhan], [DiaChiNhan], [NguoiNhan]) VALUES (3321, 103, 2, CAST(N'2019-07-09T00:00:00.000' AS DateTime), CAST(N'2019-07-09T00:00:00.000' AS DateTime), CAST(N'2019-07-09T00:00:00.000' AS DateTime), N'Bthanh    ', N'Vo Le     ')
INSERT [dbo].[DonHang] ([MaDH], [MaKH], [MaNV], [NgayDatHoa], [NgayGiaoHoa], [NgayNhan], [DiaChiNhan], [NguoiNhan]) VALUES (3333, 104, 1, CAST(N'2020-04-06T00:00:00.000' AS DateTime), CAST(N'2020-04-06T00:00:00.000' AS DateTime), CAST(N'2020-04-06T00:00:00.000' AS DateTime), N'432 CH    ', N'Tran Duy  ')
INSERT [dbo].[DonHang] ([MaDH], [MaKH], [MaNV], [NgayDatHoa], [NgayGiaoHoa], [NgayNhan], [DiaChiNhan], [NguoiNhan]) VALUES (4444, 104, 2, CAST(N'2019-04-04T00:00:00.000' AS DateTime), CAST(N'2019-04-04T00:00:00.000' AS DateTime), CAST(N'2019-04-04T00:00:00.000' AS DateTime), N'1 Le Loi  ', N'TranNguyen')
INSERT [dbo].[DonHang] ([MaDH], [MaKH], [MaNV], [NgayDatHoa], [NgayGiaoHoa], [NgayNhan], [DiaChiNhan], [NguoiNhan]) VALUES (5555, 103, 4, CAST(N'2019-08-04T00:00:00.000' AS DateTime), CAST(N'2019-08-04T00:00:00.000' AS DateTime), CAST(N'2019-08-04T00:00:00.000' AS DateTime), N'3 Cu Chi  ', N'Dang Ton  ')
INSERT [dbo].[DonHang] ([MaDH], [MaKH], [MaNV], [NgayDatHoa], [NgayGiaoHoa], [NgayNhan], [DiaChiNhan], [NguoiNhan]) VALUES (7899, 104, 4, CAST(N'2019-06-01T00:00:00.000' AS DateTime), CAST(N'2019-06-01T00:00:00.000' AS DateTime), CAST(N'2019-06-01T00:00:00.000' AS DateTime), N'Bthanh    ', N'Hau       ')
INSERT [dbo].[DonHang] ([MaDH], [MaKH], [MaNV], [NgayDatHoa], [NgayGiaoHoa], [NgayNhan], [DiaChiNhan], [NguoiNhan]) VALUES (98888, 102, 3, CAST(N'2019-09-03T00:00:00.000' AS DateTime), CAST(N'2019-09-03T00:00:00.000' AS DateTime), CAST(N'2019-09-03T00:00:00.000' AS DateTime), N'Quan 12   ', N'Lanna     ')
INSERT [dbo].[DonHang] ([MaDH], [MaKH], [MaNV], [NgayDatHoa], [NgayGiaoHoa], [NgayNhan], [DiaChiNhan], [NguoiNhan]) VALUES (99999, 101, 1, CAST(N'2019-09-09T00:00:00.000' AS DateTime), CAST(N'2019-09-09T00:00:00.000' AS DateTime), CAST(N'2019-09-09T00:00:00.000' AS DateTime), N'TanBInh   ', N'Koll      ')
GO
INSERT [dbo].[Hoa] ([MaHoa], [TenHoa], [MaNcc], [GiaMua], [GiaBan], [SoLuong], [TonKho], [Mota]) VALUES (111, N'Hoa Hong  ', 101, 200.0000, 230.0000, 21, 2, NULL)
INSERT [dbo].[Hoa] ([MaHoa], [TenHoa], [MaNcc], [GiaMua], [GiaBan], [SoLuong], [TonKho], [Mota]) VALUES (121, N'Hoa Sen   ', 101, 333.0000, 363.0000, 4, 2, NULL)
INSERT [dbo].[Hoa] ([MaHoa], [TenHoa], [MaNcc], [GiaMua], [GiaBan], [SoLuong], [TonKho], [Mota]) VALUES (122, N'Hoa Phuong', 103, 111.0000, 130.0000, 76, 32, NULL)
INSERT [dbo].[Hoa] ([MaHoa], [TenHoa], [MaNcc], [GiaMua], [GiaBan], [SoLuong], [TonKho], [Mota]) VALUES (222, N'Hoa Lan   ', 102, 300.0000, 320.0000, 22, 3, NULL)
INSERT [dbo].[Hoa] ([MaHoa], [TenHoa], [MaNcc], [GiaMua], [GiaBan], [SoLuong], [TonKho], [Mota]) VALUES (333, N'Hoa Mai   ', 104, 320.0000, 360.0000, 43, 21, NULL)
INSERT [dbo].[Hoa] ([MaHoa], [TenHoa], [MaNcc], [GiaMua], [GiaBan], [SoLuong], [TonKho], [Mota]) VALUES (444, N'Hoa Dao   ', 103, 500.0000, 560.0000, 32, 3, NULL)
INSERT [dbo].[Hoa] ([MaHoa], [TenHoa], [MaNcc], [GiaMua], [GiaBan], [SoLuong], [TonKho], [Mota]) VALUES (555, N'Hoa Hue   ', 101, 700.0000, 780.0000, 4, 1, NULL)
INSERT [dbo].[Hoa] ([MaHoa], [TenHoa], [MaNcc], [GiaMua], [GiaBan], [SoLuong], [TonKho], [Mota]) VALUES (666, N'Hoa Quynh ', 104, 210.0000, 250.0000, 54, 43, NULL)
INSERT [dbo].[Hoa] ([MaHoa], [TenHoa], [MaNcc], [GiaMua], [GiaBan], [SoLuong], [TonKho], [Mota]) VALUES (777, N'Hoa Tulip ', 101, 543.0000, 550.0000, 432, 32, NULL)
INSERT [dbo].[Hoa] ([MaHoa], [TenHoa], [MaNcc], [GiaMua], [GiaBan], [SoLuong], [TonKho], [Mota]) VALUES (888, N'Hoa Cuc   ', 102, 432.0000, 450.0000, 99, 22, NULL)
INSERT [dbo].[Hoa] ([MaHoa], [TenHoa], [MaNcc], [GiaMua], [GiaBan], [SoLuong], [TonKho], [Mota]) VALUES (999, N'Hoa Cuc 2 ', 104, 460.0000, 600.0000, 54, 1, NULL)
GO
INSERT [dbo].[KhachHang] ([MaKH], [HoKH], [TenKH], [GioiTinh], [DiaChi], [SDT], [Fax]) VALUES (101, N'Tran      ', N'Huy       ', N'Nam       ', N'Tan Binh  ', 90000, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [HoKH], [TenKH], [GioiTinh], [DiaChi], [SDT], [Fax]) VALUES (102, N'Le        ', N'Tam       ', N'Nam       ', N'Quan 12   ', 90882, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [HoKH], [TenKH], [GioiTinh], [DiaChi], [SDT], [Fax]) VALUES (103, N'Vo        ', N'Thanh     ', N'Nu        ', N'Cu Chi    ', 98746, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [HoKH], [TenKH], [GioiTinh], [DiaChi], [SDT], [Fax]) VALUES (104, N'Trinh     ', N'Tram      ', N'Nu        ', N'Go Vap    ', 92121, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [HoKH], [TenKH], [GioiTinh], [DiaChi], [SDT], [Fax]) VALUES (105, N'Phuong    ', N'Oanh      ', N'Nu        ', N'Quan 1    ', 9090, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [HoKH], [TenKH], [GioiTinh], [DiaChi], [SDT], [Fax]) VALUES (106, N'Manh      ', N'Hung      ', N'Nam       ', N'Binh Thanh', 9890, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [HoKH], [TenKH], [GioiTinh], [DiaChi], [SDT], [Fax]) VALUES (107, N'Thu       ', N'Lan       ', N'Nu        ', N'Phu Nhuan ', 95567, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [HoKH], [TenKH], [GioiTinh], [DiaChi], [SDT], [Fax]) VALUES (108, N'Tri       ', N'Quang     ', N'Nam       ', N'Quan 3    ', 9212, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [HoKH], [TenKH], [GioiTinh], [DiaChi], [SDT], [Fax]) VALUES (109, N'Thuy      ', N'Dung      ', N'Nu        ', N'Go Vap    ', 9532, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [HoKH], [TenKH], [GioiTinh], [DiaChi], [SDT], [Fax]) VALUES (110, N'Phuong    ', N'Thanh     ', N'Nu        ', N'Quan 10   ', 9873, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [HoKH], [TenKH], [GioiTinh], [DiaChi], [SDT], [Fax]) VALUES (111, N'Cao       ', N'Nguyen    ', N'Nam       ', N'Quan 1    ', 1312, NULL)
GO
INSERT [dbo].[NhaCungCap] ([MaNcc], [TenNcc], [DiaChi], [SoDT]) VALUES (101, N'Hoa PP1   ', N'BinhThanh ', 988245)
INSERT [dbo].[NhaCungCap] ([MaNcc], [TenNcc], [DiaChi], [SoDT]) VALUES (102, N'Hoa PP2   ', N'TanBinh   ', 92222)
INSERT [dbo].[NhaCungCap] ([MaNcc], [TenNcc], [DiaChi], [SoDT]) VALUES (103, N'Hoa PP3   ', N'Cu Chi    ', 98882)
INSERT [dbo].[NhaCungCap] ([MaNcc], [TenNcc], [DiaChi], [SoDT]) VALUES (104, N'Hoa PP4   ', N'Hoc Mon   ', 97654)
INSERT [dbo].[NhaCungCap] ([MaNcc], [TenNcc], [DiaChi], [SoDT]) VALUES (105, N'HoaPP5    ', N'Quan 1    ', 90888)
INSERT [dbo].[NhaCungCap] ([MaNcc], [TenNcc], [DiaChi], [SoDT]) VALUES (106, N'Hoa PP6   ', N'Quan 12   ', 9843)
GO
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [ChucVu], [NgaySinh], [NgayLam], [SoCMND], [DiaChi], [HinhThe], [Luong]) VALUES (1, N'Tran      ', N'Phu       ', N'Nam       ', N'NV        ', CAST(N'1999-02-02T00:00:00.000' AS DateTime), CAST(N'2018-02-03T00:00:00.000' AS DateTime), 2, N'Hcm       ', NULL, 2.0000)
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [ChucVu], [NgaySinh], [NgayLam], [SoCMND], [DiaChi], [HinhThe], [Luong]) VALUES (2, N'Vo        ', N'Thuan     ', N'Nam       ', N'Truongban ', CAST(N'1999-03-03T00:00:00.000' AS DateTime), CAST(N'2019-03-03T00:00:00.000' AS DateTime), 323, N'Hcm       ', NULL, 30000.0000)
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [ChucVu], [NgaySinh], [NgayLam], [SoCMND], [DiaChi], [HinhThe], [Luong]) VALUES (3, N'Nguyen    ', N'Tram      ', N'Nu        ', N'NV        ', CAST(N'1999-04-04T00:00:00.000' AS DateTime), CAST(N'2016-04-04T00:00:00.000' AS DateTime), 34, N'HN        ', NULL, 20000.0000)
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [ChucVu], [NgaySinh], [NgayLam], [SoCMND], [DiaChi], [HinhThe], [Luong]) VALUES (4, N'Tran      ', N'Hau       ', N'Nam       ', N'NS        ', CAST(N'1998-06-08T00:00:00.000' AS DateTime), CAST(N'2016-06-08T00:00:00.000' AS DateTime), 432, N'DN        ', NULL, 2.0000)
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [ChucVu], [NgaySinh], [NgayLam], [SoCMND], [DiaChi], [HinhThe], [Luong]) VALUES (5, N'Nguyen    ', N'Hieu      ', N'Nam       ', N'QL        ', CAST(N'1999-07-05T00:00:00.000' AS DateTime), CAST(N'2020-01-02T00:00:00.000' AS DateTime), 432, N'VT        ', NULL, 4.0000)
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [ChucVu], [NgaySinh], [NgayLam], [SoCMND], [DiaChi], [HinhThe], [Luong]) VALUES (6, N'Kim       ', N'Hoa       ', N'Nu        ', N'TP        ', CAST(N'1999-01-05T00:00:00.000' AS DateTime), CAST(N'2020-01-02T00:00:00.000' AS DateTime), 543, N'BT        ', NULL, NULL)
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [ChucVu], [NgaySinh], [NgayLam], [SoCMND], [DiaChi], [HinhThe], [Luong]) VALUES (7, N'Phuong    ', N'Thao      ', N'Nu        ', N'NS        ', CAST(N'1999-05-08T00:00:00.000' AS DateTime), CAST(N'2019-03-03T00:00:00.000' AS DateTime), 434, N'DN        ', NULL, NULL)
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [ChucVu], [NgaySinh], [NgayLam], [SoCMND], [DiaChi], [HinhThe], [Luong]) VALUES (8, N'Ngoc      ', N'Tram      ', N'Nu        ', N'QL        ', CAST(N'1999-03-08T00:00:00.000' AS DateTime), CAST(N'2016-04-04T00:00:00.000' AS DateTime), 1156, N'Hcm       ', NULL, NULL)
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [ChucVu], [NgaySinh], [NgayLam], [SoCMND], [DiaChi], [HinhThe], [Luong]) VALUES (9, N'Le        ', N'Duc       ', N'Nam       ', N'TK        ', CAST(N'1999-08-08T00:00:00.000' AS DateTime), CAST(N'2019-03-03T00:00:00.000' AS DateTime), 3219, N'Vinh      ', NULL, NULL)
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [ChucVu], [NgaySinh], [NgayLam], [SoCMND], [DiaChi], [HinhThe], [Luong]) VALUES (10, N'Trung     ', N'Nhan      ', N'Nam       ', N'PP        ', CAST(N'1999-08-09T00:00:00.000' AS DateTime), CAST(N'2016-04-04T00:00:00.000' AS DateTime), 9074, N'HN        ', NULL, NULL)
GO
ALTER TABLE [dbo].[ChiNhanh]  WITH CHECK ADD  CONSTRAINT [FK_ChiNhanh_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[ChiNhanh] CHECK CONSTRAINT [FK_ChiNhanh_NhanVien]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_DonHang] FOREIGN KEY([MaDH])
REFERENCES [dbo].[DonHang] ([MaDH])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_DonHang]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_Hoa] FOREIGN KEY([MaHoa])
REFERENCES [dbo].[Hoa] ([MaHoa])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_Hoa]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_KhachHang]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_NhanVien]
GO
ALTER TABLE [dbo].[Hoa]  WITH CHECK ADD  CONSTRAINT [FK_Hoa_NhaCungCap] FOREIGN KEY([MaNcc])
REFERENCES [dbo].[NhaCungCap] ([MaNcc])
GO
ALTER TABLE [dbo].[Hoa] CHECK CONSTRAINT [FK_Hoa_NhaCungCap]
GO
