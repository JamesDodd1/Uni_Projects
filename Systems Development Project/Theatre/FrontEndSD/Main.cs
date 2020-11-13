// version 0.6.0 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FrontEndSD
{
    public partial class Main : Form
    {
        /* Declare variables */
        private Panel mainPanel = new MainPanel(); // Panel to display shows and information
        private Panel panelTitle; // Panel for titles
        private Panel infoPanel;  // Panel for contact and about
        private Panel padding;    // Panel for any padding

        private List<Show> shows = new List<Show>();  // List of shows
        private List<Show> search = new List<Show>(); // List of search results

        private static int panelFlag = 0; // 0 for nothing, 1 for top shows, 2 for shows, 3 for coming soon, 4 for contact and 5 for about
        private static int imageNumber = 1;

        private static User user;
        private static UserFactory factory;

        private Database db = new Database(); // Object of database class

        
        /* Get/Set methods */
        public static int PanelFlag { get => panelFlag; set => panelFlag = value; }
        public static User CurrentUser { get => user; set => user = value; }


        public Main() 
        {
            InitializeComponent();

            // Sets starting layout
            MenuBarLayout();
            this.Controls.Add(mainPanel); // Adds mainPanel to form
            InitialLayout();

            // Sets user to a guest
            factory = new GuestFactory(); // Sets factory for guest 
            user = factory.CreateUser();  // Creates guest user
            

            // Sets form opening position on screen - currently central
            Rectangle dimension = Screen.FromControl(this).Bounds; // Gets screen dimentions
            this.Location = new Point((dimension.Width / 2) - (this.Width / 2), (dimension.Height / 2) - (this.Height / 2)); // Sets form location
        }
        

        
        
        /* ===== MENU BAR ===== */

        /* Account link */
        private void Account_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (user.IsLoggedIn) // If user is logged in
            {
                // Changes cursor to waiting cursor
                this.Cursor = Cursors.WaitCursor;

                // Opens account form
                Account account = new Account(); // Creates an object of the form
                account.ShowDialog();            // Displays account

                // Resets cursor to arrow after form has loaded
                this.Cursor = Cursors.Arrow;
            }
            else // If user is not logged in
                MessageBox.Show("Please login to view your account"); // Display error message
        }


        /* Make a Booking button */
        private void MakeABooking_Click(object sender, EventArgs e) 
        {
            if (user.IsLoggedIn) // If user is logged in
            {
                // Opens Booking form
                Booking booking = new Booking(new Show()); // Creates an object of the form
                booking.ShowDialog();                      // Displays booking
            }
            else // If user is not logged in
                MessageBox.Show("Please login or register to make a booking"); // Display error message
        }


        /* What's On button top strip code */
        private void WhatsOn_Click(object sender, EventArgs e)
        {
            InitialLayout(); // Resets form layout
        }


        /* Login/Logout button */
        private void Login_Click(object sender, EventArgs e)
        {
            if (!user.IsLoggedIn) // If user not logged in
            {
                // Opens Login form
                Login login = new Login(); // Creates an object of the form
                login.ShowDialog();        // Displays login

                if (user.IsLoggedIn) // If user is now logged in
                    loginMenuItem.Text = "Logout"; // Changes login button text
            }
            else // If user already logged in
            {
                // Sets user as a guest
                factory = new GuestFactory(); // Creates guest
                user = factory.CreateUser();  // Sets user to guest

                loginMenuItem.Text = "Login"; // Changes logout button text
            }

            UserChanged();
        }


        /* Register button */
        private void Register_Click(object sender, EventArgs e)
        {
            // Opens Register form
            Register register = new Register(); // Creates an object of the form
            register.ShowDialog();              // Displays register
        }


        /* Basket button */
        private void Basket_Click(object sender, EventArgs e)
        {
            // Opens Basket form
            Basket basket = new Basket(); // Creates an object of the form
            basket.ShowDialog();          // Displays basket
        }


        /* Manage shows button */
        private void ManageShows_Click(object sender, EventArgs e)
        {
            // Opens ManageShows form
            ManageShows manageShows = new ManageShows(); // Creates an object of the form
            manageShows.ShowDialog();                    // Displays manageShows 
        }


        /* Manage reviews button */
        private void Reviews_Click(object sender, EventArgs e)
        {
            // Opens ReviewManage form
            ManageReviews manageReviews = new ManageReviews(); // Creates an object of the form
            manageReviews.ShowDialog();                        // Displays manageReviews 
        }


        /* Manage sales button */
        private void SalesReport_Click(object sender, EventArgs e)
        {
            // Opens SalesReport form
            SalesReport salesReport = new SalesReport(); // Creates an object of the form
            salesReport.ShowDialog();                    // Displays salesReport 
        }




        /* ===== BANNER ===== */

        /* Main timer */
        private void BannerTimer_Tick(object sender, EventArgs e) // New tick every 3 seconds
        {
            LoadNextImage(); // Loads next image for the banner
        }


        /* Banner image */
        private void LoadNextImage()
        {
            // Resets loop counter
            if (imageNumber == 4)
                imageNumber = 0;

            slidePictureBox.ImageLocation = string.Format(@"Images\{0}.jpg", imageNumber); // Sets banner image
            imageNumber++;
        }
        



        /* ===== INFO BAR ===== */

        /* Shows button */
        private void Shows_Click(object sender, EventArgs e)
        {
            // Display panel
            if (panelFlag == 2)  // If shows panel displayed
                DisplayPanel(1); // Display top shows panel
            else                 // If shows panel not diplayed
                DisplayPanel(2); // Displays show panel
        }


        /* Coming Soon button */
        private void ComingSoon_Click(object sender, EventArgs e)
        {
            // Display panel
            if (panelFlag == 3)  // If coming soon panel displayed
                DisplayPanel(1); // Display top shows panel
            else                 // If coming soon panel not displayed
                DisplayPanel(3); // Displays coming soon panel 
        }


        /* Contact button */
        private void Contact_Click(object sender, EventArgs e)
        {
            // Set details
            string adminPhone = "020 8858 4447";
            string boxOfficePhone = "020 8858 7755";
            string accountEmail = "accounts@greenwichtheatre.org.uk";
            string boxOfficeEmail = "boxoffice @greenwichtheatre.org.uk";

            // Set text to be displayed
            string text = $"For any general information about the theatre, please contact the administration office on \n{adminPhone}. \nFor all bookings and ticket enquiries, contact the Box Office on {boxOfficePhone}. \n\nFor more specific enquiries, please email the appropriate persons below: \n\nAccounts Enquiries: {accountEmail} \nBox Office Services: {boxOfficeEmail}";
            string image = "TMap.png";


            // Display panel
            if (panelFlag == 4)  // If contact panel displayed
                DisplayPanel(1); // Display top shows panel
            else                              // If contact panel not displayed
                DisplayPanel(4, text, image); // Display contact panel 
        }


        /* About button */
        private void About_Click(object sender, EventArgs e)
        {
            // Set text to be displayed
            string txt = "Greenwich Theatre is one of London’s premiere Off-West End theatres, presenting a year-round programme of drama, music theatre, family shows and pantomime. The theatre is one of the country’s leading supporters of young and emerging theatre companies, regularly providing a launch pad for new work which subsequently transfers around the country, into the West End and around the world. The theatre is also at the forefront of developing and celebrating some of the UK’s finest family theatre and produces the annual Greenwich Children’s Theatre Festival and one of the country’s most acclaimed traditional pantomimes. \n\nLOCATION: \nGreenwich Theatre \nCrooms Hill \nLondon \nSE10 8ES";
            string image = "Much Ado About Nothing.jpg";


            // Display panel
            if (panelFlag == 5)  // If about panel displayed
                DisplayPanel(1); // Display top shows panel
            else                             // If about panel not on diplayed
                DisplayPanel(5, txt, image); // Displays about show
        }


        /* SearchBar */
        private void SearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // When enter key pressed
                DisplayPanel(6); // Display search panel
        }


        /* Magnifying glass image */
        private void MagnifyingGlass_Click(object sender, EventArgs e)
        {
            DisplayPanel(6); // Display search panel 
        }




        /* ===== MAIN PANEL ===== */

        /* Resets mainPanel */
        private void ClearMainPanel()
        {
            mainPanel.Controls.Clear(); // Clears mainPanel

            // Sets mainPanel title
            switch (panelFlag)
            {
                // Top shows panel
                case 1:
                    panelTitle = new MainPanelTitle("Top Shows"); // Creates title panel
                    break;

                // Shows panel
                case 2:
                    panelTitle = new MainPanelTitle("Shows"); // Creates title panel
                    break;

                // Coming soon panel
                case 3:
                    panelTitle = new MainPanelTitle("Coming Soon"); // Creates title panel
                    break;

                // Contact panel
                case 4:
                    panelTitle = new MainPanelTitle("Contact"); // Creates title panel
                    break;

                // About panel
                case 5:
                    panelTitle = new MainPanelTitle("About"); // Creates title panel
                    break;

                // Search panel
                case 6:
                    panelTitle = new MainPanelTitle("Search Results"); // Creates title panel
                    break;

                // No panel
                default:
                    panelTitle = new MainPanelTitle("");
                    break;
            }

            mainPanel.Controls.Add(panelTitle); // Adds panelTitle to mainPanel
        }


        /* Creates panel to display top shows */
        private void CreateTopShowPanel()
        {
            ClearMainPanel(); // Clears mainPanel

            InitTopShowPanels(); // Gets top four rated shows
            
            int locX = 44; // Starting X position

            // Loops through each show
            foreach (Show show in shows) 
            {
                Panel showPanel = new TopShowPanel(show, locX, 45); // Creates a TopShowPanel for each show
                mainPanel.Controls.Add(showPanel); // Adds to showPanel to mainPanel

                locX += 219; // New X location
            }
        }


        /* Creates panel to display shows
         * 
         * panelType: Sets which panel to display.  2 for shows panel, 3 for coming soon panel
         */
        private void CreateShowsPanel(int panelType)
        {
            ClearMainPanel(); // Clears mainPanel


            // Decides what shows to to retrieve 
            if (panelType == 2) 
                InitShowPanels(); // Gets all current performances
            else if (panelType == 3) 
                InitComingSoonPanels(); // Gets all coming soon shows
            

            int locY = 50; // Starting Y position

            // Loops though each show
            foreach (Show show in shows) 
            {
                Panel showPanel = new ShowPanel(show, 22, locY); // Creates a ShowPanel for each show
                this.mainPanel.Controls.Add(showPanel); // Adds to showPanel to mainPanel

                locY += 225; // New Y position 
            }


            // Add space at the bottom of the shows list
            padding = new PaddingPanel(0, locY - 50, 921, 25); // Creates PaddingPanel
            this.mainPanel.Controls.Add(padding); // Adds padding to mainPanel
        }

        
        /* Creates a panel to display search results
         * 
         * searchText: Text entered into searchbar 
         */
        private void CreateSearchPanel(string searchText)
        {
            ClearMainPanel(); // Clears mainPanel

            InitSearchPanels(searchText); // Gets all search results
            
            int locY = 50; // Starting Y position

            // Loops though each show
            foreach (Show show in search) 
            {
                Panel showPanel = new ShowPanel(show, 22, locY); // Creates a ShowPanel for each show
                this.mainPanel.Controls.Add(showPanel); // Adds to showPanel to mainPanel

                locY += 225; // New Y position 
            }


            // Add space at the bottom of the shows list
            padding = new PaddingPanel(0, locY - 50, 921, 25); // Creates PaddingPanel
            this.mainPanel.Controls.Add(padding); // Adds padding to mainPanel
        }


        /* Creates information panel
         * 
         * infoText: The content which will be displayed for either Contact or About
         */
        private void CreateInfoPanel(string infoText, string image)
        {
            ClearMainPanel(); // Clears mainPanel
            
            infoPanel = new InfoPanel(infoText, image); // Creates panel
            mainPanel.Controls.Add(infoPanel);   // Adds panel to form
        }


        /* Gets shows for Top Shows */
        private void InitTopShowPanels()
        {
            shows.Clear(); // Clears showsList

            shows = db.GetTopShows(); // Gets top four shows from database
        }


        /* Gets shows for Shows */
        private void InitShowPanels()
        {
            shows.Clear(); // Clears showsList

            shows = db.GetCurrentPerformances(); // Gets all current performances from database
        }


        /* Gets shows for Coming Soon */
        private void InitComingSoonPanels()
        {
            shows.Clear(); // Clears showsList

            shows = db.GetComingSoonShows(); // Gets all coming soon shows from database
        }


        /* Gets shows for Search */
        private void InitSearchPanels(string searchText)
        {
            search.Clear(); // Clears search
            
            // Loops for each show from current panel (e.g. all shows displayed on coming soon)
            foreach (Show show in shows)
            {
                try
                {
                    // Searches for searchText within each show's name
                    if (System.Text.RegularExpressions.Regex.IsMatch(show.Name, searchText, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                        search.Add(new Show(show.Name, show.Genre, show.Date, show.StartDate, show.EndDate, show.Description, show.Image, show.Rating)); // Adds shows show to search
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e);
                }
            }
        }




        /* ===== MAIN LAYOUT ===== */

        /* Sets main form's initial layout */
        private void InitialLayout()
        {
            // Sets item's starting properties
            logoPictureBox.Location = new Point(30, 76);
            logoPictureBox.Visible = true;

            slidePictureBox.Location = new Point(220, 76);
            slidePictureBox.Visible = true;

            infoBarPanel.Location = new Point(30, 279);
            infoBarPanel.Visible = true;

            mainPanel.Location = new Point(30, 380);
            mainPanel.Visible = true;
            mainPanel.AutoScroll = false;
            mainPanel.VerticalScroll.Visible = false;
            mainPanel.Height = 300;


            panelFlag = 1;
            CreateTopShowPanel(); // Runs method to create panel
        }


        /* Sets panel on main form
         * 
         * panelTypeVisible: Decides which panel type to display.  1 for Top Shows, 2 for Shows, 3 for Coming Soon, 6 for Search and 0 for nothing
         */
        private void DisplayPanel(int panelTypeVisible)
        {
            // Sets mainPanel properties
            mainPanel.Visible = true;
            mainPanel.AutoScroll = true;
            mainPanel.VerticalScroll.Visible = true;
            mainPanel.Height = 500;


            // Decide which panel to display
            switch (panelTypeVisible)
            {
                // Top shows panel
                case 1: 
                    panelFlag = 1;
                    CreateTopShowPanel(); // Runs method to create panel

                    // Sets more mainPanel properties
                    mainPanel.AutoScroll = false;
                    mainPanel.VerticalScroll.Visible = false;
                    mainPanel.Height = 300;
                    break;

                // Shows panel
                case 2: 
                    panelFlag = 2;
                    CreateShowsPanel(2); // Runs method to create panel
                    break;

                // Coming soon panel
                case 3: 
                    panelFlag = 3;
                    CreateShowsPanel(3); // Runs method to create panel
                    break;

                // Search panel
                case 6: 
                    panelFlag = 6;
                    CreateSearchPanel(searchBarTextBox.Text); // Runs method to create panel
                    break;

                // No panel
                default:
                    panelFlag = 0;
                    mainPanel.Visible = false; // Set panel to invisible
                    break;
            }
        }


        /* Sets panel on main form 
         * 
         * panelTypeVisible: Decides which panel type to display.  4 for Contact, 5 for About and 0 for nothing
         */
        private void DisplayPanel(int panelTypeVisible, string infoText, string image)
        {
            // Sets mainPanel properties
            mainPanel.Visible = true;
            mainPanel.AutoScroll = false;
            mainPanel.VerticalScroll.Visible = false;
            mainPanel.Height = 330;


            // Decide which panel to display
            switch (panelTypeVisible)
            {
                // Contact panel 
                case 4:                       
                    panelFlag = 4;
                    CreateInfoPanel(infoText, image); // Runs method to create panel
                    break;
                    
                // About panel    
                case 5:                    
                    panelFlag = 5; 
                    CreateInfoPanel(infoText, image); // Runs method to create panel
                    break;
                
                // No panel
                default: 
                    panelFlag = 0; 
                    mainPanel.Visible = false; // Set panel to invisible
                    break;
            }
        }
        

        /* MenuBar layout */
        private void MenuBarLayout()
        {
            // Sets text
            basketMenuItem.Text = "Basket";
            loginMenuItem.Text = "Login";
            registerMenuItem.Text = "Register";
            whatsOnMenuItem.Text = "What's On";
            makeABookingMenuItem.Text = "Make a Booking";

            manageShowsMenuItem.Text = "Manage Shows";
            manageReviewsMenuItem.Text = "Manage Reviews";
            manageSalesMenuItem.Text = "Manage Sales";


            // Sets margins
            basketMenuItem.Margin = new Padding(4, 0, 4, 0);
            loginMenuItem.Margin = new Padding(4, 0, 4, 0);
            registerMenuItem.Margin = new Padding(4, 0, 4, 0);
            whatsOnMenuItem.Margin = new Padding(4, 0, 4, 0);
            makeABookingMenuItem.Margin = new Padding(4, 0, 4, 0);

            manageShowsMenuItem.Margin = new Padding(4, 0, 4, 0);
            manageReviewsMenuItem.Margin = new Padding(4, 0, 4, 0);
            manageSalesMenuItem.Margin = new Padding(4, 0, 4, 0);


            // Sets padding
            basketMenuItem.Padding = new Padding(5, 0, 5, 0);
            loginMenuItem.Padding = new Padding(5, 0, 5, 0);
            registerMenuItem.Padding = new Padding(5, 0, 5, 0);
            whatsOnMenuItem.Padding = new Padding(5, 0, 5, 0);
            makeABookingMenuItem.Padding = new Padding(5, 0, 5, 0);

            manageShowsMenuItem.Padding = new Padding(5, 0, 5, 0);
            manageReviewsMenuItem.Padding = new Padding(5, 0, 5, 0);
            manageSalesMenuItem.Padding = new Padding(5, 0, 5, 0);


            // Searchbar focus
            searchBarTextBox.GotFocus += new EventHandler(SearchBarRemoveText);
            searchBarTextBox.LostFocus += new EventHandler(SearchBarAddText);
        }
        

        /* Removes searchbar temp text */
        public void SearchBarRemoveText(object sender, EventArgs e)
        {
            // When searchbar is focused, temp text will be removed
            searchBarTextBox.Clear();
        }


        /* Adds searchbar temp text */
        public void SearchBarAddText(object sender, EventArgs e)
        {
            // When searchbar is unfocused, temp text is added
            if (string.IsNullOrWhiteSpace(searchBarTextBox.Text))
                searchBarTextBox.Text = "Search for a show...";
        }


        /* Changes display depending on user type */
        private void UserChanged()
        {
            if (user.IsAdmin) // If user is an admin
            {
                // Sets menu bar item's visiblity
                manageShowsMenuItem.Visible = true;
                manageReviewsMenuItem.Visible = true;
                manageSalesMenuItem.Visible = true;
            }
            else if (user.IsLoggedIn) // If user is logged in as another user
            {
                // Sets menu bar item's visiblity
                manageShowsMenuItem.Visible = false;
                manageReviewsMenuItem.Visible = true;
                manageSalesMenuItem.Visible = false;
            }
            else // If user is a guest
            {
                // Sets menu bar item's visiblity
                manageShowsMenuItem.Visible = false;
                manageReviewsMenuItem.Visible = false;
                manageSalesMenuItem.Visible = false;
            }
        }
    }
}
