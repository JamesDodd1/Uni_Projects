using DatabaseLibrary;
using Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminSystem
{
    public partial class LeaveForm : Form
    {
        // Declare variables 
        private Database db = new Database();
        private int row = -1;


        public LeaveForm()
        {
            InitializeComponent();

            SetColumns();
            SetFields();
        }


        private void SetColumns()
        {
            // Set column titles
            userList.Columns.Add("Username", 60);
            userList.Columns.Add("Full Name", 150);

            // Add columns to list view
            userList.View = View.Details;
        }


        private void SetFields()
        {
            foreach (Employee staff in db.GetAllStaff())
            {
                ListViewItem item = new ListViewItem();

                // Adds values to items
                item.Text = (staff.Username);
                item.SubItems.Add(staff.FirstName + " " + staff.LastName);

                // Adds data to userList
                userList.Items.Add(item);
            }
        }


        private void UserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If a new item focused on 
            if (row != userList.FocusedItem.Index)
            {
                // Get username for selected item
                row = userList.FocusedItem.Index;
                ListViewItem item = userList.Items[row];
                string username = item.SubItems[0].Text;

                // Display username's holidays on calendar
                DisplayHolidays(username);
            }
        }


        private void DisplayHolidays(string username)
        {
            leaveCalendar.Clear();

            // Add each holiday to calendar
            foreach (Holidays holiday in db.GetLeave(username))
            {
                leaveCalendar.BookHoliday(holiday.Start, holiday.End);
            }
        }


        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
