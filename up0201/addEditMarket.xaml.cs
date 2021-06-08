using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
    /// Логика взаимодействия для addEditMarket.xaml
    /// </summary>
    public partial class addEditMarket : Page
    {
        private Market item;
        public addEditMarket(Market Item)
        {
            InitializeComponent();
            item = Item;
            box1.Text = item.name;
            box2.Text = item.status;
            box3.Text = item.countPlaces.ToString();
            box4.Text = item.city;
            box5.Text = item.price.ToString();
            box6.Text = item.countPlaces.ToString();
            box7.Text = item.delta.ToString();
            DataContext = item;

            
        }
        public void del(object sender, object e)
        {
            box2.Text = "Удален";
        }
        public void save(object sender, object e)
        {
            
            Manager.connection.Open();
            string sqlExpression = String.Format("update markets set [name]=@name, [status]=@status, countPlaces=@count, city=@city, price=@price, dleta=@delta, flors = @flors, photo=@image where idMarket=@id");
            SqlCommand command = new SqlCommand(sqlExpression, Manager.connection);
            try
            {
                item.name = box1.Text;
                item.status = box2.Text;
                item.countPlaces = Convert.ToInt32(box3.Text);
                item.city = box4.Text;
                item.price = Convert.ToDouble(box5.Text);
                item.delta = Convert.ToDouble(box6.Text);
                item.flors = Convert.ToInt32(box7.Text);
            }catch(Exception ex)
            {
                MessageBox.Show("Какое-то значение неправильного типа:\n"+ex.ToString());
            }
            command.Parameters.AddWithValue("@id", item.id);
            command.Parameters.AddWithValue("@name", item.name);
            command.Parameters.AddWithValue("@status", item.status);
            command.Parameters.AddWithValue("@count", item.countPlaces);
            command.Parameters.AddWithValue("@city", item.city);
            command.Parameters.AddWithValue("@price", item.price);
            command.Parameters.AddWithValue("@delta", item.delta);
            command.Parameters.AddWithValue("@flors", item.flors);
            command.Parameters.AddWithValue("@image", item.photo);
            try
            {
                command.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обратитесь к администратору: "+ex.ToString());
            }
            
            Manager.connection.Close();
            
        } 
        public void newPhoto(object sender, object e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog()==true)
            {
                FileInfo file = new FileInfo(dlg.FileName);
                item.photo = File.ReadAllBytes(file.FullName);
            }
            
        }
        public void pavs(object sender, object e)
        {
            Manager.frame.Navigate(new Pavilions(item));
        }
    }
}
