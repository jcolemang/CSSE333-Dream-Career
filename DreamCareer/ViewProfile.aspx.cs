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

                NameText.InnerText = Profile["Name"];
                GenderText.InnerText = Profile["Gender"];
                MajorText.InnerText = Profile["Major"];
                ExperienceText.InnerText = Profile["Experience"];
                StreetText.InnerText = Profile["Street"];
                CityText.InnerText = Profile["City"];
                StateText.InnerText = Profile["State"];
                ZipcodeText.InnerText = Profile["Zipcode"];
            }
            catch (NoDataException)
            {
                Response.Redirect("CreateProfile.aspx");
            }


        }

        protected void EditButton_OnClick(object sender, EventArgs e)
        {
           
            //get the current username
                      string usernameString = Request.QueryString["username"];
                      int username;
                      int.TryParse(usernameString, out username);

            //get the new field
                      String NewName = UpdateNameTextBox.Text;

            //update with new field
                       Database.UpdateProfile(username, NewName: NewName);
                      NameText.InnerText = NewName;
        }

        protected void Like_Click(object sender, EventArgs e)
        {

        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            //if it has a valid username, then go on
            if(Request.QueryString["username"] != null)
            {
                string usernameString = Request.QueryString["usernmae"];
                int username;
                int.TryParse(usernameString, out username);
                String newName = NameText.InnerText;
                Database.UpdateProfile(username, NewName: newName);
            }
               
        }

        protected void Commit_Click(object sender, EventArgs e)
        {

        }
    }
}