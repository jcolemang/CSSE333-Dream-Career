using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Data;

namespace DreamCareer
{
    

    /*
     * Basically just a whole bunch of wrappers for
     * SQL stored procedures. Most of them are nearly
     * identical. I could probably compress a lot of
     * them into a standard 'insert' but I don't think
     * the refactoring would be worth the time right now.
     */
    public static class Database
    {
        // constants used by the commands
        public const int RepeatUsernameError = -1;
        public const int RepeatEmailError = -2;
        public const int UsernameDoesntExistError = -3;
        public const int ProfileAlreadyExistsError = -4;
        public const int RepeatCompanyNameError = -7;
        public const int NoSuchData = -5;
        public const int RepeatData = -6;
        public const int UserDoesntExist = -8;

        public const int MaxTagLength = 50;
        
        public static RNGCryptoServiceProvider RNGCSP = 
            new RNGCryptoServiceProvider();
        public static int SaltLength = 128;

        /*
         * 
         */ 
        public static string GenerateSaltValue()
        {
             return GetRandomString(SaltLength);
        }


        public static string GetRandomString(int length)
        {
            byte[] Bytes = new byte[length];
            RNGCSP.GetBytes(Bytes);
            return System.Text.Encoding.ASCII.GetString(Bytes);
        }


        public static SqlConnection GetSqlConnection()
        {
            string remote_db_string = 
                "Data Source=titan.csse.rose-hulman.edu;" +
                "Initial Catalog=DreamCareer;" +
                "Persist Security Info=True;" +
                "User ID=dreamcareer;" +
                "Password=csse333;";

            // Just for Coleman's local machine. 
            // DO NOT USE (unless you're Coleman). It just
            // wont work.
            string local_db_string = 
                "Data Source=localhost;" +
                "Initial Catalog=DreamCareer;" +
                "Integrated Security=True;";

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = local_db_string;
            connection.Open();
            return connection;
        }


        public static int CreateUser( string Username, string Password, string Email )
        {
            string Salt = GenerateSaltValue();

            SqlConnection connection = GetSqlConnection();

            // Setting up the command
            string sp_name = "insert_new_user";
            SqlCommand insert_user = new SqlCommand(sp_name, connection);
            insert_user.CommandType = System.Data.CommandType.StoredProcedure;

            // Adding parameters
            insert_user.Parameters.Add(
                new SqlParameter("@Uname", Username));
            insert_user.Parameters.Add(
                new SqlParameter("@password", Password));
            insert_user.Parameters.Add(
                new SqlParameter("@salt", Salt));
            insert_user.Parameters.Add(
                new SqlParameter("@email", Email));

            // Output parameter
            SqlParameter OutputParam =
                new SqlParameter("@UserID", SqlDbType.Int);
            OutputParam.Direction = ParameterDirection.Output;
            insert_user.Parameters.Add(OutputParam);

            // Setting up a return value container
            SqlParameter ReturnVal = new SqlParameter("RetVal", 
                System.Data.SqlDbType.Int);
            ReturnVal.Direction = 
                System.Data.ParameterDirection.ReturnValue;
            insert_user.Parameters.Add(ReturnVal);

            // Executing the query and closing connection
            insert_user.ExecuteNonQuery();
            connection.Close();

            // checking the return value
            int val = (int)ReturnVal.Value;
            if (val == Database.RepeatEmailError)
                throw new RepeatEmailException();
            if (val == Database.RepeatUsernameError)
                throw new RepeatUsernameException();
            if (val != 0)
                throw new Exception("Unknown error");

            return (int)OutputParam.Value;
        }


        public static string GetUserSalt(string Username)
        {
            SqlConnection connection = GetSqlConnection();

            string sp_name = "get_user_salt";
            SqlCommand get_salt = new SqlCommand(sp_name, connection);
            get_salt.CommandType = System.Data.CommandType.StoredProcedure;

            get_salt.Parameters.Add(
                new SqlParameter("@uname", Username));
            
            SqlParameter ReturnVal = new SqlParameter("RetVal", 
                System.Data.SqlDbType.Int);
            ReturnVal.Direction = 
                System.Data.ParameterDirection.ReturnValue;
            get_salt.Parameters.Add(ReturnVal);

            SqlDataReader reader = get_salt.ExecuteReader();

            if (!reader.Read())
            {
                reader.Close();
                connection.Close();

                if ((int)ReturnVal.Value == Database.UsernameDoesntExistError)
                    throw new UsernameDoesntExistException();
                throw new Exception("Unknown error.");
            }

            string Salt = reader.GetString(0);
            reader.Close();
            connection.Close();
            return Salt;
        }


        /*
         * Hashes the password and salt in the database to verify that
         * the credentials given are valid.
         */
        public static bool IsAUser( string Username, string Password )
        {
            SqlConnection connection = GetSqlConnection();

            // The stored procedure
            string sp_name = "check_username_password";
            SqlCommand get_user_sp = new SqlCommand(sp_name, connection);
            get_user_sp.CommandType = System.Data.CommandType.StoredProcedure;

            get_user_sp.Parameters.Add(
                new SqlParameter("@username", Username));
            get_user_sp.Parameters.Add(
                new SqlParameter("@pass", Password));

            SqlDataReader reader = get_user_sp.ExecuteReader();
            bool contains_data = reader.HasRows;
            reader.Close();
            connection.Close();

            // If there is a matching username and password the credentials must be valid
            return contains_data;
        }

        
        public static List<string> ParseTags(string TagString)
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


        /*
         * Creates a temporary table used to search for tags.
         */
        public static DataTable CreateTagsTable(List<string> tags)
        {
            DataTable TagsTable = new DataTable();
            TagsTable.Columns.Add("TagWords", typeof(string));

            foreach (string tag in tags)
                TagsTable.Rows.Add(tag);

            return TagsTable;
        }


        public static List<string> GetCompanyTags(int CompanyID)
        {
            return _GetTagsHelper("get_company_tags", CompanyID, "@CompanyID");
        }


        /*
         * So I don't have to write the exact same code
         * three times for Company, Position, and Profile
         * I should have done this for search but it isn't 
         * worth rewriting them to have fewer lines of code.
         */
        public static List<string> _GetTagsHelper(
            string sp_name, 
            int ID, 
            string IDParamName)
        {
            List<string> Tags = new List<string>();
            SqlConnection connection = GetSqlConnection();

            SqlCommand command = new SqlCommand(sp_name, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(
                new SqlParameter(IDParamName, ID));

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Tags.Add(reader.GetString(0));
            }

            reader.Close();
            connection.Close();
            return Tags;
        }


        public static List<Dictionary<string, string>> GetCompanyPositions(int CompanyID)
        {
            // Setting up the command
            SqlConnection Connection = GetSqlConnection();
            string SP_Name = "get_company_positions";
            SqlCommand Command = new SqlCommand(SP_Name, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            // Adding parameters
            Command.Parameters.Add(
                new SqlParameter("@CompanyID", CompanyID));

            // Executing the command
            SqlDataReader Reader = Command.ExecuteReader();

            // Getting the results
            List<Dictionary<string, string>> Positions = 
                new List<Dictionary<string, string>>();
            Dictionary<string, string> Position;
            while (Reader.Read())
            {
                Position = new Dictionary<string, string>();
                Position["PositionID"] = Reader.GetInt32(0).ToString();
                Position["Title"] = Reader.GetString(1);
                Position["Type"] = Reader.GetString(2);
                Position["Salary"] = Reader.GetSqlMoney(3).ToString();
                Positions.Add(Position);
            }

            return Positions;
        }


        /*
         * The three Search functions are nearly identical
         * both here and in the database. I should try
         * to combine them but there are more important things
         * to do
         */
        public static List<Dictionary<string, string>> SearchForPositionsWithTags(List<string> Tags)
        {
            string sp_name = "search_positions_by_tags";
            SqlConnection connection = GetSqlConnection();

            // Setting up the command
            SqlCommand search = new SqlCommand(
                sp_name, connection);
            search.CommandType = CommandType.StoredProcedure;

            // Setting up the parameter
            // 'Structured' means this is a table valued parameter
            SqlParameter TagsTableParameter =
                new SqlParameter("@Tags", System.Data.SqlDbType.Structured);
            TagsTableParameter.TypeName = "TagWordsTableType";
            TagsTableParameter.Value = Database.CreateTagsTable(Tags);
            search.Parameters.Add(TagsTableParameter);

            // Executing the query
            SqlDataReader reader = search.ExecuteReader();

            // Getting back the data
            List<Dictionary<string, string>> Rows = new List<Dictionary<string, string>>();
            Dictionary<string, string> CurrentRow;
            while (reader.Read())
            {
                CurrentRow = new Dictionary<string, string>();
                CurrentRow["PositionID"] = reader.GetInt32(0).ToString();
                CurrentRow["Title"] = reader.GetString(1);
                CurrentRow["Salary"] = reader.GetSqlMoney(2).ToString();
                CurrentRow["City"] = reader.GetString(3);
                CurrentRow["State"] = reader.GetString(4);
                Rows.Add(CurrentRow);
            }

            connection.Close();
            reader.Close();
            return Rows;
        }


        public static List<Dictionary<string, string>> SearchForProfilesWithTags(List<string> Tags)
        {
            List<Dictionary<string, string>> Companies = new List<Dictionary<string, string>>();
            SqlConnection Connection = GetSqlConnection();
            string sp_name = "search_profiles_by_tags";

            // Setting up the command
            SqlCommand Search = new SqlCommand(sp_name, Connection);
            Search.CommandType = System.Data.CommandType.StoredProcedure;

            // Setting up the table parameter
            SqlParameter TagsTableParameter =
                new SqlParameter("@Tags", System.Data.SqlDbType.Structured);
            TagsTableParameter.TypeName = "TagWordsTableType";
            TagsTableParameter.Value = Database.CreateTagsTable(Tags);

            // Adding the parameter to the command
            Search.Parameters.Add(TagsTableParameter);

            SqlDataReader Reader = Search.ExecuteReader();

            Dictionary<string, string> CurrentRow;
            while (Reader.Read())
            {
                CurrentRow = new Dictionary<string, string>();
                CurrentRow["ProfileID"] = Reader.GetInt32(0).ToString();
                CurrentRow["Name"] = Reader.GetString(1);
                CurrentRow["Username"] = Reader.GetString(2);
                Companies.Add(CurrentRow);
            }

            Connection.Close();
            Reader.Close();
            return Companies;
        }


        public static List<Dictionary<string, string>> SearchForCompaniesWithTags(List<string> Tags)
        {
            List<Dictionary<string, string>> Companies = new List<Dictionary<string, string>>();
            SqlConnection Connection = GetSqlConnection();
            string sp_name = "search_companies_by_tags";

            // Setting up the command
            SqlCommand Search = new SqlCommand(sp_name, Connection);
            Search.CommandType = System.Data.CommandType.StoredProcedure;

            // Setting up the table parameter
            SqlParameter TagsTableParameter =
                new SqlParameter("@Tags", System.Data.SqlDbType.Structured);
            TagsTableParameter.TypeName = "TagWordsTableType";
            TagsTableParameter.Value = Database.CreateTagsTable(Tags);

            // Adding the parameter to the command
            Search.Parameters.Add(TagsTableParameter);

            SqlDataReader Reader = Search.ExecuteReader();

            Dictionary<string, string> CurrentRow;
            while (Reader.Read())
            {
                CurrentRow = new Dictionary<string, string>();
                CurrentRow["CompanyID"] = Reader.GetInt32(0).ToString();
                CurrentRow["CompanyName"] = Reader.GetString(1);
                Companies.Add(CurrentRow);
            }

            Connection.Close();
            Reader.Close();
            return Companies;
        }


        /*
         * A general procedure for updating the company
         * table so I don't have to rewrite what is essentially
         * the same function 200 different times. Uses optional
         * parameters to avoid updating the entire row every time.
         */
        public static void UpdateCompany(
            int CompanyID, 
            string NewName=null, 
            int NewSize=-1,
            string NewDescription=null,
            string NewStreet=null,
            string NewCity=null,
            string NewState=null,
            string NewZip=null)
        {
            string sp_name = "update_company";
            SqlConnection connection = Database.GetSqlConnection();

            SqlCommand update = new SqlCommand(sp_name, connection);
            update.CommandType = System.Data.CommandType.StoredProcedure;

            // Adding parameters
            // This one is absolutely necessary
            update.Parameters.Add(
                new SqlParameter("@CompanyID", CompanyID));

            // A whole mess of optional parameters
            if (NewName != null)
            {
                update.Parameters.Add(
                    new SqlParameter("@NewCompanyName", NewName));
            }
            if (NewSize != -1)
            {
                update.Parameters.Add(
                    new SqlParameter("@NewSize", NewSize));
            }
            if (NewDescription != null)
            {
                update.Parameters.Add(
                    new SqlParameter("@NewDescription", NewDescription));
            }
            if (NewStreet != null)
            {
                update.Parameters.Add(
                    new SqlParameter("@NewStreet", NewStreet));
            }
            if (NewCity != null)
            {
                update.Parameters.Add(
                    new SqlParameter("@NewCity", NewCity));
            }
            if (NewState != null)
            {
                update.Parameters.Add(
                    new SqlParameter("@NewState", NewState));
            }
            if (NewZip != null)
            {
                update.Parameters.Add(
                    new SqlParameter("@NewZip", NewZip));
            }

            // Setting up the return value
            SqlParameter ReturnValue = new SqlParameter("RetVal", 
                System.Data.SqlDbType.Int);
            ReturnValue.Direction = 
                System.Data.ParameterDirection.ReturnValue;
            update.Parameters.Add(ReturnValue);

            // Executing the query
            update.ExecuteNonQuery();

            // I don't think I can check the ReturnValue
            // after closing the connection
            if ( (int)ReturnValue.Value == Database.NoSuchData )
            {
                connection.Close();
                throw new NoDataException();
            }

            connection.Close();
        }


        public static void DeleteProfile(int ProfileID)
        {
            string sp_name = "delete_profile";
            SqlConnection Connection = GetSqlConnection();

            SqlCommand delete_profile = new SqlCommand(
                sp_name, Connection);
            delete_profile.CommandType =
                System.Data.CommandType.StoredProcedure;
            delete_profile.Parameters.Add(
                new SqlParameter("@ProfileID", ProfileID));

            delete_profile.ExecuteNonQuery();

            Connection.Close();
        }


        public static void UpdateProfile(
            int ProfileID,
            string NewGender = null,
            string NewExperience = null,
            string NewStreet = null,
            string NewCity = null,
            string NewMajor = null,
            string NewState = null,
            string NewZipcode = null)
        {
            string sp_name = "update_profile";
            SqlConnection connection = Database.GetSqlConnection();

            SqlCommand update = new SqlCommand(sp_name, connection);
            update.CommandType = System.Data.CommandType.StoredProcedure;

            // Adding parameters
            // This one is absolutely necessary
            update.Parameters.Add(
                new SqlParameter("@ProfileID", ProfileID));
 //           update.Parameters.Add(
 //               new SqlParameter("@Name", Name));
            // A whole mess of optional parameters
            //           if (NewName != null)
            //           {
            //               update.Parameters.Add(
            //                   new SqlParameter("@NewName", NewName));
            //           }



            if (NewGender != null)
            {
                update.Parameters.Add(
                    new SqlParameter("@NewGender", NewGender));
            }
            if (NewExperience != null)
            {
                update.Parameters.Add(
                    new SqlParameter("@NewExperience", NewExperience));
            }
            if (NewStreet != null)
            {
                update.Parameters.Add(
                    new SqlParameter("@NewStreet", NewStreet));
            }
            if (NewCity != null)
            {
                update.Parameters.Add(
                    new SqlParameter("@NewCity", NewCity));
            }
            if (NewMajor != null)
            {
                update.Parameters.Add(
                    new SqlParameter("@NewMajor", NewMajor));
            }
            if (NewZipcode != null)
            {
                update.Parameters.Add(
                    new SqlParameter("@NewZipcode", NewZipcode));
            }

            SqlParameter ReturnValue = new SqlParameter("RetVal",
                System.Data.SqlDbType.Int);
            ReturnValue.Direction =
                System.Data.ParameterDirection.ReturnValue;
            update.Parameters.Add(ReturnValue);

            update.ExecuteNonQuery();

            if ((int)ReturnValue.Value == Database.NoSuchData)
            {
                connection.Close();
                throw new NoDataException();
            }

            connection.Close();
        }

       
        public static void DeleteCompany(int CompanyID)
        {
            string sp_name = "delete_company";
            SqlConnection Connection = GetSqlConnection();

            SqlCommand delete_company = new SqlCommand(
                sp_name, Connection);
            delete_company.CommandType =
                System.Data.CommandType.StoredProcedure;
            delete_company.Parameters.Add(
                new SqlParameter("@CompanyID", CompanyID));

            delete_company.ExecuteNonQuery();

            Connection.Close();
        }


        public static void InsertProfileTag(int ProfileID, string tag)
        {
            string sp_name = "insert_new_profile_tag";
            SqlConnection Connection = GetSqlConnection();

            SqlCommand insert_tag = new SqlCommand(
                sp_name, Connection);
            insert_tag.CommandType =
                System.Data.CommandType.StoredProcedure;

            insert_tag.Parameters.Add(
                new SqlParameter("@tagtext", tag));
            insert_tag.Parameters.Add(
                new SqlParameter("@ProfileID", ProfileID));

            SqlParameter ReturnParam = new SqlParameter();
            ReturnParam.Direction = ParameterDirection.ReturnValue;
            insert_tag.Parameters.Add(ReturnParam);

            insert_tag.ExecuteNonQuery();

            if ((int)ReturnParam.Value == Database.RepeatData)
            {
                Connection.Close();
                throw new RepeatDataException();
            }

            Connection.Close();
        }


        public static void InsertPositionTag(int PositionID, string tag)
        {
            string sp_name = "insert_new_position_tag";
            SqlConnection Connection = GetSqlConnection();

            SqlCommand insert_tag = new SqlCommand(
                sp_name, Connection);
            insert_tag.CommandType =
                System.Data.CommandType.StoredProcedure;

            insert_tag.Parameters.Add(
                new SqlParameter("@tagtext", tag));
            insert_tag.Parameters.Add(
                new SqlParameter("@posid", PositionID));

            SqlParameter ReturnParam = new SqlParameter();
            ReturnParam.Direction = ParameterDirection.ReturnValue;
            insert_tag.Parameters.Add(ReturnParam);

            insert_tag.ExecuteNonQuery();

            if ((int)ReturnParam.Value == Database.RepeatData)
            {
                Connection.Close();
                throw new RepeatDataException();
            }

            Connection.Close();
        }


        public static void InsertCompanyTag(int CompanyID, string tag)
        {
            string sp_name = "insert_new_company_tag";
            SqlConnection Connection = GetSqlConnection();

            SqlCommand insert_tag = new SqlCommand(
                sp_name, Connection);
            insert_tag.CommandType =
                System.Data.CommandType.StoredProcedure;

            insert_tag.Parameters.Add(
                new SqlParameter("@tagtext", tag));
            insert_tag.Parameters.Add(
                new SqlParameter("@CompanyID", CompanyID));

            SqlParameter ReturnParam = new SqlParameter();
            ReturnParam.Direction = ParameterDirection.ReturnValue;
            insert_tag.Parameters.Add(ReturnParam);

            insert_tag.ExecuteNonQuery();

            if ((int)ReturnParam.Value == Database.RepeatData)
            {
                Connection.Close();
                throw new RepeatDataException();
            }

            Connection.Close();
        }


        public static Dictionary<string, string> GetCompany(int CompanyID)
        {
            Dictionary<string, string> Company = new Dictionary<string, string>();

            string sp_name = "get_company";
            SqlConnection Connection = GetSqlConnection();

            SqlCommand get_company = new SqlCommand(
                sp_name, Connection);
            get_company.CommandType = System.Data.CommandType.StoredProcedure;
            get_company.Parameters.Add(
                new SqlParameter("@CompanyID", CompanyID));

            SqlDataReader reader = get_company.ExecuteReader();

            if (reader.Read())
            {
                Company["Name"] = reader.GetString(0);
                Company["Description"] = reader.GetString(1);
                Company["Size"] = reader.GetInt32(2).ToString();
                Company["Street"] = reader.GetString(3);
                Company["City"] = reader.GetString(4);
                Company["State"] = reader.GetString(5);
                Company["Zipcode"] = reader.GetString(6);
            }
            else
            {
                throw new NoDataException();
            }

            reader.Close();
            Connection.Close();
            return Company;
        }


        public static bool checkIfNameInDatabase(string name)
        {
            SqlConnection connection = GetSqlConnection();
            string sp_name = "checkif_name_in_database";
            SqlCommand get_user_sp = new SqlCommand(sp_name, connection);
            get_user_sp.CommandType = System.Data.CommandType.StoredProcedure;
            get_user_sp.Parameters.Add(new SqlParameter("@name", name));
            SqlDataReader reader = get_user_sp.ExecuteReader();
            bool contains_data = reader.HasRows;
            reader.Close();
            connection.Close();
            return contains_data;
        }


        public static bool checkIfUsernameInDatabase(string uname)
        {
            SqlConnection connection = GetSqlConnection();
            string sp_name = "checkif_username_in_database";
            SqlCommand get_user_sp = new SqlCommand(sp_name, connection);
            get_user_sp.CommandType = System.Data.CommandType.StoredProcedure;
            get_user_sp.Parameters.Add(new SqlParameter("@uname", uname));
            SqlDataReader reader = get_user_sp.ExecuteReader();
            bool contains_data = reader.HasRows;
            reader.Close();
            connection.Close();
            return contains_data;
        }


        public static bool checkIfUsernameInProfile(string uname)
        {
            SqlConnection connection = GetSqlConnection();
            string sp_name = "checkif_username_in_profile";
            SqlCommand get_user_sp = new SqlCommand(sp_name, connection);
            get_user_sp.CommandType = System.Data.CommandType.StoredProcedure;
            get_user_sp.Parameters.Add(new SqlParameter("@uname", uname));
            SqlDataReader reader = get_user_sp.ExecuteReader();
            bool contains_data = reader.HasRows;
            reader.Close();
            connection.Close();
            return contains_data;
        }


        public static void CreateUserProfile( string name, string gender,
            string major, string experience, string street,
            string city, string state, string zip, string username) 
        {
            string sp_name = "insert_new_user_profile";
            SqlConnection connection = GetSqlConnection();
            SqlCommand insert_profile_sp = new SqlCommand(sp_name, connection);
            insert_profile_sp.CommandType = System.Data.CommandType.StoredProcedure;

            insert_profile_sp.Parameters.Add(
                new SqlParameter("@name", name));
            insert_profile_sp.Parameters.Add(
                new SqlParameter("@gender", gender));
            insert_profile_sp.Parameters.Add(
                new SqlParameter("@major", major));
            insert_profile_sp.Parameters.Add(
                new SqlParameter("@experience", experience));
            insert_profile_sp.Parameters.Add(
                new SqlParameter("@street", street));
            insert_profile_sp.Parameters.Add(
                new SqlParameter("@city", city));
            insert_profile_sp.Parameters.Add(
                new SqlParameter("@state", state));
            insert_profile_sp.Parameters.Add(
                new SqlParameter("@zip", zip));
            insert_profile_sp.Parameters.Add(
                new SqlParameter("@uname", username));

            SqlParameter ReturnVal = new SqlParameter("RetVal", 
                System.Data.SqlDbType.Int);
            ReturnVal.Direction = 
                System.Data.ParameterDirection.ReturnValue;
            insert_profile_sp.Parameters.Add(ReturnVal);

            insert_profile_sp.ExecuteNonQuery();

            int ReturnValue = (int)ReturnVal.Value;
            if (ReturnValue == Database.ProfileAlreadyExistsError)
            {
                connection.Close();
                throw new ProfileAlreadyExistsException();
            }

            connection.Close();
        }       


        public static Dictionary<string, string> GetPosition(int PositionID)
        {
            SqlConnection connection = Database.GetSqlConnection();
            string sp_name = "get_position";

            SqlCommand get_position = new SqlCommand(
                sp_name, connection);
            get_position.CommandType = System.Data.CommandType.StoredProcedure;
            get_position.Parameters.Add(
                new SqlParameter("@posid", PositionID));

            SqlDataReader reader = get_position.ExecuteReader();

            Dictionary<string, string> Position = new Dictionary<string, string>();
            if (reader.Read())
            {
                Position["Title"] = reader.GetString(0);
                Position["Type"] = reader.GetString(1);
                Position["Salary"] = reader.GetSqlMoney(2).ToString();
                Position["Description"] = reader.GetString(3);
                Position["Street"] = reader.GetString(4);
                Position["City"] = reader.GetString(5);
                Position["State"] = reader.GetString(6);
                Position["Zipcode"] = reader.GetString(7);
            }
            else
            {
                throw new NoDataException();
            }

            reader.Close();
            connection.Close();
            return Position;
        }


        public static int CreateCompany(int UserID, int size, 
            string name, string description, string street,
            string city, string state, string zip)
        {
            string sp_name = "insert_new_company";
            SqlConnection connection = GetSqlConnection();
            SqlCommand insert_new_company_sp = new SqlCommand(sp_name, connection);
            insert_new_company_sp.CommandType = System.Data.CommandType.StoredProcedure;

            insert_new_company_sp.Parameters.Add(
                new SqlParameter("@UserID", UserID));
            insert_new_company_sp.Parameters.Add(
                new SqlParameter("@size", size));
            insert_new_company_sp.Parameters.Add(
                new SqlParameter("@name", name));
            insert_new_company_sp.Parameters.Add(
                new SqlParameter("@description", description));
            insert_new_company_sp.Parameters.Add(
                new SqlParameter("@street", street));
            insert_new_company_sp.Parameters.Add(
                new SqlParameter("@city", city));
            insert_new_company_sp.Parameters.Add(
                new SqlParameter("@state", state));
            insert_new_company_sp.Parameters.Add(
                new SqlParameter("@zip", zip));

            SqlParameter CompanyIDParam =
                new SqlParameter("@CompanyID", SqlDbType.Int);
            CompanyIDParam.Direction = ParameterDirection.Output;
            insert_new_company_sp.Parameters.Add(CompanyIDParam);

            SqlParameter ReturnParam = new SqlParameter("ReturnVal", SqlDbType.Int);
            ReturnParam.Direction = ParameterDirection.ReturnValue;
            insert_new_company_sp.Parameters.Add(ReturnParam);

            insert_new_company_sp.ExecuteNonQuery();

            if ((int)ReturnParam.Value == Database.RepeatCompanyNameError)
            {
                throw new RepeatCompanyNameException();
            }

            int CompanyID = (int)CompanyIDParam.Value;
            connection.Close();
            return CompanyID;
        }


        public static int GetUserID(string Username)
        {
            SqlConnection Connection = GetSqlConnection();
            string sp_name = "get_user_id";

            SqlCommand Command = new SqlCommand(sp_name, Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(
                new SqlParameter("@Username", Username));

            SqlDataReader Reader = Command.ExecuteReader();

            if (Reader.Read())
            {
                int UserID = Reader.GetInt32(0);
                Reader.Close();
                Connection.Close();
                return UserID;
            }

            Reader.Close();
            Connection.Close();
            throw new UsernameDoesntExistException();
        }


        public static void CreatePosition(int companyid, string pos, string ty, string stree, 
            string cit, string stat, string zi, string sal, string jobdesc)
        {
            string sp_name = "insert_new_position_gui";
            SqlConnection connection = GetSqlConnection();
            SqlCommand insert_new_pos_sp = new SqlCommand(sp_name, connection);
            insert_new_pos_sp.CommandType = System.Data.CommandType.StoredProcedure;

            insert_new_pos_sp.Parameters.Add(
               new SqlParameter("@companyid", companyid));
            insert_new_pos_sp.Parameters.Add(
                new SqlParameter("@positiontitle", pos));
            insert_new_pos_sp.Parameters.Add(
                new SqlParameter("@postype", ty));
            insert_new_pos_sp.Parameters.Add(
                new SqlParameter("@street", stree));
            insert_new_pos_sp.Parameters.Add(
                new SqlParameter("@city", cit));
            insert_new_pos_sp.Parameters.Add(
                new SqlParameter("@state", stat));
            insert_new_pos_sp.Parameters.Add(
                new SqlParameter("@zipcode", zi));
            insert_new_pos_sp.Parameters.Add(
                new SqlParameter("@salary", sal));
            insert_new_pos_sp.Parameters.Add(
                new SqlParameter("@description", jobdesc));

            SqlParameter ReturnVal = new SqlParameter("RetVal",
                System.Data.SqlDbType.Int);
            ReturnVal.Direction =
                System.Data.ParameterDirection.ReturnValue;
            insert_new_pos_sp.Parameters.Add(ReturnVal);

            insert_new_pos_sp.ExecuteNonQuery();

            int ReturnValue = (int)ReturnVal.Value;
            if (ReturnValue == Database.ProfileAlreadyExistsError)
            {
                connection.Close();
                throw new ProfileAlreadyExistsException();
            }

            connection.Close();
        }
        

        public static void deletePosition(string pos)
        {
            string sp_name = "delete_position";
            SqlConnection connection = GetSqlConnection();
            SqlCommand del = new SqlCommand(sp_name, connection);
            del.CommandType = System.Data.CommandType.StoredProcedure;

            del.Parameters.Add(
              new SqlParameter("@pos", pos));
            del.ExecuteNonQuery();
            connection.Close();
        }


        public static int getPosId(string oldpos)
        {
            string sp_name = "get_positionIdold";
            SqlConnection connection = GetSqlConnection();
            SqlCommand get_positionid = new SqlCommand(sp_name, connection);
            get_positionid.CommandType = System.Data.CommandType.StoredProcedure;
            int posid = 0;

            get_positionid.Parameters.Add(
              new SqlParameter("@oldpos", oldpos));

            posid = (int)get_positionid.ExecuteScalar();
            return (int)posid;
        }

        
        public static int getProfileID(string profName)
        {
            string sp_name = "get_profileID";
            SqlConnection connection = GetSqlConnection();
            SqlCommand getprofid = new SqlCommand(sp_name, connection);
            getprofid.CommandType = System.Data.CommandType.StoredProcedure;
            int posid = 0;

            getprofid.Parameters.Add(
              new SqlParameter("@oldpos", profName));

            var Result = getprofid.ExecuteScalar();
            if (Result == null)
            {
                throw new ProfileDoesntExistException();
            }

            posid = (int)Result;
            connection.Close();
            return (int)posid;
            
        }


        public static int getCompanyIdview(string oldpos)
        {
            string sp_name = "get_CompanyID";
            SqlConnection connection = GetSqlConnection();
            SqlCommand getcompid = new SqlCommand(sp_name, connection);
            getcompid.CommandType = System.Data.CommandType.StoredProcedure;
            int compid = 0;
            getcompid.Parameters.Add(
              new SqlParameter("@oldpos", oldpos));

            compid = (int)getcompid.ExecuteScalar();
            return (int)compid;
        }


        public static void UpdatePosition(int posid, int compid, 
            string pos, string ty, string stree, string cit, 
            string stat, string zi, string sal, string jobdesc)
        {
            string sp_name = "update_position";
            SqlConnection connection = GetSqlConnection();
            SqlCommand updatepos = new SqlCommand(sp_name, connection);
            updatepos.CommandType = System.Data.CommandType.StoredProcedure;

            updatepos.Parameters.Add(
              new SqlParameter("@positionid", posid));
            updatepos.Parameters.Add(
               new SqlParameter("@companyid", compid));
            updatepos.Parameters.Add(
               new SqlParameter("@positiontitle", pos));
            updatepos.Parameters.Add(
                new SqlParameter("@postype", ty));
            updatepos.Parameters.Add(
                new SqlParameter("@street", stree));
            updatepos.Parameters.Add(
                new SqlParameter("@city", cit));
            updatepos.Parameters.Add(
                new SqlParameter("@state", stat));
            updatepos.Parameters.Add(
                new SqlParameter("@zipcode", zi));
            updatepos.Parameters.Add(
                new SqlParameter("@salary", sal));
            updatepos.Parameters.Add(
                new SqlParameter("@description", jobdesc));

            SqlParameter ReturnVal = new SqlParameter("RetVal",
                System.Data.SqlDbType.Int);
            ReturnVal.Direction =
                System.Data.ParameterDirection.ReturnValue;
            updatepos.Parameters.Add(ReturnVal);

            updatepos.ExecuteNonQuery();

            int ReturnValue = (int)ReturnVal.Value;

            connection.Close();
        }


        // TODO I have not yet tested this
        // (nor the stored procedure it is based on)
        public static void ApplyToPosition(string Username, 
            int PositionID)
        {
            string sp_name = "apply_to_position";
            SqlConnection connection = GetSqlConnection();

            SqlCommand apply = 
                new SqlCommand(sp_name, connection);
            apply.CommandType = 
                System.Data.CommandType.StoredProcedure;

            apply.Parameters.Add(
                new SqlParameter("@username", Username));
            apply.Parameters.Add(
                new SqlParameter("@posid", PositionID));

            apply.ExecuteNonQuery();
            connection.Close();
        }


        public static void LikeProfile(int UserID, 
            int ProfileID)
        {
            string sp_name = "like_profile";
            SqlConnection connection = GetSqlConnection();

            SqlCommand like = 
                new SqlCommand(sp_name, connection);
            like.CommandType =
                System.Data.CommandType.StoredProcedure;

            like.Parameters.Add(
                new SqlParameter("@userid", UserID));
            like.Parameters.Add(
                new SqlParameter("@posid", ProfileID));

            like.ExecuteNonQuery();
            connection.Close();
        }


        public static List<int> GetAllUserIDs()
        {
            string sp_name = "get_all_userids";
            SqlConnection connection = GetSqlConnection();
            List<int> ids = new List<int>();

            SqlCommand get_all_ids = new SqlCommand(
                sp_name, connection);
            get_all_ids.CommandType =
                System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = get_all_ids.ExecuteReader();

            while (reader.Read())
                ids.Add(reader.GetInt32(0));

            reader.Close();
            connection.Close();
            return ids;
        }


        public static List<string> GetAllUsernamesFromUserTable()
        {
            string sp_name = "get_all_usernames_from_user_table";
            SqlConnection connection = GetSqlConnection();
            List<string> unames = new List<string>();

            SqlCommand get_all_usernames_from_user_table = new SqlCommand(sp_name, connection);
            get_all_usernames_from_user_table.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = get_all_usernames_from_user_table.ExecuteReader();
            //anything need to be added?-------------------------------------------------------------------------------------------------
            reader.Close();
            connection.Close();
            return unames;
        }


        public static int GetCompanyID(string name)
        {
            string sp_name = "get_inserted_companyid";
            SqlConnection connection = GetSqlConnection();
            int companyid = 0;

            SqlCommand get_companyid = new SqlCommand(
                sp_name, connection);
            get_companyid.CommandType =
                System.Data.CommandType.StoredProcedure;
            get_companyid.Parameters.Add(
                new SqlParameter("@name", name));                        
            companyid = (int)get_companyid.ExecuteScalar();
            return (int)companyid;
        }


        public static void CreateUserLikes(int UserID, int ProfileID)
        {
            string sp_name = "insert_new_like";
            SqlConnection connection = GetSqlConnection();

            SqlCommand insert_like = new SqlCommand(
                sp_name, connection);
            insert_like.CommandType =
                System.Data.CommandType.StoredProcedure;
            insert_like.Parameters.Add(
                new SqlParameter("@userid", UserID));
            insert_like.Parameters.Add(
                new SqlParameter("@profileid", ProfileID));

            // This is an absurd amount of code just to get 
            // a return value. Note that "RetVal" does NOT
            // need to be a parameter in the stored proc
            SqlParameter ReturnVal = new SqlParameter("RetVal", 
                System.Data.SqlDbType.Int);
            ReturnVal.Direction = 
                System.Data.ParameterDirection.ReturnValue;
            insert_like.Parameters.Add(ReturnVal);
            
            insert_like.ExecuteNonQuery();
            connection.Close();

            int ReturnValue = (int)ReturnVal.Value;
            if (ReturnValue != 0)
                throw new Exception("Problem in SQL code");
        }


        public static List<Dictionary<string, string>> GetUserCompanies(int UserID)
        {
            // Setting up the command
            SqlConnection Connection = GetSqlConnection();
            string sp_name = "get_user_companies";
            SqlCommand command = new SqlCommand(sp_name, Connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(
                new SqlParameter("@UserID", UserID));

            // Exectuing the command
            SqlDataReader Reader = command.ExecuteReader();

            // Getting the results
            Dictionary<string, string> Company;
            List<Dictionary<string, string>> Companies =
                new List<Dictionary<string, string>>();
            while (Reader.Read())
            {
                Company = new Dictionary<string, string>();
                Company["CompanyID"] = Reader.GetInt32(0).ToString();
                Company["CompanyName"] = Reader.GetString(1);
                Companies.Add(Company);
            }

            return Companies;
        }


        public static List<int> GetUserLikes( int user )
        {
            string sp_name = "get_user_likes";
            SqlConnection connection = GetSqlConnection();
            List<int> likes = new List<int>();

            SqlCommand get_likes = new SqlCommand(
                sp_name, connection);
            get_likes.CommandType =
                System.Data.CommandType.StoredProcedure;
            get_likes.Parameters.Add(
                new SqlParameter("@userid", user));

            SqlDataReader reader = get_likes.ExecuteReader();

            while (reader.Read())
                likes.Add(reader.GetInt32(0));

            reader.Close();
            connection.Close();
            return likes;
        }


        public static Dictionary<string, string> GetProfile(string Username)
        {
            SqlConnection connection = GetSqlConnection();
            string sp_name = "get_profile";

            SqlCommand get_profile = new SqlCommand(sp_name, connection);
            get_profile.CommandType =
                System.Data.CommandType.StoredProcedure;
            get_profile.Parameters.Add(
                new SqlParameter("@username", Username));

            SqlDataReader reader = get_profile.ExecuteReader();

            Dictionary<string, string> Profile = new Dictionary<string, string>();
            if (reader.Read())
            {
                Profile["Username"] = Username;
                Profile["Name"] = reader.GetString(1);
                Profile["Gender"] = reader.GetString(2);
                Profile["Major"] = reader.GetString(3);
                Profile["Experience"] = reader.GetString(4);
                Profile["Street"] = reader.GetString(5);
                Profile["City"] = reader.GetString(6);
                Profile["State"] = reader.GetString(7);
                Profile["Zipcode"] = reader.GetString(8);
            }
            else
            {
                throw new NoDataException();
            }

            return Profile;
        }


        // These really wouldnt be used in the actual product. 
        // Just for testing with batch inserts

        public static string GetRandomUsername()
        {
            SqlConnection connection = GetSqlConnection();
            string sp_name = "get_random_username";

            SqlCommand get_random_username =
                new SqlCommand(sp_name, connection);
            get_random_username.CommandType =
                System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = get_random_username.ExecuteReader();

            string username;
            if (reader.HasRows)
                username = reader.GetString(0);
            else
            {
                reader.Close();
                throw new Exception("No data in table.");
            }

            reader.Close();
            connection.Close();
            return username;
        }


        public static int GetRandomUserID()
        {
            string sp_name = "get_random_userid";
            SqlConnection connection = GetSqlConnection();

            SqlCommand get_random_userid =
                new SqlCommand(sp_name, connection);
            get_random_userid.CommandType = 
                System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = get_random_userid.ExecuteReader();

            int userid;
            if (reader.Read())
                userid = reader.GetInt32(0);
            else
            {
                reader.Close();
                throw new Exception("No data in table");
            }

            reader.Close();
            connection.Close();
            return userid;

        }


        public static int GetRandomPositionID()
        {
            SqlConnection connection = GetSqlConnection();
            string sp_name = "get_random_position_id";

            SqlCommand get_random_position_id =
                new SqlCommand(sp_name, connection);
            get_random_position_id.CommandType =
                System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = 
                get_random_position_id.ExecuteReader();

            int posid;
            if (reader.Read())
                posid = reader.GetInt32(0);
            else
            {
                reader.Close();
                throw new Exception("No data in table.");
            }

            reader.Close();
            connection.Close();
            return posid;
        }


        public static int GetRandomCompanyID()
        {
            SqlConnection connection = GetSqlConnection();
            string sp_name = "get_random_company_id";

            SqlCommand get_random_company_id =
                new SqlCommand(sp_name, connection);
            get_random_company_id.CommandType =
                System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = 
                get_random_company_id.ExecuteReader();

            int companyid;
            if (reader.Read())
                companyid = reader.GetInt32(0);
            else
            {
                reader.Close();
                throw new Exception("No data in table.");
            }

            reader.Close();
            connection.Close();
            return companyid; 
        }


        public static int GetRandomTagID()
        {
            SqlConnection Connection = GetSqlConnection();
            string sp_name = "get_random_tag_id";
            SqlCommand get_random = new SqlCommand(
                sp_name, Connection);
            get_random.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = get_random.ExecuteReader();

            if (reader.Read())
            {
                reader.Close();
                Connection.Close();
                return reader.GetInt32(0);
            }
            else
            {
                reader.Close();
                Connection.Close();
                throw new NoDataException("No Data in table");
            }


        }

        public static int GetRandomProfileID()
        {
            SqlConnection connection = GetSqlConnection();
            string sp_name = "get_random_profile_id";

            SqlCommand get_random_profile_id =
                new SqlCommand(sp_name, connection);
            get_random_profile_id.CommandType =
                System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = 
                get_random_profile_id.ExecuteReader();

            int profileid;
            if (reader.Read())
                profileid = reader.GetInt32(0);
            else
            {
                reader.Close();
                throw new Exception("No data in table.");
            }

            reader.Close();
            connection.Close();
            return profileid; 
        }


    }

    // Exceptions. They don't do anything specific, I just
    // Wanted to be able to distinguish between some
    // different kinds of issues
    public class RepeatEmailException : RepeatDataException 
    {
        public RepeatEmailException()
        {

        }

        public RepeatEmailException(string message) : base(message)
        {

        }
    }

    public class RepeatUsernameException : RepeatDataException 
    {
        public RepeatUsernameException()
        {

        }

        public RepeatUsernameException(string message) : base(message)
        {

        }

    }

    public class UsernameDoesntExistException : ApplicationException
    {
        public UsernameDoesntExistException() : base()
        {

        }

        public UsernameDoesntExistException(string message) : base(message)
        {

        }
    }

    public class ProfileAlreadyExistsException : RepeatDataException 
    {
        public ProfileAlreadyExistsException() : base()
        {

        }

        public ProfileAlreadyExistsException(string message) : base(message)
        {

        }
    }

    public class ProfileDoesntExistException : NoDataException
    {
        public ProfileDoesntExistException() : base()
        {

        }

        public ProfileDoesntExistException(string msg) : base(msg)
        {

        }
    }

    public class RepeatDataException : ApplicationException
    {
        public RepeatDataException() : base()
        {

        }

        public RepeatDataException(string msg) : base(msg)
        {

        }
    }

    public class NoDataException : ApplicationException
    {
        public NoDataException() : base()
        {

        }

        public NoDataException( string message ) : base(message)
        {

        }
    }

    public class RepeatCompanyNameException : RepeatDataException
    {
        public RepeatCompanyNameException() : base()
        {

        }

        public RepeatCompanyNameException(string msg) : base(msg)
        {

        }
    }

}

