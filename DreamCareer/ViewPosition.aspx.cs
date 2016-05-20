using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class ViewPosition : UserPage
    {

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (this.LoadError)
                return;

            //TODO add company textbox too
            string pos = Request.QueryString["PositionID"];

            if (pos == null || pos == "")
            {
                return;
            }
            int posid;
            int.TryParse(pos, out posid);
            if (!posid.Equals(0))
            {
                Dictionary<string, string> positioninfo = Database.GetPosition(posid);
                string title = positioninfo["Title"];
                string type = positioninfo["Type"];
                string salary = positioninfo["Salary"];
                string description = positioninfo["Description"];
                string street = positioninfo["Street"];
                string city = positioninfo["City"];
                string state = positioninfo["State"];
                string zip = positioninfo["Zipcode"];

                positiontitle.Text = "Title:" + HttpUtility.HtmlEncode(title);
                positiontype.Text = "Type:" + HttpUtility.HtmlEncode(type);
                salaryamount.Text = "Salary:" + HttpUtility.HtmlEncode(salary);
                job.Text = "Description:" + HttpUtility.HtmlEncode(description);
                streetname.Text = "Street:" + HttpUtility.HtmlEncode(street);
                cityname.Text = "City:" + HttpUtility.HtmlEncode(city);
                statename.Text = "State:" + HttpUtility.HtmlEncode(state);
                zipcode.Text = "Zipcode:" + HttpUtility.HtmlEncode(zip);
            }
            else
            {
               // name_dne_error_label.Text = "Not an existing position.";
                return;
            }

        }
 
        protected void ApplyButton_OnClick(object sender, EventArgs e)
        {
            String posid = Request.QueryString["PositionID"];
            String userid = Request.QueryString["userid"];
            Database.insertUserIDPositionID(userid, posid);
            System.Windows.Forms.MessageBox.Show("Applied!");
            Response.Redirect("Login.aspx");
            return;
        }

        protected void Upload(object sender, EventArgs e)
        {
            // Dummy to make this thing compile
        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            // Same
        }
    }
}
