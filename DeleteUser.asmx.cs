using CommonLegacy.entities;
using CommonLegacy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace CommonLegacy
{
    /// <summary>
    /// Summary description for DeleteUser
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DeleteUser : System.Web.Services.WebService
    {

        [WebMethod]
        //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]        
        [WebInvoke(Method = "DELETE")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public void Delete_Commit(UserDel userId)
        {
            //this is where UserMod comes into play - to modify
            IUserRepository userRepository = Application["UserRepository"] as IUserRepository;
            //UserMod userMod = JsonConvert.DeserializeObject<UserMod>(jsUser);
            //userRepository?.ModifyUser(userMod); //<-should be equiv of statement below:
            userRepository?.DeleteUser(userId.Id); //<-should be equiv of statement below:
        }
    }
}
