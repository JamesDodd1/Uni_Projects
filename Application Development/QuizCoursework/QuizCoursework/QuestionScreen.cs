
using System;
using System.Collections;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Data.OleDb;
using System.ComponentModel;

namespace QuizCoursework
{
    public partial class QuestionScreen : Form
    {
        public QuestionScreen()
        {
            InitializeComponent();

            /* Resets variables */
            currentQuestion = 0;
            totalCorrect = 0;

            SettingObjects();
            DisplayQuestion(currentQuestion);
        }


        private void DisplayQuestion(int QuestNum)
        {
            Invalidate();   // Redraws

            /* Reset variables */
            answered = false;
            imagePaint = false;


            /* Printing question */
            if (questType[QuestNum] == 0)   // If multiple choice question without image
            {
                MultipleChoice quest = (MultipleChoice)questions[QuestNum];

                /* Setting layout */
                SettingButtons(true, new Point(15, 60), new Point(225, 60), new Point(15, 110), new Point(225, 110));
                SettingCheckBoxes(false);
                SettingImage(false, false);
                checkAnswer_btn.Visible = false;

                /* Setting text */
                QuestionText.Text = quest.QuestText;
                option1_btn.Text = quest.Choice1;
                option2_btn.Text = quest.Choice2;
                option3_btn.Text = quest.Choice3;
                option4_btn.Text = quest.Choice4;
            }
            else if (questType[QuestNum] == 1)  // If multiple choice question with image
            {
                MultipleChoice quest = (MultipleChoice)questions[QuestNum];

                /* Setting layout */
                SettingButtons(true, new Point(15, 160), new Point(225, 160), new Point(15, 210), new Point(225, 210));
                SettingCheckBoxes(false);
                SettingImage(true, quest.ImgLocation, new Size(100, 100), new Point(15, 50), false);
                checkAnswer_btn.Visible = false;

                /* Setting text */
                QuestionText.Text = quest.QuestText;
                option1_btn.Text = quest.Choice1;
                option2_btn.Text = quest.Choice2;
                option3_btn.Text = quest.Choice3;
                option4_btn.Text = quest.Choice4;
            }
            else if (questType[QuestNum] == 2)  // If lists question without image
            {
                Lists quest = (Lists)questions[QuestNum];

                /* Setting layout */
                SettingButtons(false);
                SettingCheckBoxes(true, new Point(15, 60), new Point(225, 60), new Point(15, 110), new Point(225, 110));
                SettingImage(false, false);
                checkAnswer_btn.Visible = true;

                /* Setting text */
                QuestionText.Text = quest.QuestText;
                option1_check.Text = quest.Choice1;
                option2_check.Text = quest.Choice2;
                option3_check.Text = quest.Choice3;
                option4_check.Text = quest.Choice4;
            }
            else if (questType[QuestNum] == 3)  // If lists question with image
            {
                Lists quest = (Lists)questions[QuestNum];

                /* Setting layout */
                SettingButtons(false);
                SettingCheckBoxes(true, new Point(15, 160), new Point(225, 160), new Point(15, 210), new Point(225, 210));
                SettingImage(true, quest.ImgLocation, new Size(100, 100), new Point(15, 50), false);
                checkAnswer_btn.Visible = true;

                /* Setting text */
                QuestionText.Text = quest.QuestText;
                option1_check.Text = quest.Choice1;
                option2_check.Text = quest.Choice2;
                option3_check.Text = quest.Choice3;
                option4_check.Text = quest.Choice4;
            }
            else if (questType[QuestNum] == 4)  // If multiple choice question with zoom out image
            {
                MultipleChoice quest = (MultipleChoice)questions[QuestNum];

                /* Setting layout */
                SettingButtons(true, new Point(15, 160), new Point(225, 160), new Point(15, 210), new Point(225, 210));
                SettingCheckBoxes(false);
                SettingImage(false, true);
                checkAnswer_btn.Visible = false;

                /* Setting text */
                QuestionText.Text = quest.QuestText;
                option1_btn.Text = quest.Choice1;
                option2_btn.Text = quest.Choice2;
                option3_btn.Text = quest.Choice3;
                option4_btn.Text = quest.Choice4;

                zoomImg = quest.ImgLocation;

                /* Run threads */
                zoomRun = true;
                countdownRun = true;
                threadDone1 = false;
                threadDone2 = false;

                imagePaint = true;

                zoom = new Thread(ZoomImage);
                time = new Thread(Countdown);
                
                zoom.Start();
                time.Start();
            }
            else if (questType[QuestNum] == 5)   // If timed question
            {
                MultipleChoice quest = (MultipleChoice)questions[QuestNum];

                /* Setting layout */
                SettingButtons(true, new Point(15, 60), new Point(225, 60), new Point(15, 110), new Point(225, 110));
                SettingCheckBoxes(false);
                SettingImage(false, false);
                checkAnswer_btn.Visible = false;

                /* Setting text */
                QuestionText.Text = quest.QuestText;
                option1_btn.Text = quest.Choice1;
                option2_btn.Text = quest.Choice2;
                option3_btn.Text = quest.Choice3;
                option4_btn.Text = quest.Choice4;

                /* Run threads */
                zoomRun = true;
                countdownRun = true;

                zoom = new Thread(ZoomImage);
                time = new Thread(Countdown);

                zoom.Start();
                time.Start();
            }
        }

        private void SettingForm(int height)
        {
            this.Size = new Size(460, height);
        }


        private void SettingObjects()
        {
            /* Add objects to window */
            this.Controls.Add(option1_check);
            this.Controls.Add(option2_check);
            this.Controls.Add(option3_check);
            this.Controls.Add(option4_check);

            /* Setting visibility */
            SettingButtons(false);
            SettingCheckBoxes(false);
            Image_Box.Visible = false;
            checkAnswer_btn.Visible = false;

            /* Set font */
            option1_check.Font = new Font("Verdana", 14);
            option2_check.Font = new Font("Verdana", 14);
            option3_check.Font = new Font("Verdana", 14);
            option4_check.Font = new Font("Verdana", 14);

            /* Set font colour */
            option1_check.ForeColor = Color.FromArgb(255, 255, 255);    // White
            option2_check.ForeColor = Color.FromArgb(255, 255, 255);    // White
            option3_check.ForeColor = Color.FromArgb(255, 255, 255);    // White
            option4_check.ForeColor = Color.FromArgb(255, 255, 255);    // White

            /* Set size */
            option1_check.Size = new Size(200, 40);
            option2_check.Size = new Size(250, 40);
            option3_check.Size = new Size(200, 40);
            option4_check.Size = new Size(250, 40);
        }


        private void SettingButtons(bool visible)
        {
            if (visible)
            {
                /* Set visibility */
                option1_btn.Visible = true;
                option2_btn.Visible = true;
                option3_btn.Visible = true;
                option4_btn.Visible = true;
            }
            else
            {
                /* Set visibility */
                option1_btn.Visible = false;
                option2_btn.Visible = false;
                option3_btn.Visible = false;
                option4_btn.Visible = false;
            }
        }


        private void SettingButtons(bool visible, Point option1_Pos, Point option2_Pos, Point option3_Pos, Point option4_Pos)
        {
            if (visible)
            {
                /* Set visibility */
                option1_btn.Visible = true;
                option2_btn.Visible = true;
                option3_btn.Visible = true;
                option4_btn.Visible = true;

                /* Setting positions */
                option1_btn.Location = option1_Pos;
                option2_btn.Location = option2_Pos;
                option3_btn.Location = option3_Pos;
                option4_btn.Location = option4_Pos;

                quit_btn.Location = new Point(option4_Pos.X, option4_Pos.Y + 60);

                /* Set form size */
                SettingForm(quit_btn.Location.Y + 95);
            }
            else
            {
                /* Set visibility */
                option1_btn.Visible = false;
                option2_btn.Visible = false;
                option3_btn.Visible = false;
                option4_btn.Visible = false;
            }
        }


        private void SettingCheckBoxes(bool visible)
        {
            if (visible)
            {
                /* Set visibility */
                option1_check.Visible = true;
                option2_check.Visible = true;
                option3_check.Visible = true;
                option4_check.Visible = true;

                /* Unchecking check boxes */
                option1_check.Checked = false;
                option2_check.Checked = false;
                option3_check.Checked = false;
                option4_check.Checked = false;
            }
            else
            {
                /* Set visibility */
                option1_check.Visible = false;
                option2_check.Visible = false;
                option3_check.Visible = false;
                option4_check.Visible = false;
            }
        }


        private void SettingCheckBoxes(bool visible, Point option1_Pos, Point option2_Pos, Point option3_Pos, Point option4_Pos)
        {
            if (visible)
            {
                /* Set visibility */
                option1_check.Visible = true;
                option2_check.Visible = true;
                option3_check.Visible = true;
                option4_check.Visible = true;

                /* Unchecking check boxes */
                option1_check.Checked = false;
                option2_check.Checked = false;
                option3_check.Checked = false;
                option4_check.Checked = false;

                /* Setting positions */
                option1_check.Location = option1_Pos;
                option2_check.Location = option2_Pos;
                option3_check.Location = option3_Pos;
                option4_check.Location = option4_Pos;

                checkAnswer_btn.Location = new Point(option3_Pos.X, option3_Pos.Y + 60);
                quit_btn.Location = new Point(option4_Pos.X, option4_Pos.Y + 60);

                /* Set form size */
                SettingForm(quit_btn.Location.Y + 95);
            }
            else
            {
                /* Set visibility */
                option1_check.Visible = false;
                option2_check.Visible = false;
                option3_check.Visible = false;
                option4_check.Visible = false;
            }
        }


        private void SettingImage(bool visible, bool panelVisible)
        {
            if (visible)
                Image_Box.Visible = true;
            else
                Image_Box.Visible = false;

            if (panelVisible)
            {
                Panel1.Visible = true;
                Panel2.Visible = true;
            }
            else
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
            }
        }


        private void SettingImage(bool visible, String imgLocation, Size size, Point location, bool panelVisible)
        {
            if (visible)
            {
                Image_Box.Visible = true;
                Image_Box.ImageLocation = imgLocation;
                Image_Box.Size = size;
                Image_Box.SizeMode = PictureBoxSizeMode.Zoom;
                Image_Box.Location = location;
            }
            else
                Image_Box.Visible = false;

            if (panelVisible)
            {
                Panel1.Visible = true;
                Panel2.Visible = true;
            }
            else
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
            }
        }


        public void ZoomImage()
        {
            imgHeight = Image.FromFile(zoomImg).Height;
            imgWidth = Image.FromFile(zoomImg).Width;

            int dx = (imgWidth - 100) / 100;    // Change in width
            int dy = (imgHeight - 100) / 100;   // Change in height

            run = true;

            /* Shrinks image */
            while (run)
            {
                for (int i = 0; i < 50; i++)
                {
                    if (imgWidth > imgHeight)
                    {
                        if (imgWidth == 100 || isTimeUp)
                        {
                            run = false;
                            break;
                        }
                    }
                    else
                    {
                        if (imgHeight == 100 || isTimeUp)
                        {
                            run = false;
                            break;
                        }
                    }

                    imgWidth -= dx;     // Reduce height
                    imgHeight -= dy;    // Reduce width
                    Invalidate();       // Redraws 
                    Thread.Sleep(50);   // Sleeps for 50 milliseconds
                }
            }
            KillThreads();
        }


        public void Countdown()
        {
            isTimeUp = false;
            Thread.Sleep(5000);   // Sleeps for 5 seconds
            isTimeUp = true;
            //KillThreads();
        }


        private void KillThreads()
        {
            /* Destroy threads */
            if (zoomRun)
            {
                zoomRun = false;
                threadDone1 = true;
                zoom.Join();
            }

            if (countdownRun)
            {
                countdownRun = false;
                threadDone2 = true;
                time.Join();
            }
        }


        private void Quiz_Paint(object sender, PaintEventArgs e)
        {
            /* Paints image */
            if (imagePaint)
            {
                this.DoubleBuffered = true;
                Graphics g = e.Graphics;
                g.DrawImage(Image.FromFile(zoomImg), 15, 50, imgWidth, imgHeight);
                
                /* Closes threads */
                if (imgWidth <= 100 || imgHeight <= 100)
                    KillThreads();

                /* Go to next question */
                if (threadDone1 && threadDone2)
                    NextQuestion(sender, e);
            }
        }


        private void Quit_Click(object sender, EventArgs e)
        {
            quit = true;
            Quit();
        }


        private void Option1_Click(object sender, EventArgs e)
        {
            /* Checking answer */
            if (questType[currentQuestion] == 0 || questType[currentQuestion] == 1 || questType[currentQuestion] == 4 || questType[currentQuestion] == 5)
            {
                MultipleChoice quest = (MultipleChoice)questions[currentQuestion];
                answered = true;

                if (quest.Answer == 1)
                {
                    totalCorrect++;
                    TotalScore.Text = totalCorrect.ToString();
                    MessageBox.Show("Correct!");
                }
                else
                    MessageBox.Show("AHAHAHAHAHA!!!");
            }

            NextQuestion(sender, e);   // Goes to next question
        }


        private void Option2_Click(object sender, EventArgs e)
        {
            /* Checking answer */
            if (questType[currentQuestion] == 0 || questType[currentQuestion] == 1 || questType[currentQuestion] == 4 || questType[currentQuestion] == 5)
            {
                MultipleChoice quest = (MultipleChoice)questions[currentQuestion];
                answered = true;

                if (quest.Answer == 2)
                {
                    totalCorrect++;
                    TotalScore.Text = totalCorrect.ToString();
                    MessageBox.Show("Correct!");
                }
                else
                    MessageBox.Show("AHAHAHAHAHA!!!");
            }

            NextQuestion(sender, e);   // Goes to next question
        }


        private void Option3_Click(object sender, EventArgs e)
        {
            /* Checking answer */
            if (questType[currentQuestion] == 0 || questType[currentQuestion] == 1 || questType[currentQuestion] == 4 || questType[currentQuestion] == 5)
            {
                MultipleChoice quest = (MultipleChoice)questions[currentQuestion];
                answered = true;

                if (quest.Answer == 3)
                {
                    totalCorrect++;
                    TotalScore.Text = totalCorrect.ToString();
                    MessageBox.Show("Correct!");
                }
                else
                    MessageBox.Show("AHAHAHAHAHA!!!");
            }

            NextQuestion(sender, e);   // Goes to next question
        }


        private void Option4_Click(object sender, EventArgs e)
        {
            /* Checking answer */
            if (questType[currentQuestion] == 0 || questType[currentQuestion] == 1 || questType[currentQuestion] == 4 || questType[currentQuestion] == 5)
            {
                MultipleChoice quest = (MultipleChoice)questions[currentQuestion];
                answered = true;

                if (quest.Answer == 4)
                {
                    totalCorrect++;
                    TotalScore.Text = totalCorrect.ToString();
                    MessageBox.Show("Correct!");
                }
                else
                    MessageBox.Show("AHAHAHAHAHA!!!");
            }

            NextQuestion(sender, e);   // Goes to next question
        }


        private void CheckAnswer_Click(object sender, EventArgs e)
        {
            /* Checking answer */
            if (questType[currentQuestion] == 2 || questType[currentQuestion] == 3)    // If lists question
            {
                Lists quest = (Lists)questions[currentQuestion];
                answered = true;

                if (option1_check.Checked == quest.Choice1Answer && option2_check.Checked == quest.Choice2Answer && option3_check.Checked == quest.Choice3Answer && option4_check.Checked == quest.Choice4Answer)
                {
                    totalCorrect++;
                    TotalScore.Text = totalCorrect.ToString();
                    MessageBox.Show("Correct!");
                }
                else
                    MessageBox.Show("AHAHAHAHAHA!!!");
            }

            NextQuestion(sender, e);   // Goes to next question
        }


        private void NextQuestion(object sender, EventArgs e)
        {
            if (countdownRun || zoomRun)
            {
                KillThreads();
            }
            
            if (!answered)
                MessageBox.Show("AHAHAHAHAHA!!!");

            /* Running next question */
            if (++currentQuestion < questions.Length)
                DisplayQuestion(currentQuestion);   // Show next question
            else
            {
                if (!quit)
                    Quit();  // Quit game
            }
        }


        private void Quit()
        {
            Menu menu = new Menu();
            double correctPercent = (totalCorrect / currentQuestion) * 100; // Calculate percentage

            /* Connect to database */
            OleDbConnection myConnection = Database.GetConnection();
            String myQuery = "Insert into Scores (Name,Score,PercentageCorrect) values ( '" + menu.Username + "', " + totalCorrect + ", '" + correctPercent + "%' )";   // Add data to database
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                MessageBox.Show(menu.Username + ", you got " + totalCorrect + " correct answers out of " + currentQuestion); // Display end message
            }
            catch (Exception e1)
            {
                MessageBox.Show("Exception in DBHandler " + e1);    // Error message
            }
            finally
            {
                myConnection.Close();   // Close connection
            }
            
            Close();    // Close window
        }


        /* Declarations */
        private static int currentQuestion = 0;
        private static int totalCorrect = 0;

        private int imgWidth;
        private int imgHeight;

        private static CheckBox option1_check = new CheckBox();
        private static CheckBox option2_check = new CheckBox();
        private static CheckBox option3_check = new CheckBox();
        private static CheckBox option4_check = new CheckBox();

        private static String image1 = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e1/FullMoon2010.jpg/1200px-FullMoon2010.jpg";
        private static String image2 = "http://tokko.co.uk/wp-content/uploads/2018/05/TableTennisForFun_EVENT_400px-X-300px.jpg";
        private static String image3 = "https://www.pedagonet.com/brain/manysquares.jpg";
        private static String zoomImg = "Ostrich.jpg";

        private Thread zoom;
        private Thread time;

        private bool run = false;
        private bool imagePaint = false;
        private bool isTimeUp = true;
        private bool countdownRun = false;
        private bool zoomRun = false;
        private bool threadDone1 = true;
        private bool threadDone2 = true;
        private bool answered = false;
        private bool quit = false;


        /* Set questions */
        private static Lists q1 = new Lists("What is this coursework worth?", "100%", "75%", "50%", "25%", true, false, false, false);
        private static MultipleChoice q2 = new MultipleChoice("What is 1 + 1?", "1", "2", "3", "4", 2);
        private static MultipleChoice q3 = new MultipleChoice("What is 2 + 2?", "2", "4", "6", "8", 2);
        private static MultipleChoice q4 = new MultipleChoice("What is 3 + 3?", "3", "4", "5", "6", 4);
        private static MultipleChoice q5 = new MultipleChoice("What is this?", image1, "The moon", "The Sun", "The Sea", "The Sky", 1);
        private static Lists q6 = new Lists("What sport's this?", image2, "Tennis", "Ping Pong", "Table Tennis", "Badminton", false, true, true, false);
        private static MultipleChoice q7 = new MultipleChoice("In 5 secs, guess the image", "Ostrich.jpg", "Mud", "Tea", "Ostrich", "Nothing", 3);
        private static Lists q8 = new Lists("What is the fastest living animal?", "Tiger", "Cheater", "Peregrine Falcon", "Black Marlin", false, false, true, false);
        private static Lists q9 = new Lists("How many squares are there?", image3, "36", "40", "44", "48", false, true, false, false);
        private static MultipleChoice q10 = new MultipleChoice("In 5 secs, what's 25 x 12?", "250", "325", "300", "400", 3);

        private static object[] questions = { q1, q2, q3, q4, q5, q6, q7, q8, q9, q10 };
        private static int[] questType = { 2, 0, 0, 0, 1, 3, 4, 2, 3, 5 };
        /* questType
         * 0 = Multiple choice without image
         * 1 = Multiple choice with image
         * 2 = Lists without image
         * 3 = Lists with Image
         * 4 = Multiple choice with zoom out image
         * 5 = Timed question
         */
    }
}