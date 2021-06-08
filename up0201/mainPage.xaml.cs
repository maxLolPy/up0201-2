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
    /// Логика взаимодействия для mainPage.xaml
    /// </summary>
     
    public partial class mainPage : Page
    {
        const int maxCountErr = 3;
        private int countErrLogin = 0;
        private Capcha capcha { get; set; }
        public mainPage()
        {
            InitializeComponent();
            capcha = new Capcha(canv);
        }
        public void login(object sender, object e)
        {
            if (capcha.compare(countErrLogin, maxCountErr) == 1)
            {
                //try
                //{
                    string sqlExpression = String.Format(" select * from typeUserByLogin ( @login, @pass ) ");
                    SqlCommand command = new SqlCommand(sqlExpression, Manager.connection);
                    command.Parameters.AddWithValue("@login", loginBox.Text);
                    command.Parameters.AddWithValue("@pass", pswdBox.Password);
                    Manager.connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Manager.im = new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetValue(9));
                    }
                    reader.Close();
                    Manager.connection.Close();
                    if (Manager.im == null)
                    {
                        countErrLogin++;
                        MessageBox.Show("Логин или пароль неверны.");
                    } else
                    {
                        Manager.mainFrame.Navigate(new userPage());
                    }
                    if (countErrLogin > 3)
                    {
                        capchaRow1.Height = new GridLength(80);
                    }
                //}
                //catch (Exception ex)
                /*{

                    MessageBox.Show(ex.ToString());
                    Application.Current.Shutdown();
                }*/
            }
            else
            {
                MessageBox.Show("Неправильный код с картинки");
                capcha.New();
            }
        }
    }
}
