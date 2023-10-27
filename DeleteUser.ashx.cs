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
            //context.Request.RequestType = "POST";

            //var json = new StreamReader(context.Request.InputStream).ReadToEnd();
            //var userDel = JsonConvert.DeserializeObject<UserDel>(json);
            //var userRepository = new UserRepository();
            //userRepository.DeleteUser(userDel);
            string jsonData;
            using (var reader = new StreamReader(context.Request.InputStream))
            {
                jsonData = reader.ReadToEnd();
            }

            var userDel = JsonConvert.DeserializeObject<UserDel>(jsonData);
            long id = (long)userDel.Id;
            int userId = (int)id;
            //int userId = userDel["userId"]["Id"];
            var userRepository = new UserRepository();
            userRepository.DeleteUser(userId);

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