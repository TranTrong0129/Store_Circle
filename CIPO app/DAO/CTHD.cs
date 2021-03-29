using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPO_app
{
    public class CTHD
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("id"));
            }
        }

        

        private int _sohd;
        public int sohd 
        {
            get { return _sohd; }
            set
            {
                _sohd = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("Sohd"));
            }
        }

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

        private int _soluong;
        public int soluong
        {
            get { return _soluong; }
            set
            {
                _soluong = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("Soluong"));
            }
        }

        public event PropertyChangedEventHandler
          PropertyChanged;
    }
}
