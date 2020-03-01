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
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        User user = new User();
        public Settings(User user)

        {
        
            InitializeComponent();
                this.user = user;
            string str = MainWindow.path;
            tbdb.Text = str;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput(tbdb,lbl))
            {
                MainWindow.path = tbdb.Text;
            }
         
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(user);
            mainWindow.Show();
            this.Close();
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
