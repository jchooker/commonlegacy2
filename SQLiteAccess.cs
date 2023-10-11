
using CommonLegacy.entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.Linq;

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
    }
}