using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jobhunt.Controllers;
using Jobhunt.Models;
using System.Data;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.ComponentModel;
using iTextSharp.text.html.simpleparser;
using Jobhunt.Data;
using Jobhunt;
using System.Text;
using System.Web.Services;
using System.Collections;

public partial class _JobApplications : System.Web.UI.Page
    {
    #region members
    public JobApplicationsController _JobApplicationsController;
    public UsersController _UserController;
    public JobApplications _JobApplication;
    public Utility _Utility;
    public GridViewUtility _GridViewUtility;
    public User _User;

    public int _JobApplID = 0;
    public string _Viewtype;

    public int _UserId;
    #endregion members

    #region events
    protected void Page_Load(object sender, EventArgs e)
    {
        _JobApplicationsController = new JobApplicationsController();
        _Utility = new Utility();
        _GridViewUtility = new GridViewUtility();
        _UserController = new UsersController();
        _JobApplication = new JobApplications();
        fillJobApplTimeDDL();
        fillJobApplInterviewDDL();
        fillJobApplSecInterviewDLL();
        fillJobApplThirdInterviewDLL();

        Label _label = this.Master.FindControl("ContentPlaceHolderMain").FindControl("lHeader") as Label;

        ImageButton ImageButtonWord = new ImageButton();
        ImageButtonWord = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ImageButtonWord") as ImageButton;

        ImageButtonWord.ToolTip = "Export Job application to PDF";
        ImageButtonWord.ID = "btn_View";
        ImageButtonWord.ImageUrl = "~/images/pdficon.png";
        ImageButtonWord.Width = 40;
        ImageButtonWord.Height = 40;
        ImageButtonWord.Click += new ImageClickEventHandler(ImageButton_Word);


        //if (Request.QueryString["Parameter"] != null)
        //{
        //    if (!String.IsNullOrEmpty(Request.QueryString["Parameter"].ToString()))
        //    {
        //        _JobApplID = Convert.ToInt32(Request.QueryString["Parameter"].ToString());
        //    }
        //}

        //if (Request.QueryString["Viewtype"] != null)
        //{
        //    if (!String.IsNullOrEmpty(Request.QueryString["Viewtype"].ToString()))
        //    {
        //        _Viewtype = Request.QueryString["Viewtype"].ToString();

        //        if (_Viewtype == "edit")
        //        {
        //            _label.Text = "Edit your job application:";

        //        }
        //        else if (_Viewtype == "view")
        //        {
        //            _label.Text = "Job Application:";
        //        }
        //    }
        //}
        //else
        //{
        //    _Viewtype = "new";
        //    _label.Text = "Create a new Job application:";
        //}
        


        if (Session["Parameter"] != null)
        {
            
                _JobApplID = Convert.ToInt32(Session["Parameter"].ToString());
        }

        if (Session["Viewtype"] != null)
        {
                _Viewtype = Session["Viewtype"].ToString();

                if (_Viewtype == "edit")
                {
                    _label.Text = "Edit your job application:";

                }
                else if (_Viewtype == "view")
                {
                    _label.Text = "View job application (read only):";
                }
                else if (_Viewtype == "new")
                {
                _label.Text = "Create a new job application:";
                }
        }

        var UserId = Session["UserId"];
        if (UserId != null)
        {
            _UserId = Convert.ToInt32(UserId);
        }

        if (!Page.IsPostBack)
        {
            if (_JobApplID > 0 && (_Viewtype == "edit" || _Viewtype == "view"))
            {
                ShowJobApplication(_JobApplID, _Viewtype);
            }

            if (_Viewtype == "edit" || _Viewtype == "new")
            {

                AjaxControlToolkit.ComboBox ccCategory = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ccCategory") as AjaxControlToolkit.ComboBox;
                ccCategory.DataSource = _Utility.GetUserCategories(_UserId, false);
                ccCategory.DataTextField = "Key";
                ccCategory.DataValueField = "Value";
                ccCategory.DataBind();
            }

            if (_Viewtype == "new")
            {
                ImageButtonWord.Enabled = false;
                ImageButtonWord.Visible = false;
            }
        }
       
        //UTCreateUser();

    }

    protected void NewJobApplication(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

            TextBox _TextBox = new TextBox();
            DropDownList _DropDownList = new DropDownList();
            CheckBox _checkBox = new CheckBox();
         

            _JobApplication.UserUserId = _UserId;


            //--User
            //User _User = new User();
            //_User = _UserController.GetUser(_UserId);       
            //_JobApplication.User = _UserController.GetUser(_UserId);
            //_JobApplication.User
            _UserController.Dispose();
            //--


            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplName") as TextBox;
            _JobApplication.JobApplName = _Utility.Encrypt(_TextBox.Text);



            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplTimeHour") as DropDownList;
            string hour = _DropDownList.SelectedValue.ToString();
            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplTimeMinute") as DropDownList;
            string minute = _DropDownList.SelectedValue.ToString();
            _JobApplication.JobApplTime = hour + ":" + minute;


            //string[] JobApplDateValues = Request.Form["datepickerJobApplDate"].Split('-');
            // string[] JobApplDateValues = Request.Form["ContentPlaceHolderMain_datepickerJobApplDate"].Split('-');

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("datepickerJobApplDate") as TextBox;
            if (!String.IsNullOrWhiteSpace(_TextBox.Text))
            {
                string[] JobApplDateValues = _TextBox.Text.Split('-');
                // string JobApplDateValue = Request.Form["datepickerJobApplDate"];
                DateTime JobApplDateValue = DateTime.ParseExact((JobApplDateValues[2] + "-" + JobApplDateValues[1] + "-" + JobApplDateValues[0] + " " + _JobApplication.JobApplTime + ":" + "00"), "yyyy-MM-dd HH:mm:ss",
                                               System.Globalization.CultureInfo.InvariantCulture);
                _JobApplication.JobApplDateTime = JobApplDateValue;
            }
            else
            {

                _JobApplication.JobApplDateTime = null;
            }

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplMethod") as TextBox;
            _JobApplication.JobApplMethod = _Utility.Encrypt(_TextBox.Text);

            //1st interview

            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplInterviewTimeHour") as DropDownList;
            hour = _DropDownList.SelectedValue.ToString();
            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplInterviewTimeMinute") as DropDownList;
            minute = _DropDownList.SelectedValue.ToString();
            _JobApplication.JobApplInterviewTime = hour + ":" + minute;


            //string[] JobApplDateValues = Request.Form["datepickerJobApplDate"].Split('-');
            // string[] JobApplDateValues = Request.Form["ContentPlaceHolderMain_datepickerJobApplDate"].Split('-');

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("datepickerJobApplInterviewDate") as TextBox;
            if (!String.IsNullOrWhiteSpace(_TextBox.Text))
            {
                string[] JobApplInterviewDateValues = _TextBox.Text.Split('-');
                // string JobApplDateValue = Request.Form["datepickerJobApplDate"];
                DateTime JobApplInterviewDateValue = DateTime.ParseExact((JobApplInterviewDateValues[2] + "-" + JobApplInterviewDateValues[1] + "-" + JobApplInterviewDateValues[0] + " " + _JobApplication.JobApplInterviewTime + ":" + "00"), "yyyy-MM-dd HH:mm:ss",
                                               System.Globalization.CultureInfo.InvariantCulture);
                _JobApplication.JobApplInterviewDateTime = JobApplInterviewDateValue;
            }
            else
            {
                _JobApplication.JobApplInterviewDateTime = null;
            }

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplInterviewPersons") as TextBox;
            _TextBox.MaxLength = 4;
            _JobApplication.JobApplInterviewPersons = _Utility.Encrypt(_TextBox.Text);


            //2nd interview

            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplSecInterviewTimeHour") as DropDownList;
            hour = _DropDownList.SelectedValue.ToString();
            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplSecInterviewTimeMinute") as DropDownList;
            minute = _DropDownList.SelectedValue.ToString();
            _JobApplication.JobApplSecInterviewTime = hour + ":" + minute;


            //string[] JobApplDateValues = Request.Form["datepickerJobApplDate"].Split('-');
            // string[] JobApplDateValues = Request.Form["ContentPlaceHolderMain_datepickerJobApplDate"].Split('-');

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("datepickerJobApplSecInterviewDate") as TextBox;
            if (!String.IsNullOrWhiteSpace(_TextBox.Text))
            {
                string[] JobApplSecInterviewDateValues = _TextBox.Text.Split('-');
                // string JobApplDateValue = Request.Form["datepickerJobApplDate"];
                DateTime JobApplSecInterviewDateValue = DateTime.ParseExact((JobApplSecInterviewDateValues[2] + "-" + JobApplSecInterviewDateValues[1] + "-" + JobApplSecInterviewDateValues[0] + " " + _JobApplication.JobApplSecInterviewTime + ":" + "00"), "yyyy-MM-dd HH:mm:ss",
                                               System.Globalization.CultureInfo.InvariantCulture);
                _JobApplication.JobApplSecInterviewDateTime = JobApplSecInterviewDateValue;

            }
            else
            {
                _JobApplication.JobApplSecInterviewDateTime = null;
            }

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplSecInterviewPersons") as TextBox;
            _JobApplication.JobApplSecInterviewPersons = _Utility.Encrypt(_TextBox.Text);


            //Third interview:


            //2nd interview

            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplThirdInterviewTimeHour") as DropDownList;
            hour = _DropDownList.SelectedValue.ToString();
            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplThirdInterviewTimeMinute") as DropDownList;
            minute = _DropDownList.SelectedValue.ToString();
            _JobApplication.JobApplThirdInterviewTime = hour + ":" + minute;


            //string[] JobApplDateValues = Request.Form["datepickerJobApplDate"].Split('-');
            // string[] JobApplDateValues = Request.Form["ContentPlaceHolderMain_datepickerJobApplDate"].Split('-');

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("datepickerJobApplThirdInterviewDate") as TextBox;
            if (!String.IsNullOrWhiteSpace(_TextBox.Text))
            {
                string[] JobApplThirdInterviewDateValues = _TextBox.Text.Split('-');
                // string JobApplDateValue = Request.Form["datepickerJobApplDate"];
                DateTime JobApplThirdInterviewDateValue = DateTime.ParseExact((JobApplThirdInterviewDateValues[2] + "-" + JobApplThirdInterviewDateValues[1] + "-" + JobApplThirdInterviewDateValues[0] + " " + _JobApplication.JobApplThirdInterviewTime + ":" + "00"), "yyyy-MM-dd HH:mm:ss",
                                               System.Globalization.CultureInfo.InvariantCulture);
                _JobApplication.JobApplThirdInterviewDateTime = JobApplThirdInterviewDateValue;

            }
            else
            {
                _JobApplication.JobApplThirdInterviewDateTime = null;
            }

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplThirdInterviewPersons") as TextBox;
            _JobApplication.JobApplThirdInterviewPersons = _Utility.Encrypt(_TextBox.Text);


            // Interview preperation:
            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplInterviewPreperation") as TextBox;
            _JobApplication.JobApplInterviewPreperation = _Utility.Encrypt(_TextBox.Text);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplMyQuestions") as TextBox;
            _JobApplication.JobApplMyQuestions = _Utility.Encrypt(_TextBox.Text);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplCompanyQuestions") as TextBox;
            _JobApplication.JobApplCompanyQuestions = _Utility.Encrypt(_TextBox.Text);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtInterviewNotes") as TextBox;
            _JobApplication.JobApplInterviewNotes = _Utility.Encrypt(_TextBox.Text);


            //----------------
            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplLetter") as TextBox;
            _JobApplication.JobApplLetter = _Utility.Encrypt(_TextBox.Text);

            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlMyRating") as DropDownList;
            _JobApplication.JobApplMyRating = _DropDownList.SelectedItem.Text;


            //datepickerJobApplDate
            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyTitle") as TextBox;
            _JobApplication.VacancyTitle = _Utility.Encrypt(_TextBox.Text);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyFunctionTitle") as TextBox;
            _JobApplication.VacancyFunctionTitle = _Utility.Encrypt(_TextBox.Text);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyCareerField") as TextBox;
            _JobApplication.VacancyCareerField = _Utility.Encrypt(_TextBox.Text);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyText") as TextBox;
            _JobApplication.VacancyText = _Utility.Encrypt(_TextBox.Text);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyContactPerson") as TextBox;
            _JobApplication.VacancyContactPerson = _Utility.Encrypt(_TextBox.Text);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyContactPersonEmail") as TextBox;
            _JobApplication.VacancyContactPersonEmail = _Utility.Encrypt(_TextBox.Text);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyContactPersonLinkedIn") as TextBox;
            _JobApplication.VacancyContactPersonLinkedIn = _Utility.Encrypt(_TextBox.Text);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyLink") as TextBox;
            _JobApplication.VacancyLink = _Utility.Encrypt(_TextBox.Text);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancySalary") as TextBox;
            _JobApplication.VacancySalary = _Utility.Encrypt(_TextBox.Text);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyCompany") as TextBox;
            _JobApplication.VacancyCompany = _Utility.Encrypt(_TextBox.Text);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyCompanyCity") as TextBox;
            _JobApplication.VacancyCompanyCity = _Utility.Encrypt(_TextBox.Text);


            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyCompanyStreetName") as TextBox;
            _JobApplication.VacancyCompanyStreetName = _Utility.Encrypt(_TextBox.Text);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyCompanyStreetNumber") as TextBox;
            _JobApplication.VacancyCompanyStreetNumber = _Utility.Encrypt(_TextBox.Text);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyCompanyZipCode") as TextBox;
            _JobApplication.VacancyCompanyZipCode = _Utility.Encrypt(_TextBox.Text);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyCompanyCountry") as TextBox;
            _JobApplication.VacancyCompanyCountry = _Utility.Encrypt(_TextBox.Text);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyCompanySummary") as TextBox;
            _JobApplication.VacancyCompanySummary = _Utility.Encrypt(_TextBox.Text);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyCompanyWebsite") as TextBox;
            _JobApplication.VacancyCompanyWebsite = _Utility.Encrypt(_TextBox.Text);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplFeedback") as TextBox;
            _JobApplication.JobApplFeedback = _Utility.Encrypt(_TextBox.Text);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplMyFollowUpEmails") as TextBox;
            _JobApplication.JobApplMyFollowUpEmails = _Utility.Encrypt(_TextBox.Text);

            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("dropdownStatus") as DropDownList;
            _JobApplication.JobApplStatus = _DropDownList.SelectedItem.Text;

            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlFollowUpStatus") as DropDownList;
            _JobApplication.JobApplFollowUpStatus = _DropDownList.SelectedItem.Text;

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplNote") as TextBox;
            _JobApplication.JobApplNote = _Utility.Encrypt(_TextBox.Text);

             AjaxControlToolkit.ComboBox ccCategory = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ccCategory") as AjaxControlToolkit.ComboBox;
            _JobApplication.JobApplCat = _Utility.Encrypt(ccCategory.Text);

            _checkBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("chkBoxShowToFriends") as CheckBox;
            if (_checkBox.Checked == true)
            {
                _JobApplication.ShowToFriends = "True";
            }
            else if (_checkBox.Checked == false)
            {
                _JobApplication.ShowToFriends = "False";
            }

            if (_Viewtype == "new")
            {
                _JobApplicationsController.PostJobApplications(_JobApplication);                
                UpdateUserCategories(_UserId, ccCategory.Text);
                Response.Redirect("Dashboard.aspx");
            }
            else if (_Viewtype == "edit")
            {
                if (_JobApplID > 0)
                {
                    _JobApplication.ID = _JobApplID;
                    _JobApplicationsController.PutJobApplications(_JobApplID, _JobApplication);
                    UpdateUserCategories(_UserId, ccCategory.Text);
                    Response.Redirect("Dashboard.aspx");
                }
            }
        }
        //else
        //{
        //    Label _Label = this.Master.FindControl("ContentPlaceHolderMain").FindControl("labelCreateJobAppl") as Label;
        //    // _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplNote") as TextBox;
        //    _Label.Text = "Please fill in all required fields";
        //    _Label.ForeColor = System.Drawing.Color.Red;
        //}
    }

    protected void ImageButton_Word(object sender, EventArgs e)
    {

        List<JobApplications> jobApplicationList = new List<JobApplications>();
        JobApplications currentJobApplications = _JobApplicationsController.GetJobApplications(_JobApplID);
        if (currentJobApplications != null)
        {
            jobApplicationList.Add(currentJobApplications);
            DataTable dataTable = _Utility.ToDataTable(jobApplicationList);

            createPDF(dataTable, _Utility.Decrypt(currentJobApplications.JobApplName));
        }
    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {
        /* Your Code While Closing*/
        //HttpContext.Current.Session["Parameter"] = null;
        //HttpContext.Current.Session["Viewtype"] = null;
    }

    #endregion events

    #region methods
    //public SortedList GetUserCategories(int userId)
    //{
    //    _UserController = new UsersController();
    //    User loggedInUser = _UserController.GetUser(userId);

    //    SortedList userCategories = new SortedList();
    //    string userCats = "";
    //    string[] userAllCats = null;
    //    if (_Utility.Decrypt(loggedInUser.Categories) != null)
    //    {
    //        userCats = _Utility.Decrypt(loggedInUser.Categories);
    //        userAllCats = userCats.Split('`');

    //        foreach (string cat in userAllCats)
    //        {
    //            userCategories.Add(cat, cat);
    //        }
    //    }
    //    return userCategories;
    //}


    public void UpdateUserCategories(int userId, string catogery)
    {
        _UserController = new UsersController();
        _User = _UserController.GetUser(userId);
        string userCats = "";
        string[] userAllCats = null;
        bool alreadyAdded = false;

        if (!string.IsNullOrEmpty(catogery))
        {
            if (_Utility.Decrypt(_User.Categories) != null)
            {
                userCats = _Utility.Decrypt(_User.Categories);
                userAllCats = userCats.Split('`');

                foreach (string cat in userAllCats)
                {
                    if (cat == catogery)
                    {
                        alreadyAdded = true;
                        break;
                    }
                }
            }

            if (alreadyAdded == false)
            {
                if (String.IsNullOrEmpty(userCats))
                {
                    userCats = userCats + catogery;
                }
                else
                {
                    userCats = userCats + "`" + catogery;
                }
                _User.Categories = _Utility.Decrypt(userCats);
                _UserController.PutUser(_User.UserId, _User);
            }
        }

    }
    public void createPDF(DataTable dataTable, string fileName)
    {
        //Dummy data for Invoice (Bill).
        string companyName = "ASPSnippets";
        int orderNo = 2303;
        DataTable dt = new DataTable();
        dt = dataTable;

        try
        {


            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<table border = '0'>");
                    foreach (DataRow row in dt.Rows)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>");
                        foreach (DataColumn column in dt.Columns)
                        {

                            sb.Append("<tr>");
                            sb.Append("<td style=font-weight:bold>");
                            if (column.ColumnName == "JobApplID")
                            {
                                sb.Append("");
                            }
                            else if (column.ColumnName == "JobApplNumber")
                            {
                                sb.Append("ID:");
                            }
                            else if (column.ColumnName == "JobApplDateTime")
                            {
                                sb.Append("Job application date:");
                            }
                            else if (column.ColumnName == "JobApplTime")
                            {
                                sb.Append("Job application time:");
                            }
                            else if (column.ColumnName == "JobApplName")
                            {
                                sb.Append("Job application name:");
                            }
                            else if (column.ColumnName == "JobApplLetter")
                            {
                                sb.Append("Job application letter:");
                            }
                            else if (column.ColumnName == "JobApplMethod")
                            {
                                sb.Append("Job application method:");
                            }
                            else if (column.ColumnName == "JobApplInterviewDateTime")
                            {
                                sb.Append("Interview date:");
                            }
                            else if (column.ColumnName == "JobApplInterviewTime")
                            {
                                sb.Append("Interview time:");
                            }
                            else if (column.ColumnName == "JobApplInterviewPersons")
                            {
                                sb.Append("Interview persons:");
                            }
                            else if (column.ColumnName == "JobApplSecInterviewDateTime")
                            {
                                sb.Append("Second interview date:");
                            }
                            else if (column.ColumnName == "JobApplSecInterviewTime")
                            {
                                sb.Append("Second interview time:");
                            }
                            else if (column.ColumnName == "JobApplSecInterviewPersons")
                            {
                                sb.Append("Second interview persons:");
                            }
                            else if (column.ColumnName == "JobApplThirdInterviewDateTime")
                            {
                                sb.Append("Third interview date:");
                            }
                            else if (column.ColumnName == "JobApplThirdInterviewTime")
                            {
                                sb.Append("Third interview time:");
                            }
                            else if (column.ColumnName == "JobApplThirdInterviewPersons")
                            {
                                sb.Append("Third interview persons:");
                            }
                            else if (column.ColumnName == "JobApplInterviewPreperation")
                            {
                                sb.Append("Interview preperation:");
                            }
                            else if (column.ColumnName == "JobApplMyQuestions")
                            {
                                sb.Append("My interview questions:");
                            }
                            else if (column.ColumnName == "JobApplCompanyQuestions")
                            {
                                sb.Append("Company questions:");
                            }
                            else if (column.ColumnName == "JobApplInterviewNotes")
                            {
                                sb.Append("My Interview Notes:");
                            }
                            else if (column.ColumnName == "JobApplStatus")
                            {
                                sb.Append("Status:");
                            }
                            else if (column.ColumnName == "JobApplFeedback")
                            {
                                sb.Append("Company feedback/ follow-up:");
                            }
                            else if (column.ColumnName == "JobApplMyFollowUpEmails")
                            {
                                sb.Append("My follow-up e-mails:");
                            }
                            else if (column.ColumnName == "JobApplFollowUpStatus")
                            {
                                sb.Append("Follow-up status:");
                            }
                            else if (column.ColumnName == "JobApplNote")
                            {
                                sb.Append("Note:");
                            }
                            else if (column.ColumnName == "JobApplMyRating")
                            {
                                sb.Append("My rating:");
                            }
                            else if (column.ColumnName == "VacancyTitle")
                            {
                                sb.Append("Vacancy title:");
                            }
                            else if (column.ColumnName == "VacancyFunctionTitle")
                            {
                                sb.Append("Function title:");
                            }
                            else if (column.ColumnName == "VacancyCareerField")
                            {
                                sb.Append("Career field:");
                            }
                            else if (column.ColumnName == "VacancyText")
                            {
                                sb.Append("Vacancy text:");
                            }
                            else if (column.ColumnName == "VacancySalary")
                            {
                                sb.Append("Vacancy salary:");
                            }
                            else if (column.ColumnName == "VacancyLink")
                            {
                                sb.Append("Vacancy link:");
                            }
                            else if (column.ColumnName == "VacancyContactPerson")
                            {
                                sb.Append("Contact person:");
                            }
                            else if (column.ColumnName == "VacancyContactPersonEmail")
                            {
                                sb.Append("Contact person e-mail:");
                            }
                            else if (column.ColumnName == "VacancyContactPersonLinkedIn")
                            {
                                sb.Append("Contact person LinkedIn:");
                            }
                            else if (column.ColumnName == "VacancyCompany")
                            {
                                sb.Append("Company:");
                            }
                            else if (column.ColumnName == "VacancyCompanyWebsite")
                            {
                                sb.Append("Website:");
                            }
                            else if (column.ColumnName == "VacancyCompanyCity")
                            {
                                sb.Append("City:");
                            }
                            else if (column.ColumnName == "VacancyCompanyStreetName")
                            {
                                sb.Append("Streetname:");
                            }
                            else if (column.ColumnName == "VacancyCompanyStreetNumber")
                            {
                                sb.Append("Streetnumber:");
                            }
                            else if (column.ColumnName == "VacancyCompanyZipcode")
                            {
                                sb.Append("Zipcode:");
                            }
                            else if (column.ColumnName == "VacancyCompanyCountry")
                            {
                                sb.Append("Country:");
                            }
                            else if (column.ColumnName == "VacancyCompanySummary")
                            {
                                sb.Append("Summary:");
                            }

                            sb.Append("</td>");
                            sb.Append("</tr>");

                            sb.Append("<tr>");
                            sb.Append("<td>");
                            if (column.ColumnName != "JobApplID")
                            {
                                sb.Append(row[column]);
                            }
                            sb.Append("</td>");
                            sb.Append("</tr>");
                        }

                        sb.Append("</td>");
                        sb.Append("</tr>");

                        sb.Append("<tr>");
                        sb.Append("<td>");
                        sb.Append("</br>");
                        sb.Append("</br>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                    }
                    sb.Append("</table>");
                    //Export HTML String as PDF.
                    StringReader sr = new StringReader(sb.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 20f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=" + fileName + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
        catch (Exception ex)
        {
        }
    }


    private void ShowJobApplication(int JobApplID, string Viewtype)
    {
        _JobApplication = _JobApplicationsController.GetJobApplications(JobApplID);

        TextBox _TextBox = new TextBox();
        DropDownList _DropDownList = new DropDownList();
        CheckBox _checkBox = new CheckBox();
        HyperLink hp = new HyperLink();

        if (_JobApplication != null)
        {
           
            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplName") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.JobApplName);
            _TextBox.Enabled = setControl(_TextBox);

            string[] time = _JobApplication.JobApplTime.Split(':');
            string hour = time[0];
            string minute = time[1];

            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplTimeHour") as DropDownList;
            _DropDownList.Text = hour;
            _DropDownList.Enabled = setControl(_DropDownList);
            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplTimeMinute") as DropDownList;
            _DropDownList.Text = minute;
            _DropDownList.Enabled = setControl(_DropDownList);


            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplLetter") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.JobApplLetter);
            _TextBox.Enabled = setControl(_TextBox);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplMethod") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.JobApplMethod);
            _TextBox.Enabled = setControl(_TextBox);


            //string[] JobApplDateValues = Request.Form["datepickerJobApplDate"].Split('-');
            //DateTime JobApplDateValue = new DateTime(Int32.Parse(JobApplDateValues[2]), Int32.Parse(JobApplDateValues[1]), Int32.Parse(JobApplDateValues[0]));
            //_JobApplication.JobApplDateTime = JobApplDateValue;
            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("datepickerJobApplDate") as TextBox;
            _TextBox.Enabled = setControl(_TextBox);
            if (_JobApplication.JobApplDateTime != null)
            {
                _TextBox.Text = _JobApplication.JobApplDateTime.Value.Date.ToString("dd-MM-yyyy");
             
            }

            //1st interview
            time = _JobApplication.JobApplInterviewTime.Split(':');
            hour = time[0];
            minute = time[1];

            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplInterviewTimeHour") as DropDownList;
            _DropDownList.Text = hour;
            _DropDownList.Enabled = setControl(_DropDownList);
            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplInterviewTimeMinute") as DropDownList;
            _DropDownList.Text = minute;
            _DropDownList.Enabled = setControl(_DropDownList);
        
            //string[] JobApplDateValues = Request.Form["datepickerJobApplDate"].Split('-');
            //DateTime JobApplDateValue = new DateTime(Int32.Parse(JobApplDateValues[2]), Int32.Parse(JobApplDateValues[1]), Int32.Parse(JobApplDateValues[0]));
            //_JobApplication.JobApplDateTime = JobApplDateValue;
            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("datepickerJobApplInterviewDate") as TextBox;
            _TextBox.Enabled = setControl(_TextBox);
            if (_JobApplication.JobApplInterviewDateTime != null)
            {
                _TextBox.Text = _JobApplication.JobApplInterviewDateTime.Value.Date.ToString("dd-MM-yyyy");
               
            }

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplInterviewPersons") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.JobApplInterviewPersons);
            _TextBox.Enabled = setControl(_TextBox);


            //2nd interview
            time = _JobApplication.JobApplSecInterviewTime.Split(':');
            hour = time[0];
            minute = time[1];

            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplSecInterviewTimeHour") as DropDownList;
            _DropDownList.Text = hour;
            _DropDownList.Enabled = setControl(_DropDownList);
            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplSecInterviewTimeMinute") as DropDownList;
            _DropDownList.Text = minute;
            _DropDownList.Enabled = setControl(_DropDownList);

            //string[] JobApplDateValues = Request.Form["datepickerJobApplDate"].Split('-');
            //DateTime JobApplDateValue = new DateTime(Int32.Parse(JobApplDateValues[2]), Int32.Parse(JobApplDateValues[1]), Int32.Parse(JobApplDateValues[0]));
            //_JobApplication.JobApplDateTime = JobApplDateValue;
            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("datepickerJobApplSecInterviewDate") as TextBox;
            _TextBox.Enabled = setControl(_TextBox);
            if (_JobApplication.JobApplSecInterviewDateTime != null)
            {
                _TextBox.Text = _JobApplication.JobApplSecInterviewDateTime.Value.Date.ToString("dd-MM-yyyy");             
            }

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplSecInterviewPersons") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.JobApplSecInterviewPersons);
            _TextBox.Enabled = setControl(_TextBox);



            //Third interview
            time = _JobApplication.JobApplThirdInterviewTime.Split(':');
            hour = time[0];
            minute = time[1];

            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplThirdInterviewTimeHour") as DropDownList;
            _DropDownList.Text = hour;
            _DropDownList.Enabled = setControl(_DropDownList);
            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplThirdInterviewTimeMinute") as DropDownList;
            _DropDownList.Text = minute;
            _DropDownList.Enabled = setControl(_DropDownList);
            //string[] JobApplDateValues = Request.Form["datepickerJobApplDate"].Split('-');
            //DateTime JobApplDateValue = new DateTime(Int32.Parse(JobApplDateValues[2]), Int32.Parse(JobApplDateValues[1]), Int32.Parse(JobApplDateValues[0]));
            //_JobApplication.JobApplDateTime = JobApplDateValue;
            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("datepickerJobApplThirdInterviewDate") as TextBox;
            _TextBox.Enabled = setControl(_TextBox);
            if (_JobApplication.JobApplThirdInterviewDateTime != null)
            {
                _TextBox.Text = _JobApplication.JobApplThirdInterviewDateTime.Value.Date.ToString("dd-MM-yyyy");              
            }

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplThirdInterviewPersons") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.JobApplThirdInterviewPersons);
            _TextBox.Enabled = setControl(_TextBox);
            //Interview preperation:

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplInterviewPreperation") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.JobApplInterviewPreperation);
            _TextBox.Enabled = setControl(_TextBox);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplMyQuestions") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.JobApplMyQuestions);
            _TextBox.Enabled = setControl(_TextBox);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplCompanyQuestions") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.JobApplCompanyQuestions);
            _TextBox.Enabled = setControl(_TextBox);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtInterviewNotes") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.JobApplInterviewNotes);
            _TextBox.Enabled = setControl(_TextBox);


            //rating:
            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlMyRating") as DropDownList;
            _DropDownList.Items.FindByText(_JobApplication.JobApplMyRating).Selected = true;
            _DropDownList.Enabled = setControl(_DropDownList);


            //datepickerJobApplDate
            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyTitle") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.VacancyTitle);
            _TextBox.Enabled = setControl(_TextBox);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyFunctionTitle") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.VacancyFunctionTitle);
            _TextBox.Enabled = setControl(_TextBox);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyCareerField") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.VacancyCareerField);
            _TextBox.Enabled = setControl(_TextBox);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyText") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.VacancyText);
            _TextBox.Enabled = setControl(_TextBox);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyContactPerson") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.VacancyContactPerson);
            _TextBox.Enabled = setControl(_TextBox);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyContactPersonEmail") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.VacancyContactPersonEmail);
            _TextBox.Enabled = setControl(_TextBox);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyContactPersonLinkedIn") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.VacancyContactPersonLinkedIn);
            _TextBox.Enabled = setControl(_TextBox);
            if (_Viewtype == "view")
            {
                _TextBox.Visible = false;
                hp = this.Master.FindControl("ContentPlaceHolderMain").FindControl("hlVacancyContactPersonLinkedIn") as HyperLink;
                hp.Text = _Utility.Decrypt(_JobApplication.VacancyContactPersonLinkedIn);
                string navigateUrlStart = _GridViewUtility.checkNavigateUrlStart(hp.Text);
                hp.NavigateUrl = navigateUrlStart + hp.Text;
                //hp.Width = 400;
                //hp.Style.Add("style", "word-wrap:break-word");
                hp.Enabled = setControl(hp);
                //hp.Style.Add("style", "text-align:left;");
                //hp.Font.Size = new FontUnit(9);
                hp.Target = "_blank";
            }




            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyLink") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.VacancyLink);
            _TextBox.Enabled = setControl(_TextBox);

            if (_Viewtype == "view")
            {
                _TextBox.Visible = false;
                hp = this.Master.FindControl("ContentPlaceHolderMain").FindControl("hlVacancyLink") as HyperLink;
                hp.Text = _Utility.Decrypt(_JobApplication.VacancyLink);
                string navigateUrlStart = _GridViewUtility.checkNavigateUrlStart(hp.Text);
                hp.NavigateUrl = navigateUrlStart + hp.Text;
                //hp.Width = 400;
                //hp.Style.Add("style", "word-wrap:break-word");
                hp.Enabled = setControl(hp);
                //hp.Style.Add("style", "text-align:left;");
                //hp.Font.Size = new FontUnit(9);
                hp.Target = "_blank";
            }



            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancySalary") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.VacancySalary);
            _TextBox.Enabled = setControl(_TextBox);


            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyCompany") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.VacancyCompany);
            _TextBox.Enabled = setControl(_TextBox);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyCompanyCity") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.VacancyCompanyCity);
            _TextBox.Enabled = setControl(_TextBox);


            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyCompanyStreetName") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.VacancyCompanyStreetName);
            _TextBox.Enabled = setControl(_TextBox);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyCompanyStreetNumber") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.VacancyCompanyStreetNumber);
            _TextBox.Enabled = setControl(_TextBox);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyCompanyZipCode") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.VacancyCompanyZipCode);
            _TextBox.Enabled = setControl(_TextBox);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyCompanyCountry") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.VacancyCompanyCountry);
            _TextBox.Enabled = setControl(_TextBox);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyCompanySummary") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.VacancyCompanySummary);
            _TextBox.Enabled = setControl(_TextBox);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtVacancyCompanyWebsite") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.VacancyCompanyWebsite);
            _TextBox.Enabled = setControl(_TextBox);

            if (_Viewtype == "view")
            {
                _TextBox.Visible = false;
                hp = this.Master.FindControl("ContentPlaceHolderMain").FindControl("hlVacancyCompanyWebsite") as HyperLink;
                hp.Text = _Utility.Decrypt(_JobApplication.VacancyCompanyWebsite);
                string navigateUrlStart = _GridViewUtility.checkNavigateUrlStart(hp.Text);
                hp.NavigateUrl = navigateUrlStart + hp.Text;
                //hp.Width = 400;
                //hp.Style.Add("style", "word-wrap:break-word");
                hp.Enabled = setControl(hp);
                //hp.Style.Add("style", "text-align:left;");
                //hp.Font.Size = new FontUnit(9);
                hp.Target = "_blank";

            }

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplFeedback") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.JobApplFeedback);
            _TextBox.Enabled = setControl(_TextBox);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplMyFollowUpEmails") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.JobApplMyFollowUpEmails);
            _TextBox.Enabled = setControl(_TextBox);

            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("dropdownStatus") as DropDownList;
            //_DropDownList.Text = _JobApplication.JobApplStatus;
            _DropDownList.Items.FindByText(_JobApplication.JobApplStatus).Selected = true;
            _DropDownList.Enabled = setControl(_DropDownList);

            _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlFollowUpStatus") as DropDownList;
            //_DropDownList.Text = _JobApplication.JobApplStatus;
            _DropDownList.Items.FindByText(_JobApplication.JobApplFollowUpStatus).Selected = true;
            _DropDownList.Enabled = setControl(_DropDownList);

            _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtJobApplNote") as TextBox;
            _TextBox.Text = _Utility.Decrypt(_JobApplication.JobApplNote);
            _TextBox.Enabled = setControl(_TextBox);

            AjaxControlToolkit.ComboBox ccCategory = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ccCategory") as AjaxControlToolkit.ComboBox;
            if (_Viewtype == "view")
            {
                ccCategory.Items.Add(_Utility.Decrypt(_JobApplication.JobApplCat));
             }

            ccCategory.Text = "";
            string category = _Utility.Decrypt(_JobApplication.JobApplCat);
            if (!string.IsNullOrEmpty(category));
            {
                    ccCategory.Text = category;
            }
            ccCategory.Enabled = setControl(ccCategory);

            _checkBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("chkBoxShowToFriends") as CheckBox;
            _checkBox.Enabled = setControl(_checkBox);
            string showToFriends = _JobApplication.ShowToFriends;
            if (showToFriends == "True")
            {
                _checkBox.Checked = true;
            }
            else if (showToFriends == "False")
            {
                _checkBox.Checked = false;
            }

            if (Viewtype == "view")
            {
                //Panel _Panel = this.Master.FindControl("ContentPlaceHolderMain").FindControl("JobApplicationsPanel") as Panel;
                //_Panel.Enabled = false;

                //foreach (Control control in _Panel.Controls)
                //{

                //    if (control is HyperLink)
                //    {
                //        control.Enabled
                //        (HyperLink)control. = true;
                //    }
                //}

                Button _Button = this.Master.FindControl("ContentPlaceHolderMain").FindControl("btnSubmit") as Button;
                _Button.Visible = false;
            }
            else if (Viewtype == "edit")
            {

                Button _Button = this.Master.FindControl("ContentPlaceHolderMain").FindControl("btnSubmit") as Button;
                _Button.Text = "Edit";
            }
        }
    }


    private Boolean setControl(WebControl control)
    {
        Boolean value = true;

        if (_Viewtype == "view")
        {
            if (control is TextBox)
            {
                value = false;
            }
            else if(control is HyperLink)
            {
                value = true;
            }
            else
            {
                value = false;
            }
        }
        else if(_Viewtype == "edit")
        {
            if (control is TextBox)
            {
                value = true;
            }
            else if (control is HyperLink)
            {
                value = true;
            }
            else
            {
                value = true;
            }
        }
        return value;
    }

    private void fillJobApplTimeDDL()
    {
        DropDownList _DropDownList = new DropDownList();

        _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplTimeHour") as DropDownList;
        _DropDownList = dropdownlistHour(_DropDownList);

        _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplTimeMinute") as DropDownList;
        _DropDownList = dropdownlistMinute(_DropDownList);
    }

    private void fillJobApplInterviewDDL()
    {
        DropDownList _DropDownList = new DropDownList();

        _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplInterviewTimeHour") as DropDownList;
        _DropDownList = dropdownlistHour(_DropDownList);

        _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplInterviewTimeMinute") as DropDownList;
        _DropDownList = dropdownlistMinute(_DropDownList);
    }

    private void fillJobApplSecInterviewDLL()
    {
        DropDownList _DropDownList = new DropDownList();

        _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplSecInterviewTimeHour") as DropDownList;
        _DropDownList = dropdownlistHour(_DropDownList);

        _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplSecInterviewTimeMinute") as DropDownList;
        _DropDownList = dropdownlistMinute(_DropDownList);
    }

    private void fillJobApplThirdInterviewDLL()
    {
    DropDownList _DropDownList = new DropDownList();

    _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplThirdInterviewTimeHour") as DropDownList;
        _DropDownList = dropdownlistHour(_DropDownList);

    _DropDownList = this.Master.FindControl("ContentPlaceHolderMain").FindControl("ddlJobApplThirdInterviewTimeMinute") as DropDownList;
        _DropDownList = dropdownlistMinute(_DropDownList);
    }

    private DropDownList dropdownlistHour(DropDownList _DropDownList)
    {
        string hour = "";
        for (int i = 0; i < 24; i++)
        {
            if (i < 10)
            {
                hour = "0" + i.ToString();
            }
            else
            {
                hour = i.ToString();
            }

            _DropDownList.Items.Add(hour);
        }

        return _DropDownList;
    }

    private DropDownList dropdownlistMinute(DropDownList _DropDownList)
    {
        string minute = "";
        for (int i = 0; i < 60; i++)
        {
            if (i < 10)
            {
                minute = "0" + i.ToString();
            }
            else
            {
                minute = i.ToString();
            }
            _DropDownList.Items.Add(minute);
        }
        return _DropDownList;
    }

    #endregion methods

    #region webmethods
    [WebMethod(EnableSession = true)]
    //[HttpPost]
    public static void openjobApplication(string parameter, string viewType)
    {
        //if (HttpContext.Current.Session["OpenJobApplGridview"] == "true")
        //{
        //    List<JobApplications> foundJobApplications = new List<JobApplications>();
        //    JobApplicationsController jobApplController = new JobApplicationsController();
        //    JobApplications jobApplication = jobApplController.GetJobApplications(Convert.ToInt32(parameter));

        //    foundJobApplications.Add(jobApplication);

        //    HttpContext.Current.Session["searchResultsJobAppl"] = foundJobApplications;
        //    HttpContext.Current.Session["nofSearchResults"] = foundJobApplications.Count().ToString();
        //    HttpContext.Current.Server.Transfer("Dashboard.aspx");
        //}
        //else
        //{ 
        //    HttpContext.Current.Session["Parameter"] = parameter;
        //    HttpContext.Current.Session["Viewtype"] = viewType;
        //    //HttpContext.Current.Server.Transfer("JobApplications.aspx");
        //}
    }
    #endregion webmethods
}
