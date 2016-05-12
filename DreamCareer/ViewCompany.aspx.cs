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

            Dictionary<string, string> Company =
                Database.GetCompany(CompanyID);

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
            string CompanyIDString = Request.QueryString["CompanyID"];
            int ID;
            int.TryParse(CompanyIDString, out ID);
            Database.UpdateCompanyName(ID, "Updated");
            // Update the company's name
        }
    }

}