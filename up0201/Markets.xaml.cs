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
    /// Логика взаимодействия для Markets.xaml
    /// </summary>
    public partial class Markets : Page
    {

        public Markets()
        {

            List<Market> markets = new List<Market>();
            InitializeComponent();

            Manager.connection.Open();
            string sqlExpression = String.Format("SELECT * FROM markets WHERE not (status = 'Удален')");
            SqlCommand command = new SqlCommand(sqlExpression, Manager.connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                markets.Add(new Market(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetDouble(5), (!reader.IsDBNull(6)) ? reader.GetDouble(6) : 0, reader.GetInt32(7), (byte[])reader["photo"]));
            }
            reader.Close();
            Manager.connection.Close();
            DataContext = markets;
        }

        public void EditBtn(object sender, object e)
        {
            Manager.frame.Navigate(new addEditMarket((sender as Button).DataContext as Market));
        }
    }
}
