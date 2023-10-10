using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommonLegacy
{
    public partial class UserManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Roles.IsUserInRole("Admin"))
            {
                HttpContext.Current.Response.Redirect("~/Error.aspx?message=" + Server.UrlEncode("Must be Admin"));
            }
        }
    }
}