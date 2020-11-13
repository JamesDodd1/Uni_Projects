using DatabaseLibrary;
using Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AdminSystem
{
    public partial class RequestForm : Form
    {
        // Declare variables
        private Database db = new Database();
        private List<Holidays> holidayList, passList, failList;
        private bool viewAll, outstand, viewDate, passConstraint = true;


        public RequestForm()
        {
            InitializeComponent();
        }


        private void RequestForm_Load(object sender, EventArgs e)
        {
            // Add constant data to the components
            SetupComponents();

            viewAllButton.PerformClick();
        }


        private void SetupComponents()
        {
            // Request Constraints component
            requestConstraints.Management = db.GetManagement();
            requestConstraints.SeniorStaff = db.GetSeniors();

            requestConstraints.DefaultTime = db.DefaultOnDuty();
            requestConstraints.TimePeriods = db.GetPeriodTimes();


            // Prioritising component
            prioritise.PeakTimes = db.GetPeakTimes();
        }


        private void RefreshListButton_Click(object sender, EventArgs e)
        {
            // Add current approved holidays to component
            List<Holidays> approved = db.GetApprovedHolidays();
            requestConstraints.AcceptedHolidays = approved;

            // If viewing outstanding holidays
            if (outstand)
            {
                CheckConstraints();

                // If viewing holidays which passed the constraints
                if (passConstraint)
                {
                    prioritise.ApprovedHolidays = approved;
                    prioritise.PrioritiseHolidays(passList);
                }
            }

            // Recreate user list
            userList.Clear();
            SetColumns();
            SetFields();
        }


        private void CheckConstraints()
        {
            passList = new List<Holidays>();
            failList = new List<Holidays>();

            foreach (Holidays holiday in holidayList)
            {
                // Add staff's role and dept total count to component
                requestConstraints.RoleTotal = db.GetTotalRoleNum(holiday.Staff.RoleName, holiday.Staff.DepartmentName);
                requestConstraints.DepartmentTotal = db.GetTotalDepartmentNum(holiday.Staff.DepartmentName);

                try 
                {
                    // Add returning errors to list
                    holiday.Error = requestConstraints.CheckHoliday(holiday);

                    // If any error found
                    if (holiday.Error != null)
                        failList.Add(holiday);
                    else
                        passList.Add(holiday);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }


        private void SetColumns()
        {
            // Set column titles
            userList.Columns.Add("Username", 60);
            userList.Columns.Add("Full Name", 150);

            if (viewDate)
                userList.Columns.Add("Status", 60);

            userList.Columns.Add("Start Date", 100);
            userList.Columns.Add("End Date", 100);
            userList.Columns.Add("Duration", 60);

            if (viewAll)
            {
                userList.Columns.Add("Pending", 60);
                userList.Columns.Add("Approved", 60);
                userList.Columns.Add("Cancelled", 60);
            }

            // Only show for contraint failing holidays
            if (outstand && !passConstraint)
                userList.Columns.Add("Errors", 100);

            // Add columns to list view
            userList.View = View.Details;
        }


        private void SetFields()
        {
            // Check if viewing outstanding holidays, then if pass constrains list, else general holiday list
            foreach (Holidays holiday in outstand ? (passConstraint ? passList : failList) : holidayList)
            { 
                ListViewItem item = new ListViewItem();

                // Adds values to item
                item.Text = (holiday.Staff.Username);
                item.SubItems.Add(holiday.Staff.FirstName + " " + holiday.Staff.LastName);


                // If viewing staff's holiday dates
                if (viewDate)
                {
                    item.SubItems.Add(holiday.Staff.Status ? "On Holiday" : "Working");

                    // If on holiday
                    if (holiday.Staff.Status)
                    {
                        item.SubItems.Add(holiday.Start.ToLongDateString());
                        item.SubItems.Add(holiday.End.ToLongDateString());

                        string duration = (holiday.End - holiday.Start).TotalDays.ToString();
                        item.SubItems.Add(duration);
                    }
                }
                else
                {
                    item.SubItems.Add(holiday.Start.ToLongDateString());
                    item.SubItems.Add(holiday.End.ToLongDateString());

                    string duration = (holiday.End - holiday.Start).TotalDays.ToString();
                    item.SubItems.Add(duration);
                }


                // If viewing all holidays
                if (viewAll)
                { 
                    item.SubItems.Add(holiday.Pending.ToString());
                    item.SubItems.Add(holiday.Approved.ToString());
                    item.SubItems.Add(holiday.Canceled.ToString());
                }


                // If viewing failing constraints holidays
                if (outstand && !passConstraint)
                {
                    string errors = "";
                    foreach (string err in holiday.Error)
                        errors += err + ". \n";

                    item.SubItems.Add(errors);
                }


                // Adds data to userListView
                userList.Items.Add(item);
            }
        }


        private void ViewAllButton_Click(object sender, EventArgs e)
        {
            // Get all holidays from database
            holidayList = db.GetAllHolidays();


            // Set viewing bool flags
            viewAll = true;
            outstand = false;
            viewDate = false;

            // Enable / disable buttons
            viewAllButton.Enabled = false;
            outstandButton.Enabled = true;
            viewDateButton.Enabled = true;

            acceptButton.Enabled = false;
            rejectButton.Enabled = false;

            passButton.Enabled = false;
            failButton.Enabled = false;

            // DateTime viewer invisible
            viewDateTime.Visible = false;


            refreshListButton.PerformClick();
        }


        private void OutstandButton_Click(object sender, EventArgs e)
        {
            // Get all outstanding holidays from database
            holidayList = db.GetAllOutstandingHolidays();


            // Set viewing bool flags
            viewAll = false;
            outstand = true;
            viewDate = false;

            // Enable / disable buttons
            viewAllButton.Enabled = true;
            outstandButton.Enabled = false;
            viewDateButton.Enabled = true;
            
            acceptButton.Enabled = true;
            rejectButton.Enabled = true;

            // If viewing contraint passing list
            if (passConstraint)
            {
                passButton.Enabled = false;
                failButton.Enabled = true;
            }
            else
            {
                passButton.Enabled = true;
                failButton.Enabled = false;
            }

            // DateTime viewer invisible
            viewDateTime.Visible = false;


            refreshListButton.PerformClick();
        }


        private void ViewDateButton_Click(object sender, EventArgs e)
        {
            // Get staff status for a day from database
            holidayList = db.GetStaffStatus(viewDateTime.Value);


            // Set viewing bool flags
            viewAll = false;
            outstand = false;
            viewDate = true;

            // Enable / disable buttons
            viewAllButton.Enabled = true;
            outstandButton.Enabled = true;
            viewDateButton.Enabled = false;

            acceptButton.Enabled = false;
            rejectButton.Enabled = false;
            
            // DateTime viewer visible
            viewDateTime.Visible = true;


            refreshListButton.PerformClick();
        }


        private void ViewDateTime_ValueChanged(object sender, EventArgs e)
        {
            // Get new list when date is changed
            holidayList = db.GetStaffStatus(viewDateTime.Value);

            refreshListButton.PerformClick();
        }


        private void PassButton_Click(object sender, EventArgs e)
        {
            // Set bool flag
            passConstraint = true;

            // Enable / disable buttons
            acceptButton.Enabled = true;
            passButton.Enabled = false;
            failButton.Enabled = true;

            refreshListButton.PerformClick();
        }


        private void FailButton_Click(object sender, EventArgs e)
        {
            acceptButton.Enabled = false;
            passConstraint = false;

            passButton.Enabled = true;
            failButton.Enabled = false;

            refreshListButton.PerformClick();
        }


        private void AcceptButton_Click(object sender, EventArgs e)
        {
            // Get values for selected row
            int row = userList.FocusedItem.Index;
            ListViewItem item = userList.Items[row];

            string username = item.SubItems[0].Text;
            DateTime startDate = Convert.ToDateTime(item.SubItems[2].Text);
            DateTime endDate = Convert.ToDateTime(item.SubItems[3].Text);

            // Update database
            if (db.ApproveBooking(username, startDate, endDate))
                MessageBox.Show(username + "\'s booking request has been accepted");

            outstandButton.Enabled = true;
            outstandButton.PerformClick();
        }


        private void RejectButton_Click(object sender, EventArgs e)
        {
            // Get values for selected row
            int row = userList.FocusedItem.Index;
            ListViewItem item = userList.Items[row];

            string username = item.SubItems[0].Text;
            DateTime startDate = Convert.ToDateTime(item.SubItems[2].Text);
            DateTime endDate = Convert.ToDateTime(item.SubItems[3].Text);

            // Update database
            if (db.RejectBooking(username, startDate, endDate))
                MessageBox.Show(username + "\'s booking request has been rejected");

            outstandButton.Enabled = true;
            outstandButton.PerformClick();
        }


        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    

        private void SelectedView(Button button)
        {
            // Set view all
            if (button.Name == viewAllButton.Name)
            {
                viewAllButton.Enabled = false;
                viewAll = true;

                // Disable buttons
                acceptButton.Enabled = false;
                rejectButton.Enabled = false;

                passButton.Enabled = false;
                failButton.Enabled = false;
            }
            else
            {
                viewAllButton.Enabled = true;
                viewAll = false;
            }


            // Set outstand
            if (button.Name == outstandButton.Name)
            {
                outstandButton.Enabled = false;
                outstand = true;

                // Enable buttons
                acceptButton.Enabled = true;
                rejectButton.Enabled = true;

                // If viewing contraint passing list
                if (passConstraint)
                {
                    passButton.Enabled = false;
                    failButton.Enabled = true;
                }
                else
                {
                    passButton.Enabled = true;
                    failButton.Enabled = false;
                }
            }
            else
            {
                outstandButton.Enabled = true;
                outstand = false;
            }


            // Set view date
            if (button.Name == viewDateButton.Name)
            {
                viewDateButton.Enabled = false;
                viewDateTime.Visible = true;
                viewDate = true;

                // Disable buttongs
                acceptButton.Enabled = false;
                rejectButton.Enabled = false;
            }
            else
            {
                viewDateButton.Enabled = true;
                viewDateTime.Visible = false;
                viewDate = false;
            }
        }
    }
}
