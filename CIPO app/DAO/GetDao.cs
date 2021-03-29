using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using MySql.Data.MySqlClient;

namespace CIPO_app
{
    public class GetDao
    {
        public static string conn = "server=localhost;database=data_cipo;uid=root;pwd=root";
        public static BindingList<SanPham> get_SanPham()
        {
            string currentFolder = AppDomain.CurrentDomain.BaseDirectory;
            var baseFolder = currentFolder.Substring(0, currentFolder.Length - 1);
            string directoryPath = baseFolder + @"\ImagesCake\";

            if (!System.IO.Directory.Exists(directoryPath))
                System.IO.Directory.CreateDirectory(directoryPath);


            string query = "SELECT * FROM SANPHAM";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query,con);
            MySqlDataReader reader = com.ExecuteReader();
            BindingList<SanPham> data_Cipos = new BindingList<SanPham>();


            var filename = currentFolder.Substring(0, currentFolder.Length - 10);
            var info = new FileInfo(filename);
            var folder = info.Directory;

            while (reader.Read())
            {
                SanPham data = new SanPham();
                data.Masp = (int)reader["Masp"];
                data.Tensp = (string)reader["Tensp"];
                data.gia = (float)reader["gia"];
                
                string avatar = (string)reader["Anhdaidien"];
                string avatarPath = folder + @"\ImagesCake\" + avatar;
                var avarInfo = new FileInfo(avatarPath);
                var newAvatar = Guid.NewGuid() + avarInfo.Extension;
                avarInfo.CopyTo(directoryPath + newAvatar);
                data.Anhdaidien = newAvatar;

                data.Maloai = (int)reader["Maloai"];
                var line = (string)reader["Anhsp"];
                var tokens = line.Split(new string[] { " - " }, StringSplitOptions.None);
                data.Anhsp = new BindingList<string>();
                data.Danhgiasao = (int)reader["Danhgiasao"];
                data.Soluong = (int)reader["Soluong"];
                data.MaNhaSx = (int)reader["ManhaSx"];
                foreach (var token in tokens)
                {
                    string imagePath =  folder + @"\ImagesCake\" + token;
                    var imgInfo = new FileInfo(imagePath);
                    var newName = Guid.NewGuid() + imgInfo.Extension;
                    imgInfo.CopyTo(directoryPath + newName);
                    
                    data.Anhsp.Add(newName);
                }

                data_Cipos.Add(data);

            }
            con.Close();
            return data_Cipos;
        }

        public static BindingList<SanPham> get_SanPham2()
        {
            string query = "SELECT * FROM SANPHAM";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            MySqlDataReader reader = com.ExecuteReader();
            BindingList<SanPham> data_Cipos = new BindingList<SanPham>();

            while (reader.Read())
            {
                SanPham data = new SanPham();
                data.Masp = (int)reader["Masp"];
                data.Tensp = (string)reader["Tensp"];
                data.gia = (float)reader["gia"];
                data.Anhdaidien = (string)reader["Anhdaidien"];
                data.Maloai = (int)reader["Maloai"];
                var line = (string)reader["Anhsp"];
                var tokens = line.Split(new string[] { " - " }, StringSplitOptions.None);
                data.Anhsp = new BindingList<string>();
                data.Danhgiasao = (int)reader["Danhgiasao"];
                data.Soluong = (int)reader["Soluong"];
                data.MaNhaSx = (int)reader["ManhaSx"];
                foreach (var token in tokens)
                {
                    data.Anhsp.Add(token);
                }

                data_Cipos.Add(data);

            }
            con.Close();
            return data_Cipos;
        }

        public static BindingList<CTHD> get_CTHD()
        {
            string query = "SELECT * FROM CHITIETHOADON";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            MySqlDataReader reader = com.ExecuteReader();
            var DataCTHD = new BindingList<CTHD>();
            while (reader.Read())
            {
                CTHD data = new CTHD();
                data.id = (int)reader["id"];
                data.sohd = (int)reader["Sohd"];
                data.Masp = (int)reader["Masp"];
                data.soluong = (int)reader["Soluong"];
                DataCTHD.Add(data);

            }
            con.Close();

            return DataCTHD;
        }

        public static BindingList<HoaDon> get_HoaDon()
        {
            string query = "SELECT * FROM HOADON";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            MySqlDataReader reader = com.ExecuteReader();
            var DataHoaDon = new BindingList<HoaDon>();
            while (reader.Read())
            {
                HoaDon data = new HoaDon();
                data.Sohd = (int)reader["Sohd"];
                data.Ngaymua = (DateTime)reader["Ngaymua"];
                data.Tongtien = (float)reader["Tongtien"];
                DataHoaDon.Add(data);

            }
            con.Close();

            return DataHoaDon;
        }


        public static BindingList<NhaSX> get_NhaSX()
        {
            string query = "SELECT * FROM NHASX";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            MySqlDataReader reader = com.ExecuteReader();
            var producers = new BindingList<NhaSX>();
            while (reader.Read())
            {
                NhaSX data = new NhaSX();
                data.id = (int)reader["ManhaSX"];
                data.tennhasx = (string)reader["TennhaSX"];
                producers.Add(data);

            }
            con.Close();

            return producers;
        }


        public static BindingList<LoaiSP> get_LoaiSp()
        {
            string query = "SELECT * FROM LOAISANPHAM";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            MySqlDataReader reader = com.ExecuteReader();
            var listtype = new BindingList<LoaiSP>();
            while (reader.Read())
            {
                LoaiSP data = new LoaiSP();
                data.id = (int)reader["Maloai"];
                data.tenloai = (string)reader["TenloaiSp"];
                listtype.Add(data);

            }
            con.Close();

            return listtype;
        }

        public static void insertSanPham(string tensp, string anhdaidien, string anhsp, string soluong, string gia ,string maloai, string nhasx, string diem)
        {
            string query = "INSERT INTO SANPHAM (tensp, gia, anhsp, anhdaidien, maloai, danhgiasao, soluong, manhasx)" +
                "VALUES('" + tensp + "','" + gia + "','" + anhsp + "','" + anhdaidien + "','" + maloai + "','" + diem + "','" + soluong + "', '"+ nhasx +"')";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public static void deleteSanPham(string masp)
        {
            string query = "DELETE FROM SANPHAM WHERE(Masp =" + masp + ")";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public static void updateSanPham(string masp, string tensp, string anhdaidien, string anhsp, string soluong, string gia, string maloai, string nhasx, string diem)
        {
            string query = "UPDATE SANPHAM SET " +
                "Tensp = '" + tensp + "', gia = " + gia + ", Anhsp = '" + anhsp +
                "', Anhdaidien = '" + anhdaidien + "', Maloai = '" + maloai +
                "', Danhgiasao = '" + diem + "', Soluong = '" + soluong + "', ManhaSX = '" + nhasx
                +
                "' WHERE Masp = "+ masp ;
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public static void insertLoaiSanPham(string tenloaisp)
        {
            string query = "INSERT INTO LOAISANPHAM (TenloaiSp) VALUES('" + tenloaisp + "')";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public static void deleteLoaiSanPham(string maloai)
        {
            string query = "DELETE FROM LOAISANPHAM WHERE(Maloai=" + maloai + ")";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public static void updateLoaiSanPham(string id, string tenloaisp)
        {
            string query = "UPDATE LOAISANPHAM SET " +
                "TenloaiSp = '" + tenloaisp
                +"' WHERE Maloai = " + id;
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public static void insertNhaSX(string tennhasx)
        {
            string query = "INSERT INTO NHASX (TennhaSX) VALUES('" + tennhasx + "')";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public static void deleteNhaSX(string id)
        {
            string query = "DELETE FROM NHASX WHERE(ManhaSX =" + id + ")";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public static void updateNhaSX(string id, string tennhasx)
        {
            string query = "UPDATE NHASX SET TennhaSX = '" + tennhasx + "'  WHERE ManhaSX = " + id;
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public static int checkNhaSX(string id)
        {
            int dem = 0;
            string query = "SELECT * FROM SANPHAM WHERE ManhaSX = " + id;
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            MySqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
                dem++;
            con.Close();
            return dem;
        }

        public static int checkLoaiSp(string id)
        {
            int dem = 0;
            string query = "SELECT * FROM SANPHAM WHERE Maloai = " + id;
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            MySqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
                dem++;
            con.Close();
            return dem;
        }

        public static void insert_CTHD(string sohd, string masp, string soluong)
        {
            string query = "INSERT INTO CHITIETHOADON (Sohd, Masp, Soluong) VALUES('" + sohd + "', '" + masp + "', '" + soluong + "')";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public static void delete_CTHD(string id)
        {
            string query = "DELETE FROM CHITIETHOADON WHERE(id =" + id + ")";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public static void update_CTHD(string id, string sohd, string masp, string  soluong)
        {
            string query = "UPDATE CHITIETHOADON SET" + "Sohd = " + sohd + "Masp = " + masp +"Soluong = " + soluong + " WHERE id = " + id; ;
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public static void insert_HoaDon(string ngaymua, float tongtien)
        {
            string query = "INSERT INTO HOADON (ngaymua, tongtien) VALUES('" + ngaymua + "', '" + tongtien + "')";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public static void delete_HoaDon(string id)
        {
            string query = "DELETE FROM HOADON WHERE(Sohd =" + id + ")";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public static void update_HoaDon(string sohd, string ngaymua, string tongtien)
        {
            string query = "UPDATE HOADON SET" + "ngaymua = " + ngaymua + "tongtien = " + tongtien + " WHERE id = " + sohd; ;
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand com = new MySqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}
