<%@ Page Language="C#" MasterPageFile="~/JobHunter.Master" AutoEventWireup="true" CodeBehind="JobApplications.aspx.cs" Inherits="_JobApplications" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
      <%--<link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />--%>
      <link href="css/jquery-ui.min.css" rel="stylesheet" type="text/css" />
       <link href="https://code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" rel="stylesheet" type="text/css">

    <style type="text/css">
        .accordion {
            background-color: #ffffff;
            color: #444;
            cursor: pointer;
            padding: 18px;
            width: 100%;
            border: none;
            text-align: left;
            outline: none;
            font-size: 15px;
            transition: 0.4s;
        }

            .active, .accordion:hover {
                background-color: #ccc;
            }

        .panel {
            padding: 0 18px;
            display: none;
            background-color: #e6e6e6;
            overflow: hidden;
        }
    </style>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     
        <br />
        <br />
        <asp:Panel ID="JobApplicationsPanel" runat="server" ScrollBars="None">
            <table border="0" cellpadding="5" cellspacing="5" style="width: 100%;">             
                <tr>
                 <td bgcolor="#0066CC" style="vertical-align : middle;">
                 <asp:ImageButton ID="imgMyjobApplFormHelp" runat="server" ImageUrl="~/images/questionmark.png" Height="15" Width="15" OnClientClick="return false;" />
                 <asp:Panel runat="server" ID="pnlimgMyjobApplFormHelp" Enabled="false">                       
                        In this job application form you can fill in and keep track of all the details of a job application. Only the job application name is a required field the other fields 
                     are not mandatory. When you submit the job application form you are redirected to your dashboard and then the job application can be seen in the job application gridview.
                     Date fields with a color appear in the displayed color on the calendar on your dashboard.
                                </asp:Panel>
                                <ajaxToolkit:BalloonPopupExtender ID="BalloonPopupExtender1" runat="server"
                                TargetControlID="imgMyjobApplFormHelp"
                                BalloonPopupControlID="pnlimgMyjobApplFormHelp"
                                Position="TopRight" 
                                BalloonStyle="Cloud"
                                BalloonSize="Large"
                                UseShadow="false" 
                                ScrollBars="Auto"
                                DisplayOnMouseOver="false"
                                DisplayOnFocus="false"
                                DisplayOnClick="true" />

                <asp:Image runat="server" ImageUrl="~/images/form.png" Height="35px" Width="35px"></asp:Image>
                 <asp:Label ID="ljobApplForm" runat="server" Text="Job application form" Font-Size="Medium" Font-Bold="True" ForeColor="White" Font-Underline="True"></asp:Label>
                 </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lHeader" runat="server" Text="" Font-Size="Small"></asp:Label>
                        </br>
                        <asp:Label ID="lRequired" runat="server" Text="(Only fields with a:" Font-Size="Small"></asp:Label>
                        <asp:Label ID="lRequired1" runat="server" Text=" * " Font-Size="Medium" ForeColor="Red"></asp:Label>
                        <asp:Label ID="lRequired2" runat="server" Text="are required)" Font-Size="Small"></asp:Label>
                    </td>
                </tr>
            </table>

            <table border="0" cellpadding="5" cellspacing="5" height="700px" style="width: 100%;">
                <tr>
                    <td style="width: 50%;">
                        <div id="divjobApll" style="border-top: none; width: 100%; margin-top: -1px; height: 100%; margin-top: 0px;">


                            <table border="0" cellpadding="5" cellspacing="5" height="500px">
                                <col width="150">
                                <%--   <table border="0" cellpadding="5" cellspacing="5" height="500px">--%>
                                <tr>
                                    <td align="left">
                                        <asp:Image runat="server" ImageUrl="~/images/jobapplication.png" Height="22px" Width="22px"></asp:Image>
                                    </td>
                                    <td>
                                        <asp:Label ID="lJobapplication" runat="server" Text="Job application" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">Job application name: <span style="color: red">*</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtJobApplName" runat="server" EnableViewState="True" Width="400px" />
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtJobApplName"
                                            runat="server" EnableClientScript="false" />
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,250})$" ID="regExtxtJobApplName" runat="server" ErrorMessage="Max 250 characters" ForeColor="Red" ControlToValidate="txtJobApplName" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">Job application date:
                                    </td>
                                    <td>
                                        <input type="hidden" id="datepickerJobApplDateValue" name="datepickerJobApplDateValue" value="" />
                                        <p>
                                            <asp:TextBox ID="datepickerJobApplDate" runat="server" EnableViewState="True" Width="400px" /></p>
                                         <asp:Panel ID="pJobApplDate" runat="server" Height="20" Width="20" BackColor="#007F46"></asp:Panel>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^(\d{1,2})-(\d{1,2})-(\d{4})$" ID="regExdatepickerJobApplDate" runat="server" ErrorMessage="invalid date" ForeColor="Red" ControlToValidate="datepickerJobApplDate" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">Job application time:
                                    </td>
                                    <td align="left">
                                        <span>
                                            <asp:DropDownList ID="ddlJobApplTimeHour" runat="server"></asp:DropDownList>
                                            <asp:DropDownList ID="ddlJobApplTimeMinute" runat="server"></asp:DropDownList></span>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">Job application letter:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtJobApplLetter" runat="server" EnableViewState="True" Width="400px" TextMode="MultiLine" Height="500px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,20000})$" ID="regExtxtJobApplLetter" runat="server" ErrorMessage="Max 20000 characters" ForeColor="Red" ControlToValidate="txtJobApplLetter" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">Job application method:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtJobApplMethod" runat="server" EnableViewState="True" Width="400px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,250})$" ID="regExtxtJobApplMethod" runat="server" ErrorMessage="Max 250 characters" ForeColor="Red" ControlToValidate="txtJobApplMethod" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">My rating:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlMyRating" runat="server" Width="400px">
                                            <asp:ListItem Text="1" Value="0" />
                                            <asp:ListItem Text="2" Value="1" />
                                            <asp:ListItem Text="3" Value="2" />
                                            <asp:ListItem Text="4" Value="3" />
                                            <asp:ListItem Text="5" Value="4" />
                                            <asp:ListItem Text="6" Value="5" />
                                            <asp:ListItem Text="7" Value="6" />
                                            <asp:ListItem Text="8" Value="7" />
                                            <asp:ListItem Text="9" Value="8" />
                                            <asp:ListItem Text="10" Value="9" />
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">Note:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtJobApplNote" runat="server" EnableViewState="True" Width="400px" TextMode="MultiLine" Height="200px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,10000})$" ID="regExtxtJobApplNote" runat="server" ErrorMessage="Max 10000 characters" ForeColor="Red" ControlToValidate="txtJobApplNote" />
                                    </td>
                                </tr>
                                  <tr>
                                    <td align="left">Category:
                                    </td>
                                    <td>
                                        <ajaxToolkit:ComboBox ID="ccCategory" runat="server"
                                            AutoPostBack="False"
                                            DropDownStyle="DropDown"
                                            AutoCompleteMode="SuggestAppend"
                                            CaseSensitive="False"
                                            CssClass=""
                                            ItemInsertLocation="OrdinalText"
                                            Width="372px">
                                            </ajaxToolkit:ComboBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,10000})$" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Max 10000 characters" ForeColor="Red" ControlToValidate="ccCategory" />
                                    </td>
                                </tr>
                                   <tr>
                                    <td align="left">
                                        <asp:Image runat="server" ImageUrl="~/images/jobapplicant.png" Height="22px" Width="22px"></asp:Image>
                                    </td>
                                    <td>
                                        <asp:Label ID="lContacts" runat="server" Text="Contacts" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">Show to Contacts:
                                    </td>
                                    <td align="center">
                                        <asp:CheckBox ID="chkBoxShowToFriends" runat="server" />
                                    </td>

                                </tr>

                                <tr>
                                    <td align="left"></td>
                                    <td></td>
                                </tr>
                                </table>
                        </div>
                    </td>
                    <td style="width: 50%;">
                        <div id='divJobVacancy' style="border-top: none; width: 100%; margin-top: -1px; height: 100%; margin-top: 0px;">

                                 <table border="0" cellpadding="5" cellspacing="5" height="60px">
                                <tr>
                                    <td align="left">
                                        <asp:Image runat="server" ImageUrl="~/images/company.png" Height="22px" Width="22px"></asp:Image>
                                    </td>
                                    <td>
                                        <asp:Label ID="lCompany" runat="server" Text="Company" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                   </table>
                                  
                             <button class="accordion" style="height: 40px; vertical-align: middle;">Expand:</button>
                                <div class="panel">
                                 <table border="0" cellpadding="5" cellspacing="5" height="500px">
                                <tr>
                                    <td align="left">Company:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVacancyCompany" runat="server" EnableViewState="True" Width="400px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,250})$" ID="regExtxtVacancyCompany" runat="server" ErrorMessage="Max 250 characters" ForeColor="Red" ControlToValidate="txtVacancyCompany" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">Website:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVacancyCompanyWebsite" runat="server" EnableViewState="True" Width="400px" />
                                        <asp:HyperLink ID="hlVacancyCompanyWebsite" runat="server" Style="text-align: left;"></asp:HyperLink>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,1000})$" ID="regExtxtVacancyCompanyWebsite" runat="server" ErrorMessage="Max 1000 characters" ForeColor="Red" ControlToValidate="txtVacancyCompanyWebsite" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">City:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVacancyCompanyCity" runat="server" EnableViewState="True" Width="400px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,250})$" ID="regExtxtVacancyCompanyCity" runat="server" ErrorMessage="Max 250 characters" ForeColor="Red" ControlToValidate="txtVacancyCompanyCity" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">Streetname:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVacancyCompanyStreetName" runat="server" EnableViewState="True" Width="400px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,250})$" ID="regExtxtVacancyCompanyStreetName" runat="server" ErrorMessage="Max 250 characters" ForeColor="Red" ControlToValidate="txtVacancyCompanyStreetName" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">Streetnumber:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVacancyCompanyStreetNumber" runat="server" EnableViewState="True" Width="400px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,250})$" ID="regExtxtVacancyCompanyStreetNumber" runat="server" ErrorMessage="Max 250 characters" ForeColor="Red" ControlToValidate="txtVacancyCompanyStreetNumber" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">Zipcode:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVacancyCompanyZipCode" runat="server" EnableViewState="True" Width="400px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,250})$" ID="regExtxtVacancyCompanyZipCode" runat="server" ErrorMessage="Max 250 characters" ForeColor="Red" ControlToValidate="txtVacancyCompanyZipCode" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">Country:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVacancyCompanyCountry" runat="server" EnableViewState="True" Width="400px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,250})$" ID="regExtxtVacancyCompanyCountry" runat="server" ErrorMessage="Max 250 characters" ForeColor="Red" ControlToValidate="txtVacancyCompanyCountry" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">Summary:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVacancyCompanySummary" runat="server" EnableViewState="True" Width="400px" TextMode="MultiLine" Height="300px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,10000})$" ID="regExtxtVacancyCompanySummary" runat="server" ErrorMessage="Max 10000 characters" ForeColor="Red" ControlToValidate="txtVacancyCompanySummary" />
                                    </td>
                                </tr>
                            </table>
                                    </div>

                                <table border="0" cellpadding="5" cellspacing="5" height="60px">
                                <tr>
                                    <td align="left">
                                        <asp:Image runat="server" ImageUrl="~/images/status.png" Height="22px" Width="22px"></asp:Image>
                                    </td>
                                    <td>
                                        <asp:Label ID="lStatus" runat="server" Text="Job application status" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                    </table>

                                
                            <button class="accordion" style="height: 40px; vertical-align: middle;">Expand:</button>
                                <div class="panel">
                                <table border="0" cellpadding="5" cellspacing="5" height="500px">
                                <tr>
                                    <td align="left">Status:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dropdownStatus" runat="server" Width="400px">
                                            <asp:ListItem Text="Concept" Value="0" />
                                            <asp:ListItem Text="Job application sended" Value="1" />
                                            <asp:ListItem Text="Rejection - Job application letter" Value="2" />
                                            <asp:ListItem Text="First round interview" Value="3" />
                                            <asp:ListItem Text="Rejection - First round Job application interview" Value="4" />
                                            <asp:ListItem Text="Second round interview" Value="5" />
                                            <asp:ListItem Text="Rejection - Second round Job application interview" Value="6" />
                                            <asp:ListItem Text="Third round interview" Value="7" />
                                            <asp:ListItem Text="Rejection - Third round Job application interview" Value="8" />
                                            <asp:ListItem Text="Assessment" Value="9" />
                                            <asp:ListItem Text="Rejection - Assessment" Value="10" />
                                            <asp:ListItem Text="Job offer" Value="11" />
                                            <asp:ListItem Text="Closed" Value="12" />
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">Company feedback/ follow-up:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtJobApplFeedback" runat="server" EnableViewState="True" Width="400px" TextMode="MultiLine" Height="200px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,10000})$" ID="regExtxtJobApplFeedback" runat="server" ErrorMessage="Max 10000 characters" ForeColor="Red" ControlToValidate="txtJobApplFeedback" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">My follow-up e-mails:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtJobApplMyFollowUpEmails" runat="server" EnableViewState="True" Width="400px" TextMode="MultiLine" Height="200px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,10000})$" ID="regExtxtJobApplMyFollowUpEmails" runat="server" ErrorMessage="Max 10000 characters" ForeColor="Red" ControlToValidate="txtJobApplMyFollowUpEmails" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">Follow-up status:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlFollowUpStatus" runat="server" Width="400px">
                                            <asp:ListItem Text="Not sended" Value="0" />
                                            <asp:ListItem Text="Sended" Value="1" />
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left"></td>
                                    <td></td>
                                </tr>
                                </table>
                             </div>
                                  <table border="0" cellpadding="5" cellspacing="5" height="60px">
                                <tr>
                                    <td align="left">
                                        <asp:Image runat="server" ImageUrl="~/images/jobvacancy.png" Height="22px" Width="22px"></asp:Image>
                                    </td>
                                    <td>
                                        <asp:Label ID="lJobVacancy" runat="server" Text="Job vacancy" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                    </td>
                                    <td>
                                </tr>
                                </table>
                                

                            <button class="accordion" style="height: 40px; vertical-align: middle;">Expand:</button>
                                <div class="panel">
                                <table border="0" cellpadding="5" cellspacing="5" height="500px">
                                <tr>
                                    <td align="left">Vacancy title:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVacancyTitle" runat="server" EnableViewState="True" Width="400px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,250})$" ID="regExtxtVacancyTitle" runat="server" ErrorMessage="Max 250 characters" ForeColor="Red" ControlToValidate="txtVacancyTitle" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">Function title:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVacancyFunctionTitle" runat="server" EnableViewState="True" Width="400px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,250})$" ID="regExtxtVacancyFunctionTitle" runat="server" ErrorMessage="Max 250 characters" ForeColor="Red" ControlToValidate="txtVacancyFunctionTitle" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">Career field:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVacancyCareerField" runat="server" EnableViewState="True" Width="400px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,250})$" ID="regExtxtVacancyCareerField" runat="server" ErrorMessage="Max 250 characters" ForeColor="Red" ControlToValidate="txtVacancyCareerField" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">Vacancy text:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVacancyText" runat="server" EnableViewState="True" Width="400px" TextMode="MultiLine" Height="500px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,20000})$" ID="regExtxtVacancyText" runat="server" ErrorMessage="Max 20000 characters" ForeColor="Red" ControlToValidate="txtVacancyText" />
                                    </td>
                                </tr>


                                <tr>
                                    <td align="left">Vacancy salary:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVacancySalary" runat="server" EnableViewState="True" Width="400px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,250})$" ID="regExtxtVacancySalary" runat="server" ErrorMessage="Max 250 characters" ForeColor="Red" ControlToValidate="txtVacancySalary" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">Vacancy link:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVacancyLink" runat="server" EnableViewState="True" Width="400px" />
                                        <asp:HyperLink ID="hlVacancyLink" runat="server" Style="text-align: left;"></asp:HyperLink>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,1000})$" ID="regExtxtVacancyLink" runat="server" ErrorMessage="Max 1000 characters" ForeColor="Red" ControlToValidate="txtVacancyLink" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">Contact person:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVacancyContactPerson" runat="server" EnableViewState="True" Width="400px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,250})$" ID="regExtxtVacancyContactPerson" runat="server" ErrorMessage="Max 250 characters" ForeColor="Red" ControlToValidate="txtVacancyContactPerson" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">Contact person e-mail:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVacancyContactPersonEmail" runat="server" EnableViewState="True" Width="400px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,250})$" ID="regExtxtVacancyContactPersonEmail" runat="server" ErrorMessage="Max 250 characters" ForeColor="Red" ControlToValidate="txtVacancyContactPersonEmail" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">Contact person LinkedIn:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVacancyContactPersonLinkedIn" runat="server" EnableViewState="True" Width="400px" />
                                        <asp:HyperLink ID="hlVacancyContactPersonLinkedIn" runat="server" Style="text-align: left;"></asp:HyperLink>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,1000})$" ID="regExtxtVacancyContactPersonLinkedIn" runat="server" ErrorMessage="Max 1000 characters" ForeColor="Red" ControlToValidate="txtVacancyContactPersonLinkedIn" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left"></td>
                                    <td></td>
                                </tr>
                                </table>
                                    </div>
                             <table border="0" cellpadding="5" cellspacing="5" height="60px">
                                <tr>
                                    <td align="left">
                                        <asp:Image runat="server" ImageUrl="~/images/jobinterview.png" Height="22px" Width="22px"></asp:Image>
                                    </td>
                                    <td>
                                        <asp:Label ID="lInterviews" runat="server" Text="Job application interviews" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                </table>

                                <button class="accordion" style="height: 40px; vertical-align: middle;">Expand:</button>
                                <div class="panel">
                                <table border="0" cellpadding="5" cellspacing="5" height="500px">
                                <tr>
                                    <td align="left">Interview date:
                                    </td>
                                    <td>
                                        <input type="hidden" id="datepickerJobApplInterviewDateValue" name="datepickerJobApplInterviewDateValue" value="" />
                                        <p>
                                            <asp:TextBox ID="datepickerJobApplInterviewDate" runat="server" EnableViewState="True" Width="400px" /></p>
                                        <asp:Panel ID="pJobApplInterview" runat="server" Height="20" Width="20" BackColor="#FFD800"></asp:Panel>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^(\d{1,2})-(\d{1,2})-(\d{4})$" ID="regExdatepickerJobApplInterviewDate" runat="server" ErrorMessage="invalid date" ForeColor="Red" ControlToValidate="datepickerJobApplInterviewDate" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">Interview time:
                                    </td>
                                    <td align="left">
                                        <span>
                                            <asp:DropDownList ID="ddlJobApplInterviewTimeHour" runat="server"></asp:DropDownList>
                                            <asp:DropDownList ID="ddlJobApplInterviewTimeMinute" runat="server"></asp:DropDownList></span>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">Interview persons:
                                    </td>
                                    <td style="border-bottom: 1pt dotted black;">
                                        <asp:TextBox ID="txtJobApplInterviewPersons" runat="server" EnableViewState="True" Width="400px" TextMode="MultiLine" Height="80px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,1500})$" ID="regExtxtJobApplInterviewPersons" runat="server" ErrorMessage="Max 250 characters" ForeColor="Red" ControlToValidate="txtJobApplInterviewPersons" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">Second interview date:
                                    </td>
                                    <td>
                                        <input type="hidden" id="datepickerJobApplSecInterviewDateValue" name="datepickerJobApplSecInterviewDateValue" value="" />
                                        <p>
                                            <asp:TextBox ID="datepickerJobApplSecInterviewDate" runat="server" EnableViewState="True" Width="400px" /></p>
                                        <asp:Panel ID="pJobApplSecInterview" runat="server" Height="20" Width="20" BackColor="#FF6607"></asp:Panel>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^(\d{1,2})-(\d{1,2})-(\d{4})$" ID="regExdatepickerJobApplSecInterviewDate" runat="server" ErrorMessage="invalid date" ForeColor="Red" ControlToValidate="datepickerJobApplSecInterviewDate" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">Second interview time:
                                    </td>
                                    <td align="left">
                                        <span>
                                            <asp:DropDownList ID="ddlJobApplSecInterviewTimeHour" runat="server"></asp:DropDownList>
                                            <asp:DropDownList ID="ddlJobApplSecInterviewTimeMinute" runat="server"></asp:DropDownList></span>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">Second interview persons:
                                    </td>
                                    <td style="border-bottom: 1pt dotted black;">
                                        <asp:TextBox ID="txtJobApplSecInterviewPersons" runat="server" EnableViewState="True" Width="400px" TextMode="MultiLine" Height="80px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,1500})$" ID="regExtxtJobApplSecInterviewPersons" runat="server" ErrorMessage="Max 250 characters" ForeColor="Red" ControlToValidate="txtJobApplSecInterviewPersons" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">Third interview date:
                                    </td>
                                    <td>
                                        <input type="hidden" id="datepickerJobApplThirdInterviewDateValue" name="datepickerJobApplThirdInterviewDateValue" value="" />
                                        <p>
                                            <asp:TextBox ID="datepickerJobApplThirdInterviewDate" runat="server" EnableViewState="True" Width="400px" /></p>
                                        <asp:Panel ID="pJobApplThirdInterview" runat="server" Height="20" Width="20" BackColor="#FF3B26"></asp:Panel>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^(\d{1,2})-(\d{1,2})-(\d{4})$" ID="regExdatepickerJobApplThirdInterviewDate" runat="server" ErrorMessage="invalid date" ForeColor="Red" ControlToValidate="datepickerJobApplThirdInterviewDate" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">Third interview time:
                                    </td>
                                    <td align="left">
                                        <span>
                                            <asp:DropDownList ID="ddlJobApplThirdInterviewTimeHour" runat="server"></asp:DropDownList>
                                            <asp:DropDownList ID="ddlJobApplThirdInterviewTimeMinute" runat="server"></asp:DropDownList></span>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">Third interview persons:
                                    </td>
                                    <td style="border-bottom: 1pt dotted black;">
                                        <asp:TextBox ID="txtJobApplThirdInterviewPersons" runat="server" EnableViewState="True" Width="400px" TextMode="MultiLine" Height="80px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,1500})$" ID="regExtxtJobApplThirdInterviewPersons" runat="server" ErrorMessage="Max 250 characters" ForeColor="Red" ControlToValidate="txtJobApplThirdInterviewPersons" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">Interview preperation:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtJobApplInterviewPreperation" runat="server" EnableViewState="True" Width="400px" TextMode="MultiLine" Height="200px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,10000})$" ID="regExtxtJobApplInterviewPreperation" runat="server" ErrorMessage="Max 10000 characters" ForeColor="Red" ControlToValidate="txtJobApplInterviewPreperation" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">My interview questions:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtJobApplMyQuestions" runat="server" EnableViewState="True" Width="400px" TextMode="MultiLine" Height="200px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,10000})$" ID="regExtxtJobApplMyQuestions" runat="server" ErrorMessage="Max 10000 characters" ForeColor="Red" ControlToValidate="txtJobApplMyQuestions" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">Company questions:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtJobApplCompanyQuestions" runat="server" EnableViewState="True" Width="400px" TextMode="MultiLine" Height="200px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,10000})$" ID="regExtxtJobApplCompanyQuestions" runat="server" ErrorMessage="Max 10000 characters" ForeColor="Red" ControlToValidate="txtJobApplCompanyQuestions" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">My Interview Notes:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtInterviewNotes" runat="server" EnableViewState="True" Width="400px" TextMode="MultiLine" Height="200px" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ValidationExpression="^([\S\s]{0,10000})$" ID="regExtxtInterviewNotes" runat="server" ErrorMessage="Max 10000 characters" ForeColor="Red" ControlToValidate="txtInterviewNotes" />
                                    </td>
                                </tr>

                                <%--<tr>--%>
                            </table>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%;" align="center">                  
                            <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="NewJobApplication" Width="250px"></asp:Button>
                    </td>
                    <td style="width: 50%;">
                        <div id='divJobSubmit2'>

                            <%--                                <table border="0" cellpadding="5" cellspacing="5">
                                    <tr>
                                     <td>--%>
                    </td>
                    <%--   </tr>
                                      <tr>
                                        <td>--%>
                    <%--<asp:Label ID="labelCreateJobAppl" runat="server" Text=""></asp:Label>--%>
                    <%--              </td>
                                    </tr>
                                </table>--%>
                    </div>
                </td>
                </tr>
                <tr>
                    <td style="width: 50%;">
                        <div style="text-align: left;">
                            <asp:ImageButton ID="ImageButtonWord" runat="server"></asp:ImageButton>
                        </div>
                    </td>
                    <td style="width: 50%;"></td>
                </tr>
            </table>
</asp:Panel>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
    <script type="text/javascript" src="js/jquery-3.1.1.js"></script>
    <%--<script type="text/javascript" src="js/jquery-ui.js"></script>--%>
     <script type="text/javascript" src="js/jquery-ui.min.js"></script>

      <script type="text/javascript">

        $(document).ready(function () {
        $(function () {
            $("#ContentPlaceHolderMain_datepickerJobApplDate").datepicker({
                changeMonth: true,
                changeYear: true,
                autoclose: true,
                dateFormat: "dd-mm-yy",
                onSelect: function () {
                    $("#datepickerJobApplDateValue").val($(this).datepicker("getDate"));                            
                }
            });
        });

        $(function () {
            $("#ContentPlaceHolderMain_datepickerJobApplInterviewDate").datepicker({
                changeMonth: true,
                changeYear: true,
                autoclose: true,
                dateFormat: "dd-mm-yy",
                onSelect: function () {
                    $("#datepickerJobApplInterviewDateValue").val($(this).datepicker("getDate"));
                }
            });
        });

        $(function () {
            $("#ContentPlaceHolderMain_datepickerJobApplSecInterviewDate").datepicker({
                changeMonth: true,
                changeYear: true,
                autoclose: true,
                dateFormat: "dd-mm-yy",
                onSelect: function () {
                    $("#datepickerJobApplSecInterviewDateValue").val($(this).datepicker("getDate"));
                }
            });
        });


        $(function () {
            $("#ContentPlaceHolderMain_datepickerJobApplThirdInterviewDate").datepicker({
                changeMonth: true,
                changeYear: true,
                autoclose: true,
                dateFormat: "dd-mm-yy",
                onSelect: function () {
                    $("#datepickerJobApplThirdInterviewDateValue").val($(this).datepicker("getDate"));
                }
            });
        });

        }); 
      </script>
    <script type="text/javascript">
              var acc = document.getElementsByClassName("accordion");
          var i;

          for (i = 0; i < acc.length; i++) {
              acc[i].addEventListener("click", function (e) {
                  e.preventDefault();
                  this.classList.toggle("active");
                  var panel = this.nextElementSibling;
                  if (panel.style.display === "block") {
                      panel.style.display = "none";
                  } else {
                      panel.style.display = "block";
                  }
              });
          }
          </script>
</asp:Content>


