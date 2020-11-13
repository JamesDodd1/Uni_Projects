
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace FrontEndSD
{
    public partial class ManageShows : Form
    {
        /* Declare variables */
        private List<Show> shows = new List<Show>();
        private Show show = new Show();

        private string fileName;
        private int showIndex;
        private int editFlag = 0; // 0 for Add, 1 for Edit, 2 for Remove
        private DateTime today = DateTime.Now; // Today's date

        private Database db = new Database(); // Creates an object of database class


        public ManageShows()
        {
            InitializeComponent();
            searchShowsComboBox.Visible = false;

            SelectShowAddItems();
            ClearForm(); // Resets form

            // Sets form opening position on screen - currently central
            Rectangle dimension = Screen.FromControl(this).Bounds; // Gets screen dimentions
            this.Location = new Point((dimension.Width / 2) - (this.Width / 2), (dimension.Height / 2) - (this.Height / 2)); // Sets form location
        }


        /* Select show items */
        private void SelectShowAddItems()
        {
            shows = db.GetShows(); // Gets shows from database

            // Loops for each play
            foreach (Show play in shows)
                searchShowsComboBox.Items.Add(play.Name); // Adds play name to combobox
        }


        /* Reset form */
        private void ClearForm()
        {
            // Clears fields
            addTextBox.Clear();
            fileTextBox.Clear();
            searchShowsComboBox.ResetText();
            fromCalendar.SetDate(today);
            toCalendar.SetDate(today);
            genreTextBox.Clear();
            descriptionTextBox.Clear();

            fileName = "";


            // Sets button location
            continueButton.Location = new Point(412, 439);
            cancelButton.Location = new Point(412, 472);

            this.Size = new Size(550, 615); // Set current form size
        }


        /* Add Show Button */
        private void Add_Click(object sender, EventArgs e)
        {
            // Set form display
            showLabel.Text = "Add Show";
            searchShowsComboBox.Visible = false;
            fromCalendar.Visible = true;
            toCalendar.Visible = true;
            fromLabel.Visible = true;
            toLabel.Visible = true;
            fileButton.Visible = true;
            fileTextBox.Visible = true;
            genreLabel.Visible = true;
            genreTextBox.Visible = true;
            descriptionLabel.Visible = true;
            descriptionTextBox.Visible = true;

            continueButton.Text = "Insert"; // Change button text

            ClearForm(); // Reset form

            editFlag = 0;
        }


        /* Edit Show Button */
        private void Edit_Click(object sender, EventArgs e)
        {
            // Set form display
            showLabel.Text = "Edit Show";
            searchShowsComboBox.Visible = true;
            fromCalendar.Visible = true;
            toCalendar.Visible = true;
            fromLabel.Visible = true;
            toLabel.Visible = true;
            fileButton.Visible = true;
            fileTextBox.Visible = true;
            genreLabel.Visible = true;
            genreTextBox.Visible = true;
            descriptionLabel.Visible = true;
            descriptionTextBox.Visible = true;

            continueButton.Text = "Save"; // Change button text

            ClearForm(); // Reset form

            editFlag = 1;
        }


        /* Remove Show Button */
        private void Remove_Click(object sender, EventArgs e)
        {
            // Sets form display
            showLabel.Text = "Remove Show";
            searchShowsComboBox.Visible = true;
            fromCalendar.Visible = false;
            toCalendar.Visible = false;
            fromLabel.Visible = false;
            toLabel.Visible = false;
            fileButton.Visible = false;
            fileTextBox.Visible = false;
            genreLabel.Visible = false;
            genreTextBox.Visible = false;
            descriptionLabel.Visible = false;
            descriptionTextBox.Visible = false;

            // Sets button text
            if (show.ShowCancelled) // If show is cancelled
                continueButton.Text = "Restore";
            else
                continueButton.Text = "Delete";

            // Sets button locations
            continueButton.Location = new Point(412, 127);
            cancelButton.Location = new Point(412,160);
            
            this.Size = new Size(550, 238); // Set current form size

            editFlag = 2;
        }


        /* File button */
        private void File_Click(object sender, EventArgs e)
        {
            // Declare variables
            string filePath = string.Empty;
            string fileContent = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog()) // Opens file selection window
            {
                // Set openFileDialog properties
                openFileDialog.Title = "Select Image";
                openFileDialog.InitialDirectory = "c:\\"; // Starting location
                openFileDialog.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif"; // Filter items that can be selected
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;


                if (openFileDialog.ShowDialog() == DialogResult.OK) // If 'OK' is clicked
                {
                    filePath = openFileDialog.FileName;     // Gets the path of specified file
                    fileName = openFileDialog.SafeFileName; // Gets the name of specified file

                    // Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile(); // Gets file

                    using (StreamReader reader = new StreamReader(fileStream)) // Views data from retreived file
                    {
                        fileContent = reader.ReadToEnd();
                        fileTextBox.Text = filePath; // Displays filePath in textbox
                    }
                }
            }
        }


        /* Selected show changed */
        private void SearchShows_SelectedIndexChanged(object sender, EventArgs e)
        {
            showIndex = searchShowsComboBox.SelectedIndex; // Stores selected index
            show = shows[showIndex];                       // Save selected show


            // Adds info from show to fields
            fileTextBox.Text = show.Image;
            fromCalendar.SetDate(show.StartDate);
            toCalendar.SetDate(show.EndDate);
            genreTextBox.Text = show.Genre;
            descriptionTextBox.Text = show.Description.Replace("\\n", Environment.NewLine); // Replaces \\n with new line


            // Set buttons accessablity
            if (showIndex == 0 && editFlag != 0) // Something must be selected and when not on Add
            {
                continueButton.Enabled = false;
                performanceButton.Enabled = false;
            }
            else
            {
                continueButton.Enabled = true;
                performanceButton.Enabled = true;
            }
        }


        /* Performance button */
        private void Performance_Click(object sender, EventArgs e)
        {
            // Opens ManagePerformances
            ManagePerformances perform = new ManagePerformances(show); // Creates object of the form
            perform.ShowDialog();                                      // Displays perform
        }


        /* Continue button */
        private void Continue_Click(object sender, EventArgs e)
        {
            // Get data from fields
            string showName = addTextBox.Text;
            DateTime startDate = fromCalendar.SelectionRange.Start;
            DateTime endDate = toCalendar.SelectionRange.Start;
            string genre = genreTextBox.Text;
            string description = descriptionTextBox.Text;


            if (editFlag == 0) // Adding
            {
                // Checks all fields aren't empty
                if (!string.IsNullOrEmpty(showName) && startDate >= today && endDate >= today && !string.IsNullOrEmpty(genre) && !string.IsNullOrEmpty(description) && !string.IsNullOrEmpty(fileName))
                    db.InsertShow(showName, startDate, endDate, genre, description, fileName); // Inserts show to database
                else // If a field is empty or wrong
                    MessageBox.Show("At least one of the fields are incorrect"); // Error message
            }
            else if (editFlag == 1) // Editing
            {
                // Updates show within shows list
                shows[showIndex].StartDate = startDate;
                shows[showIndex].EndDate = endDate;
                shows[showIndex].Genre = genre;
                shows[showIndex].Description = description;
                shows[showIndex].Image = fileName;

                // Updates database
                db.UpdateShow(show.ShowID, show.Name, startDate, endDate, genre, description, fileName);
            }
            else if (editFlag == 2) // Removing
            {
                if (show.ShowCancelled) // If show is currently cancelled
                    db.CancelShow(show.ShowID, false); // Restore show
                else
                    db.CancelShow(show.ShowID, true); // Cancel show
            }

            MessageBox.Show("Your changes have been made"); // Conformation message
        }


        /* Close button */
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes current form
        }
    }
}
