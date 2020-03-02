using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_maker;

namespace PublicLibrary.lip
{
    public class DbContext
    {
        public DbContext(string Path)
        {
            this.Path = Path;
        }

        private string Path { get; set; }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (var db = new LiteDatabase(Path))
            {
                users = db.GetCollection<User>("User").FindAll().ToList();
            }

            return users;
        }

        public User GetUser(string pass, string login)
        {
            User user = null;
            using (var db = new LiteDatabase(Path))
            {
                user = db.GetCollection<User>("User")
                         .FindOne(f => f.Login == login && f.Password == pass);
            }

            return user;
        }

       public User GetUser(User user)
        {
            using (var db = new LiteDatabase(Path))
            {
                user = db.GetCollection<User>("User")
                         .FindOne(f => f.Login == user.Login
                         && f.Password == user.Password);
                return user;
            }
        }

        public bool RegUser(User user)
        {

            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var users = db.GetCollection<User>("User");
                    users.Insert(user);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Test> GetAllTests()
        {
            List<Test> tests = new List<Test>();

            using (var db = new LiteDatabase(Path))
            {
                tests = db.GetCollection<Test>("Test").FindAll().ToList();
                foreach (var test in tests)
                {
                    List<Question> question = new List<Question>();
                    question = db.GetCollection<Question>("Question" + test.id.ToString()).FindAll().ToList();
                    //foreach (var item in question)
                    //{
                    //    int tmp = item.Id - 1;
                    //    item.answers = db.GetCollection<Answer>("Answer" + test.id.ToString() + "_" + tmp.ToString()).FindAll().ToList();

                    //}
                    test.questions = question;
                }
              
            }

            return tests;
        }

        public Test GetTest(string des)
        {
            Test test = null;
            using (var db = new LiteDatabase(Path))
            {
                test = db.GetCollection<Test>("Test")
                         .FindOne(f => f.Descriprtion == des);
                List<Question> question = new List<Question>();
                question = db.GetCollection<Question>("Question" + test.id.ToString()).FindAll().ToList();
                //foreach (var item in question)
                //{
                //    int tmp = item.Id - 1;
                //    item.answers = db.GetCollection<Answer>("Answer" + test.id.ToString() + "_" + tmp.ToString()).FindAll().ToList();
                //}
                test.questions = question;

            }

            return test;
        }
        public Question GetQuestion(Test test, string des)
        {
             Question quest = null;
            using (var db = new LiteDatabase(Path))
            {
                quest = db.GetCollection<Question>("Question"+ test.id.ToString())
                         .FindOne(f => f.quest_text == des);
    
            }

            return quest;
        }
        public bool DeleteTest(Test test)
        {
            {

                using (var db = new LiteDatabase(Path))
                {
                    if (db.CollectionExists("Test"))
                    {
                        var users = db.GetCollection<Test>("Test");
                        users.Delete( test.id);
                        db.DropCollection(("Question" + test.id));
                    }
                    else
                    {
                        return false;
                    }

                }

                return true;
            }


        }
        public bool DeleteUser(User user)
        {
            {

                using (var db = new LiteDatabase(Path))
                {
                    if (db.CollectionExists("User"))
                    {
                        var users = db.GetCollection<User>("User");
                        users.Delete(user.Id);
                  
                    }
                    else
                    {
                        return false;
                    }

                }

                return true;
            }

        }
        public bool DeleteQuestion(Test test,int id)
        {
            {

                using (var db = new LiteDatabase(Path))
                {
                    if (db.CollectionExists("Question"+ test.id))
                    {
                        var users = db.GetCollection<Question>("Question" + test.id);
                        users.Delete(id);
                    }
                    else
                    {
                        return false;
                    }

                }

                return true;
            }

        }
        public bool RegTest(Test test)
        {

           
                using (var db = new LiteDatabase(Path))
                {

                    var users = db.GetCollection<Test>("Test");
                    users.Insert(test);
                    var quests = db.GetCollection<Question>("Question" + test.id.ToString());
                
                foreach (var item in test.questions)
                {
                    //var answers = db.GetCollection<Answer>("Answer" + test.id.ToString() + "_" + item.Id.ToString());
                    //foreach (var item_a in item.answers)
                    //{
                    //    answers.Insert(item_a);
                    //}

                    quests.Insert(item);
                }
                //foreach (var item in db.GetCollection<Question>("Question" + test.id.ToString()).FindAll().ToList())
                //{
                //    var answers = db.GetCollection<Answer>("Answer" + test.id.ToString() + "_" + item.Id.ToString());
                //    foreach (var item_a in item.answers)
                //    {
                //        answers.Insert(item_a);
                //    }

                //}
              







            }

                return true;
            }
          

        
        }
}
