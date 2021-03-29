using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CIPO_app
{
    /// <summary>
    /// Interaction logic for Bill.xaml
    /// </summary>
    public partial class Bill : UserControl
    {

        public BindingList<SanPham> listcart;
        UserControl thanhtoan, hoadon;
        Button xuat;
        Border listhoadon;
        DateTime d = DateTime.Now;
        public Bill(BindingList<SanPham> cartlist, UserControl tt, Button x, Border lsthoadon, UserControl save)
        {
            InitializeComponent();
            listcart = cartlist;
            BillPrint.ItemsSource = cartlist;
            total.Text = cartlist.Sum(p => p.gia * p.Soluong).ToString()+".00 $";
            timebill.Content = d.ToString();
            thanhtoan = tt;
            xuat = x;
            listhoadon = lsthoadon;
            hoadon = save;
        }

        private void Event_bill(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if(btn.Name == "xoadon")
            {
                listcart.Clear();
                BillPrint.ItemsSource = null;
                thanhtoan.Content = null;
            }
            else
            {
                luuvaxuat.Visibility = Visibility.Hidden;
                xoadon.Visibility = Visibility.Hidden;
                xuat.Visibility = Visibility.Hidden;
                listhoadon.Child = null;

                var formatday = d.ToString("yyyy-MM-dd");
                float tongtien = float.Parse(total.Text.Substring(0, total.Text.Length - 5));
                GetDao.insert_HoaDon(formatday, tongtien);
                int idhd = GetDao.get_HoaDon().LastOrDefault().Sohd;
                AddDonhang(idhd);
                MessageBox.Show("Thêm hóa đơn và chi tiết hóa đơn thành công");

                Total.cart_cipos.Clear();
                hoadon.Content = new DetailBills();

            }
        }

        void AddDonhang(int idhoadon)
        {
            foreach (SanPham i in listcart)
            {
                GetDao.insert_CTHD(idhoadon.ToString(), i.Masp.ToString(), i.Soluong.ToString());
            }
        }
    }
}
