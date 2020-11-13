using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class MainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If not logged in
            if (string.IsNullOrEmpty(Session["username"] as string))
                Response.Redirect("~/Login.aspx");
        }


        protected void BookingButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Booking.aspx");
        }


        protected void RequestsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Requests.aspx");
        }


        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Response.Redirect("~/Login.aspx");
        }
    }
}