
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace FrontEndSD
{
    public partial class SalesReport : Form
    {
        public SalesReport()
        {
            InitializeComponent();

            // Sets form opening position on screen - currently central
            Rectangle dimension = Screen.FromControl(this).Bounds; // Gets screen dimentions
            this.Location = new Point((dimension.Width / 2) - (this.Width / 2), (dimension.Height / 2) - (this.Height / 2)); // Sets form location
        }


        /* Print report button */
        private void PrintReport_Click(object sender, EventArgs e)
        {
            // Opens Printer form
            Printer printer = new Printer(); // Creates an object of form - Printer class is below this class
            printer.ShowDialog();            // Displays printer
        }


        /* Close button */
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes current form
        }
    }


    public class Printer : Form
    {
        /* Declare variables */
        private Label label;
        private PictureBox image;
        private Button button;


        public Printer()
        {
            Init();
        }

        private void Init()
        {
            // Sets objects
            label = new Label();
            image = new PictureBox();
            button = new Button();


            // Adds objects to form
            this.Controls.Add(label);
            this.Controls.Add(image);
            this.Controls.Add(button);


            // Set form properties
            Rectangle dimension = Screen.FromControl(this).Bounds; // Gets screen dimentions
            this.Location = new Point((dimension.Width / 2) - (this.Width / 2), (dimension.Height / 2) - (this.Height / 2)); // Sets form location
            this.Name = "Priter";
            this.Text = "Printing";
            this.Font = new Font("Mictosoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Size = new Size(425, 425);
            this.ControlBox = false;
            this.TabIndex = 0;


            // Sets label properties
            this.label.AutoSize = true;
            this.label.Name = "printingLabel";
            this.label.Location = new Point(12, 28);
            this.label.Text = "Sending to printer...";
            this.label.TabIndex = 5;


            // Gets image
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("FrontEndSD.Resources.Printer.png");
            Bitmap printer = new Bitmap(myStream);


            // Sets image properties
            this.image.Name = "printerImage";
            this.image.Location = new Point(100, 100);
            this.image.Size = new Size(200, 200);
            this.image.SizeMode = PictureBoxSizeMode.StretchImage;
            this.image.Image = printer;
            this.image.BackColor = Color.Transparent;
            this.image.TabIndex = 2;


            // Sets button properties
            this.button.Name = "okButton";
            this.button.Location = new Point(283, 325);
            this.button.Size = new Size(100, 27);
            this.button.Text = "OK";
            this.button.TabIndex = 4;
            this.button.Click += new EventHandler(OK_Click); // Added click event
        }


        /* OK button */
        private void OK_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes current form
        }
    }
}
