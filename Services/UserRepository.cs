using CommonLegacy.entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using System.Data.SQLite;
using System.Configuration;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.ServiceModel.Web;

namespace CommonLegacy.Services
{
    public class UserRepository : IUserRepository
    {
        private static string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        [WebInvoke(Method = "GET")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public IEnumerable<User> GetAllUsers()
        {
            using (IDbConnection dbConn = new SQLiteConnection(cs))
            {
                dbConn.Open();
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                IEnumerable<User> userList = dbConn.Query<User>("SELECT * FROM users").ToList();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string jsonData = serializer.Serialize(userList);
                dbConn.Close();
                return userList;
            }
        }
        [System.Web.Services.WebMethod]
        [WebInvoke(Method = "POST")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public void ModifyUser(UserMod userMod) 
        {
            using (IDbConnection dbConn = new SQLiteConnection(cs))
            {
                dbConn.Open();
                //Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                string sql = "UPDATE users SET first_name = @FirstName, last_name = @LastName, email = @Email, gender = @Gender, age = @Age, country = @Country WHERE id = @Id";
                dbConn.Execute(sql, userMod);
                dbConn.Close();
            }
        }
        
        [System.Web.Services.WebMethod]
        [WebInvoke(Method = "DELETE")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public void DeleteUser(int userId) 
        {
            using (IDbConnection dbConn = new SQLiteConnection(cs))
            {
                dbConn.Open();
                //Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                string sql = "DELETE FROM users WHERE id = @Id";
                dbConn.Execute(sql, userId);
                dbConn.Close();
            }
        }
    }
}
