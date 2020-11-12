using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCoursework
{
    class Lists : Question
    {
        private bool choice1Answer;
        private bool choice2Answer;
        private bool choice3Answer;
        private bool choice4Answer;

        public bool Choice1Answer { get => choice1Answer; set => choice1Answer = value; }
        public bool Choice2Answer { get => choice2Answer; set => choice2Answer = value; }
        public bool Choice3Answer { get => choice3Answer; set => choice3Answer = value; }
        public bool Choice4Answer { get => choice4Answer; set => choice4Answer = value; }

        /* Default constructor extending Question's default constructor */
        public Lists() : base()
        {
            choice1Answer = false;
            choice2Answer = false;
            choice3Answer = false;
            choice4Answer = false;
        }

        /* Parameterized constructor without image extending Question's constructor */
        public Lists(String questText, String choice1, String choice2, String choice3, String choice4, bool choice1Answer, bool choice2Answer, bool choice3Answer, bool choice4Answer) : base(questText, choice1, choice2, choice3, choice4)
        {
            this.choice1Answer = choice1Answer;
            this.choice2Answer = choice2Answer;
            this.choice3Answer = choice3Answer;
            this.choice4Answer = choice4Answer;
        }

        /* Parameterized constructor with image extending Question's constructor */
        public Lists(String questText, String imgLocation, String choice1, String choice2, String choice3, String choice4, bool choice1Answer, bool choice2Answer, bool choice3Answer, bool choice4Answer) : base(questText, choice1, choice2, choice3, choice4, imgLocation)
        {
            this.choice1Answer = choice1Answer;
            this.choice2Answer = choice2Answer;
            this.choice3Answer = choice3Answer;
            this.choice4Answer = choice4Answer;
        }
    }
}
