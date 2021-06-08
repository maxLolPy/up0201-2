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
    /// Логика взаимодействия для Pavilions.xaml
    /// </summary>
    public partial class Pavilions : Page
    {
        public Pavilions(Market item)
        {
            InitializeComponent();
            item.pavilions = new List<Pavilion>();
            Manager.connection.Open();
            string sqlExpression = String.Format("SELECT dbo.places.* FROM dbo.markets INNER JOIN dbo.places ON dbo.markets.idMarket = dbo.places.idMarket WHERE(dbo.markets.idMarket = "+item.id+")");
            SqlCommand command = new SqlCommand(sqlExpression, Manager.connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                item.pavilions.Add(new Pavilion() { id = reader.GetInt32(0), idMarket = reader.GetInt32(1), name = reader.GetString(2), flor = reader.GetInt32(3), status = reader.GetString(4), squere = reader.GetDouble(5), price = reader.GetDouble(6), delta = reader.GetDouble(7) });
            }
            reader.Close();
            name.Content = item.name;
            status.Content = item.status;
            DataContext = item.pavilions;
            Manager.connection.Close();
        }
        public void EditBtn(object sender, object e)
        {
            Manager.frame.Navigate(new addEditPavilions((sender as Button).DataContext as Pavilion));
        }

    }
}
