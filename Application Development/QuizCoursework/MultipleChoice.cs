using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCoursework
{
    class MultipleChoice : Question
    {
        private int answer;

        public int Answer { get => answer; set => answer = value; }

        /* Default constructor extending Question's default constructor */
        public MultipleChoice() : base()
        {
            answer = 1;
        }

        /* Parameterized constructor without image extending Question's constructor */
        public MultipleChoice(String questText, String choice1, String choice2, String choice3, String choice4, int answer) : base(questText, choice1, choice2, choice3, choice4)
        {
            this.answer = answer;
        }

        /* Parameterized constructor with image extending Question's constructor */
        public MultipleChoice(String questText, String imgLocation, String choice1, String choice2, String choice3, String choice4, int answer) : base(questText, choice1, choice2, choice3, choice4, imgLocation)
        {
            this.answer = answer;
        }
    }
}
