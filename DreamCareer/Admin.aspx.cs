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
        UserGenerator userGenerator;
        ProfileGenerator profileGenerator;
        CompanyGenerator companyGenerator;
        PositionGenerator positionGenerator;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.userGenerator = new UserGenerator();
            this.profileGenerator = new ProfileGenerator();
            this.companyGenerator = new CompanyGenerator();
            this.positionGenerator = new PositionGenerator();
        }

        protected void ClearLabelText()
        {
            GenerateUsersText.Text = "";
            GenerateProfilesText.Text = "";
            GenerateCompaniesLabel.Text = "";
            GeneratePositionsLabel.Text = "";
        }

        protected void GenerateUsersButton_OnClick(object sender, 
            EventArgs e)
        {
            this.ClearLabelText();
            int NumToGenerate = 50;
            this.userGenerator.GenerateUsers(NumToGenerate);
            GenerateUsersText.Text = "Insertions Complete";
        }

        protected void GenerateProfilesButton_OnClick(
            object sender, EventArgs e)
        {
            this.ClearLabelText();
            int NumToGenerate = 250;
            this.profileGenerator.GenerateProfiles(NumToGenerate);
            GenerateProfilesText.Text = "Insertions Complete";
        }

        protected void GenerateCompaniesButton_OnClick(
            object sender, EventArgs e)
        {
            this.ClearLabelText();
            int NumToGenerate = 1000;
            this.companyGenerator.GenerateCompanies(NumToGenerate);
            GenerateCompaniesLabel.Text = "Insertions Complete";
        }

        protected void GeneratePositionsButton_OnClick(
            object sender, EventArgs e)
        {
            this.ClearLabelText();

            int NumToGenerate = 250;
            //this.positionGenerator.Ge
            GeneratePositionsLabel.Text = "Insertions Complete";
        }
    }
}