using DatabaseLibrary;
using Libraries;
using System;
using System.Windows.Forms;


namespace Register
{
    public partial class EditUserForm : Form
    {
        // Declare variables
        private string user;
        private Database db = new Database();
        private Encrypt encrypt = new Encrypt();


        public EditUserForm(string user)
        {
            InitializeComponent();
            this.user = user;
        }


        private void EditUserForm_Load(object sender, EventArgs e)
        {
            SetComboBoxes();
            StaffDetails(db.GetStaff(user));
        }


        // Set values to each ComboBox
        private void SetComboBoxes()
        {
            roleComboBox.DataSource = db.GetAllRoles();
            departmentComboBox.DataSource = db.GetAllDepartments();
        }

      
        // Display staff details on screen
        private void StaffDetails(Employee staff)
        {
            usernameTextBox.Text = staff.Username;
            firstNameTextBox.Text = staff.FirstName;
            surnameTextBox.Text = staff.LastName;

            dateOfBirthDateTime.Value = staff.DoB;

            addressTextBox.Text = staff.Address;
            phoneNumTextBox.Text = staff.PhoneNumber;

            ComboBoxSelectedItem(roleComboBox, staff.RoleName);
            ComboBoxSelectedItem(departmentComboBox, staff.DepartmentName);

            joinedDateTime.Value = staff.JoinDate;

            ComboBoxSelectedItem(adminComboBox, staff.Admin);
            ComboBoxSelectedItem(employedComboBox, staff.Employed);
        }


        // Set ComboBox to select matching text
        private void ComboBoxSelectedItem(ComboBox comboBox, string selected)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (String.Equals(comboBox.Items[i].ToString(), selected))
                {
                    comboBox.SelectedIndex = i;
                    break;
                }
            }
        }


        // Set ComboBox to select matching boolean
        private void ComboBoxSelectedItem(ComboBox comboBox, bool selected)
        {
            for (int i = 0; i < 2; i++)
            {
                if (Convert.ToBoolean(comboBox.Items[i]) == selected)
                    comboBox.SelectedIndex = i;
            }
        }


        private void FirstNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow letters, punctuation and white space
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsPunctuation(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }


        private void SurnameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow letters, punctuation and white space
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsPunctuation(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }


        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Store edit form data
            string username = usernameTextBox.Text;
            string firstName = firstNameTextBox.Text;
            string lastName = surnameTextBox.Text;
            string address = addressTextBox.Text;
            string phoneNum = phoneNumTextBox.Text;
            string role = roleComboBox.Text;
            string department = departmentComboBox.Text;

            bool admin = Convert.ToBoolean(adminComboBox.Text);
            bool employed = Convert.ToBoolean(employedComboBox.Text);


            // Validate fields
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(address) && !string.IsNullOrEmpty(phoneNum))
            {
                if (db.EditStaff(username, firstName, lastName, address, phoneNum, employed, admin, role, department))
                    MessageBox.Show("Staff " + username + " has been updated");
                

                // Close form
                this.Close();
            }
            else
                MessageBox.Show("Please fill all fields");
        }


        private void PasswordResetButton_Click(object sender, EventArgs e)
        {
            // Default generated password 
            string newPassword = encrypt.Encryption("Password");
            string userID = usernameTextBox.Text;

           
            // If password is reset
            if (db.PasswordReset(userID, newPassword))
                MessageBox.Show("Password has changed to the defualt password, please inform the user");
        }
      
        
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
