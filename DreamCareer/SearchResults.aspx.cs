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

        private List<string> ParseTags(string TagString)
        {
            List<string> Tags = new List<string>();
            char[] Separators = new char[] { ',', ' ' };

            foreach (string tag in TagString.Split(Separators))
            {
                // Why does split give me the empty string?
                if (tag.Length < 1)
                    continue;
                Tags.Add(tag);
            }

            return Tags;
        }

        protected string WriteResults()
        {
            string Search = Request.QueryString["Search"];
            if (Search == "" || Search == null)
            {
                Response.Redirect("Default.aspx");
                return "";
            }

            List<string> Tags = ParseTags(Request.QueryString["Search"]);
            List<Dictionary<string, string>> Results =
                Database.SearchForPositionsWithTags(Tags);

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

        protected void RepeatSearchButton_Click(object sender, EventArgs e)
        {
            string NewSearch = RepeatSearchTextBox.Text;
            Response.Redirect("SearchResults.aspx?Search=" +
                NewSearch);
        }
    }
}