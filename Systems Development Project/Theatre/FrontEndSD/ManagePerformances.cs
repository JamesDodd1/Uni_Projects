
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FrontEndSD
{
    public partial class ManagePerformances : Form
    {
        /* Declare variables */
        private List<Show> performances = new List<Show>();
        private Show performance = new Show();
        private Show show = new Show();
        
        private int performanceIndex;
        private int editFlag = 0; // 0 for Add, 1 for Edit, 2 for Remove
        private DateTime today = DateTime.Now; // Today's date

        private Database db = new Database(); // Creates an object for database class


        public ManagePerformances(Show show)
        {
            InitializeComponent();


            this.show = show;
            showTextBox.Text = show.Name; // Sets showTextBox 
            SelectPerformanceAddItems();  // Gets related performances


            // Sets form opening position on screen - currently central
            Rectangle dimension = Screen.FromControl(this).Bounds; // Gets screen dimentions
            this.Location = new Point((dimension.Width / 2) - (this.Width / 2), (dimension.Height / 2) - (this.Height / 2)); // Sets form location
        }


        /* Adds performances */
        private void SelectPerformanceAddItems()
        {
            performances = db.GetAllPerformances(show.ShowID); // Gets performances for a selected show

            // Loops for each performance
            foreach (Show play in performances)
                searchPerformancesComboBox.Items.Add(play.Date.ToString("dd/MM/yyyy HH:mm")); // Adds dates (24 hour time)
        }


        /* Reset form */
        private void ClearForm()
        {
            searchPerformancesComboBox.ResetText();
            dateCalendar.SetDate(today);
            costTextBox.Clear();
        }


        /* Add Show Button */
        private void Add_Click(object sender, EventArgs e)
        {
            // Set layout
            showLabel.Text = "Add Performance";
            performanceLabel.Visible = false;
            searchPerformancesComboBox.Visible = false;
            dateLabel.Visible = true;
            dateCalendar.Visible = true;
            costLabel.Visible = true;
            costTextBox.Visible = true;

            dateLabel.Location = new Point(12, 118);
            dateCalendar.Location = new Point(15, 140);
            costLabel.Location = new Point(398, 118);
            costTextBox.Location = new Point(446, 115);


            // Sets button locations
            continueButton.Location = new Point(412, 254);
            cancelButton.Location = new Point(412, 287);

            this.Size = new Size(550, 370); // Current form's size

            continueButton.Text = "Insert"; // Sets button text

            ClearForm(); // Resets layout

            editFlag = 0;
        }


        /* Edit Show Button */
        private void Edit_Click(object sender, EventArgs e)
        {
            // Set Layout
            showLabel.Text = "Edit Performance";
            performanceLabel.Visible = true;
            searchPerformancesComboBox.Visible = true;
            dateLabel.Visible = true;
            dateCalendar.Visible = true;
            costLabel.Visible = true;
            costTextBox.Visible = true;

            dateLabel.Location = new Point(12, 158);
            dateCalendar.Location = new Point(15, 180);
            costLabel.Location = new Point(398, 158);
            costTextBox.Location = new Point(446, 155);


            // Sets button locations
            continueButton.Location = new Point(412, 294);
            cancelButton.Location = new Point(412, 327);


            this.Size = new Size(550, 410); // Current form's layout

            continueButton.Text = "Save"; // Sets button text

            ClearForm(); // Resets layout

            editFlag = 1;
        }


        /* Remove Show Button */
        private void Remove_Click(object sender, EventArgs e)
        {
            // Sets form display
            performanceLabel.Text = "Remove Performance";
            searchPerformancesComboBox.Visible = true;
            dateLabel.Visible = false;
            dateCalendar.Visible = false;
            costLabel.Visible = false;
            costTextBox.Visible = false;


            // Sets button locations
            continueButton.Location = new Point(412, 155);
            cancelButton.Location = new Point(412, 188);

            
            this.Size = new Size(550, 271); // Current form's size


            // Sets button text
            if (show.ShowCancelled) // If show is cancelled
                continueButton.Text = "Restore";
            else
                continueButton.Text = "Delete";


            editFlag = 2;
        }


        /* Selected performance changed */
        private void SearchPerformances_SelectedIndexChanged(object sender, EventArgs e)
        {
            performanceIndex = searchPerformancesComboBox.SelectedIndex; // Stores combobox index
            performance = performances[performanceIndex];                // Saves show selected
            
            // Sets fields to selected show's info
            dateCalendar.SetDate(performance.Date);
            costTextBox.Text = performance.Cost.ToString();
        }


        /* Text entered into cost */
        private void Cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Only allows 2 dp
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -2))
            {
                e.Handled = true;
            }
        }


        /* Continue button */
        private void Continue_Click(object sender, EventArgs e)
        {
            // Get data from fields
            DateTime showDate = dateCalendar.SelectionRange.Start;
            double cost = Double.Parse(costTextBox.Text);


            if (editFlag == 0) // Adding
            {
                // Checks all fields aren't empty
                if (showDate >= today && cost > 0)
                    db.InsertPerformance(show.ShowID, cost, showDate); // Adds to database
                else
                    MessageBox.Show("At least one of the fields are incorrect"); // Error message
            }
            else if (editFlag == 1) // Editing
            {
                // Updates show within shows list
                performances[performanceIndex].StartDate = showDate;
                performances[performanceIndex].Cost = cost;

                // Updatse database
                db.UpdatePerformance(performance.PerformanceID, show.ShowID, cost, showDate);
            }
            else if (editFlag == 2) // Removing
            {
                if (show.ShowCancelled) // If show is currently cancelled
                    db.CancelPerformance(performance.PerformanceID, false); // Restore show
                else
                    db.CancelPerformance(performance.PerformanceID, true); // Cancel show
            }

            MessageBox.Show("Your changes have been made"); // Conformation message
        }


        /* Return button */
        private void Return_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes current form
        }
    }
}
