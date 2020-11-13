
using System;

namespace FrontEndSD
{
    public class Review
    {
        /* Declare variables */
        private int reviewID, showID, accountID, rating;
        private string showReview;
        private DateTime date;
        private bool deleted;


        /* Default constructor */
        public Review()
        {
            this.reviewID = 0;
            this.showID = 0;
            this.accountID = 0;
            this.showReview = "";
            this.date = new DateTime();
            this.rating = 0;
            this.deleted = false;
        }


        public Review(int reviewID, int showID, int accountID, string showReview, DateTime date, int rating, bool deleted)
        {
            this.reviewID = reviewID;
            this.showID = showID;
            this.accountID = accountID;
            this.showReview = showReview;
            this.date = date;
            this.rating = rating;
            this.deleted = deleted;
        }


        /* Get/Set methods */
        public int ReviewID { get => reviewID;  }
        public int ShowID { get => showID; set => showID = value; }
        public int AccountID { get => accountID; set => accountID = value; }
        public string ShowReview { get => showReview; set => showReview = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Rating { get => rating; set => rating = value; }
        public bool Deleted { get => deleted; set => deleted = value; }
    }
}
