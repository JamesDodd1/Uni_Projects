
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FrontEndSD
{
    public partial class ManageReviews : Form
    {
        /* Declare variables */
        private List<List<string>> users = new List<List<string>>();
        private List<Show> shows = new List<Show>();
        private List<Review> reviews = new List<Review>();

        private static User currentUser = Main.CurrentUser; // Current user
        private Panel userReviewPanel;

        private int showsIndex = 0;

        private Database db = new Database(); // Create an object of database class


        public ManageReviews()
        {
            InitializeComponent();

            showsComboBox.Items.Clear();
            shows = db.GetCurrentShows(); // Gets current shows from the database
            AddShows();


            // Sets form opening position on screen - currently central
            Rectangle dimension = Screen.FromControl(this).Bounds; // Gets screen dimentions
            this.Location = new Point((dimension.Width / 2) - (this.Width / 2), (dimension.Height / 2) - (this.Height / 2)); // Sets form location
        }


        /* Adds shows names */
        private void AddShows()
        {
            // Loops for each play
            foreach (Show play in shows)
                showsComboBox.Items.Add(play.Name); // Adds play name to showsComboBox

            showsComboBox.SelectedIndex = 0; // Displays first value in combobox
        }


        /* Selected show changed */
        private void Shows_SelectedIndexChanged(object sender, EventArgs e)
        {
            reviewPanel.Controls.Clear(); // Clears panel
            showsIndex = showsComboBox.SelectedIndex; // Stores selected index


            // Gets reviews and set desplay depending on who the user is
            if (currentUser.IsAdmin) // If current user is an admin
                reviews = db.GetReviews(shows[showsIndex].ShowID, false); // Get reviews for show
            else // If current user is not an admin
                reviews = db.GetReviews(shows[showsIndex].ShowID, true); // Get reviews for show 

            
            int locY = 0; // Starting Y position

            // Loop for each review
            foreach (Review review in reviews)
            {
                userReviewPanel = new ReviewPanel(locY, currentUser, review); // Creates a ReviewPanel
                reviewPanel.Controls.Add(userReviewPanel); // Adds userReviewPanel to reviewPanel

                locY += 160; // New Y position
            }
        }


        /* Add button */
        private void Add_Click(object sender, EventArgs e)
        {
            // Opens AddReview
            AddReview addReview = new AddReview(shows[showsIndex]); // Creates an object for the form - AddReview class is below this one
            addReview.ShowDialog();                                       // Displays addReview
        }


        /* Close button */
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes current form
        }
    }



    public class AddReview : Form
    {
        /* Declare variables */
        private Label label;
        private ComboBox rating;
        private RichTextBox review;
        private Button button;

        private Show show;
        private User user = Main.CurrentUser; // Current user
        private Database db = new Database(); // Creates an object of the database class

        
        public AddReview(Show show)
        {
            Init(show);
        }

        private void Init(Show show)
        {
            // Sets objects
            this.label = new Label();
            this.rating = new ComboBox();
            this.review = new RichTextBox();
            
            this.show = show;


            // Adds objects to form
            this.Controls.Add(CreateLabel(10, 10, "title", $"Add a Review for {show.Name}", true));
            this.Controls.Add(CreateLabel(10, 185, "rating", "Rating:", false));
            this.Controls.Add(CreateLabel(10, 50, "review", "Review:", false));
            this.Controls.Add(rating);
            this.Controls.Add(review);
            this.Controls.Add(CreateButton(120, 180, "insert", "Insert", false));
            this.Controls.Add(CreateButton(220, 180, "close", "Close", true));


            // Set form properties
            Rectangle dimension = Screen.FromControl(this).Bounds; // Gets screen dimentions
            this.Location = new Point((dimension.Width / 2) - (this.Width / 2), (dimension.Height / 2) - (this.Height / 2)); // Sets form location
            this.Name = "AddReview";
            this.Text = "Add Review";
            this.Font = new Font("Mictosoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Size = new Size(340, 265);
            this.ControlBox = false;
            this.TabIndex = 0;


            // Sets rating properties
            this.rating.Name = "ratingComboBox";
            this.rating.Font = new Font("Microsoft Sans Serif", 10F);
            this.rating.Location = new Point(65, 182);
            this.rating.Size = new Size(40, 30);
            this.rating.Items.Add("5");
            this.rating.Items.Add("4");
            this.rating.Items.Add("3");
            this.rating.Items.Add("2");
            this.rating.Items.Add("1");
            this.rating.SelectedIndex = 2;
            this.rating.TabIndex = 2;


            // Sets review properties
            this.review.Name = "reviewRichTextBox";
            this.review.Font = new Font("Microsoft Sans Serif", 10F);
            this.review.Location = new Point(10, 70);
            this.review.Size = new Size(300, 100);
            this.review.TabIndex = 3;
        }


        /* Label creation */
        private Label CreateLabel(int locX, int locY, string name, string text, bool title)
        {
            // Create label
            label = new Label();
            

            // Sets label properties
            this.label.AutoSize = true;
            this.label.Name = $"{name}Label";
            this.label.Location = new Point(locX, locY);
            this.label.Text = text;
            this.label.TabIndex = 1;

            if (title) // If this is a title
                this.label.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            else // If this is not a title
                this.label.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            

            return label;
        }


        /* Button creation */
        private Button CreateButton(int locX, int locY, string name, string text, bool close)
        {
            // Create button
            button = new Button();


            // Sets button properties
            this.button.Name = $"{name}Button";
            this.button.Font = new Font("Microsoft Sans Serif", 10F);
            this.button.Location = new Point(locX, locY);
            this.button.Size = new Size(90, 27);
            this.button.BackColor = SystemColors.ButtonFace;
            this.button.Text = text;
            this.button.TabIndex = 4;

            if (close) // If this is a close button
                this.button.Click += new EventHandler(Close_Click); // Create click event
            else // If this is not a close button
                this.button.Click += new EventHandler(Add_Click); // Create click event


            return button;
        }


        /* Add button */
        private void Add_Click(object sender, EventArgs e)
        {
            // Gets field data
            int score = 5 - rating.SelectedIndex; // Calculates score by removing selected index from 5 (e.g. index 0 is value of 5, so score = 5)
            string newReview = review.Text;


            // Updates database
            db.InsertReview(user.ID, show.ShowID, newReview, score); // Inserts review into the database
            db.UpdateAverageScores(show.ShowID); // Updates total score within the database
        }


        /* Close button */
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes current form
        }
    }
}
