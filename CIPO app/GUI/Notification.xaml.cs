using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CIPO_app
{
    /// <summary>
    /// Interaction logic for Notification.xaml
    /// </summary>
    public partial class Notification : Window
    {
       
        public Notification()
        {
            InitializeComponent();

            step.Visibility = Visibility.Collapsed;

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(5);
            dt.Tick += Dt_Tick;
            dt.Start();

            Total.data_Cipos = GetDao.get_SanPham();
            var rand = new Random();
            var i = rand.Next(Total.data_Cipos.Count());

            var discount = (Total.data_Cipos[i].gia * 50) / 100;
            cost.Text = discount.ToString();
            this.DataContext = Total.data_Cipos[i];
            valueloading.Width = 950;
            Duration duration = new Duration(TimeSpan.FromSeconds(5));
            DoubleAnimation doubleanimation = new DoubleAnimation(100.0, duration);
            valueloading.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);

        }


        private int increment = 0;


        private void Dt_Tick(object sender, EventArgs e)
        {

            for (increment = 0; increment < 100; increment++)
            {
                if (increment == 99)
                {
                    step.Visibility = Visibility.Visible;
                }
            }

        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["ShowSplash"].Value = "False";
            config.Save(ConfigurationSaveMode.Modified);

            // Buoc thua
            ConfigurationManager.RefreshSection("AppSettings");
        }

     
        private void step_Click(object sender, RoutedEventArgs e)
        {
            
            var screen = new MainWindow();
            screen.Show();
           
        }
    }
}
