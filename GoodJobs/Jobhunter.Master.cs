using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jobhunt.Controllers;
using Jobhunt.Models;

namespace Jobhunt
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        //public UsersController _UsersController;
        //public User _User;

        protected void Page_Load(object sender, EventArgs e)
        {
            //_UsersController = new UsersController();
            //_User = new User();

            if (Session["UserId"] != null)
            {
                var UserId = Session["UserId"];
                var UserName = Session["UserName"];
                if (UserId != null)
                {
                    if (UserName != null)
                    {
                        lblWelcome.Text = "Welcome: " + Session["UserName"];
                    }
                }
            }
            else
            {

                this.panelUserManagement.Visible = false;
                this.panelUserManagement.Enabled = false;
                this.panelUserFunctionality.Visible = false;
                this.panelUserFunctionality.Enabled = false;
            }
        }

        protected void newJobApplication(object sender, EventArgs e)
        {
            HttpContext.Current.Session["Parameter"] = null;
            HttpContext.Current.Session["Viewtype"] = "new";

            Response.Redirect("JobApplications.aspx");
        }
    }
}