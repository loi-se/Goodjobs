<%@ Page Language="C#" MasterPageFile="~/JobHunter.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
     
    <style type="text/css">
        .accordion {
            width: 80%;
        }
        
        .accordionHeader {
            border: 1px solid #2F4F4F;
            color: white;
            background-color: #0066CC;
            font-family: Arial, Sans-Serif;
            font-size: 12px;
            font-weight: bold;
            padding: 5px;
            margin-top: 5px;
            cursor: pointer;
        }
        
        .accordionHeaderSelected {
            border: 1px solid #2F4F4F;
            color: black;
            background-color: #0066CC;
            font-family: Arial, Sans-Serif;
            font-size: 12px;
            font-weight: bold;
            padding: 5px;  
            margin-top: 5px;
            cursor: pointer;
        }
        
        .accordionContent {
            background-color: white;
            border: 1px solid #2F4F4F;
            border-top: none;
            padding: 5px;
            padding-top: 10px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <%-- <div class="default1" style="height: 500px;">--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table border="0" cellpadding="5" cellspacing="10" height="220px" style="width: 100%; position: relative">
        <tr>
            <td style="width: 40%">
                <div id="About" style="border-top: none; width: 100%; margin-top: -1px; height: 100%; background-color: #e6e6e6; margin-top: 0px;">
                            <asp:Label ID="lAbout" runat="server" Text="About:" Font-Bold="true"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="lAboutDescription" runat="server" Text="GoodJobs is a free web application 
                            to register and manage your job applications.  
                             In a job search it is important to stay organized and have all your data readily available. 
                            GoodJobs offers a free web application in which you can do just that: stay organized in your
                             job search and have all your job application details available in one place."></asp:Label>
                      </div>
            </td>

            <td style="width: 20%"></td>
            <td style="width: 40%">
                <div id="Login" style="border-top: none; width: 100%; margin-top: -1px; height: 100%; background-color:#e6e6e6; margin-top: 0px;">
                    <table border="0" cellpadding="5" cellspacing="5" style="width: 100%">
                        <tr>
                            <asp:Label ID="lRegister" runat="server" Text="Register now:" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </tr>
                        <br />
                        <tr>
                            <a href="Register.aspx" style="color:#0099FF">Register</a>
                        </tr>
                        <br />
                        <br />
                        <br />
                        <tr>
                            <asp:Label ID="lAccount" runat="server" Text="Already have an account?" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </tr>
                        <br />
                        <tr>
                            <a href="Login.aspx" style="color:#0099FF">Sign in</a>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>



    <table border="0" cellpadding="5" cellspacing="5" style="width: 100%;  height:400px; position: relative">
        <tr>
            <td style="width: 40%">
                <table border="0" cellpadding="5" cellspacing="5" style="width: 100%; height:400px; position: relative">
                    <tr>
                        <td style="width: 30%">
                            <asp:Label ID="lFeatures" runat="server" Text="GoodJobs features:" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr style="width: 100%">
                        <tr>

                            <td style="width: 10%">
                                <asp:Image runat="server" ImageUrl="~/images/gridview.png" Height="30px" Width="30px"></asp:Image>
                            </td>
                            <td style="width: 90%">
                                <asp:Label ID="lfeature1" runat="server" Text="- Keep an overview of all your job applications and see the most important details of a job application through a clear gridview."></asp:Label>
                            </td>
                        </tr>
                        <tr>

                            <td style="width: 10%">
                                <asp:Image runat="server" ImageUrl="~/images/form.png" Height="40px" Width="40px"></asp:Image>
                            </td>
                            <td style="width: 90%">
                                <asp:Label ID="lfeature2" runat="server" Text="- Enter all your job application details (including the job aplication letter and vacancy) in a clear job application form."></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td style="width: 10%">
                                <asp:Image runat="server" ImageUrl="~/images/dashboard.png" Height="35px" Width="35px"></asp:Image>
                            </td>
                            <td style="width: 90%">
                                <asp:Label ID="lfeature3" runat="server" Text="- A personal dashboard with various statistics a calendar and the gridview with all your job applications."></asp:Label>

                            </td>
                        </tr>

                        <tr>
                            <td style="width: 10%">
                                <asp:Image runat="server" ImageUrl="~/images/jobapplicant.png" Height="35px" Width="35px"></asp:Image>
                            </td>
                            <td style="width: 90%">
                                <asp:Label ID="lfeature4" runat="server" Text="- Invite other users and view their job application forms."></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td style="width: 10%">
                                <asp:Image runat="server" ImageUrl="~/images/ExportExcell.png" Height="30px" Width="30px"></asp:Image>
                            </td>
                            <td style="width: 90%">
                                <asp:Label ID="lfeature5" runat="server" Text="- Export all your job applications to Excell."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%">
                                <asp:Image runat="server" ImageUrl="~/images/pdficon.png" Height="35px" Width="35px"></asp:Image>
                            </td>
                            <td style="width: 90%">
                                <asp:Label ID="lfeature6" runat="server" Text="- Export a job application form to PDF."></asp:Label>
                            </td>
                        </tr>
                    </tr>
                </table>
            </td>

            <td style="width: 20%">

            </td>
            <td style="width: 40%">
                <div style="width: 100%; height:400px;">
                <ajaxToolkit:Accordion ID="Accordion1" runat="server" CssClass="accordion" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" RequireOpenedPane="False" SelectedIndex="0">
                    <Panes>
                        <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane1">
                            <Header>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image runat="server" ImageUrl="~/images/screenshot.png" Height="15px" Width="15px"></asp:Image>
                                        </td>
                                        <td>
                                            Dashboard
                                        </td>
                                    </tr>
                                </table>
                            </Header>
                            <Content>
                               <%-- <asp:Image ID="imgDashboard" runat="server" ImageUrl="~/images/Dashboard-Screenshot.png" onmouseover="showOnHoverAnimation(this);" onmouseout="hideOnHoverAnimation()"/>--%>
                                <%--<asp:LinkButton ID="panImgLnkBtn" runat="server" OnClientClick="openWindow();">--%>
                                 <a href="/images/Dashboard-Screenshot.png" target="_blank"> 
                                  <asp:Image ID="imgDashboard" runat="server" style="width: 100%; height:100%;" ImageUrl="~/images/Dashboard-Screenshot.png"/>   
                                 </a>
                               <%-- </asp:LinkButton>    --%>                       
                            </Content>
                        </ajaxToolkit:AccordionPane>
                        <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane2">
                            <Header>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image runat="server" ImageUrl="~/images/screenshot.png" Height="15px" Width="15px"></asp:Image>
                                        </td>
                                        <td>
                                            Job application form
                                        </td>
                                    </tr>
                                </table>
                            </Header>
                            <Content>
                                 <asp:Image ID="imgJobApplicationForm" runat="server" style="width: 100%; height:100%;" ImageUrl="~/images/Jobapplform-Screenshot.png" />
                            </Content>
                        </ajaxToolkit:AccordionPane>
                    </Panes>
                </ajaxToolkit:Accordion>
                 </div>
            </td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
     <script type="text/javascript">
        function openWindow() {
        //Change your pagename here and also the width and height as per your desgin
            window.open('Default.aspx', 'open_window', ' width=400, height=400, left=0, top=0');
        }
    </script>
</asp:Content>