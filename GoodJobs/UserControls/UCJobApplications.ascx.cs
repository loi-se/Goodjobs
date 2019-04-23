using Jobhunt.Controllers;
using Jobhunt.Data;
using Jobhunt.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Jobhunt.UserControls
{

    public partial class UCJobApplications : System.Web.UI.UserControl
    {
        #region members
        public GridViewUtility _GridViewUtility;
        public JobApplicationsController _JobApplicationsController;
        public UsersController _UsersController;
        public Utility _Utility;
        public int _UserId { get; set; }
        public User _ChosenUser;
        #endregion

        //public List<JobApplications> searchJobApplications = new List<JobApplications>();
        private int pIndex = 1;
        private int nofPages = 0;
        #region events

        public UCJobApplications()
        {
            _GridViewUtility = new GridViewUtility();
            _JobApplicationsController = new JobApplicationsController();
            _UsersController = new UsersController();

        }
        public void Page_Load(object sender, EventArgs e)
        {
            _Utility = new Utility();
            bool calledFromContactsPage = false;
            if (this.Parent.Page.AppRelativeVirtualPath == "~/Dashboard.aspx")
            {
                _UserId = Convert.ToInt32(Session["UserId"]);
            }
            else if (this.Parent.Page.AppRelativeVirtualPath == "~/Contacts.aspx")
            {
                _UserId = Convert.ToInt32(Session["UserIdChoosenContact"]);            
                _ChosenUser = _UsersController.GetUser(_UserId);
                if (_ChosenUser != null)
                {
                    Label _label = this.Page.Master.FindControl("ContentPlaceHolderMain").FindControl("lJobApplSelContact") as Label;
                    _label.Text = "Job Applications of:" + " " + _Utility.Decrypt(_ChosenUser.FirstName) + " " + _Utility.Decrypt(_ChosenUser.LastName);
                }
                calledFromContactsPage = true;
            }
            lsearch.Text = "";

            #region ispostback
            if (!this.IsPostBack)
            {
                imgBPrevious.ImageUrl = "~/images/Previous.png";
                imgBPrevious.ToolTip = "Previous";
                imgBNext.ImageUrl = "~/images/Next.png";
                imgBNext.ToolTip = "Next";

                #region boundfields
                //0-Edit button
                ButtonField buttonField = new ButtonField();
                buttonField.HeaderText = "";
                buttonField.ItemStyle.VerticalAlign = VerticalAlign.Middle;
                DashBoardJobApplicationsGV.Columns.Add(buttonField);

                //1-Delete button
                buttonField = new ButtonField();
                buttonField.HeaderText = "";
                buttonField.ItemStyle.VerticalAlign = VerticalAlign.Middle;
                DashBoardJobApplicationsGV.Columns.Add(buttonField);

                //2- View button
                buttonField = new ButtonField();
                buttonField.HeaderText = "";
                buttonField.ItemStyle.VerticalAlign = VerticalAlign.Middle;
                DashBoardJobApplicationsGV.Columns.Add(buttonField);

                BoundField boundField = new BoundField();
                boundField.HeaderText = "";
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = 1;
                boundField.DataField = "JobApplID";
                DashBoardJobApplicationsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "";
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "JobApplNumber";
                DashBoardJobApplicationsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "Job application date";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "JobApplDateTime";
                DashBoardJobApplicationsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "Job application name";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "JobApplName";
                DashBoardJobApplicationsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "Job application method";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "JobApplMethod";
                DashBoardJobApplicationsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "Job application category";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "JobApplCat";
                DashBoardJobApplicationsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "Status";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "JobApplStatus";
                DashBoardJobApplicationsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "My rating";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "JobApplMyRating";
                DashBoardJobApplicationsGV.Columns.Add(boundField);

                // Vacancy:
                boundField = new BoundField();
                boundField.HeaderText = "Vacancy title";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "VacancyTitle";
                DashBoardJobApplicationsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "Function title";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "VacancyFunctionTitle";
                DashBoardJobApplicationsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "Vacancy link";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "VacancyLink";
                DashBoardJobApplicationsGV.Columns.Add(boundField);

                // Company:
                boundField = new BoundField();
                boundField.HeaderText = "Company";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "VacancyCompany";
                DashBoardJobApplicationsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "Company website";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "VacancyCompanyWebsite";
                DashBoardJobApplicationsGV.Columns.Add(boundField);

                #endregion boundfields

                fillddlCustomPagerItemSelected();
            }
            #endregion

            if (ViewState["GridPageIndex"] != null)
            {
                pIndex = Convert.ToInt32(ViewState["GridPageIndex"]);
            }

            pnlCustomPager.Visible = customPagerVisible();
            DashBoardJobApplicationsGV.BackColor = _GridViewUtility.GridViewCellBackColor;
            DashBoardJobApplicationsGV.BorderColor = _GridViewUtility.GridViewCellBorderColor;
            DashBoardJobApplicationsGV.RowDataBound += new GridViewRowEventHandler(DashBoardJobApplicationsGV_RowDataBound);

            if (Session["searchResultsJobAppl"] == null)
            {
                BViewAll.Visible = false;
            }
            else
            {
                BViewAll.Visible = true;
            }

            if (Session["searchResultsJobAppl"] != null)
            {
                lsearch.Text = "found job applications: " + Session["nofSearchResults"].ToString();
                lsearch.ForeColor = Color.Green;

                ShowJobApplicationTable(true, (List<JobApplications>)Session["searchResultsJobAppl"], pIndex, calledFromContactsPage);
            }
            else
            {
                ShowJobApplicationTable(false, null, pIndex, calledFromContactsPage);
            }
        }

        private void DashBoardJobApplicationsGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.Header)
            {

                e.Row.Cells[0].BorderWidth = 0;
                e.Row.Cells[0].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[1].BorderWidth = 0;
                e.Row.Cells[1].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[2].BorderWidth = 0;
                e.Row.Cells[2].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[3].BorderWidth = 0;
                e.Row.Cells[3].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[4].BorderWidth = 0;
                e.Row.Cells[4].BackColor = _GridViewUtility.HeaderBackColor;

                e.Row.Cells[5].BackColor = _GridViewUtility.HeaderBackColor;
                //e.Row.Cells[6].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[6].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[7].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[8].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[9].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[10].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[11].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[12].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[13].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[14].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[15].BackColor = _GridViewUtility.HeaderBackColor;
         
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TextBox txtbox;
                HyperLink hp;
                //hp =  new HyperLink();
                string navigateUrlStart = "";

                ImageButton btn_Edit = new ImageButton();
                btn_Edit.ID = "btn_Edit";
                btn_Edit.ToolTip = "Edit";
                // btn_Edit.Text = "Edit";
                btn_Edit.ImageUrl = "~/images/buttons/edit.png";
                //btn_Edit.

                btn_Edit.Click += new System.Web.UI.ImageClickEventHandler(btn_Edit_Click);
                btn_Edit.Width = 80;
                btn_Edit.Height = 25;

                if (this.Parent.Page.AppRelativeVirtualPath == "~/Contacts.aspx")
                {
                    btn_Edit.Enabled = false;
                    btn_Edit.Visible = false;
                    e.Row.Cells[0].BorderColor = _GridViewUtility.GridViewCellBackColor;
                }
                else
                {
                    e.Row.Cells[0].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                }
                e.Row.Cells[0].Controls.Add(btn_Edit);
                
                e.Row.Cells[0].BackColor = _GridViewUtility.GridViewCellBackColor;
                e.Row.Cells[0].VerticalAlign = VerticalAlign.Top;
                if (this.Parent.Page.AppRelativeVirtualPath == "~/Contacts.aspx")
                {
                    e.Row.Cells[0].CssClass = "contactsview";
                }

                    // e.Row.Cells[0].BorderColor = _GridViewUtility.GridViewCellBorderColor;

                    //var DeleteCell = e.Row.Cells[1];
                    //DeleteCell.Controls.Clear();
                    ImageButton btn_Delete = new ImageButton();
                btn_Delete.ID = "btn_Delete";
                btn_Delete.ToolTip = "Delete";
                btn_Delete.ImageUrl = "~/images/buttons/delete.png";
                btn_Delete.Width = 80;
                btn_Delete.Height = 25;
                //btn_Delete.Text = "Delete";
                btn_Delete.OnClientClick = "return confirm('Are you sure you want to delete this job application?')";
                btn_Delete.Click += new System.Web.UI.ImageClickEventHandler(btn_Delete_Click);

                if (this.Parent.Page.AppRelativeVirtualPath == "~/Contacts.aspx")
                {
                    btn_Delete.Enabled = false;
                    btn_Delete.Visible = false;
                    e.Row.Cells[1].BorderColor = _GridViewUtility.GridViewCellBackColor;
                    e.Row.Cells[1].CssClass = "contactsview";
                }
                else
                {
                    e.Row.Cells[1].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                }
                e.Row.Cells[1].Controls.Add(btn_Delete);
                      
                e.Row.Cells[1].BackColor = _GridViewUtility.GridViewCellBackColor;
                e.Row.Cells[1].VerticalAlign = VerticalAlign.Top;
               

                //var ViewCell = e.Row.Cells[2];
                //ViewCell.Controls.Clear();
                ImageButton btn_View = new ImageButton();
                btn_View.ToolTip = "View";
                btn_View.ID = "btn_View";
               // btn_View.PostBackUrl = "javascript:void(0);";

                //btn_View.CommandName = "View";
                btn_View.ImageUrl = "~/images/buttons/view.png";
                btn_View.Width = 25;
                btn_View.Height = 25;
                btn_View.CausesValidation = false;
                btn_View.EnableViewState = true;
                //btn_View.Text = "Open";
                btn_View.Click += new System.Web.UI.ImageClickEventHandler(this.btn_View_Click);
                e.Row.Cells[2].Controls.Add(btn_View);
                e.Row.Cells[2].BackColor = _GridViewUtility.GridViewCellBackColor;
                e.Row.Cells[2].VerticalAlign = VerticalAlign.Top;
                e.Row.Cells[2].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                if (this.Parent.Page.AppRelativeVirtualPath == "~/Contacts.aspx")
                {
                    //e.Row.Cells[2].BorderStyle = BorderStyle.None;
                    e.Row.Cells[2].CssClass = "contactsview";
                }

                    Label lbl = new Label();
                lbl.Text = (e.Row.DataItem as DataRowView).Row["JobApplID"].ToString();
                lbl.Visible = false;
                lbl.Width = 0;
                e.Row.Cells[3].BackColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[3].Controls.Add(lbl);
                e.Row.Cells[3].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                //e.Row.Cells[3].Visible = false;

                txtbox = _GridViewUtility.labelTextbox((e.Row.DataItem as DataRowView).Row["JobApplNumber"].ToString(), 50);
                e.Row.Cells[4].Controls.Add(txtbox);
                e.Row.Cells[4].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[4].BackColor = _GridViewUtility.GridViewCellBackColor;

                txtbox = _GridViewUtility.labelTextbox((e.Row.DataItem as DataRowView).Row["JobApplDateTime"].ToString(), 75);
                e.Row.Cells[5].Controls.Add(txtbox);
                e.Row.Cells[5].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[5].BackColor = _GridViewUtility.GridViewCellBackColor;

                //txtbox = _GridViewUtility.labelTextbox((e.Row.DataItem as DataRowView).Row["JobApplTime"].ToString(), 75);
                //e.Row.Cells[6].Controls.Add(txtbox);
                //e.Row.Cells[6].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                //e.Row.Cells[6].BackColor = _GridViewUtility.GridViewCellBackColor;

                txtbox = _GridViewUtility.labelTextbox((e.Row.DataItem as DataRowView).Row["JobApplName"].ToString(), 110);
                e.Row.Cells[6].Controls.Add(txtbox);
                e.Row.Cells[6].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[6].BackColor = _GridViewUtility.GridViewCellBackColor;

                txtbox = _GridViewUtility.labelTextbox((e.Row.DataItem as DataRowView).Row["JobApplMethod"].ToString(), 120);
                e.Row.Cells[7].Controls.Add(txtbox);
                e.Row.Cells[7].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[7].BackColor = _GridViewUtility.GridViewCellBackColor;

                txtbox = _GridViewUtility.labelTextbox((e.Row.DataItem as DataRowView).Row["JobApplCat"].ToString(), 120);
                e.Row.Cells[8].Controls.Add(txtbox);
                e.Row.Cells[8].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[8].BackColor = _GridViewUtility.GridViewCellBackColor;

                txtbox = _GridViewUtility.labelTextbox((e.Row.DataItem as DataRowView).Row["JobApplStatus"].ToString(), 150);
                e.Row.Cells[9].Controls.Add(txtbox);
                e.Row.Cells[9].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[9].BackColor = _GridViewUtility.GridViewCellBackColor;

                txtbox = _GridViewUtility.labelTextbox((e.Row.DataItem as DataRowView).Row["JobApplMyRating"].ToString(), 70);
                e.Row.Cells[10].Controls.Add(txtbox);
                e.Row.Cells[10].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[10].BackColor = _GridViewUtility.GridViewCellBackColor;

                txtbox = _GridViewUtility.labelTextbox((e.Row.DataItem as DataRowView).Row["VacancyTitle"].ToString(), 150);
                e.Row.Cells[11].Controls.Add(txtbox);
                e.Row.Cells[11].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[11].BackColor = _GridViewUtility.GridViewCellBackColor;

                txtbox = _GridViewUtility.labelTextbox((e.Row.DataItem as DataRowView).Row["VacancyFunctionTitle"].ToString(), 150);
                e.Row.Cells[12].Controls.Add(txtbox);
                e.Row.Cells[12].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[12].BackColor = _GridViewUtility.GridViewCellBackColor;

                hp = new HyperLink();
                hp.Text = (e.Row.DataItem as DataRowView).Row["VacancyLink"].ToString();
                navigateUrlStart = _GridViewUtility.checkNavigateUrlStart(hp.Text);
                hp.NavigateUrl = navigateUrlStart + (e.Row.DataItem as DataRowView).Row["VacancyLink"].ToString();
                hp.Width = 120;
                hp.ForeColor = System.Drawing.Color.FromArgb(int.Parse("#0099FF".Replace("#", ""),
                        System.Globalization.NumberStyles.AllowHexSpecifier));

                hp.Style.Add("style", "width:120px;word-wrap:break-word");
                hp.Font.Size = new FontUnit(9);
                hp.Target = "_blank";
                e.Row.Cells[13].Controls.Add(hp);
                e.Row.Cells[13].BackColor = _GridViewUtility.GridViewCellBackColor;
                e.Row.Cells[13].BorderColor = _GridViewUtility.GridViewCellBorderColor;

                txtbox = _GridViewUtility.labelTextbox((e.Row.DataItem as DataRowView).Row["VacancyCompany"].ToString(), 150);
                e.Row.Cells[14].Controls.Add(txtbox);
                e.Row.Cells[14].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[14].BackColor = _GridViewUtility.GridViewCellBackColor;

                hp = new HyperLink();
                hp.Text = (e.Row.DataItem as DataRowView).Row["VacancyCompanyWebsite"].ToString();
                navigateUrlStart = _GridViewUtility.checkNavigateUrlStart(hp.Text);
                hp.NavigateUrl = navigateUrlStart + (e.Row.DataItem as DataRowView).Row["VacancyCompanyWebsite"].ToString();
                hp.Width = 120;
                hp.ForeColor = System.Drawing.Color.FromArgb(int.Parse("#0099FF".Replace("#", ""),
                       System.Globalization.NumberStyles.AllowHexSpecifier));
                hp.Style.Add("style", "width:120px;word-wrap:break-word");
                hp.Font.Size = new FontUnit(9);
                hp.Target = "_blank";
                e.Row.Cells[15].Controls.Add(hp);
                e.Row.Cells[15].BackColor = _GridViewUtility.GridViewCellBackColor;
                e.Row.Cells[15].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[15].BackColor = _GridViewUtility.GridViewCellBackColor;
            }
        }

        protected void DashBoardJobApplicationsGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                //int JobApplID;
                //GridViewRow DashBoardJobApplicationsGVRow = (GridViewRow)(sender as Control).Parent.Parent;
                //JobApplID = Convert.ToInt32(DashBoardJobApplicationsGVRow.Cells[3].Text);
                //Session["Parameter"] = JobApplID;
                //Session["Viewtype"] = "view";
                //Response.Redirect("JobApplications.aspx");
            }
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            GridViewRow DashBoardJobApplicationsGVRow = (GridViewRow)(sender as Control).Parent.Parent;
            int JobApplID = Convert.ToInt32(DashBoardJobApplicationsGVRow.Cells[3].Text);
            Session["Parameter"] = JobApplID;
            Session["Viewtype"] = "edit";
            Response.Redirect("JobApplications.aspx");
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            int JobApplID;
            GridViewRow DashBoardJobApplicationsGVRow = (GridViewRow)(sender as Control).Parent.Parent;
            JobApplID = Convert.ToInt32(DashBoardJobApplicationsGVRow.Cells[3].Text);
            Session["Parameter"] = JobApplID;
            Session["Viewtype"] = "view";
            Response.Redirect("JobApplications.aspx");
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            GridViewRow DashBoardJobApplicationsGVRow = (GridViewRow)(sender as Control).Parent.Parent;
            int JobApplID = Convert.ToInt32(DashBoardJobApplicationsGVRow.Cells[3].Text); 

            _JobApplicationsController.DeleteJobApplications(JobApplID);
            Response.Redirect("Dashboard.aspx");
        }

        protected void ddlCustomPagerItemSelected(object sender, EventArgs e)
        {
            int selectedPage = Convert.ToInt32(ddlCustomPager.SelectedItem.Text.ToString());
            ViewState["GridPageIndex"] = selectedPage;
            pIndex = selectedPage;

            empthyWordCloudControl();
            customPagerShowJobApplicationTable(selectedPage);
        }

        protected void imgBPrevious_click(object sender, EventArgs e)
        {
            int currentPageIndex = Convert.ToInt32(ViewState["GridPageIndex"]);
            if (currentPageIndex == 0)
            {
                currentPageIndex++;
            }
            currentPageIndex--;
            ViewState["GridPageIndex"] = currentPageIndex;
            pIndex = currentPageIndex;
            ddlCustomPager.ClearSelection();
            ddlCustomPager.Items.FindByText(pIndex.ToString()).Selected = true;

            empthyWordCloudControl();

            customPagerShowJobApplicationTable(currentPageIndex);
        }

        protected void imgBNext_click(object sender, EventArgs e)
        {
            int currentPageIndex = Convert.ToInt32(ViewState["GridPageIndex"]);
            if (currentPageIndex == 0)
            {
                currentPageIndex++;
            }
            currentPageIndex++;

            ViewState["GridPageIndex"] = currentPageIndex;
            pIndex = currentPageIndex;

            ddlCustomPager.ClearSelection();
            ddlCustomPager.Items.FindByText(pIndex.ToString()).Selected = true;
            empthyWordCloudControl();

            customPagerShowJobApplicationTable(currentPageIndex);
        }


        protected void SearchMyJobApplications(object sender, EventArgs e)
        {
            string searchQuery = TSearch.Text.Trim();
            List<JobApplications> foundJobApplications = new List<JobApplications>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                Boolean found = false;
                foreach (JobApplications _JobApplicationItem in _JobApplicationsController.GetMyJobApplications(_UserId))
                {
                    found = false;
                    if (this.Parent.Page.AppRelativeVirtualPath == "~/Contacts.aspx")
                    {
                        string showToFriends = _JobApplicationItem.ShowToFriends;
                        if (showToFriends == "False")
                        {
                            continue;
                        }
                    }

                    if (_Utility.Decrypt(_JobApplicationItem.JobApplCompanyQuestions).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.JobApplFeedback).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_JobApplicationItem.JobApplFollowUpStatus.Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.JobApplInterviewNotes).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.JobApplInterviewPersons).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.JobApplInterviewPreperation).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.JobApplLetter).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.JobApplMethod).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.JobApplMyFollowUpEmails).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.JobApplMyQuestions).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.JobApplName).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.JobApplNote).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.JobApplSecInterviewPersons).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_JobApplicationItem.JobApplStatus.Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.JobApplThirdInterviewPersons).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.VacancyCareerField).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.VacancyCompany).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.VacancyCompanyCity).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.VacancyCompanyCountry).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.VacancyCompanyStreetName).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.VacancyCompanySummary).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.VacancyContactPerson).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.VacancyContactPersonEmail).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.VacancyFunctionTitle).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.VacancyText).Contains(searchQuery))
                    {
                        found = true;
                    }
                    else if (_Utility.Decrypt(_JobApplicationItem.VacancyTitle).Contains(searchQuery))
                    {
                        found = true;
                    }

                    if (found)
                    {
                        foundJobApplications.Add(_JobApplicationItem);
                    }
                }

                Session["searchResultsJobAppl"] = foundJobApplications;
                Session["searchQuery"] = searchQuery;
                Session["nofSearchResults"] = foundJobApplications.Count().ToString();
                transferToPage();
            }
            else
            {
                //LSearch.ForeColor = Color.Red;
                //LSearch.Text = "Please enter a search term of at least 4 characters";
            }
        }

        protected void ViewAllJobApplications(object sender, EventArgs e)
        {
            Session["searchResultsJobAppl"] = null;
            Session["searchQuery"] = null;
            Session["nofSearchResults"] = null;
            transferToPage();
        }

        #endregion

        #region methods

        public void transferToPage()
        {
            if (this.Parent.Page.AppRelativeVirtualPath == "~/Dashboard.aspx")
            {
                Server.Transfer("Dashboard.aspx");
            }
            else if (this.Parent.Page.AppRelativeVirtualPath == "~/Contacts.aspx")
            {
                Server.Transfer("Contacts.aspx");
            }
        }

        public void empthyWordCloudControl()
        {
            if (this.Parent.Page.AppRelativeVirtualPath == "~/Dashboard.aspx")
            {
                Literal wordCloud = this.Page.Master.FindControl("ContentPlaceHolderMain").FindControl("WordCloudText") as Literal;
                if (wordCloud != null)
                {
                    wordCloud.Text = "";
                }
           }

        }

        public void customPagerShowJobApplicationTable(int currentPagerIndex)
        {

            if (Session["searchResultsJobAppl"] != null)
            {
                ShowJobApplicationTable(true, (List<JobApplications>)Session["searchResultsJobAppl"], currentPagerIndex, false);
            }
            else
            {
                ShowJobApplicationTable(false, null, currentPagerIndex, false);
            }
        }

        public int customPagerNumberOfResults()
        {
            int foundJobApplications = 0;
            if (Session["searchResultsJobAppl"] != null)
            {

                List<JobApplications> searchQueryCount = (List<JobApplications>)Session["searchResultsJobAppl"];
                foundJobApplications = searchQueryCount.Count();
            }
            else
            {
                if (this.Parent.Page.AppRelativeVirtualPath == "~/Contacts.aspx")
                {
                    int publicJobApplications = 0;
                    List<JobApplications> _PublicJobApplications = _JobApplicationsController.GetMyJobApplications(_UserId).ToList();

                    foreach (JobApplications _JobApplicationItem in _PublicJobApplications)
                    {
                        string showToFriends = _JobApplicationItem.ShowToFriends;
                        if (showToFriends == "True")
                        {
                            publicJobApplications++;
                        }
                    }
                    foundJobApplications = publicJobApplications;
                }
                else
                {
                    foundJobApplications = _JobApplicationsController.GetMyJobApplications(_UserId).ToList().Count();
                }
                //}
            }
            return foundJobApplications;
        }

        public bool customPagerVisible()
        {
            bool visible = true;
            if (customPagerNumberOfResults() <= _GridViewUtility.jobApplpageSize)
            {
                visible = false;
            }
            return visible;
        }

        public void fillddlCustomPagerItemSelected()
        {
            ddlCustomPager.Items.Clear();
            int numberOfResults = customPagerNumberOfResults();
            int numberOfPages = (int)Math.Ceiling(Convert.ToDouble(customPagerNumberOfResults()) / Convert.ToDouble(_GridViewUtility.jobApplpageSize));

            for (int i = 1; i <= numberOfPages; i++)
            {
                ddlCustomPager.Items.Add(i.ToString());
            }
        }

        public List<GridViewRow> getGridViewRows()
        {
            List<GridViewRow> gridViewRows = new List<GridViewRow>();
            GridViewRowCollection gridViewRowsCol = this.DashBoardJobApplicationsGV.Rows;

            foreach (GridViewRow gridViewRow in gridViewRowsCol)
            {
                gridViewRows.Add(gridViewRow);
            }
            return gridViewRows;
        }

        public void ShowJobApplicationTable(Boolean search, List<JobApplications> searchJobApplications, int pageIndex, Boolean calledFromContacts)
        {
          
            if (calledFromContacts)
            {
                pnlCustomPager.Visible = customPagerVisible();
                this.fillddlCustomPagerItemSelected();
            }
            //pageIndex = pageIndex - 1;
            int pagerMinRange = 1;
            int pagerMaxRange = 1;
            if (pageIndex == 1)
            {
                pagerMinRange = 1;
                pagerMaxRange = pagerMinRange + (_GridViewUtility.jobApplpageSize - 1);
            }
            else if (pageIndex > 1)
            {
                pagerMinRange = (pageIndex -1 ) * _GridViewUtility.jobApplpageSize;
                pagerMaxRange = pagerMinRange + (_GridViewUtility.jobApplpageSize - 1);
            }
            //int pagerMinRange = pageIndex * _GridViewUtility.pageSize;
            //int pagerMaxRange = (pageIndex + 1) * _GridViewUtility.pageSize;
            int nofResults = customPagerNumberOfResults();
            int totalPages = Convert.ToInt32(Math.Ceiling((Convert.ToDouble(nofResults) / Convert.ToDouble(_GridViewUtility.jobApplpageSize))));

            lTotalPages.Text = totalPages.ToString() + ")";
            nofPages = totalPages;

            imgBPrevious.Visible = false;
            imgBNext.Visible = false;

            if (nofResults <= _GridViewUtility.jobApplpageSize)
            {
                imgBPrevious.Visible = false;
                imgBNext.Visible = false;
            }
            
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("JobApplID", typeof(Int32)));
                dt.Columns.Add(new DataColumn("JobApplNumber", typeof(Int32)));
                dt.Columns.Add(new DataColumn("JobApplDateTime", typeof(String)));
                dt.Columns.Add(new DataColumn("JobApplName", typeof(String)));
                dt.Columns.Add(new DataColumn("JobApplMethod", typeof(String)));
                dt.Columns.Add(new DataColumn("JobApplCat", typeof(String)));
                dt.Columns.Add(new DataColumn("JobApplStatus", typeof(String)));
                dt.Columns.Add(new DataColumn("JobApplMyRating", typeof(String)));
                dt.Columns.Add(new DataColumn("VacancyTitle", typeof(String)));
                dt.Columns.Add(new DataColumn("VacancyFunctionTitle", typeof(String)));
                dt.Columns.Add(new DataColumn("VacancyLink", typeof(String)));
                dt.Columns.Add(new DataColumn("VacancyCompany", typeof(String)));
                dt.Columns.Add(new DataColumn("VacancyCompanyWebsite", typeof(String)));


                List<JobApplications> foundJobApplications = new List<JobApplications>();

                if (!search && searchJobApplications == null)
                {
                    foundJobApplications = _JobApplicationsController.GetMyJobApplications(_UserId);
                }
                else if (search && searchJobApplications != null)
                {
                    foundJobApplications = searchJobApplications;
                }

                //DashBoardJobApplicationsGV.PageCount = foundJobApplications / page
                if (_JobApplicationsController.GetMyJobApplications(_UserId).Count > 0)
                {
                Psearch.Visible = true;

                if (pIndex != 1)
                {
                    imgBPrevious.Visible = true;
                }

                if (pIndex != nofPages)
                {
                    imgBNext.Visible = true;
                }

                DashBoardJobApplicationsGV.Visible = true;
                int counter = 1;
                int foundItems = 0;
                foreach (JobApplications _JobApplicationItem in foundJobApplications)
                {
                    DataRow dr = dt.NewRow();
                    Boolean showJobApplicationitem = true;

                    if (this.Parent.Page.AppRelativeVirtualPath == "~/Contacts.aspx")
                    {
                        string showToFriends = _JobApplicationItem.ShowToFriends;
                        if (showToFriends == "False")
                        {
                            continue;
                        }
                    }

                    if (counter >= pagerMinRange && counter <= pagerMaxRange)
                    {
                        dr["JobApplID"] = _JobApplicationItem.ID;
                        dr["JobApplNumber"] = counter.ToString();
                        //dr["JobApplDateTime"] = DateTime.ParseExact(_JobApplicationItem.JobApplDateTime.Value.ToShortDateString(), "dd-MM-yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat).ToString();

                        dr["JobApplDateTime"] = _JobApplicationItem.JobApplDateTime.ToString();
                        //dr["JobApplTime"] = _JobApplicationItem.JobApplTime;
                        dr["JobApplName"] = _Utility.Decrypt(_JobApplicationItem.JobApplName);
                        dr["JobApplMethod"] = _Utility.Decrypt(_JobApplicationItem.JobApplMethod);
                        dr["JobApplCat"] = _Utility.Decrypt(_JobApplicationItem.JobApplCat);

                        dr["JobApplMyRating"] = _JobApplicationItem.JobApplMyRating;

                        dr["JobApplStatus"] = _JobApplicationItem.JobApplStatus;

                        dr["VacancyTitle"] = _Utility.Decrypt(_JobApplicationItem.VacancyTitle);
                        dr["VacancyFunctionTitle"] = _Utility.Decrypt(_JobApplicationItem.VacancyFunctionTitle);
                        dr["VacancyLink"] = _Utility.Decrypt(_JobApplicationItem.VacancyLink);

                        dr["VacancyCompany"] = _Utility.Decrypt(_JobApplicationItem.VacancyCompany);
                        dr["VacancyCompanyWebsite"] = _Utility.Decrypt(_JobApplicationItem.VacancyCompanyWebsite);

                        foundItems = foundItems + 1;
                        dt.Rows.Add(dr);

                    }

                    counter = counter + 1;
                    if (foundItems == _GridViewUtility.jobApplpageSize)
                    {
                        break;
                    }
                }
                DashBoardJobApplicationsGV.DataSource = dt;
                DashBoardJobApplicationsGV.DataBind();
            }
            else
            {
                if (this.Parent.Page.AppRelativeVirtualPath == "~/Dashboard.aspx")
                {
                    lJobApplications.Text = "You have not yet registered a job application.";
                    lJobApplications.ForeColor = System.Drawing.Color.Green;
                }
                DashBoardJobApplicationsGV.Visible = false;

            }
        }
        #endregion
    }
}