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
    /// Interaction logic for DetailBills.xaml
    /// </summary>
    public partial class DetailBills : UserControl
    {
        public DetailBills()
        {
            InitializeComponent();
            hoadon.ItemsSource = GetDao.get_HoaDon();
        }
        private void eventchangehoadon(object sender, SelectedCellsChangedEventArgs e)
        {
            var sp = hoadon.SelectedItem as HoaDon;

            if (hoadon.SelectedIndex != -1)
            {
                var sq = GetDao.get_CTHD().Where(p => p.sohd.Equals(sp.Sohd));
                cthd.ItemsSource = sq;
            }
        }

        private void XoaBills(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Có chắc là bạn muốn xóa bỏ hóa đơn và chi tiết hóa đơn của nó", "Thông báo", MessageBoxButton.OKCancel);
            if (MessageBoxResult.OK == res)
            {

                if (hoadon.SelectedIndex != -1)
                {
                    int row = (hoadon.SelectedItem as HoaDon).Sohd;
                    var cthde = GetDao.get_CTHD().Where(p => p.sohd.Equals(row));

                    foreach (CTHD i in cthde) GetDao.delete_CTHD(i.id.ToString());

                    GetDao.delete_HoaDon(row.ToString());

                    hoadon.ItemsSource = GetDao.get_HoaDon();
                    cthd.ItemsSource = null;
                    MessageBox.Show("Xóa hóa đơn và chi tiết hóa đơn thành công");

                }
            }
        }

    }
}
