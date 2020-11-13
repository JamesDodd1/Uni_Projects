
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FrontEndSD
{
    public partial class SeatingPlan : Form
    {
        /* Declares variables */
        private Dictionary<string, Seat> seats = new Dictionary<string, Seat>();
        private Show show;

        private int alphabetCount = 74;
        private char alphabet;
        private bool success = false;
        private double bandA_Price = 0, bandB_Price = 0, bandC_Price = 0;

        private Database db = new Database(); // Creates an object of the database class


        // Get method
        public bool Success { get => success; }


        public SeatingPlan(Show show)
        {
            InitializeComponent();

            this.show = show;

            
            // Sets band prices
            bandA_Price = db.BandCost('A'); // Gets A band cost from the database
            bandB_Price = db.BandCost('B'); // Gets B band cost from the database 
            bandC_Price = db.BandCost('C'); // Gets C band cost from the database


            CreateTheatre(); // Creates theatre layout
            

            // Sets form opening position on screen - currently central
            Rectangle dimension = Screen.FromControl(this).Bounds; // Gets screen dimentions
            this.Location = new Point((dimension.Width / 2) - (this.Width / 2), (dimension.Height / 2) - (this.Height / 2)); // Sets form location
        }


        /* Creates the theatre layout */
        private void CreateTheatre()
        {
            seatingPanel.Controls.Clear(); // Clears panel

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeatingPlan));

            // Loops for all seating rows
            int locY = 10, seatID = 137;
            for (int row = 0; row < 12; row++)
            {
                // No row of seats for the fifth and eight row
                if (row != 4 && row != 7)
                {
                    // Loops for every seat on a row
                    int locX = 5;
                    for (int column = 1; column <= 16; column++)
                    {
                        // No seats for the eigth and nineth column beyond the eigth row
                        if ((row > 7 && column != 8 && column != 9) || row < 7)
                        {
                            double price = SeatPrice(row, column); // Get set price
                            PictureBox seat = new PictureBox();    // Create PictureBox
                            
                            alphabet = (char)alphabetCount; // alphabet - starts at J and ends at A


                            // Box for each seat
                            ((System.ComponentModel.ISupportInitialize)(seat)).BeginInit();

                            // Sets seat properties
                            seat.Location = new Point(locX, locY);
                            seat.Name = $"{alphabet}{column}"; // Letter followed by Number (eg A1 or D14)
                            seat.Size = new Size(20, 20);
                            seat.SizeMode = PictureBoxSizeMode.Zoom;
                            seat.TabIndex = 26;
                            seat.TabStop = false;

                            seats.Add(seat.Name, new Seat(seatID, seat.Name, price, row, column, true)); // Adds seat to seats dictionary

                            if ( db.SeatFree(show.PerformanceID, seatID) ) // If seat is free within the database
                            {
                                // Enable seat
                                seat.Image = BandSeatImage(row, column);
                                seat.Click += new EventHandler(Seat_Click); // Adds click event
                            }
                            else // If seat is taken within the database
                            {
                                // Disable seat
                                seat.Image = Properties.Resources.XredLogo;
                                seat.Enabled = false;
                                seats[seat.Name].Free = false;
                            }

                            ((System.ComponentModel.ISupportInitialize)(seat)).EndInit();


                            // Seat info tip
                            ToolTip tip = new ToolTip();
                            tip.ShowAlways = true;
                            tip.SetToolTip(seat, $"{seat.Name}\n£{price}");


                            this.seatingPanel.Controls.Add(seat); // Adds seat to panel

                            seatID++;
                        }
                        locX += 30; // New X position
                    }
                    // Sets seatID to correct number for the start of the next row
                    if (row == 6)
                        seatID -= 30; 
                    else if (row > 7)
                        seatID -= 28;
                    else
                        seatID -= 32;

                    alphabetCount--;
                }
                locY += 30; // New Y position
            }
        }


        /* Gets seat image */
        private Bitmap BandSeatImage(int row, int col)
        {
            // Sets image depending on row and column
            if (row < 2)
                return Properties.Resources.SeatBandC;
            if (row < 4)
                if (col > 4 && col < 13)
                    return Properties.Resources.SeatBandB;
                else
                    return Properties.Resources.SeatBandC;
            else if (row < 8)
                return Properties.Resources.SeatBandB;
            else
                return Properties.Resources.SeatBandA;
        }


        /* Gets cost for a seat */
        private double SeatPrice(int row, int column)
        {
            // Sets cost depending on row and column
            if (row < 2)
                return bandA_Price;
            else if (row < 4)
                if (column > 4 && column < 13)
                    return bandB_Price;
                else
                    return bandA_Price;
            else if (row < 8)
                return bandB_Price;
            else
                return bandC_Price;
        }


        /* Gets seat band */
        private char SeatBand(double price)
        {
            if (price == bandA_Price)
                return 'A';
            else if (price == bandB_Price)
                return 'B';
            else
                return 'C';
        }

        
        /* Seat */
        private void Seat_Click(object sender, EventArgs e)
        {
            PictureBox chair = (PictureBox)sender;
            chair.BackColor = Color.Transparent;

            Seat seat = seats[chair.Name]; // Gets selected seat


            if (seat.Free) // If seat is free
            {
                seat.Band = SeatBand(seat.Price); // Sets seat band

                if (seats.TryGetValue(chair.Name, out seat))
                {
                    // Opens TicketType form
                    TicketType ticketType = new TicketType(show, seat); // Creates an object of form
                    ticketType.ShowDialog();                            // Displays ticketType


                    // Seat to be reserved 
                    if (ticketType.Success)
                    {
                        // Change to taken seat image
                        chair.BackColor = Color.Transparent;
                        chair.Image = Properties.Resources.XredLogo; // Sets seat image to red X
                        seat.Free = false;
                    }
                }
            }
            else // If seat is taken
            {
                string id = (show.Name + show.Date + seat.Name).GetHashCode().ToString().Replace(@"-", ""); // Set complicated ID
                TicketHold.temporary.Remove(id); // Removes temporary ticket

                chair.Image = BandSeatImage(seat.Row, seat.Column); // Restores seat in seat image
                seat.Free = true;
            }
        }


        /* Select button */
        private void Select_Click(object sender, EventArgs e)
        {
            success = true;
            this.Close(); // Close current form
            return;
        }


        /* Cancel button */
        private void Cancel_Click(object sender, EventArgs e)
        {
            TicketHold.temporary.Clear(); // Clears temporary tickets
            this.Close(); // Closes current form
        }
    }
}
