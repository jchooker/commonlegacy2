using CommonLegacy.entities;
using CommonLegacy.Services;
using System;
using Newtonsoft.Json;
using System.Web.Services;
using System.Web.Script.Services;
using System.Collections.Generic;
using System.Web.UI;
using System.ServiceModel.Web;

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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        protected string GetUsers()
        {
            IUserRepository userAccess = new UserRepository();
            IEnumerable<User> users = userAccess.GetAllUsers();
            string usersJson = JsonConvert.SerializeObject(users);
            return usersJson;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat=ResponseFormat.Json)]
        protected void AddUser(User user)
        {
            IUserRepository userRepository = Application["UserRepository"] as IUserRepository;
            //^^non-global version of this needed? Viewback, even?
            userRepository?.AddUser(user); //<-should be equiv of statement below:
        }
    }
}