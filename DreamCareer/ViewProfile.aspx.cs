﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class ViewProfile : System.Web.UI.Page
    {
        protected string username;
        //     protected Dictionary<string, string> ProfileID;
        protected int ProfileID;
        protected int UserID;
        protected string name;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("Login.aspx");
            if (Session["UserID"] == null)
                Response.Redirect("Login.aspx");

            this.UserID = (int)Session["UserID"];

            string UsernameParameter = "";
            if (Request.QueryString["username"] != null)
            {
                UsernameParameter = Request.QueryString["username"];
            }
            else
            {
                // The default if they gave no parameter
                Response.Redirect("ViewProfile.aspx?username=" + Session["username"]);
            }
            Dictionary<string, string> Profile =
                    Database.GetProfile(UsernameParameter);
            try
            {
                ProfileID = Database.getProfileID(UsernameParameter);

                this.ProfileID = ProfileID;
                NameText.InnerText = Profile["Name"];
                GenderText.InnerText = Profile["Gender"];
                MajorText.InnerText = Profile["Major"];
                ExperienceText.InnerText = Profile["Experience"];
                StreetText.InnerText = Profile["Street"];
                CityText.InnerText = Profile["City"];
                StateText.InnerText = Profile["State"];
                ZipcodeText.InnerText = Profile["Zipcode"];
            }
            catch (NoDataException)
            {
                Response.Redirect("CreateProfile.aspx");
            }


        }


        protected void UpdateGender(object sender, EventArgs e)
        {
            string newGender = UpdateGenderTextBox.Text;
            Database.UpdateProfile(this.ProfileID, NewGender: newGender);
            GenderText.InnerText = newGender;
        }


        protected void UpdateMajor(object sender, EventArgs e)
        {
            string newMajor = UpdateMajorTextBox.Text;
            Database.UpdateProfile(this.ProfileID,  NewMajor: newMajor);
            MajorText.InnerText = newMajor;
        }


        protected void UpdateExperience(object sender, EventArgs e)
        {
            string newExperience = UpdateExperienceTextBox.Text;
            Database.UpdateProfile(this.ProfileID, NewExperience: newExperience);
            ExperienceText.InnerText = newExperience;
        }


        protected void UpdateStreet(object sender, EventArgs e)
        {
            string newStreet = UpdateStreetTextBox.Text;
            Database.UpdateProfile(this.ProfileID, NewStreet: newStreet);
            StreetText.InnerText = newStreet;
        }


        protected void UpdateCity(object sender, EventArgs e)
        {
            string newCity = UpdateCityTextBox.Text;
            Database.UpdateProfile(this.ProfileID, NewCity: newCity);
            StreetText.InnerText = newCity;
        }

        protected void UpdateState(object sender, EventArgs e)
        {
            string newState = UpdateStateTextBox.Text;
            Database.UpdateProfile(this.ProfileID, NewState: newState);
            StateText.InnerText = newState;
        }


        protected void UpdateZipcode(object sender, EventArgs e)
        {
            string newZipcode = UpdateZipcodeTextBox.Text;
            Database.UpdateProfile(this.ProfileID, NewZipcode: newZipcode);
            ZipcodeText.InnerText = newZipcode;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Database.DeleteProfile(this.ProfileID);
            Response.Redirect("Default.aspx");
        }
    }
}