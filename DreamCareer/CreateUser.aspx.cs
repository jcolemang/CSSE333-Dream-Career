using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // I would like it documented that I think
            // this is an absurd was to have tp include
            // javascript.
            /*Page.ClientScript.RegisterClientScriptInclude(
                "selective", ResolveUrl("scripts/CreateUser.js"));

            Page.ClientScript.RegisterClientScriptInclude(
                "selective", ResolveUrl("scripts/jquery-2.2.3.min.js"));
                */
        }
        protected void InsertUserButton_OnClick(object sender, EventArgs e)
        {
            string un = username.Text;
            string em = email.Text;
            string pw = password.Text;

            try
            {
                Database.CreateUser(un, pw, em);
                error_label.Text = "Inserted user";
            }
            catch (System.Data.SqlClient.SqlException)
            {
                error_label.Text = "ERROR!";
            }
        }
    }
}