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

            if (!this.SetCompanyID())
                return;

        }


        protected void InsertPositionButton_OnClick(object sender, EventArgs e)
        {
            string pos = titl.Text;
            string ty = typ.Text;
            string stree = strname.Text;
            string cit = cityname.Text;
            string stat = statename.Text;
            string zi = zipcode.Text;
            string salar =salaryam.Text;
            decimal variable2;
            if ((!salar.Length.Equals(0) && !decimal.TryParse(salar, out variable2)) || salar.Contains(" "))
            {
                sal_input_error_label.Text = "Invalid salary value";
                return;
            }
            double salval = Convert.ToDouble(salar);
            double sal = System.Math.Round(salval, 2);
            string jobdesc = jobdes.Text;
            int variable;

            if ((!zi.Length.Equals(5) && !zi.Length.Equals(0)) || (!zi.Length.Equals(0) && !int.TryParse(zi, out variable)) || zi.Contains(" "))
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
            //int posid = Database.getPosId(pos);
            Database.CreatePosition(this.CompanyID, pos, ty, stree, cit, stat, zi, sal, jobdesc);
            System.Windows.Forms.MessageBox.Show("Created!");
            Response.Redirect("Default.aspx");  
        }

    }
}