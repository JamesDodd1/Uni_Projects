using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCoursework
{
    class Question
    {
        protected String questText;
        protected String choice1;
        protected String choice2;
        protected String choice3;
        protected String choice4;
        protected String imgLocation;
        
        public string QuestText { get => questText; set => questText = value; }
        public String Choice1 { get => choice1; set => choice1 = value; }
        public String Choice2 { get => choice2; set => choice2 = value; }
        public String Choice3 { get => choice3; set => choice3 = value; }
        public String Choice4 { get => choice4; set => choice4 = value; }
        public String ImgLocation { get => imgLocation; set => imgLocation = value; }

        /* Default constructor */
        public Question()
        {
            questText = "This is a question";
            choice1 = "Choice 1";
            choice2 = "Choice 2";
            choice3 = "Choice 3";
            choice4 = "Choice 4";
            imgLocation = "";
        }

        /* Parameterized constructor without image */
        public Question(String questText, String choice1, String choice2, String choice3, String choice4)
        {
            this.questText = questText;
            this.choice1 = choice1;
            this.choice2 = choice2;
            this.choice3 = choice3;
            this.choice4 = choice4;
            this.imgLocation = "";
        }

        /* Parameterized constructor with image */
        public Question(String questText, String choice1, String choice2, String choice3, String choice4, String imgLocation)
        {
            this.questText = questText;
            this.choice1 = choice1;
            this.choice2 = choice2;
            this.choice3 = choice3;
            this.choice4 = choice4;
            this.imgLocation = imgLocation;
        }
    }
}
