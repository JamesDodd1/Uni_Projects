using DatabaseLibrary;
using System;
using System.Windows.Forms;


namespace Register
{
    public partial class StaffDetailsForm : Form
    {
        // Declare variables
        private ListViewItem item;
        private Database db = new Database();


        public StaffDetailsForm()
        {
            InitializeComponent();
        }


        private void AdminForm_Load(object sender, EventArgs e)
        {
            refreshListButton.PerformClick();
        }


        private void CreateButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RegisterForm().ShowDialog();
            this.Show();

            refreshListButton.PerformClick();
        }


        private void refreshListButton_Click(object sender, EventArgs e)
        {
            userListView.Clear();
            SetColumns();
            SetFields();
        }


        private void SetColumns()
        {
            // Set column titles
            userListView.Columns.Add("Username", 100);
            userListView.Columns.Add("Full Name", 200);
            userListView.Columns.Add("Department", 100);
            userListView.Columns.Add("Role", 100);
            userListView.Columns.Add("Employed", 100);
            userListView.Columns.Add("Join Date", 100);

            // Add columns to list view
            userListView.View = View.Details;
        }


        private void SetFields()
        {
            var enumerator = db.GetAllStaff().GetEnumerator();

            while (enumerator.MoveNext())
            {
                item = new ListViewItem();

                // Adds values to item
                item.Text = (enumerator.Current.Username);
                item.SubItems.Add(enumerator.Current.FirstName + " " + enumerator.Current.LastName);
                item.SubItems.Add(enumerator.Current.DepartmentName);
                item.SubItems.Add(enumerator.Current.RoleName);
                item.SubItems.Add(enumerator.Current.Employed.ToString());
                item.SubItems.Add(enumerator.Current.JoinDate.ToShortDateString());

                // Adds data to userListView
                userListView.Items.Add(item);
            }
        }


        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get username of selected item
                int row = userListView.FocusedItem.Index;
                item = userListView.Items[row];
                string user = item.SubItems[0].Text;

                // Open edit form
                this.Hide();
                new EditUserForm(user).ShowDialog();
                this.Show();
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1);
            }

            refreshListButton.PerformClick();
        }


        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get username of selected item
                int row = userListView.FocusedItem.Index;
                item = userListView.Items[row];
                string user = item.SubItems[0].Text;

                if (db.DeleteStaff(user))
                    MessageBox.Show(user + " has been deleted");
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1);
            }

            refreshListButton.PerformClick();
        }


        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
