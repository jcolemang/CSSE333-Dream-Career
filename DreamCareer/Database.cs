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
            throw new Exception("Replace the *'s below with your password. " +
                "I would strongly recommend NOT committing with your password " +
                "in there. Be sure this is uncommented before you commit.");
                

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
        }



    }

}

