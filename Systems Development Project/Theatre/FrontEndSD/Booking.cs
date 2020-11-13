
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FrontEndSD
{
    public partial class Booking : Form
    {
        /* Declare variables */
        private List<Show> shows = new List<Show>();
        private List<Dictionary<int, Show>> dateShows = new List<Dictionary<int, Show>>();
        private List<Show> timeShows = new List<Show>();

        private int showIndex = -1, dateIndex = -1, timeIndex = -1;

        private List<Show> plays = new List<Show>();
        private List<Show> performances = new List<Show>();

        private Database db = new Database(); // Create an object of database class


        public Booking(Show show)
        {
            InitializeComponent();


            SelectShowAddItems();

            // When enter by clicking on a specific show, gets the relevent show chosen
            if (!string.IsNullOrEmpty(show.Name)) // If not default show
            {
                int size = showComboBox.Items.Count; // Gets number of shows

                // Loops for number of items in combobox
                for (int i = 0; i < size; i++)
                {
                    string value = showComboBox.Items[i].ToString(); // Gets name of selected show

                    if (string.Compare(value, show.Name) == 0) // If clicked show and loop selection show match
                    {
                        showComboBox.SelectedIndex = i; // Set starting index
                        break; // Break when found entered show name
                    }
                }
            }
            else // If default show
                showComboBox.SelectedIndex = 0; // Sets starting index


            // Sets form opening position on screen - currently central
            Rectangle dimension = Screen.FromControl(this).Bounds; // Gets screen dimentions
            this.Location = new Point((dimension.Width / 2) - (this.Width / 2), (dimension.Height / 2) - (this.Height / 2)); // Sets form location
        }


        /* Adds show names to showComboBox */
        private void SelectShowAddItems()
        {
            plays = db.GetCurrentShows(); // Gets current shows from database

            // Loop for each play
            foreach (Show play in plays)
            {
                showComboBox.Items.Add(play.Name); // Adds play name to showComboBox
                shows.Add(play); // Adds play to shows list
            }
        }


        /* Adds show dates to dateComboBox */
        private void DateAddItems(Show show)
        {
            // Resets variables
            dateComboBox.Items.Clear();
            dateShows.Clear();
            performances.Clear();


            performances = db.GetCurrentPerformances(show.ShowID); // Gets all performanced for a show
            int showNo = 0;

            // Loops for each performance
            foreach (Show performance in performances)
            {
                if (showNo != 0) // If not first show in loop
                {
                    // If dates match nothing happens
                    if (string.Compare(performance.Date.ToString("dd/MM/yyyy"), performances[--showNo].Date.ToString("dd/MM/yyyy")) == 0) // Compares date to previous date
                        ; // Do nothing
                    else
                    {
                        showNo++; // Reincrements showNo to starting value
                        dateComboBox.Items.Add(performance.Date.ToString("dd/MM/yyyy"));
                    }
                }
                else // If first show in loop
                    dateComboBox.Items.Add(performance.Date.ToString("dd/MM/yyyy")); // Adds performance date to dateComboBox

                dateShows.Add( new Dictionary<int, Show>() { { showNo, performance } }); // Adds dicionary dateShow to list
                showNo++;
            }
        }


        /* Adds show times to timeComboBox */
        private void TimeAddItems()
        {
            // Resets variables
            timeComboBox.Items.Clear();
            timeShows.Clear();
            

            // Loop for each show
            foreach (var show in dateShows)
            {
                try
                {
                    timeComboBox.Items.Add(show[dateIndex].Date.ToString("HH:mm")); // Adds date (24 hour clock) to timeComboBox
                    timeShows.Add(show[dateIndex]); // Adds show to timeShows
                }
                catch (Exception) // When trying to view incorrect show
                {
                    continue; // Continue with next iteration of the loop
                }
            }
        }

        
        /* Show name changed */
        private void Show_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Resets form 
            dateComboBox.Items.Clear();
            timeComboBox.Items.Clear();
            seatsComboBox.Items.Clear();
            seatsComboBox.Enabled = false;
            seatButton.Enabled = true;
            timeIndex = -1;


            showIndex = showComboBox.SelectedIndex; // Stores showComboBox index
            DateAddItems(shows[showIndex]);         // Adds dates

            try
            {
                dateComboBox.SelectedIndex = 0; // Displays first item in dateComboBox
            }
            catch (Exception) // If nothing can be selected
            {
                dateComboBox.Text = null;   // Clears text
                dateComboBox.Items.Clear(); // Clears items
                seatButton.Enabled = false; // Disables seatButton
            }
        }


        /* Show date changed */
        private void Date_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Resets form
            seatsComboBox.Items.Clear();
            seatsComboBox.Enabled = false;
            seatButton.Enabled = true;


            dateIndex = dateComboBox.SelectedIndex; // Stores dateComboBox index
            TimeAddItems();                         // Adds time

            try
            {
                timeComboBox.SelectedIndex = 0; // Displays first item in timeComboBox
            }
            catch (Exception) // If nothing can be selected
            {
                timeComboBox.Text = null;   // Clears text
                timeComboBox.Items.Clear(); // Clears items
                seatButton.Enabled = false; // Disables seatButton
            }
        }


        /* Show time changed */
        private void Time_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Resets form
            seatsComboBox.Items.Clear();
            seatsComboBox.Enabled = false;

            timeIndex = timeComboBox.SelectedIndex; // Stores timeComboBox index
        }


        /* Seat button */
        private void Seat_Click(object sender, EventArgs e)
        {
            try
            {
                // Checks all comboboxes aren't empty
                if (showIndex != -1 && dateIndex != -1 && timeIndex != -1)
                {
                    // Creates show based on info selected
                    Show show = new Show(timeShows[timeIndex].PerformanceID, shows[showIndex].ShowID, shows[showIndex].Name, shows[showIndex].Genre, timeShows[timeIndex].Date, shows[showIndex].StartDate, shows[showIndex].EndDate, timeShows[timeIndex].Cost, shows[showIndex].Description, shows[showIndex].Image, shows[showIndex].Rating);


                    // Changes cursor to waiting cursor
                    this.Cursor = Cursors.WaitCursor;

                    // Opens SeatingPlan form
                    SeatingPlan seatingPlan = new SeatingPlan(show); // Creates an object of the form
                    seatingPlan.ShowDialog();                        // Displays seatingPlan

                    // Resets cursor to arrow after for has loaded
                    this.Cursor = Cursors.Arrow;


                    if (seatingPlan.Success) // If a seat was selected
                    {
                        seatsComboBox.Items.Clear(); // Clears combobox

                        // Loops through each temporary ticket
                        foreach (Ticket ticket in TicketHold.temporary.Values)
                            seatsComboBox.Items.Add(ticket.Seat.Name + " - " + ticket.Seat.Type); // Add seats to seatsComboBox
                        
                        try
                        {
                            seatsComboBox.SelectedIndex = 0; // Display first value in seatsComboBox
                            seatsComboBox.Enabled = true;    // Enable seatsComboBox
                            basketButton.Enabled = true;     // Enable basketButton
                        }
                        catch (Exception) {  }
                    }
                    
                    return; // Stop method
                }
                MessageBox.Show("Missing required fields ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // Error message

            }
            catch (Exception)
            {
                MessageBox.Show("Something didn't work it seems :( ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // Error message
                this.Close(); // Close current form
            }
        }


        /* Basket button */
        private void Basket_Click(object sender, EventArgs e)
        {
            // Loops through each ticket in temporary
            foreach (var item in TicketHold.temporary)
                TicketHold.basket.Add(item.Key, item.Value); // Adds tickets to basket

            TicketHold.temporary.Clear(); // Clears temporary

            this.Hide(); // Hide current form

            // Open Basket form
            Basket basket = new Basket(); // Create object of the form
            basket.ShowDialog();          // Display basket
        }


        /* Cancel button */
        private void Cancel_Click(object sender, EventArgs e)
        {
            TicketHold.temporary.Clear(); // Clears temporary
            this.Close(); // Close current form
        }
    }
}
