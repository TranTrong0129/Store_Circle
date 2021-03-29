using LiveCharts;
using LiveCharts.Definitions.Series;
using LiveCharts.Wpf;
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
    /// Interaction logic for Chart_HD.xaml
    /// </summary>
    public partial class Chart_HD : UserControl
    {
        public Chart_HD()
        {
            InitializeComponent();
            createChart();
        }

        void createChart()
        {
            List<double> values = new List<double>();
            for (int month = 1; month <= 12; month++)
            {
                double valu = 0;
                for (int index = 0; index < Total.DataHoaDon.Count; index++)
                {
                    if (Total.DataHoaDon[index].Ngaymua.Month == month)
                    {
                        valu += Total.DataHoaDon[index].Tongtien;
                    }
                }

                values.Add(valu);
            }

            Charts.Series.Add(new ColumnSeries
            {
                Title = "Month",
                Values = new ChartValues<double>(values)
            });

            Charts.AxisX.Add(new Axis
            {
                Title = "Month",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
            });

            Charts.AxisY.Add(new Axis
            {
                Title = "Total",
                LabelFormatter = value => value.ToString("C")
            });


            SeriesCollection series = new SeriesCollection();
            Dictionary<string, int> List_sp = new Dictionary<string, int>();

         
            foreach (SanPham i in Total.data_Cipos)
            {
                int tongtien = 0;
                string tensp = "";
                foreach (CTHD j in Total.DataCTHD)
                {
                    if(i.Masp == j.Masp)
                    {
                        tongtien += (int)i.gia * j.soluong;
                        tensp = i.Tensp;
                    }
                }
                if(tongtien != 0)
                {
                    List_sp.Add(tensp, tongtien);
                }
            }

            foreach (var l in List_sp)
            {

                series.Add(new PieSeries() { Title = l.Key , Values = new ChartValues<int> { l.Value }, DataLabels = true });
                pie.Series = series;
            }
            pie.LegendLocation = LegendLocation.Bottom;
            Totals.Content = "Tổng tiền của tất cả Sản phẩm đã được bán : " + List_sp.Values.Sum();
            ListCake.ItemsSource = Total.data_Cipos;
        }
    }
}
