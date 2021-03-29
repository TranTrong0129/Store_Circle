using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPO_app
{
    public class NhaSX
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("ManhaSX"));
            }
        }



        private string _tennhasx;
        public string tennhasx
        {
            get { return _tennhasx; }
            set
            {
                _tennhasx = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("TennhaSX"));
            }
        }

        public event PropertyChangedEventHandler
          PropertyChanged;
    }
}
