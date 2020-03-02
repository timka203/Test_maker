using PublicLibrary.lip;
using System;
using System.Collections.Generic;
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

namespace Test_maker
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        User user = new User();
        private DbContext db = new DbContext(MainWindow.path);
        public RegWindow( User user=null)
        {
            InitializeComponent();
            
                if (user!=null)
                {
                    this.user = user;
                    Login.Text = user.Login;
                    tbxUserName.Text = user.UserName;
                    lblpass.Visibility = Visibility.Hidden;
                    pbPassword.Visibility = Visibility.Hidden;
                    BtnRegistrate.Content = "Обновить";
                }
            
        }

        private void BtnRegistrate_Click(object sender, RoutedEventArgs e)
        {
 
            user.Login = Login.Text;
            if (user.Id == 0)
            {
                user.Password = pbPassword.Password;
            }
            user.UserName = tbxUserName.Text;
            if (user.Id!=0)
            {
                db.DeleteUser(user);
            }

            if (db.RegUser(user))
            {
                MainWindow mw = new MainWindow(user);
                mw.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Упс!!!");
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(user);
            mainWindow.Show();
            this.Close();
        }
    }
}