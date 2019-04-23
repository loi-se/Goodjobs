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

namespace Jobhunt.UserControls
{
    public partial class UCContacts : System.Web.UI.UserControl
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

        //public string parentPageName;
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
            //_UserId = Convert.ToInt32(UserId);

            //_User = _UsersController.GetUser(_UserId);

            //UCJobApplications ctrlUCJobApplications = new UCJobApplications();

            ApplicantsGV.RowDataBound += new GridViewRowEventHandler(ApplicantsGV_RowDataBound);


            if (!this.IsPostBack)
            {
                //0-Edit button
                ButtonField buttonField = new ButtonField();
                buttonField.HeaderText = "";
                buttonField.ItemStyle.VerticalAlign = VerticalAlign.Middle;
                ApplicantsGV.Columns.Add(buttonField);


                BoundField boundField = new BoundField();
                boundField.HeaderText = "";
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = 1;
                boundField.DataField = "UserID";
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
                boundField.HeaderText = "E-mail";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "ApplEmail";
                ApplicantsGV.Columns.Add(boundField);

                boundField = new BoundField();
                boundField.HeaderText = "LinkedIn";
                boundField.HeaderStyle.Font.Underline = true;
                boundField.HeaderStyle.ForeColor = _GridViewUtility.HeaderTextColor;
                boundField.HeaderStyle.Font.Size = _GridViewUtility.HeaderTextSize;
                boundField.DataField = "ApplLinkedIn";
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


            if (this.Parent.Page.AppRelativeVirtualPath == "~/ContactsSearch.aspx")
            {
                if (Session["searchResultsContacts"] != null)
                {
                    ShowMyContactsTable(true, (List<User>)Session["searchResultsContacts"], pIndex);
                }
            }
            else if (this.Parent.Page.AppRelativeVirtualPath == "~/Contacts.aspx")
            {
                Session["searchResultsContacts"] = null;
                ShowMyContacts(pIndex);
            }

        }

        private void ApplicantsGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].BorderWidth = 0;
                e.Row.Cells[0].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[1].BorderWidth = 0;
                e.Row.Cells[1].BackColor = _GridViewUtility.HeaderBackColor;

                e.Row.Cells[2].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[3].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[4].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[5].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[6].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[7].BackColor = _GridViewUtility.HeaderBackColor;
                e.Row.Cells[8].BackColor = _GridViewUtility.HeaderBackColor;

            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TextBox txtbox;
                HyperLink hp;
                //hp =  new HyperLink();
                string navigateUrlStart = "";

                Button btn_UCContacts = new Button();

                if (this.Parent.Page.AppRelativeVirtualPath == "~/ContactsSearch.aspx")
                {
                    btn_UCContacts.ID = "btn_UCContactsSearch";
                    btn_UCContacts.Text = "Send contact invitation";
                    btn_UCContacts.ToolTip = "Send contact invitation";
                }
                else if (this.Parent.Page.AppRelativeVirtualPath == "~/Contacts.aspx")
                {
                    btn_UCContacts.ID = "btn_UCContacts";
                    btn_UCContacts.Text = "View Job Applications";
                    btn_UCContacts.ToolTip = "View Job Applications";
                }

                // btn_Edit.Text = "Edit";
                //btn_SendFriendRequest.ImageUrl = "~/images/buttons/edit.png";
                //btn_Edit.

                btn_UCContacts.Click += new EventHandler(btn_UCContacts_Click);
                //btn_UCContacts.OnClientClick = "return false;";
                //btn_UCContacts.OnClientClick += new EventHandler(btn_UCContacts_Click);
                btn_UCContacts.Width = 200;
                btn_UCContacts.Height = 25;
                btn_UCContacts.CausesValidation = false;
                btn_UCContacts.EnableViewState = true;
                e.Row.Cells[0].Controls.Add(btn_UCContacts);
                e.Row.Cells[0].BackColor = _GridViewUtility.GridViewCellBackColor;
                e.Row.Cells[0].VerticalAlign = VerticalAlign.Top;
                e.Row.Cells[0].BorderColor = _GridViewUtility.GridViewCellBorderColor;


                Label lbl = new Label();
                lbl.Text = (e.Row.DataItem as DataRowView).Row["UserID"].ToString();
                lbl.Visible = false;
                lbl.Width = 0;
                e.Row.Cells[1].BackColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[1].Controls.Add(lbl);
                e.Row.Cells[1].BorderColor = _GridViewUtility.GridViewCellBorderColor;


                txtbox = _GridViewUtility.labelTextbox((e.Row.DataItem as DataRowView).Row["ApplName"].ToString(), 75);
                e.Row.Cells[2].Controls.Add(txtbox);
                e.Row.Cells[2].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[2].BackColor = _GridViewUtility.GridViewCellBackColor;

                txtbox = _GridViewUtility.labelTextbox((e.Row.DataItem as DataRowView).Row["ApplMainCareerField"].ToString(), 120);
                e.Row.Cells[3].Controls.Add(txtbox);
                e.Row.Cells[3].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[3].BackColor = _GridViewUtility.GridViewCellBackColor;

                txtbox = _GridViewUtility.labelTextbox((e.Row.DataItem as DataRowView).Row["ApplSubCareerField"].ToString(), 120);
                e.Row.Cells[4].Controls.Add(txtbox);
                e.Row.Cells[4].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[4].BackColor = _GridViewUtility.GridViewCellBackColor;

                txtbox = _GridViewUtility.labelTextbox((e.Row.DataItem as DataRowView).Row["ApplSearchTags"].ToString(), 120);
                e.Row.Cells[5].Controls.Add(txtbox);
                e.Row.Cells[5].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[5].BackColor = _GridViewUtility.GridViewCellBackColor;

                txtbox = _GridViewUtility.labelTextbox((e.Row.DataItem as DataRowView).Row["ApplEmail"].ToString(), 120);
                e.Row.Cells[6].Controls.Add(txtbox);
                e.Row.Cells[6].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[6].BackColor = _GridViewUtility.GridViewCellBackColor;


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

                e.Row.Cells[7].Controls.Add(hp);
                e.Row.Cells[7].BackColor = _GridViewUtility.GridViewCellBackColor;
                e.Row.Cells[7].BorderColor = _GridViewUtility.GridViewCellBorderColor;

                txtbox = _GridViewUtility.labelTextbox((e.Row.DataItem as DataRowView).Row["nofJobAppl"].ToString(), 120);
                e.Row.Cells[8].Controls.Add(txtbox);
                e.Row.Cells[8].BorderColor = _GridViewUtility.GridViewCellBorderColor;
                e.Row.Cells[8].BackColor = _GridViewUtility.GridViewCellBackColor;
            }
        }


        protected void btn_UCContacts_Click(object sender, EventArgs e)
        {
            //Session["UserIdChoosenContact"] = null;
            GridViewRow uCContactsGVRow = (GridViewRow)(sender as Control).Parent.Parent;
            int InvitedUserID = Convert.ToInt32(uCContactsGVRow.Cells[1].Text);

            if (this.Parent.Page.AppRelativeVirtualPath == "~/ContactsSearch.aspx")
            {
                //--Check if contact is already invited:
                Boolean alreadyInvited = false;

                List<string> myInvSendToCertainUser = new List<string>();

                String MyInvSend = _Utility.Decrypt(User.FriendsInvSend);
                if (!String.IsNullOrEmpty(MyInvSend))
                {
                    String[] MyInvsSend = MyInvSend.Split(',');

                    foreach (string MyInv in MyInvsSend)
                    {

                        string[] Myinvs = MyInv.Split(':');

                        if (Myinvs != null)
                        {
                            int InvReceiverUserId = Convert.ToInt32(Myinvs[2]);
                            if (InvReceiverUserId == InvitedUserID)
                            {
                                myInvSendToCertainUser.Add(MyInv);
                            }
                        }
                    }

                    // Controleer de status van de laatst verzonden uitnodiging:
                    if (myInvSendToCertainUser.Count > 0)
                    {
                        for (int i = myInvSendToCertainUser.Count() - 1; i >= 0; i--)
                        {
                            string MyInv = myInvSendToCertainUser[i];
                            string[] Myinvs = MyInv.Split(':');

                            if (Myinvs != null)
                            {
                                string status = Myinvs[0];
                                if (status == "S" || status == "A") // S = status: sent | A = status: accepted
                                {
                                    alreadyInvited = true;
                                }

                                break;
                            }     
                        }
                    }
                }

                //--Update invivitation fields in user table:
                if (!alreadyInvited)
                {
                    var guid = Guid.NewGuid();
                    string updatedInvitation = "";
                    updatedInvitation = _InvitationHandler.UpdateInvitation(UserId, InvitedUserID, "S", "FriendsInvRecieved", "new", guid.ToString());
                    User UserToUpdate = _UsersController.GetUser(InvitedUserID);
                    UserToUpdate.FriendsInvRecieved = _Utility.Encrypt(updatedInvitation);
                    _UsersController.PutUser(UserToUpdate.UserId, UserToUpdate);

                    updatedInvitation = _InvitationHandler.UpdateInvitation(UserId, InvitedUserID, "S", "FriendsInvSend", "new", guid.ToString());
                    UserToUpdate = _UsersController.GetUser(UserId);
                    UserToUpdate.FriendsInvSend = _Utility.Encrypt(updatedInvitation);
                    _UsersController.PutUser(UserToUpdate.UserId, UserToUpdate);

                    lContacts.ForeColor = System.Drawing.Color.Green;
                    lContacts.Text = "Invitation was send to the user. If the user accepts your invitation the user will be shown under contacts.";
                }
                else
                {
                    lContacts.ForeColor = System.Drawing.Color.Red;
                    lContacts.Text = "You have already invited this user. The contact invitation was not send.";
                }
            }
            else if (this.Parent.Page.AppRelativeVirtualPath == "~/Contacts.aspx")
            {
                UCJobApplications _uCJobApplications = this.Parent.FindControl("UCJobApplications") as UCJobApplications;
                Session["UserIdChoosenContact"] = InvitedUserID;

                User _ChoosenUser = new Models.User();
                _ChoosenUser = _UsersController.GetUser(Convert.ToInt32(Session["UserIdChoosenContact"]));

                _uCJobApplications._UserId = InvitedUserID;
                Session["searchResultsJobAppl"] = null;
                Session["searchQuery"] = null;
                Session["nofSearchResults"] = null;

                Server.Transfer("Contacts.aspx");
            }
        }

        #endregion
        protected void ddlCustomPagerItemSelected(object sender, EventArgs e)
        {
            int selectedPage = Convert.ToInt32(ddlCustomPager.SelectedItem.Text.ToString());
            ViewState["GridPageIndex"] = selectedPage;
            pIndex = selectedPage;

            if (Session["searchResultsContacts"] != null)
            {
                ShowMyContactsTable(true, (List<User>)Session["searchResultsContacts"], pIndex);
            }
            else
            {
                ShowMyContacts(pIndex);
            }
        }


        #region methods
        public int customPagerNumberOfResults()
        {
            int foundContacts = 0;
            if (this.Parent.Page.AppRelativeVirtualPath == "~/ContactsSearch.aspx")
            {
                if (Session["searchResultsContacts"] != null)
                {

                    List<User> searchQueryCount = (List<User>)Session["searchResultsContacts"];
                    foundContacts = searchQueryCount.Count();
                }
                else
                {
                    foundContacts = 0;
                }
            }
            else if(this.Parent.Page.AppRelativeVirtualPath == "~/Contacts.aspx")
           {
                string[] myContactsIds = null;
                if (_Utility.Decrypt(User.Friends) != null)
                {
                    myContactsIds = _Utility.Decrypt(User.Friends).Split(',');
                    foundContacts = myContactsIds.Count();
                }
            }
            return foundContacts;
        }

        public bool customPagerVisible()
        {
            bool visible = true;
            if (customPagerNumberOfResults() <= _GridViewUtility.contactspageSize)
            {
                visible = false;
            }
            return visible;
        }



        public void fillddlCustomPagerItemSelected()
        {
            ddlCustomPager.Items.Clear();
            int numberOfResults = customPagerNumberOfResults();
            int numberOfPages = (int)Math.Ceiling(Convert.ToDouble(customPagerNumberOfResults()) / Convert.ToDouble(_GridViewUtility.contactspageSize));

            for (int i = 1; i <= numberOfPages; i++)
            {
                ddlCustomPager.Items.Add(i.ToString());
            }
        }

        public void ShowMyContacts(int pIndex)
        {
            if (_Utility.Decrypt(User.Friends) != null)
            {
                string[] myContactsIds = _Utility.Decrypt(User.Friends).Split(',');

                if (myContactsIds.Count() > 0)
                {
                    List<User> foundUsers = new List<User>();

                    foreach (string contactId in myContactsIds)
                    {
                        if (!String.IsNullOrEmpty(contactId))
                        {
                            int foundUserId = Convert.ToInt32(contactId);
                            User foundUser = _UsersController.GetUser(foundUserId);
                            foundUsers.Add(foundUser);
                        }
                    }
                    ShowMyContactsTable(false, foundUsers, pIndex);
                }
                else
                {
                    if (this.Parent.Page.AppRelativeVirtualPath == "~/Contacts.aspx")
                    {
                        lContacts.Text = "You have no contacts yet.";
                        lContacts.ForeColor = System.Drawing.Color.Green;
                    }

                }
            }
            else
            {
                if (this.Parent.Page.AppRelativeVirtualPath == "~/Contacts.aspx")
                {
                    lContacts.Text = "You have no contacts yet.";
                    lContacts.ForeColor = System.Drawing.Color.Green;
                }

            }
        }

        public void ShowMyContactsTable(Boolean search, List<User> searchUsers, int pageIndex)
        {

            int pagerMinRange = 1;
            int pagerMaxRange = 1;
            if (pageIndex == 1)
            {
                pagerMinRange = 1;
                pagerMaxRange = pagerMinRange + (_GridViewUtility.contactspageSize - 1);
            }
            else if (pageIndex > 1)
            {
                pagerMinRange = (pageIndex - 1) * _GridViewUtility.contactspageSize;
                pagerMaxRange = pagerMinRange + (_GridViewUtility.contactspageSize - 1);
            }

            lTotalPages.Text = Math.Ceiling((Convert.ToDouble(customPagerNumberOfResults()) / Convert.ToDouble(_GridViewUtility.contactspageSize))).ToString() + ")";

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("UserID", typeof(Int32)));
            dt.Columns.Add(new DataColumn("ApplName", typeof(String)));
            dt.Columns.Add(new DataColumn("ApplMainCareerField", typeof(String)));
            dt.Columns.Add(new DataColumn("ApplSubCareerField", typeof(String)));
            dt.Columns.Add(new DataColumn("ApplSearchTags", typeof(String)));
            dt.Columns.Add(new DataColumn("ApplEmail", typeof(String)));
            dt.Columns.Add(new DataColumn("ApplLinkedIn", typeof(String)));
            dt.Columns.Add(new DataColumn("nofJobAppl", typeof(String)));

            if (searchUsers != null)
            {
                int counter = 1;
                foreach (User user in searchUsers)
                {
                    // Gebruiker kan niet gevonden worden bij het zoeken:
                    if (user.UserId == UserId)
                    {
                        continue;
                    }

                    DataRow dr = dt.NewRow();
                    if (counter >= pagerMinRange && counter <= pagerMaxRange)
                    {
                        dr["UserID"] = user.UserId;
                        dr["ApplName"] = _Utility.Decrypt(user.FirstName) + " " + _Utility.Decrypt(user.LastName);
                        int mainCareerId = Convert.ToInt32(_Utility.Decrypt(user.MainCareer));
                        Dictionary<int, string> MainCareers = _Careers.GetMainCareers();

                        dr["ApplMainCareerField"] = MainCareers[mainCareerId];
                        dr["ApplSubCareerField"] = _Utility.Decrypt(user.SubCareer);
                        dr["ApplSearchTags"] = _Utility.Decrypt(user.SearchTag);
                        dr["ApplEmail"] = _Utility.Decrypt(user.Email);
                        dr["ApplLinkedIn"] = _Utility.Decrypt(user.LinkedIn);
                        dr["nofJobAppl"] = _GridViewUtility.numberOfJobApplications(user.UserId);
                        dt.Rows.Add(dr);
                    }
                    counter = counter + 1;
                }
                ApplicantsGV.DataSource = dt;
                ApplicantsGV.DataBind();
            }
        }
        #endregion


    }
}