using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для Authorize.xaml
    /// </summary>
    public partial class Authorize : Window
    {
        //ApplicationContext localdb;
        public Authorize()
        {
            InitializeComponent();
            //localdb = new ApplicationContext();
        }

        private void Auth_Click(object sender, RoutedEventArgs e)
        {
            //List<User> userl = localdb.Users.ToList();
            //foreach(User user in userl) { 
            //if(user.Login == EnterLogin.Text && user.Password == EnterPass.Password)
            //    {
            //        MessageBox.Show("Вход выполнен");
            //    }
            //}
            string login = EnterLogin.Text;
            string pass = EnterPass.Password;
            User us = null;
            using (ApplicationContext db = new ApplicationContext()){
                us = db.Users.Where(i => (i.Login == login || i.Email == login ) && i.Password == pass).FirstOrDefault();
            }
            if(us != null)
            {
                MessageBox.Show("Вход выполнен");
                UserPageWindow userWin = new UserPageWindow();
                userWin.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Пользователь не найден");
        }

        private void RegPageButton(object sender, RoutedEventArgs e)
        {
            MainWindow regWin = new MainWindow();
            regWin.Show();
            this.Close();
        }
    }
}
