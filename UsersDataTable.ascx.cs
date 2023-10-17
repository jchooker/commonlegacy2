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
using System.Web.UI;

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
            if (!IsPostBack)
            {
                IUserRepository userRepository = new UserRepository();
                IEnumerable<User> users = userRepository.GetAllUsers();
                string usersJson = JsonConvert.SerializeObject(users);

                // Inject JavaScript code with the JSON data into the page
                string script = $"<script>var usersData = {usersJson};</script>";

                Control placeholder = FindControl("extra-js");
                placeholder?.Controls.Add(new LiteralControl(script));
                //string jsonData = GetUsers();
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "initDataTable", "setUpTable(" + jsonData + ");", true);
            }
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
        public void Modify_Commit(string jsUser)
        {
            IUserRepository userRepository = Application["UserRepository"] as IUserRepository;
            UserMod userMod = JsonConvert.DeserializeObject<UserMod>(jsUser);
            userRepository?.ModifyUser(userMod); //<-should be equiv of statement below:
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        protected string GetUsers()
        {
            IUserRepository userAccess = new UserRepository();
            IEnumerable<User> users = userAccess.GetAllUsers();
            string usersJson = JsonConvert.SerializeObject(users);
            return usersJson;
        }
    }
}