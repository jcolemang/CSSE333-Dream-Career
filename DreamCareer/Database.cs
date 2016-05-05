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
        
        public static RNGCryptoServiceProvider RNGCSP = 
            new RNGCryptoServiceProvider();
        public static SHA256 PasswordHasher = new System.Security.Cryptography.SHA256Managed();
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
            //throw new Exception("Replace the *'s below with your password. " +
            //    "I would strongly recommend NOT committing with your password " +
            //    "in there. Be sure this is uncommented before you commit.");

            string remote_db_string = 
                "Data Source=titan.csse.rose-hulman.edu;" +
                "Initial Catalog=DreamCareer;" +
                "Persist Security Info=True;" +
                "User ID=dreamcareer;" +
                "Password=csse333;";

            string local_db_string = 
                "Data Source=localhost;" +
                "Initial Catalog=DreamCareer;" +
                "Integrated Security=True;";

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = local_db_string;
            connection.Open();
            return connection;
        }

        public static void CreateUser( string Username, string Password, string Email )
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
            //insert_user.Parameters.Add(
            //new SqlParameter("@pass", Password));
            insert_user.Parameters.Add(
                new SqlParameter("@password", Password));
            insert_user.Parameters.Add(
                new SqlParameter("@salt", Salt));
            insert_user.Parameters.Add(
                new SqlParameter("@email", Email));

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

            // nothing to return
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


        public static DataTable CreateTagsTable(List<string> tags)
        {
            DataTable TagsTable = new DataTable();
            TagsTable.Columns.Add("TagWords", typeof(string));

            foreach (string tag in tags)
                TagsTable.Rows.Add(tag);

            return TagsTable;
        }


        public static List<Dictionary<string, string>> SearchForPositionsWithTags(List<string> Tags)
        {
            string sp_name = "search_by_tags";
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
                CurrentRow["Title"] = reader.GetString(0);
                CurrentRow["Type"] = reader.GetString(1);
                CurrentRow["Description"] = reader.GetString(2);
                CurrentRow["Salary"] = reader.GetSqlMoney(3).ToString();
                CurrentRow["PositionID"] = reader.GetInt32(4).ToString();
                Rows.Add(CurrentRow);
            }

            connection.Close();
            reader.Close();
            return Rows;
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
            insert_profile_sp.ExecuteNonQuery();
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


        public static void CreateCompany(int size, 
            string name, string description, string street,
            string city, string state, string zip)
        {
            string sp_name = "insert_new_company";
            SqlConnection connection = GetSqlConnection();
            SqlCommand insert_new_company_sp = new SqlCommand(sp_name, connection);
            insert_new_company_sp.CommandType = System.Data.CommandType.StoredProcedure;

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

            insert_new_company_sp.ExecuteNonQuery();
            connection.Close();
        }


        public static void CreatePosition(int companyid, string postype,
            string posloc, int salary)
        {
            string sp_name = "insert_new_position";
            SqlConnection connection = GetSqlConnection();
            SqlCommand insert_new_pos_sp = new SqlCommand(sp_name, connection);
            insert_new_pos_sp.CommandType = System.Data.CommandType.StoredProcedure;

            insert_new_pos_sp.Parameters.Add(
                new SqlParameter("@companyid", companyid));
            insert_new_pos_sp.Parameters.Add(
                new SqlParameter("@postype", postype));
            insert_new_pos_sp.Parameters.Add(
                new SqlParameter("@posloc", posloc));
            insert_new_pos_sp.Parameters.Add(
                new SqlParameter("@salary", salary));

            insert_new_pos_sp.ExecuteNonQuery();
            connection.Close();
        }

        public static void CreateTag(string TagWord, 
            int PositionID)
        {
            string sp_name = "insert_position_tag";
            SqlConnection connection = GetSqlConnection();
            SqlCommand insert_new_pos_sp = new SqlCommand(sp_name, connection);
            insert_new_pos_sp.CommandType = System.Data.CommandType.StoredProcedure;

            insert_new_pos_sp.Parameters.Add(
                new SqlParameter("@tagtext", TagWord));
            insert_new_pos_sp.Parameters.Add(
                new SqlParameter("@posid", PositionID));

            insert_new_pos_sp.ExecuteNonQuery();
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
            int InputError = -1;

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
                Profile["Name"] = reader.GetString(0);
                Profile["Gender"] = reader.GetString(1);
                Profile["Major"] = reader.GetString(2);
                Profile["Experience"] = reader.GetString(3);
            }
            else
            {
                throw new NoDataException();
            }

            return Profile;
        }


        // These really wont be used in the actual product. 
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
            if (reader.HasRows)
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

    public class RepeatEmailException : ApplicationException
    {
        public RepeatEmailException()
        {

        }

        public RepeatEmailException(string message) : base(message)
        {

        }
    }

    public class RepeatUsernameException : ApplicationException
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

    public class ProfileAlreadyExistsException : ApplicationException
    {
        public ProfileAlreadyExistsException() : base()
        {

        }

        public ProfileAlreadyExistsException(string message) : base(message)
        {

        }
    }

    public class NoDataException : ApplicationException
    {
        public NoDataException()
        {

        }

        public NoDataException( string message ) : base(message)
        {

        }
    }

}

