using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_maker;

namespace PublicLibrary.lip
{
    public class Question
    {
        public int Id { get; set; }
        public string quest_text { get; set; }
        public string ans_text1 { get; set; }
        public bool IsRight1 { get; set; }
        public string ans_text2 { get; set; }
        public bool IsRight2 { get; set; }
        public string ans_text3 { get; set; }
        public bool IsRight3 { get; set; }
        public string ans_text4 { get; set; }
        public bool IsRight4 { get; set; }
        public string price { get; set; }
    }
}
