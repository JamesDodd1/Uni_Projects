
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FrontEndSD
{
    public partial class Register : Form
    {
        /* Declare variables */
        private User currentUser = Main.CurrentUser; // Gets current user
        private DateTime today = DateTime.Now; // Gets current date
        private Database db = new Database();  // Creates an object of database class


        public Register()
        {
            InitializeComponent();

            AccountTypeView();

            // Sets form opening position on screen - currently central
            Rectangle dimension = Screen.FromControl(this).Bounds; // Gets screen dimentions
            this.Location = new Point((dimension.Width / 2) - (this.Width / 2), (dimension.Height / 2) - (this.Height / 2)); // Sets form location
        }


        /* Regsiter Layout */
        private void AccountTypeView()
        {
            // Adds items to combobox
            accountTypeComboBox.Items.Add("Customer");
            accountTypeComboBox.Items.Add("Staff");
            accountTypeComboBox.SelectedIndex = 0; // Sets starting index

            if (currentUser.IsAdmin) // If current user is an admin
            {
                // Enable combobox
                this.accountTypeComboBox.Enabled = true;
                this.accountTypeComboBox.Visible = true;
            }
            else // if current user is not an admin
            {
                // Disable combobox
                this.accountTypeComboBox.Enabled = false;
                this.accountTypeComboBox.Visible = false;
            }
        }


        /* Save button */
        private void Save_Click(object sender, EventArgs e)
        {
            // Textbox info
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string email = emailTextBox.Text;
            string address = addressTextBox.Text;
            string postCode = postCodeTextBox.Text;
            DateTime dateOfBirth = DateTime.Parse(dobDateTimeBox.Text);


            // If field are not empty and dateOfBirth is before today and after 1900
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(address) && !string.IsNullOrEmpty(postCode) && dateOfBirth < today && dateOfBirth > new DateTime(1900, 1, 1))
            {
                bool usernameTaken = db.UsernameTaken(username); // Check is username is taken within the database

                if (usernameTaken == false) // If not taken
                {
                    if (accountTypeComboBox.SelectedIndex == 0) // Customer
                        db.InsertCustomer(username, password, firstName, lastName, email, address, postCode, dateOfBirth); // Inserts new customer into the databse
                    else if (accountTypeComboBox.SelectedIndex == 1) // Staff
                        db.InsertStaff(username, password, firstName, lastName, email, address, postCode, dateOfBirth); // Inserts new staff into the database 

                    // Clears textboxes
                    usernameTextBox.Clear();
                    passwordTextBox.Clear();
                    firstNameTextBox.Clear();
                    lastNameTextBox.Clear();
                    emailTextBox.Clear();
                    addressTextBox.Clear();
                    postCodeTextBox.Clear();

                    MessageBox.Show("You are now a registered customer"); // Conformation message
                    this.Close(); // Close current form
                }
                else if (usernameTaken == true) // If username take within database
                    MessageBox.Show("Username Taken"); // Error message
            }
            else // If fields entered are incorrect
                MessageBox.Show("You haven't filled in all the fields.  Please try again!"); // Error message
        }


        /* Cancel button */
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Close current form
        }
    }
}
