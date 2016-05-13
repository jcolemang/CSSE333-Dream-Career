using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class AlterPosition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void InsertAlterPositionButton_OnClick(object sender, EventArgs e)
        {
            string oldpos = oldtitle.Text;
            string newpos = newtitle.Text;
            string ty = typ.Text;
            string stree = strname.Text;
            string cit = cityname.Text;
            string stat = statename.Text;
            string zi = zipcode.Text;
            string sal = salaryam.Text;
            string jobdesc = jobdes.Text;

            if (!zi.Length.Equals(5) && !zi.Length.Equals(0))
            {
                zip_input_error_label.Text = "Invalid zip code";
                return;
            }
            if (oldpos.Length <= 0)
            {
                name_dne_error_label.Text = "Need title to update position info.";
                return;
            }
            string pos = "";
            if (newpos.Length > 0)
            {
                pos = newpos;
            }
            else
            {
                pos = oldpos;
            }
            int compid = Database.getCompanyIdview(oldpos);
            int posid = Database.getPosId(oldpos);
            //Database.getPositionInfo(posid);
            Database.UpdatePosition(posid, compid, pos, ty, stree, cit, stat, zi, sal, jobdesc);
            System.Windows.Forms.MessageBox.Show("Updated!");
            Response.Redirect("Login.aspx");
        }
    }
}