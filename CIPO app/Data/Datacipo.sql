use master
go
if DB_ID('Data_Cipo') is not null
	drop database Data_Cipo
go
create database Data_Cipo
go

USE [Data_Cipo]
GO
/****** Object:  Table [dbo].[CTHD]    Script Date: 8/1/2020 4:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHD](
	[Sohd] [int] NOT NULL,
	[Masp] [int] NOT NULL,
	[Sl] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hoadon]    Script Date: 8/1/2020 4:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hoadon](
	[Sohd] [int] NOT NULL,
	[ngaymua] [date] NULL,
	[Total] [real] NULL,
 CONSTRAINT [PK_Hoadon] PRIMARY KEY CLUSTERED 
(
	[Sohd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sanpham]    Script Date: 8/1/2020 4:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sanpham](
	[Masp] [int] NOT NULL,
	[Tensp] [nvarchar](50) NULL,
	[Maker] [nvarchar](50) NULL,
	[Cost] [real] NULL,
	[Images] [nvarchar](50) NULL,
	[Avatar] [nvarchar](50) NULL,
	[Type] [int] NULL,
	[Point] [int] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_Sanpham] PRIMARY KEY CLUSTERED 
(
	[Masp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CTHD] ([Sohd], [Masp], [Sl]) VALUES (6, 101, 3)
INSERT [dbo].[CTHD] ([Sohd], [Masp], [Sl]) VALUES (1, 102, 2)
INSERT [dbo].[CTHD] ([Sohd], [Masp], [Sl]) VALUES (3, 106, 2)
INSERT [dbo].[CTHD] ([Sohd], [Masp], [Sl]) VALUES (9, 103, 2)
INSERT [dbo].[Hoadon] ([Sohd], [ngaymua], [Total]) VALUES (1, CAST(N'2020-01-04' AS Date), 540326)
INSERT [dbo].[Hoadon] ([Sohd], [ngaymua], [Total]) VALUES (3, CAST(N'2020-01-03' AS Date), 100000)
INSERT [dbo].[Hoadon] ([Sohd], [ngaymua], [Total]) VALUES (6, CAST(N'2020-01-01' AS Date), 3000000)
INSERT [dbo].[Hoadon] ([Sohd], [ngaymua], [Total]) VALUES (9, CAST(N'2020-01-02' AS Date), 4000000)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Maker], [Cost], [Images], [Avatar], [Type], [Point], [Quantity]) VALUES (100, N'Bánh Quy Bơ Danisa', N'Danisa', 256, N'001_1.jpg - 001_2.jpg - 001_3.jpg', N'001.jpg',2,3,56)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Maker], [Cost], [Images], [Avatar], [Type], [Point], [Quantity]) VALUES (101, N'Bánh Quy Cosy', N'Cosy', 14099, N'002_1.jpg', N'002.jpg',1,5,56)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Maker], [Cost], [Images], [Avatar], [Type], [Point], [Quantity]) VALUES (102, N'Bánh Trứng tươi Karo', N'Karo', 34000, N'003_1.jpg - 003_2.jpg - 003_3.jpg', N'003.jpg',1,5,76)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Maker], [Cost], [Images], [Avatar], [Type], [Point], [Quantity]) VALUES (103, N'Bánh Bông Lan Hàn Quốc', N'Noname', 21000, N'004_1.jpg - 004_2.jpg', N'004.jpg',3,5,65)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Maker], [Cost], [Images], [Avatar], [Type], [Point], [Quantity]) VALUES (104, N'Bánh Bông Lan Custas', N'Custas', 17000, N'005_1.jpg - 005_2.jpg', N'005.jpg',2,5,423)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Maker], [Cost], [Images], [Avatar], [Type], [Point], [Quantity]) VALUES (105, N'Bánh Bông lan cuộn Solite', N'Kinh Đô', 40000, N'006_1.jpg - 006_2.jpg', N'006.jpg',2,4,4234)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Maker], [Cost], [Images], [Avatar], [Type], [Point], [Quantity]) VALUES (106, N'Snack cua', N'Oishi', 7000, N'007_1.jpg - 007_2.jpg', N'007.jpg',1,4,4324)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Maker], [Cost], [Images], [Avatar], [Type], [Point], [Quantity]) VALUES (108, N'Sanck Bí Đỏ', N'Oishi', 6000, N'008_1.jpg - 008_2.jpg - 008_3.jpg - 008_4.jpg', N'008.jpg',1,4,44)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Maker], [Cost], [Images], [Avatar], [Type], [Point], [Quantity]) VALUES (109, N'Choco-pie', N'Orion', 20000, N'009_1.jpg - 009_2.jpg - 009_3.jpg', N'009.jpg',2,4,44)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Maker], [Cost], [Images], [Avatar], [Type], [Point], [Quantity]) VALUES (110, N'nabati', N'Richese', 5000, N'010_1.jpg - 010_2.jpg - 010_3.jpg', N'010.jpg',1,4,44)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Maker], [Cost], [Images], [Avatar], [Type], [Point], [Quantity]) VALUES (111, N'Hộp Bánh Richy', N'Richy', 62000, N'011_1.jpg - 011_2.jpg - 011_3.jpg', N'011.jpg',2,4,44)
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_Hoadon] FOREIGN KEY([Sohd])
REFERENCES [dbo].[Hoadon] ([Sohd])
GO
ALTER TABLE [dbo].[CTHD] CHECK CONSTRAINT [FK_CTHD_Hoadon]
GO
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_Sanpham] FOREIGN KEY([Masp])
REFERENCES [dbo].[Sanpham] ([Masp])
GO
ALTER TABLE [dbo].[CTHD] CHECK CONSTRAINT [FK_CTHD_Sanpham]
GO
