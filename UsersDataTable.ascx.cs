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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string usersJson = GetUsers();

                // Inject JavaScript code with the JSON data into the page
                string script = $"var usersData = {usersJson};";

                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "initDataTable", script, true);
            }
        }
        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        //public void Modify_Commit(string jsUser)
        //{
        //    //this is where UserMod comes into play - to modify
        //    IUserRepository userRepository = Application["UserRepository"] as IUserRepository;
        //    UserMod userMod = JsonConvert.DeserializeObject<UserMod>(jsUser);
        //    userRepository?.ModifyUser(userMod); //<-should be equiv of statement below:
        //}

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