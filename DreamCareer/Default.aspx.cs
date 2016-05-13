using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void SearchPositionButton_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("SearchResults.aspx?Type=Position&Search=" +
                SearchBar.Text);
        }


        protected void SearchCompanyButton_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("SearchResults.aspx?Type=Company&Search=" +
                SearchBar.Text);
        }


        protected void SearchProfileButton_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("SearchResults.aspx?Type=Profile&Search=" +
                SearchBar.Text);
        }
    }
}