using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jobhunt.Controllers;
using Jobhunt.Models;
using Jobhunt.Data;

public partial class _Faq : System.Web.UI.Page
{
    #region members
    public UsersController _UsersController;
    public User _User;
    public Utility _Utility;

    #endregion members

    #region events
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    #endregion events
}