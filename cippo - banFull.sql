create database Data_Cipopo;

CREATE TABLE IF NOT EXISTS Data_Cipopo.LoaiNhanvien(
	idcv int NOT NULL AUTO_INCREMENT,
	chucVu VARCHAR(255) CHARSET utf8mb4,
    PRIMARY KEY(idcv)
);

CREATE TABLE IF NOT EXISTS Data_Cipopo.Nhanvien(
	idnv int NOT NULL AUTO_INCREMENT,
	tennhanvien VARCHAR(255) CHARSET utf8mb4,
	diachi VARCHAR(255) CHARSET utf8mb4,
    sodt VARCHAR(11),
    machucvu int,
    
    PRIMARY KEY(idnv),
	FOREIGN KEY (machucvu) REFERENCES LoaiNhanvien (idcv)
);

CREATE TABLE IF NOT EXISTS Data_Cipopo.Chinhanh(
	idcn int NOT NULL AUTO_INCREMENT,
	tenchinhanh VARCHAR(255) CHARSET utf8mb4 ,
	diachi VARCHAR(255) CHARSET utf8mb4,
    sodt VARCHAR(11),
    idnguoiquanly int,
    
    PRIMARY KEY(idcn),
	FOREIGN KEY (idnguoiquanly) REFERENCES Nhanvien (idnv)
);

CREATE TABLE IF NOT EXISTS Data_Cipopo.Luongcoban(
	id int NOT NULL AUTO_INCREMENT,
    maloainv int,
	tienluong int ,
    
    PRIMARY KEY(id),
    FOREIGN KEY (maloainv) REFERENCES loainhanvien (idcv)
);

CREATE TABLE IF NOT EXISTS Data_Cipopo.Lichlamviec(
	id int NOT NULL AUTO_INCREMENT,
	manv int ,
    macn int,
	giobatdau date,
    gioketthuc date,
    
    PRIMARY KEY(id),
    FOREIGN KEY (manv) REFERENCES Nhanvien (idnv),
    FOREIGN KEY (macn) REFERENCES Chinhanh (idcn)
);


CREATE TABLE IF NOT EXISTS Data_Cipopo.Loaisanpham(
	maloai int NOT NULL AUTO_INCREMENT,
    tenloaiSp VARCHAR(255) CHARSET utf8mb4,
    
	PRIMARY KEY(maloai)
);

CREATE TABLE IF NOT EXISTS Data_Cipopo.NhaSX(
	manhasx int NOT NULL AUTO_INCREMENT,
    tennhasx   varchar(255) CHARSET utf8mb4,
    
	PRIMARY KEY(manhasx)
);

CREATE TABLE IF NOT EXISTS Data_Cipopo.Sanpham(
	masp int NOT NULL AUTO_INCREMENT,
	tensp varchar(255) CHARSET utf8mb4,
	gia int,
	anhsp varchar(255) CHARSET utf8mb4,
	anhdaidien varchar(50) CHARSET utf8mb4,
	maloai int,
	danhgiasao int,
	soluong int,
    manhasx int,
   
    PRIMARY KEY(masp),
    FOREIGN KEY (maloai) REFERENCES Loaisanpham (maloai),
	FOREIGN KEY (manhasx) REFERENCES nhaSX (manhasx)
);

CREATE TABLE IF NOT EXISTS Data_Cipopo.MaLoaiThanhToan(
	idmaloai int NOT NULL AUTO_INCREMENT,
    tenloaithanhtoan varchar(255) CHARSET utf8mb4,
    
    PRIMARY KEY(idmaloai)
);

CREATE TABLE IF NOT EXISTS Data_Cipopo.Hoadon(
	sohd int NOT NULL AUTO_INCREMENT,
	ngaymua datetime,
	tongtien int,
    maloaithanhtoan int, 
    idnvthanhtoan int,
    
    PRIMARY KEY(sohd),
    FOREIGN KEY (idnvthanhtoan) REFERENCES Nhanvien (idnv),
    FOREIGN KEY (maloaithanhtoan) REFERENCES MaLoaiThanhToan (idmaloai)
);

CREATE TABLE IF NOT EXISTS Data_Cipopo.Chitiethoadon(
	id INT NOT NULL AUTO_INCREMENT,
	sohd int,
	masp int,
	soluong int,
    
    PRIMARY KEY(id),
    FOREIGN KEY (sohd) REFERENCES Hoadon (sohd),
    FOREIGN KEY (masp) REFERENCES Sanpham (masp)
);

INSERT Data_Cipopo.LoaiNhanvien (chucVu)
VALUES('Nhân viên bán thời gian'),('Nhân viên chính'),('quản lý');

INSERT Data_Cipopo.Nhanvien (tennhanvien, diachi, sodt, machucvu)
VALUES('Lê A', 'Quận 3', '0932423432', 3),
('Nguyễn C', 'Quận 5', '0845435324', 2),
('Trần Thừa', 'Quận 10', '03242345', 3),
('Bùi Phú Lâm', 'Quận Bình Thạnh', '0324325213', 1),
('Cao ráo', 'Quận Gò Vấp', '0324325213', 3),
('Anh Tài', 'Quận 1', '0324325213', 1),
('Đức Độ', 'Quận 2', '0324325213', 3),
('Tiến Lên', 'Quận 11', '0324325213', 1),
('kiên Cố', 'Quận Tân Bình', '043242345', 2),
('Mệt Mỏi', 'Quận 2', '045452343', 2);

INSERT Data_Cipopo.Chinhanh (tenchinhanh, diachi, sodt, idnguoiquanly)
VALUES('Lê Văn Sỹ', 'Quận 3', '0910101011', 1),
('Nguyễn Văn Cừ', 'Quận 5', '0945345662', 3),
('3/2', 'Quận 10', '0436457234', 5),
('Phú Lâm', 'Quận 6', '0234464573', 7);

INSERT Data_Cipopo.Luongcoban(maloainv, tienluong)
VALUES(1,20),(2,30),(3,100);

INSERT Data_Cipopo.NhaSX (tennhasx) 
VALUES ('Danisa'), ('Cosy'), ('Karo'), ('Noname'), ('Custas'),('Kinh Đô'),('Oishi'),('Orion'),('Richese'),('Richy');

INSERT Data_Cipopo.Loaisanpham (tenloaisp) 
VALUES ('Thức ăn chính'),('Bánh'),('Thức ăn nhanh'), ('Nước giải khát'),('Trái cây');


INSERT Data_Cipopo.Sanpham (tensp, gia, anhsp, anhdaidien, maloai, danhgiasao, soluong, manhasx) 
VALUES ('Bánh Quy Bơ Danisa', 20, '1.1.jpg - 1.2.jpg - 1.3.jpg', '1.jpg',1,3,56,1),
('Bánh Quy Cosy', 15, '2.1.jpg', '2.jpg',1,5,56,2),
('Bánh Trứng tươi Karo', 35, '3.1.jpg - 3.2.jpg - 3.3.jpg', '3.jpg',1,5,76,3),
('Bánh Bông Lan Hàn Quốc', 21, '4.1.jpg - 4.2.jpg', '4.jpg',1,5,65,4),
('Bánh Bông Lan Custas', 17, '5.1.jpg - 5.2.jpg', '5.jpg',1,5,423,5),
('Bánh Bông lan cuộn Solite', 40, '6.1.jpg - 6.2.jpg', '6.jpg',1,4,4234,6),
('Snack cua', 7, '7.1.jpg - 7.2.jpg', '7.jpg',2,4,4324,7),
('Snack Bí Đỏ', 6, '8.1.jpg - 8.2.jpg - 8.3.jpg - 8.4.jpg', '8.jpg',2,4,44,7),
('Choco-pie', 20, '9.1.jpg - 9.2.jpg - 9.3.jpg', '9.jpg',1,4,44,8),
('nabati', 5, '10.1.jpg - 10.2.jpg - 10.3.jpg', '10.jpg',1,4,44,9),
('Hộp Bánh Richy', 62, '11.1.jpg - 11.2.jpg - 11.3.jpg', '11.jpg',1,4,44,10);

INSERT Data_Cipopo.MaLoaiThanhToan(tenloaithanhtoan)
VALUES ('Tiền mặt'), ('Thẻ');

INSERT Data_Cipopo.Hoadon (ngaymua, tongtien, maloaithanhtoan, idnvthanhtoan)
VALUES ('2020-01-04', 40, 1, 2),('2020-01-03', 140,1,6),('2020-01-01', 45,1,9),('2020-01-02', 75,2,8);

INSERT Data_Cipopo.Chitiethoadon (sohd, masp, soluong) 
VALUES (1, 1, 2), (2, 3, 4), (2, 2, 3), (3, 2, 5);

