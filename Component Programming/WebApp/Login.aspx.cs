using Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            WebService ws = new WebService();
            Encrypt encrypt = new Encrypt();

            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            // If successful 
            if (ws.CheckLogin(username, encrypt.Encryption(password)))
            {
                Session["username"] = username;
                Response.Redirect("~/MainMenu.aspx");
            }
            else
                errorLabel.Visible = true;
        }
    }
}