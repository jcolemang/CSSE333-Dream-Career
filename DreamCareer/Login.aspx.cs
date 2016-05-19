using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_OnClick(object sender, EventArgs e)
        {
            string Username = username.Text.ToLower();
            string Password = password.Text;
            if (!Database.IsAUser(Username, Password))
            {

                login_username_input_error.Text = "The password and username don't match, try again!";
            }
            else
            {
                // logged in
                Session["username"] = Username;

                try
                {
                    Session["UserID"] = Database.GetUserID(Username);
                }
                catch (UsernameDoesntExistException)
                {
                    // I have no idea how this could ever happen
                    Response.Redirect("ErrorPage.aspx");
                }

                Response.Redirect("Default.aspx?field1=" + Database.GetUserID(Username));
            }


        }

    }
}