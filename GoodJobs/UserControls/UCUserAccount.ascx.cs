using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jobhunt.Controllers;
using Jobhunt.Models;
using Jobhunt.Data;
using System.Linq;
using System.Collections;
using System.Globalization;

namespace Jobhunt
{
    public partial class UCUserAccount : System.Web.UI.UserControl
    {

        #region members
        public UsersController _UsersController;
        public User _User;
        public Careers _Careers;
        public Utility _Utility;
        public MailHandler _MailHandler;

        #endregion members
        //public User _NotUpdatedUser;

        #region events
        protected void Page_Load(object sender, EventArgs e)
        {
            _Careers = new Careers();
            _UsersController = new UsersController();
            _Utility = new Utility();
            _MailHandler = new MailHandler();

            if (Session["UserId"] != null)
            {
                _User = _UsersController.GetUser(Convert.ToInt32(Session["UserId"]));
            }

           // _NotUpdatedUser = new User();
            labelCreateUser.Text = "";
            string virtualPath = Request.Path.ToString();
            string pageName = virtualPath.Substring(virtualPath.LastIndexOf("/") + 1);

            txtPassword.Attributes["type"] = "password";
            txtConfirmPassword.Attributes["type"] = "password";



            Button _Button = new Button();
            if (!this.IsPostBack)
            {

                fillddlSubCareers();
                fillddlMainCareers();
                fillddlCountry();

                if (pageName == "MyAccount.aspx")
                {
                    //_User = _UsersController.GetUser(Convert.ToInt32(Session["UserId"]));
                    //Button _Button = new Button();
                    _Button = this.FindControl("submitButton") as Button;
                    _Button.Text = "Edit";

                    TextBox _TextBox = new TextBox();
                    _TextBox = this.FindControl("txtOldPassword") as TextBox;
                    _TextBox.Visible = true;

                    trHidetxtOldPassword.Visible = true;
                    lHeader.Text = "My account";
                    ShowUser();
                }
            }

            if (pageName == "Register.aspx")
            {
                _User = new User();
                _Button = this.FindControl("submitButton") as Button;
                _Button.Text = "Submit";
                lHeader.Text = "Register";
                trHidetxtOldPassword.Visible = false;
            }
        }

        protected void itemSelected(object sender, EventArgs e)
        {
            int mainCareerId = Convert.ToInt32(ddlMainCareerField.SelectedItem.Value.ToString());
            ddlSubCareerField.Items.Clear();
            List<string> subCareers = _Careers.GetSubCareers(mainCareerId);
            foreach (string item in subCareers)
            {
                ddlSubCareerField.Items.Add(item);
            }
        }

        #endregion events

        #region methods
        public void fillddlCountry()
        {
            SortedList slCountry = new SortedList();
            string Key = "";
            string Value = "";

            foreach (CultureInfo info in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo info2 = new RegionInfo(info.LCID);
                if (!slCountry.Contains(info2.EnglishName))
                {
                    Value = info2.TwoLetterISORegionName;
                    Key = info2.EnglishName;
                    slCountry.Add(Key, Value);
                }
            }
            ddlCountry.DataSource = slCountry;
            ddlCountry.DataTextField = "Key";
            ddlCountry.DataValueField = "Value";
            ddlCountry.DataBind();
        }

        public void fillddlMainCareers()
        {
            Dictionary<int, string> MainCareers = _Careers.GetMainCareers();
            foreach (KeyValuePair<int, string> entry in MainCareers)
            {
                ddlMainCareerField.Items.Add(new ListItem(entry.Value, entry.Key.ToString()));
            }
        }

        public void fillddlSubCareers()
        {
            List<string> subCareers = _Careers.GetSubCareers(1);
            foreach (string item in subCareers)
            {
                ddlSubCareerField.Items.Add(item);
            }
        }
        private void ShowUser()
        {
            var UserId = Session["UserId"];
            int _UserId = Convert.ToInt32(UserId);

            _User = _UsersController.GetUser(_UserId);

            if (_User != null)
            {

                TextBox _TextBox = new TextBox();
                DropDownList _dropDownList = new DropDownList();
                _TextBox = this.FindControl("txtUsername") as TextBox;
                _TextBox.Text = _Utility.Decrypt(_User.UserName);

                _TextBox = this.FindControl("txtPassword") as TextBox;
                _TextBox.Text = _Utility.Decrypt(_User.Password);

                _TextBox = this.FindControl("txtConfirmPassword") as TextBox;
                _TextBox.Text = _Utility.Decrypt(_User.Password);

                _TextBox = this.FindControl("txtEmail") as TextBox;
                _TextBox.Text = _Utility.Decrypt(_User.Email);

                _TextBox = this.FindControl("txtFirstName") as TextBox;
                _TextBox.Text = _Utility.Decrypt(_User.FirstName);

                _TextBox = this.FindControl("txtLastName") as TextBox;
                _TextBox.Text = _Utility.Decrypt(_User.LastName);

                _TextBox = this.FindControl("txtStreetName") as TextBox;
                _TextBox.Text = _Utility.Decrypt(_User.StreetName);

                _TextBox = this.FindControl("txtStreetNumber") as TextBox;
                _TextBox.Text = _Utility.Decrypt(_User.StreetNumber);

                _TextBox = this.FindControl("txtCity") as TextBox;
                _TextBox.Text = _Utility.Decrypt(_User.City);

                string country = _Utility.Decrypt(_User.Country);
                _dropDownList = this.FindControl("ddlCountry") as DropDownList;
                _dropDownList.SelectedValue = _dropDownList.Items.FindByText(country).Value;

                _TextBox = this.FindControl("txtZipCode") as TextBox;
                _TextBox.Text = _Utility.Decrypt(_User.ZipCode);


                _TextBox = this.FindControl("txtLinkedIn") as TextBox;
                _TextBox.Text = _Utility.Decrypt(_User.LinkedIn);

                //
                _TextBox = this.FindControl("txtSearchTags") as TextBox;
                _TextBox.Text = _Utility.Decrypt(_User.SearchTag);

                int mainCareerId = Convert.ToInt32(_Utility.Decrypt(_User.MainCareer));
                Dictionary<int, string> MainCareers = _Careers.GetMainCareers();
                foreach (KeyValuePair<int, string> entry in MainCareers)
                {

                    ddlMainCareerField.Items.Add(new ListItem(entry.Value, entry.Key.ToString()));
                }
                _dropDownList = this.FindControl("ddlMainCareerField") as DropDownList;
                _dropDownList.SelectedValue = mainCareerId.ToString();



                List<string> subCareers = _Careers.GetSubCareers(mainCareerId);
                foreach (string item in subCareers)
                {
                    ddlSubCareerField.Items.Add(item);
                }
                string subCareerField = _Utility.Decrypt(_User.SubCareer);
                _dropDownList = this.FindControl("ddlSubCareerField") as DropDownList;
                _dropDownList.SelectedValue = _dropDownList.Items.FindByText(subCareerField).Value;

                _TextBox = this.FindControl("datepickerBirthDateText") as TextBox;
                _TextBox.Text = _User.BirthDate.Value.Date.ToString("dd-MM-yyyy");
            }
        }

        protected void CreateUser(object sender, EventArgs e)
        {
            string _email = "";
            TextBox _textBox = new TextBox();
            DropDownList _dropDownList = new DropDownList();

            _textBox = this.FindControl("txtUsername") as TextBox;
            _User.UserName = _Utility.Encrypt(_textBox.Text);

            _textBox = this.FindControl("txtPassword") as TextBox;
            _User.Password = _Utility.Encrypt(_textBox.Text);

            _textBox = this.FindControl("txtEmail") as TextBox;
            _User.Email = _Utility.Encrypt(_textBox.Text);
            _email = _textBox.Text;

            _textBox = this.FindControl("txtFirstName") as TextBox;
            _User.FirstName = _Utility.Encrypt(_textBox.Text);

            _textBox = this.FindControl("txtLastName") as TextBox;
            _User.LastName = _Utility.Encrypt(_textBox.Text);

            _textBox = this.FindControl("txtStreetName") as TextBox;
            _User.StreetName = _Utility.Encrypt(_textBox.Text);

            _textBox = this.FindControl("txtStreetNumber") as TextBox;
            _User.StreetNumber = _Utility.Encrypt(_textBox.Text);

            _textBox = this.FindControl("txtCity") as TextBox;
            _User.City = _Utility.Encrypt(_textBox.Text);

            string selectedValue = "";
            _dropDownList = this.FindControl("ddlCountry") as DropDownList;
            selectedValue = _dropDownList.SelectedItem.Text;
            _User.Country = _Utility.Encrypt(selectedValue);

            _textBox = this.FindControl("txtZipCode") as TextBox;
            _User.ZipCode = _Utility.Encrypt(_textBox.Text);


            _textBox = this.FindControl("txtLinkedIn") as TextBox;
            _User.LinkedIn = _Utility.Encrypt(_textBox.Text);

            _textBox = this.FindControl("txtSearchTags") as TextBox;
            _User.SearchTag = _Utility.Encrypt(_textBox.Text);

            _dropDownList = this.FindControl("ddlMainCareerField") as DropDownList;
            selectedValue = _dropDownList.SelectedValue.ToString();
            _User.MainCareer = _Utility.Encrypt(selectedValue);

            _dropDownList = this.FindControl("ddlSubCareerField") as DropDownList;
            selectedValue = _dropDownList.SelectedItem.Text;
            _User.SubCareer = _Utility.Encrypt(selectedValue);

            _textBox = this.FindControl("datepickerBirthDateText") as TextBox;
            string[] UserBirthDateValues = _textBox.Text.Split('-');
            // string JobApplDateValue = Request.Form["datepickerJobApplDate"];
            DateTime UserBirthDateValue = DateTime.ParseExact((UserBirthDateValues[2] + "-" + UserBirthDateValues[1] + "-" + UserBirthDateValues[0]), "yyyy-MM-dd",
                                           System.Globalization.CultureInfo.InvariantCulture);
            _User.BirthDate = UserBirthDateValue;
           
            //_User.Password = txtPassword.Text;
            //_User.Email = txtEmail.Text;


            string virtualPath = Request.Path.ToString();
            string pageName = virtualPath.Substring(virtualPath.LastIndexOf("/") + 1);

            if (pageName == "MyAccount.aspx")
            {
                var UserId = Session["UserId"];
                int _UserId = Convert.ToInt32(UserId);
                _User.UserId = _UserId;

                List<string> UserOldpasswords = new List<string>();
                UserOldpasswords = _UsersController.GetOldPassword(_UserId);
                _textBox = this.FindControl("txtOldPassword") as TextBox;
                string OldPassword = _textBox.Text;
                string UserOldpassword = "";
                if (UserOldpasswords.Count > 0)
                {
                    UserOldpassword = _Utility.Decrypt(UserOldpasswords[0]);
                }


                if (UserOldpassword == OldPassword)
                {
                    _UsersController.PutUser(_UserId, _User);
                    labelCreateUser.Text = "User account updated";
                    labelCreateUser.ForeColor = System.Drawing.Color.Green;
                    Response.Redirect("MyAccount.aspx");
                }
                else
                {
                    labelCreateUser.Text = "Wrong password";
                    labelCreateUser.ForeColor = System.Drawing.Color.Red;
                }
                
            }
            else if (pageName == "Register.aspx")
            {
                //_User.Friends = "";
                //_User.FriendsInvRecieved = "";
                //_User.FriendsInvSend = "";

                bool emailAlreadyInUse = false;
                List<User> allUsers = _UsersController.GetUsers().ToList();

                foreach (User _user in allUsers)
                {
                    if (_Utility.Decrypt(_user.Email) == _email)
                    {
                        emailAlreadyInUse = true;
                        break;
                    }
                }

                if (emailAlreadyInUse == false)
                {
                    _UsersController.PostUser(_User);
                    labelCreateUser.Text = "Your account is created succesfully. Please login:";
                    labelCreateUser.ForeColor = System.Drawing.Color.Green;
                    hLinkCreateUser.NavigateUrl = "~/Login.aspx";
                    hLinkCreateUser.Text = "Login";
                    _MailHandler.welcomeEMail(_User);
                }
                else if (emailAlreadyInUse == true)
                {
                    labelCreateUser.Text = "This email address is already in use. Please use another email address.";
                    labelCreateUser.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        #endregion methods
    }
}