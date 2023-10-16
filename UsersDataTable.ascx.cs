using CommonLegacy.entities;
using CommonLegacy.Services;
using Dapper;
using System;
using System.Data;
using Newtonsoft.Json;
using System.Web.Services;
using System.Web.Script.Services;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Configuration;

namespace CommonLegacy
{
    public partial class UsersDataTable : System.Web.UI.UserControl
    {
        private static string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        //private IUserRepository iUserRepository;

        //public UsersDataTable(IUserRepository userRepository)
        //{
        //    iUserRepository = userRepository;
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                //var usersDataTable = (UsersDataTable)Page.FindControl("UsersDataTable");
                //var users = usersDataTable.iUserRepository.GetAllUsers();
                //var users = iUserRepository.GetAllUsers();
                //using (IDbConnection connection = ConnectionHelper.CreateConnection())
                //iUserRepository = new UserRepository();
                //string jsonData = GetAllUsers();
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "initDataTable", "setUpTable(" + jsonData + ");", true);
            //}
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        protected void Modify_Commit(string jsUser)
        {
            IUserRepository userRepository = Application["UserRepository"] as IUserRepository;
            UserMod userMod = JsonConvert.DeserializeObject<UserMod>(jsUser);
            userRepository?.ModifyUser(userMod); //<-should be equiv of statement below:
            //if (userRepository != null)
            //{
            //    userRepository.ModifyUser(userMod);
            //}
            //UserMod userMod = new UserMod()
            //{
            //    Id = userMod.Id,
            //    FirstName = userMod.FirstName,
            //    LastName = userMod.LastName,
            //    Email = userMod.Email,
            //    Gender = userMod.Gender,
            //    Age = userMod.Age,
            //    Country = userMod.Country
            //};
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        protected static IEnumerable<User> GetUsers()
        {
            IUserRepository userAccess = new UserRepository();
            return userAccess.GetAllUsers();
        }
    }
}