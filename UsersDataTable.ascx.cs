using CommonLegacy.entities;
using CommonLegacy.Services;
using Microsoft.Ajax.Utilities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.EnterpriseServices;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;

namespace CommonLegacy
{
    public partial class UsersDataTable : System.Web.UI.UserControl
    {
        //private const string DB_NAME = "users_db.db";
        private readonly UsersDbContext _dbContext;
        public UsersDataTable(UsersDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<List<User>> GetUsersAsync()
        {
            List<User> userList = await _dbContext.Users.ToListAsync();
            return userList;
        }

        public string ToJson(Task<List<User>> users)
        {
            string jsonData = JsonConvert.SerializeObject(users);
            return jsonData;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        //public void Open()
        //{
        //    _connection.Open();
        //}

        //public void Close()
        //{
        //    _connection.Close();
        //}

    }
}