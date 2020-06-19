
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FrontEndSD
{
    class Rating : Panel
    {
        /* Declare variables */
        private int leftMargin = 0;
        private int rightMargin = 0;
        private int topMargin = 0;
        private int bottomMargin = 0;

        private int starSpacing = 5;
        private int starCount = 5;
        private int selectedStar;

        private Rectangle[] starArea;


        public Rating(int selected)
        {
            // Set styles
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            OutlineColor = Color.Red;

            // Set variables
            selectedStar = selected;

            Width = 120;
            Height = 18;

            starArea = new Rectangle[starCount];
        }


        /* Painting the form */
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.Clear(BackColor);


            // Sets the size
            int starWidth = (Width - (LeftMargin + RightMargin + (StarSpacing * (starCount - 1)))) / starCount; // Gets width of total and divides by total
            int starHeight = Height - (TopMargin + BottomMargin);

            
            Rectangle ratingArea = new Rectangle(LeftMargin, TopMargin, starWidth, starHeight); // Area of stars


            // Loops for all stars
            for (int i = 0; i < starCount; ++i)
            {
                // Sets star properties
                starArea[i].Location = new Point(ratingArea.X, ratingArea.Y);
                starArea[i].Size = new Size(ratingArea.Width, ratingArea.Height);

                DrawStar(pe.Graphics, ratingArea, i); // Draws start

                ratingArea.X += ratingArea.Width + StarSpacing; // New X position
            }

            base.OnPaint(pe);
        }


        /* Drawing a star */
        protected void DrawStar(Graphics g, Rectangle rect, int starAreaIndex)
        {
            // Set variables
            Brush fillBrush;
            Pen outlinePen = new Pen(OutlineColor, OutlineThickness);


            // Decides whether to colour star
            if (selectedStar > starAreaIndex) // If above rating
                fillBrush = new LinearGradientBrush(rect, selectedColor, BackColor, LinearGradientMode.ForwardDiagonal); // Colourless
            else // If within rating
                fillBrush = new SolidBrush(BackColor); // Coloured
            

            // Sets locations of all 10 corners of the star
            PointF[] p = new PointF[10];
            p[0].X = rect.X + (rect.Width / 2);
            p[0].Y = rect.Y;
            p[1].X = rect.X + (42 * rect.Width / 64);
            p[1].Y = rect.Y + (19 * rect.Height / 64);
            p[2].X = rect.X + rect.Width;
            p[2].Y = rect.Y + (22 * rect.Height / 64);
            p[3].X = rect.X + (48 * rect.Width / 64);
            p[3].Y = rect.Y + (38 * rect.Height / 64);
            p[4].X = rect.X + (52 * rect.Width / 64);
            p[4].Y = rect.Y + rect.Height;
            p[5].X = rect.X + (rect.Width / 2);
            p[5].Y = rect.Y + (52 * rect.Height / 64);
            p[6].X = rect.X + (12 * rect.Width / 64);
            p[6].Y = rect.Y + rect.Height;
            p[7].X = rect.X + rect.Width / 4;
            p[7].Y = rect.Y + (38 * rect.Height / 64);
            p[8].X = rect.X;
            p[8].Y = rect.Y + (22 * rect.Height / 64);
            p[9].X = rect.X + (22 * rect.Width / 64);
            p[9].Y = rect.Y + (19 * rect.Height / 64);


            // Draws the star
            g.FillPolygon(fillBrush, p);
            g.DrawPolygon(outlinePen, p);
        }


        /* Get/Set Methods */
        public int LeftMargin { get => leftMargin; private set => leftMargin = value; }
        public int RightMargin { get => rightMargin; private set => rightMargin = value; }
        public int TopMargin { get => topMargin; private set => topMargin = value; }
        public int BottomMargin { get => bottomMargin; private set => bottomMargin = value; }

        public int StarSpacing { get => starSpacing; private set => starSpacing = value; }

        public float OutlineThickness { get; private set; }
        public Color OutlineColor { get; private set; }
        public Color selectedColor = Color.Red;
    }
}
