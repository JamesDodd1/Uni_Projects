namespace Register
{
    partial class EditUserForm
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
            this.submitButton = new System.Windows.Forms.Button();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.employedLabel = new System.Windows.Forms.Label();
            this.adminLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.joinedLabel = new System.Windows.Forms.Label();
            this.phoneNumLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.dateOfBirthLabel = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordResetButton = new System.Windows.Forms.Button();
            this.departmentLabel = new System.Windows.Forms.Label();
            this.groupBoxEditUser = new System.Windows.Forms.GroupBox();
            this.phoneNumTextBox = new Components.PhoneNum(this.components);
            this.departmentComboBox = new System.Windows.Forms.ComboBox();
            this.roleComboBox = new System.Windows.Forms.ComboBox();
            this.RoleLabel = new System.Windows.Forms.Label();
            this.dateOfBirthDateTime = new System.Windows.Forms.DateTimePicker();
            this.joinedDateTime = new System.Windows.Forms.DateTimePicker();
            this.employedComboBox = new System.Windows.Forms.ComboBox();
            this.adminComboBox = new System.Windows.Forms.ComboBox();
            this.groupBoxEditUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(356, 650);
            this.submitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(133, 39);
            this.submitButton.TabIndex = 7;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(142, 230);
            this.addressTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(300, 22);
            this.addressTextBox.TabIndex = 15;
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Location = new System.Drawing.Point(142, 130);
            this.surnameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(300, 22);
            this.surnameTextBox.TabIndex = 14;
            this.surnameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SurnameTextBox_KeyPress);
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(142, 80);
            this.firstNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(300, 22);
            this.firstNameTextBox.TabIndex = 13;
            this.firstNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FirstNameTextBox_KeyPress);
            // 
            // employedLabel
            // 
            this.employedLabel.AutoSize = true;
            this.employedLabel.Location = new System.Drawing.Point(19, 533);
            this.employedLabel.Name = "employedLabel";
            this.employedLabel.Size = new System.Drawing.Size(109, 16);
            this.employedLabel.TabIndex = 10;
            this.employedLabel.Text = "Employed/Active:";
            // 
            // adminLabel
            // 
            this.adminLabel.AutoSize = true;
            this.adminLabel.Location = new System.Drawing.Point(79, 483);
            this.adminLabel.Name = "adminLabel";
            this.adminLabel.Size = new System.Drawing.Size(49, 16);
            this.adminLabel.TabIndex = 9;
            this.adminLabel.Text = "Admin:";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(22, 650);
            this.backButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(85, 39);
            this.backButton.TabIndex = 5;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // joinedLabel
            // 
            this.joinedLabel.AutoSize = true;
            this.joinedLabel.Location = new System.Drawing.Point(48, 433);
            this.joinedLabel.Name = "joinedLabel";
            this.joinedLabel.Size = new System.Drawing.Size(80, 16);
            this.joinedLabel.TabIndex = 8;
            this.joinedLabel.Text = "Date Joined:";
            // 
            // phoneNumLabel
            // 
            this.phoneNumLabel.AutoSize = true;
            this.phoneNumLabel.Location = new System.Drawing.Point(30, 283);
            this.phoneNumLabel.Name = "phoneNumLabel";
            this.phoneNumLabel.Size = new System.Drawing.Size(98, 16);
            this.phoneNumLabel.TabIndex = 6;
            this.phoneNumLabel.Text = "Phone Number:";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(68, 233);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(60, 16);
            this.addressLabel.TabIndex = 5;
            this.addressLabel.Text = "Address:";
            // 
            // dateOfBirthLabel
            // 
            this.dateOfBirthLabel.AutoSize = true;
            this.dateOfBirthLabel.Location = new System.Drawing.Point(44, 183);
            this.dateOfBirthLabel.Name = "dateOfBirthLabel";
            this.dateOfBirthLabel.Size = new System.Drawing.Size(84, 16);
            this.dateOfBirthLabel.TabIndex = 4;
            this.dateOfBirthLabel.Text = "Date of Birth:";
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Location = new System.Drawing.Point(64, 133);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(64, 16);
            this.surnameLabel.TabIndex = 3;
            this.surnameLabel.Text = "Surname:";
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(52, 83);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(76, 16);
            this.firstNameLabel.TabIndex = 2;
            this.firstNameLabel.Text = "First Name:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(57, 33);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(71, 16);
            this.usernameLabel.TabIndex = 1;
            this.usernameLabel.Text = "Username:";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.usernameTextBox.Location = new System.Drawing.Point(142, 30);
            this.usernameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.ReadOnly = true;
            this.usernameTextBox.Size = new System.Drawing.Size(300, 22);
            this.usernameTextBox.TabIndex = 0;
            // 
            // passwordResetButton
            // 
            this.passwordResetButton.Location = new System.Drawing.Point(181, 650);
            this.passwordResetButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.passwordResetButton.Name = "passwordResetButton";
            this.passwordResetButton.Size = new System.Drawing.Size(133, 39);
            this.passwordResetButton.TabIndex = 6;
            this.passwordResetButton.Text = "Password Reset";
            this.passwordResetButton.UseVisualStyleBackColor = true;
            this.passwordResetButton.Click += new System.EventHandler(this.PasswordResetButton_Click);
            // 
            // departmentLabel
            // 
            this.departmentLabel.AutoSize = true;
            this.departmentLabel.Location = new System.Drawing.Point(49, 383);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.Size = new System.Drawing.Size(79, 16);
            this.departmentLabel.TabIndex = 7;
            this.departmentLabel.Text = "Department:";
            // 
            // groupBoxEditUser
            // 
            this.groupBoxEditUser.Controls.Add(this.phoneNumTextBox);
            this.groupBoxEditUser.Controls.Add(this.departmentComboBox);
            this.groupBoxEditUser.Controls.Add(this.roleComboBox);
            this.groupBoxEditUser.Controls.Add(this.RoleLabel);
            this.groupBoxEditUser.Controls.Add(this.dateOfBirthDateTime);
            this.groupBoxEditUser.Controls.Add(this.joinedDateTime);
            this.groupBoxEditUser.Controls.Add(this.employedComboBox);
            this.groupBoxEditUser.Controls.Add(this.adminComboBox);
            this.groupBoxEditUser.Controls.Add(this.addressTextBox);
            this.groupBoxEditUser.Controls.Add(this.surnameTextBox);
            this.groupBoxEditUser.Controls.Add(this.firstNameTextBox);
            this.groupBoxEditUser.Controls.Add(this.employedLabel);
            this.groupBoxEditUser.Controls.Add(this.adminLabel);
            this.groupBoxEditUser.Controls.Add(this.joinedLabel);
            this.groupBoxEditUser.Controls.Add(this.departmentLabel);
            this.groupBoxEditUser.Controls.Add(this.phoneNumLabel);
            this.groupBoxEditUser.Controls.Add(this.addressLabel);
            this.groupBoxEditUser.Controls.Add(this.dateOfBirthLabel);
            this.groupBoxEditUser.Controls.Add(this.surnameLabel);
            this.groupBoxEditUser.Controls.Add(this.firstNameLabel);
            this.groupBoxEditUser.Controls.Add(this.usernameLabel);
            this.groupBoxEditUser.Controls.Add(this.usernameTextBox);
            this.groupBoxEditUser.Location = new System.Drawing.Point(29, 22);
            this.groupBoxEditUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxEditUser.Name = "groupBoxEditUser";
            this.groupBoxEditUser.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxEditUser.Size = new System.Drawing.Size(470, 600);
            this.groupBoxEditUser.TabIndex = 4;
            this.groupBoxEditUser.TabStop = false;
            this.groupBoxEditUser.Text = "groupBoxEditUser";
            // 
            // phoneNumTextBox
            // 
            this.phoneNumTextBox.ForeColor = System.Drawing.Color.Black;
            this.phoneNumTextBox.Location = new System.Drawing.Point(142, 280);
            this.phoneNumTextBox.Name = "phoneNumTextBox";
            this.phoneNumTextBox.Size = new System.Drawing.Size(300, 22);
            this.phoneNumTextBox.TabIndex = 16;
            // 
            // departmentComboBox
            // 
            this.departmentComboBox.FormattingEnabled = true;
            this.departmentComboBox.Location = new System.Drawing.Point(142, 380);
            this.departmentComboBox.Name = "departmentComboBox";
            this.departmentComboBox.Size = new System.Drawing.Size(300, 24);
            this.departmentComboBox.TabIndex = 25;
            // 
            // roleComboBox
            // 
            this.roleComboBox.FormattingEnabled = true;
            this.roleComboBox.Location = new System.Drawing.Point(142, 330);
            this.roleComboBox.Name = "roleComboBox";
            this.roleComboBox.Size = new System.Drawing.Size(300, 24);
            this.roleComboBox.TabIndex = 24;
            // 
            // RoleLabel
            // 
            this.RoleLabel.AutoSize = true;
            this.RoleLabel.Location = new System.Drawing.Point(90, 333);
            this.RoleLabel.Name = "RoleLabel";
            this.RoleLabel.Size = new System.Drawing.Size(38, 16);
            this.RoleLabel.TabIndex = 23;
            this.RoleLabel.Text = "Role:";
            // 
            // dateOfBirthDateTime
            // 
            this.dateOfBirthDateTime.Location = new System.Drawing.Point(142, 180);
            this.dateOfBirthDateTime.Name = "dateOfBirthDateTime";
            this.dateOfBirthDateTime.Size = new System.Drawing.Size(300, 22);
            this.dateOfBirthDateTime.TabIndex = 22;
            // 
            // joinedDateTime
            // 
            this.joinedDateTime.Location = new System.Drawing.Point(142, 430);
            this.joinedDateTime.Name = "joinedDateTime";
            this.joinedDateTime.Size = new System.Drawing.Size(300, 22);
            this.joinedDateTime.TabIndex = 21;
            // 
            // employedComboBox
            // 
            this.employedComboBox.FormattingEnabled = true;
            this.employedComboBox.Items.AddRange(new object[] {
            "True",
            "False"});
            this.employedComboBox.Location = new System.Drawing.Point(142, 530);
            this.employedComboBox.Name = "employedComboBox";
            this.employedComboBox.Size = new System.Drawing.Size(300, 24);
            this.employedComboBox.TabIndex = 20;
            // 
            // adminComboBox
            // 
            this.adminComboBox.FormattingEnabled = true;
            this.adminComboBox.Items.AddRange(new object[] {
            "True",
            "False"});
            this.adminComboBox.Location = new System.Drawing.Point(142, 480);
            this.adminComboBox.Name = "adminComboBox";
            this.adminComboBox.Size = new System.Drawing.Size(300, 24);
            this.adminComboBox.TabIndex = 19;
            // 
            // EditUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 711);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.passwordResetButton);
            this.Controls.Add(this.groupBoxEditUser);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EditUserForm";
            this.Text = "EditUser";
            this.Load += new System.EventHandler(this.EditUserForm_Load);
            this.groupBoxEditUser.ResumeLayout(false);
            this.groupBoxEditUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label employedLabel;
        private System.Windows.Forms.Label adminLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label joinedLabel;
        private System.Windows.Forms.Label phoneNumLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label dateOfBirthLabel;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Button passwordResetButton;
        private System.Windows.Forms.Label departmentLabel;
        private System.Windows.Forms.GroupBox groupBoxEditUser;
        private System.Windows.Forms.ComboBox departmentComboBox;
        private System.Windows.Forms.ComboBox roleComboBox;
        private System.Windows.Forms.Label RoleLabel;
        private System.Windows.Forms.DateTimePicker dateOfBirthDateTime;
        private System.Windows.Forms.DateTimePicker joinedDateTime;
        private System.Windows.Forms.ComboBox employedComboBox;
        private System.Windows.Forms.ComboBox adminComboBox;
        private Components.PhoneNum phoneNumTextBox;
    }
}