using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : UserControl
    {

        List<TextBox> lstnamesl = new List<TextBox>();
        public Cart()
        {
            InitializeComponent();
            if (Total.cart_cipos.Count != 0)
                CreateLiistview(Total.cart_cipos);
            else
                thanhtoan.Visibility = Visibility.Hidden;
            
            savebill.Content = new DetailBills();
        }

        private void Xoacart_click(object sender, RoutedEventArgs e)
        {
            var m = (Button)sender;
            int idsp = int.Parse((m.Parent as StackPanel).Name.Substring(8));
            var data = Total.cart_cipos.SingleOrDefault(p => p.Masp.Equals(idsp));
            Total.cart_cipos.Remove(data);
            listBooks.Child = null;
            CreateLiistview(Total.cart_cipos);
        }

        private void PrintBill_Click(object sender, RoutedEventArgs e)
        {
            var total = Create_bill(Total.cart_cipos);
            screenbill.Content = new Bill(total, screenbill, thanhtoan, listBooks, savebill);
        }

        void CreateLiistview(BindingList<SanPham> listhd)
        {
            ListView lsv = new ListView();
            lsv.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled);
            foreach (SanPham i in listhd)
            {
                StackPanel stack = new StackPanel{Orientation = Orientation.Horizontal, Name = "Stacksp_"+i.Masp.ToString()};
                PackIcon packIcon = new PackIcon();

                stack.Children.Add(
                    new Label
                    {
                        Width = 200,
                        FontWeight = FontWeights.DemiBold,
                        Margin = new Thickness(5),
                        Content = i.Tensp
                    }
                );
                stack.Children.Add(
                    new Label
                    {
                        FontWeight = FontWeights.DemiBold,
                        Content = "SL: ",
                        Margin = new Thickness(10, 0, 10, 0)
                    });
                Border border = new Border
                {
                    Background = Brushes.White,
                    CornerRadius = new CornerRadius(3)
                };
                TextBox txt = new TextBox
                {
                    Text = "1",
                    Width = 80,
                    Height = 30,
                    Name =  "name_" + i.Masp.ToString(),
                    Foreground = Brushes.Black
                };
                border.Child = txt;
                lstnamesl.Add(txt);
                stack.Children.Add(border);
                
                Button btnXoa = new Button
                {
                    Background = Brushes.Transparent,
                    BorderThickness = new Thickness(0),
                    Foreground = Brushes.Black
                };
                packIcon.Kind = PackIconKind.Delete;
                btnXoa.Content = packIcon;
                btnXoa.Click += Xoacart_click;
                stack.Children.Add(btnXoa);
                lsv.Items.Add(stack);
            }
            listBooks.Child = lsv;

        }



        BindingList<SanPham> Create_bill(BindingList<SanPham> listsanPhams)
        {
            BindingList<SanPham> listsPs = new BindingList<SanPham>();
            int j = 0;
            foreach(SanPham i in listsanPhams)
            {
                SanPham data = new SanPham();
                data.Masp = i.Masp;
                data.Tensp = i.Tensp;
                data.gia = i.gia;
                data.Anhdaidien = i.Anhdaidien;
                data.Anhsp = i.Anhsp;
                data.Maloai = i.Maloai;
                data.Danhgiasao = i.Danhgiasao;
                data.Soluong = int.Parse(lstnamesl.ElementAt(j).Text);
                data.MaNhaSx = i.MaNhaSx;
                j++;

                listsPs.Add(data);
            }
            return listsPs;
        }
    }
}
