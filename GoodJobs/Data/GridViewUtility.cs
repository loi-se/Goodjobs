using Jobhunt.Controllers;
using Jobhunt.Data;
using Jobhunt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Jobhunt
{
    public class GridViewUtility
    {
        public System.Drawing.Color HeaderTextColor = System.Drawing.Color.FromArgb(int.Parse("#FFFFFF".Replace("#", ""),
                        System.Globalization.NumberStyles.AllowHexSpecifier));

        public int HeaderTextSize = 9;

        public System.Drawing.Color HeaderBackColor = System.Drawing.Color.FromArgb(int.Parse("#0066CC".Replace("#", ""),
                        System.Globalization.NumberStyles.AllowHexSpecifier));


        public System.Drawing.Color GridViewCellBackColor = System.Drawing.Color.FromArgb(int.Parse("#FFFFFF".Replace("#", ""),
                        System.Globalization.NumberStyles.AllowHexSpecifier));

        public System.Drawing.Color GridViewCellBorderColor = System.Drawing.Color.FromArgb(int.Parse("#000000".Replace("#", ""),
                        System.Globalization.NumberStyles.AllowHexSpecifier));

        public JobApplicationsController _JobApplicationsController;
        public UsersController _UsersController;
        public Utility _Utility;

        public int jobApplpageSize = 6;
        public int contactspageSize = 6;
        public int invpageSize = 6;

        public TextBox labelTextbox(string text, int width)
        {
            TextBox txtbox = new TextBox();
            txtbox = new TextBox();
            txtbox.Text = text;
            txtbox.Font.Size = new FontUnit(9);
            txtbox.TextMode = TextBoxMode.MultiLine;
            txtbox.Width = width;
            txtbox.Height = 100;
            txtbox.BorderStyle = BorderStyle.None;
            txtbox.BorderWidth = 0;
            txtbox.ReadOnly = true;
            txtbox.Wrap = true;
            txtbox.BackColor = GridViewCellBackColor;
            txtbox.BorderColor = GridViewCellBackColor;


            return txtbox;
        }
        public TextBox labelTextboxInv(string text, int width)
        {
            TextBox txtbox = new TextBox();
            txtbox = new TextBox();
            txtbox.Text = text;
            txtbox.Font.Size = new FontUnit(9);
            txtbox.TextMode = TextBoxMode.MultiLine;
            txtbox.Width = width;
            txtbox.Height = 100;
            txtbox.BorderStyle = BorderStyle.None;
            txtbox.BorderWidth = 0;
            txtbox.ReadOnly = true;
            txtbox.Wrap = true;
            txtbox.BackColor = GridViewCellBackColor;
            txtbox.BorderColor = GridViewCellBackColor;


            return txtbox;
        }

        public TextBox normalTextbox(string text)
        {
            TextBox txtbox = new TextBox();
            txtbox = new TextBox();
            txtbox.Text = text;
            txtbox.Font.Size = new FontUnit(9);
            txtbox.TextMode = TextBoxMode.MultiLine;
            txtbox.Width = 175;
            txtbox.Height = 120;
            txtbox.ReadOnly = true;
            txtbox.Wrap = true;
            txtbox.BackColor = GridViewCellBackColor;
            txtbox.BorderColor = GridViewCellBackColor;
            return txtbox;
        }

        public string checkNavigateUrlStart(string navigateUrl)
        {

            string navigateUrlStart;
            if (navigateUrl.Contains("http://") || navigateUrl.Contains("https://"))
            {
                navigateUrlStart = "";
            }
            else
            {
                navigateUrlStart = "http://";
            }

            return navigateUrlStart;
        }


        public string numberOfJobApplications(int userId)
        {

           string presentationNofJobAppl = "";
           string totalJobAppl = "";
            int publicJobApplCount = 0;

            _JobApplicationsController = new JobApplicationsController();
            _UsersController = new UsersController();
            _Utility = new Utility();

            List<JobApplications> userJobApplications = _JobApplicationsController.GetMyJobApplications(userId);
            totalJobAppl = userJobApplications.Count().ToString();

            foreach(JobApplications _jobApplication in userJobApplications)
            {
                if (_Utility.Decrypt(_jobApplication.ShowToFriends) == "True")
                {
                    publicJobApplCount++;
                }
            }

            presentationNofJobAppl = "Total: " + totalJobAppl + " " + "(Public: " + publicJobApplCount.ToString() + ")";
                 

           return presentationNofJobAppl;
        }

        public Color getStatusColor(string status)
        {

            Color _color = Color.White;

            if (status == "Withdrawn")
            {
                _color = Color.Orange;
            }
            else if (status == "Denied")
            {
                _color = Color.Red;
            }
            else if (status == "Send")
            {
                _color = Color.LightBlue;
            }
            else if (status == "Accepted")
            {
                _color = Color.Green;
            }

            return _color;
        }

    }
}