using System;

namespace DreamCareer
{
    public partial class CreateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void InsertProfileButton_OnClick(object sender, EventArgs e)
        {
            string uname = prof_username.Text;
            string n = name.Text;
            int gend = gender.SelectedIndex;
            //string gend = gender.Text; not sure about gender part----------------------------------------------------------------------
            string maj = major.Text;
            string stree = street.Text;
            string cit = city.Text;
            string stat = state.Text;
            string zi = zip.Text;
            string exp = experience.Text;
            string gende = "Select";
            if (gend == 2) { gende = "Male"; }
            else if (gend == 3) { gende = "Female"; }
            else if (gend == 4) { gende = "Other"; }


            //else if(gend == 1) { gende = "Select"; }
            // else { gende = "exc"; }
            // try
            //{
            //    Database.CreateUserProfile(n, gende, maj, exp, stree, cit, stat, zi, uname);
            //}
            /*catch  (ArgumentException)
            {
                gender_not_selected_error.Text = "Gender not selected";
            }  */

            /*var enumerator = Database.GetAllUsernamesFromUserTable().GetEnumerator();
            Boolean boo = false;
            while (enumerator.Current != null)
            {

                if (enumerator.Current == uname)
                {
                    boo = true;
                }
            }
            if (boo.Equals(false))
            {
                throw new MissingMemberException("Username doesn't exist in User Table");
            }
        }     */


        }
    }
}
