using CommonLegacy.entities;
using CommonLegacy.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using System.Data.SQLite;
using System.Configuration;
using System.Web.Script.Services;

namespace CommonLegacy.Services
{
    public class UserRepository : IUserRepository
    {
        private static string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet =true)]
        public IEnumerable<User> GetAllUsers()
        {
            using (IDbConnection dbConn = new SQLiteConnection(cs))
            {
                dbConn.Open();
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                IEnumerable<User> userList = dbConn.Query<User>("SELECT * FROM users").ToList();
                dbConn.Close();
                return userList;
            }
        }
        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public void ModifyUser(UserMod userMod) 
        {
            using (IDbConnection dbConn = new SQLiteConnection(cs))
            {
                dbConn.Open();
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                string sql = "UPDATE users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Gender = @Gender, Age = @Age, Country = @Country";
                dbConn.Execute(sql, userMod);
                dbConn.Close();
            }
        }
    }
}
