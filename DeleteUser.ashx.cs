using CommonLegacy.entities;
using CommonLegacy.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Metadata.Edm;
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
            bool delSuccess = userRepository.DeleteUser(userId);

            if (delSuccess)
            {
                var responseObj = new
                {
                    status = "Success",
                    message = "User deletion successful"
                };

                context.Response.Write(JsonConvert.SerializeObject(responseObj));
                //^^Works now bc I'm serializing the response? serialize coming and going?
            }
            else
            {
                var responseObj = new
                {
                    status = "Error",
                    message = "User deletion failed"
                };

                context.Response.Write(JsonConvert.SerializeObject(responseObj));
            }


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