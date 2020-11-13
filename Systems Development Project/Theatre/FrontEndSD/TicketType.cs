
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FrontEndSD
{
    public partial class TicketType : Form
    {
        /* Declare variables */
        private double total = 0;
        private int seatIndex = 0;
        private bool success = false;
        private Show show;
        private Seat seat;

        public bool Success { get => success; }


        public TicketType(Show show, Seat seat)
        {
            InitializeComponent();

            // Set objects
            this.show = show;
            this.seat = seat;

            messageLabel.Text = $"Would you like to reserve selected seat:\n \nSeat {seat.Name}"; // Set text

            ticketTypeComboBox.SelectedIndex = 0; // Set starting index


            // Sets form opening position on screen - currently central
            Rectangle dimension = Screen.FromControl(this).Bounds; // Gets screen dimentions
            this.Location = new Point((dimension.Width / 2) - (this.Width / 2), (dimension.Height / 2) - (this.Height / 2)); // Sets form location
        }


        /* Selected ticket type changed */
        private void TicketType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Sets data for selected type
            switch (ticketTypeComboBox.SelectedIndex)
            {
                // Adult
                case 0:
                    priceLabel.Text = "+£5";
                    total = this.seat.Price + 5; // Selected seat price plus 5
                    seatIndex = 1;
                    seat.Type = "Adult";
                    break;

                // Senior
                case 1:
                    priceLabel.Text = "+£4";
                    total = this.seat.Price + 4; // Selected seat price plus 4
                    seatIndex = 2;
                    seat.Type = "Senior";
                    break;

                // Child
                case 2:
                    priceLabel.Text = "+£3";
                    total = this.seat.Price + 3; // Selected seat price plus 3
                    seatIndex = 3;
                    seat.Type = "Child";
                    break;
            }

            priceLabel.Refresh(); // Refreshes label
        }


        /* Confirm button */
        private void Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                // If successful at selecting ticket
                if (total != 0 && seatIndex != 0) 
                {
                    string id = (show.Name + show.Date + seat.Name).GetHashCode().ToString().Replace(@"-", ""); // Creates an ID
                    Ticket ticket = new Ticket(id, Main.CurrentUser, show, seat, total); // Creates a ticket

                    TicketHold.temporary.Add(id, ticket); // Adds to temporary tickets
                    success = true;

                    this.Close(); // Closes current form
                    return;
                }

                // Failed to select ticket
                MessageBox.Show("Select a ticket type to continue", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // Error message
                success = false;

                this.Close(); // Closes current form
            }
            catch (Exception err)
            {
                Console.WriteLine(err);

                MessageBox.Show("Something didn't work it seems :( ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // Error message
                success = false;

                this.Close(); // Close current form
            }
        }


        /* Cancel button */
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Close current form
        }
    }
}
