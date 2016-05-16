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

            if (!IsValid)
            {
                // Company size isn't a number
            }

            if (Database.checkIfNameInDatabase(Name))
            {
                // Company with that name already exists
                CompanyNameErrorLabel.Text = "A company by this name already exists.";
                return;
            }
            else
            {
                // Good to insert!
                int CompanyID = Database.CreateCompany(this.UserID, Size, Name, Description,
                    Street, City, State, Zipcode);

                foreach (string tag in Tags)
                    Database.InsertCompanyTag(CompanyID, tag);

                System.Windows.Forms.MessageBox.Show("Created!");
                Response.Redirect("Position.aspx?value1="+Name.ToString());
            }

        }
    }
}