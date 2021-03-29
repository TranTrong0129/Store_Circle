using System;
using System.Collections.Generic;
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
using MySql.Data.MySqlClient;


namespace CIPO_app
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Tooltip : UserControl
    {
        SanPham spitem;
        Home homesp;
        public Tooltip(SanPham item, string nametool, Home home)
        {
            InitializeComponent();
            spitem = item;
            loaisp.ItemsSource = Total.listtype;
            NhaSX.ItemsSource = Total.listNhaSX;
            this.DataContext = item;
            tooltip.Content = nametool;
            loaisp.SelectedIndex = getindex(loaisp, item.Maloai);
            NhaSX.SelectedIndex = getindex(NhaSX, item.MaNhaSx);
            diemdgsp.SelectedIndex = item.Danhgiasao - 1;
            homesp = home;
        }


        int getindex(ComboBox combo, int value)
        {
            for (int i = 0; i < combo.Items.Count; i++)
            {
                if (combo.Name == "loaisp")
                {
                    var v = combo.Items[i] as LoaiSP;
                    if (v.id == value)
                        return i;
                }
                else if (combo.Name == "NhaSX")
                {
                    var v = combo.Items[i] as NhaSX;
                    if (v.id == value)
                        return i;
                }
            }
            return -1;
        }


        private void Event_button(object sender, RoutedEventArgs e)
        {
            if(tooltip.Content.ToString() == "Xóa")
            {
                try
                {
                    GetDao.deleteSanPham(spitem.Masp.ToString());
                    MessageBox.Show("Xóa sản phẩm thành công");
                    Ten.Text = soluong.Text = Gia.Text = null;
                    loaisp.SelectedItem = NhaSX.SelectedItem = diemdgsp.SelectedItem = null;
                    homesp.Data.ItemsSource = GetDao.get_SanPham();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sản Phẩm có liên quan đến chi tiết hóa đơn, " +
                        "không thể xóa nhanh được, Làm ơn thực hiện xóa CTHD trước khi xóa ", "Thông báo");
                }
            }
            else
            {
                try
                {
                    var ads = GetDao.get_SanPham2();
                    string id = spitem.Masp.ToString();
                    string ten = Ten.Text;
                    string sl = soluong.Text;
                    string giaa = Gia.Text;
                    string loai = (loaisp.SelectedValue as LoaiSP).id.ToString();
                    string nhasx = (NhaSX.SelectedValue as NhaSX).id.ToString();
                    string diem = (diemdgsp.SelectedValue as ComboBoxItem).Content.ToString();
                    string anhdaidien = ads.SingleOrDefault(p => p.Masp.ToString().Equals(id)).Anhdaidien;
                    string anhsp = string.Join(" - ", ads.SingleOrDefault(p => p.Masp.ToString().Equals(id)).Anhsp);
                    GetDao.updateSanPham(id, ten, anhdaidien, anhsp, sl, giaa, loai, nhasx, diem);
                    MessageBox.Show("Sửa sản phẩm thành công");
                    Ten.Text = soluong.Text = Gia.Text = null;
                    loaisp.SelectedItem = NhaSX.SelectedItem = diemdgsp.SelectedItem = null;

                }
                catch (Exception)
                {
                    MessageBox.Show("Kiểm tra lại thông tin sản phẩm");
                }
            }
        }
    }
}
