using Jobhunt.Controllers;
using Jobhunt.Models;
using Jobhunt.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jobhunt
{
    public partial class ContactsInvitations : System.Web.UI.Page
    {
        #region members
        public Careers _Careers;
        public GridViewUtility _GridViewUtility;
        public UsersController _UsersController;
        public User _User;
        private int _UserId;

        public int _UserIdChoosenContact { get;  set;}
        #endregion

        #region events
        protected void Page_Load(object sender, EventArgs e)
        {
            _UsersController = new UsersController();
            if (!this.IsPostBack)
            {
             //   Session["UserIdChoosenContact"] = null;
            }

            var UserId = Session["UserId"];
            _UserId = Convert.ToInt32(UserId);
            _User = _UsersController.GetUser(_UserId);

            if (Session["UserIdChoosenContact"] != null)
            {
                //UCJobApplications._UserId = Convert.ToInt32(Session["UserIdChoosenContact"]);
                //UCJobApplications._ViewType = "Contacts";
                //UCJobApplications.ShowJobApplicationTable();
                //UCJobApplications = LoadControl("~/UserControls/UCJobApplications.ascx") as UCJobApplications;
            }
        }

        #endregion

        #region methods
        #endregion

        #region fill methods

        #endregion
    }
}