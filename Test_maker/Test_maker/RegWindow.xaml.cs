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
        private DbContext db = new DbContext(MainWindow.path);
        public RegWindow()
        {
            InitializeComponent();
        }

        private void BtnRegistrate_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.Login = Login.Text;
            user.Password = pbPassword.Password;
            user.UserName = tbxUserName.Text;
  

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
    }
}