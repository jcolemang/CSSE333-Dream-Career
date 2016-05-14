using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamCareer
{
    public partial class SearchResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected string BuildPositionResponse(List<Dictionary<string, string>> Results)
        {
            string response = "";
            response += "<table id=\"search-results-table\">";

            foreach (Dictionary<string, string> Row in Results)
            {

                response += "<tr>";
                response += "<td>";
                response += "<a class=\"search-result\" " + 
                    "href=\"ViewPosition.aspx?PositionID=" +
                    HttpUtility.HtmlEncode(Row["PositionID"]) +
                    "\">" +
                    HttpUtility.HtmlEncode(Row["Title"]) +
                    ", " +
                    HttpUtility.HtmlEncode(Row["City"]) +
                    ", " +
                    HttpUtility.HtmlEncode("$" + Row["Salary"]) +
                    "</a>";
                response += "</td>";
                response += "</tr>";
            }

            if (Results.Count == 0)
            {
                response += "<tr>";
                response += "<td>";
                response += "<p>";
                response += "No results to show <strong>:(</strong>";
                response += "</p>";
                response += "</td>";
                response += "</tr>";
            }

            response += "</table>";
            return response;
        }


        protected string BuildCompanyResponse(List<Dictionary<string, string>> Results)
        {
            string response = "";
            response += "<table id=\"search-results-table\">";

            foreach (Dictionary<string, string> Row in Results)
            {

                response += "<tr>";
                response += "<td>";
                response += "<a class=\"search-result\" " + 
                    "href=\"ViewCompany.aspx?CompanyID=" +
                    HttpUtility.HtmlEncode(Row["CompanyID"]) +
                    "\">" +
                    HttpUtility.HtmlEncode(Row["CompanyName"]) + 
                    "</a>";
                response += "</td>";
                response += "</tr>";
            }

            if (Results.Count == 0)
            {
                response += "<tr>";
                response += "<td>";
                response += "<p>";
                response += "No results to show <strong>:(</strong>";
                response += "</p>";
                response += "</td>";
                response += "</tr>";
            }

            response += "</table>";
            return response;
        }


        protected string BuildProfileResponse(List<Dictionary<string, string>> Results)
        {
            string response = "";
            response += "<table id=\"search-results-table\">";

            foreach (Dictionary<string, string> Row in Results)
            {

                response += "<tr>";
                response += "<td>";
                response += "<a class=\"search-result\" " + 
                    "href=\"ViewProfile.aspx?username=" +
                    HttpUtility.HtmlEncode(Row["Username"]) +
                    "\">" +
                    HttpUtility.HtmlEncode(Row["Name"]) + 
                    "</a>";
                response += "</td>";
                response += "</tr>";
            }

            if (Results.Count == 0)
            {
                response += "<tr>";
                response += "<td>";
                response += "<p>";
                response += "No results to show <strong>:(</strong>";
                response += "</p>";
                response += "</td>";
                response += "</tr>";
            }

            response += "</table>";
            return response;
        }
        

        protected List<Dictionary<string, string>> GetResults(string type, List<string> Tags)
        {
            List<Dictionary<string, string>> Results = new List<Dictionary<string, string>>();

            if (type == "Company")
            {
                Results = Database.SearchForCompaniesWithTags(Tags);
            }
            else if (type == "Position")
            {
                Results = Database.SearchForPositionsWithTags(Tags);
            }
            else if (type == "Profile")
            {
                Results = Database.SearchForProfilesWithTags(Tags);
            }

            return Results;
        }

        protected string WriteResults()
        {
            string Search = Request.QueryString["Search"];
            if (Search == "" || Search == null)
            {
                Response.Redirect("Default.aspx");
                return "";
            }

            string SearchType = Request.QueryString["Type"];
            if (SearchType == "" || SearchType == null)
            {
                Response.Redirect("Default.aspx");
                return "";
            }

            List<string> Tags = Database.ParseTags(Request.QueryString["Search"]);
            List<Dictionary<string, string>> Results = this.GetResults(SearchType, Tags);

            if (SearchType == "Position")
            {
                return this.BuildPositionResponse(Results);
            }
            else if (SearchType == "Company")
            {
                return this.BuildCompanyResponse(Results);
            }
            else if (SearchType == "Profile")
            {
                return this.BuildProfileResponse(Results);
            }

            // TODO Put and error thing here
            return "";
        }

        protected void RepeatSearchButton_Click(object sender, EventArgs e)
        {
            string NewSearch = RepeatSearchTextBox.Text;
            Response.Redirect("SearchResults.aspx?Search=" +
                NewSearch);
        }
    }
}