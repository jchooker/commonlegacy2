using CommonLegacy.entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommonLegacy
{
    public partial class UsersDataTable : System.Web.UI.UserControl
    {
        private static string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string jsonData = GetData();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "initDataTable", "setUpTable(" + jsonData + ");", true);
            }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet =true)]
        protected string GetData()
        {
            using (IDbConnection dbConnection = new SQLiteConnection(cs)) 
            {
                dbConnection.Open();
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                List<User> userList = dbConnection.Query<User>("SELECT * FROM users").ToList();

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string jsonData = serializer.Serialize(userList);

                dbConnection.Close();

                return jsonData;
            }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public User GetUserById(int userId = 1)
        {
            using (IDbConnection dbConnection = new SQLiteConnection(cs))
            {
                dbConnection.Open();
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                User testUser = dbConnection.QuerySingleOrDefault<User>("SELECT * FROM Users WHERE Id = @UserId", new { UserId = userId });
                dbConnection.Close();
                return testUser;
            }
        }        
        
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public User ModifyUser(int userId = 1)
        {
            using (IDbConnection dbConnection = new SQLiteConnection(cs))
            {
                //dbConnection.Open();
                //Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                //User testUser = dbConnection.QuerySingleOrDefault<User>("SELECT * FROM Users WHERE Id = @UserId", new { UserId = userId });
                //dbConnection.Close();
                //return testUser;
                return new User();
            }
        }
    }
}