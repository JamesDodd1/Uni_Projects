using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizCoursework
{
    public partial class Database : Form
    {
        public Database()
        {
            InitializeComponent();
        }
		
		
        private void Return_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void Scores_Load(object sender, EventArgs e)
        {
			/* Sets and displays scores list */
            var score = new Database();
            score.DisplayScores(scores_listBox.Text);
            scores_listBox.Items.Clear();
            scores_listBox.DataSource = score.quizScores;
        }


        public void DisplayScores(String scores)
        {
            /* Connect to database */
            String link = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=L:\App Dev\Coursework\QuizCoursework\ScoresDatabase.mdb";
            using (OleDbConnection connection = new OleDbConnection(link))
            {
                connection.Open();
                OleDbDataReader reader = null;
                OleDbCommand command = new OleDbCommand("Select * from Scores order by Name", connection);

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    quizScores.Add("Name: " + reader[1].ToString());
                    quizScores.Add("Score: " + reader[2].ToString());
                    quizScores.Add("Percentage: " + reader[3].ToString());
                    quizScores.Add("");
                }

            }
        }


        public static OleDbConnection GetConnection()
        {
            /* Create database connection */
            connect = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=J:\App Dev\Coursework\QuizCoursework\ScoresDatabase.mdb";
            return new OleDbConnection(connect);
        }

		/* Declare variables */
        private List<String> quizScores = new List<String>();

        private static String connect;
    }
}
