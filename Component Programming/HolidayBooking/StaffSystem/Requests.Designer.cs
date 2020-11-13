namespace StaffSystem
{
    partial class Requests
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
            this.requestList = new System.Windows.Forms.ListView();
            this.backButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // requestList
            // 
            this.requestList.GridLines = true;
            this.requestList.HideSelection = false;
            this.requestList.Location = new System.Drawing.Point(12, 12);
            this.requestList.Name = "requestList";
            this.requestList.Size = new System.Drawing.Size(420, 181);
            this.requestList.TabIndex = 0;
            this.requestList.UseCompatibleStateImageBehavior = false;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 200);
            this.backButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(120, 49);
            this.backButton.TabIndex = 16;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(312, 200);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(120, 49);
            this.refreshButton.TabIndex = 17;
            this.refreshButton.Text = "Refresh List";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // Requests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 264);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.requestList);
            this.Name = "Requests";
            this.Text = "Requests";
            this.Load += new System.EventHandler(this.Requests_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView requestList;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button refreshButton;
    }
}