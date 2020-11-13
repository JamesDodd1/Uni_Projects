
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FrontEndSD
{
    public partial class Login : Form
    {
        /* Declare variables */
        private string username, password;
        private static int attempts = 3;

        private Database db = new Database(); // Creates an object of database class


        public Login() 
        {
            InitializeComponent();

            attemptsMsgLabel.Visible = false;

            // Sets form opening position on screen - currently central
            Rectangle dimension = Screen.FromControl(this).Bounds; // Gets screen dimentions
            this.Location = new Point((dimension.Width / 2) - (this.Width / 2), (dimension.Height / 2) - (this.Height / 2)); // Sets form location
        }
        

        /* Login button */
        private void Login_Click(object sender, EventArgs e)
        {
            // Get entered data
			username = usernameTextBox.Text;
            password = passwordTextBox.Text;


            if (attempts == 0) // If no more attempts left
            {
                // Current user locked out
                attemptsMsgLabel.Text = ("No more attempts, contact admin");
                this.usernameTextBox.Enabled = false;
                this.passwordTextBox.Enabled = false;
                this.loginButton.Enabled = false;
            }
            else if (attempts > 0)
            {
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password)) // If something is entered into both textboxes
                {
                    User account = db.LoginCheck(username, password); // Gets user with username and password entered

                    if (account != null) // If account exists
                    {
                        UserFactory factory = null;

                        if (account.IsStaff) // User is staff
                            factory = new StaffFactory(account.ID, account.AccountNo, account.Username, account.Password, account.FirstName, account.LastName, account.Email, account.Address, account.PostCode, account.DateOfBirth);
                        else if (account.IsAdmin) // User is an admin
                            factory = new AdminFactory(account.ID, account.AccountNo, account.Username, account.Password);
                        else // User is a customer
                            factory = new CustomerFactory(account.ID, account.AccountNo, account.Username, account.Password, account.FirstName, account.LastName, account.Email, account.Address, account.PostCode, account.DateOfBirth);
                        
                        Main.CurrentUser = factory.CreateUser(); // Set current user to created user type

                        MessageBox.Show("You are granted access"); // Conformation message
                        this.Close(); // Close current form
                    }
                    else // If account does not exist
                    {
                        attempts--;
                        MessageBox.Show("You are not granted access!"); // Error message

                        attemptsMsgLabel.Text = ("You Have Only " + Convert.ToString(attempts + 1) + " Attempts Left To Try"); // Update attempts label text
                        attemptsMsgLabel.Visible = true;
                    }
                }
                else // If either of the textboxes are empty
                    MessageBox.Show("You haven't filled in all the fields.  Please try again!"); // Error message
            }

            // Clears textboxes
            usernameTextBox.Clear();
            passwordTextBox.Clear();
        }


        /* Cancel button */
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes current form
        }
    }
}
