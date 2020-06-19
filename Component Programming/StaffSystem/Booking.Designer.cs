namespace StaffSystem
{
    partial class BookingForm
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
            this.components = new System.ComponentModel.Container();
            this.fromCalendar = new System.Windows.Forms.MonthCalendar();
            this.toCalendar = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.bookingButton = new System.Windows.Forms.Button();
            this.msgLabel = new System.Windows.Forms.Label();
            this.constraints = new Components.AlternativeDate(this.components);
            this.SuspendLayout();
            // 
            // fromCalendar
            // 
            this.fromCalendar.Location = new System.Drawing.Point(28, 55);
            this.fromCalendar.Name = "fromCalendar";
            this.fromCalendar.TabIndex = 0;
            // 
            // toCalendar
            // 
            this.toCalendar.Location = new System.Drawing.Point(305, 55);
            this.toCalendar.Name = "toCalendar";
            this.toCalendar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(301, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "To";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(28, 251);
            this.backButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(120, 49);
            this.backButton.TabIndex = 15;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // bookingButton
            // 
            this.bookingButton.Location = new System.Drawing.Point(412, 251);
            this.bookingButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bookingButton.Name = "bookingButton";
            this.bookingButton.Size = new System.Drawing.Size(120, 49);
            this.bookingButton.TabIndex = 16;
            this.bookingButton.Text = "Book Holiday";
            this.bookingButton.UseVisualStyleBackColor = true;
            this.bookingButton.Click += new System.EventHandler(this.BookingButton_Click);
            // 
            // msgLabel
            // 
            this.msgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgLabel.ForeColor = System.Drawing.Color.Red;
            this.msgLabel.Location = new System.Drawing.Point(154, 251);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(252, 49);
            this.msgLabel.TabIndex = 17;
            this.msgLabel.Text = "Error";
            this.msgLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.msgLabel.Visible = false;
            // 
            // constraints
            // 
            this.constraints.DepartmentTotal = 0;
            this.constraints.Management = null;
            this.constraints.RoleTotal = 0;
            this.constraints.SeniorStaff = null;
            // 
            // BookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 330);
            this.Controls.Add(this.msgLabel);
            this.Controls.Add(this.bookingButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toCalendar);
            this.Controls.Add(this.fromCalendar);
            this.Name = "BookingForm";
            this.Text = "Booking";
            this.Load += new System.EventHandler(this.BookingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar fromCalendar;
        private System.Windows.Forms.MonthCalendar toCalendar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button bookingButton;
        private System.Windows.Forms.Label msgLabel;
        private Components.AlternativeDate constraints;
    }
}