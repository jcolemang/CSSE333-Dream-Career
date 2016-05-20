using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DreamCareer
{
    public partial class ViewPosition : UserPage
    {

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (this.LoadError)
                return;

            //TODO add company textbox too
            string pos = Request.QueryString["PositionID"];

            if (pos == null || pos == "")
            {
                return;
            }
            int posid;
            int.TryParse(pos, out posid);
            if (!posid.Equals(0))
            {
                Dictionary<string, string> positioninfo = Database.GetPosition(posid);
                string title = positioninfo["Title"];
                string type = positioninfo["Type"];
                string salary = positioninfo["Salary"];
                string description = positioninfo["Description"];
                string street = positioninfo["Street"];
                string city = positioninfo["City"];
                string state = positioninfo["State"];
                string zip = positioninfo["Zipcode"];

                positiontitle.Text = "Title:" + HttpUtility.HtmlEncode(title);
                positiontype.Text = "Type:" + HttpUtility.HtmlEncode(type);
                salaryamount.Text = "Salary:" + HttpUtility.HtmlEncode(salary);
                job.Text = "Description:" + HttpUtility.HtmlEncode(description);
                streetname.Text = "Street:" + HttpUtility.HtmlEncode(street);
                cityname.Text = "City:" + HttpUtility.HtmlEncode(city);
                statename.Text = "State:" + HttpUtility.HtmlEncode(state);
                zipcode.Text = "Zipcode:" + HttpUtility.HtmlEncode(zip);
            }
            else
            {
                // name_dne_error_label.Text = "Not an existing position.";
                return;
            }
            if (!IsPostBack)
            {
                BindGrid();
            }

        }

        private void BindGrid()
        {
            //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = Database.GetSqlConnection())
            {
                // using (SqlCommand cmd = new SqlCommand())
                // {
                //cmd.CommandText = "use DreamCareer go select Id, Name from ApplyTo go GRANT SELECT ON OBJECT::dbo.ApplyTo TO DreamCareer;";
                //cmd.Connection = con;
                //con.Open();
                string sp_name = "idnameapply";
                SqlCommand applysel = new SqlCommand(sp_name, con);
                applysel.CommandType = System.Data.CommandType.StoredProcedure;
                GridView1.DataSource = applysel.ExecuteReader();
                GridView1.DataBind();
                con.Close();
                // }
            }
        }


        protected void Upload(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string contentType = FileUpload1.PostedFile.ContentType;
            using (Stream fs = FileUpload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                    //using (
                    SqlConnection con = Database.GetSqlConnection();
                    //{
                    string sp_name = "upload";
                    String posid = Request.QueryString["PositionID"];
                    String userid = Request.QueryString["userid"];
                    int retval = Database.insertUserIDPositionID(userid, posid);
                    SqlCommand uploadable = new SqlCommand(sp_name, con);
                    uploadable.CommandType = System.Data.CommandType.StoredProcedure;

                    if (retval == 0)
                    {
                        uploadable.Parameters.Add(new SqlParameter("@userid", userid));
                        uploadable.Parameters.Add(new SqlParameter("@posid", posid));
                        uploadable.Parameters.Add(new SqlParameter("@Name", filename));
                        uploadable.Parameters.Add(new SqlParameter("@ContentType", contentType));
                        uploadable.Parameters.Add(new SqlParameter("@Data", bytes));
                        //string query = "insert into ApplyTo values (@Name, @ContentType, @Data)";
                        //using (SqlCommand cmd = new SqlCommand(query))
                        //{
                        //cmd.Connection = con;
                        //cmd.Parameters.AddWithValue("@Name", filename);
                        //    cmd.Parameters.AddWithValue("@ContentType", contentType);
                        //   cmd.Parameters.AddWithValue("@Data", bytes);
                        //con.Open();
                        uploadable.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        con.Close();
                        System.Windows.Forms.MessageBox.Show("Already added resume!");

                    }
                    //}
                    //}
                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }


        protected void DownloadFile(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            string posid = Request.QueryString["PositionID"];
            int userid = this.UserID;
            
            byte[] bytes;
            string fileName, contentType;
            //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            //using (
            SqlConnection con = Database.GetSqlConnection();
            //{
            string sp_name = "download";
            SqlCommand downloadable = new SqlCommand(sp_name, con);
            downloadable.CommandType = System.Data.CommandType.StoredProcedure;
            downloadable.Parameters.Add(new SqlParameter("@id", id));
            downloadable.Parameters.Add(new SqlParameter("@posid", posid));
            downloadable.Parameters.Add(new SqlParameter("@userid", userid));


            using (SqlDataReader sdr = downloadable.ExecuteReader())
            {
                sdr.Read();
                bytes = (byte[])sdr["Data"];
                contentType = sdr["Content Type"].ToString();
                fileName = sdr["Name"].ToString();
            }
            con.Close();
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

        protected void ApplyButton_OnClick(object sender, EventArgs e)
        {
            // String posid = Request.QueryString["PositionID"];
            // String userid = Request.QueryString["userid"];
            // Database.insertUserIDPositionID(userid, posid);
            System.Windows.Forms.MessageBox.Show("Applied!");
            Response.Redirect("SearchResults.aspx?field2=" + this.UserID + "&Type=Position&Search=");
            return;
        }

        protected void AlterPosition_OnClick(object sender, EventArgs e)
        {
            string pos = Request.QueryString["PositionID"];
            Response.Redirect("AlterPosition.aspx?oldposid="+ pos +"&companyid=" + this.CompanyID);
            return;
        }
    }
}
