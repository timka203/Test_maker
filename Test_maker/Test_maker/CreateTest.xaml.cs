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
using PublicLibrary.lip;

namespace Test_maker
{
    /// <summary>
    /// Логика взаимодействия для CreateTest.xaml
    /// </summary>
    public partial class CreateTest : Window
    {
     
        Test test = new Test();
        Question question = new Question();
        private DbContext db = new DbContext(MainWindow.path);
        User user = new User();

        public CreateTest(User User,Test test = null)
        {
            InitializeComponent();
            user = User;
            if(test!=null)
            {
                this.test = test;
                txtDes.Text = test.Descriprtion;
                foreach (var item in test.questions)
                {
                    lbtquest.Items.Add(new Label() { FontSize = 26, Content = item.quest_text });
                }
            }
            if (user.Id!=0)
            {
                spcb.IsEnabled = true;
                sptb.IsEnabled = true;

            }
        }
        private void Tests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            question = db.GetQuestion(test, lbtquest.SelectedValue.ToString().Substring(31));


            txtquest.Text = question.quest_text;
            txtans1.Text = question.answer1;
            txtans2.Text = question.answer2;
            txtans3.Text = question.answer3;
            txtans4.Text = question.answer4;
            if(user.Id!=0)
            {
                txprc.Text= question.price;
               
            }

        }
        private void BtnCrtTest_Click(object sender, RoutedEventArgs e)
        {
            DbContext db = new DbContext(MainWindow.path);
            test.Descriprtion = txtDes.Text;
            if (test.id != 0)
            {
                db.DeleteTest(test);

                db.RegTest(test);
                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                if (db.RegTest(test))
                {
                    MainWindow mainWindow = new MainWindow(user);
                    mainWindow.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("error");

                }
            }
                
        }

        private void Btn_add_quest_Click(object sender, RoutedEventArgs e)
        {
            Question Question = new Question();
            if (question.Id != 0)
            {
    
                Question.quest_text = txtquest.Text;
                Question.answer1 = txtans1.Text;
                Question.answer2 = txtans2.Text;
                Question.answer3 = txtans3.Text;
                Question.answer4 = txtans4.Text;
                Question.Id = question.Id;
                Question.price = txprc.Text;
                Question.right_answer = cbrghtans.SelectedItem.ToString();

                test.questions[question.Id-1] = Question;

                MessageBox.Show("successful");
            }
            else
            {

                Question.quest_text = txtquest.Text;
                Question.answer1 = txtans1.Text;
                Question.answer2 = txtans2.Text;
                Question.answer3 = txtans3.Text;
                Question.answer4 = txtans4.Text;
                Question.price = txprc.Text;
                Question.right_answer = cbrghtans.SelectedItem.ToString();

                test.questions.Add(Question);
                lbtquest.Items.Add(Question.quest_text);
            }
        
            txtans1.Clear();
            txtans2.Clear();
            txtans3.Clear();
            txtans4.Clear();
            txtquest.Clear();
            txprc.Clear();
            

        }
    }
}
