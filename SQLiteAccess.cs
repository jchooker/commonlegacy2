
using CommonLegacy.entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.Linq;
using Newtonsoft.Json;

namespace CommonLegacy
{
    public class SQLiteAccess
    {
        public static List<User> GetUsers() 
        { 
            using(IDbConnection con=new SQLiteConnection(LoadConnectionString())) 
            {
                var res = con.Query<User>("SELECT * FROM users", new DynamicParameters());
                return res.ToList();
            } 
        }

        private static string LoadConnectionString(string id="con")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public string ToJson(List<User> users)
        {
            string jsonData = JsonConvert.SerializeObject(users);
            return jsonData;
        }
    }
}