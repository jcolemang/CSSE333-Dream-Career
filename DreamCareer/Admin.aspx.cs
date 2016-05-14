using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class Admin : System.Web.UI.Page
    {
        private string[] AllowedUsers = new string[] { "coleman", "Coleman" };

        UserGenerator UserGenerator;
        ProfileGenerator ProfileGenerator;
        CompanyGenerator CompanyGenerator;
        PositionGenerator PositionGenerator;
        RelationGenerator RelationGenerator;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("Login.aspx");
            if (!AllowedUsers.Contains(Session["username"].ToString()))
                Response.Redirect("Login.aspx");

            this.UserGenerator = new UserGenerator();
            this.ProfileGenerator = new ProfileGenerator();
            this.CompanyGenerator = new CompanyGenerator();
            this.PositionGenerator = new PositionGenerator();
            this.RelationGenerator = new RelationGenerator();
        }

        protected void ClearLabelText()
        {
            GenerateUsersText.Text = "";
            GenerateProfilesText.Text = "";
            GenerateCompaniesLabel.Text = "";
            GeneratePositionsLabel.Text = "";
            GenerateLikesLabel.Text = "";
            GenerateCompanyTagsLabel.Text = "";
            GenerateProfileTagsLabel.Text = "";
            GeneratePositionTagsLabel.Text = "";
        }

        protected void GenerateUsersButton_OnClick(object sender, 
            EventArgs e)
        {
            this.ClearLabelText();
            int NumToGenerate = 50;
            this.UserGenerator.GenerateUsers(NumToGenerate);
            GenerateUsersText.Text = "Insertions Complete";
        }

        protected void GenerateProfilesButton_OnClick(
            object sender, EventArgs e)
        {
            this.ClearLabelText();
            int NumToGenerate = 50;
            this.ProfileGenerator.GenerateProfiles(NumToGenerate);
            GenerateProfilesText.Text = "Insertions Complete";
        }

        protected void GenerateCompaniesButton_OnClick(
            object sender, EventArgs e)
        {
            this.ClearLabelText();
            int NumToGenerate = 50;
            this.CompanyGenerator.GenerateCompanies(NumToGenerate);
            GenerateCompaniesLabel.Text = "Insertions Complete";
        }

        protected void GeneratePositionsButton_OnClick(
            object sender, EventArgs e)
        {
            this.ClearLabelText();
            int NumToGenerate = 50;
            this.PositionGenerator.GeneratePositions(NumToGenerate);
            GeneratePositionsLabel.Text = "Insertions Complete";
        }

        protected void GenerateCompanyTagsButton_OnClick( object sender, EventArgs e)
        {
            this.ClearLabelText();
            int NumToGenerate = 50;
            this.RelationGenerator.GenerateCompanyTags(NumToGenerate);
            this.GenerateCompanyTagsLabel.Text = "Insertions Complete";
        }
        protected void GeneratePositionTagsButton_OnClick( object sender, EventArgs e)
        {
            this.ClearLabelText();
            int NumToGenerate = 50;
            this.RelationGenerator.GeneratePositionTags(NumToGenerate);
            this.GeneratePositionTagsLabel.Text = "Insertions Complete";
        }
        protected void GenerateProfileTagsButton_OnClick( object sender, EventArgs e)
        {
            this.ClearLabelText();
            int NumToGenerate = 50;
            this.RelationGenerator.GenerateProfileTags(NumToGenerate);
            this.GenerateProfileTagsLabel.Text = "Insertions Complete";
        }

        protected void GenerateLikesButton_OnClick(
            object sender, EventArgs e)
        {
            this.ClearLabelText();

            int NumToGenerate = 100;

            this.RelationGenerator.GenerateLikes(NumToGenerate);

            GenerateLikesLabel.Text = "Insertions Complete";
        }

        protected void PageRankButton_OnClick(
            object sender, EventArgs e)
        {
            PageRank.RankProfiles(10);
        }
    }
}