using CommonLegacy.entities;
using CommonLegacy.Services;
using Newtonsoft.Json;
using System.ServiceModel.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace CommonLegacy
{
    [WebService(Namespace = "https://localhost:44391/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ModifyUser : System.Web.Services.WebService
    {
        [WebMethod]      
        [WebInvoke(Method = "POST")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public void Modify_Commit(UserMod jsUser)
        {
            //this is where UserMod comes into play - to modify
            IUserRepository userRepository = Application["UserRepository"] as IUserRepository;
            userRepository?.ModifyUser(jsUser); //<-should be equiv of statement below:
            //^^non-global version of this needed? Viewback, even?
        }
    }
}
