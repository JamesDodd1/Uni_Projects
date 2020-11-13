
using System;
using System.Collections.Generic;

namespace FrontEndSD
{
    static class TicketHold
    {
        /* Dictonary of tickets */
        public static Dictionary<String, Ticket> basket = new Dictionary<string, Ticket>();
        public static Dictionary<String, Ticket> temporary = new Dictionary<string, Ticket>();
    }


    class Ticket
    {
        /* Declare variables */
        private string id;
        private double totalCost;

        private User user;
        private Show show;
        private Seat seat;


        /* Default constructor */
        public Ticket()
        {
            this.id = null;
            this.user = new Guest();
            this.show = new Show();
            this.seat = new Seat();
            this.totalCost = 0;
        }


        public Ticket(string id, User user, Show show, Seat seat, double totalCost)
        {
            this.id = id;
            this.user = user;
            this.show = show;
            this.seat = seat;
            this.totalCost = totalCost;
        }
        

        /* Get/Set methods */
        public string ID { get => id; }
        public double TotalCost { get => totalCost; set => totalCost = value; }
        
        public User User { get => user; set => user = value; }
        public Show Show { get => show; set => show = value; }
        public Seat Seat { get => seat; set => seat = value; }
    }
}
