using Jobhunt.Controllers;
using Jobhunt.Data;
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
    public partial class Contacts: System.Web.UI.Page
    {
        #region members
        public Careers _Careers;
        public GridViewUtility _GridViewUtility;
        public UsersController _UsersController;
        public Utility Utility;
        public User _User;
        private int _UserId;

        public int _UserIdChoosenContact { get;  set;}
        #endregion

        #region events
        protected void Page_Load(object sender, EventArgs e)
        {
            _UsersController = new UsersController();
            Utility = new Utility();

            string previousUrl = Request.UrlReferrer.ToString();

            if (!previousUrl.Contains("Contacts.aspx"))
            {
                Session["searchResultsJobAppl"] = null;
                Session["searchQuery"] = null;
                Session["nofSearchResults"] = null;
            }

            if (!this.IsPostBack)
            {
                if (!previousUrl.Contains("Contacts.aspx"))
                {
                    Session["UserIdChoosenContact"] = null;
                }
                //UCJobApplications.DataBind();
            }

            var UserId = Session["UserId"];
            _UserId = Convert.ToInt32(UserId);
            _User = _UsersController.GetUser(_UserId);

         
        }

        #endregion

        #region methods
        #endregion

        #region fill methods
        #endregion
    }
}