using Components;
using Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Booking : System.Web.UI.Page
    {
        // Declare variables 
        private AlternativeDate constraints = new AlternativeDate();
        private WebService ws = new WebService();
        private Employee user;
        private Holidays bookingRequest;


        protected void Page_Load(object sender, EventArgs e)
        {
            // If not logged in
            if (string.IsNullOrEmpty(Session["username"] as string))
                Response.Redirect("~/Login.aspx");


            user = ws.GetStaff(Session["username"].ToString());
            SetupComponents();
        }


        private void SetupComponents()
        {
            // Request constraints component
            constraints.Management = ws.GetManagement();
            constraints.SeniorStaff = ws.GetSeniors();

            constraints.DefaultTime = ws.DefaultOnDuty();
            constraints.TimePeriods = ws.GetPeriodTimes();
            constraints.RoleTotal = ws.GetTotalRoleNum(user.RoleName, user.DepartmentName);
            constraints.DepartmentTotal = ws.GetTotalDepartmentNum(user.DepartmentName);
        }


        protected void BookButton_Click(object sender, EventArgs e)
        {
            OkButton.Visible = false;


            constraints.AcceptedHolidays = ws.GetApprovedHolidays();


            // Selected data
            DateTime from = FromCalendar.SelectedDate;
            DateTime to = ToCalendar.SelectedDate;
            DateTime today = DateTime.Now;


            // Validate selected date
            if (from >= today && to >= today && to >= from)
            {
                bookingRequest = new Holidays { Staff = user, Start = from, End = to };

                try
                {
                    // If no errors found
                    if (constraints.CheckHoliday(bookingRequest) == null)
                    {
                        // If booking successful
                        if (ws.SubmitBooking(user.Username, bookingRequest.Start, bookingRequest.End))
                        {
                            // Update label
                            MsgLabel.Visible = true;
                            MsgLabel.Text = "Holiday Booked";
                        }
                        else
                        {
                            // Update label
                            MsgLabel.Visible = true;
                            MsgLabel.Text = "Unable to book";
                        }
                    }
                    else
                    {
                        bookingRequest = constraints.SuggestNewDate(bookingRequest);

                        // If new recommended date found
                        if (bookingRequest != null)
                        {
                            // Alternative date text
                            MsgLabel.Text = "An alternative date has been found between " + bookingRequest.Start.ToLongDateString() + " - " + bookingRequest.End.ToLongDateString() + "<br />Would you like to book then?";
                            OkButton.Visible = true;
                        }
                        else
                        {
                            MsgLabel.Visible = true;
                            MsgLabel.Text = "Unable to book a holiday during that time";
                        }
                    }
                }
                catch (Exception e1)
                {

                }
            }
            else
            {
                MsgLabel.Visible = true;
                MsgLabel.Text = "Dates selected cannot be chosen";
            }
        }


        protected void Ok_Click(object sender, EventArgs e)
        {
            // If booking successful
            if (ws.SubmitBooking(user.Username, bookingRequest.Start, bookingRequest.End))
            {
                // Update label
                MsgLabel.Visible = true;
                MsgLabel.Text = "Holiday Booked";

                OkButton.Visible = false;
            }
            else
            {
                // Update label
                MsgLabel.Visible = true;
                MsgLabel.Text = "Unable to book";
            }
        }


        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenu.aspx");
        }
    }
}