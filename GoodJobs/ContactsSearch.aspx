<%@ Page Language="C#" MasterPageFile="~/JobHunter.Master" AutoEventWireup="true" CodeBehind="ContactsSearch.aspx.cs" Inherits="Jobhunt.ContactsSearch" EnableViewState="true"  %>
<%@ Register TagPrefix="uc" TagName="UCContacts" Src="~/UserControls/UCContacts.ascx" %>
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
                <asp:ImageButton ID="imgSearchAndInviteHelp" runat="server" ImageUrl="~/images/questionmark.png" Height="15" Width="15" OnClientClick="return false;" />
                <asp:Panel runat="server" ID="pnlimgSearchAndInviteHelp" Enabled="false">
                Here you can search for other users and invite them to see their public job application forms. 
                </asp:Panel>
                <ajaxToolkit:BalloonPopupExtender ID="BalloonPopupExtender3" runat="server"
                    TargetControlID="imgSearchAndInviteHelp"
                    BalloonPopupControlID="pnlimgSearchAndInviteHelp"
                    Position="TopRight"
                    BalloonStyle="Cloud"
                    BalloonSize="Large"
                    UseShadow="false"
                    ScrollBars="Auto"
                    DisplayOnMouseOver="false"
                    DisplayOnFocus="false"
                    DisplayOnClick="true" />

                <asp:Image runat="server" ImageUrl="~/images/searchresults.png" Height="30px" Width="35px"></asp:Image>
                <asp:Label ID="lblSearchAndInvite" runat="server" Text="Search and invite users" Font-Size="Medium" Font-Bold="True" ForeColor="White" Font-Underline="True"></asp:Label>
            </td>
        </tr>
    </table>
     </br>
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%;">
        <tr>
            <td style="width: 10%">
                 <asp:ImageButton ID="imgSearchHelp" runat="server" ImageUrl="~/images/questionmark.png" Height="15" Width="15" OnClientClick="return false;"/>
                 <asp:Panel runat="server" ID="pnlimgSearchHelp" Enabled="false">
                         Here you can search for other users and then invite them to see their public job application forms.
                          If a user accepts the invitation this user is a contact and can then be found at my contacts.
                                </asp:Panel>
                                <ajaxToolkit:BalloonPopupExtender ID="BalloonPopupExtender1" runat="server"
                                TargetControlID="imgSearchHelp"
                                BalloonPopupControlID="pnlimgSearchHelp"
                                Position="TopRight" 
                                BalloonStyle="Cloud"
                                BalloonSize="Large"
                                UseShadow="false" 
                                ScrollBars="Auto"
                                DisplayOnMouseOver="false"
                                DisplayOnFocus="false"
                                DisplayOnClick="true" />
                <asp:Image runat="server" ImageUrl="~/images/jobapplicant.png" Height="22px" Width="22px"></asp:Image>
            </td>
            <td style="width: 90%">
                <asp:Label ID="lContacts" runat="server" Text="Search for users:" Font-Bold="True" Font-Size="Medium"></asp:Label>
               
            </td>
                </tr>
      </table>
    <br />
    <table border="0" cellpadding="5" cellspacing="5" style="width: 100%; height:300px">
        <tr>
            <td style="width: 50%;">
                <table border="0" cellpadding="5" cellspacing="5" style="width: 50%; height:100%; display: block; position: relative;">
                    <tr>
                    </tr>
                    <tr>
                        <asp:Label ID="lUserSearch" runat="server" Text="User account search fields:" Font-Bold="True" Font-Size="Small"></asp:Label>
                    </tr>
                    <tr>
                        <td>Search tag:
                        </td>
                        <td>
                            <asp:TextBox ID="txtSearchTag" runat="server" EnableViewState="True" Width="400px" />
                        </td>
                        <td>
                            <%--      <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ValidationGroup="SearchUser" ControlToValidate="txtSearchTag" runat="server" EnableClientScript="True" />--%>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ValidationExpression="^[\S\s]{4,40}$" ValidationGroup="SearchUser" ID="regTSearch" runat="server" ErrorMessage="At least 4 characters" ForeColor="Red" ControlToValidate="txtSearchTag" />
                        </td>
                    </tr>
                    <tr>
                        <td>Main career field:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMainCareerField" runat="server" Width="400px"></asp:DropDownList>
                        </td>
                        <td>
                            <%--  <asp:RequiredFieldValidator ErrorMessage="Required" InitialValue="0" ForeColor="Red" ValidationGroup="SearchUser" ControlToValidate="ddlMainCareerField" runat="server" EnableClientScript="True" />--%>
                        </td>
                    </tr>

                    <tr>
                        <td>Sub career field:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSubCareerField" runat="server" Width="400px"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button Text="Search" ID="searchButton" runat="server" ValidationGroup="SearchUser" OnClick="SearchContacts" />
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Label ID="labelSearchFriend" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 50%;">
                <table border="0" cellpadding="5" cellspacing="5" style="width: 50%; height:100%; display: block; position: relative;">
                    <tr>
                     <asp:Label ID="lblUserJobApplSearch" runat="server" Text="User job applications search fields:" Font-Bold="True" Font-Size="Small"></asp:Label>
                    </tr>
                    <tr>
                        <td>Company name:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCompanyName" runat="server" EnableViewState="True" Width="400px" />
                        </td>
                        <td>
                           <%-- <asp:RequiredFieldValidator ErrorMessage="At least 4 characters" ForeColor="Red" ValidationGroup="SearchUser" ControlToValidate="txtCompanyName" runat="server" EnableClientScript="True" />--%>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ValidationExpression="^[\S\s]{4,40}$" ValidationGroup="SearchUser" ID="RegularExpressionValidator1" runat="server" ErrorMessage="At least 4 characters" ForeColor="Red" ControlToValidate="txtCompanyName" />
                        </td>
                    </tr>
                    <tr>
                        <td>Function title:
                        </td>
                        <td>
                            <asp:TextBox ID="txtFunctionTitle" runat="server" EnableViewState="True" Width="400px" />
                        </td>
                        <td>
                           <%-- <asp:RequiredFieldValidator ErrorMessage="At least 4 characters" ForeColor="Red" ValidationGroup="SearchUser" ControlToValidate="txtFunctionTitle" runat="server" EnableClientScript="True" />--%>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ValidationExpression="^[\S\s]{4,40}$" ValidationGroup="SearchUser" ID="RegularExpressionValidator2" runat="server" ErrorMessage="At least 4 characters" ForeColor="Red" ControlToValidate="txtFunctionTitle" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                      <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                     <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                      <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                     <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                     <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    
    <br />

     <table border="0" cellpadding="2" cellspacing="2" style="width: 100%;">
        <tr>
            <td style="width: 10%">
                 <asp:ImageButton ID="imgInviteHelp" runat="server" ImageUrl="~/images/questionmark.png" Height="15" Width="15" OnClientClick="return false;"/>
                 <asp:Panel runat="server" ID="pnlimgInviteHelp" Enabled="false">
                          Here you can see the users who meet your search requirements.
                          Press the button 'send invitation' to send a user an invitation. This send invitation can then be found at your my send invitations menu and
                          the invitation receiver will see this invitation at his/her my received invitations menu.
                          At my invitations you can also see your received invitations from other users and accept, deny or withdraw invitations.
                                </asp:Panel>
                                <ajaxToolkit:BalloonPopupExtender ID="BalloonPopupExtender2" runat="server"
                                TargetControlID="imgInviteHelp"
                                BalloonPopupControlID="pnlimgInviteHelp"
                                Position="TopRight" 
                                BalloonStyle="Cloud"
                                BalloonSize="Large"
                                UseShadow="false" 
                                ScrollBars="Auto"
                                DisplayOnMouseOver="false"
                                DisplayOnFocus="false"
                                DisplayOnClick="true" />
                <asp:Image runat="server" ImageUrl="~/images/searchresults.png" Height="22px" Width="22px"></asp:Image>
            </td>
            <td style="width: 90%">
                <asp:Label ID="Label1" runat="server" Text="Invite users:" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
      </table>
    <div >
        <%-- <asp:Panel ID="DashBoardJobApplicationsPanel" runat="server" ScrollBars="Both" Height="500">--%>
        <div style="Width: 100%; overflow: scroll;">
           <uc:UCContacts runat="server" ID="UCContacts" EnableViewState="true" />
        </div> 
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