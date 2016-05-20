using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class AlterPosition : UserPage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (this.LoadError)
                return;
        }


        protected void InsertAlterPositionButton_OnClick(object sender, EventArgs e)
        {
            string oldposid = Request.QueryString["oldposid"];
            string companyid = Request.QueryString["companyid"];

            string pos = newtitle.Text;
            string ty = typ.Text;
            string stree = strname.Text;
            string cit = cityname.Text;
            string stat = statename.Text;
            string zi = zipcode.Text;
            string sal = salaryam.Text;
            string jobdesc = jobdes.Text;

            bool AllGood = true;
            if (!CheckType(ty))
                AllGood = false;
            if (!CheckType(ty))
                AllGood = false;
            if (!CheckTitle(pos))
                AllGood = false;
            if (!CheckStreet(stree))
                AllGood = false;
            if (!CheckState(stat))
                AllGood = false;
            if (!CheckZip(zi))
                AllGood = false;
            if (!CheckSalary(sal.ToString()))
                AllGood = false;
            if (!CheckDescription(jobdesc))
                AllGood = false;
            if (!CheckCity(cit))
                AllGood = false;
         
            //Database.getPositionInfo(posid);
            Database.UpdatePosition(Convert.ToInt32(oldposid), Convert.ToInt32(companyid), pos, ty, stree, cit, stat, zi, sal, jobdesc);
            System.Windows.Forms.MessageBox.Show("Updated!");
            Response.Redirect("Login.aspx");
        }


        protected void DeletePositionButton_OnClick(object sender, EventArgs e)
        {
            string oldposid = Request.QueryString["oldposid"];
            Database.deletePosition(Convert.ToInt32(oldposid));
            System.Windows.Forms.MessageBox.Show("Deleted!");
            Response.Redirect("Login.aspx");
        }

        protected bool CheckTitle(string Title)
        {
            TitleErrorLabel.Text = "";
            if (Title.Length == 0)
            {
                TitleErrorLabel.Text = "You must enter a title";
                return false;
            }

            if (Title.Length > Database.MaxTitleLength)
            {
                TitleErrorLabel.Text = "Title is too long!";
                return false;
            }

            return true;
        }


        protected bool CheckType(string PosType)
        {

            TypeErrorLabel.Text = "";
            if (PosType.Length == 0)
            {
                TypeErrorLabel.Text = "You must enter a position type";
                return false;
            }

            if (PosType.Length > Database.MaxTypeLength)
            {
                TypeErrorLabel.Text = "Position type too long";
                return false;
            }

            return true;
        }


        protected bool CheckStreet(string Street)
        {
            StreetErrorLabel.Text = "";
            if (Street.Length > Database.MaxStreetLength)
            {
                StreetErrorLabel.Text = "Street too long";
                return false;
            }

            return true;
        }


        protected bool CheckCity(string City)
        {
            CityErrorLabel.Text = "";
            if (City.Length > Database.MaxCityLength)
            {
                CityErrorLabel.Text = "City too long";
                return false;
            }

            return true;
        }


        protected bool CheckState(string State)
        {
            StateErrorLabel.Text = "";

            if (State.Length > Database.MaxStateLength)
            {
                StateErrorLabel.Text = "State too long (now I know you're just trying to break my stuff)";
                return false;
            }

            return true;
        }


        protected bool CheckZip(string Zipcode)
        {
            zip_input_error_label.Text = "";
            string ZipRegex = @"^[0-9]{5}$";

            if (Zipcode == "")
                return true;

            if (!Regex.IsMatch(Zipcode, ZipRegex))
            {
                zip_input_error_label.Text = "That doesn't look like a zipcode to me";
                return false;
            }

            return true;
        }


        protected bool CheckSalary(string SalaryString)
        {
            SalaryErrorLabel.Text = "";
            decimal Salary;

            if (!Decimal.TryParse(SalaryString, out Salary))
            {
                SalaryErrorLabel.Text = "That doesn't look like a number to me";
                return false;
            }

            return true;
        }


        protected bool CheckDescription(string Description)
        {
            DescriptionErrorLabel.Text = "";

            if (Description.Length > Database.MaxDescriptionLength)
            {
                DescriptionErrorLabel.Text = "Description is too long!";
                return false;
            }

            return true;
        }
    }
}