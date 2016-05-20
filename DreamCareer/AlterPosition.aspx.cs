using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class AlterPosition : UserPage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (this.LoadError)
                return;
        }
        protected void InsertAlterPositionButton_OnClick(object sender, EventArgs e)
        {
            string oldposid = Request.QueryString["oldposid"];
            string companyid = Request.QueryString["companyid"];

            string pos = newtitle.Text;
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
           
            //Database.getPositionInfo(posid);
            Database.UpdatePosition(Convert.ToInt32(oldposid), Convert.ToInt32(companyid), pos, ty, stree, cit, stat, zi, sal, jobdesc);
            System.Windows.Forms.MessageBox.Show("Updated!");
            Response.Redirect("Login.aspx");
        }
        protected void DeletePositionButton_OnClick(object sender, EventArgs e)
        {
            string oldposid = Request.QueryString["oldposid"];
            Database.deletePosition(Convert.ToInt32(oldposid));
            System.Windows.Forms.MessageBox.Show("Deleted!");
            Response.Redirect("Login.aspx");
        }
    }
}