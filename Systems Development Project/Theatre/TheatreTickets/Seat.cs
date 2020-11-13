
namespace FrontEndSD
{
    public class Seat
    {
        /* Declare variables */
        private int seatID, row, column;
        private string name, type;
        private char band;
        private double price;
        private bool free;


        /* Default constructor */
        public Seat()
        {
            this.seatID = 0;
            this.name = null;
            this.band = ' ';
            this.price = 0;
            this.type = null;
            this.row = 0;
            this.column = 0;
            this.free = true;
        }


        public Seat(int seatID, string name, double price, int row, int column, bool free) : this()
        {
            this.seatID = seatID;
            this.name = name;
            this.price = price;
            this.row = row;
            this.column = column;
            this.free = free;
        }


        /* Get/Set methods */
        public int SeatID { get => seatID; }
        public string Name { get => name; }
        public char Band { get => band; set => band = value; }
        public double Price { get => price; set => price = value; }
        public int Row { get => row; }
        public int Column { get => column; }
        public string Type { get => type; set => type = value; }
        public bool Free { get => free; set => free = value; }
    }
}
