using StaffSystem.Properties;
using StaffSystem.ServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaffSystem
{
    public partial class Requests : Form
    {
        public Requests()
        {
            InitializeComponent();
        }


        private void Requests_Load(object sender, EventArgs e)
        {
            refreshButton.PerformClick();
        }


        private void RefreshButton_Click(object sender, EventArgs e)
        {
            // Reset request list
            requestList.Clear();
            SetColumns();
            SetFields();
        }


        private void SetColumns()
        {
            // Set column titles
            requestList.Columns.Add("Start", 100);
            requestList.Columns.Add("End", 100);
            requestList.Columns.Add("Status", 75);

            // Add columns to list view
            requestList.View = View.Details;
        }


        private void SetFields()
        {
            WebServiceSoapClient ws = new WebServiceSoapClient();
            int count = 1;

            foreach (Holidays request in ws.GetOutstandingHolidays(Settings.Default.username))
            {
                ListViewItem item = new ListViewItem();
                item.UseItemStyleForSubItems = false;

                // Set request status
                string status = request.Canceled ? "Canceled" : (request.Pending ? "Pending" : (request.Approved ? "Approved" : "Denied"));

                // Adds sub-items to items
                item.Text = (request.Start.ToLongDateString());
                item.SubItems.Add(request.End.ToLongDateString());


                // Set field text and colour
                if (request.Canceled)
                {
                    item.SubItems.Add("Canceled");
                    item.SubItems[2].BackColor = Color.SkyBlue;
                }
                else
                {
                    if (request.Pending)
                    {
                        item.SubItems.Add("Pending");
                        item.SubItems[2].BackColor = Color.White;
                    }
                    else
                    {
                        if (request.Approved)
                        {
                            item.SubItems.Add("Approved");
                            item.SubItems[2].BackColor = Color.LimeGreen;
                        }
                        else
                        {
                            item.SubItems.Add("Denied");
                            item.SubItems[2].BackColor = Color.Red;
                        }
                    }
                }
                

                // Adds data to userListView
                requestList.Items.Add(item);


                count++;
            }
        }


        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
