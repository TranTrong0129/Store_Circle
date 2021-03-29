using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPO_app
{
    public class HoaDon
    {
        private int _Sohd;
        public int Sohd
        {
            get { return _Sohd; }
            set
            {
                _Sohd = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("Sohd"));
            }
        }

        private DateTime _Ngaymua;
        public DateTime Ngaymua
        {
            get { return _Ngaymua; }
            set
            {
                _Ngaymua = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("ngaymua"));
            }
        }

        private float _Tongtien;
        public float Tongtien
        {
            get { return _Tongtien; }
            set
            {
                _Tongtien = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("tongtien"));
            }
        }

        public event PropertyChangedEventHandler
          PropertyChanged;
    }
}
