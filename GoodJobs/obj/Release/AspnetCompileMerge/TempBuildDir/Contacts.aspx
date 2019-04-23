<%@ Page Language="C#" MasterPageFile="~/JobHunter.Master" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="Jobhunt.Contacts" EnableViewState="true" EnableEventValidation="false"%>
<%@ Register TagPrefix="uc" TagName="UCContacts" Src="~/UserControls/UCContacts.ascx" %>
<%@ Register TagPrefix="uc" TagName="UCJobApplications" Src="~/UserControls/UCJobApplications.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
      <%--<link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />--%>
      <link href="css/jquery-ui.min.css" rel="stylesheet" type="text/css" />
      <script type="text/javascript" src="js/gridviewscroll.js"></script>
    <%-- <script type="text/javascript">
        window.onload = function () {
            var gridViewScroll = new GridViewScroll({
                elementID: "ContentPlaceHolderMain_UCJobApplications_DashBoardJobApplicationsGV", // Target element id
                width : "100%", // Integer or String(Percentage)
                height : "100%", // Integer or String(Percentage)
                freezeColumn : true, // Boolean
            freezeFooter : false, // Boolean
            freezeColumnCssClass : "", // String
            freezeFooterCssClass : "", // String
            freezeHeaderRowCount : 1, // Integer
            freezeColumnCount : 7, // Integer
            //onscroll: function (scrollTop, scrollLeft) // onscroll event callback
            });
            gridViewScroll.enhance();
        }

    </script>--%>
    <style type="text/css">
        td.contactsview {
            border-left: 0px solid;
            border-right: 0px solid;
        }
    </style>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <table border="0" cellpadding="5" cellspacing="5" style="width: 100%;">
        <tr>
            <td bgcolor="#0066CC" style="vertical-align : middle;">
                <asp:ImageButton ID="imgContacts" runat="server" ImageUrl="~/images/questionmark.png" Height="15" Width="15" OnClientClick="return false;" />
                <asp:Panel runat="server" ID="pnlimgContacts" Enabled="false">
                Here you can see all your contacts and here you can view the public job application forms of a contact.
                </asp:Panel>
                <ajaxToolkit:BalloonPopupExtender ID="BalloonPopupExtender3" runat="server"
                    TargetControlID="imgContacts"
                    BalloonPopupControlID="pnlimgContacts"
                    Position="TopRight"
                    BalloonStyle="Cloud"
                    BalloonSize="Large"
                    UseShadow="false"
                    ScrollBars="Auto"
                    DisplayOnMouseOver="false"
                    DisplayOnFocus="false"
                    DisplayOnClick="true" />

                <asp:Image runat="server" ImageUrl="~/images/profile.png" Height="30px" Width="35px"></asp:Image>
                <asp:Label ID="lblContacts" runat="server" Text="My contacts" Font-Size="Medium" Font-Bold="True" ForeColor="White" Font-Underline="True"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%;">
        <tr>
            <td style="width: 10%">
                 <asp:ImageButton ID="imgMyContactsHelp" runat="server" ImageUrl="~/images/questionmark.png" Height="15" Width="15" OnClientClick="return false;" />
                 <asp:Panel runat="server" ID="pnlimgMyContactsHelp" Enabled="false">
                         Here you can see all your current contacts. Press the button: 'view job applications' to see all the public job application forms of this user.
                        The users that are listed here are all the users who have accepted your send invitation or from who you have accepted their send invitation.
                        You can always withdraw an invitation at: my invitations.
                        When you do this the user is no longer a contact and can't be found at my contacts.
                        This also works the other way around. The other user will no longer see you at his/her my contacts gridview.
                                </asp:Panel>
                                <ajaxToolkit:BalloonPopupExtender ID="BalloonPopupExtender1" runat="server"
                                TargetControlID="imgMyContactsHelp"
                                BalloonPopupControlID="pnlimgMyContactsHelp"
                                Position="TopRight" 
                                BalloonStyle="Cloud"
                                BalloonSize="Large"
                                UseShadow="false" 
                                ScrollBars="Auto"
                                DisplayOnMouseOver="false"
                                DisplayOnFocus="false"
                                DisplayOnClick="true" />

                <asp:Image runat="server" ImageUrl="~/images/profile.png" Height="22px" Width="22px"></asp:Image>
            </td>
            <td style="width: 90%">
                <asp:Label ID="lMyContacts" runat="server" Text="My contacts:" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
      </table>
    <div style="width: 100%; overflow: scroll;"  >
        <%-- <asp:Panel ID="DashBoardJobApplicationsPanel" runat="server" ScrollBars="Both" Height="500">--%>
        <%--<div style="height: 500px;">--%>
           <uc:UCContacts runat="server" ID="UCContacts" />
     <%--   </div> --%>
    </div>

    <br />
     <table border="0" cellpadding="2" cellspacing="2" style="width: 100%;">
        <tr>
            <td style="width: 10%">
                <asp:ImageButton ID="imgViewContactJobApplHelp" runat="server" ImageUrl="~/images/questionmark.png" Height="15" Width="15" OnClientClick="return false;" />
                 <asp:Panel runat="server" ID="pnlimgViewContactJobApplHelp" Enabled="false">
                       Here you see all the public job applications of a contact.
                        Please click on the view button to see the job application form.
                        The job application form is read only.
                        A user has full control over who can see a certain job application form. Only when a user has checked the option: 'show to contacts' on his job application form
                        the job application is visible for other contacts.
                                </asp:Panel>
                                <ajaxToolkit:BalloonPopupExtender ID="BalloonPopupExtender2" runat="server"
                                TargetControlID="imgViewContactJobApplHelp"
                                BalloonPopupControlID="pnlimgViewContactJobApplHelp"
                                Position="TopRight" 
                                BalloonStyle="Cloud"
                                BalloonSize="Large"
                                UseShadow="false" 
                                ScrollBars="Auto"
                                DisplayOnMouseOver="false"
                                DisplayOnFocus="false"
                                DisplayOnClick="true" />
                <asp:Image runat="server" ImageUrl="~/images/jobapplication.png" Height="22px" Width="22px"></asp:Image>
            </td>
            <td style="width: 90%">
                <asp:Label ID="lJobApplSelContact" runat="server" Text="Job Applications:" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
      </table>
   <div style="width: 100%; overflow: scroll;"  >
        <%-- <asp:Panel ID="DashBoardJobApplicationsPanel" runat="server" ScrollBars="Both" Height="500">--%>
      <%--  <div style="height: 700px;">--%>
         <uc:UCJobApplications runat="server" ID="UCJobApplications" />
        <%--</div> --%>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
    <script type="text/javascript" src="js/jquery-3.1.1.js"></script>
    <%--<script type="text/javascript" src="js/jquery-ui.js"></script>--%>
     <script type="text/javascript" src="js/jquery-ui.min.js"></script>

      <script type="text/javascript">
        $(document).ready(function () {
        $(function () {
            $("#ContentPlaceHolderMain_UserAccount_datepickerBirthDateText").datepicker({
                changeMonth: true,
                changeYear: true,
                autoclose: true,
                dateFormat: "dd-mm-yy",
                onSelect: function () {
                    $("#datepickerBirthDateValue").val($(this).datepicker("getDate"));
                }
            });
        });
        }); 
    </script>
</asp:Content>