
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FrontEndSD
{
    public partial class Account : Form
    {
        /* Declare variables */
        int idIndex = 0;
        private DateTime today = DateTime.Now;

        private List<User> users = new List<User>();
        private User person = new Guest();
        private static User currentUser = Main.CurrentUser; // Current user 

        private Database db = new Database(); // Object of database class


        public Account()
        {
            InitializeComponent();

            SetTextboxes(); // Loads data into textboxes
        }


        /* Sets textbox initial values */
        private void SetTextboxes()
        {
            if (currentUser.IsAdmin) // If current user is an admin
            {
                idComboBox.Enabled = true;
                users = db.GetUsers(); // Get all users from the database

                // Loop through each user
                foreach (User user in users)
                    idComboBox.Items.Add(user.AccountNo); // Adds account number's to idComoboBox

                // Resets fields
                usernameTextBox.Clear();
                passwordTextBox.Clear();
                firstNameTextBox.Clear();
                lastNameTextBox.Clear();
                emailTextBox.Clear();
                addressTextBox.Clear();
                postCodeTextBox.Clear();
                dobDateTimeBox.Value = DateTime.Now;

                // Sets deletedCheckBox properties
                deletedCheckBox.Visible = true;
                deletedCheckBox.Checked = false;
            }
            else // If current user is not an admin
            {
                // Adds user's information to the fields
                idComboBox.Items.Add(currentUser.AccountNo);
                usernameTextBox.Text = currentUser.Username;
                passwordTextBox.Text = currentUser.Password;
                firstNameTextBox.Text = currentUser.FirstName;
                lastNameTextBox.Text = currentUser.LastName;
                emailTextBox.Text = currentUser.Email;
                addressTextBox.Text = currentUser.Address;
                postCodeTextBox.Text = currentUser.PostCode;
                dobDateTimeBox.Value = currentUser.DateOfBirth;
            }

            idComboBox.SelectedIndex = idIndex; // Combobox displays first item (initially set to 0 - first item in list)
        }


        /* idComboBox value changes */
        private void ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentUser.IsAdmin) // If current user is an admin
            {
                idIndex = idComboBox.SelectedIndex; // Stores current combobox index
                person = users[idIndex]; // Stores selected user
                
                // Sets field values
                usernameTextBox.Text = person.Username;
                passwordTextBox.Text = person.Password;
                firstNameTextBox.Text = person.FirstName;
                lastNameTextBox.Text = person.LastName;
                emailTextBox.Text = person.Email;
                addressTextBox.Text = person.Address;
                postCodeTextBox.Text = person.PostCode;
                dobDateTimeBox.Value = person.DateOfBirth;
                deletedCheckBox.Checked = person.IsDeleted;
            }


            // Disable fields
            usernameTextBox.Enabled = false;
            passwordTextBox.Enabled = false;
            firstNameTextBox.Enabled = false;
            lastNameTextBox.Enabled = false;
            emailTextBox.Enabled = false;
            addressTextBox.Enabled = false;
            postCodeTextBox.Enabled = false;
            dobDateTimeBox.Enabled = false;
        }


        /* Edit button */
        private void Edit_Click(object sender, EventArgs e)
        {
            // Enable fields
            usernameTextBox.Enabled = true;
            passwordTextBox.Enabled = true;
            firstNameTextBox.Enabled = true;
            lastNameTextBox.Enabled = true;
            emailTextBox.Enabled = true;
            addressTextBox.Enabled = true;
            postCodeTextBox.Enabled = true;
            dobDateTimeBox.Enabled = true;
        }


        /* Save button */
        private void Save_Click(object sender, EventArgs e)
        {
            // Get field's info
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string email = emailTextBox.Text;
            string address = addressTextBox.Text;
            string postCode = postCodeTextBox.Text;
            DateTime dateOfBirth = dobDateTimeBox.Value;
            bool deleted = deletedCheckBox.Checked;


            int id = 0;
            if (currentUser.IsAdmin)   // If current user is an admin
                id = person.ID; // ID of select user from combobox
            else              // If current user is not an admin
                id = currentUser.ID; // ID from current user


            // If all textboxes have data and dateOfBirth is before today and after 1900
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password) && string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(address) && string.IsNullOrEmpty(postCode) && dateOfBirth < today && dateOfBirth > new DateTime(1900, 1, 1))
            {
                bool usernameTaken = db.UsernameTaken(username); // Checks if username is taken

                
                if (!usernameTaken) // If username is free to use
                {
                    if (currentUser.IsAdmin) // If current user is an admin
                        db.DeleteAccount(id, deleted); // Deletes/Restores account

                    db.UpdateAccount(id, username, password, firstName, lastName, email, address, postCode, dateOfBirth); // Updates account in the database
                    MessageBox.Show("Your details have been changed"); // Conformation message box appears

                    // Updates current user
                    if (!currentUser.IsAdmin) // If user is not an admin - admin account's are not displayed so only non admins can edit their own account
                    {
                        UserFactory factory = new CustomerFactory(currentUser.ID, currentUser.AccountNo, username, password, firstName, lastName, email, address, postCode, dateOfBirth); // Sets factory for customer 
                        Main.CurrentUser = factory.CreateUser();  // Creates customer and update CurrentUser
                    }
                }
                else // If username is not free to use
                    MessageBox.Show("Username Taken"); // Error message
            }
            else // If one of the fields does not have the correct data
                MessageBox.Show("You haven't filled in all the fields.  Please try again!"); // Error message
        }


        /* Cancel button */
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes current form
        }
    }
}
