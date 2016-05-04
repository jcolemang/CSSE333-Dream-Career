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
                return "<h1>Coleman needs to fix this.</h1>";
            }

            string[] Tags = Search.Split(new char[] { ',' });
            List<Dictionary<string, string>> Results =
                Database.SearchForPositionsWithTags(new List<string>(Tags));

            string response = "";
            response += "<table>";
            response += "<td><h1>Results</h1></td>";

            foreach (Dictionary<string, string> Row in Results)
            {
                foreach (string Key in Row.Keys)
                {
                    response += "<tr>";
                    response += "<td>";
                    response += HttpUtility.HtmlEncode(Key);
                    response += "</td>";
                    response += "<td>";
                    response += HttpUtility.HtmlEncode(Row[Key]);
                    response += "</td>";
                    response += "</tr>";
                }
            }

            response += "</table>";


            return response;
        }
    }
}