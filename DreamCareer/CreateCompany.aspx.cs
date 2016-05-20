using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class CreateCompany : UserPage
    {
        protected void InsertCompanyButton_OnClick(object sender, EventArgs e)
        {
            string Name = CompanyName.Text;
            int Size;
            bool IsValid = int.TryParse(CompanySize.Text, out Size);
            string Description = CompanyDescription.Text;
            string Street = CompanyStreet.Text;
            string City = CompanyCity.Text;
            string State = CompanyStreet.Text;
            string Zipcode = CompanyZipcode.Text;
            string TagString = TagsTextBox.Text;
            List<string> Tags = Database.ParseTags(TagString);

            if (Name.Length > Database.MaxCompanyNameLength)
            {
                CompanyNameErrorLabel.Text = "Too long";
                return;
            }
            if (!IsValid)
            {
                CompanySizeErrorLabel.Text = "Not a number";
                return;
            }
            if (Database.checkIfNameInDatabase(Name))
            {
                CompanyNameErrorLabel.Text = "A company by this name already exists.";
                return;
            }
            if (Description.Length > Database.MaxDescriptionLength)
            {
                DescriptionErrorLabel.Text = String.Format(
                    "Description above max length. " +
                    "Number above: {0}", 
                    Description.Length - Database.MaxDescriptionLength);
                return;
            }


            // Good to insert!
            int CompanyID = Database.CreateCompany(this.UserID, Size, Name, Description,
                Street, City, State, Zipcode);

            foreach (string tag in Tags)
                Database.InsertCompanyTag(CompanyID, tag);

            System.Windows.Forms.MessageBox.Show("Created!");
            Response.Redirect("Position.aspx");

        }
    }
}