CREATE DATABASE DOAN4
USE DOAN4

CREATE TABLE SanPhamNuocHoa (
MaSanPham INT PRIMARY KEY,
TenSanPham NVARCHAR(50) NOT NULL,
MoTa NVARCHAR(100),
HinhAnh NVARCHAR(MAX),
Gia FLOAT NOT NULL,
SoLuong INT NOT NULL
);


CREATE TABLE KhachHang (
MaKhachHang INT PRIMARY KEY,
HoTen NVARCHAR(50) NOT NULL,
DiaChi NVARCHAR(100) NOT NULL,
SoDienThoai NVARCHAR(20) NOT NULL,
Email NVARCHAR(50)
);


create table tk(
idtk int identity (1000,1) primary key,
hoten nvarchar(100),
email nvarchar(100),
mk nvarchar(50),
sdt int(10),
diachi nvarchar(200)
)

CREATE TABLE DonHang (
MaDonHang INT PRIMARY KEY,
NgayDatHang DATE NOT NULL,
MaKhachHang INT NOT NULL,
DiaChiGiaoHang NVARCHAR(100) NOT NULL,
TongTien FLOAT NOT NULL,
FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
);
CREATE TABLE ChiTietDonHang (
MaDonHang INT,
MaSanPham INT,
SoLuong INT NOT NULL,
Gia FLOAT NOT NULL,
PRIMARY KEY (MaDonHang, MaSanPham),
FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang),
FOREIGN KEY (MaSanPham) REFERENCES SanPhamNuocHoa(MaSanPham)
);

INSERT INTO SanPhamNuocHoa VALUES (01,'NUOC HOA LOUIS VUITTON','HÀNG CHÍNH HÃNG','https://storage.beautyfulls.com/uploads-1/sg-press/600x/nuoc-hoa-louis-vuitton-nuit-de-feu-200ml-127294.webp','100',2)
INSERT INTO SanPhamNuocHoa VALUES (02,N'Nước Hoa Le Labo 33 100ml ','HÀNG CHÍNH HÃNG','https://storage.beautyfulls.com/uploads-1/sg-press/600x/nuoc-hoa-le-labo-33-100ml-127450.webp','200',1)

DELETE SanPhamNuocHoa WHERE MaSanPham = 02 

INSERT INTO KhachHang VALUES (125,N'LÒ VĂN MÕM',N'88B NGUYỄN SỸ SÁCH-Q.TÂN BÌNH-TPHCM','0981123123','momnhom69@gmail.com') 
INSERT INTO KhachHang VALUES (139,N'NGUYỄN VĂN KIÊN',N'263 NHÂN HÒA MỸ HÀO - HƯNG YÊN','0981123123','kienbety@gmail.com')
INSERT INTO KhachHang VALUES (192,N'LÒ VĂN MÕM',N'178 Phố Nguyễn Ngọc Ngạn- Nhân hòa - Mỹ hào','098231223','quatnguatruyphong@gmail.com')

INSERT INTO DONHANG VALUES (100,'03-19-2023',125,'101 Phố cũ - ân thi - hưng yên','200')
INSERT INTO DONHANG VALUES (101,'03-22-2023',125,'101 Phố mới - ân thi - hưng yên','400')

INSERT INTO ChiTietDonHang VALUES (100,01,1,200)
INSERT INTO ChiTietDonHang VALUES (101,02,1,300)


DROP TABLE ChiTietDonHang 
DROP TABLE DonHang
DROP TABLE KhachHang
DROP TABLE tk
DROP TABLE SanPhamNuocHoa


