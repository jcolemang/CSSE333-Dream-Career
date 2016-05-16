﻿using System;

namespace DreamCareer
{
    public partial class CreateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }


        protected void InsertProfileButton_OnClick(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("Login.aspx");

            string uname = (string)Session["username"];
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
            Boolean boo = false;
            
            
            if (Database.checkIfUsernameInDatabase(uname))
            {
                try
                {
                    Database.CreateUserProfile(n, gende, maj, exp, stree, cit, stat, zi, uname);
                }
                catch (ProfileAlreadyExistsException)
                {
                    Response.Redirect("ErrorPage.aspx");
                }
            }
        }
    }
}
