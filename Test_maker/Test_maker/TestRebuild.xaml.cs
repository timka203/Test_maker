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
    /// Логика взаимодействия для TestRebuild.xaml
    /// </summary>
    public partial class TestRebuild : Window

    {
        Test test = new Test();
        Question question = new Question();
        User user = new User();
 
        public TestRebuild(Test test, User User)
        {
            InitializeComponent();
            user = User;
            this.test = test;
            lbldes.Content = test.Descriprtion;
            foreach (var item in test.questions)
            {
                lbquest.Items.Add(new Label() { FontSize = 26, Content = item.quest_text});
            }
        }
        private DbContext db = new DbContext(MainWindow.path);
        private void Tests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

     
             question= db.GetQuestion(test,lbquest.SelectedValue.ToString().Substring(31));
          
         
            txtquest.Text = question.quest_text;
            txtans1.Text = question.answer1;
            txtans2.Text = question.answer2;
            txtans3.Text = question.answer3;
            txtans4.Text = question.answer4;

        }
      

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Question Question = new Question();
            Question.quest_text = txtquest.Text;
            Question.answer1 = txtans1.Text;
            Question.answer2 = txtans2.Text;
            Question.answer3 = txtans3.Text;
            Question.answer4 = txtans4.Text;
            Question.Id = question.Id-1;
          
            test.questions[question.Id-1] = Question;

            MessageBox.Show("successful");
 

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.DeleteTest(test);

            db.RegTest(test);
            MainWindow mainWindow = new MainWindow(user);
            mainWindow.Show();
            this.Close();
        }
    }
}
