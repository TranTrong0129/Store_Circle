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
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Data.SqlClient;
using System.IO;

namespace CIPO_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Total
    {
        public static BindingList<SanPham> data_Cipos = new  BindingList<SanPham>();
        public static BindingList<SanPham> cart_cipos = new BindingList<SanPham>();
        public static BindingList<CTHD> DataCTHD;
        public static BindingList<HoaDon> DataHoaDon;
        public static BindingList<LoaiSP> listtype;
        public static BindingList<NhaSX> listNhaSX;
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Uri resourceUri = new Uri("../Images/close.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            var brush = new ImageBrush();
            brush.ImageSource = temp;
            Button.Background = brush;


        }

        //string pathfilecurrent;
        //string filename = "";
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(Total.data_Cipos.Count == 0)
            {
                Total.data_Cipos = GetDao.get_SanPham();
            }
            Total.DataCTHD = GetDao.get_CTHD();
            Total.DataHoaDon = GetDao.get_HoaDon();
            Total.listtype = GetDao.get_LoaiSp();
            Total.listNhaSX = GetDao.get_NhaSX();
            screen.Content = new Home();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void setting_Click(object sender, RoutedEventArgs e)
        {
            screen.Content = new Settings();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            screen.Content = new Home();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            screen.Content = new Create();
        }

        private void Chart_Click(object sender, RoutedEventArgs e)
        {
            screen.Content = new Chart_HD();
        }

        private void ADD_MENU(object sender, RoutedEventArgs e)
        {
            screen.Content = new Create();
        }

        private void HOME_MENU(object sender, RoutedEventArgs e)
        {
            screen.Content = new Home();
        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {
            screen.Content = new Cart();
        }
    }
}
