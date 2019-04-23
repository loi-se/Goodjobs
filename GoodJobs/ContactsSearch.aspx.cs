using Jobhunt.Controllers;
using Jobhunt.Data;
using Jobhunt.Models;
using Jobhunt.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jobhunt
{
    public partial class ContactsSearch: System.Web.UI.Page
    {
        #region members
        public Careers _Careers;
        public GridViewUtility _GridViewUtility;
        public UsersController _UserController;
        public JobApplicationsController _JobApplicationController;
        public Utility _Utility;
        public int UserId;
        #endregion

        #region events
        protected void Page_Load(object sender, EventArgs e)
        {
            _UserController = new UsersController();
            _JobApplicationController = new JobApplicationsController();
            _Utility = new Data.Utility();
            UserId = Convert.ToInt32(Session["UserId"]);

            if (!this.IsPostBack)
            {

            }
            FillddlMainCareerField();
            FillddlSubCareerField();
        }
        protected void SearchContacts(object sender, EventArgs e)
        {
            Search();
        }
        #endregion

        #region methods

        public void Search()
        {
            List<User> foundUsers = new List<User>();
            Session["searchResultsContacts"] = null;

            string searchTags = "";
            string companyName = "";
            string functionTitle = "";
            string mainCareer = "";
            string subCareer = "";

            Dictionary<string, string> searchValues = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(txtSearchTag.Text))
            {
                searchTags = txtSearchTag.Text.Trim();
                searchValues.Add("searchTags", searchTags);
            }
            if (!string.IsNullOrEmpty(txtCompanyName.Text))
            {
                companyName = txtCompanyName.Text.Trim();
                searchValues.Add("companyName", companyName);
            }
            if (!string.IsNullOrEmpty(txtFunctionTitle.Text))
            {
                functionTitle = txtFunctionTitle.Text.Trim();
                searchValues.Add("functionTitle", functionTitle);
            }
            if (!string.IsNullOrEmpty(ddlMainCareerField.SelectedItem.Text) && ddlMainCareerField.SelectedItem.Text != "select option")
            {
                mainCareer = ddlMainCareerField.SelectedItem.Value.Trim();
                searchValues.Add("mainCareer", mainCareer);
            }
            if (!string.IsNullOrEmpty(ddlSubCareerField.SelectedItem.Text) && ddlSubCareerField.SelectedItem.Text != "select option")
            {
                subCareer = ddlSubCareerField.SelectedItem.Text.Trim();
                searchValues.Add("subCareer", subCareer);
            }
            if (searchValues.Count > 0)
            {
                foundUsers = _UserController.searchUsers(searchValues);
                Session["searchResultsContacts"] = foundUsers;           
            }
            Server.Transfer("ContactsSearch.aspx");
        }

        #endregion

        #region fill methods
        private void FillddlMainCareerField()
        {
            _Careers = new Careers();
            ddlMainCareerField.Items.Add(new ListItem("select option", "0"));
            Dictionary<int, string> MainCareers = _Careers.GetMainCareers();
            foreach (KeyValuePair<int, string> entry in MainCareers)
            {
                ddlMainCareerField.Items.Add(new ListItem(entry.Value, entry.Key.ToString()));
            }
        }

        private void FillddlSubCareerField()
        {

            Dictionary<int, string> MainCareers = _Careers.GetMainCareers();
            ddlSubCareerField.Items.Add(new ListItem("select option", "0"));
            List<string> allSubCareers = new List<string>();

            foreach (KeyValuePair<int, string> entry in MainCareers)
            {
                List<string> subCareers = _Careers.GetSubCareers(entry.Key);
                foreach (string item in subCareers)
                {
                    allSubCareers.Add(item);
                }
            }

            allSubCareers.Sort();

            foreach (string item in allSubCareers)
            {
                ddlSubCareerField.Items.Add(item);
            }
        }

        #endregion
    }
}