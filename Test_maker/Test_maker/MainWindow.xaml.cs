using System;
using System.Collections.Generic;
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
using Microsoft.Win32;
using PublicLibrary.lip;
namespace Test_maker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static User user = new User();
        Button but = new Button();


        public MainWindow()
        {
            InitializeComponent();
  
            foreach (var item in db.GetAllTests())
            {

                tests.Items.Add(item.Descriprtion);
            }
           
           
          
        }
        public MainWindow(User User = null)
        {
            InitializeComponent();
            user = User;
            foreach (var item in db.GetAllTests())
            {

                tests.Items.Add(item.Descriprtion);
            }
            if (user.Id != 0)
            {
                spuser.Children.Clear();
                btncrttest.Visibility = Visibility.Visible;
                exadmin.Visibility = Visibility.Visible;



            }
          



        }

        public static string path = @"D:/MyData.db";
        private DbContext db = new DbContext(path);

        private void Btncrttest_Click(object sender, RoutedEventArgs e)
        {
            CreateTest createTest = new CreateTest(user);
            createTest.Show();
            this.Close();
        }

        private void Tests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Test test = new Test();
            test = db.GetTest(tests.SelectedValue.ToString());
        TestView testview = new TestView(test,user); 
            testview.Show();
            this.Close();
          

        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            RegWindow regWindow = new RegWindow();
            regWindow.Show();
            this.Close();
        }

        private void Reguser_Click(object sender, RoutedEventArgs e)
        {
            RegUser rg = new RegUser();
            rg.Show();
            this.Close();
        }

        private void GetUser_Click(object sender, RoutedEventArgs e)
        {
            RegWindow regWindow = new RegWindow(user);
            regWindow.Show();
            this.Close();

        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings button = new Settings(user);
            button.Show();
            this.Close();
        }
    }
}
