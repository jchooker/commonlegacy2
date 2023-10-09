using CommonLegacy.entities;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommonLegacy
{
    public partial class UsersDataTable : System.Web.UI.UserControl
    {
        //private const string DB_NAME = "users_db.db";
        string msg = string.Empty;
        private SqliteConnection _connection;
        public UsersDataTable()
        {
            
        }

        public List<User> GetUsers()
        {
            List<User> userList = new List<User>();
            //return new List<User>();

            try
            {
                _connection.Open();
            }
            catch (Exception ex)
            {
                msg = "An Error occurred: " + ex.Message;
                Console.WriteLine(msg); //need to beef up the handling of exceptions
            }
            finally
            {
                _connection.Close();
            }
            return userList;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            //using (var factory = new SQLiteFactory())
            //{
            //    var conn = factory.CreateConnection();
            //    conn.ConnectionString = "Data Source=con";
            //}


            //************************MAKE SURE ALL OF THIS IS HAPPENING IN PAGE LOAD???
            try
            {
                _connection = new SqliteConnection(connectionString);

            }
            catch (Exception ex)
            {
                try
                {
                    if (HttpContext.Current != null)
                    {
                        string errMsg = "An error occurred: " + ex.Message;
                        HttpContext.Current.Response.Redirect("~/Error.aspx?message=" + Server.UrlEncode(errMsg));
                    }
                }
                catch (Exception ex2)
                {
                    Console.WriteLine("Error during redirection: " + ex2.Message);
                }
            }
        }


        public void Open()
        {
            _connection.Open();
        }

        public void Close()
        {
            _connection.Close();
        }

        //protected void Page_Error(object sender, EventArgs e)
        //{
        //    Exception exception = Report.Load(HttpContext.Current.Server.GetLastError());
        //    HttpResponse.Redirect("~/error.aspx");
        //} ^^More sophisticated error handling later?

    }
}