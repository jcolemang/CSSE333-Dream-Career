using System;
using System.Web;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class Profile : System.Web.UI.Page
    {
        //public HtmlString temp;
        protected void Page_Load(object sender, EventArgs e)
        {
       //     var temp = Database.GetProfile("xuy2");
            
        }

        protected void getData(object sender, EventArgs e)
        {
            //     var temp = Database.GetProfile("xuy2");
            string Name = Request.QueryString["Name"];
            string Gender = Request.QueryString["Gender"];
            string Major = Request.QueryString["Major"];
            string Experience = Request.QueryString["Experience"];
            string Street = Request.QueryString["Street"];
            string City = Request.QueryString["City"];
            string State = Request.QueryString["State"];
            string Zipcode = Request.QueryString["Zipcode"];


        }
    }
}
