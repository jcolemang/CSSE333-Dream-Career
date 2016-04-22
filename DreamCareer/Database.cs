using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;

namespace DreamCareer
{
    /*
     * Basically just a whole bunch of wrappers for
     * SQL stored procedures
     */
    public class Database
    {
        public static SqlConnection GetSqlConnection()
        {
            //throw new Exception("Replace the *'s below with your password. " +
            //    "I would strongly recommend NOT committing with your password " +
            //    "in there. Be sure this is uncommented before you commit.");
                

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                "Data Source=titan.csse.rose-hulman.edu;" +
                "Initial Catalog=DreamCareer;" +
                "Persist Security Info=True;" +
                "User ID=gibsonjc;" +
                "Password=************;";
            connection.Open();
            return connection;
        }

        public static void CreateUser( string Username, string Password, string Email )
        {
            SqlConnection connection = GetSqlConnection();

            string sp_name = "insert_new_user";
            SqlCommand insert_user_sp = new SqlCommand(sp_name, connection);
            insert_user_sp.CommandType = System.Data.CommandType.StoredProcedure;

            insert_user_sp.Parameters.Add(
                new SqlParameter("@Uname", Username));
            insert_user_sp.Parameters.Add(
                new SqlParameter("@pass", Password));
            insert_user_sp.Parameters.Add(
                new SqlParameter("@email", Email));

            insert_user_sp.ExecuteNonQuery();
            connection.Close();
        }

        public static bool IsAUser( string Username, string Password )
        {
            SqlConnection connection = GetSqlConnection();

            string sp_name = "get_user";
            SqlCommand get_user_sp = new SqlCommand(sp_name, connection);
            get_user_sp.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = get_user_sp.ExecuteReader();

            bool contains_data = reader.HasRows;
            reader.Close();
            return contains_data;
        }


        public static void CreateUserProfile( string name, string gender,
            string major, string address, string experience, int userid )
        {
            string sp_name = "insert_new_user_profile_id";
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
                new SqlParameter("@address", address));
            insert_profile_sp.Parameters.Add(
                new SqlParameter("@experience", experience));
            insert_profile_sp.Parameters.Add(
                new SqlParameter("@userid", userid));

            insert_profile_sp.ExecuteNonQuery();
            connection.Close();
        }

        public static void CreateUserProfile( string name, string gender,
            string major, string address, string experience, string username )
        {
            string sp_name = "insert_new_user_profile_username";
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
                new SqlParameter("@address", address));
            insert_profile_sp.Parameters.Add(
                new SqlParameter("@experience", experience));
            insert_profile_sp.Parameters.Add(
                new SqlParameter("@username", username));

            insert_profile_sp.ExecuteNonQuery();
            connection.Close();
        }


        public static void CreateCompany(string address, int size, 
            string name, string description)
        {
            string sp_name = "insert_new_company";
            SqlConnection connection = GetSqlConnection();
            SqlCommand insert_new_company_sp = new SqlCommand(sp_name, connection);
            insert_new_company_sp.CommandType = System.Data.CommandType.StoredProcedure;

            insert_new_company_sp.Parameters.Add(
                new SqlParameter("@address", address));
            insert_new_company_sp.Parameters.Add(
                new SqlParameter("@size", size));
            insert_new_company_sp.Parameters.Add(
                new SqlParameter("@name", name));
            insert_new_company_sp.Parameters.Add(
                new SqlParameter("@description", description));

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


        public static void ApplyToPosition(string Username, 
            int PositionID)
        {
            //TODO this
        }


        public static void LikeProfile(string Username, 
            int ProfileID)
        {
            //TODO this
        }


        public static void SearchByTag(string TagWord)
        {
            //TODO this
        }


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
            return username;
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
            if (reader.HasRows)
                posid = reader.GetInt32(0);
            else
            {
                reader.Close();
                throw new Exception("No data in table.");
            }

            reader.Close();
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
            if (reader.HasRows)
                profileid = reader.GetInt32(0);
            else
            {
                reader.Close();
                throw new Exception("No data in table.");
            }

            reader.Close();
            return profileid; 
        }


    }

}

