using AdminSystem.Properties;
using System;
using System.Windows.Forms;


namespace AdminSystem
{
    public partial class MainMenuForm : Form
    {
        // Declare variable
        private string username;


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
            username = Settings.Default.username;
            
            // If no username set
            if (string.IsNullOrEmpty(username))
            {
                this.Hide();

                // Loop until logged in
                while (true)
                {
                    login.ShowDialog();
                    username = Settings.Default.username;

                    // If username set
                    if (!string.IsNullOrEmpty(username))
                    {
                        userIDLabel.Text = "Username: " + username;
                        this.Show();
                        break;
                    }
                }
            }
        }


        private void LeaveBookedButton_Click(object sender, EventArgs e)
        {
            // Open leave form
            this.Hide();
            new LeaveForm().ShowDialog();
            this.Show();
        }


        private void RequestButton_Click(object sender, EventArgs e)
        {
            // Open requests form
            this.Hide();
            new RequestForm().ShowDialog();
            this.Show();
        }


        private void ViewStaffButton_Click(object sender, EventArgs e)
        {
            // Open view staff form
            this.Hide();
            new StaffDetailsForm().ShowDialog();
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
