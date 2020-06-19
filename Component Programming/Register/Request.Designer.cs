namespace Register
{
    partial class RequestForm
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
            this.refreshListButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.rejectButton = new System.Windows.Forms.Button();
            this.viewAllButton = new System.Windows.Forms.Button();
            this.outstandButton = new System.Windows.Forms.Button();
            this.viewDateButton = new System.Windows.Forms.Button();
            this.viewDateTime = new System.Windows.Forms.DateTimePicker();
            this.passButton = new System.Windows.Forms.Button();
            this.failButton = new System.Windows.Forms.Button();
            this.prioritise = new Components.Prioritise(this.components);
            this.requestConstraints = new Components.RequestConstraints(this.components);
            this.SuspendLayout();
            // 
            // userList
            // 
            this.userList.FullRowSelect = true;
            this.userList.HideSelection = false;
            this.userList.Location = new System.Drawing.Point(23, 69);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(766, 260);
            this.userList.TabIndex = 12;
            this.userList.UseCompatibleStateImageBehavior = false;
            // 
            // refreshListButton
            // 
            this.refreshListButton.Location = new System.Drawing.Point(23, 345);
            this.refreshListButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.refreshListButton.Name = "refreshListButton";
            this.refreshListButton.Size = new System.Drawing.Size(120, 49);
            this.refreshListButton.TabIndex = 13;
            this.refreshListButton.Text = "Refresh List";
            this.refreshListButton.UseVisualStyleBackColor = true;
            this.refreshListButton.Click += new System.EventHandler(this.RefreshListButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(669, 13);
            this.backButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(120, 49);
            this.backButton.TabIndex = 14;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(543, 345);
            this.acceptButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(120, 49);
            this.acceptButton.TabIndex = 14;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // rejectButton
            // 
            this.rejectButton.Location = new System.Drawing.Point(669, 345);
            this.rejectButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rejectButton.Name = "rejectButton";
            this.rejectButton.Size = new System.Drawing.Size(120, 49);
            this.rejectButton.TabIndex = 14;
            this.rejectButton.Text = "Reject";
            this.rejectButton.UseVisualStyleBackColor = true;
            this.rejectButton.Click += new System.EventHandler(this.RejectButton_Click);
            // 
            // viewAllButton
            // 
            this.viewAllButton.Location = new System.Drawing.Point(23, 13);
            this.viewAllButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.viewAllButton.Name = "viewAllButton";
            this.viewAllButton.Size = new System.Drawing.Size(120, 49);
            this.viewAllButton.TabIndex = 15;
            this.viewAllButton.Text = "View All";
            this.viewAllButton.UseVisualStyleBackColor = true;
            this.viewAllButton.Click += new System.EventHandler(this.ViewAllButton_Click);
            // 
            // outstandButton
            // 
            this.outstandButton.Location = new System.Drawing.Point(149, 13);
            this.outstandButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.outstandButton.Name = "outstandButton";
            this.outstandButton.Size = new System.Drawing.Size(120, 49);
            this.outstandButton.TabIndex = 16;
            this.outstandButton.Text = "View Outstanding";
            this.outstandButton.UseVisualStyleBackColor = true;
            this.outstandButton.Click += new System.EventHandler(this.OutstandButton_Click);
            // 
            // viewDateButton
            // 
            this.viewDateButton.Location = new System.Drawing.Point(275, 13);
            this.viewDateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.viewDateButton.Name = "viewDateButton";
            this.viewDateButton.Size = new System.Drawing.Size(120, 49);
            this.viewDateButton.TabIndex = 17;
            this.viewDateButton.Text = "View Date";
            this.viewDateButton.UseVisualStyleBackColor = true;
            this.viewDateButton.Click += new System.EventHandler(this.ViewDateButton_Click);
            // 
            // viewDateTime
            // 
            this.viewDateTime.Location = new System.Drawing.Point(407, 13);
            this.viewDateTime.Margin = new System.Windows.Forms.Padding(2);
            this.viewDateTime.Name = "viewDateTime";
            this.viewDateTime.Size = new System.Drawing.Size(102, 20);
            this.viewDateTime.TabIndex = 18;
            this.viewDateTime.Visible = false;
            this.viewDateTime.ValueChanged += new System.EventHandler(this.ViewDateTime_ValueChanged);
            // 
            // passButton
            // 
            this.passButton.Enabled = false;
            this.passButton.Location = new System.Drawing.Point(149, 345);
            this.passButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.passButton.Name = "passButton";
            this.passButton.Size = new System.Drawing.Size(120, 49);
            this.passButton.TabIndex = 19;
            this.passButton.Text = "Passed Constraints";
            this.passButton.UseVisualStyleBackColor = true;
            this.passButton.Click += new System.EventHandler(this.PassButton_Click);
            // 
            // failButton
            // 
            this.failButton.Location = new System.Drawing.Point(275, 345);
            this.failButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.failButton.Name = "failButton";
            this.failButton.Size = new System.Drawing.Size(120, 49);
            this.failButton.TabIndex = 20;
            this.failButton.Text = "Failed Constraints";
            this.failButton.UseVisualStyleBackColor = true;
            this.failButton.Click += new System.EventHandler(this.FailButton_Click);
            // 
            // prioritise
            // 
            this.prioritise.ApprovedHolidays = null;
            // 
            // requestConstraints
            // 
            this.requestConstraints.DepartmentTotal = 0;
            this.requestConstraints.Management = null;
            this.requestConstraints.RoleTotal = 0;
            this.requestConstraints.SeniorStaff = null;
            // 
            // RequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 408);
            this.Controls.Add(this.failButton);
            this.Controls.Add(this.passButton);
            this.Controls.Add(this.viewDateTime);
            this.Controls.Add(this.viewDateButton);
            this.Controls.Add(this.outstandButton);
            this.Controls.Add(this.viewAllButton);
            this.Controls.Add(this.rejectButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.refreshListButton);
            this.Controls.Add(this.userList);
            this.Name = "RequestForm";
            this.Text = "HolidayRequest";
            this.Load += new System.EventHandler(this.RequestForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView userList;
        private System.Windows.Forms.Button refreshListButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button rejectButton;
        private System.Windows.Forms.Button outstandButton;
        private System.Windows.Forms.Button viewAllButton;
        private System.Windows.Forms.Button viewDateButton;
        private System.Windows.Forms.DateTimePicker viewDateTime;
        private System.Windows.Forms.Button passButton;
        private System.Windows.Forms.Button failButton;
        private Components.Prioritise prioritise;
        private Components.RequestConstraints requestConstraints;
    }
}