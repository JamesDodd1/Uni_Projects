namespace FrontEndSD
{
    partial class ManageReviews
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
            this.closeButton = new System.Windows.Forms.Button();
            this.reviewPanel = new System.Windows.Forms.Panel();
            this.addButton = new System.Windows.Forms.Button();
            this.showsComboBox = new System.Windows.Forms.ComboBox();
            this.showLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(420, 49);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(100, 27);
            this.closeButton.TabIndex = 28;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.Close_Click);
            // 
            // reviewPanel
            // 
            this.reviewPanel.AutoScroll = true;
            this.reviewPanel.BackColor = System.Drawing.Color.White;
            this.reviewPanel.Location = new System.Drawing.Point(20, 82);
            this.reviewPanel.Name = "reviewPanel";
            this.reviewPanel.Size = new System.Drawing.Size(500, 231);
            this.reviewPanel.TabIndex = 26;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(420, 16);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 27);
            this.addButton.TabIndex = 25;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.Add_Click);
            // 
            // showsComboBox
            // 
            this.showsComboBox.FormattingEnabled = true;
            this.showsComboBox.Location = new System.Drawing.Point(107, 18);
            this.showsComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.showsComboBox.Name = "showsComboBox";
            this.showsComboBox.Size = new System.Drawing.Size(307, 24);
            this.showsComboBox.TabIndex = 21;
            this.showsComboBox.SelectedIndexChanged += new System.EventHandler(this.Shows_SelectedIndexChanged);
            // 
            // showLabel
            // 
            this.showLabel.AutoSize = true;
            this.showLabel.Location = new System.Drawing.Point(17, 21);
            this.showLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.showLabel.Name = "showLabel";
            this.showLabel.Size = new System.Drawing.Size(82, 16);
            this.showLabel.TabIndex = 20;
            this.showLabel.Text = "Select Show";
            // 
            // ReviewManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 342);
            this.ControlBox = false;
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.reviewPanel);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.showsComboBox);
            this.Controls.Add(this.showLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReviewManage";
            this.Text = "Review Manage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel reviewPanel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ComboBox showsComboBox;
        private System.Windows.Forms.Label showLabel;
    }
}