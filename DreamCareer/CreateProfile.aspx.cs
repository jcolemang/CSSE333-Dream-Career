using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class CreateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void InsertProfileButton_OnClick( object sender, EventArgs e)
        {
            string n = name.Text;
            string gend = gender.Text;
            string maj = major.Text;
            string add = address.Text;
            string exp = experience.Text;
            string uname = prof_username.Text;


            try
            {
                Database.CreateUserProfile(n, gend, maj, add, exp, uname);
                error_label.Text = "Inserted profile";
            }
            catch (System.Data.SqlClient.SqlException)
            {
                error_label.Text = "ERROR!";
            }
        }
    }
}