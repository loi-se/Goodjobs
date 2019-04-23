using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jobhunt.Controllers;
using Jobhunt.Models;
using Jobhunt.Data;
using System.Security.Claims;
using System.Web.Security;

public partial class _Login : System.Web.UI.Page
{
    #region members
    public UsersController _UsersController;
    public User _User;
    public Utility _Utility;
    public MailHandler _MailHandler;

    #endregion members

    #region events
    protected void Page_Load(object sender, EventArgs e)
    {
        _UsersController = new UsersController();
        _User = new User();
        _Utility = new Utility();
        _MailHandler = new MailHandler();
        //UTCreateUser();
    }

    protected void LoginUser(object sender, EventArgs e)
    {

        int UserId = 0;
        string eMail = "";
        string Password = "";
        List<int> UserLoginId = new List<int>();

        TextBox _TextBox = new TextBox();
        _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtEmail") as TextBox;
        eMail = _TextBox.Text;

        _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtPassword") as TextBox;
        Password = _TextBox.Text;

        UserLoginId = _UsersController.GetLoginUserId(_Utility.Encrypt(eMail), _Utility.Encrypt(Password));

        if (UserLoginId.Count > 0)
        {
            UserId = UserLoginId[0];
            Session["UserId"] = UserId;
            _User = _UsersController.GetUser(UserId);
            Session["UserName"] = _Utility.Decrypt(_User.UserName);
            string _email = _Utility.Decrypt(_User.Email);

            FormsAuthentication.SetAuthCookie(_email, true);

            Label _lblWelcome = new Label();
            _lblWelcome = this.Master.FindControl("lblWelcome") as Label;
            _lblWelcome.Text = "Welcome: " + _Utility.Decrypt(_User.UserName);

            Response.Redirect("Dashboard.aspx");

        }
        else
        {
            Label _Label = new Label();
            _Label = this.Master.FindControl("ContentPlaceHolderMain").FindControl("lblLoggedIn") as Label;
            _Label.Text = "Wrong password or username";
            _Label.ForeColor = System.Drawing.Color.Red;
        }


    }

    protected void ShowForgotPasswordPanel(object sender, EventArgs e)
    {
        Panel _Panel = this.Master.FindControl("ContentPlaceHolderMain").FindControl("pForgotPassword") as Panel;
        if (_Panel.Visible == false)
        {
            _Panel.Visible = true;
        } 
        else if (_Panel.Visible == true)
        {
            _Panel.Visible = false;
        }
           
        
    }
    protected void SendForgottenPassword(object sender, EventArgs e)
    {
        List<int> UserLoginId = new List<int>();
        int UserId = 0;
        string eMail = "";
        TextBox _TextBox = this.Master.FindControl("ContentPlaceHolderMain").FindControl("txtForgotPasswordEmail") as TextBox;
        Label _Label = this.Master.FindControl("ContentPlaceHolderMain").FindControl("lblForgotPassword") as Label;
        eMail = _TextBox.Text;


        UserLoginId = _UsersController.GetForgottenPasswordUserId(_Utility.Encrypt(eMail));

        if (UserLoginId.Count > 0)
        {
            UserId = UserLoginId[0];
            _User = _UsersController.GetUser(UserId);

            _MailHandler.forgottenPasswordEmail(_User);
            _Label.Text = "Your password is send to your E-mail.";
            _Label.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            _Label.Text = "This Email address is not in use.";
            _Label.ForeColor = System.Drawing.Color.Red;
        }

    }
    #endregion events
}