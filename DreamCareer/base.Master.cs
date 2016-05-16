using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class _base : System.Web.UI.MasterPage
    {

        protected bool HasProfile;
        protected bool IsUser;
        protected string Username;
        protected int UserID;

        protected void Page_Load(object sender, EventArgs e)
        {
            HasProfile = false;
            var Username = Session["username"];
            if (Username == null)
            {
                this.IsUser = false;
                this.HasProfile = false;
            }
            else
            {
                this.IsUser = true;
                this.Username = Username.ToString();
                this.UserID = Database.GetUserID(this.Username);
                this.HasProfile = this.UserHasProfile();
            }
        }

        protected void LogoutButton_OnClick(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("Default.aspx");
        }

        protected bool UserHasProfile()
        {
            try
            {
                Dictionary<string, string> Profile = Database.GetProfile(this.Username);
                return true;
            }
            catch (NoDataException)
            {
                return false;
            }
        }
    }
}