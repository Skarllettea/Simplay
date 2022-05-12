using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace WpfApp29
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          
        }

        private void login(object sender, MouseButtonEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
           
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SmtpClient Client = new SmtpClient();
            Client.Credentials = new NetworkCredential("vasya.pupkin@mail.ru","pupkin");
            Client.Host = "smtp.mail.ru";
            Client.Port = 587;
            Client.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("vasya.pupkin@mail.ru");
            mail.To.Add(new MailAddress("ek53084@gmail.com"));
            mail.Subject = Subject.Text;
            mail.IsBodyHtml = true;
            mail.Body = "Имя: " + nam.Text + "<br> " + "Фамилия: " + first.Text + "<br> " + Text1.Text;
            Client.Send(mail);
        }

        private void F_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
