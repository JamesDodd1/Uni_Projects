
namespace FrontEndSD
{
    partial class Register
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
            this.accountTypeComboBox = new System.Windows.Forms.ComboBox();
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
            this.SuspendLayout();
            // 
            // accountTypeComboBox
            // 
            this.accountTypeComboBox.Enabled = false;
            this.accountTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.accountTypeComboBox.FormattingEnabled = true;
            this.accountTypeComboBox.Location = new System.Drawing.Point(125, 340);
            this.accountTypeComboBox.Name = "accountTypeComboBox";
            this.accountTypeComboBox.Size = new System.Drawing.Size(150, 24);
            this.accountTypeComboBox.TabIndex = 59;
            this.accountTypeComboBox.Visible = false;
            // 
            // dobLabel
            // 
            this.dobLabel.AutoSize = true;
            this.dobLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dobLabel.Location = new System.Drawing.Point(22, 303);
            this.dobLabel.Name = "dobLabel";
            this.dobLabel.Size = new System.Drawing.Size(38, 17);
            this.dobLabel.TabIndex = 56;
            this.dobLabel.Text = "DOB";
            // 
            // postCodeTextBox
            // 
            this.postCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.postCodeTextBox.Location = new System.Drawing.Point(125, 260);
            this.postCodeTextBox.Name = "postCodeTextBox";
            this.postCodeTextBox.Size = new System.Drawing.Size(150, 23);
            this.postCodeTextBox.TabIndex = 55;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.saveButton.Location = new System.Drawing.Point(25, 385);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 27);
            this.saveButton.TabIndex = 54;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.Save_Click);
            // 
            // dobDateTimeBox
            // 
            this.dobDateTimeBox.CustomFormat = "dd-MM-yyyy";
            this.dobDateTimeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dobDateTimeBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dobDateTimeBox.Location = new System.Drawing.Point(125, 300);
            this.dobDateTimeBox.Name = "dobDateTimeBox";
            this.dobDateTimeBox.Size = new System.Drawing.Size(150, 23);
            this.dobDateTimeBox.TabIndex = 53;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addressTextBox.Location = new System.Drawing.Point(125, 220);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(150, 23);
            this.addressTextBox.TabIndex = 52;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.emailTextBox.Location = new System.Drawing.Point(125, 180);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(150, 23);
            this.emailTextBox.TabIndex = 51;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lastNameTextBox.Location = new System.Drawing.Point(125, 140);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(150, 23);
            this.lastNameTextBox.TabIndex = 50;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.firstNameTextBox.Location = new System.Drawing.Point(125, 100);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(150, 23);
            this.firstNameTextBox.TabIndex = 49;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.passwordTextBox.Location = new System.Drawing.Point(125, 60);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(150, 23);
            this.passwordTextBox.TabIndex = 48;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.passwordLabel.Location = new System.Drawing.Point(22, 63);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(69, 17);
            this.passwordLabel.TabIndex = 47;
            this.passwordLabel.Text = "Password";
            // 
            // postCodeLabel
            // 
            this.postCodeLabel.AutoSize = true;
            this.postCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.postCodeLabel.Location = new System.Drawing.Point(22, 263);
            this.postCodeLabel.Name = "postCodeLabel";
            this.postCodeLabel.Size = new System.Drawing.Size(73, 17);
            this.postCodeLabel.TabIndex = 46;
            this.postCodeLabel.Text = "Post Code";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addressLabel.Location = new System.Drawing.Point(22, 223);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(60, 17);
            this.addressLabel.TabIndex = 45;
            this.addressLabel.Text = "Address";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.emailLabel.Location = new System.Drawing.Point(22, 183);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(42, 17);
            this.emailLabel.TabIndex = 44;
            this.emailLabel.Text = "Email";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lastNameLabel.Location = new System.Drawing.Point(22, 143);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(76, 17);
            this.lastNameLabel.TabIndex = 43;
            this.lastNameLabel.Text = "Last Name";
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.firstNameLabel.Location = new System.Drawing.Point(22, 103);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(76, 17);
            this.firstNameLabel.TabIndex = 42;
            this.firstNameLabel.Text = "First Name";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.usernameTextBox.Location = new System.Drawing.Point(125, 20);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(150, 23);
            this.usernameTextBox.TabIndex = 41;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.usernameLabel.Location = new System.Drawing.Point(22, 23);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(73, 17);
            this.usernameLabel.TabIndex = 40;
            this.usernameLabel.Text = "Username";
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cancelButton.Location = new System.Drawing.Point(175, 385);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 27);
            this.cancelButton.TabIndex = 39;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 421);
            this.ControlBox = false;
            this.Controls.Add(this.accountTypeComboBox);
            this.Controls.Add(this.dobLabel);
            this.Controls.Add(this.postCodeTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.dobDateTimeBox);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.postCodeLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.cancelButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Register";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox accountTypeComboBox;
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
    }
}
