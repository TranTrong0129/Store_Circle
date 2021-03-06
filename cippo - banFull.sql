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
VALUES('Nh??n vi??n b??n th???i gian'),('Nh??n vi??n ch??nh'),('qu???n l??');

INSERT Data_Cipopo.Nhanvien (tennhanvien, diachi, sodt, machucvu)
VALUES('L?? A', 'Qu???n 3', '0932423432', 3),
('Nguy???n C', 'Qu???n 5', '0845435324', 2),
('Tr???n Th???a', 'Qu???n 10', '03242345', 3),
('B??i Ph?? L??m', 'Qu???n B??nh Th???nh', '0324325213', 1),
('Cao r??o', 'Qu???n G?? V???p', '0324325213', 3),
('Anh T??i', 'Qu???n 1', '0324325213', 1),
('?????c ?????', 'Qu???n 2', '0324325213', 3),
('Ti???n L??n', 'Qu???n 11', '0324325213', 1),
('ki??n C???', 'Qu???n T??n B??nh', '043242345', 2),
('M???t M???i', 'Qu???n 2', '045452343', 2);

INSERT Data_Cipopo.Chinhanh (tenchinhanh, diachi, sodt, idnguoiquanly)
VALUES('L?? V??n S???', 'Qu???n 3', '0910101011', 1),
('Nguy???n V??n C???', 'Qu???n 5', '0945345662', 3),
('3/2', 'Qu???n 10', '0436457234', 5),
('Ph?? L??m', 'Qu???n 6', '0234464573', 7);

INSERT Data_Cipopo.Luongcoban(maloainv, tienluong)
VALUES(1,20),(2,30),(3,100);

INSERT Data_Cipopo.NhaSX (tennhasx) 
VALUES ('Danisa'), ('Cosy'), ('Karo'), ('Noname'), ('Custas'),('Kinh ????'),('Oishi'),('Orion'),('Richese'),('Richy');

INSERT Data_Cipopo.Loaisanpham (tenloaisp) 
VALUES ('Th???c ??n ch??nh'),('B??nh'),('Th???c ??n nhanh'), ('N?????c gi???i kh??t'),('Tr??i c??y');


INSERT Data_Cipopo.Sanpham (tensp, gia, anhsp, anhdaidien, maloai, danhgiasao, soluong, manhasx) 
VALUES ('B??nh Quy B?? Danisa', 20, '1.1.jpg - 1.2.jpg - 1.3.jpg', '1.jpg',1,3,56,1),
('B??nh Quy Cosy', 15, '2.1.jpg', '2.jpg',1,5,56,2),
('B??nh Tr???ng t????i Karo', 35, '3.1.jpg - 3.2.jpg - 3.3.jpg', '3.jpg',1,5,76,3),
('B??nh B??ng Lan H??n Qu???c', 21, '4.1.jpg - 4.2.jpg', '4.jpg',1,5,65,4),
('B??nh B??ng Lan Custas', 17, '5.1.jpg - 5.2.jpg', '5.jpg',1,5,423,5),
('B??nh B??ng lan cu???n Solite', 40, '6.1.jpg - 6.2.jpg', '6.jpg',1,4,4234,6),
('Snack cua', 7, '7.1.jpg - 7.2.jpg', '7.jpg',2,4,4324,7),
('Snack B?? ?????', 6, '8.1.jpg - 8.2.jpg - 8.3.jpg - 8.4.jpg', '8.jpg',2,4,44,7),
('Choco-pie', 20, '9.1.jpg - 9.2.jpg - 9.3.jpg', '9.jpg',1,4,44,8),
('nabati', 5, '10.1.jpg - 10.2.jpg - 10.3.jpg', '10.jpg',1,4,44,9),
('H???p B??nh Richy', 62, '11.1.jpg - 11.2.jpg - 11.3.jpg', '11.jpg',1,4,44,10);

INSERT Data_Cipopo.MaLoaiThanhToan(tenloaithanhtoan)
VALUES ('Ti???n m???t'), ('Th???');

INSERT Data_Cipopo.Hoadon (ngaymua, tongtien, maloaithanhtoan, idnvthanhtoan)
VALUES ('2020-01-04', 40, 1, 2),('2020-01-03', 140,1,6),('2020-01-01', 45,1,9),('2020-01-02', 75,2,8);

INSERT Data_Cipopo.Chitiethoadon (sohd, masp, soluong) 
VALUES (1, 1, 2), (2, 3, 4), (2, 2, 3), (3, 2, 5);

