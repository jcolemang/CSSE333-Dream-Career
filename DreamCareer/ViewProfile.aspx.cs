using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class ViewProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["username"] == null)
                Response.Redirect("Login.aspx");

            string UsernameParameter = "";
            if (Request.QueryString["username"] != null)
            {
                UsernameParameter = Request.QueryString["username"];
            }
            else
            {
                // The default if they gave no parameter
                // Response.Redirect(Session["username"] + ".aspx");
                Response.Redirect("ViewProfile.aspx?username=" + Session["username"]);
            }

            try
            {
                Dictionary<string, string> Profile =
                    Database.GetProfile(UsernameParameter);

                NameLabel.Text = Profile["Name"];
                GenderLabel.Text = Profile["Gender"];
                MajorLabel.Text = Profile["Major"];
                ExperienceLabel.Text = Profile["Experience"];
            }
            catch (NoDataException)
            {
                Response.Redirect("CreateProfile.aspx");
            }


        }

        protected void EditButton_OnClick(object sender, EventArgs e)
        {

        }
    }
}