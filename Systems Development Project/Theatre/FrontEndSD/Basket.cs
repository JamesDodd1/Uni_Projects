
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FrontEndSD
{
    public partial class Basket : Form
    {
        /* Declare variables */
        private string msg = "";
        private double total = 0;
        private bool sendTickets = false;

        private Panel ticketPanel; // Panel for each ticket
        private static User currentUser = Main.CurrentUser; // Current user

        private Database db = new Database(); // Creates an object of database class


        public Basket()
        {
            InitializeComponent();


            // Adds tickets to basket
            int locY = 3;
            foreach (Ticket ticket in TicketHold.basket.Values)
            {
                ticketPanel = new TicketPanel(locY, ticket.ID, ticket.Show, ticket.Seat, ticket.TotalCost); // Creates ticketPanel
                this.basketPanel.Controls.Add(ticketPanel); // Adds ticketPanel to basketPanel

                locY += 120; // New Y position
                total += ticket.Show.Cost; // Adds show cost to total
            }

            totalLabel.Text = $"£{total}"; // Displays total cost


            if (TicketHold.basket.Count != 0) // If basket is empty
            {
                // Enable buttons
                buyButton.Enabled = true;
                clearButton.Enabled = true;
            }
            else // If basket is not empty
            {
                // Disable buttons
                buyButton.Enabled = false;
                clearButton.Enabled = false;
            }


            // Sets form opening position on screen - currently central
            Rectangle dimension = Screen.FromControl(this).Bounds; // Gets screen dimentions
            this.Location = new Point((dimension.Width / 2) - (this.Width / 2), (dimension.Height / 2) - (this.Height / 2)); // Sets form location
        }


        /* Clear button */
        private void Clear_Click(object sender, EventArgs e)
        {
            TicketHold.basket.Clear();    // Clears basket
            basketPanel.Controls.Clear(); // Clears basketPanel
        }


        /* Buy button */
        private void Buy_Click(object sender, EventArgs e)
        {
            if (TicketHold.basket.Count != 0)
            {
                // Sending ticket message box
                DialogResult sending = MessageBox.Show("Would you like the tickets sent to you", "Sending Tickets", MessageBoxButtons.YesNo);

                if (sending == DialogResult.Yes)
                {
                    sendTickets = true;
                    msg = "The ticekts you have bought will be sent to your address";
                }
                else if (sending == DialogResult.No)
                {
                    sendTickets = false;
                    msg = "The tickets you have bought will be stored at the theatre.  They can be collected any time before the show starts";
                }


                // Adding to the database
                foreach (var element in TicketHold.basket)
                {
                    Ticket ticket = element.Value;


                    // Inserts new ticket to database
                    db.InsertTicket(ticket.User.ID, ticket.Show.PerformanceID, ticket.Seat.SeatID, total, sendTickets);


                    // Inserts new PerformanceSeat to database
                    db.InsertPerformanceSeat(ticket.Show.PerformanceID, ticket.Seat.SeatID);
                }


                // Complete message box
                MessageBox.Show(msg, "Bought", MessageBoxButtons.OK, MessageBoxIcon.None);

                this.Close();
            }
            else
                MessageBox.Show("Please select a show");
        }

        
        /* Cancel button */
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes current form
        }
    }
}
