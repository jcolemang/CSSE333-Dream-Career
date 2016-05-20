using System;

namespace DreamCareer
{
    public partial class CreateProfile : UserPage
    {

        protected void InsertProfileButton_OnClick(object sender, EventArgs e)
        {
            string uname = this.Username;
            string n = name.Text;
            int gend = gender.SelectedIndex;
            //string gend = gender.Text; not sure about gender part----------------------------------------------------------------------
            string maj = major.Text;
            string stree = street.Text;
            string cit = city.Text;
            string stat = state.Text;
            string zi = zip.Text;
            string exp = experience.Text;
            string GenderString;
            if (gend == 1) { GenderString = "Male"; }
            else if (gend == 2) { GenderString = "Female"; }
            else if (gend == 3) { GenderString = "Other"; }
            else { GenderString = "Prefer not to say"; }
            
            
            if (Database.checkIfUsernameInDatabase(uname))
            {
                try
                {
                    Database.CreateUserProfile(n, GenderString, maj, exp, stree, cit, stat, zi, uname);
                    Response.Redirect("Default.aspx");
                }
                catch (ProfileAlreadyExistsException)
                {
                    ProfileAlreadyExistsLabel.Text = "You already have a profile!";
                }
            }
        }
    }
}
