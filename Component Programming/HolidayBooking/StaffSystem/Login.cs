using DatabaseLibrary;
using Libraries;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Collections.Generic;
using StaffSystem.Properties;
using StaffSystem.ServiceReference;

namespace StaffSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Store login form data
            string username = userNameTextBox.Text;
            string password = passwordTextBox.Text;
  
            // Validate fields
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                Database db = new Database();
                Encrypt encrypt = new Encrypt();

                bool result =  db.CheckLogin(username, encrypt.Encryption(password));

                // If login successsful
                if (result)
                {
                    // Save username
                    Settings.Default.username = username;
                    Settings.Default.Save();

                    // Close form
                    this.Close();
                }
                else
                {
                    //If user and/or password don't match within the database
                    MessageBox.Show("Incorrect username or password");
                }
            }
            else
            {
                // Fields haven't been entered
                MessageBox.Show("Error with username and/or password fields");
            }
        }
    }
}
