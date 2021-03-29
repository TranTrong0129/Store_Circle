create database Data_Cipopo;

CREATE TABLE IF NOT EXISTS Data_Cipopo.loaisanpham(
	Maloai int NOT NULL AUTO_INCREMENT,
    TenloaiSp VARCHAR(255) CHARSET utf8mb4,
    
	PRIMARY KEY(Maloai)
);

CREATE TABLE IF NOT EXISTS Data_Cipopo.NhaSX(
	ManhaSX int NOT NULL AUTO_INCREMENT,
    TennhaSX   varchar(255) CHARSET utf8mb4,
    
	PRIMARY KEY(ManhaSX)
);

CREATE TABLE IF NOT EXISTS Data_Cipopo.sanpham(
	Masp int NOT NULL AUTO_INCREMENT,
	Tensp varchar(255) CHARSET utf8mb4,
	gia float,
	Anhsp varchar(255) CHARSET utf8mb4,
	Anhdaidien varchar(50) CHARSET utf8mb4,
	Maloai int,
	Danhgiasao int,
	Soluong int,
    ManhaSX int,
   
    PRIMARY KEY(Masp),
    FOREIGN KEY (Maloai) REFERENCES loaisanpham (Maloai),
	FOREIGN KEY ManhaSX REFERENCES nhasx ManhaSX 
);

CREATE TABLE IF NOT EXISTS Data_Cipopo.hoadon(
	Sohd int NOT NULL AUTO_INCREMENT,
	ngaymua datetime,
	tongtien int
    
    PRIMARY KEY(Sohd)
);

CREATE TABLE IF NOT EXISTS Data_Cipopo.chitiethoadon(
	id INT NOT NULL AUTO_INCREMENT,
	Sohd int,
	Masp int,
	Soluong int,
    
    PRIMARY KEY(id),
    FOREIGN KEY (Sohd) REFERENCES hoadon (Sohd),
    FOREIGN KEY (Masp) REFERENCES sanpham (Masp)
);

INSERT Data_Cipopo.NhaSX (tennhasx) 
VALUES ('Danisa'), ('Cosy'), ('Karo'), ('Noname'), ('Custas'),('Kinh Đô'),('Oishi'),('Orion'),('Richese'),('Richy');

INSERT Data_Cipopo.Loaisanpham (tenloaisp) 
VALUES ('Thức ăn chính'),('Bánh'),('Thức ăn nhanh'), ('Nước giải khát'),('Trái cây');


INSERT Data_Cipopo.Sanpham (tensp, gia, anhsp, anhdaidien, maloai, danhgiasao, soluong, manhasx) 
VALUES ('Bánh Quy Bơ Danisa', 20, '1.1.jpg - 1.2.jpg - 1.3.jpg', '1.jpg',2,3,56,1),
('Bánh Quy Cosy', 15, '2.1.jpg', '2.jpg',2,5,56,2),
('Bánh Trứng tươi Karo', 35, '3.1.jpg - 3.2.jpg - 3.3.jpg', '3.jpg',2,5,76,3),
('Bánh Bông Lan Hàn Quốc', 21, '4.1.jpg - 4.2.jpg', '4.jpg',2,5,65,4),
('Bánh Bông Lan Custas', 17, '5.1.jpg - 5.2.jpg', '5.jpg',2,5,423,5),
('Bánh Bông lan cuộn Solite', 40, '6.1.jpg - 6.2.jpg', '6.jpg',2,4,4234,6),
('Snack cua', 7, '7.1.jpg - 7.2.jpg', '7.jpg',3,4,434,7),
('Snack Bí Đỏ', 6, '8.1.jpg - 8.2.jpg - 8.3.jpg - 8.4.jpg', '8.jpg',3,4,44,7),
('Choco-pie', 20, '9.1.jpg - 9.2.jpg - 9.3.jpg', '9.jpg',1,4,44,8),
('nabati', 5, '10.1.jpg - 10.2.jpg - 10.3.jpg', '10.jpg',1,4,44,9),
('Hộp Bánh Richy', 62, '11.1.jpg - 11.2.jpg - 11.3.jpg', '11.jpg',1,4,44,10);

INSERT Data_Cipopo.Hoadon (ngaymua, tongtien, maloaithanhtoan, idnvthanhtoan)
VALUES ('2020-01-04', 40),('2020-01-03', 140),('2020-01-01', 45),('2020-01-02', 75);

INSERT Data_Cipopo.Chitiethoadon (sohd, masp, soluong) 
VALUES (1, 1, 2), (2, 3, 4), (2, 2, 3), (3, 2, 5);

