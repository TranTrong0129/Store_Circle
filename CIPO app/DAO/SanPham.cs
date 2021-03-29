using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPO_app
{
    public class SanPham
    {
        private int _Masp;
        public int Masp
        {
            get { return _Masp; }
            set
            {
                _Masp = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("Masp"));
            }
        }

        private string _Tensp;
        public string Tensp
        {
            get { return _Tensp; }
            set
            {
                _Tensp = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("Tensp"));
            }
        }

        private float _gia;
        public float gia
        {
            get { return _gia; }
            set
            {
                _gia = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("gia"));
            }
        }

        private string _Anhdaidien;
        public string Anhdaidien
        {
            get { return _Anhdaidien; }
            set
            {
                _Anhdaidien = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("Anhdaidien"));
            }
        }

        public BindingList<string> _Anhsp;
        public BindingList<string> Anhsp
        {
            get { return _Anhsp; }
            set
            {
                _Anhsp = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("Anhsp"));
            }
        }

        private int _Maloai;
        public int Maloai
        {
            get { return _Maloai; }
            set
            {
                _Maloai = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("Maloai"));
            }
        }


        private int _Danhgiasao;
        public int Danhgiasao
        {
            get { return _Danhgiasao; }
            set
            {
                _Danhgiasao = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("Danhgiasao"));
            }
        }


        private int _Soluong;
        public int Soluong
        {
            get { return _Soluong; }
            set
            {
                _Soluong = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("Soluong"));
            }
        }


        private int _MaNhaSx;
        public int MaNhaSx
        {
            get { return _MaNhaSx; }
            set
            {
                _MaNhaSx = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("MaNhaSx"));
            }
        }
        public event PropertyChangedEventHandler
          PropertyChanged;
    }
}
