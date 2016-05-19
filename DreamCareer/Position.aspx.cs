using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    

    public partial class Position : UserPage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (this.LoadError)
                return;

            // Set the company ID
        }


        protected void InsertPositionButton_OnClick(object sender, EventArgs e)
        {
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

            //Comment in later START//
            //String s = Request.QueryString["value1"];
            //Comment in later END//
                                                         
            //TODO add code later to throw error if name of non-existent company
            int compid = Database.GetCompanyID(this.Username);
            int posid = Database.getPosId(pos);
            Database.CreatePosition(compid, pos, ty, stree, cit, stat, zi, sal, jobdesc);
            System.Windows.Forms.MessageBox.Show("Created!");
            Response.Redirect("Login.aspx?value1 = " + pos);  
        }

    }
}