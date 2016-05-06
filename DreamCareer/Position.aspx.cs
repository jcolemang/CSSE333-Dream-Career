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

            string pos = titl.Text;
            string ty = typ.Text;
            string stree = strname.Text;
            string cit = cityname.Text;
            string stat = statename.Text;
            string zi = zipcode.Text;
            string sal = salaryam.Text;
            string jobdesc = jobdes.Text;

            //Database.Position(pos, ty, stree, cit, stat, cit, stat, zi, sal, jobdesc);

            //if (Session["title"] == null)
            //    Response.Redirect("Login.aspx");       

        }
    }
}