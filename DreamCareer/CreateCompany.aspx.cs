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

        }
        protected void InsertCompanyButton_OnClick(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("Login.aspx");

            string uname = (string)Session["username"];
            string n = name.Text;
            int gend = gender.SelectedIndex;
            //string gend = gender.Text; not sure about gender part----------------------------------------------------------------------
            string maj = major.Text;
            string stree = street.Text;
            string cit = city.Text;
            string stat = state.Text;
            string zi = zip.Text;
            string exp = experience.Text;
            string gende = "Select";
            
            Database.CreateUserProfile(n, gende, maj, exp, stree, cit, stat, zi, uname);

        }
    }
}