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
    /// Логика взаимодействия для RegUser.xaml
    /// </summary>
    public partial class RegUser : Window
    {
        User user = new User();
        private DbContext db = new DbContext(MainWindow.path);
        public RegUser()
        {
            InitializeComponent();
            stUsers.DataContext = MainWindow.user;

        
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput(InputLogin, validateInputLogin))
            {
                MainWindow.user.Password = InputPassword.Password;
                user = db.GetUser(MainWindow.user);

                if (user != null)
                {
                    MainWindow mw = new MainWindow(user);
                    mw.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка авторизации");
                }
            }
        }

        private bool CheckInput(TextBox input, Label validLable)
        {
            if (string.IsNullOrWhiteSpace(input.Text))
            {
                validLable.Content = "Поля обязательное для заполнения!";
                validLable.Foreground = new SolidColorBrush(Colors.Red);
                return false;
            }
            else
            {
                validLable.Content = "";
                return true;
            }
        }
    }
    
}
