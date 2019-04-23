<%@ Page Language="C#" MasterPageFile="~/JobHunter.Master" AutoEventWireup="true" CodeBehind="ContactsInvitations.aspx.cs" Inherits="Jobhunt.ContactsInvitations" EnableViewState="true" EnableEventValidation="false" %>
<%@ Register TagPrefix="uc" TagName="UCContactsInvitations" Src="~/UserControls/UCContactsInvitations.ascx" %>
<%@ Register TagPrefix="uc" TagName="UCContactsInvitationsSend" Src="~/UserControls/UCContactsInvitationsSend.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
      <%--<link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />--%>
      <link href="css/jquery-ui.min.css" rel="stylesheet" type="text/css" />
       
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <table border="0" cellpadding="5" cellspacing="5" style="width: 100%;">
        <tr>
            <td bgcolor="#0066CC" style="vertical-align : middle;">
                <asp:ImageButton ID="imgInvitations" runat="server" ImageUrl="~/images/questionmark.png" Height="15" Width="15" OnClientClick="return false;" />
                <asp:Panel runat="server" ID="pnlimgInvitations" Enabled="false">
                Here you can see all your received invitations and your send invitations. You can deny, withdraw or accept them.  
                </asp:Panel>
                <ajaxToolkit:BalloonPopupExtender ID="BalloonPopupExtender3" runat="server"
                    TargetControlID="imgInvitations"
                    BalloonPopupControlID="pnlimgInvitations"
                    Position="TopRight"
                    BalloonStyle="Cloud"
                    BalloonSize="Large"
                    UseShadow="false"
                    ScrollBars="Auto"
                    DisplayOnMouseOver="false"
                    DisplayOnFocus="false"
                    DisplayOnClick="true" />

                <asp:Image runat="server" ImageUrl="~/images/invitationmanagement.png" Height="30px" Width="35px"></asp:Image>
                <asp:Label ID="lblInvitations" runat="server" Text="My contact invitations" Font-Size="Medium" Font-Bold="True" ForeColor="White" Font-Underline="True"></asp:Label>
            </td>
        </tr>
    </table>
     </br>
     <table border="0" cellpadding="2" cellspacing="2" style="width: 100%;">
        <tr>
            <td style="width: 10%">
              <asp:ImageButton ID="imgcontactinvitationRecHelp" runat="server" ImageUrl="~/images/questionmark.png" Height="15" Width="15" OnClientClick="return false;" />
                 <asp:Panel runat="server" ID="pnlimgcontactinvitationRecHelp" Enabled="false">
                          Here you can see your received invitations from other users and their current status.
                            You can either accept an invitation or deny an invitation.
                            If you accept an invitation the user becomes a contact and can be found at my contacts.
                            At my contacts you can then see their public job application forms.
                             When you have accepted an invitation you can always withdraw the invitation.
                            When you do this the user is no longer a contact and can't be found at my contacts.
                            This also applies to the user who sent the invitation. This user will no longer see you at his/her my contacts gridview.
                                </asp:Panel>
                                <ajaxToolkit:BalloonPopupExtender ID="BalloonPopupExtender1" runat="server"
                                TargetControlID="imgcontactinvitationRecHelp"
                                BalloonPopupControlID="pnlimgcontactinvitationRecHelp"
                                Position="TopRight" 
                                BalloonStyle="Cloud"
                                BalloonSize="Large"
                                UseShadow="false" 
                                ScrollBars="Auto"
                                DisplayOnMouseOver="false"
                                DisplayOnFocus="false"
                                DisplayOnClick="true" />

                <asp:Image runat="server" ImageUrl="~/images/contactinvitationRec.png" Height="22px" Width="22px"></asp:Image>
            </td>
            <td style="width: 90%">
                <asp:Label ID="Label1" runat="server" Text="Received contact invitations:" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
      </table>
     <div style="width: 100%; overflow: scroll;">
        <%-- <asp:Panel ID="DashBoardJobApplicationsPanel" runat="server" ScrollBars="Both" Height="500">--%>
       <%-- <div style="height: 500px;">--%>
           <uc:UCContactsInvitations runat="server" ID="UCContactsInvitations" />
       <%-- </div> --%>
    </div>

     <br />
   <table border="0" cellpadding="2" cellspacing="2" style="width: 100%;">
        <tr>
            <td style="width: 10%">
                <asp:ImageButton ID="imgcontactinvitationSendHelp" runat="server" ImageUrl="~/images/questionmark.png" Height="15" Width="15" OnClientClick="return false;" />
                 <asp:Panel runat="server" ID="pnlimgcontactinvitationSendHelp" Enabled="false">
                          Here you can see all your send invitations to other users and their status.
                            When the receiver of your invitation has accepted your invitation the status of the invitation becomes: accepted.
                             When the other user has accepted your invitation the user can be found at my contacts and you can see his/her public job application forms.
                            The receiver of your invitation can then also see you at his/her my contacts and see your public job application forms.
                            When the other user has accepted your invitation you can always withdraw the invitation from here.
                            When you do this the user is no longer a contact and can't be found at my contacts.
                            This also applies to the user who received the invitation. This user will no longer see you at his/her my contacts gridview.
                                </asp:Panel>
                                <ajaxToolkit:BalloonPopupExtender ID="BalloonPopupExtender2" runat="server"
                                TargetControlID="imgcontactinvitationSendHelp"
                                BalloonPopupControlID="pnlimgcontactinvitationSendHelp"
                                Position="TopRight" 
                                BalloonStyle="Cloud"
                                BalloonSize="Large"
                                UseShadow="false" 
                                ScrollBars="Auto"
                                DisplayOnMouseOver="false"
                                DisplayOnFocus="false"
                                DisplayOnClick="true" />
                <asp:Image runat="server" ImageUrl="~/images/contactinvitationSend.png" Height="22px" Width="22px"></asp:Image>
            </td>
            <td style="width: 90%">
                <asp:Label ID="Label2" runat="server" Text="Send contact invitations:" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
      </table>
    <div style="width: 100%; overflow: scroll;">
        <%-- <asp:Panel ID="DashBoardJobApplicationsPanel" runat="server" ScrollBars="Both" Height="500">--%>
      <%--  <div style="height: 500px;">--%>
           <uc:UCContactsInvitationsSend runat="server" ID="UCContactsInvitationsSend" />
      <%--  </div> --%>
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