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

                

            /*
            string SearchBarInput = SearchBar.Text;
            string[] tags = SearchBarInput.Split(new char[] { ',' });
            List<Dictionary<string, string>> Positions =
                Database.SearchForPositionsWithTags(new List<string>(tags));

            SearchBar.Text = Positions.Count.ToString();
            */
        }

        protected string WriteResults()
        {
            string Search = Request.QueryString["Search"];
            if (Search == "" || Search == null)
            {
                // do something
                Response.Redirect("Default.aspx");
                return "";
            }

            string[] Tags = Search.Split(new char[] { ',' });
            List<Dictionary<string, string>> Results =
                Database.SearchForPositionsWithTags(new List<string>(Tags));

            string response = "";
            response += "<table>";
            response += "<td><h1>Results</h1></td>";

            foreach (Dictionary<string, string> Row in Results)
            {
                response += "<tr>";
                response += "<td>";
                response += "<a href=\"ViewPosition.aspx?PositionID=" +
                    HttpUtility.HtmlEncode(Row["PositionID"]) +
                    "\">" + HttpUtility.HtmlEncode(Row["Title"]) +
                    "</a>";
                response += "</td>";
                response += "</tr>";
            }

            response += "</table>";


            return response;
        }
    }
}