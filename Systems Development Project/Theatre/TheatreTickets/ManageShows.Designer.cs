namespace FrontEndSD
{
    partial class ManageShows
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
            this.searchShowsComboBox = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.fileButton = new System.Windows.Forms.Button();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.removeBtton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.toLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.toCalendar = new System.Windows.Forms.MonthCalendar();
            this.fromCalendar = new System.Windows.Forms.MonthCalendar();
            this.addTextBox = new System.Windows.Forms.TextBox();
            this.showLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.genreLabel = new System.Windows.Forms.Label();
            this.genreTextBox = new System.Windows.Forms.TextBox();
            this.performanceButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchShowsComboBox
            // 
            this.searchShowsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.searchShowsComboBox.FormattingEnabled = true;
            this.searchShowsComboBox.Location = new System.Drawing.Point(122, 78);
            this.searchShowsComboBox.Name = "searchShowsComboBox";
            this.searchShowsComboBox.Size = new System.Drawing.Size(383, 24);
            this.searchShowsComboBox.TabIndex = 29;
            this.searchShowsComboBox.SelectedIndexChanged += new System.EventHandler(this.SearchShows_SelectedIndexChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cancelButton.Location = new System.Drawing.Point(412, 472);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(110, 27);
            this.cancelButton.TabIndex = 28;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // continueButton
            // 
            this.continueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.continueButton.Location = new System.Drawing.Point(412, 439);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(110, 27);
            this.continueButton.TabIndex = 27;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.Continue_Click);
            // 
            // fileButton
            // 
            this.fileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.fileButton.Location = new System.Drawing.Point(9, 127);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(100, 27);
            this.fileButton.TabIndex = 26;
            this.fileButton.Text = "Image File";
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.File_Click);
            // 
            // fileTextBox
            // 
            this.fileTextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.fileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.fileTextBox.Location = new System.Drawing.Point(122, 127);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.ReadOnly = true;
            this.fileTextBox.Size = new System.Drawing.Size(383, 23);
            this.fileTextBox.TabIndex = 25;
            // 
            // removeBtton
            // 
            this.removeBtton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.removeBtton.Location = new System.Drawing.Point(387, 12);
            this.removeBtton.Name = "removeBtton";
            this.removeBtton.Size = new System.Drawing.Size(100, 31);
            this.removeBtton.TabIndex = 24;
            this.removeBtton.Text = "REMOVE";
            this.removeBtton.UseVisualStyleBackColor = true;
            this.removeBtton.Click += new System.EventHandler(this.Remove_Click);
            // 
            // editButton
            // 
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.editButton.Location = new System.Drawing.Point(206, 12);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(100, 31);
            this.editButton.TabIndex = 23;
            this.editButton.Text = "EDIT";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.Edit_Click);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addButton.Location = new System.Drawing.Point(31, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 31);
            this.addButton.TabIndex = 22;
            this.addButton.Text = "ADD";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.Add_Click);
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.toLabel.Location = new System.Drawing.Point(275, 170);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(29, 17);
            this.toLabel.TabIndex = 21;
            this.toLabel.Text = "To:";
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.fromLabel.Location = new System.Drawing.Point(11, 170);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(44, 17);
            this.fromLabel.TabIndex = 20;
            this.fromLabel.Text = "From:";
            // 
            // toCalendar
            // 
            this.toCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.toCalendar.Location = new System.Drawing.Point(278, 192);
            this.toCalendar.Name = "toCalendar";
            this.toCalendar.TabIndex = 19;
            // 
            // fromCalendar
            // 
            this.fromCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.fromCalendar.Location = new System.Drawing.Point(14, 192);
            this.fromCalendar.Name = "fromCalendar";
            this.fromCalendar.TabIndex = 18;
            // 
            // addTextBox
            // 
            this.addTextBox.Location = new System.Drawing.Point(122, 78);
            this.addTextBox.Name = "addTextBox";
            this.addTextBox.Size = new System.Drawing.Size(383, 23);
            this.addTextBox.TabIndex = 17;
            // 
            // showLabel
            // 
            this.showLabel.AutoSize = true;
            this.showLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLabel.Location = new System.Drawing.Point(11, 78);
            this.showLabel.Name = "showLabel";
            this.showLabel.Size = new System.Drawing.Size(69, 16);
            this.showLabel.TabIndex = 16;
            this.showLabel.Text = "Add Show";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(93, 409);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(306, 155);
            this.descriptionTextBox.TabIndex = 35;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(8, 409);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(79, 17);
            this.descriptionLabel.TabIndex = 34;
            this.descriptionLabel.Text = "Description";
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Location = new System.Drawing.Point(12, 372);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(48, 17);
            this.genreLabel.TabIndex = 36;
            this.genreLabel.Text = "Genre";
            // 
            // genreTextBox
            // 
            this.genreTextBox.Location = new System.Drawing.Point(93, 369);
            this.genreTextBox.Name = "genreTextBox";
            this.genreTextBox.Size = new System.Drawing.Size(313, 23);
            this.genreTextBox.TabIndex = 37;
            // 
            // performanceButton
            // 
            this.performanceButton.Enabled = false;
            this.performanceButton.Location = new System.Drawing.Point(412, 518);
            this.performanceButton.Name = "performanceButton";
            this.performanceButton.Size = new System.Drawing.Size(110, 46);
            this.performanceButton.TabIndex = 38;
            this.performanceButton.Text = "View Performances";
            this.performanceButton.UseVisualStyleBackColor = true;
            this.performanceButton.Click += new System.EventHandler(this.Performance_Click);
            // 
            // ShowManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 576);
            this.ControlBox = false;
            this.Controls.Add(this.genreTextBox);
            this.Controls.Add(this.genreLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.fileButton);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.removeBtton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.toLabel);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.toCalendar);
            this.Controls.Add(this.fromCalendar);
            this.Controls.Add(this.showLabel);
            this.Controls.Add(this.searchShowsComboBox);
            this.Controls.Add(this.addTextBox);
            this.Controls.Add(this.performanceButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(550, 615);
            this.MinimumSize = new System.Drawing.Size(550, 238);
            this.Name = "ShowManage";
            this.Text = "Manage Shows";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox searchShowsComboBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button fileButton;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button removeBtton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.MonthCalendar toCalendar;
        private System.Windows.Forms.MonthCalendar fromCalendar;
        private System.Windows.Forms.TextBox addTextBox;
        private System.Windows.Forms.Label showLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.TextBox genreTextBox;
        private System.Windows.Forms.Button performanceButton;
    }
}