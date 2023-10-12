using System;

namespace CommonLegacy
{
    public partial class UserManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Roles.IsUserInRole("Admin"))
            //{
            //    HttpContext.Current.Response.Redirect("~/Error.aspx?message=" + Server.UrlEncode("Must be Admin"));
            //} ^ENABLE SOON
        }
    }
}