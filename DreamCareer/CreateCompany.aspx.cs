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

            string nam = (string)Session["name"];
            int siz = comsize.SelectedIndex;
            string descr = compdes.Text;
            string stree = strname.Text;
            string cit = cityname.Text;
            string stat = statename.Text;
            string zi = zipcode.Text;
            string si = "Select";
            if (siz == 2) { si = "Small"; }
            else if (siz == 3) { si = "Medium"; }
            else if (siz == 4) { si = "Big"; }
            Boolean boo = false;


            if (!Database.checkIfNameInDatabase(nam))
            {
                boo = true;
            }



            if (boo)
            {


                //username_input_error_label.Text = "Username doesn't exist.";
                return;
            }
            else
            {
                //username_input_error_label.Text = "";
                Database.CreateCompany(siz, nam, descr, stree, cit, stat, zi);

            }

            if (Session["name"] == null)
                Response.Redirect("Login.aspx");


        }
    }
}