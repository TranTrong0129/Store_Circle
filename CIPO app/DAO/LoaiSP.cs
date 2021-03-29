using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPO_app
{
    public class LoaiSP
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("Maloai"));
            }
        }



        private string _tenloai;
        public string tenloai
        {
            get { return _tenloai; }
            set
            {
                _tenloai = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("TenloaiSp"));
            }
        }

        public event PropertyChangedEventHandler
          PropertyChanged;
    }
}
