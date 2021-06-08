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
    /// Логика взаимодействия для addEditPavilions.xaml
    /// </summary>
    public partial class addEditPavilions : Page
    {
        private Pavilion item;
        public addEditPavilions(Pavilion Item)
        {
            InitializeComponent();
            item = Item;
            box1.Text = item.flor.ToString();
            box2.Text = item.name;
            box3.Text = item.squere.ToString();
            box4.Text = item.status;
            box5.Text = item.delta.ToString();
            box6.Text = item.price.ToString();
            DataContext = item;
        }
        public void del(object sender, object e)
        {
            box4.Text = "Удален";
        }
        public void save(object sender, object e)
        {

            Manager.connection.Open();
            string sqlExpression = String.Format("update places set floor=@flor, numPlace=@name, squere=@squere, status=@status, delta=@delta, price=@price where idPlace=@id");
            SqlCommand command = new SqlCommand(sqlExpression, Manager.connection);
            try
            {
                item.flor = Convert.ToInt32(box1.Text);
                item.name = box2.Text;
                item.squere = Convert.ToDouble(box3.Text);
                item.status = box4.Text;
                item.delta = Convert.ToDouble(box5.Text);
                item.price = Convert.ToDouble(box6.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Какое-то значение неправильного типа:\n" + ex.ToString());
            }
            command.Parameters.AddWithValue("@id", item.id);
            command.Parameters.AddWithValue("@flor", item.flor);
            command.Parameters.AddWithValue("@name", item.name);
            command.Parameters.AddWithValue("@squere", item.squere);
            command.Parameters.AddWithValue("@status", item.status);
            command.Parameters.AddWithValue("@delta", item.delta);
            command.Parameters.AddWithValue("@price", item.price);
            try
            {
                command.ExecuteNonQuery().ToString();
                MessageBox.Show("Успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обратитесь к администратору: " + ex.ToString());
            }

            Manager.connection.Close();

        }

        private void Rent3_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
