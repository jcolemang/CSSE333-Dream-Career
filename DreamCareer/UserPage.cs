using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DreamCareer
{
    public class UserPage : System.Web.UI.Page
    {
        protected int UserID;
        protected int CompanyID;
        protected string Username;
        protected bool LoadError;
        
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            this.LoadError = false;
            if (Session["username"] == null)
            {
                this.LoadError = true;
                Response.Redirect("Login.aspx");
                return;
            }

            if (!this.SetUser())
            {
                this.LoadError = true;
                this.SendToErrorPage("Not a valid username.");
                return;
            }
        }

        protected bool SetUser()
        {
            string UsernameString = Session["username"].ToString();
            
            try
            {
                this.UserID = Database.GetUserID(UsernameString);
                this.Username = UsernameString;
                return true;
            }
            catch (UsernameDoesntExistException)
            {
                this.SendToErrorPage("Username doesn't exist");
            }

            return false;
        }

        /*
         * converts the CompanyID into an integer and checks if it is valid
         */
        protected bool SetCompanyID()
        {
            string CompanyIDString = Request.QueryString["CompanyID"] ?? "Unparseable";
            if (!int.TryParse(CompanyIDString, out this.CompanyID))
            {
                this.SendToErrorPage("Invalid CompanyID");
                return false;
            }
            try
            {
                Database.GetCompany(this.CompanyID);
            }
            catch (CompanyDoesntExistException)
            {
                this.SendToErrorPage("Company doesn't exist.");
                return false;
            }

            return true;
        }

        protected void SendToErrorPage(string message)
        {
            Response.Redirect("ErrorPage.aspx");
        }
    }

    public class AdminPage : UserPage
    {
        private string[] AllowedUsers = { "coleman" };
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (this.LoadError)
                return;

            if (!this.AllowedUsers.Contains(this.Username))
            {
                this.LoadError = true;
                this.SendToErrorPage("You are not an admin!");
                return;
            }
        }
    }
}