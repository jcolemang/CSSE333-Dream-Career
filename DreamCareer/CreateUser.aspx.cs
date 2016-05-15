using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class CreateUser : System.Web.UI.Page
    {
        


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void InsertUserButton_OnClick(object sender, EventArgs e)
        {
            // strip username
            string UName = username.Text.ToLower().Trim();
            string UserEmail = email.Text.ToLower().Trim();
            string UserPassword = password.Text.ToLower().Trim();

            username_input_error_label.Text = "";
            email_input_error_label.Text = "";

            try
            {
                Session["UserID"] = Database.CreateUser(UName, UserPassword, UserEmail);
            }
            catch (RepeatUsernameException)
            {
                username_input_error_label.Text = "Username already in use.";
                return;
            }
            catch (RepeatEmailException)
            {
                email_input_error_label.Text = "Email already in use.";
                return;
            }
            
            Session["username"] = UName;
            Response.Redirect("CreateProfile.aspx");
        }
    }
}