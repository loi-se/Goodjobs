using Jobhunt.Controllers;
using Jobhunt.Data;
using Jobhunt.Models;
using Jobhunt.UserControls;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Jobhunt.UserControls
{
    public partial class UCContactsInvitationsSend : System.Web.UI.UserControl
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
                boundField.DataField = "Status";
                ApplicantsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "";
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "To";
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

            ShowSendInvitationsTable(pIndex);
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
                e.Row.Cells[5].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[6].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[7].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[8].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[9].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[10].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[11].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[12].BackColor = _GridViewUtility.HeaderBackColor;
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TextBox txtbox;
                HyperLink hp;
                //hp =  new HyperLink();
                string navigateUrlStart = "";
                string status = (e.Row.DataItem as DataRowView).Row["Status"].ToString();

                Button btn_UCCIWithdraw = new Button();
                btn_UCCIWithdraw.ID = "btn_UCCIWithdraw";
                btn_UCCIWithdraw.Text = "Withdraw";
                btn_UCCIWithdraw.ToolTip = "Accept invitation";
                btn_UCCIWithdraw.OnClientClick = "return confirm('Are you sure you want to withdraw this invitation? This contact will be removed from your contacts and vice versa.')";
                btn_UCCIWithdraw.Click += new EventHandler(btn_UCCIWithdraw_Click);

                btn_UCCIWithdraw.Width = 80;
                btn_UCCIWithdraw.Height = 25;

                if (status == "Withdrawn" || status == "Denied")
                {
                    btn_UCCIWithdraw.Enabled = false;
                }

                e.Row.Cells[0].Controls.Add(btn_UCCIWithdraw);
                e.Row.Cells[0].BackColor = _GridViewUtility.GridViewCellBackColor;
                e.Row.Cells[0].VerticalAlign = VerticalAlign.Top;
                e.Row.Cells[0].BorderColor = _GridViewUtility.GridViewCellBorderColor;

                Label lbl = new Label();
                lbl.Text = (e.Row.DataItem as DataRowView).Row["SenderId"].ToString();
                lbl.Visible = false;
                lbl.Width = 0;
                e.Row.Cells[1].BackColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[1].Controls.Add(lbl);
                e.Row.Cells[1].BorderStyle = BorderStyle.None;
                e.Row.Cells[1].BorderColor = _GridViewUtility.GridViewCellBorderColor;

                lbl = new Label();
                lbl.Text = (e.Row.DataItem as DataRowView).Row["ReceiverId"].ToString();
                lbl.Visible = false;
                lbl.Width = 0;
                e.Row.Cells[2].BackColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[2].Controls.Add(lbl);
                e.Row.Cells[2].BorderStyle = BorderStyle.None;
                e.Row.Cells[2].BorderColor = _GridViewUtility.GridViewCellBorderColor;

                lbl = new Label();
                lbl.Text = (e.Row.DataItem as DataRowView).Row["GuidId"].ToString();
                lbl.Visible = false;
                lbl.Width = 0;
                e.Row.Cells[3].BackColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[3].Controls.Add(lbl);
                e.Row.Cells[3].BorderStyle = BorderStyle.None;
                e.Row.Cells[3].BorderColor = _GridViewUtility.GridViewCellBorderColor;

                lbl = new Label();
                lbl.Text = (e.Row.DataItem as DataRowView).Row["Status"].ToString();
                lbl.BackColor = _GridViewUtility.getStatusColor(status);
                lbl.Width = 80;
                lbl.Font.Name = "Arial";
                lbl.Font.Size = 9;
                lbl.ForeColor = Color.WhiteSmoke;
                e.Row.Cells[4].Controls.Add(lbl);
                e.Row.Cells[4].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[4].BackColor = _GridViewUtility.GridViewCellBackColor;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;


                lbl = new Label();
                lbl.Text = (e.Row.DataItem as DataRowView).Row["To"].ToString();
                lbl.Width = 75;
                lbl.Font.Name = "Arial";
                lbl.Font.Size = 9;
                lbl.Font.Bold = true;

                e.Row.Cells[5].Controls.Add(lbl);
                e.Row.Cells[5].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[5].BackColor = _GridViewUtility.GridViewCellBackColor;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;

                txtbox = _GridViewUtility.labelTextboxInv((e.Row.DataItem as DataRowView).Row["ApplName"].ToString(), 75);
                e.Row.Cells[6].Controls.Add(txtbox);
                e.Row.Cells[6].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[6].BackColor = _GridViewUtility.GridViewCellBackColor;

                txtbox = _GridViewUtility.labelTextboxInv((e.Row.DataItem as DataRowView).Row["ApplMainCareerField"].ToString(), 120);
                e.Row.Cells[7].Controls.Add(txtbox);
                e.Row.Cells[7].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[7].BackColor = _GridViewUtility.GridViewCellBackColor;

                txtbox = _GridViewUtility.labelTextboxInv((e.Row.DataItem as DataRowView).Row["ApplSubCareerField"].ToString(), 120);
                e.Row.Cells[8].Controls.Add(txtbox);
                e.Row.Cells[8].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[8].BackColor = _GridViewUtility.GridViewCellBackColor;

                txtbox = _GridViewUtility.labelTextboxInv((e.Row.DataItem as DataRowView).Row["ApplSearchTags"].ToString(), 120);
                e.Row.Cells[9].Controls.Add(txtbox);
                e.Row.Cells[9].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[9].BackColor = _GridViewUtility.GridViewCellBackColor;



                hp = new HyperLink();
                hp.Text = (e.Row.DataItem as DataRowView).Row["ApplLinkedIn"].ToString();
                navigateUrlStart = _GridViewUtility.checkNavigateUrlStart(hp.Text);
                hp.NavigateUrl = navigateUrlStart + (e.Row.DataItem as DataRowView).Row["ApplLinkedIn"].ToString();
                hp.Width = 200;
                hp.Style.Add("style", "width:200px;word-wrap:break-word");
                hp.Font.Size = new FontUnit(9);
                hp.Target = "_blank";
                hp.ForeColor = System.Drawing.Color.FromArgb(int.Parse("#0099FF".Replace("#", ""),
                        System.Globalization.NumberStyles.AllowHexSpecifier));
                e.Row.Cells[10].Controls.Add(hp);
                e.Row.Cells[10].BackColor = _GridViewUtility.GridViewCellBackColor;
                e.Row.Cells[10].BorderColor = _GridViewUtility.GridViewCellBorderColor;

                txtbox = _GridViewUtility.labelTextboxInv((e.Row.DataItem as DataRowView).Row["InvitationDate"].ToString(), 120);
                e.Row.Cells[11].Controls.Add(txtbox);
                e.Row.Cells[11].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[11].BackColor = _GridViewUtility.GridViewCellBackColor;

                txtbox = _GridViewUtility.labelTextboxInv((e.Row.DataItem as DataRowView).Row["nofJobAppl"].ToString(), 120);
                e.Row.Cells[12].Controls.Add(txtbox);
                e.Row.Cells[12].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[12].BackColor = _GridViewUtility.GridViewCellBackColor;

            }
        }


        protected void btn_UCCIWithdraw_Click(object sender, EventArgs e)
        {
            //Session["UserIdChoosenContact"] = null;
            _InvitationHandler = new InvitationHandler();
            GridViewRow uCContactsGVRow = (GridViewRow)(sender as Control).Parent.Parent;
            int senderId = Convert.ToInt32(uCContactsGVRow.Cells[1].Text);
            int receiverId = Convert.ToInt32(uCContactsGVRow.Cells[2].Text);
            string GuidId = uCContactsGVRow.Cells[3].Text;
            int userId = UserId;

            if (this.Parent.Page.AppRelativeVirtualPath == "~/ContactsInvitations.aspx")
            {
                string updatedInvitation = "";
                string updatedContacts = "";
                updatedInvitation = _InvitationHandler.UpdateInvitation(senderId, receiverId, "W", "FriendsInvSend", "update", GuidId.ToString());
                User UserToUpdate = _UsersController.GetUser(senderId);
                UserToUpdate.FriendsInvSend = _Utility.Encrypt(updatedInvitation);
                _UsersController.PutUser(UserToUpdate.UserId, UserToUpdate);

                updatedInvitation = _InvitationHandler.UpdateInvitation(senderId, receiverId, "W", "FriendsInvRecieved", "update", GuidId.ToString());
                UserToUpdate = _UsersController.GetUser(receiverId);
                UserToUpdate.FriendsInvRecieved = _Utility.Encrypt(updatedInvitation);
                _UsersController.PutUser(UserToUpdate.UserId, UserToUpdate);

                updatedContacts = _InvitationHandler.RemoveSenderContact(senderId, receiverId);
                UserToUpdate = _UsersController.GetUser(senderId);
                UserToUpdate.Friends = _Utility.Encrypt(updatedContacts);
                _UsersController.PutUser(UserToUpdate.UserId, UserToUpdate);

                updatedContacts = _InvitationHandler.RemoveReceiverContact(senderId, receiverId);
                UserToUpdate = _UsersController.GetUser(receiverId);
                UserToUpdate.Friends = _Utility.Encrypt(updatedContacts);
                _UsersController.PutUser(UserToUpdate.UserId, UserToUpdate);
            }
            Server.Transfer("ContactsInvitations.aspx");
        }

        protected void ddlCustomPagerItemSelected(object sender, EventArgs e)
        {
            int selectedPage = Convert.ToInt32(ddlCustomPager.SelectedItem.Text.ToString());
            ViewState["GridPageIndex"] = selectedPage;
            pIndex = selectedPage;
            ShowSendInvitationsTable(pIndex);
        }
        #endregion

        #region methods
        public bool customPagerVisible()
        {
            bool visible = true;
            if (customPagerNumberOfResults() <= _GridViewUtility.invpageSize)
            {
                visible = false;
            }
            return visible;
        }
        public int customPagerNumberOfResults()
        {
            int foundContactInv = 0;
            string[] MySendInvitations = null;
            if (_Utility.Decrypt(User.FriendsInvSend) != null)
            {
                MySendInvitations = _Utility.Decrypt(User.FriendsInvSend).Split(',');
                foundContactInv = MySendInvitations.Count();
            }
            return foundContactInv;
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

        public void ShowSendInvitationsTable(int pageIndex)
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

            if (_Utility.Decrypt(User.FriendsInvSend) != null)
            {
                String MySendInvitations = _Utility.Decrypt(User.FriendsInvSend);
                Dictionary<User, DateTime> UsersWhoIhaveSendAnInvitation = new Dictionary<User, DateTime>();

                string[] mySendInvitations = MySendInvitations.Split(',');
                List<string> mySendInvitationsList = new List<string>();

                for (int i = mySendInvitations.Count() - 1; i >= 0; i--)
                {
                    string invitation = mySendInvitations[i];
                    mySendInvitationsList.Add(invitation);
                }
             
                if (mySendInvitationsList.Count() > 0)
                {


                    DataTable dt = new DataTable();

                    dt.Columns.Add(new DataColumn("SenderId", typeof(Int32)));
                    dt.Columns.Add(new DataColumn("ReceiverId", typeof(Int32)));
                    dt.Columns.Add(new DataColumn("GuidId", typeof(String)));
                    dt.Columns.Add(new DataColumn("Status", typeof(String)));
                    dt.Columns.Add(new DataColumn("To", typeof(String)));
                    dt.Columns.Add(new DataColumn("ApplName", typeof(String)));
                    dt.Columns.Add(new DataColumn("ApplMainCareerField", typeof(String)));
                    dt.Columns.Add(new DataColumn("ApplSubCareerField", typeof(String)));
                    dt.Columns.Add(new DataColumn("ApplSearchTags", typeof(String)));
                    dt.Columns.Add(new DataColumn("ApplLinkedIn", typeof(String)));
                    dt.Columns.Add(new DataColumn("InvitationDate", typeof(String)));
                    dt.Columns.Add(new DataColumn("nofJobAppl", typeof(String)));

                    int i = 1;
                    int counter = 1;
                    foreach (string sendInvitation in mySendInvitationsList)
                    {

                        string[] MySendInvs = sendInvitation.Split(':');

                        if (MySendInvs != null && MySendInvs.Count() > 1)
                        {
                            string SenderId = MySendInvs[1];
                            string ReceiverId = MySendInvs[2];
                            string InvGuidId = MySendInvs[4];
                            User FoundUser = _UsersController.GetUser(Convert.ToInt32(ReceiverId));
                            string status = MySendInvs[0];
                            string invSendDateTimeString = MySendInvs[3];
                            string inputFormat = "dd/MM/yyyy";
                            DateTime invSendDateTime = DateTime.ParseExact(invSendDateTimeString, inputFormat, CultureInfo.InvariantCulture);

                            DataRow dr = dt.NewRow();
                            if (counter >= pagerMinRange && counter <= pagerMaxRange)
                            {
                                //dr["Edit"] = "";
                                //dr["Delete"] = "";
                                //dr["View"] = "";
                                dr["SenderId"] = SenderId;
                                dr["ReceiverId"] = ReceiverId;
                                dr["GuidId"] = InvGuidId;

                                string invitationStatus = status;
                                string statusPresentation = "";
                                if (invitationStatus == "S")
                                {
                                    statusPresentation = "Send";
                                }
                                else if (invitationStatus == "A")
                                {
                                    statusPresentation = "Accepted";
                                }
                                else if (invitationStatus == "D")
                                {
                                    statusPresentation = "Denied";
                                }
                                else if (invitationStatus == "W")
                                {
                                    statusPresentation = "Withdrawn";
                                }

                                dr["Status"] = statusPresentation;
                                dr["To"] = "  Receiver:";
                                dr["ApplName"] = _Utility.Decrypt(FoundUser.FirstName) + " " + _Utility.Decrypt(FoundUser.LastName);
                                int mainCareerId = Convert.ToInt32(_Utility.Decrypt(FoundUser.MainCareer));
                                Dictionary<int, string> MainCareers = _Careers.GetMainCareers();

                                dr["ApplMainCareerField"] = MainCareers[mainCareerId];
                                dr["ApplSubCareerField"] = _Utility.Decrypt(FoundUser.SubCareer);
                                dr["ApplSearchTags"] = _Utility.Decrypt(FoundUser.SearchTag);
                                dr["ApplLinkedIn"] = _Utility.Decrypt(FoundUser.LinkedIn);
                                dr["InvitationDate"] = invSendDateTime;
                                dr["nofJobAppl"] = _GridViewUtility.numberOfJobApplications(Convert.ToInt32(ReceiverId));
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
                        lContactsInvitationsSend.Text = "You have not yet sended a contact invitation.";
                        lContactsInvitationsSend.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
            else
            {
                if (this.Parent.Page.AppRelativeVirtualPath == "~/ContactsInvitations.aspx")
                {
                    lContactsInvitationsSend.Text = "You have not yet sended a contact invitation.";
                    lContactsInvitationsSend.ForeColor = System.Drawing.Color.Green;
                }
            }
        }
        #endregion
    }
}