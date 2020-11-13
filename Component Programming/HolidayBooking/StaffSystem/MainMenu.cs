using DatabaseLibrary;
using StaffSystem.Properties;
using System;
using System.Windows.Forms;


namespace StaffSystem
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }


        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            loggedIn();
        }


        // Check if user is logged in
        private void loggedIn()
        {
            LoginForm login = new LoginForm();
            string username = Settings.Default.username;
            
            // If no username is set
            if (string.IsNullOrEmpty(username))
            {
                this.Hide();

                // Loop until logged in
                while (true)
                {
                    login.ShowDialog();
                    username = Settings.Default.username;

                    // If username is set
                    if (!string.IsNullOrEmpty(username))
                    {
                        userIDLabel.Text = "Username: " + username;
                        this.Show();
                        break;
                    }
                }
            }
        }


        private void BookLeaveButton_Click(object sender, EventArgs e)
        {
            // Open booking form
            this.Hide();
            new BookingForm().ShowDialog();
            this.Show();
        }


        private void RequestButton_Click(object sender, EventArgs e)
        {
            // Open requests form
            this.Hide();
            new Requests().ShowDialog();
            this.Show();
        }


        private void LogoutButton_Click(object sender, EventArgs e)
        {
            // Reset login details
            userIDLabel.Text = "";
            Properties.Settings.Default.username = null;
            
            loggedIn();
        }
    }
}
