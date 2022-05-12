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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
namespace WpfApp29
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Connection con = new Connection();
        string username, password;
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textbox1.Text != "" && textbox2.Text != "")
                {
                    con.Open();
                    string query = "select username,password from login1 WHERE username ='" + textbox1.Text + "' AND password ='" + textbox2.Text + "'";
                    MySqlDataReader row;
                    row = con.ExecuteReader(query);
                    if (row.HasRows)
                    {
                        while (row.Read())
                        {

                            username = row["username"].ToString();
                            password = row["password"].ToString();

                        }
                        System.Windows.MessageBox.Show("Введите другой пароль");
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Данные не найдены", "!");
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = @"Insert into login1 (username,password)values('" + textbox1.Text + "', '" + textbox2.Text + "')";
                }
            }
            catch
            {
                System.Windows.MessageBox.Show("Успешно)", "!");
                MainWindow l = new MainWindow();
                l.Show();
                this.Close();

            }
            }
         }
    }


