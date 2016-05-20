using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class ViewProfile : UserPage
    {
        protected int ProfileID;
        protected string name;


        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (this.LoadError)
                return;

            string UsernameParameter = "";
            if (Request.QueryString["username"] != null)
            {
                UsernameParameter = Request.QueryString["username"];
            }
            else
            {
                // The default if they gave no parameter
                Response.Redirect("ViewProfile.aspx?username=" + Session["username"]);
                return;
            }

            // Getting the profile
            Dictionary<string, string> Profile;
            try
            {
                Profile = Database.GetProfile(UsernameParameter);
                bool ValidProfileID = int.TryParse(Profile["ProfileID"], out this.ProfileID);
                if (!ValidProfileID)
                {
                    Response.Redirect("ErrorPage.aspx");
                    return;
                }
                    
            }
            catch (ProfileDoesntExistException)
            {
                if (this.Username == UsernameParameter)
                {
                    Response.Redirect("CreateProfile.aspx");
                }
                else
                {
                    this.SendToErrorPage("User has no profile");
                }

                return;
            }

            NameText.InnerText = Profile["Name"];
            GenderText.InnerText = Profile["Gender"];
            MajorText.InnerText = Profile["Major"];
            ExperienceText.InnerText = Profile["Experience"];
            StreetText.InnerText = Profile["Street"];
            CityText.InnerText = Profile["City"];
            StateText.InnerText = Profile["State"];
            ZipcodeText.InnerText = Profile["Zipcode"];
        }


        protected void UpdateGender(object sender, EventArgs e)
        {
            string newGender = UpdateGenderTextBox.Text;
            Database.UpdateProfile(this.ProfileID, NewGender: newGender);
            GenderText.InnerText = HttpUtility.HtmlEncode(newGender);
        }


        protected void UpdateMajor(object sender, EventArgs e)
        {
            string newMajor = UpdateMajorTextBox.Text;
            Database.UpdateProfile(this.ProfileID, NewMajor: newMajor);
            MajorText.InnerText = HttpUtility.HtmlEncode(newMajor);
        }


        protected void UpdateExperience(object sender, EventArgs e)
        {
            string newExperience = UpdateExperienceTextBox.Text;
            Database.UpdateProfile(this.ProfileID, NewExperience: newExperience);
            ExperienceText.InnerText = HttpUtility.HtmlEncode(newExperience);
        }


        protected void UpdateStreet(object sender, EventArgs e)
        {
            string newStreet = UpdateStreetTextBox.Text;
            Database.UpdateProfile(this.ProfileID, NewStreet: newStreet);
            StreetText.InnerText = HttpUtility.HtmlEncode(newStreet);
        }


        protected void UpdateCity(object sender, EventArgs e)
        {
            string newCity = UpdateCityTextBox.Text;
            Database.UpdateProfile(this.ProfileID, NewCity: newCity);
            StreetText.InnerText = HttpUtility.HtmlEncode(newCity);
        }

        protected void UpdateState(object sender, EventArgs e)
        {
            string newState = UpdateStateTextBox.Text;
            Database.UpdateProfile(this.ProfileID, NewState: newState);
            StateText.InnerText = HttpUtility.HtmlEncode(newState);
        }


        protected void UpdateZipcode(object sender, EventArgs e)
        {
            string newZipcode = UpdateZipcodeTextBox.Text;
            Database.UpdateProfile(this.ProfileID, NewZipcode: newZipcode);
            ZipcodeText.InnerText = HttpUtility.HtmlEncode(newZipcode);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Database.DeleteProfile(this.ProfileID);
            Response.Redirect("Default.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Database.LikeProfile(this.ProfileID);
            Response.Redirect("Default.aspx");
        }

        protected string WriteUserCompanies()
        {
            string ResponseString = "";

            List<Dictionary<string, string>> Companies =
                Database.GetUserCompanies(this.UserID);

            foreach (Dictionary<string, string> Company in Companies)
            {
                ResponseString += "<div>";
                ResponseString += "<div class=\"text-div\">";

                ResponseString += String.Format(
                    "<a class=\"search-result\" " + 
                    "href=\"ViewCompany.aspx?CompanyID={0}\">" + 
                    "{1}" + 
                    "</a>",
                    HttpUtility.HtmlEncode(Company["CompanyID"]),
                    HttpUtility.HtmlEncode(Company["CompanyName"])
                    );

                ResponseString += "</div>";
                ResponseString += "</div>";
            }

            return ResponseString;
        }
    }
}