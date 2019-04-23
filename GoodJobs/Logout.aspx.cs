using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jobhunt.Controllers;
using Jobhunt.Models;
using System.Web.Security;

public partial class _Logout : System.Web.UI.Page
{
    #region members
    #endregion members

    #region events
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        FormsAuthentication.SignOut();
        Response.Redirect("Default.aspx");
    }
    #endregion events
}