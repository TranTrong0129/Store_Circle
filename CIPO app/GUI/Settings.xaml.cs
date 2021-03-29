using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var config = ConfigurationManager.AppSettings["ShowSplash"];
            if (config.ToLower() == "false")
            {
                var configue = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configue.AppSettings.Settings["ShowSplash"].Value = "True";
                configue.Save(ConfigurationSaveMode.Modified);

            }
        }
    }
}
