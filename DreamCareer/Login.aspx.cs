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
            string Username = username.Text;
            string Password = password.Text;

            if (!Database.IsAUser(Username, Password))
            {
                // Write an error
                Response.Redirect("CreateUser.aspx");
            }
            else
            {
                Session["username"] = Username;
                // logged in
                Response.Redirect("Default.aspx");
            }


        }

    }
}