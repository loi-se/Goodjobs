using Jobhunt.Controllers;
using Jobhunt.Data;
using Jobhunt.Models;
using Jobhunt.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jobhunt.UserControls
{
    public partial class UCContactsInvitations : System.Web.UI.UserControl
    {
        #region members
        public GridViewUtility _GridViewUtility;
        public JobApplicationsController _JobApplicationsController;
        public UsersController _UsersController;
        public Careers _Careers;
        public Utility _Utility;
        public InvitationHandler _InvitationHandler;


        public int UserId;
        public User User;
        //public string parentPageName;
        private int pIndex = 1;
        #endregion

        #region events
        protected void Page_Load(object sender, EventArgs e)
        {
            //foundUsers = new List<User>();
            _GridViewUtility = new GridViewUtility();
            _JobApplicationsController = new JobApplicationsController();
            _UsersController = new UsersController();
            _Careers = new Careers();
            _Utility = new Utility();
            _InvitationHandler = new InvitationHandler();

            UserId = Convert.ToInt32(Session["UserId"]);
            User = _UsersController.GetUser(UserId);

            ApplicantsGV.RowDataBound += new GridViewRowEventHandler(ApplicantsGV_RowDataBound);

            if (!this.IsPostBack)
            {
                //0-Accept button:
                ButtonField buttonField = new ButtonField();
                buttonField.HeaderText = "";
                buttonField.ItemStyle.VerticalAlign = VerticalAlign.Middle;
                ApplicantsGV.Columns.Add(buttonField);

                // Deny button:
                buttonField = new ButtonField();
                buttonField.HeaderText = "";
                buttonField.ItemStyle.VerticalAlign = VerticalAlign.Middle;
                ApplicantsGV.Columns.Add(buttonField);


                BoundField boundField = new BoundField();
                boundField.HeaderText = "";
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = 1;
                boundField.DataField = "SenderId";
                ApplicantsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "";
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = 1;
                boundField.DataField = "ReceiverId";
                ApplicantsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "";
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = 1;
                boundField.DataField = "GuidId";
                ApplicantsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "Status";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "InvStatus";
                ApplicantsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "";
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "From";
                ApplicantsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "Name";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "ApplName";
                ApplicantsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "Main career field";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "ApplMainCareerField";
                ApplicantsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "Sub career field";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "ApplSubCareerField";
                ApplicantsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "Search tags";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "ApplSearchTags";
                ApplicantsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "LinkedIn";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "ApplLinkedIn";
                ApplicantsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "Invitation date";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "InvitationDate";
                ApplicantsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "Number of job applications";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "nofJobAppl";
                ApplicantsGV.Columns.Add(boundField);

                fillddlCustomPagerItemSelected();
            }

            if (ViewState["GridPageIndex"] != null)
            {
                pIndex = Convert.ToInt32(ViewState["GridPageIndex"]);
            }

            pnlCustomPager.Visible = customPagerVisible();

            ShowRecievedInvitationsTable(pIndex);
        }

        private void ApplicantsGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

                e.Row.Cells[0].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[0].BorderStyle = BorderStyle.None;
                e.Row.Cells[1].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[1].BorderStyle = BorderStyle.None;
                e.Row.Cells[2].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[2].BorderStyle = BorderStyle.None;
                e.Row.Cells[3].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[3].BorderStyle = BorderStyle.None;
                e.Row.Cells[4].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[4].BorderStyle = BorderStyle.None;
                e.Row.Cells[5].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[6].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[7].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[8].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[9].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[10].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[11].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[12].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[13].BackColor = _GridViewUtility.HeaderBackColor;
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TextBox txtbox;
                HyperLink hp;
                //hp =  new HyperLink();
                string navigateUrlStart = "";

                string status = (e.Row.DataItem as DataRowView).Row["InvStatus"].ToString();

                Button btn_UCCIAccept = new Button();
                btn_UCCIAccept.ID = "btn_UCCIAccept";
                btn_UCCIAccept.Text = "Accept";
                btn_UCCIAccept.ToolTip = "Accept invitation";
                btn_UCCIAccept.OnClientClick = "return confirm('Are you sure you want to accept this invitation?')";
                btn_UCCIAccept.Click += new EventHandler(btn_UCCIAccept_Click);
                //btn_UCContacts.OnClientClick = "return false;";
                //btn_UCContacts.OnClientClick += new EventHandler(btn_UCContacts_Click);
                btn_UCCIAccept.Width = 80;
                btn_UCCIAccept.Height = 25;
                if (status == "Accepted")
                {
                    btn_UCCIAccept.BorderWidth = 3;
                }

                if (status != "Send")
                {
                    btn_UCCIAccept.Enabled = false;
                }

                e.Row.Cells[0].Controls.Add(btn_UCCIAccept);
                e.Row.Cells[0].BackColor = _GridViewUtility.GridViewCellBackColor;
                e.Row.Cells[0].VerticalAlign = VerticalAlign.Top;
                e.Row.Cells[0].BorderColor = _GridViewUtility.GridViewCellBorderColor;

                Button btn_UCCIDeny = new Button();
                btn_UCCIDeny = new Button();
                btn_UCCIDeny.ID = "btn_UCCIDeny";
                btn_UCCIDeny.Text = "Deny";
                btn_UCCIDeny.ToolTip = "Deny invitation";
                btn_UCCIDeny.OnClientClick = "return confirm('Are you sure you want to deny this invitation?')";
                btn_UCCIDeny.Click += new EventHandler(btn_UCCIDeny_Click);
                //btn_UCContacts.OnClientClick = "return false;";
                //btn_UCContacts.OnClientClick += new EventHandler(btn_UCContacts_Click);
                btn_UCCIDeny.Width = 80;
                btn_UCCIDeny.Height = 25;

                if (status == "Denied")
                {
                    btn_UCCIDeny.BorderWidth = 3;
                }

                if (status != "Send")
                {
                    btn_UCCIDeny.Enabled = false;
                }

                if (status == "Accepted")
                {
                    btn_UCCIDeny.BorderColor = System.Drawing.Color.Black;
                    btn_UCCIDeny.OnClientClick = "return confirm('Are you sure you want to withdraw this invitation? This contact will be removed from your contacts and vice versa.')";
                    btn_UCCIDeny.BorderWidth = 1;
                    btn_UCCIDeny.Text = "Withdraw";
                    btn_UCCIDeny.Enabled = true;
                }
            
                e.Row.Cells[1].Controls.Add(btn_UCCIDeny);
                e.Row.Cells[1].BackColor = _GridViewUtility.GridViewCellBackColor;
                e.Row.Cells[1].VerticalAlign = VerticalAlign.Top;
                e.Row.Cells[1].BorderColor = _GridViewUtility.GridViewCellBorderColor;

                Label lbl = new Label();
                lbl.Text = (e.Row.DataItem as DataRowView).Row["SenderId"].ToString();
                lbl.Visible = false;
                lbl.Width = 0;
                e.Row.Cells[2].BackColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[2].Controls.Add(lbl);
                e.Row.Cells[2].BorderStyle = BorderStyle.None;
                e.Row.Cells[2].BorderColor = _GridViewUtility.GridViewCellBorderColor;

                lbl = new Label();
                lbl.Text = (e.Row.DataItem as DataRowView).Row["ReceiverId"].ToString();
                lbl.Visible = false;
                lbl.Width = 0;
                e.Row.Cells[3].BackColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[3].Controls.Add(lbl);
                e.Row.Cells[3].BorderStyle = BorderStyle.None;
                e.Row.Cells[3].BorderColor = _GridViewUtility.GridViewCellBorderColor;

                lbl = new Label();
                lbl.Text = (e.Row.DataItem as DataRowView).Row["GuidId"].ToString();
                lbl.Visible = false;
                lbl.Width = 0;
                e.Row.Cells[4].BackColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[4].Controls.Add(lbl);
                e.Row.Cells[4].BorderStyle = BorderStyle.None;
                e.Row.Cells[4].BorderColor = _GridViewUtility.GridViewCellBorderColor;

                lbl = new Label();
                lbl.Text = (e.Row.DataItem as DataRowView).Row["InvStatus"].ToString();
                lbl.BackColor = _GridViewUtility.getStatusColor(status);
                lbl.Width = 80;
                lbl.Font.Name = "Arial";
                lbl.Font.Size = 9;
                lbl.ForeColor = Color.WhiteSmoke;
                e.Row.Cells[5].Controls.Add(lbl);
                e.Row.Cells[5].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[5].BackColor = _GridViewUtility.GridViewCellBackColor;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;

                lbl = new Label();
                lbl.Text = (e.Row.DataItem as DataRowView).Row["From"].ToString();
                lbl.Width = 60;
                lbl.Font.Name = "Arial";
                lbl.Font.Size = 9;
                lbl.Font.Bold = true;

                e.Row.Cells[6].Controls.Add(lbl);
                e.Row.Cells[6].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[6].BackColor = _GridViewUtility.GridViewCellBackColor;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;

                txtbox = _GridViewUtility.labelTextboxInv((e.Row.DataItem as DataRowView).Row["ApplName"].ToString(), 75);
                e.Row.Cells[7].Controls.Add(txtbox);
                e.Row.Cells[7].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[7].BackColor = _GridViewUtility.GridViewCellBackColor;

                txtbox = _GridViewUtility.labelTextboxInv((e.Row.DataItem as DataRowView).Row["ApplMainCareerField"].ToString(), 120);
                e.Row.Cells[8].Controls.Add(txtbox);
                e.Row.Cells[8].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[8].BackColor = _GridViewUtility.GridViewCellBackColor;

                txtbox = _GridViewUtility.labelTextboxInv((e.Row.DataItem as DataRowView).Row["ApplSubCareerField"].ToString(), 120);
                e.Row.Cells[9].Controls.Add(txtbox);
                e.Row.Cells[9].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[9].BackColor = _GridViewUtility.GridViewCellBackColor;

                txtbox = _GridViewUtility.labelTextboxInv((e.Row.DataItem as DataRowView).Row["ApplSearchTags"].ToString(), 120);
                e.Row.Cells[10].Controls.Add(txtbox);
                e.Row.Cells[10].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[10].BackColor = _GridViewUtility.GridViewCellBackColor;


                hp = new HyperLink();
                hp.Text = (e.Row.DataItem as DataRowView).Row["ApplLinkedIn"].ToString();
                navigateUrlStart = _GridViewUtility.checkNavigateUrlStart(hp.Text);
                hp.NavigateUrl = navigateUrlStart + (e.Row.DataItem as DataRowView).Row["ApplLinkedIn"].ToString();
                hp.Width = 150;
                hp.Style.Add("style", "width:200px;word-wrap:break-word");
                hp.Font.Size = new FontUnit(9);
                hp.Target = "_blank";
                hp.ForeColor = System.Drawing.Color.FromArgb(int.Parse("#0099FF".Replace("#", ""),
                        System.Globalization.NumberStyles.AllowHexSpecifier));

                e.Row.Cells[11].Controls.Add(hp);
                e.Row.Cells[11].BackColor = _GridViewUtility.GridViewCellBackColor;
                e.Row.Cells[11].BorderColor = _GridViewUtility.GridViewCellBorderColor;

                txtbox = _GridViewUtility.labelTextboxInv((e.Row.DataItem as DataRowView).Row["InvitationDate"].ToString(), 120);
                e.Row.Cells[12].Controls.Add(txtbox);
                e.Row.Cells[12].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[12].BackColor = _GridViewUtility.GridViewCellBackColor;

                txtbox = _GridViewUtility.labelTextboxInv((e.Row.DataItem as DataRowView).Row["nofJobAppl"].ToString(), 120);
                e.Row.Cells[13].Controls.Add(txtbox);
                e.Row.Cells[13].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[13].BackColor = _GridViewUtility.GridViewCellBackColor;

            }
        }


        // Invitation is accepted:
        protected void btn_UCCIAccept_Click(object sender, EventArgs e)
        {
            _InvitationHandler = new InvitationHandler();
            Session["UserIdChoosenContact"] = null;
            GridViewRow uCContactsGVRow = (GridViewRow)(sender as Control).Parent.Parent;

            int InvitationSenderID = Convert.ToInt32(uCContactsGVRow.Cells[2].Text);
            int InvitationReceiverID = Convert.ToInt32(uCContactsGVRow.Cells[3].Text);
            string invStatus = uCContactsGVRow.Cells[5].Text;
            string GuidId = uCContactsGVRow.Cells[4].Text;

            int userId = UserId;

            if (this.Parent.Page.AppRelativeVirtualPath == "~/ContactsInvitations.aspx")
            {
                string updatedInvitation = "";
                string contacts = "";
                updatedInvitation = _InvitationHandler.UpdateInvitation(InvitationSenderID, InvitationReceiverID, "A", "FriendsInvSend", "update", GuidId.ToString());
                User UserToUpdate = _UsersController.GetUser(InvitationSenderID);
                UserToUpdate.FriendsInvSend = _Utility.Encrypt(updatedInvitation);
                _UsersController.PutUser(UserToUpdate.UserId, UserToUpdate);
                updatedInvitation = _InvitationHandler.UpdateInvitation(InvitationSenderID, InvitationReceiverID, "A", "FriendsInvRecieved", "update", GuidId.ToString());
                UserToUpdate = _UsersController.GetUser(InvitationReceiverID);
                UserToUpdate.FriendsInvRecieved = _Utility.Encrypt(updatedInvitation);
                _UsersController.PutUser(UserToUpdate.UserId, UserToUpdate);

                // Contacten van de ontvanger bijwerken:
                contacts = _InvitationHandler.AddReceiverContacts(InvitationSenderID, InvitationReceiverID);
                UserToUpdate = _UsersController.GetUser(InvitationReceiverID);
                UserToUpdate.Friends = _Utility.Encrypt(contacts);
                _UsersController.PutUser(UserToUpdate.UserId, UserToUpdate);
                // Contacten van de verzender bijwerken:
                contacts = _InvitationHandler.AddSenderContacts(InvitationSenderID, InvitationReceiverID);
                UserToUpdate = _UsersController.GetUser(InvitationSenderID);
                UserToUpdate.Friends = _Utility.Encrypt(contacts);
                _UsersController.PutUser(UserToUpdate.UserId, UserToUpdate);
            }

            //User user1 = _UsersController.GetUser(InvitationSenderID);
            //User user2 = _UsersController.GetUser(InvitationReceiverID);

            //// BUG: critical bug accept not working first click: parent page reload??:
            //string sendInvitationSender = user1.FriendsInvSend;
            //string sendInvitationReceiver = user2.FriendsInvRecieved;
            Server.Transfer("ContactsInvitations.aspx");
         
        }

        protected void btn_UCCIDeny_Click(object sender, EventArgs e)
        {
            _InvitationHandler = new InvitationHandler();
            Session["UserIdChoosenContact"] = null;
            GridViewRow uCContactsGVRow = (GridViewRow)(sender as Control).Parent.Parent;
            int InvitationSenderID = Convert.ToInt32(uCContactsGVRow.Cells[2].Text);
            string GuidId = uCContactsGVRow.Cells[4].Text;
            int userId = UserId;

            if (this.Parent.Page.AppRelativeVirtualPath == "~/ContactsInvitations.aspx")
            {
                string updatedInvitation = "";

                Button _sender = (Button)sender;
                if (_sender.Text == "Deny")
                 {
                    updatedInvitation = _InvitationHandler.UpdateInvitation(InvitationSenderID, userId, "D", "FriendsInvSend", "update", GuidId.ToString());
                    User UserToUpdate = _UsersController.GetUser(InvitationSenderID);
                    UserToUpdate.FriendsInvSend = _Utility.Encrypt(updatedInvitation);
                    _UsersController.PutUser(UserToUpdate.UserId, UserToUpdate);


                    updatedInvitation = _InvitationHandler.UpdateInvitation(InvitationSenderID, userId, "D", "FriendsInvRecieved", "update", GuidId.ToString());
                    UserToUpdate = _UsersController.GetUser(userId);
                    UserToUpdate.FriendsInvRecieved = _Utility.Encrypt(updatedInvitation);
                    _UsersController.PutUser(UserToUpdate.UserId, UserToUpdate);
                }
                else if (_sender.Text == "Withdraw")
                {
               
                    updatedInvitation = _InvitationHandler.UpdateInvitation(InvitationSenderID, userId, "W", "FriendsInvSend", "update", GuidId.ToString());
                    User UserToUpdate = _UsersController.GetUser(InvitationSenderID);
                    UserToUpdate.FriendsInvSend = _Utility.Encrypt(updatedInvitation);
                    _UsersController.PutUser(UserToUpdate.UserId, UserToUpdate);

                    updatedInvitation = _InvitationHandler.UpdateInvitation(InvitationSenderID, userId, "W", "FriendsInvRecieved", "update", GuidId.ToString());
                    UserToUpdate = _UsersController.GetUser(userId);
                    UserToUpdate.FriendsInvRecieved = _Utility.Encrypt(updatedInvitation);
                    _UsersController.PutUser(UserToUpdate.UserId, UserToUpdate);

                    string updatedContacts = "";
                    updatedContacts = _InvitationHandler.RemoveSenderContact(InvitationSenderID, userId);
                    UserToUpdate = _UsersController.GetUser(InvitationSenderID);
                    UserToUpdate.Friends = _Utility.Encrypt(updatedContacts);
                    _UsersController.PutUser(UserToUpdate.UserId, UserToUpdate);

                    updatedContacts = _InvitationHandler.RemoveReceiverContact(InvitationSenderID, userId);
                    UserToUpdate = _UsersController.GetUser(userId);
                    UserToUpdate.Friends = _Utility.Encrypt(updatedContacts);
                    _UsersController.PutUser(UserToUpdate.UserId, UserToUpdate);

                }
            }

            Server.Transfer("ContactsInvitations.aspx");
        }

        protected void ddlCustomPagerItemSelected(object sender, EventArgs e)
        {
            int selectedPage = Convert.ToInt32(ddlCustomPager.SelectedItem.Text.ToString());
            ViewState["GridPageIndex"] = selectedPage;
            pIndex = selectedPage;
            ShowRecievedInvitationsTable(pIndex);
        }

        #endregion

        #region methods

        public int customPagerNumberOfResults()
        {
            int foundContactInv = 0;
            string[] MyRecievedInvitations = null;
            if (_Utility.Decrypt(User.FriendsInvRecieved) != null)
            {
                MyRecievedInvitations = _Utility.Decrypt(User.FriendsInvRecieved).Split(',');
                foundContactInv = MyRecievedInvitations.Count();
            }
            
            return foundContactInv;
        }

        public bool customPagerVisible()
        {
            bool visible = true;
            if (customPagerNumberOfResults() <= _GridViewUtility.invpageSize)
            {
                visible = false;
            }
            return visible;
        }

        public void fillddlCustomPagerItemSelected()
        {
            ddlCustomPager.Items.Clear();
            int numberOfResults = customPagerNumberOfResults();
            int numberOfPages = (int)Math.Ceiling(Convert.ToDouble(customPagerNumberOfResults()) / Convert.ToDouble(_GridViewUtility.invpageSize));

            for (int i = 1; i <= numberOfPages; i++)
            {
                ddlCustomPager.Items.Add(i.ToString());
            }
        }
        public void ShowRecievedInvitationsTable(int pageIndex)
        {

            int pagerMinRange = 1;
            int pagerMaxRange = 1;
            if (pageIndex == 1)
            {
                pagerMinRange = 1;
                pagerMaxRange = pagerMinRange + (_GridViewUtility.invpageSize - 1);
            }
            else if (pageIndex > 1)
            {
                pagerMinRange = (pageIndex - 1) * _GridViewUtility.invpageSize;
                pagerMaxRange = pagerMinRange + (_GridViewUtility.invpageSize - 1);
            }
            lTotalPages.Text = Math.Ceiling((Convert.ToDouble(customPagerNumberOfResults()) / Convert.ToDouble(_GridViewUtility.invpageSize))).ToString() + ")";

            if (_Utility.Decrypt(User.FriendsInvRecieved) != null)
            {
                String MyRecievedInvitations = _Utility.Decrypt(User.FriendsInvRecieved);
               // Dictionary<User, DateTime> UsersWhoHaveSendMeInvitations = new Dictionary<User, DateTime>();

                string[] myRecievedInvitations = MyRecievedInvitations.Split(',');

                List<string> myRecievedInvitationsList = new List<string>();

                for (int i = myRecievedInvitations.Count() - 1; i >= 0; i--)
                {
                    string invitation = myRecievedInvitations[i];
                    myRecievedInvitationsList.Add(invitation);
                }

                if (myRecievedInvitationsList.Count() > 0)
                {


                    DataTable dt = new DataTable();

                    dt.Columns.Add(new DataColumn("SenderId", typeof(Int32)));
                    dt.Columns.Add(new DataColumn("ReceiverId", typeof(Int32)));
                    dt.Columns.Add(new DataColumn("GuidId", typeof(String)));
                    dt.Columns.Add(new DataColumn("InvStatus", typeof(String)));
                    dt.Columns.Add(new DataColumn("From", typeof(String)));
                    dt.Columns.Add(new DataColumn("ApplName", typeof(String)));
                    dt.Columns.Add(new DataColumn("ApplMainCareerField", typeof(String)));
                    dt.Columns.Add(new DataColumn("ApplSubCareerField", typeof(String)));
                    dt.Columns.Add(new DataColumn("ApplSearchTags", typeof(String)));
                    dt.Columns.Add(new DataColumn("ApplLinkedIn", typeof(String)));
                    dt.Columns.Add(new DataColumn("InvitationDate", typeof(String)));
                    dt.Columns.Add(new DataColumn("nofJobAppl", typeof(String)));


                    int i = 1;
                    int counter = 1;
                    foreach (string recievedInvitation in myRecievedInvitationsList)
                    {

                        string[] MyRecievedInvs = recievedInvitation.Split(':');

                        if (MyRecievedInvs != null && MyRecievedInvs.Count() > 0 && !String.IsNullOrEmpty(MyRecievedInvs[0]))
                        {
                            string status = MyRecievedInvs[0];
                            string statusPresentation = "";
                           
                            int senderId = Convert.ToInt32(MyRecievedInvs[1]);
                            int receiverId = Convert.ToInt32(MyRecievedInvs[2]);
                            string invDateTimeString = MyRecievedInvs[3];
                            string InvGuidId = MyRecievedInvs[4];
                            string inputFormat = "dd/MM/yyyy";
                            DateTime invDateTime = DateTime.ParseExact(invDateTimeString, inputFormat, CultureInfo.InvariantCulture);
                            User FoundUser = _UsersController.GetUser(senderId);

                            if (status == "S")
                            {
                                statusPresentation = "Send";
                            }
                            else if (status == "A")
                            {
                                statusPresentation = "Accepted";
                            }
                            else if (status == "D")
                            {
                                statusPresentation = "Denied";
                            }
                            else if (status == "W")
                            {
                                statusPresentation = "Withdrawn";
                            }

                            DataRow dr = dt.NewRow();
                            if (counter >= pagerMinRange && counter <= pagerMaxRange)
                            {


                                //dr["Edit"] = "";
                                //dr["Delete"] = "";
                                //dr["View"] = "";
                                dr["InvStatus"] = statusPresentation;
                                dr["From"] = "  Sender:";
                                dr["SenderId"] = FoundUser.UserId;
                                dr["ReceiverId"] = receiverId;
                                dr["GuidId"] = InvGuidId.ToString();

                                dr["ApplName"] = _Utility.Decrypt(FoundUser.FirstName) + " " + _Utility.Decrypt(FoundUser.LastName);
                                int mainCareerId = Convert.ToInt32(_Utility.Decrypt(FoundUser.MainCareer));
                                Dictionary<int, string> MainCareers = _Careers.GetMainCareers();

                                dr["ApplMainCareerField"] = MainCareers[mainCareerId];

                                dr["ApplSubCareerField"] = _Utility.Decrypt(FoundUser.SubCareer);
                                dr["ApplSearchTags"] = _Utility.Decrypt(FoundUser.SearchTag);
                                dr["ApplLinkedIn"] = _Utility.Decrypt(FoundUser.LinkedIn);
                                dr["InvitationDate"] = invDateTime.ToString();
                                dr["nofJobAppl"] = _GridViewUtility.numberOfJobApplications(senderId);

                                dt.Rows.Add(dr);
                                i = i + 1;
                            }
                            counter = counter + 1;
                        }
                    }
                    ApplicantsGV.DataSource = dt;
                    ApplicantsGV.DataBind();
                }
                else
                {
                    if (this.Parent.Page.AppRelativeVirtualPath == "~/ContactsInvitations.aspx")
                    {
                        lContactsInvitations.Text = "You have no contact invitations yet.";
                        lContactsInvitations.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
            else
            {
                if (this.Parent.Page.AppRelativeVirtualPath == "~/ContactsInvitations.aspx")
                {
                    lContactsInvitations.Text = "You have no contact invitations yet.";
                    lContactsInvitations.ForeColor = System.Drawing.Color.Green;
                }

            }
        }
        #endregion


    }
}