using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class CreateCompany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // TODO make a specific user type that can do this
            if (Session["Username"] == null)
                Response.Redirect("Login.aspx");
        }
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

            /*
            if (!Zip.Length.Equals(5) && !Zip.Length.Equals(0))
            {
                zip_input_error_label.Text = "Invalid zip code";
                return;
            }

            if (Name.Equals(""))
            {
                name_input_error_label.Text = "Need company name to make company profile.";
                return;
            }
            if (Database.checkIfNameInDatabase(nam))
            {
                name_input_error_label.Text = "A profile for this company already exists.";
                return;
            }
            */

            if (!IsValid)
            {
                // Company size isn't a number
            }

            if (Database.checkIfNameInDatabase(Name))
            {
                // Company with that name already exists
            }
            else
            {
                // Good to insert!
                Database.CreateCompany(Size, Name, Description,
                    Street, City, State, Zipcode);
            }




            Database.CreateCompany(Size, Name, Description, Street, City, State, Zipcode);
            System.Windows.Forms.MessageBox.Show("Created!");
            Response.Redirect("Position.aspx?value1="+Name.ToString());
        }
    }
}