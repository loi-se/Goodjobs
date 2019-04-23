using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using Jobhunt.Controllers;
using Jobhunt.Models;
using System.Data;
using System.Collections;
using System.Runtime.Serialization.Json;
using GoogleMaps.LocationServices;
using Newtonsoft.Json;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Http;
using System.IO;
using System.Drawing;
using ClosedXML.Excel;
using System.Web.UI.DataVisualization.Charting;
using System.Text;
using Jobhunt.UserControls;
using Jobhunt.Data;

namespace Jobhunt
{
    public partial class Dashboard : System.Web.UI.Page
    {
        #region members
        public JobApplicationsController _JobApplicationsController;
        public JobApplications _JobApplication;
        public UsersController _UsersController;
        public GridViewUtility _GridViewUtility;
        public Utility Utility;
        public User _User;
        private int _UserId;

        //private GridView DashBoardJobApplicationsGV;
        #endregion members

        #region events
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page page = Page..;

            string previousUrl = Request.UrlReferrer.ToString();

            if (!previousUrl.Contains("Dashboard.aspx"))
            {
                Session["searchResultsJobAppl"] = null;
                Session["searchQuery"] = null;
                Session["nofSearchResults"] = null;
            }

            _GridViewUtility = new GridViewUtility();
            Utility = new Utility();
            _JobApplicationsController = new JobApplicationsController();
            _JobApplication = new JobApplications();
            _UsersController = new UsersController();
            _User = new User();

            ImageButtonExcell.ToolTip = "Export gridview to Excell";
            ImageButtonExcell.ID = "btn_View";
            ImageButtonExcell.ImageUrl = "~/images/buttons/ExportExcell.png";
            ImageButtonExcell.Width = 20;
            ImageButtonExcell.Height = 20;
            ImageButtonExcell.Click += new ImageClickEventHandler(ImageButton_Excell);
            //DashBoardJobApplicationsGV.BorderColor = System.Drawing.Color.FromArgb(int.Parse("#99CCFF".Replace("#", ""),
            //             System.Globalization.NumberStyles.AllowHexSpecifier));
          
            var UserId = Session["UserId"];
            _UserId = Convert.ToInt32(UserId);
            _User = _UsersController.GetUser(_UserId);
            if (!this.IsPostBack)
            {
                Tab1.CssClass = "Clicked";
                MainView.ActiveViewIndex = 0;
                if (HttpContext.Current.Session["OpenJobApplGridview"] == "true")
                {
                    cbOpenJobAppl.Checked = true;
                }
                else
                {
                    cbOpenJobAppl.Checked = false;
                }
            }
            UCJobApplications._UserId = _UserId;
            ShowPersonalInformation();
            ShowCharts();
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            //BindGMap();
        }


        protected void Tab1_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Clicked";
            Tab2.CssClass = "Initial";
            Tab3.CssClass = "Initial";
            MainView.ActiveViewIndex = 0;
        }

        protected void ShowTimeLine(object sender, EventArgs e)
        {
            DateTime dateTimeNow = DateTime.Now;
            List<JobApplications> myJobApplications = _JobApplicationsController.GetMyJobApplications(_UserId);

            int currentYear = dateTimeNow.Year;
            int currentMonth = dateTimeNow.Month;

            int i = 0;
            int count = 0;

            int foundJobAppl = 0;
            int historyRange = Convert.ToInt32(ddlHistoryRange.SelectedItem.Text);

            decimal[] values = new decimal[historyRange];
            int historyCounter = 0;
            DateTime historyDateTime;

            string categoriesAxis = "";
            string category = "";
            string selectedCategory = ddlCategory.SelectedItem.Text;
            if (string.IsNullOrEmpty(selectedCategory))
            {
                category = "All";
            }
            else
            {
                category = selectedCategory;
            }

            List<int> points = new List<int>();

            ChartTimeLine.Series.Add("series1");

            for (historyCounter = 0; historyCounter < historyRange; historyCounter++)
            {
                foundJobAppl = 0;
                DateTime datetimeMonth = dateTimeNow.AddMonths(-(historyCounter));
                //DateTime datetimeMin = dateTimeNow.AddMonths(-(historyCounter + 1));

                foreach (JobApplications jobAppl in myJobApplications)
                {
                    if (jobAppl.JobApplDateTime != null)
                    {
                        DateTime jobApplDateTime = (DateTime)jobAppl.JobApplDateTime;

                        if (jobApplDateTime.Month == datetimeMonth.Month && jobApplDateTime.Year == datetimeMonth.Year)
                        {
                            string jobApplCat = Utility.Decrypt(jobAppl.JobApplCat);
                            if (category != "All")
                            {
                                if (category != jobApplCat)
                                {
                                    continue;
                                }
                            }
                            foundJobAppl++;
                        }
                    }
                }

                if (string.IsNullOrEmpty(categoriesAxis))
                {
                    categoriesAxis = datetimeMonth.Month + "/" + datetimeMonth.Year;
                }
                else
                {
                    categoriesAxis = categoriesAxis + "," + datetimeMonth.Month + "/" + datetimeMonth.Year;
                }

                ChartTimeLine.Series["series1"].Points.AddXY(historyCounter, foundJobAppl);
                ChartTimeLine.Series["series1"].Points[i].AxisLabel = datetimeMonth.Month + "/" + datetimeMonth.Year;
                ChartTimeLine.Series["series1"].Points[i].Label = foundJobAppl.ToString();
                values[i] = Convert.ToDecimal(foundJobAppl);
                i++;
            }

            ChartTimeLine.Series["series1"].ChartType = SeriesChartType.Bar;
            ChartTimeLine.ChartAreas["ChartArea1"].AxisX.Title = "Month / year";
            ChartTimeLine.ChartAreas["ChartArea1"].AxisX.IsReversed = true;
            ChartTimeLine.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            ChartTimeLine.ChartAreas["ChartArea1"].AxisY.Title = "Number of job applications";

            ChartTimeLine.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            ChartTimeLine.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            ChartTimeLine.Titles.Add("Category: " + category);
            ChartTimeLine.Height = (historyRange * 30) + 100;
            ChartTimeLine.DataBind();
        }

        protected void Tab2_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Initial";
            Tab2.CssClass = "Clicked";
            Tab3.CssClass = "Initial";
            MainView.ActiveViewIndex = 1;
            ChartTimeLine.Visible = false;

            ddlCategory.DataSource = Utility.GetUserCategories(_UserId, true);
            ddlCategory.DataTextField = "Key";
            ddlCategory.DataValueField = "Value";
            ddlCategory.DataBind();

            ddlHistoryRange.Items.Clear();
            for (int i = 1; i <= 36; i++)
            {
                ddlHistoryRange.Items.Add(i.ToString());
            }
            ddlHistoryRange.DataBind();

        }

        protected void Tab3_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Initial";
            Tab2.CssClass = "Initial";
            Tab3.CssClass = "Clicked";
            MainView.ActiveViewIndex = 2;

            WordCloudText.Text = "";

            SortedList wordCloudInput = new SortedList();

             wordCloudInput.Add("Job application letters", "jobAplLetter");
             wordCloudInput.Add("Job application vacancy texts", "jobAplVacancy");


            ddlWordCloud.DataSource = wordCloudInput;
            ddlWordCloud.DataTextField = "Key";
            ddlWordCloud.DataValueField = "Value";
            ddlWordCloud.DataBind();
        }

        protected void ShowWordCloud(object sender, EventArgs e)
        {
            GenerateWordCloud();
        }

        protected void ImageButton_Excell(object sender, EventArgs e)
        {
            ExportToExcell();
            // identify which button was clicked and perform necessary actions
        }

        protected void DashBoardJobApplicationsGV_Sorting(object sender, GridViewSortEventArgs e)
        {
            //DashBoardJobApplicationsGV.DataBind();

            //SetSortDirection(SortDirection);
            //if (dt != null)
            //{
            //    //Sort the data.
            //    dt.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
            //    GridView1.DataSource = dt;
            //    GridView1.DataBind();
            //    SortDireaction = _sortDirection;
            //}
        }

        protected void cbOpenJobAppl_CheckedChanged(Object sender, EventArgs args)
        {
            if (cbOpenJobAppl.Checked == true)
            {
                HttpContext.Current.Session["OpenJobApplGridview"] = "true";
            }
            else
            {
                HttpContext.Current.Session["OpenJobApplGridview"] = "false";
            }
        }

        #endregion events

        #region methods

        public void GenerateWordCloud()
        {
            max.Value = "120";
            perline.Checked = false;
            font.Value = @"""Helvetica Neue"", Helvetica, Arial, sans-serif";
            //Just copy from the visible explanation

            string selectedInputType = "";
            selectedInputType = ddlWordCloud.SelectedItem.Value;

            List<JobApplications> jobApplications = _JobApplicationsController.GetMyJobApplications(_UserId);

            string outPutString = "";
            if (!string.IsNullOrEmpty(selectedInputType))
            {
                foreach (JobApplications _jobApplication in jobApplications)
                {
                    if (selectedInputType == "jobAplLetter")
                    {
                        outPutString = outPutString + " " + Utility.Decrypt(_jobApplication.JobApplLetter);
                    }

                    if (selectedInputType == "jobAplVacancy")
                    {
                        outPutString = outPutString + " " + Utility.Decrypt(_jobApplication.VacancyText);
                    }
                }
            }
            WordCloudText.Text = outPutString;
            wordcloudcanvaswidth.Text = "500";
            wordcloudcanvasheight.Text = "300";
        }

        public void ShowPersonalInformation()
        {
            Label _Label = new Label();
            HyperLink _hyperLink = new HyperLink();

            if (_User != null)
            {
                _Label = this.Master.FindControl("ContentPlaceHolderMain").FindControl("lblWelcomeName") as Label;
                _Label.Text = Utility.Decrypt(_User.FirstName) + " " + Utility.Decrypt(_User.LastName);

                _hyperLink = this.Master.FindControl("ContentPlaceHolderMain").FindControl("hplLinkedIn") as HyperLink;

                //string myUrl = Utility.Decrypt(_User.LinkedIn);
                _hyperLink.NavigateUrl = "";
                string myUrl = Utility.Decrypt(_User.LinkedIn);
                if (!string.IsNullOrEmpty(myUrl))
                {
                    UriBuilder builder = new UriBuilder(myUrl);
                    if (builder != null)
                    {
                        _hyperLink.NavigateUrl = builder.Uri.AbsoluteUri;
                    }
                }
          
                _hyperLink.Text = "LinkedIn";
                _hyperLink.Target = "_blank";

                _Label = this.Master.FindControl("ContentPlaceHolderMain").FindControl("lblNofJobApplications") as Label;
                _Label.Text =  _GridViewUtility.numberOfJobApplications(_UserId);

                _Label = this.Master.FindControl("ContentPlaceHolderMain").FindControl("lblNofContacts") as Label;
                _Label.Text = Utility.NumberOfUserContacts(_UserId);

                _Label = this.Master.FindControl("ContentPlaceHolderMain").FindControl("lblnofInvitations") as Label;
                _Label.Text = Utility.NumberOfUserOpenInvitations(_UserId);
            }
        }

        public void ShowCharts()
        {

            List<JobApplications> _MyJobApplications = new List<JobApplications>();
            _MyJobApplications = _JobApplicationsController.GetMyJobApplications(_UserId);

            Dictionary<string, int> _JobapplicationStatus = new Dictionary<string, int>();
            _JobapplicationStatus.Add("Job application sended", 0);
            _JobapplicationStatus.Add("Rejection - Job application letter", 0);
            _JobapplicationStatus.Add("First round interview", 0);
            _JobapplicationStatus.Add("Rejection - First round interview", 0);
            _JobapplicationStatus.Add("Second round interview", 0);
            _JobapplicationStatus.Add("Rejection - Second round interview", 0);
            _JobapplicationStatus.Add("Third round interview", 0);
            _JobapplicationStatus.Add("Rejection - Third round interview", 0);
            _JobapplicationStatus.Add("Assessment", 0);
            _JobapplicationStatus.Add("Rejection - Assessment", 0);
            _JobapplicationStatus.Add("Job offer", 0);


            //ChartUserStats.BackColor = System.Drawing.Color.FromArgb(int.Parse("#99CCFF".Replace("#", ""),
            //            System.Globalization.NumberStyles.AllowHexSpecifier));
            //ChartUserStats.Width = 450;

            foreach (JobApplications _myjobapplication in _MyJobApplications)
            {

                if (_myjobapplication.JobApplStatus == "Job application sended")
                {
                    if (_myjobapplication.JobApplDateTime != null)
                    {
                        _JobapplicationStatus["Job application sended"] += 1;
                    }
                }

                else if (_myjobapplication.JobApplStatus == "Rejection - Job application letter")
                {
                    _JobapplicationStatus["Rejection - Job application letter"] += 1;
                    if (_myjobapplication.JobApplDateTime != null)
                    {
                        _JobapplicationStatus["Job application sended"] += 1;
                    }

                }
                else if (_myjobapplication.JobApplStatus == "First round interview")
                {
                    if (_myjobapplication.JobApplInterviewDateTime != null)
                    {
                        _JobapplicationStatus["First round interview"] += 1;
                    }
                    if (_myjobapplication.JobApplDateTime != null)
                    {
                        _JobapplicationStatus["Job application sended"] += 1;
                    }
                }
                else if (_myjobapplication.JobApplStatus == "Rejection - First round Job application interview")
                {
                    _JobapplicationStatus["Rejection - First round interview"] += 1;

                    if (_myjobapplication.JobApplDateTime != null)
                    {
                        _JobapplicationStatus["Job application sended"] += 1;
                    }
                    if (_myjobapplication.JobApplInterviewDateTime != null)
                    {
                        _JobapplicationStatus["First round interview"] += 1;
                    }

                }
                else if (_myjobapplication.JobApplStatus == "Second round interview")
                {
                    if (_myjobapplication.JobApplSecInterviewDateTime != null)
                    {
                        _JobapplicationStatus["Second round interview"] += 1;
                    }

                    if (_myjobapplication.JobApplDateTime != null)
                    {
                        _JobapplicationStatus["Job application sended"] += 1;
                    }
                    if (_myjobapplication.JobApplInterviewDateTime != null)
                    {
                        _JobapplicationStatus["First round interview"] += 1;
                    }

                }
                else if (_myjobapplication.JobApplStatus == "Rejection - Second round Job application interview")
                {
                    _JobapplicationStatus["Rejection - Second round interview"] += 1;

                    if (_myjobapplication.JobApplSecInterviewDateTime != null)
                    {
                        _JobapplicationStatus["Second round interview"] += 1;
                    }
                    if (_myjobapplication.JobApplDateTime != null)
                    {
                        _JobapplicationStatus["Job application sended"] += 1;
                    }
                    if (_myjobapplication.JobApplInterviewDateTime != null)
                    {
                        _JobapplicationStatus["First round interview"] += 1;
                    }

                }
                else if (_myjobapplication.JobApplStatus == "Third round interview")
                {
                    if (_myjobapplication.JobApplThirdInterviewDateTime != null)
                    {
                        _JobapplicationStatus["Third round interview"] += 1;
                    }
                    if (_myjobapplication.JobApplSecInterviewDateTime != null)
                    {
                        _JobapplicationStatus["Second round interview"] += 1;
                    }
                    if (_myjobapplication.JobApplDateTime != null)
                    {
                        _JobapplicationStatus["Job application sended"] += 1;
                    }
                    if (_myjobapplication.JobApplInterviewDateTime != null)
                    {
                        _JobapplicationStatus["First round interview"] += 1;
                    }

                }
                else if (_myjobapplication.JobApplStatus == "Rejection - Third round Job application interview")
                {
                    _JobapplicationStatus["Rejection - Third round interview"] += 1;

                    if (_myjobapplication.JobApplThirdInterviewDateTime != null)
                    {
                        _JobapplicationStatus["Third round interview"] += 1;
                    }
                    if (_myjobapplication.JobApplSecInterviewDateTime != null)
                    {
                        _JobapplicationStatus["Second round interview"] += 1;
                    }
                    if (_myjobapplication.JobApplDateTime != null)
                    {
                        _JobapplicationStatus["Job application sended"] += 1;
                    }
                    if (_myjobapplication.JobApplInterviewDateTime != null)
                    {
                        _JobapplicationStatus["First round interview"] += 1;
                    }

                }
                else if (_myjobapplication.JobApplStatus == "Assessment")
                {
                    _JobapplicationStatus["Assessment"] += 1;

                }
                else if (_myjobapplication.JobApplStatus == "Rejection - Assessment")
                {
                    _JobapplicationStatus["Assessment"] += 1;
                    _JobapplicationStatus["Rejection - Assessment"] += 1;

                }
                else if (_myjobapplication.JobApplStatus == "Job offer")
                {
                    _JobapplicationStatus["Job offer"] += 1;

                }
            }
            Literal _Literal = new Literal();
            _Literal = this.Master.FindControl("ContentPlaceHolderMain").FindControl("litJobApplicationSended") as Literal;

            StringBuilder htmlTableString = new StringBuilder();
            htmlTableString.AppendLine("<table>");
    
            htmlTableString.AppendLine("<tr>");
            htmlTableString.AppendLine("<th></th>");
            htmlTableString.AppendLine("<th></th>");
            htmlTableString.AppendLine("<th></th>");
            htmlTableString.AppendLine("</tr>");


            foreach (KeyValuePair<string, int> _myjobapplicationStatus in _JobapplicationStatus)
            {
                htmlTableString.AppendLine("<tr>");
                htmlTableString.AppendLine("<td>" + _myjobapplicationStatus.Key.ToString() + "</td>");
                htmlTableString.AppendLine("<td>" + " : " + "</td>");
                htmlTableString.AppendLine("<td>" + _myjobapplicationStatus.Value.ToString() + "</td>");
                htmlTableString.AppendLine("</tr>");
               // _Label.Text = _Label.Text + "<br />" + _myjobapplicationStatus.Key + " : " + _myjobapplicationStatus.Value.ToString(); 
            }
            htmlTableString.AppendLine("</table>");
            _Literal.Text = htmlTableString.ToString();

            //_TextBox = normalTextbox(jobApplicationStatus);
            //_TextBox.Text = jobApplicationStatus;
        }

        //private void BindGMap()
        //{
        //    try
        //    {
        //        //User _UserHome = new Models.User();
        //        List<ProgramAddresses> AddressList = new List<ProgramAddresses>();
        //        string FullAddress;
        //        ProgramAddresses MapAddress;
        //        //var locationService;
        //        var locationService = new GoogleLocationService();

        //        List<GridViewRow> rows = this.UCJobApplications.getGridViewRows();
        //        List<JobApplications> _JobApplicationsPageView = new List<JobApplications>();
        //        foreach (GridViewRow gridViewRow in rows)
        //        {
        //            int JobApplID = Convert.ToInt32(gridViewRow.Cells[3].Text);
        //            JobApplications jobApplications  = _JobApplicationsController.GetJobApplications(JobApplID);
        //            _JobApplicationsPageView.Add(jobApplications);
        //        }

        //       // UCJobApplications.


        //        foreach (JobApplications _JobApplicationItem in _JobApplicationsPageView)
        //        {
        //            //if(String.IsNullOrEmpty())
        //            if (!String.IsNullOrEmpty(Utility.Decrypt(_JobApplicationItem.VacancyCompanyStreetName)) || !String.IsNullOrEmpty(Utility.Decrypt(_JobApplicationItem.VacancyCompanyStreetNumber)) 
        //                || !String.IsNullOrEmpty(Utility.Decrypt(_JobApplicationItem.VacancyCompanyZipCode)) || !String.IsNullOrEmpty(Utility.Decrypt(_JobApplicationItem.VacancyCompanyCity)) 
        //                || !String.IsNullOrEmpty(Utility.Decrypt(_JobApplicationItem.VacancyCompanyCountry)))
        //            {
        //                FullAddress = Utility.Decrypt(_JobApplicationItem.VacancyCompanyStreetName) + " " + Utility.Decrypt(_JobApplicationItem.VacancyCompanyStreetNumber) + " " + Utility.Decrypt(_JobApplicationItem.VacancyCompanyZipCode) + " " + Utility.Decrypt(_JobApplicationItem.VacancyCompanyCity) + " " + Utility.Decrypt(_JobApplicationItem.VacancyCompanyCountry);
        //                MapAddress = new ProgramAddresses();
        //                MapAddress.description = FullAddress;
        //                locationService = new GoogleLocationService();
        //                var point = locationService.GetLatLongFromAddress(FullAddress);
        //                MapAddress.lat = point.Latitude;
        //                MapAddress.lng = point.Longitude;
        //                AddressList.Add(MapAddress);
        //            }
        //        }

        //        //_UserHome = ((Site1)this.Master)._User;
        //        if (_User != null)
        //        {
        //            if (!String.IsNullOrEmpty(Utility.Decrypt(_User.StreetName)) || !String.IsNullOrEmpty(Utility.Decrypt(_User.StreetNumber)) || !String.IsNullOrEmpty(Utility.Decrypt(_User.ZipCode)) || !String.IsNullOrEmpty(Utility.Decrypt(_User.City)) || !String.IsNullOrEmpty(Utility.Decrypt(_User.Country)))
        //            {
        //                FullAddress = Utility.Decrypt(_User.StreetName) + " " + Utility.Decrypt(_User.StreetNumber) + " " + Utility.Decrypt(_User.ZipCode) + " " + Utility.Decrypt(_User.City) + " " + Utility.Decrypt(_User.Country);
        //                MapAddress = new ProgramAddresses();
        //                MapAddress.description = FullAddress;
        //                locationService = new GoogleLocationService();
        //                var point2 = locationService.GetLatLongFromAddress(FullAddress);
        //                MapAddress.lat = point2.Latitude;
        //                MapAddress.lng = point2.Longitude;
        //                AddressList.Add(MapAddress);
        //            }
        //        }

        //        // string jsonString =  JsonSerializer(AddressList);
        //        string jsonString = JsonConvert.SerializeObject(AddressList);

        //        // string jsonString = JsonSerializer<List<ProgramAddresses>>(AddressList);
        //        ScriptManager.RegisterArrayDeclaration(Page, "markers", jsonString);
        //        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "GoogleMap();", true);
        //    }
        //    catch (Exception ex)
        //    {
        //        lMapError.Text = ex.Message.ToString();
        //        lMapError.ForeColor = Color.Red;
        //    }
        //}

        // Behaves like a wrapped label:
        private void ExportToExcell()
        {
            List<JobApplications> _myJobApplications = _JobApplicationsController.GetMyJobApplications(_UserId).ToList();
            DataTable _myJobApplicationsDataTable = Utility.ToDataTable(_myJobApplications);

            ToExcelFile(_myJobApplicationsDataTable);
        }

        public void ToExcelFile(DataTable dt)
        {
            try
            {
                ClosedXML.Excel.XLWorkbook wbook = new ClosedXML.Excel.XLWorkbook();
                wbook.Worksheets.Add(dt, "tab1");
                // Prepare the response
                HttpResponse httpResponse = Response;
                httpResponse.Clear();
                httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //Provide you file name here
                httpResponse.AddHeader("content-disposition", "attachment;filename=\"myJobApplications.xlsx\"");

                // Flush the workbook to the Response.OutputStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    wbook.SaveAs(memoryStream);
                    memoryStream.WriteTo(httpResponse.OutputStream);
                    memoryStream.Close();
                }

                httpResponse.End();
            }
            catch(Exception ex)
            {

            }
        }

        #endregion methods

        #region Web methods

        [WebMethod(EnableSession = true)]
        //[HttpPost]
        public static bool openjobApplication(string parameter, string viewType)
        {
            bool openJobApplGidView = false;
            //String page = ";
            //Session
            if (HttpContext.Current.Session["OpenJobApplGridview"] == "true")
            {
                List<JobApplications> foundJobApplications = new List<JobApplications>();
                JobApplicationsController jobApplController = new JobApplicationsController();
                JobApplications jobApplication = jobApplController.GetJobApplications(Convert.ToInt32(parameter));

                foundJobApplications.Add(jobApplication);

                HttpContext.Current.Session["searchResultsJobAppl"] = foundJobApplications;
                HttpContext.Current.Session["nofSearchResults"] = foundJobApplications.Count().ToString();
                openJobApplGidView = true;
                //Response.Redirect("Dashboard.aspx");
            }
            else
            {
                HttpContext.Current.Session["Parameter"] = parameter;
                HttpContext.Current.Session["Viewtype"] = viewType;
                openJobApplGidView = false;
                //HttpContext.Current.Server.Transfer("JobApplications.aspx", true);
            }
            return openJobApplGidView;
        }


        [WebMethod]
        //[HttpPost]
        public static String BindCalendar()
        {
            Utility myUtility = new Utility();
            string myJsonString = "";
            List<object> myList = new List<object>();

            var UserId = HttpContext.Current.Session["UserId"];
            int _myUserId = Convert.ToInt32(UserId);

            JobApplicationsController JobApplicationsController = new JobApplicationsController();
            foreach (JobApplications _JobApplicationItem in JobApplicationsController.GetMyJobApplications(_myUserId))
            {

                var JobApplId = "";
                var JobApplName = "";
                DateTime JobApplDateStart = new DateTime();
                DateTime JobApplDateEnd = new DateTime();
                DateTime JobApplRealStartDate;
                DateTime JobApplRealEndDate;
                String JobApplSendStartDate;
                String JobApplSendEndDate;
                timeTable t_table;

                JobApplId = _JobApplicationItem.ID.ToString();

                // First job application:
                if (_JobApplicationItem.JobApplDateTime != null)
                {
                    //JobApplName = _JobApplicationItem.ID + ": " + myUtility.Decrypt(_JobApplicationItem.JobApplName);
                    JobApplName = "Job Appl: " + myUtility.Decrypt(_JobApplicationItem.JobApplName);
                    JobApplDateStart = _JobApplicationItem.JobApplDateTime.Value;
                    JobApplDateEnd = _JobApplicationItem.JobApplDateTime.Value.AddHours(1);

                    JobApplRealStartDate = Convert.ToDateTime(JobApplDateStart);
                    JobApplRealEndDate = Convert.ToDateTime(JobApplDateEnd);

                    JobApplSendStartDate = JobApplRealStartDate.ToString("s");
                    JobApplSendEndDate = JobApplRealEndDate.ToString("s");

                    t_table = new timeTable(JobApplId, JobApplName, JobApplSendStartDate, JobApplSendEndDate);
                    myList.Add(t_table);
                }

                // 1st interview:
                if (_JobApplicationItem.JobApplInterviewDateTime != null)
                {
                    //JobApplName = _JobApplicationItem.ID + ": " + "Interview - " + myUtility.Decrypt(_JobApplicationItem.JobApplName);
                    JobApplName = "1st IV: " + myUtility.Decrypt(_JobApplicationItem.JobApplName);
                    JobApplDateStart = _JobApplicationItem.JobApplInterviewDateTime.Value;
                    JobApplDateEnd = _JobApplicationItem.JobApplInterviewDateTime.Value.AddHours(1);

                    JobApplRealStartDate = Convert.ToDateTime(JobApplDateStart);
                    JobApplRealEndDate = Convert.ToDateTime(JobApplDateEnd);

                    JobApplSendStartDate = JobApplRealStartDate.ToString("s");
                    JobApplSendEndDate = JobApplRealEndDate.ToString("s");

                    t_table = new timeTable(JobApplId, JobApplName, JobApplSendStartDate, JobApplSendEndDate);
                    myList.Add(t_table);
                }
                //2nd interview:
                if (_JobApplicationItem.JobApplSecInterviewDateTime != null)
                {
                    //JobApplName = _JobApplicationItem.ID + ": " + "Interview - " + myUtility.Decrypt(_JobApplicationItem.JobApplName);
                    JobApplName = "2nd IV: " + myUtility.Decrypt(_JobApplicationItem.JobApplName);
                    JobApplDateStart = _JobApplicationItem.JobApplSecInterviewDateTime.Value;
                    JobApplDateEnd = _JobApplicationItem.JobApplSecInterviewDateTime.Value.AddHours(1);

                    JobApplRealStartDate = Convert.ToDateTime(JobApplDateStart);
                    JobApplRealEndDate = Convert.ToDateTime(JobApplDateEnd);

                    JobApplSendStartDate = JobApplRealStartDate.ToString("s");
                    JobApplSendEndDate = JobApplRealEndDate.ToString("s");

                    t_table = new timeTable(JobApplId, JobApplName, JobApplSendStartDate, JobApplSendEndDate);
                    myList.Add(t_table);
                }

                //Third interview:
                if (_JobApplicationItem.JobApplThirdInterviewDateTime != null)
                {
                    //JobApplName = _JobApplicationItem.ID + ": " + "Interview - " + myUtility.Decrypt(_JobApplicationItem.JobApplName);
                    JobApplName = "3rd IV: " + myUtility.Decrypt(_JobApplicationItem.JobApplName);
                    JobApplDateStart = _JobApplicationItem.JobApplThirdInterviewDateTime.Value;
                    JobApplDateEnd = _JobApplicationItem.JobApplThirdInterviewDateTime.Value.AddHours(1);

                    JobApplRealStartDate = Convert.ToDateTime(JobApplDateStart);
                    JobApplRealEndDate = Convert.ToDateTime(JobApplDateEnd);

                    JobApplSendStartDate = JobApplRealStartDate.ToString("s");
                    JobApplSendEndDate = JobApplRealEndDate.ToString("s");

                    t_table = new timeTable(JobApplId, JobApplName, JobApplSendStartDate, JobApplSendEndDate);
                    myList.Add(t_table);
                }
            }
            myJsonString = (new JavaScriptSerializer()).Serialize(myList);
            return myJsonString;

        }
        #endregion web methods
 
    }

    public class ProgramAddresses
    {
        public ProgramAddresses()
        {
        }
        public string description { get; set; }
        public double lng { get; set; }
        public double lat { get; set; }
    }

    public class timeTable
    {
        public String id { get; set; }
        public String title { get; set; }
        public String start { get; set; }
        public String end { get; set; }

        public timeTable(String I, String t, String ds, String de)
        {
            this.id = I;
            this.title = t;
            this.start = ds;
            this.end = de;
        }


    }
}