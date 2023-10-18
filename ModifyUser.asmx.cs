using CommonLegacy.entities;
using CommonLegacy.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace CommonLegacy
{
    /// <summary>
    /// Summary description for ModifyUser
    /// </summary>
    [WebService(Namespace = "https://localhost:44391/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ModifyUser : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public void Modify_Commit(string jsUser)
        {
            //this is where UserMod comes into play - to modify
            IUserRepository userRepository = Application["UserRepository"] as IUserRepository;
            UserMod userMod = JsonConvert.DeserializeObject<UserMod>(jsUser);
            userRepository?.ModifyUser(userMod); //<-should be equiv of statement below:
        }
    }
}
