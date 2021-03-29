using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
using System.Windows.Shapes;

namespace CIPO_app
{
    /// <summary>
    /// Interaction logic for ConnectionString.xaml
    /// </summary>
    public partial class ConnectionString : Window
    {
        public ConnectionString()
        {
            InitializeComponent();
        }

        private void connectiondata_event(object sender, RoutedEventArgs e)
        {
            string conn = connecttring.Text;

            MySqlConnection con = new MySqlConnection(conn);
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("ConnectionString không đúng, làm ơn kiểm tra lại");
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                GetDao.conn = conn;
                MessageBox.Show("ConnectionString hợp lệ");

                var config = ConfigurationManager.AppSettings["ShowSplash"];
                if (config.ToLower() == "true")
                {
                    var screen = new Notification();
                    screen.Show();

                }
                else
                {
                    var main = new MainWindow();
                    main.Show();
                }
                this.Close();
            }
        }

    }
}
