
namespace FrontEndSD
{
    partial class Account
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any image being used.
        /// </summary>
        /// <param name="disposing">true if managed image should be disposed; otherwise, false.</param>
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
            this.editButton = new System.Windows.Forms.Button();
            this.idLabel = new System.Windows.Forms.Label();
            this.dobLabel = new System.Windows.Forms.Label();
            this.postCodeTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.dobDateTimeBox = new System.Windows.Forms.DateTimePicker();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.postCodeLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.editAccountLabel = new System.Windows.Forms.Label();
            this.accountPanel = new System.Windows.Forms.Panel();
            this.deletedCheckBox = new System.Windows.Forms.CheckBox();
            this.idComboBox = new System.Windows.Forms.ComboBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.accountPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // editButton
            // 
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.editButton.Location = new System.Drawing.Point(39, 466);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(128, 27);
            this.editButton.TabIndex = 81;
            this.editButton.Text = "Edit Account";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.Edit_Click);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.idLabel.Location = new System.Drawing.Point(36, 63);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(21, 17);
            this.idLabel.TabIndex = 78;
            this.idLabel.Text = "ID";
            // 
            // dobLabel
            // 
            this.dobLabel.AutoSize = true;
            this.dobLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dobLabel.Location = new System.Drawing.Point(36, 385);
            this.dobLabel.Name = "dobLabel";
            this.dobLabel.Size = new System.Drawing.Size(38, 17);
            this.dobLabel.TabIndex = 77;
            this.dobLabel.Text = "DOB";
            // 
            // postCodeTextBox
            // 
            this.postCodeTextBox.Enabled = false;
            this.postCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.postCodeTextBox.Location = new System.Drawing.Point(131, 340);
            this.postCodeTextBox.Name = "postCodeTextBox";
            this.postCodeTextBox.Size = new System.Drawing.Size(237, 23);
            this.postCodeTextBox.TabIndex = 76;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.saveButton.Location = new System.Drawing.Point(191, 466);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(128, 27);
            this.saveButton.TabIndex = 75;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.Save_Click);
            // 
            // dobDateTimeBox
            // 
            this.dobDateTimeBox.CustomFormat = "dd-MM-yyyy";
            this.dobDateTimeBox.Enabled = false;
            this.dobDateTimeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dobDateTimeBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dobDateTimeBox.Location = new System.Drawing.Point(131, 380);
            this.dobDateTimeBox.Name = "dobDateTimeBox";
            this.dobDateTimeBox.Size = new System.Drawing.Size(237, 23);
            this.dobDateTimeBox.TabIndex = 74;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Enabled = false;
            this.addressTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addressTextBox.Location = new System.Drawing.Point(131, 300);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(237, 23);
            this.addressTextBox.TabIndex = 73;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Enabled = false;
            this.emailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.emailTextBox.Location = new System.Drawing.Point(131, 260);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(237, 23);
            this.emailTextBox.TabIndex = 72;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Enabled = false;
            this.lastNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lastNameTextBox.Location = new System.Drawing.Point(131, 220);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(237, 23);
            this.lastNameTextBox.TabIndex = 71;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Enabled = false;
            this.firstNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.firstNameTextBox.Location = new System.Drawing.Point(131, 180);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(237, 23);
            this.firstNameTextBox.TabIndex = 70;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Enabled = false;
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.passwordTextBox.Location = new System.Drawing.Point(131, 140);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(237, 23);
            this.passwordTextBox.TabIndex = 69;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.passwordLabel.Location = new System.Drawing.Point(36, 143);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(69, 17);
            this.passwordLabel.TabIndex = 68;
            this.passwordLabel.Text = "Password";
            // 
            // postCodeLabel
            // 
            this.postCodeLabel.AutoSize = true;
            this.postCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.postCodeLabel.Location = new System.Drawing.Point(36, 343);
            this.postCodeLabel.Name = "postCodeLabel";
            this.postCodeLabel.Size = new System.Drawing.Size(73, 17);
            this.postCodeLabel.TabIndex = 67;
            this.postCodeLabel.Text = "Post Code";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addressLabel.Location = new System.Drawing.Point(36, 303);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(60, 17);
            this.addressLabel.TabIndex = 66;
            this.addressLabel.Text = "Address";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.emailLabel.Location = new System.Drawing.Point(36, 263);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(42, 17);
            this.emailLabel.TabIndex = 65;
            this.emailLabel.Text = "Email";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lastNameLabel.Location = new System.Drawing.Point(36, 223);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(76, 17);
            this.lastNameLabel.TabIndex = 64;
            this.lastNameLabel.Text = "Last Name";
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.firstNameLabel.Location = new System.Drawing.Point(36, 183);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(76, 17);
            this.firstNameLabel.TabIndex = 63;
            this.firstNameLabel.Text = "First Name";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Enabled = false;
            this.usernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.usernameTextBox.Location = new System.Drawing.Point(131, 100);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(237, 23);
            this.usernameTextBox.TabIndex = 62;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.usernameLabel.Location = new System.Drawing.Point(36, 103);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(73, 17);
            this.usernameLabel.TabIndex = 61;
            this.usernameLabel.Text = "Username";
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cancelButton.Location = new System.Drawing.Point(351, 466);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(129, 27);
            this.cancelButton.TabIndex = 60;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // editAccountLabel
            // 
            this.editAccountLabel.AutoSize = true;
            this.editAccountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editAccountLabel.Location = new System.Drawing.Point(20, 19);
            this.editAccountLabel.Name = "editAccountLabel";
            this.editAccountLabel.Size = new System.Drawing.Size(187, 18);
            this.editAccountLabel.TabIndex = 1;
            this.editAccountLabel.Text = "Change your acount details";
            // 
            // accountPanel
            // 
            this.accountPanel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.accountPanel.Controls.Add(this.deletedCheckBox);
            this.accountPanel.Controls.Add(this.idComboBox);
            this.accountPanel.Controls.Add(this.editButton);
            this.accountPanel.Controls.Add(this.idLabel);
            this.accountPanel.Controls.Add(this.dobLabel);
            this.accountPanel.Controls.Add(this.postCodeTextBox);
            this.accountPanel.Controls.Add(this.saveButton);
            this.accountPanel.Controls.Add(this.dobDateTimeBox);
            this.accountPanel.Controls.Add(this.addressTextBox);
            this.accountPanel.Controls.Add(this.emailTextBox);
            this.accountPanel.Controls.Add(this.lastNameTextBox);
            this.accountPanel.Controls.Add(this.firstNameTextBox);
            this.accountPanel.Controls.Add(this.passwordTextBox);
            this.accountPanel.Controls.Add(this.passwordLabel);
            this.accountPanel.Controls.Add(this.postCodeLabel);
            this.accountPanel.Controls.Add(this.addressLabel);
            this.accountPanel.Controls.Add(this.emailLabel);
            this.accountPanel.Controls.Add(this.lastNameLabel);
            this.accountPanel.Controls.Add(this.firstNameLabel);
            this.accountPanel.Controls.Add(this.usernameTextBox);
            this.accountPanel.Controls.Add(this.usernameLabel);
            this.accountPanel.Controls.Add(this.cancelButton);
            this.accountPanel.Controls.Add(this.editAccountLabel);
            this.accountPanel.Location = new System.Drawing.Point(36, 82);
            this.accountPanel.Name = "accountPanel";
            this.accountPanel.Size = new System.Drawing.Size(517, 526);
            this.accountPanel.TabIndex = 6;
            // 
            // deletedCheckBox
            // 
            this.deletedCheckBox.AutoSize = true;
            this.deletedCheckBox.Location = new System.Drawing.Point(131, 420);
            this.deletedCheckBox.Name = "deletedCheckBox";
            this.deletedCheckBox.Size = new System.Drawing.Size(76, 21);
            this.deletedCheckBox.TabIndex = 83;
            this.deletedCheckBox.Text = "Deleted";
            this.deletedCheckBox.UseVisualStyleBackColor = true;
            this.deletedCheckBox.Visible = false;
            // 
            // idComboBox
            // 
            this.idComboBox.Enabled = false;
            this.idComboBox.FormattingEnabled = true;
            this.idComboBox.Location = new System.Drawing.Point(131, 60);
            this.idComboBox.Name = "idComboBox";
            this.idComboBox.Size = new System.Drawing.Size(237, 24);
            this.idComboBox.TabIndex = 82;
            this.idComboBox.SelectedIndexChanged += new System.EventHandler(this.ID_SelectedIndexChanged);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(32, 33);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(243, 24);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "Personal Account Details";
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 641);
            this.ControlBox = false;
            this.Controls.Add(this.accountPanel);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Account";
            this.Text = "Account";
            this.accountPanel.ResumeLayout(false);
            this.accountPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label dobLabel;
        private System.Windows.Forms.TextBox postCodeTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DateTimePicker dobDateTimeBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label postCodeLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label editAccountLabel;
        private System.Windows.Forms.Panel accountPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ComboBox idComboBox;
        private System.Windows.Forms.CheckBox deletedCheckBox;
    }
}
