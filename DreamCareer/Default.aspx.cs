using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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