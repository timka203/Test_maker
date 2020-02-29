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
    /// Логика взаимодействия для TestView.xaml
    /// </summary>
    public partial class TestView : Window
    {
        Test test_local = new Test();
        User user = new User();
        public TestView(Test test, User User)
        {
            InitializeComponent();
            user = User;
             this.test_local = test;
            lbldes.Content = test.Descriprtion;
            foreach (var item in test.questions)
            {
                lbquest.Items.Add(new Label() { FontSize=26, Content = item.quest_text });
                lbquest.Items.Add(new Label() { FontSize=20, Content = item.answer1  });
                lbquest.Items.Add(new Label() { FontSize = 20, Content = item.answer2 });
                lbquest.Items.Add(new Label() { FontSize = 20, Content = item.answer3 });
                lbquest.Items.Add(new Label() { FontSize = 20, Content = item.answer4});
                lbquest.Items.Add(new Label() { FontSize = 20, Content = "---------------------------------" });
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateTest test = new CreateTest(user,test_local);
            test.Show();
            this.Close();


        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(user);
            mainWindow.Show();
            this.Close();
        }
    }
}
