using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizCoursework
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            /* Run QuestionScreen */
            QuestionScreen test = new QuestionScreen();
            username = Name_TxtBox.Text;
            test.ShowDialog();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }


        private static String username;

        public String Username { get => username; }

        private void Database_Click(object sender, EventArgs e)
        {
            Database scoreList = new QuizCoursework.Database();
            scoreList.Show();
        }
    }
}
