using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Show.xaml
    /// </summary>
    public partial class Show : UserControl
    {
        SanPham data;
        int numrecord = 1;
        int numpage1 = 0;
        int totalimages = 0;

        Label cart;
        public Show(int index, Label c)
        {

            data = travelidentificiton(index);
            
            InitializeComponent();

            Totalimage.Text = data.Anhsp.Count.ToString();
            this.DataContext = data;
            this.tenSX.Text = GetDao.get_NhaSX().SingleOrDefault(p => p.id.Equals(data.MaNhaSx)).tennhasx;
            ListImages.ItemsSource = Page1(numrecord, numpage1, data);
            cart = c;
        }


        public SanPham travelidentificiton(int id)
        {
            SanPham result = new SanPham();

            foreach (SanPham i in Total.data_Cipos)
            {
                if (id == i.Masp)
                {
                    result = i;
                }
            }

            return result;
        }

        private void nex_Click(object sender, RoutedEventArgs e)
        {
            int number = data.Anhsp.Count / numrecord;
            totalimages = data.Anhsp.Count / numrecord;
            if ((data.Anhsp.Count % numrecord) != 0)
            {
                number = number + 1;
                totalimages = totalimages + 1;
            }
            if (numpage1 < number - 1)
            {

                ListImages.ItemsSource = Page1(numrecord, numpage1 + 1, data);
                int tam = numpage1 + 1;
                if (tam != number)
                {
                    numpage1++;
                }
            }
            NumberImage.Text = (numpage1 + 1).ToString();
            Totalimage.Text = totalimages.ToString();
        }

        private void pre_Click(object sender, RoutedEventArgs e)
        {

            if (numpage1 - 1 >= 0)
            {
                ListImages.ItemsSource = Page1(numrecord, numpage1 - 1, data);
                if (numpage1 != 0)
                {
                    numpage1--;
                }
                NumberImage.Text = (numpage1 + 1).ToString();
                Totalimage.Text = totalimages.ToString();
            }
        }
        public static List<string> Page1(int element, int page, SanPham s)
        {
            return s.Anhsp.Skip(page * element).Take(element).ToList();
        }


        private void Booking(object sender, RoutedEventArgs e)
        {
            Total.cart_cipos.Add(data);
            cart.Content = Total.cart_cipos.Count.ToString();
        }
    }
}
