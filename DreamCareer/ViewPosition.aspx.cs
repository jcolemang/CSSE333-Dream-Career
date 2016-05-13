using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class ViewPosition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ViewPositionButton_OnClick(object sender, EventArgs e)
        {
            //TODO add company textbox too
            string pos = postitle.Text;
            
            if (pos.Equals(""))
            {
                return;
            }
            int posid = Database.getPosId(pos);
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

                positiontitle.Text = "Title:" + title;
                positiontype.Text = "Type:" + type;
                salaryamount.Text = "Salary:" + salary;
                job.Text = "Description:" + description;
                streetname.Text = "Street:" + street;
                cityname.Text = "City:" + city;
                statename.Text = "State:" + state;
                zipcode.Text = "Zipcode:" + zip;
            }
            else
            {
                name_dne_error_label.Text = "Not an existing position.";
                return;
            }
        }

    }
}
