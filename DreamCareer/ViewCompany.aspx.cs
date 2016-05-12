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
            // Getting the company ID
            string CompanyIDString = Request.QueryString["CompanyID"];
            int ID;
            int.TryParse(CompanyIDString, out ID);

            // Getting the new name
            string NewCompanyName = UpdateCompanyNameTextBox.Text;

            // Update the company's name
            Database.UpdateCompany(ID, NewName: NewCompanyName);

            CompanyName.InnerText = NewCompanyName;
        }
    }

}