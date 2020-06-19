namespace StaffSystem
{
    partial class MainMenuForm
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
            this.userIDLabel = new System.Windows.Forms.Label();
            this.requestButton = new System.Windows.Forms.Button();
            this.leaveBookedButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userIDLabel
            // 
            this.userIDLabel.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userIDLabel.Location = new System.Drawing.Point(17, 24);
            this.userIDLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.userIDLabel.Name = "userIDLabel";
            this.userIDLabel.Size = new System.Drawing.Size(297, 23);
            this.userIDLabel.TabIndex = 9;
            this.userIDLabel.Text = "Username: ";
            this.userIDLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // requestButton
            // 
            this.requestButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestButton.Location = new System.Drawing.Point(172, 98);
            this.requestButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.requestButton.Name = "requestButton";
            this.requestButton.Size = new System.Drawing.Size(125, 125);
            this.requestButton.TabIndex = 7;
            this.requestButton.Text = "View Requests";
            this.requestButton.UseVisualStyleBackColor = true;
            this.requestButton.Click += new System.EventHandler(this.RequestButton_Click);
            // 
            // leaveBookedButton
            // 
            this.leaveBookedButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaveBookedButton.Location = new System.Drawing.Point(31, 98);
            this.leaveBookedButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.leaveBookedButton.Name = "leaveBookedButton";
            this.leaveBookedButton.Size = new System.Drawing.Size(125, 125);
            this.leaveBookedButton.TabIndex = 5;
            this.leaveBookedButton.Text = "Book Leave";
            this.leaveBookedButton.UseVisualStyleBackColor = true;
            this.leaveBookedButton.Click += new System.EventHandler(this.BookLeaveButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutButton.Location = new System.Drawing.Point(31, 237);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(125, 125);
            this.logoutButton.TabIndex = 10;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 393);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.userIDLabel);
            this.Controls.Add(this.requestButton);
            this.Controls.Add(this.leaveBookedButton);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainMenuForm";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label userIDLabel;
        private System.Windows.Forms.Button requestButton;
        private System.Windows.Forms.Button leaveBookedButton;
        private System.Windows.Forms.Button logoutButton;
    }
}