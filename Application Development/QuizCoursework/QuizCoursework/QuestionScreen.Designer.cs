namespace QuizCoursework
{
    partial class QuestionScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.QuestionText = new System.Windows.Forms.Label();
            this.TotalScore = new System.Windows.Forms.Label();
            this.TotalScoreTxt = new System.Windows.Forms.Label();
            this.option4_btn = new System.Windows.Forms.Button();
            this.option3_btn = new System.Windows.Forms.Button();
            this.option2_btn = new System.Windows.Forms.Button();
            this.option1_btn = new System.Windows.Forms.Button();
            this.quit_btn = new System.Windows.Forms.Button();
            this.checkAnswer_btn = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Image_Box = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Image_Box)).BeginInit();
            this.SuspendLayout();
            // 
            // QuestionText
            // 
            this.QuestionText.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionText.ForeColor = System.Drawing.Color.White;
            this.QuestionText.Location = new System.Drawing.Point(15, 15);
            this.QuestionText.Name = "QuestionText";
            this.QuestionText.Size = new System.Drawing.Size(309, 23);
            this.QuestionText.TabIndex = 5;
            this.QuestionText.Text = "Question Text";
            // 
            // TotalScore
            // 
            this.TotalScore.AutoSize = true;
            this.TotalScore.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalScore.ForeColor = System.Drawing.Color.White;
            this.TotalScore.Location = new System.Drawing.Point(409, 15);
            this.TotalScore.Name = "TotalScore";
            this.TotalScore.Size = new System.Drawing.Size(22, 23);
            this.TotalScore.TabIndex = 12;
            this.TotalScore.Text = "0";
            // 
            // TotalScoreTxt
            // 
            this.TotalScoreTxt.AutoSize = true;
            this.TotalScoreTxt.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalScoreTxt.ForeColor = System.Drawing.Color.White;
            this.TotalScoreTxt.Location = new System.Drawing.Point(330, 15);
            this.TotalScoreTxt.Name = "TotalScoreTxt";
            this.TotalScoreTxt.Size = new System.Drawing.Size(73, 23);
            this.TotalScoreTxt.TabIndex = 11;
            this.TotalScoreTxt.Text = "Score:";
            // 
            // option4_btn
            // 
            this.option4_btn.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.option4_btn.Location = new System.Drawing.Point(225, 210);
            this.option4_btn.Name = "option4_btn";
            this.option4_btn.Size = new System.Drawing.Size(200, 40);
            this.option4_btn.TabIndex = 16;
            this.option4_btn.Text = "Option 4";
            this.option4_btn.UseVisualStyleBackColor = true;
            this.option4_btn.Click += new System.EventHandler(this.Option4_Click);
            // 
            // option3_btn
            // 
            this.option3_btn.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.option3_btn.Location = new System.Drawing.Point(15, 210);
            this.option3_btn.Name = "option3_btn";
            this.option3_btn.Size = new System.Drawing.Size(200, 40);
            this.option3_btn.TabIndex = 15;
            this.option3_btn.Text = "Option 3";
            this.option3_btn.UseVisualStyleBackColor = true;
            this.option3_btn.Click += new System.EventHandler(this.Option3_Click);
            // 
            // option2_btn
            // 
            this.option2_btn.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.option2_btn.Location = new System.Drawing.Point(225, 160);
            this.option2_btn.Name = "option2_btn";
            this.option2_btn.Size = new System.Drawing.Size(200, 40);
            this.option2_btn.TabIndex = 14;
            this.option2_btn.Text = "Option 2";
            this.option2_btn.UseVisualStyleBackColor = true;
            this.option2_btn.Click += new System.EventHandler(this.Option2_Click);
            // 
            // option1_btn
            // 
            this.option1_btn.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.option1_btn.Location = new System.Drawing.Point(15, 160);
            this.option1_btn.Name = "option1_btn";
            this.option1_btn.Size = new System.Drawing.Size(200, 40);
            this.option1_btn.TabIndex = 13;
            this.option1_btn.Text = "Option 1";
            this.option1_btn.UseVisualStyleBackColor = true;
            this.option1_btn.Click += new System.EventHandler(this.Option1_Click);
            // 
            // quit_btn
            // 
            this.quit_btn.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quit_btn.Location = new System.Drawing.Point(225, 270);
            this.quit_btn.Name = "quit_btn";
            this.quit_btn.Size = new System.Drawing.Size(200, 40);
            this.quit_btn.TabIndex = 19;
            this.quit_btn.Text = "Quit";
            this.quit_btn.UseVisualStyleBackColor = true;
            this.quit_btn.Click += new System.EventHandler(this.Quit_Click);
            // 
            // checkAnswer_btn
            // 
            this.checkAnswer_btn.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAnswer_btn.Location = new System.Drawing.Point(15, 270);
            this.checkAnswer_btn.Name = "checkAnswer_btn";
            this.checkAnswer_btn.Size = new System.Drawing.Size(200, 40);
            this.checkAnswer_btn.TabIndex = 18;
            this.checkAnswer_btn.Text = "Check Answer";
            this.checkAnswer_btn.UseVisualStyleBackColor = true;
            this.checkAnswer_btn.Click += new System.EventHandler(this.CheckAnswer_Click);
            // 
            // Panel1
            // 
            this.Panel1.Location = new System.Drawing.Point(115, 50);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(567, 103);
            this.Panel1.TabIndex = 20;
            // 
            // Panel2
            // 
            this.Panel2.Location = new System.Drawing.Point(-26, 150);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(691, 382);
            this.Panel2.TabIndex = 21;
            // 
            // Image_Box
            // 
            this.Image_Box.Location = new System.Drawing.Point(15, 50);
            this.Image_Box.Name = "Image_Box";
            this.Image_Box.Size = new System.Drawing.Size(100, 100);
            this.Image_Box.TabIndex = 22;
            this.Image_Box.TabStop = false;
            // 
            // QuestionScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(444, 326);
            this.Controls.Add(this.quit_btn);
            this.Controls.Add(this.TotalScoreTxt);
            this.Controls.Add(this.checkAnswer_btn);
            this.Controls.Add(this.Image_Box);
            this.Controls.Add(this.option4_btn);
            this.Controls.Add(this.option2_btn);
            this.Controls.Add(this.TotalScore);
            this.Controls.Add(this.option3_btn);
            this.Controls.Add(this.option1_btn);
            this.Controls.Add(this.QuestionText);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "QuestionScreen";
            this.Text = "Quiz Questions";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Quiz_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.Image_Box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label QuestionText;
        private System.Windows.Forms.Label TotalScore;
        private System.Windows.Forms.Label TotalScoreTxt;
        private System.Windows.Forms.Button option4_btn;
        private System.Windows.Forms.Button option3_btn;
        private System.Windows.Forms.Button option2_btn;
        private System.Windows.Forms.Button option1_btn;
        //        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.Button quit_btn;
        private System.Windows.Forms.Button checkAnswer_btn;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.PictureBox Image_Box;
    }
}