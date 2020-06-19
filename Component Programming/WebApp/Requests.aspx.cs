using Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Requests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If not logged in
            if (string.IsNullOrEmpty(Session["username"] as string))
                Response.Redirect("~/Login.aspx");

            UserRequests();
        }


        private void UserRequests()
        {
            WebService ws = new WebService();
            List<Holidays> requests = ws.GetOutstandingHolidays(Session["username"].ToString());

            // Add column titles to page
            RequestList.InnerHtml += "<ul class=\"list\">";
            RequestList.InnerHtml += "<li class=\"dates\"> <h3> Booking Dates </h3> </li>";
            RequestList.InnerHtml += "<li class\"status\"> <h3> Status </h3> </li>";
            RequestList.InnerHtml += "</ul>";

            // Add new line for each request to page
            foreach (Holidays booking in requests)
            {
                string status = booking.Canceled ? "Canceled" : (booking.Pending ? "Pending" : (booking.Approved ? "Approved" : "Denied"));

                RequestList.InnerHtml += "<ul class=\"list\">";
                RequestList.InnerHtml += "<li class=\"dates\"> <b> " + booking.Start.ToLongDateString() + " - " + booking.End.ToLongDateString() + " </b> </li>";
                RequestList.InnerHtml += "<li class\"status\"> <b class=\"" + status + "\"> " + status + " </b> </li>";
                RequestList.InnerHtml += "</ul>";
            }
        }


        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenu.aspx");
        }
    }
}