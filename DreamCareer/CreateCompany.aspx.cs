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
            name_input_error_label.Text = "";
            zip_input_error_label.Text = "";

            string nam = compname.Text;
            int siz = comsize.SelectedIndex;
            string descr = compdes.Text;
            string stree = strname.Text;
            string cit = cityname.Text;
            string stat = statename.Text;
            string zi = zipcode.Text;

            if(!zi.Length.Equals(5) && !zi.Length.Equals(0))
            {
                zip_input_error_label.Text = "Invalid zip code";
                return;
            }
           
            if(nam.Equals("")) { 
                name_input_error_label.Text = "Need company name to make company profile.";
                return;
            }
            if(Database.checkIfNameInDatabase(nam))
            {
                name_input_error_label.Text = "A profile for this company already exists.";
                return;
            }

            Database.CreateCompany(siz, nam, descr, stree, cit, stat, zi);
            System.Windows.Forms.MessageBox.Show("Created!");
            Response.Redirect("Login.aspx");
        }
    }
}         