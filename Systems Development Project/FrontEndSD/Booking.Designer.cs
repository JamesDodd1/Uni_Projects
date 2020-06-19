namespace FrontEndSD
{
    partial class Booking
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.seatButton = new System.Windows.Forms.Button();
            this.timeComboBox = new System.Windows.Forms.ComboBox();
            this.showComboBox = new System.Windows.Forms.ComboBox();
            this.selectTimeLabel = new System.Windows.Forms.Label();
            this.selectDateLabel = new System.Windows.Forms.Label();
            this.selectShowLabel = new System.Windows.Forms.Label();
            this.dateComboBox = new System.Windows.Forms.ComboBox();
            this.seatsComboBox = new System.Windows.Forms.ComboBox();
            this.seatsLabel = new System.Windows.Forms.Label();
            this.basketButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(267, 190);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 31);
            this.cancelButton.TabIndex = 22;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // seatButton
            // 
            this.seatButton.Location = new System.Drawing.Point(142, 190);
            this.seatButton.Name = "seatButton";
            this.seatButton.Size = new System.Drawing.Size(100, 31);
            this.seatButton.TabIndex = 21;
            this.seatButton.Text = "Select Seat";
            this.seatButton.UseVisualStyleBackColor = true;
            this.seatButton.Click += new System.EventHandler(this.Seat_Click);
            // 
            // timeComboBox
            // 
            this.timeComboBox.FormattingEnabled = true;
            this.timeComboBox.Location = new System.Drawing.Point(117, 100);
            this.timeComboBox.Name = "timeComboBox";
            this.timeComboBox.Size = new System.Drawing.Size(250, 24);
            this.timeComboBox.TabIndex = 20;
            this.timeComboBox.SelectedIndexChanged += new System.EventHandler(this.Time_SelectedIndexChanged);
            // 
            // showComboBox
            // 
            this.showComboBox.FormattingEnabled = true;
            this.showComboBox.Location = new System.Drawing.Point(117, 20);
            this.showComboBox.Name = "showComboBox";
            this.showComboBox.Size = new System.Drawing.Size(250, 24);
            this.showComboBox.TabIndex = 19;
            this.showComboBox.SelectedIndexChanged += new System.EventHandler(this.Show_SelectedIndexChanged);
            // 
            // selectTimeLabel
            // 
            this.selectTimeLabel.AutoSize = true;
            this.selectTimeLabel.Location = new System.Drawing.Point(12, 101);
            this.selectTimeLabel.Name = "selectTimeLabel";
            this.selectTimeLabel.Size = new System.Drawing.Size(82, 17);
            this.selectTimeLabel.TabIndex = 17;
            this.selectTimeLabel.Text = "Select Time";
            // 
            // selectDateLabel
            // 
            this.selectDateLabel.AutoSize = true;
            this.selectDateLabel.Location = new System.Drawing.Point(12, 63);
            this.selectDateLabel.Name = "selectDateLabel";
            this.selectDateLabel.Size = new System.Drawing.Size(81, 17);
            this.selectDateLabel.TabIndex = 16;
            this.selectDateLabel.Text = "Select Date";
            // 
            // selectShowLabel
            // 
            this.selectShowLabel.AutoSize = true;
            this.selectShowLabel.Location = new System.Drawing.Point(12, 26);
            this.selectShowLabel.Name = "selectShowLabel";
            this.selectShowLabel.Size = new System.Drawing.Size(85, 17);
            this.selectShowLabel.TabIndex = 15;
            this.selectShowLabel.Text = "Select Show";
            // 
            // dateComboBox
            // 
            this.dateComboBox.FormattingEnabled = true;
            this.dateComboBox.Location = new System.Drawing.Point(117, 60);
            this.dateComboBox.Name = "dateComboBox";
            this.dateComboBox.Size = new System.Drawing.Size(250, 24);
            this.dateComboBox.TabIndex = 23;
            this.dateComboBox.SelectedIndexChanged += new System.EventHandler(this.Date_SelectedIndexChanged);
            // 
            // seatsComboBox
            // 
            this.seatsComboBox.Enabled = false;
            this.seatsComboBox.FormattingEnabled = true;
            this.seatsComboBox.Location = new System.Drawing.Point(117, 140);
            this.seatsComboBox.Name = "seatsComboBox";
            this.seatsComboBox.Size = new System.Drawing.Size(250, 24);
            this.seatsComboBox.TabIndex = 24;
            // 
            // seatsLabel
            // 
            this.seatsLabel.AutoSize = true;
            this.seatsLabel.Location = new System.Drawing.Point(12, 143);
            this.seatsLabel.Name = "seatsLabel";
            this.seatsLabel.Size = new System.Drawing.Size(103, 17);
            this.seatsLabel.TabIndex = 25;
            this.seatsLabel.Text = "Seats Selected";
            // 
            // basketButton
            // 
            this.basketButton.Enabled = false;
            this.basketButton.Location = new System.Drawing.Point(15, 190);
            this.basketButton.Name = "basketButton";
            this.basketButton.Size = new System.Drawing.Size(100, 31);
            this.basketButton.TabIndex = 26;
            this.basketButton.Text = "Basket";
            this.basketButton.UseVisualStyleBackColor = true;
            this.basketButton.Click += new System.EventHandler(this.Basket_Click);
            // 
            // Booking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 245);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.seatButton);
            this.Controls.Add(this.basketButton);
            this.Controls.Add(this.seatsLabel);
            this.Controls.Add(this.seatsComboBox);
            this.Controls.Add(this.dateComboBox);
            this.Controls.Add(this.timeComboBox);
            this.Controls.Add(this.showComboBox);
            this.Controls.Add(this.selectTimeLabel);
            this.Controls.Add(this.selectDateLabel);
            this.Controls.Add(this.selectShowLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Booking";
            this.Text = "Booking";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button seatButton;
        private System.Windows.Forms.ComboBox timeComboBox;
        private System.Windows.Forms.ComboBox showComboBox;
        private System.Windows.Forms.Label selectTimeLabel;
        private System.Windows.Forms.Label selectDateLabel;
        private System.Windows.Forms.Label selectShowLabel;
        private System.Windows.Forms.ComboBox dateComboBox;
        private System.Windows.Forms.ComboBox seatsComboBox;
        private System.Windows.Forms.Label seatsLabel;
        private System.Windows.Forms.Button basketButton;
    }
}