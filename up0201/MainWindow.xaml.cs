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

namespace up0201
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = @"HOME-PC", //PC-MAX\SQLEXPRESS HOME-PC\SQLEXPRESS
                    InitialCatalog = "up0201",
                    IntegratedSecurity = true
                };
                Manager.connection = new SqlConnection(builder.ConnectionString);
                Manager.mainFrame = mainFrame;
                Manager.mainFrame.Navigate(new mainPage());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                Application.Current.Shutdown();
            }
        }
    }
}
