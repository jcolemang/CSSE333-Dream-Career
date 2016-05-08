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
           
            Database.CreatePosition(pos, ty, stree, cit, stat, zi, sal, jobdesc);
            System.Windows.Forms.MessageBox.Show("Created!");
            Response.Redirect("Login.aspx");

            //if (Session["title"] == null)
            //    Response.Redirect("Login.aspx");  
        }

    }
}