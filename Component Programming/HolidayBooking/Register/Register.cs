using DatabaseLibrary;
using Libraries;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Register
{
    public partial class RegisterForm : Form
    {
        // Declare variables
        private Database db = new Database();


        public RegisterForm()
        {
            InitializeComponent();
            SetComboBoxes();
        }


        // Set values to each ComboBox
        private void SetComboBoxes()
        {
            roleComboBox.DataSource = db.GetAllRoles();
            departmentComboBox.DataSource = db.GetAllDepartments();
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
            Encrypt encrypt = new Encrypt();

            // Store register form data
            string username = usernameTextBox.Text;
            string firstName = firstNameTextBox.Text;
            string lastName = surnameTextBox.Text;
            string password = encrypt.Encryption(passwordTextBox.Text);

            DateTime dateOfBirth = dateOfBirthDateTime.Value;

            string address = addressTextBox.Text;
            string phoneNum = phoneNumTextBox.Text;

            string department = departmentComboBox.Text;
            string role = roleComboBox.Text;


            // Validate Form
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && dateOfBirth < DateTime.Now && !string.IsNullOrEmpty(address) && !string.IsNullOrEmpty(phoneNum) && !phoneNumTextBox.Error)
            {
                if (!db.UsernameTaken(username))
                {
                    bool result = db.Register(firstName, lastName, password, username, dateOfBirth, address, phoneNum, role, department);

                    // If registration was successful 
                    if (result)
                    {
                        MessageBox.Show("New user created");

                        this.Close();
                    }
                    else
                        MessageBox.Show("Unable to register");
                }
                else
                    MessageBox.Show("Username already taken");
            }
            else 
                MessageBox.Show("Please fill all fields");
        }


        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
