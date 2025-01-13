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

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext localdb;   
        public MainWindow()
        {
            InitializeComponent();
            localdb = new ApplicationContext();
            

        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = TextboxLogin.Text.Trim();
            string pass = PasswordBox1.Password.Trim();
            string passRep = PasswordBox2.Password.Trim();
            string email = emailBox.Text.Trim().ToLower();



            if (login.Length < 5)
            {
                TextboxLogin.ToolTip = "Логин должен быть длиннее 5 символов";
                TextboxLogin.Background = Brushes.IndianRed;
            } else if(pass.Length < 8){
                PasswordBox1.ToolTip = "Пароль слишком короткий";
                PasswordBox1.Background = Brushes.IndianRed;
            }else if(pass != passRep)
            {
                PasswordBox2.ToolTip = "Пароли не совпадают";
                PasswordBox2.Background = Brushes.IndianRed;
            }
            else if (email.Length< 5 || !email.Contains("@") || !email.Contains("."))
            {
                emailBox.ToolTip = "Ошибка";
                emailBox.Background = Brushes.IndianRed;
            }
            else
            {
                emailBox.ToolTip = "";
                TextboxLogin.ToolTip = "";
                PasswordBox1.ToolTip = "";
                PasswordBox2.ToolTip = "";
                TextboxLogin.Background = Brushes.Transparent;
                PasswordBox1.Background = Brushes.Transparent;
                emailBox.Background = Brushes.Transparent;
                PasswordBox2.Background = Brushes.Transparent;

                User userObj = new User()
                {
                    Login = login,
                    Password = pass,
                    Email = email,

                };

                localdb.Users.Add(userObj);
                localdb.SaveChanges();
                MessageBox.Show("Пользователь создан");
            }


        }

        private void ButtonClickAuth(object sender, RoutedEventArgs e)
        {
            Authorize AuthWin = new Authorize();
            AuthWin.Show();
            this.Close();

        }
    }
}
