using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class ViewCompany : System.Web.UI.Page
    {

        protected int CompanyID;

        protected void Page_Load(object sender, EventArgs e)
        {
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
            }

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

            this.CompanyID = CompanyID;
            CompanyName.InnerText = Company["Name"];
            CompanyDescription.InnerText = Company["Description"];
            CompanySize.InnerText = Company["Size"];
            CompanyStreet.InnerText = Company["Street"];
            CompanyCity.InnerText = Company["City"];
            CompanyState.InnerText = Company["State"];
            CompanyZipcode.InnerText = Company["Zipcode"];
        }


        protected void UpdateCompanyName(object sender, EventArgs e)
        {
            // Getting the new name
            string NewCompanyName = UpdateCompanyNameTextBox.Text;

            // Update the company's name
            Database.UpdateCompany(this.CompanyID, NewName: NewCompanyName);

            CompanyName.InnerText = NewCompanyName;
        }


        protected void UpdateCompanySize(object sender, EventArgs e)
        {
            string NewCompanySize = UpdateCompanySizeTextBox.Text;
            int NewSize;
            int.TryParse(NewCompanySize, out NewSize);

            Database.UpdateCompany(this.CompanyID, NewSize: NewSize);

            CompanySize.InnerText = NewCompanySize;
        }


        protected void UpdateCompanyDescription(object sender, EventArgs e)
        {
            string NewCompanyDescription = UpdateCompanyDescriptionTextBox.Text;
            Database.UpdateCompany(this.CompanyID, NewDescription: NewCompanyDescription);
            CompanyDescription.InnerText = NewCompanyDescription;
        }


        protected void UpdateCompanyStreet(object sender, EventArgs e)
        {
            string NewCompanyStreet = UpdateCompanyStreetTextBox.Text;
            Database.UpdateCompany(this.CompanyID, NewStreet: NewCompanyStreet);
            CompanyStreet.InnerText = NewCompanyStreet;
        }


        protected void UpdateCompanyCity(object sender, EventArgs e)
        {
            string NewCompanyCity = UpdateCompanyCityTextBox.Text;
            Database.UpdateCompany(this.CompanyID, NewCity: NewCompanyCity);
            CompanyCity.InnerText = NewCompanyCity;
        }


        protected void UpdateCompanyState(object sender, EventArgs e)
        {
            string NewCompanyState = UpdateCompanyStateTextBox.Text;
            Database.UpdateCompany(this.CompanyID, NewState: NewCompanyState);
            CompanyState.InnerText = NewCompanyState;
        }


        protected void UpdateCompanyZipcode(object sender, EventArgs e)
        {
            string NewCompanyZipcode = UpdateCompanyZipcodeTextBox.Text;
            Database.UpdateCompany(this.CompanyID, NewZip: NewCompanyZipcode);
            CompanyZipcode.InnerText = NewCompanyZipcode;
        }


        protected void DeleteCompany(object sender, EventArgs e)
        {
            Database.DeleteCompany(this.CompanyID);
            Response.Redirect("Default.aspx");
        }
    }

}