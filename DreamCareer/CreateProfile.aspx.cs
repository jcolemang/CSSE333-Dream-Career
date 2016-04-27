using System;

namespace DreamCareer
{
    public partial class CreateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        

        protected void InsertProfileButton_OnClick( object sender, EventArgs e)
        {
            string uname = prof_username.Text;
            string n = name.Text;
            string gend = gender.AccessKey;
            //string gend = gender.Text; not sure about gender part----------------------------------------------------------------------
            string maj = major.Text;
            string stree = street.Text;
            string cit = city.Text;
            string stat = state.Text;
            string zi = zip.Text;
            string exp = experience.Text;

                Database.CreateUserProfile(n, gend, maj, exp, stree, cit, stat, zi, uname);
                var enumerator = Database.GetAllUsernamesFromUserTable().GetEnumerator();
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
            }
            
        
        }
    }
