
using System;

namespace FrontEndSD
{
    public class Show
    {
        /* Declare variables */
        private int performanceID, showID, rating;
        private string name, genre, description, image;
        private DateTime date, startDate, endDate;
        private double cost;
        private bool showCancelled, performCancelled;


        /* Default Constructor */
        public Show()
        {
            this.performanceID = 0;
            this.showID = 0;
            this.name = null;
            this.genre = null;
            this.date = new DateTime();
            this.startDate = new DateTime();
            this.endDate = new DateTime();
            this.cost = 0;
            this.description = null;
            this.image = "Default.jpg";
            this.rating = 0;
            this.showCancelled = false;
            this.performCancelled = false;
        }


        /* Top Shows and Coming Soon */
        public Show(int showID, string name, string genre, DateTime startDate, DateTime endDate, string description, string image, int rating) : this()
        {
            this.showID = showID;
            this.name = name;
            this.genre = genre;
            this.startDate = startDate;
            this.endDate = endDate;
            this.description = description;
            this.image = image;
            this.rating = rating;
        }


        /* Current Shows - combines Performance and Show tables */
        public Show(int performanceID, int showID, string name, string genre, DateTime showDate, DateTime startDate, DateTime endDate, double cost, string description, string image, int rating) : this()
        {
            this.performanceID = performanceID;
            this.showID = showID;
            this.name = name;
            this.genre = genre;
            this.date = showDate;
            this.startDate = startDate;
            this.endDate = endDate;
            this.cost = cost;
            this.description = description;
            this.image = image;
            this.rating = rating;
        }


        /* Search shows */
        public Show(string name, string genre, DateTime showDate, DateTime startDate, DateTime endDate, string description, string image, int rating) : this()
        {
            this.name = name;
            this.genre = genre;
            this.date = showDate;
            this.startDate = startDate;
            this.endDate = endDate;
            this.description = description;
            this.image = image;
            this.rating = rating;
        }


        /* Complete Show table data */
        public Show(int showID, string name, string genre, DateTime startDate, DateTime endDate, string description, string image, int rating, bool showCancelled) : this()
        {
            this.showID = showID;
            this.name = name;
            this.genre = genre;
            this.startDate = startDate;
            this.endDate = endDate;
            this.description = description;
            this.image = image;
            this.rating = rating;
            this.showCancelled = showCancelled;
        }


        /* Performance table data */
        public Show(int performanceID, int showID, DateTime showDate, double cost, bool performCancelled) : this()
        {
            this.performanceID = performanceID;
            this.showID = showID;
            this.date = showDate;
            this.cost = cost;
            this.performCancelled = performCancelled;
        }


        /* Get/Set methods */
        public int PerformanceID { get => performanceID; }
        public int ShowID { get => showID; }
        public string Name { get => name; set => name = value; }
        public string Genre { get => genre; set => genre = value; }
        public DateTime Date { get => date; set => date = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public double Cost { get => cost; set => cost = value; }
        public string Description { get => description; set => description = value; }
        public string Image { get => image; set => image = value; }
        public int Rating { get => rating; set => rating = value; }
        public bool ShowCancelled { get => showCancelled; set => showCancelled = value; }
        public bool PerformCancelled { get => performCancelled; set => performCancelled = value; }
    }
}
