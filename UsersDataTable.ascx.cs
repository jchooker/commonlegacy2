using CommonLegacy.entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommonLegacy
{
    public partial class UsersDataTable : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string jsonData = GetData();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "initDataTable", "setUpTable(" + jsonData + ");", true);
            }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet =true)]
        protected string GetData()
        {
            string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (IDbConnection dbConnection = new SQLiteConnection(cs)) 
            {
                List<User> userList = dbConnection.Query<User>("SELECT * FROM users").ToList();

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string jsonData = serializer.Serialize(userList);

                return jsonData;
            }
            //DataTables result = new DataTables();

            //string search = HttpContext.Current.Request.Params["search[value]"];
            //string draw = HttpContext.Current.Request.Params["draw"];
            //string order = HttpContext.Current.Request.Params["order[0][column]"];
            //string orderDir = HttpContext.Current.Request.Params["order[0][dir]"];
            //int startRec = Convert.ToInt32(HttpContext.Current.Request.Params["start"]);
            //int pageSize = Convert.ToInt32(HttpContext.Current.Request.Params["length"]);

            //List<User> users = new List<User>();

            //int totalRecords = users.Count;

            //int recFilter = users.Count;

            //result.draw = Convert.ToInt32(draw);
            //result.recordsTotal = totalRecords;
            //result.recordsFiltered = recFilter;
            //result.data = users;

            //return result;
            //return new object;
        }
    }
}