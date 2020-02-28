﻿using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        quests.Insert(item);
                        
                    }
                   
                    
                }

                return true;
            }
          

        
        }
}