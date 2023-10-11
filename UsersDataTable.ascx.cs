using CommonLegacy;
using CommonLegacy.entities;
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
using System.Data.Entity;
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

        public string ToJson(List<User> users)
        {
            string jsonData = JsonConvert.SerializeObject(users);
            return jsonData;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var usersData = SQLiteAccess.GetUsers();
                var jsonUsersData = ToJson(usersData);
                ScriptManager.RegisterStartupScript(this, GetType(), "SetUserData", $"var usersData = {jsonUsersData};", true);

                //string script = $"<script type='text/javascript'>usersData = {jsonUsersData};</script>";

            }
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