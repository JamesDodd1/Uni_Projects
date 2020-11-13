
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace FrontEndSD
{
    /* Panel to display everything on Main form */
    public class MainPanel : Panel
    {
        public MainPanel()
        {
            Init();
        }

        private void Init()
        {
            // Sets panel properties
            this.Name = "mainPanel";
            this.Size = new Size(921, 500);
            this.Location = new Point(30, 380);
            this.BackColor = ColorTranslator.FromHtml("#D7E4F2");
            this.HorizontalScroll.Maximum = 0;
            this.VerticalScroll.Visible = true;
            this.AutoScroll = true;
            this.TabIndex = 0;

            // Sets this' properties
            this.ClientSize = new Size(921, 500);
        }
    }


    /* Panel adds the title */
    public class MainPanelTitle : Panel
    {
        /* Declare variables */
        private Label title;


        public MainPanelTitle(string titleText)
        {
            Init(titleText);
        }

        private void Init(string titleText)
        {
            // Creates objects
            this.title = new Label();


            // Adds objects
            this.Controls.Add(this.title);


            // Sets title properties
            this.title.AutoSize = true;
            this.title.Visible = true;
            this.title.Location = new Point(0, 0);
            this.title.Name = "titleLabel";
            this.title.Text = titleText;
            this.title.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            this.title.ForeColor = Color.Black;
            this.title.BackColor = Color.Transparent;
            this.title.TabIndex = 0;


            // Sets this' properties
            this.Size = title.Size;
        }
    }


    /* Panel to display a top show */
    public class TopShowPanel : Panel
    {
        /* Declare variables */
        private PictureBox image;
        private TextBox showDescription;

        private Show shows;

        
        public TopShowPanel(Show shows, int locX, int locY)
        {
            Init(shows, locX, locY);
        }

        private void Init(Show shows, int locX, int locY)
        {
            // Creates objects
            this.showDescription = new TextBox();
            this.image = new PictureBox();
            this.shows = shows;

            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();


            // Adds objects
            this.Controls.Add(this.image);
            this.Controls.Add(this.showDescription);
            

            // Sets properties
            this.Name = "topShowPanel";
            this.Size = new Size(175, 300);
            this.Location = new Point(locX, locY);
            this.Cursor = Cursors.Hand;
            this.TabIndex = 0;
            this.Click += new EventHandler(TopShow_Click); // Adds click event


            // Sets showDescription properties
            this.showDescription.ReadOnly = true;
            this.showDescription.Location = new Point(0, 185);
            this.showDescription.Name = "showDescriptionTextBox";
            this.showDescription.Size = new Size(175, 55);
            this.showDescription.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Italic);
            this.showDescription.TabIndex = 0;
            this.showDescription.WordWrap = true;
            this.showDescription.Multiline = true;
            this.showDescription.AppendText(shows.Name + Environment.NewLine + shows.StartDate.ToString("d MMM") + " - " + shows.EndDate.ToString("d MMM") + Environment.NewLine + "Stars: " + shows.Rating);
            this.showDescription.Cursor = Cursors.Hand;
            this.showDescription.Click += new EventHandler(TopShow_Click); // Adds click event


            // Sets image properties
            string dir = Path.GetDirectoryName(Application.ExecutablePath);           // Get path to this application
            string imgAddress = Path.Combine(dir, @"../../Resources/" + shows.Image); // Gets image from correct folder with this application

            this.image.Image = Image.FromFile(imgAddress);
            this.image.Location = new Point(0, 0);
            this.image.Name = "imagePictureBox";
            this.image.Size = new Size(175, 175);
            this.image.SizeMode = PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 1;
            this.image.TabStop = false;
            this.image.Click += new EventHandler(TopShow_Click); // Adds click event


            // Sets this' properties
            this.ClientSize = this.Size;
            this.ResumeLayout(false);
            this.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();

            this.ResumeLayout(false);
        }


        /* TopShow */
        private void TopShow_Click(object sender, EventArgs e)
        {
            if (Main.CurrentUser.IsLoggedIn) // If current user is loggedin
            {
                // Changes cursor to waiting cursor
                this.Cursor = Cursors.WaitCursor;
                this.showDescription.Cursor = Cursors.WaitCursor;

                // Open Booking form
                Booking booking = new Booking(shows); // Creates an object of form
                booking.ShowDialog();                 // Displays booking

                // Resets cursor to arrow after form has loaded
                this.Cursor = Cursors.Hand;
                this.showDescription.Cursor = Cursors.Hand;
            }
            else // If current user is not logged in
                MessageBox.Show("Please login or register to make a booking"); // Dislay error message
        }
    }


    /* Panel to display a show */
    public class ShowPanel : Panel
    {
        /* Declare variables */
        private Panel show;
        private Label label;
        private PictureBox image;
        private RichTextBox showDescription;

        private Show shows;


        public ShowPanel(Show show, int locX, int locY)
        {
            Init(show, locX, locY);
        }
        
        private void Init(Show shows, int locX, int locY)
        {
            // Creates objects
            this.show = new Panel();
            this.image = new PictureBox();
            this.showDescription = new RichTextBox();
            this.shows = shows;

            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.show.SuspendLayout();
            this.SuspendLayout();


            // Adds objects
            this.Controls.Add(CreateLabel(0, 110, $"{show.Name}NameLabel", $"Title: {shows.Name}", false));
            this.Controls.Add(CreateLabel(0, 130, $"{shows.Genre}genreLabel", $"Genre: {shows.Genre}", false));
            this.Controls.Add(CreateLabel(0, 150, $"{shows.Date.ToString("dd/MM/yyyy")}DateLabel", null, true));
            this.Controls.Add(show);
            this.Controls.Add(image);
            this.Controls.Add(showDescription);


            // Sets panel properties
            this.Name = $"{shows.Name}Panel";
            this.Size = new Size(869, 175);
            this.Location = new Point(locX, locY);
            this.Cursor = Cursors.Hand;
            this.TabIndex = 0;


            // Sets showDescription properties
            this.showDescription.ReadOnly = true;
            this.showDescription.Location = new Point(180, 0);
            this.showDescription.Name = "showDescriptionRichTextBox";
            this.showDescription.Size = new Size(679, 175);
            this.showDescription.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Italic);
            this.showDescription.TabIndex = 1;
            this.showDescription.WordWrap = true;
            this.showDescription.Text = shows.Description.Replace("\\n", Environment.NewLine);
            this.showDescription.BackColor = Color.AliceBlue;
            this.showDescription.Cursor = Cursors.Hand;


            // Sets image properties
            string dir = Path.GetDirectoryName(Application.ExecutablePath);           // Get path to this application
            string imgAddress = Path.Combine(dir, @"../../Resources/" + shows.Image); // Gets image from correct folder with this application

            this.image.Image = Image.FromFile(imgAddress);
            this.image.SizeMode = PictureBoxSizeMode.StretchImage;
            this.image.Location = new Point(0, 0);
            this.image.Name = "imagePictureBox";
            this.image.Size = new Size(170, 80);
            this.image.TabIndex = 2;
            this.image.TabStop = false;


            // Sets rating properties
            this.show.Location = new Point(0, 83);
            this.show.Name = "showPanel";
            this.show.Size = new Size(170, 37);
            this.show.TabIndex = 3;
            
            if (Main.PanelFlag != 3) // Don't show for coming soon
                this.show.Controls.Add(new Rating(shows.Rating));

            

            if (Main.PanelFlag != 3) // Don't add to coming soon 
            {
                // Add click events
                this.Click += new EventHandler(Show_Click);
                this.Click += new EventHandler(Show_Click);
                this.showDescription.Click += new EventHandler(Show_Click);
                this.image.Click += new EventHandler(Show_Click);
                this.show.Click += new EventHandler(Show_Click);
            }


            // Sets this' properties
            this.ClientSize = this.Size;
            this.ResumeLayout(false);
            this.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.show.ResumeLayout(false);

            this.ResumeLayout(false);
        }


        /* Label creation */
        private Label CreateLabel(int locX, int locY, string name, string text, bool isDateLabel)
        {
            // Create label
            label = new Label();


            // Set label properties
            this.label.AutoSize = true;
            this.label.Location = new Point(locX, locY);
            this.label.Name = name;
            this.label.Font = new Font("Microsoft Sans Serif", 10F);
            this.label.TabIndex = 4;

            if (Main.PanelFlag != 3) // Don't add to coming soon 
                this.label.Click += new EventHandler(Show_Click); // Add click event

            if (isDateLabel) // If this is date label
            {
                if (shows.Date == new DateTime()) // When no performance date
                    this.label.Text = shows.StartDate.ToString("d MMM yyyy") + " - " + shows.EndDate.ToString("d MMM yyyy");
                else // When there is a performance date
                {
                    if (Main.PanelFlag == 2) // For shows 
                        this.label.Text = $"Showing: {shows.Date.ToString("dd/MM/yyyy")}";
                    else if (Main.PanelFlag == 3) // For coming soon 
                        this.label.Text = $"Showing From: {shows.Date.ToString("dd/MM/yyyy")}";
                    else // Others
                        this.label.Text = $"Showing: {shows.Date.ToString("dd/MM/yyyy")}";
                }
            }
            else // If this isn't date label
                this.label.Text = text;


            return label;
        }


        /* Panel */
        private void Show_Click(object sender, EventArgs e)
        {
            if (Main.CurrentUser.IsLoggedIn) // If current user is logged in
            {
                // Open seating plan form
                Booking booking = new Booking(shows); // Create object of form
                booking.ShowDialog();                 // Display booking
            }
            else // If current user is not logged in
                MessageBox.Show("Please login or register to make a booking"); // Display error message
        }
    }


    /* Panel to display information */
    public class InfoPanel : Panel
    {
        /* Declare variables */
        private RichTextBox info;
        private PictureBox infoPicture;


        public InfoPanel(string information, string image)
        {
            Init(information, image);
        }

        private void Init(string information, string imageName)
        {
            // Creates objects
            this.info = new RichTextBox();
            this.infoPicture = new PictureBox();


            this.SuspendLayout();


            // Adds objects
            this.Controls.Add(this.info);
            this.Controls.Add(this.infoPicture);


            // Sets info properties
            this.info.Name = "infoRichTextBox";
            this.info.Location = new Point(30, 50);
            this.info.Size = new Size(600, 300);
            this.info.Font = new Font("Microsoft Sans Serif", 10F,FontStyle.Italic);
            this.info.ReadOnly = true;
            this.info.TabIndex = 0;
            this.info.WordWrap = true;
            this.info.Text = information;
            this.info.BackColor = Color.AliceBlue;


            // Sets infoPicture properties
            this.infoPicture.Name = "infoPictureBox";
            this.infoPicture.Location = new Point(640, 50);
            this.infoPicture.Size = new Size(250, 250);
            this.infoPicture.SizeMode = PictureBoxSizeMode.Zoom;
            
            try
            {
                // Get 
                string dir = Path.GetDirectoryName(Application.ExecutablePath);       // Get path to this application
                string filename = Path.Combine(dir, @"../../Resources/" + imageName); // Gets image from correct folder with this application
                
                this.infoPicture.Image = Image.FromFile(filename);
            }
            catch (Exception) // If image not found
            {
                Assembly myAssembly = Assembly.GetExecutingAssembly();
                Stream myStream = myAssembly.GetManifestResourceStream("FrontEndSD.Resources.XredLogo.png");
                Bitmap image = new Bitmap(myStream);

                this.infoPicture.BackColor = Color.WhiteSmoke;
                this.infoPicture.Image = image;
            }


            // Set this' properties
            this.ClientSize = new Size(921, 300);
        }
    }


    /* Panel to add padding */
    public class PaddingPanel : Panel
    {
        public PaddingPanel(int locX, int locY, int width, int height)
        {
            Init(locX, locY, width, height);
        }

        private void Init(int locX, int locY, int width, int height)
        {
            // Sets this' properties
            this.Size = new Size(width, height);
            this.Location = new Point(locX, locY);
        }
    }


    /* Panel to display a ticket */
    public class TicketPanel : Panel
    {
        /* Declare variables */
        private PictureBox image;
        private Label label;

        public TicketPanel(int locY, string id, Show shows, Seat seats, double totalCost)
        {
            Init(locY, id, shows, seats, totalCost);
        }

        public void Init(int locY, string id, Show shows, Seat seats, double totalCost)
        {
            // Create object
            image = new PictureBox();


            // Adds objects
            this.Controls.Add( CreateLabel("idLabel", id, 3, 3) );
            this.Controls.Add( CreateLabel("bandLabel", "Band: " + seats.Band, 131, 79) );
            this.Controls.Add( CreateLabel("typeLabel", seats.Type, 3, 79) );
            this.Controls.Add( CreateLabel("costLabel", $"£{shows.Cost + totalCost}", 275, 23) );
            this.Controls.Add( CreateLabel("seatNameLabel", seats.Name, 3, 43) );
            this.Controls.Add( CreateLabel("showNameLabel", shows.Name, 3, 23) );
            this.Controls.Add(image);


            // Sets this' properties
            this.Location = new Point(3, locY);
            this.Size = new Size(490, 112);
            this.TabIndex = 0;
            this.BackColor = Color.White;


            // Sets image properties
            string dir = Path.GetDirectoryName(Application.ExecutablePath);           // Get path to this application
            string imgAddress = Path.Combine(dir, @"../../Resources/" + shows.Image); // Gets image from correct folder with this application

            this.image.Image = Image.FromFile(imgAddress);
            this.image.Location = new Point(340, 3);
            this.image.Name = "image";
            this.image.Size = new Size(134, 106);
            this.image.SizeMode = PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 0;
            this.image.TabStop = false;
        }


        /* Creates Labels */
        private Label CreateLabel(string name, string text, int x, int y)
        {
            // Creates label
            label = new Label();


            // Sets label properties
            label.AutoSize = true;
            label.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label.Location = new Point(x, y);
            label.Name = name;
            label.Size = new Size(97, 20);
            label.TabIndex = 1;
            label.Text = text;


            return label;
        }
    }


    /* Panel to display a reveiw */
    public class ReviewPanel : Panel
    {
        /* Declare variables */
        private Label label;
        private TextBox rating;
        private RichTextBox review;
        private Button button;
        private Button edit;
        private Button delete;

        private Review userReview;
        private Database db = new Database();

        private bool editClicked = false;

        public ReviewPanel(int locY, User user, Review userReview)
        {
            Init(locY, user, userReview);
        }

        private void Init(int locY, User user, Review userReview)
        {
            // Creates object
            this.rating = new TextBox();
            this.review = new RichTextBox();

            this.userReview = userReview;


            // Adds objects
            this.Controls.Add(CreateLabel(5, 5, "usernameLabel", user.Username));
            this.Controls.Add(CreateLabel(5, 30, "reviewDateLabel", $"Date: {userReview.Date.ToString("dd/MM/yyyy")}"));
            this.Controls.Add(CreateLabel(5, 57, "ratingLabel", "Rating:"));
            this.Controls.Add(rating);
            this.Controls.Add(review);


            // Sets this panel's propeties
            this.Name = "reviewPanel";
            this.Location = new Point(5, locY);
            this.Size = new Size(470, 152);
            this.TabIndex = 0;


            // Sets rating properties
            this.rating.Name = "ratingPanel";
            this.rating.Text = userReview.Rating.ToString();
            this.rating.ReadOnly = true;
            this.rating.Enabled = false;
            this.rating.Location = new Point(60, 55);
            this.rating.Font = new Font("Microsoft Sans Serif", 10F);
            this.rating.Size = new Size(20, 27);
            this.rating.TabIndex = 2;


            // Sets review properties
            this.review.Name = "reviewTextBox";
            this.review.ReadOnly = true;
            this.review.Enabled = false;
            this.review.Font = new Font("Microsoft Sans Serif", 10F);
            this.review.Location = new Point(125, 10);
            this.review.Size = new Size(335, 130);
            this.review.ReadOnly = true;
            this.review.TabIndex = 3;
            this.review.WordWrap = true;
            this.review.Text = userReview.ShowReview;


            if (Main.CurrentUser.IsAdmin || Main.CurrentUser.ID == userReview.AccountID) // If admin or user's review
            {
                edit = CreateButton(5, 85, "editButton", "Edit", false);
                delete = CreateButton(5, 115, "deleteButton", "Delete", true);

                this.Controls.Add(edit);
                this.Controls.Add(delete);
            }
        }


        /* Label creation */
        private Label CreateLabel(int locX, int locY, string name, string text)
        {
            // Create label
            label = new Label();


            // Set label properties
            this.label.Name = name;
            this.label.Text = text;
            this.label.Font = new Font("Microsoft Sans Serif", 10F);
            this.label.AutoSize = true;
            this.label.Location = new Point(locX, locY);
            this.label.TabIndex = 1;


            return label;
        }

        
        /* Button creation */
        private Button CreateButton(int locX, int locY, string name, string text, bool isDeleteButton)
        {
            // Create button
            button = new Button();


            // Set button properties
            this.button.Name = name;
            this.button.Font = new Font("Microsoft Sans Serif", 10F);
            this.button.Size = new Size(90, 27);
            this.button.Location = new Point(locX, locY);
            this.button.BackColor = SystemColors.ButtonFace;
            this.button.TabIndex = 4;

            if (isDeleteButton)
            {
                if (userReview.Deleted && Main.CurrentUser.IsAdmin)
                    this.button.Text = "Restore";
                else if (!userReview.Deleted)
                    this.button.Text = "Delete";

                this.button.Click += new EventHandler(Delete_Click);
            }
            else
            {
                this.button.Text = text;
                this.button.Click += new EventHandler(Edit_Click);
            }


            return button;
        }
        

        /* Edit button */
        private void Edit_Click(object sender, EventArgs e)
        {
            // Swaps between states depending on whether true or false
            if (editClicked) // Saves changes and disable editing
            {
                try
                {
                    int score = Int32.Parse(rating.Text);
                    if (score > 5 || score < 1)
                        MessageBox.Show("The number entered is out of range"); // Error message
                    else
                    {
                        db.UpdateReview(userReview, review.Text, score); // Update reviews within the database

                        // Set this' object's properties
                        review.ReadOnly = true;
                        review.Enabled = false;
                        rating.ReadOnly = true;
                        rating.Enabled = false;
                        editClicked = false;
                        edit.Text = "Edit";
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("The information you've entered is incorrect"); // Error message
                }
            }
            else // Enables fields to be edited
            {
                // Sets this' object properties
                review.ReadOnly = false;
                review.Enabled = true;
                rating.ReadOnly = false;
                rating.Enabled = true;
                editClicked = true;
                edit.Text = "Save";
            }
        }


        /* Delete button */
        private void Delete_Click(object sender, EventArgs e)
        {
            if (Main.CurrentUser.IsAdmin) // IF current user is an admin
            {
                if (userReview.Deleted) // If review is already delete
                {
                    db.DeleteReview(userReview.ReviewID, true); // Updates the review within the database
                    this.delete.Text = "Restore";               // Changes button text
                }
                else // If review not delete
                {
                    db.DeleteReview(userReview.ReviewID, false); // Updates the review within the database
                    this.delete.Text = "Delete";                 // Changes button text
                }
            }
            else // If current user not an admin
            {
                db.DeleteReview(userReview.ReviewID, false); // Updates the review within the database
                delete.Enabled = false;                      // Disables delete button
            }
        }
    }
}
