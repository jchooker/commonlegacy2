using CommonLegacy.entities;
using CommonLegacy.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace CommonLegacy
{
    /// <summary>
    /// Summary description for DeleteUser
    /// </summary>
    public class DeleteUser : IHttpHandler
    {

        //private static string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            var json = new StreamReader(context.Request.InputStream).ReadToEnd();
            var userDel = JsonConvert.DeserializeObject<UserDel>(json);

            var userRepository = new UserRepository();
            userRepository.DeleteUser(userDel);

            context.Response.Write("Success");
    }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}