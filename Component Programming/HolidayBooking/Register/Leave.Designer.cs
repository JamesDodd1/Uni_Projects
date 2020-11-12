namespace Register
{
    partial class LeaveForm
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
            this.userList = new System.Windows.Forms.ListView();
            this.leaveCalendar = new Components.LeaveCalendar(this.components);
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userList
            // 
            this.userList.FullRowSelect = true;
            this.userList.HideSelection = false;
            this.userList.Location = new System.Drawing.Point(12, 12);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(228, 260);
            this.userList.TabIndex = 13;
            this.userList.UseCompatibleStateImageBehavior = false;
            this.userList.SelectedIndexChanged += new System.EventHandler(this.UserList_SelectedIndexChanged);
            // 
            // leaveCalendar
            // 
            this.leaveCalendar.Location = new System.Drawing.Point(252, 12);
            this.leaveCalendar.Name = "leaveCalendar";
            this.leaveCalendar.TabIndex = 1;
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(297, 235);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(175, 35);
            this.buttonBack.TabIndex = 14;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // LeaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 286);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.userList);
            this.Controls.Add(this.leaveCalendar);
            this.Name = "LeaveForm";
            this.Text = "Booked Leave";
            this.ResumeLayout(false);

        }

        #endregion
        private Components.LeaveCalendar leaveCalendar;
        private System.Windows.Forms.ListView userList;
        private System.Windows.Forms.Button buttonBack;
    }
}