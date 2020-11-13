using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Components
{
    public partial class PhoneNum : TextBox
    {
        public PhoneNum()
        {
            InitializeComponent();
        }


        public PhoneNum(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        private bool error;

        public bool Error
        {
            get { return error; }
        }


        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            // Only allow numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;

            base.OnKeyPress(e);
        }


        protected override void OnTextChanged(EventArgs e)
        {
            if (this.Text.Length > 11)
            {
                error = true;
                this.ForeColor = Color.Red;
            }
            else
            {
                error = false;
                this.ForeColor = Color.Black;
            }

            base.OnTextChanged(e);
        }
    }
}
