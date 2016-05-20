using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class ViewCompany : UserPage
    {

        protected int CompanyID;
        protected bool UserOwnsCompany = false;

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (this.LoadError)
                return;

            string CompanyIDString = Request.QueryString["CompanyID"];

            if (CompanyIDString == null || CompanyIDString == "")
            {
                Response.Redirect("Default.aspx");
                return;
            }

            int CompanyID;
            if (!int.TryParse(CompanyIDString, out CompanyID))
            {
                Response.Redirect("Default.aspx");
                return;
            }

            this.CompanyID = CompanyID;

            Dictionary<string, string> Company;
            try
            {
                Company = Database.GetCompany(CompanyID);
            }
            catch (NoDataException NoDataError)
            {
                Response.Redirect("ErrorPage.aspx");
                return;
            }

            this.UserOwnsCompany = false;
            int UserID;
            if (int.TryParse(Session["UserID"].ToString(), out UserID))
            {
                // used in in-line aspx code
                this.UserOwnsCompany = Database.UserInCompany(this.CompanyID, UserID);
            }

            CompanyName.InnerText = HttpUtility.HtmlEncode(Company["Name"]);
            CompanyDescription.InnerText = HttpUtility.HtmlEncode(Company["Description"]);
            CompanySize.InnerText = HttpUtility.HtmlEncode(Company["Size"]);
            CompanyStreet.InnerText = HttpUtility.HtmlEncode(Company["Street"]);
            CompanyCity.InnerText = HttpUtility.HtmlEncode(Company["City"]);
            CompanyState.InnerText = HttpUtility.HtmlEncode(Company["State"]);
            CompanyZipcode.InnerText = HttpUtility.HtmlEncode(Company["Zipcode"]);
            CompanyTagsLabel.Text = HttpUtility.HtmlEncode(GetCompanyTagsString(CompanyID));
        }


        protected string GetCompanyTagsString(int CompanyID)
        {
            List<string> Tags = Database.GetCompanyTags(CompanyID);
            if (Tags.Count == 0)
                return "";
            if (Tags.Count == 1)
                return Tags[0];
            string TagString = Tags[0];
            for (int i = 1; i < Tags.Count; i++)
                TagString += ", " + Tags[i];
            return TagString;
        }


        protected void UpdateCompanyName(object sender, EventArgs e)
        {

            // Getting the new name
            string NewCompanyName = UpdateCompanyNameTextBox.Text;

            if (NewCompanyName.Length > Database.MaxCompanyNameLength)
            {
                CompanyNameErrorLabel.Text = "Company name too long";
                return;
            }

            // Update the company's name
            Database.UpdateCompany(this.CompanyID, NewName: NewCompanyName);

            CompanyName.InnerText = HttpUtility.HtmlEncode(NewCompanyName);
        }


        protected void InsertCompanyTag(object sender, EventArgs e)
        {
            string TagText = TagInput.Text.ToLower();
            List<string> Tags = Database.ParseTags(TagText);
            CompanyTagsErrorLabel.Text = "";
            string NewTag;

            foreach (string tag in Tags)
            {
                // Checking the length of the tag
                if (tag.Length > Database.MaxTagLength)
                {
                    CompanyTagsErrorLabel.Text = "One of the tags is too long";
                    return;
                }
                else
                {
                    // was previously actually useful
                    NewTag = tag;
                }

                // inserting the tag
                try
                {
                    Database.InsertCompanyTag(this.CompanyID, NewTag);
                    if (CompanyTagsLabel.Text.Length == 0)
                        CompanyTagsLabel.Text = HttpUtility.HtmlEncode(NewTag);
                    else
                        CompanyTagsLabel.Text += ", " + HttpUtility.HtmlEncode(NewTag);
                }
                catch (RepeatDataException)
                {
                    // do nothing
                }
            }

            TagInput.Text = "";
        }


        protected void UpdateCompanySize(object sender, EventArgs e)
        {
            string NewCompanySize = UpdateCompanySizeTextBox.Text;
            int NewSize;
            if (!int.TryParse(NewCompanySize, out NewSize))
            {
                CompanySizeErrorLabel.Text = "Not a valid company size.";
                return;
            }
            if (NewSize <= 0)
            {
                CompanySizeErrorLabel.Text = "Company size must be greater than 0.";
                return;
            }

            CompanySizeErrorLabel.Text = "";
            Database.UpdateCompany(this.CompanyID, NewSize: NewSize);
            CompanySize.InnerText = HttpUtility.HtmlEncode(NewCompanySize);
        }


        protected void UpdateCompanyDescription(object sender, EventArgs e)
        {
            string NewCompanyDescription = UpdateCompanyDescriptionTextBox.Text;

            if (NewCompanyDescription.Length > Database.MaxDescriptionLength)
            {
                CompanyDescriptionErrorLabel.Text =
                    String.Format(
                        "Description too long. Remove {0} characters.",
                        NewCompanyDescription.Length - Database.MaxDescriptionLength);
                return;
            }

            Database.UpdateCompany(this.CompanyID, NewDescription: NewCompanyDescription);
            CompanyDescription.InnerText = HttpUtility.HtmlEncode(NewCompanyDescription);
        }


        protected void UpdateCompanyStreet(object sender, EventArgs e)
        {
            string NewCompanyStreet = UpdateCompanyStreetTextBox.Text;

            if (NewCompanyStreet.Length > Database.MaxStreetLength)
            {
                CompanyStreetErrorLabel.Text = "Too long";
                return;
            }

            Database.UpdateCompany(this.CompanyID, NewStreet: NewCompanyStreet);
            CompanyStreet.InnerText = HttpUtility.HtmlEncode(NewCompanyStreet);
        }


        protected void UpdateCompanyCity(object sender, EventArgs e)
        {
            string NewCompanyCity = UpdateCompanyCityTextBox.Text;

            if (NewCompanyCity.Length > Database.MaxCityLength)
            {
                CompanyCityErrorLabel.Text = "Too long";
                return;
            }

            Database.UpdateCompany(this.CompanyID, NewCity: NewCompanyCity);
            CompanyCity.InnerText = HttpUtility.HtmlEncode(NewCompanyCity);
        }


        protected void UpdateCompanyState(object sender, EventArgs e)
        {
            string NewCompanyState = UpdateCompanyStateTextBox.Text;

            if (NewCompanyState.Length > Database.MaxStateLength)
            {
                CompanyStateErrorLabel.Text = "Too long";
                return;
            }

            Database.UpdateCompany(this.CompanyID, NewState: NewCompanyState);
            CompanyState.InnerText = HttpUtility.HtmlEncode(NewCompanyState);
        }


        protected void UpdateCompanyZipcode(object sender, EventArgs e)
        {
            string NewCompanyZipcode = UpdateCompanyZipcodeTextBox.Text.Trim(new char[] { ' ' });
            CompanyZipcodeErrorLabel.Text = "";

            // Checking the zipcode for errors
            int dummy;
            if (!int.TryParse(NewCompanyZipcode, out dummy))
            {
                CompanyZipcodeErrorLabel.Text = "Invalid zipcode";
                return;
            }
            if (NewCompanyZipcode.Length != 5)
            {
                CompanyZipcodeErrorLabel.Text = "Invalid zipcode";
                return;
            }

            Database.UpdateCompany(this.CompanyID, NewZip: NewCompanyZipcode);
            CompanyZipcode.InnerText = HttpUtility.HtmlEncode(NewCompanyZipcode);
        }


        protected void DeleteCompany(object sender, EventArgs e)
        {
            Database.DeleteCompany(this.CompanyID);
            Response.Redirect("Default.aspx");
        }


        protected void AddPosition(object sender, EventArgs e)
        {
            Response.Redirect(String.Format(
                "Position.aspx?CompanyID={0}",
                this.CompanyID));
        }


        protected string GetCompanyPositions()
        {
            string ResponseString = "";

            List<Dictionary<string, string>> Positions = 
                Database.GetCompanyPositions(this.CompanyID);

            foreach (Dictionary<string, string> Position in Positions)
            {
                ResponseString += "<div>";
                ResponseString += "<div class=\"text-div\">"; 

                ResponseString += String.Format(
                    "<a class=\"search-result\" " +
                    "href=\"ViewPosition.aspx?PositionID={0}\">" + 
                    "{1}, {2}, {3}" +  
                    "</a>", 
                    HttpUtility.HtmlEncode(Position["PositionID"]),
                    HttpUtility.HtmlEncode(Position["Title"]), 
                    HttpUtility.HtmlEncode(Position["Type"]), 
                    HttpUtility.HtmlEncode(Position["Salary"]));

                ResponseString += "</div>";
                ResponseString += "</div>";
            }

            return ResponseString;
        }
    }

}