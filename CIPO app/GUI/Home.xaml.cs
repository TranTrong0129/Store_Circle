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

namespace CIPO_app
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {

        public Home()
        {
            InitializeComponent();
            DateTime time = DateTime.Now;
            this.clock.Text = time.ToString();
            DispatcherTimer Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
            Header.Text = "Tất cả";
            Data.ItemsSource = Total.data_Cipos;
            DataLoai.ItemsSource = Total.listtype;
        }

        private void Timer_Click(object sender, EventArgs e)
        {

            DateTime d;
            d = DateTime.Now;
            clock.Text = d.ToString();

        }

        private void Data_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;

            var id = (item as SanPham).Masp;
            var screen = new Show(id, NumberOder);
            screenshow.Content = screen;
        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Cart();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Header.Text = "Tất Cả";
            Data.ItemsSource = Total.data_Cipos;
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var value = Search.Text;
            var data_search = new List<SanPham>();
            data_search = Total.data_Cipos.Where(p => p.Tensp.ToLower().Contains(value.ToLower()) || p.MaNhaSx.ToString().Contains(value) || p.gia.ToString().Contains(value)).ToList();
            Data.ItemsSource = data_search;
        }

        private void Event_click(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;
            MenuItem m = (MenuItem)e.OriginalSource;

            if (m.Header.ToString() == "Delete")
            {
                var ite = (item as SanPham);
                var screen = new Tooltip(ite, "Xóa", this);
                screenshow.Content = screen;
            }
            else
            {
                var ite = (item as SanPham);
                var screen = new Tooltip(ite, "Cập nhật", this);
                screenshow.Content = screen;
            }  
        }

        void Filter_Sp(int maloai)
        {
            var datanew = new BindingList<SanPham>();

            if (maloai == 6)
            {
                for (int i = 0; i < Total.data_Cipos.Count; i++)
                {
                    int ii = Total.data_Cipos[i].Maloai;
                    if ( ii != 1 && ii != 2 && ii != 3 && ii != 4 && ii != 5)
                    {
                        datanew.Add(Total.data_Cipos[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < Total.data_Cipos.Count; i++)
                {
                    if (Total.data_Cipos[i].Maloai == maloai)
                    {
                        datanew.Add(Total.data_Cipos[i]);
                    }
                }
            }
            Data.ItemsSource = datanew;
        }

        void Type(int tag)
        {
            if (tag == 1)
            {
                Header.Text = "Thức Ăn chính";
                Filter_Sp(1);
            }
            else if (tag == 2)
            {
                Header.Text = "Các loại bánh";
                Filter_Sp(2);
            }
            else if (tag == 3)
            {
                Header.Text = "Thức Ăn Nhanh";
                Filter_Sp(3);
            }
            else if (tag == 4)
            {
                Header.Text = "Nước giải khát";
                Filter_Sp(4);
            }
            else if (tag == 5)
            {
                Header.Text = "Trái cây";
                Filter_Sp(5);
            }
            else
            {
                Header.Text = "Các loại khác";
                Filter_Sp(6);
            }
        }
        private void Type_Click(object sender, RoutedEventArgs e)
        {
            Button m = (Button)e.OriginalSource;
            int tag = int.Parse(m.Tag.ToString());
            Type(tag);
        }

        private void DataLoai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataLoai.SelectedItem != null)
            {
                LoaiSP lsp = (DataLoai.SelectedItem as LoaiSP);
                Search.Text = lsp.tenloai;
                Type(lsp.id);
            }
        }

        bool CheckCartDuplicated(SanPham data)
        {
            foreach (SanPham i in Total.cart_cipos)
            {
                if (i == data)
                {
                    return true;
                }
            }
            return false;
        }

        private void addBooking(object sender, MouseButtonEventArgs e)
        {
            var Sp = (Label)sender;
            SanPham data = Sp.DataContext as SanPham;

            if (Total.cart_cipos.Count == 0)
            {
                Total.cart_cipos.Add(data);
            }
            else
            {
                if(CheckCartDuplicated(data) != true)
                {
                    Total.cart_cipos.Add(data);
                }
            }

            NumberOder.Content = Total.cart_cipos.Count.ToString();
        }
    }
}
