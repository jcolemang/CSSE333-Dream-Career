using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class Position : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check that the query string is valid
            // Should include a CompanyID
            // Should check that the current user owns the company
        }
        protected void InsertPositionButton_OnClick(object sender, EventArgs e)
        {
            //comment out later START//
            string s = compname.Text;
            //comment out later END//
            string pos = titl.Text;
            string ty = typ.Text;
            string stree = strname.Text;
            string cit = cityname.Text;
            string stat = statename.Text;
            string zi = zipcode.Text;
            string sal =salaryam.Text;
            string jobdesc = jobdes.Text;

            if (!zi.Length.Equals(5) && !zi.Length.Equals(0))
            {
                zip_input_error_label.Text = "Invalid zip code";
                return;
            }

            if (pos.Equals(""))
            {
                name_input_error_label.Text = "Need title to make position.";
                return;
            }
            if (s.Equals(""))
            {
                compname_input_error_label.Text = "Need company name to make position.";
                return;
            }
            //Comment in later START//
            //String s = Request.QueryString["value1"];
            //Comment in later END//

            //TODO add code later to throw error if name of non-existent company
            int compid = Database.GetCompanyID(s);
            Database.CreatePosition(compid, pos, ty, stree, cit, stat, zi, sal, jobdesc);
            System.Windows.Forms.MessageBox.Show("Created!");
            Response.Redirect("Login.aspx");  
        }

    }
}