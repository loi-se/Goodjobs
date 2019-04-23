<%@ Page Language="C#" MasterPageFile="~/JobHunter.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Jobhunt.Dashboard"  EnableViewState="true" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register TagPrefix="uc" TagName="UCJobApplications" Src="~/UserControls/UCJobApplications.ascx" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
    <link href="css/fullcalendar.css" rel="stylesheet" type="text/css" />
 
    <script type="text/javascript" src="js/gridviewscroll.js"></script>
    <script src='js/jquery.min.js' type="text/javascript"></script>
    <script src='js/moment.min.js' type="text/javascript"></script>
    <script src='js/fullcalendar.js' type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {

            var something = "";
            $.ajax({
                type: "POST",
                url: "Dashboard.aspx/BindCalendar",
                //url: "Dashboard/BindCalendar",
                   <%--  //url: <%=ResolveUrl("~/Dashboard.aspx/BindCalendar") %>,--%>
                   contentType: "application/json; charset=utf-8",
                   dataType: "json",
                   success: function (doc) {
                       //alert("Success");
                       var events = [];
                       var docd = doc.d;
                       something = docd;

                       var obj = $.parseJSON(doc.d);
                       console.log(obj);

                       $('#calendar').fullCalendar({
                           header: {
                               left: 'prev,next today',
                               center: 'title',
                               right: 'month,agendaWeek,agendaDay,list'
                           },
                           defaultView: 'month',
                           contentHeight: 400,

                           eventClick: function (calEvent, jsEvent, view) {
                               JobApplID = calEvent.id;

                               $.ajax({
                                   type: "POST",
                                   url: "Dashboard.aspx/openjobApplication",
                                   dataType: "json",
                                   contentType: "application/json; charset=utf-8",
                                   data: '{"parameter":' + JobApplID + ', "viewType":"view"}',
                                   success: function (msg) {
                                       if (msg.d == false)
                                       {
                                           window.location = "JobApplications.aspx";
                                       }
                                       else if (msg.d == true)
                                       {
                                           window.location = "Dashboard.aspx";
                                       }
                                       //alert(msg.d); //here you need to use msg.d in order to get response.
                                   
                                   },
                                   //call on ajax call failure
                                   error: function (xhr, textStatus, error) {
                                       //called on ajax call success
                                       alert("Error: " + error);
                                   }
                               });
                           },
                           eventMouseover: function (calEvent, jsEvent) {
                               //cursor: pointer
                               $(this).css('cursor', 'pointer');
                               var tooltip = '<div class="tooltipevent" style="width:100px;height:100px;background:#FCF8E3;position:absolute;z-index:10001;">' + calEvent.title + '</div>';
                               $("body").append(tooltip);
                               $(this).mouseover(function (e) {
                                   $(this).css('z-index', 10000);
                                   $('.tooltipevent').fadeIn('500');
                                   $('.tooltipevent').fadeTo('10', 1.9);
                               }).mousemove(function (e) {
                                   $('.tooltipevent').css('top', e.pageY + 10);
                                   $('.tooltipevent').css('left', e.pageX + 20);
                               });
                           },


                           eventMouseout: function (calEvent, jsEvent) {
                               $(this).css('z-index', 8);
                               $('.tooltipevent').remove();
                           },

                           eventAfterRender: function (event, element, view) {
                               var description = event.title;

                               var strJobAppl = description.search(/Job Appl/);
                               var str1stIV = description.search(/1st/);
                               var str2ndIV = description.search(/2nd/);
                               var str3rdIV = description.search(/3rd/);


                               if (str1stIV !== null) {
                                   if (str1stIV != -1) {
                                       element.css('background-color', '#FFD800');
                                   }
                               }

                               if (str2ndIV !== null) {
                                   if (str2ndIV != -1) {
                                       element.css('background-color', '#FF6607');
                                   }
                               }

                               if (str3rdIV !== null) {
                                   if (str3rdIV != -1) {
                                       element.css('background-color', '#FF3B26');
                                   }
                               }

                               if (strJobAppl !== null) {
                                   if (strJobAppl != -1) {
                                       element.css('background-color', '#007F46');
                                   }
                               }
                           },
                           events: obj,
                       })
                       // console.log(events);
                   },
                   error: function (XMLHttpRequest, textStatus, errorThrown) {
                       alert("Status: " + textStatus); alert("Error: " + XMLHttpRequest.responseText);
                   }
               });
           });
    </script>
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
        .Initial
        {
            display: block;
            padding: 4px 18px 4px 18px;
            float: left;
            /*background: url("../Images/InitialImage.png") no-repeat right top;*/
            background-color: #FFFFFF;
            color: Black;
            font-weight: bold;
            font-size:small;
        }
        .Initial:hover
        {
            color: #FFFFFF;
            /*background: url("../Images/SelectedButton.png") no-repeat right top;*/
            background-color: #0066CC;
        }
            .Clicked {
                float: left;
                display: block;
                /*background: url("../Images/SelectedButton.png") no-repeat right top;*/
                background-color: #0066CC;
                padding: 4px 18px 4px 18px;
                color: Black;
                font-weight: bold;
                color: #FFFFFF;
            }

         
        </style>

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table border="0" cellpadding="5" cellspacing="5" style="width: 100%;">
        <tr>
            <td bgcolor="#0066CC" style="vertical-align : middle;">
                <asp:ImageButton ID="imgDashboardHelp" runat="server" ImageUrl="~/images/questionmark.png" Height="15" Width="15" OnClientClick="return false;" />
                <asp:Panel runat="server" ID="pnlimgDashboardHelp" Enabled="false">
                 This is your dashboard where you have a clear overview of all your job application data. Here you can see your personal information, statistics, a calendar with 
                    the dates you applied and the times at which you had a job interview (the colors on the calendar correspond to the colors as shown in the job application form), and 
                    a gridview with all job applications you have registered so far.
                </asp:Panel>
                <ajaxToolkit:BalloonPopupExtender ID="BalloonPopupExtender1" runat="server"
                    TargetControlID="imgDashboardHelp"
                    BalloonPopupControlID="pnlimgDashboardHelp"
                    Position="TopRight"
                    BalloonStyle="Cloud"
                    BalloonSize="Large"
                    UseShadow="false"
                    ScrollBars="Auto"
                    DisplayOnMouseOver="false"
                    DisplayOnFocus="false"
                    DisplayOnClick="true" />

                <asp:Image runat="server" ImageUrl="~/images/mydashboard.png" Height="30px" Width="35px"></asp:Image>
                <asp:Label ID="lblDashboard" runat="server" Text="Dashboard" Font-Size="Medium" Font-Bold="True" ForeColor="White" Font-Underline="True"></asp:Label>
            </td>
        </tr>
    </table>
    </br>
    <table border="0" cellpadding="5" cellspacing="5" height="300px" style="width: 100%;">
        <tr>
            <td style="width: 50%;">
                <table border="0" cellpadding="5" cellspacing="5" height="35px" style="width: 100%;">
                    <tr>

                        <td style="width: 10%">
                            <asp:Image runat="server" ImageUrl="~/images/profile.png" Height="35px" Width="35px"></asp:Image>
                        </td>
                        <td style="width: 90%">
                            <asp:Label ID="lUserProfile" runat="server" Text="User profile:" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div id="userInfo" style="border-top: none; width: 100%; margin-top: -1px; height: 100%; background-color: #e6e6e6; margin-top: 0px; border-radius: 15px; background: #FFFFFF;">
                    <table border="0" cellpadding="5" cellspacing="5" height="100px" style="width: 100%;">
                        <tr>
                            <td style="width: 30%;">
                                <asp:Label ID="lName" runat="server" Text="Name:" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="width: 70%;">
                                <asp:Label ID="lblWelcomeName" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%;">
                                <asp:Label ID="lLinkedIn" runat="server" Text="LinkedIn profile:" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="width: 70%;">
                                <asp:HyperLink ID="hplLinkedIn" runat="server" Target="_blank" ForeColor="#0099FF">HyperLink</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%;">
                                <asp:Label ID="lnofJobApplications" runat="server" Text="Number of job applications:" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="width: 70%;">
                                <asp:Label ID="lblNofJobApplications" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%;">
                                <asp:Label ID="lnofContacts" runat="server" Text="Number of contacts:" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="width: 70%;">
                                <asp:Label ID="lblNofContacts" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                         <tr>
                            <td style="width: 30%;">
                                <asp:Label ID="lnofInvitations" runat="server" Text="Open invitations:" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="width: 70%;">
                                <asp:Label ID="lblnofInvitations" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>

                    </table>
                </div>
            </td>
            <td style="width: 50%;">
                <table border="0" cellpadding="5" cellspacing="5" height="35px" style="width: 100%;">
                    <tr>

                        <td style="width: 10%">
                            <asp:Image runat="server" ImageUrl="~/images/dashboard.png" Height="35px" Width="35px"></asp:Image>
                        </td>
                        <td style="width: 90%">
                            <asp:Label ID="lStatistics" runat="server" Text="My Statistics" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                </table>
                <%--<h4>My statistics:</h4>--%>
                <%--  <table border="0" cellpadding="5" cellspacing="5" height="100px" style="width: 100%;">
                        <tr>
                            <td style="width: 100%;">
                                <asp:Literal ID="litJobApplicationSended" runat="server" />
                            </td>
                        </tr>
                    </table>


                   <%-- <form id="form1" runat="server">--%>
                <div id="userStats" style="border-top: none; width: 100%; margin-top: -1px; height: 100%; background-color: #e6e6e6; margin-top: 0px; border-radius: 15px; background: #FFFFFF;">
                    <table width="100%" style="margin-top: 1px;">
                        <tr>
                            <td>
                                <asp:Button Text="Status overview" BorderStyle="None" ID="Tab1" CssClass="Initial" runat="server"
                                    OnClick="Tab1_Click" />
                                <asp:Button Text="Time line" BorderStyle="None" ID="Tab2" CssClass="Initial" runat="server"
                                    OnClick="Tab2_Click" />
                                <asp:Button Text="Word cloud" BorderStyle="None" ID="Tab3" CssClass="Initial" runat="server"
                                    OnClick="Tab3_Click" />
                                <asp:MultiView ID="MainView" runat="server">
                                    <asp:View ID="View1" runat="server">
                                        <table border="0" cellpadding="5" cellspacing="5" height="100px" style="width: 100%;">
                                            <tr>
                                                <td style="width: 100%;">
                                                    <asp:Literal ID="litJobApplicationSended" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:View>
                                    <asp:View ID="View2" runat="server">
                                        <table border="0" cellpadding="5" cellspacing="5" height="200px" style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lddlCategory" runat="server" Text="Category:"></asp:Label>
                                                    <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
                                                    <asp:Label ID="lddlHistoryRange" runat="server" Text="|   Past:"></asp:Label>
                                                    <asp:DropDownList ID="ddlHistoryRange" runat="server"></asp:DropDownList>
                                                    <asp:Label ID="lddlHistoryRangeUnit" runat="server" Text="Month(s)"></asp:Label>
                                                    <asp:Button ID="bShowTimeLine" runat="server" OnClick="ShowTimeLine" Text="Show" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="panelBarChartTimeLine" runat="server" ScrollBars="Vertical" Height="300">
                                                        <asp:Chart ID="ChartTimeLine" runat="server" Width="500px">

                                                            <ChartAreas>
                                                                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                                            </ChartAreas>
                                                            <BorderSkin BackColor="Transparent" PageColor="Transparent"
                                                                SkinStyle="Emboss" />
                                                        </asp:Chart>

                                                    </asp:Panel>

                                                    <%--  <br />
                                                        <br />
                                                        <h3>View 2
                                                        </h3>
                                                        <br />
                                                        <br />--%>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:View>
                                    <asp:View ID="View3" runat="server">
                                        <%--<table border="0" cellpadding="5" cellspacing="5" height="100px" style="width: 100%;">--%>

                                        <table border="0" cellpadding="5" cellspacing="5" style="width: 100%; height: 100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lWordCloud" runat="server" Text="Input:"></asp:Label>
                                                    <asp:DropDownList ID="ddlWordCloud" runat="server"></asp:DropDownList>
                                                    <asp:Button ID="bWordCloud" runat="server" OnClick="ShowWordCloud" Text="Show" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="pWordCloud" runat="server" ScrollBars="Vertical" Height="300">
                                                                <%--This is the visualization placeholder for the word cloud--%>
                                                                <div id="vis" style="width: 100%; height: 100%">
                                                                </div>

                                                                <%--These are the hidden fields for the various configuration options--%>
                                                                <div style="visibility: hidden; width: 0%; height: 0%">

                                                                    <%--Number of words to display, default is 250--%>
                                                                    <%--<input type="number" value="250" min="1" id="max">--%>
                                                                    <asp:HiddenField runat="server" ID="max" ClientIDMode="Static" Value="250" />


                                                                    <%--One word per line, default is false. --%>
                                                                    <%--Whether to take on word per line or to apply an english word parser--%>
                                                                    <%--<input type="checkbox" id="per-line">--%>
                                                                    <asp:CheckBox runat="server" ID="perline" ClientIDMode="Static" Value="false" />

                                                                    <%--The spiral style--%>
                                                                    <%--For simplicity, only the archimedean type is supported, without the ability to change programmatically --%>
                                                                    <input type="radio" name="spiral" id="archimedean" value="archimedean" checked="checked" />
                                                                    <%--<input type="radio" name="spiral" id="rectangular" value="rectangular">--%>

                                                                    <%--The scale style--%>
                                                                    <%--For simplicity, only the log type is supported, without the ability to change programmatically --%>
                                                                    <input type="radio" name="scale" id="scale-log" value="log" checked="checked">
                                                                    <%--<input type="radio" name="scale" id="scale-sqrt" value="sqrt">--%>
                                                                    <%--<input type="radio" name="scale" id="scale-linear" value="linear">--%>


                                                                    <%--Font, Default is Impact--%>
                                                                    <%--<input type="text" id="font" value="Impact">--%>
                                                                    <asp:HiddenField runat="server" ID="font" ClientIDMode="Static" Value="Impact" />

                                                                    <%--angles for word display--%>
                                                                    <%--For simplicity, without the ability to change programmatically --%>
                                                                    <input type="number" id="angle-count" value="5" min="1">
                                                                    <input type="number" id="angle-from" value="-60" min="-90" max="90">
                                                                    <input type="number" id="angle-to" value="60" min="-90" max="90">

                                                                    <%-- size of the word cloud canvas. Default is w=960, h=600 --%>
                                                                    <asp:TextBox runat="server" type="number" ID="wordcloudcanvaswidth" Text="500" ClientIDMode="Static" />
                                                                    <asp:TextBox runat="server" type="number" ID="wordcloudcanvasheight" Text="300" ClientIDMode="Static" />

                                                                    <%--This contains the text to use for the wordcloud. The content must be set via the literal--%>
                                                                    <textarea id="text">
                                                        <asp:Literal ID="WordCloudText" runat="server"></asp:Literal>
                                                        </textarea>
                                                            </div>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>


                                        <%--   </table>--%>
                                    </asp:View>
                                </asp:MultiView>
                            </td>
                        </tr>
                    </table>
                   <%-- </form>--%>




                </div>

                <%--<div id='userStats'>
                    <asp:Chart ID="ChartUserStats" runat="server">
                        <Series>
                            <asp:Series Name="Series1" IsVisibleInLegend="False"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">

                                <AxisY Title="">
                                </AxisY>
                                <AxisX Title="" IsLabelAutoFit="True">
                                    <LabelStyle Angle="-90" Interval="1" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>--%>
            </td>
        </tr>
    </table>
     <br />
     <br />
    <table border="0" cellpadding="5" cellspacing="5" height="300px" style="width: 100%;">
        <tr>
           <%-- <td style="width: 50%;">
                <table border="0" cellpadding="5" cellspacing="5" height="35px" style="width: 100%;">
                    <tr>
                        <td style="width: 10%">
                            <asp:Image runat="server" ImageUrl="~/images/googlemaps.png" Height="35px" Width="35px"></asp:Image>
                        </td>
                        <td style="width: 90%">
                            <asp:Label ID="lGooglemaps" runat="server" Text="Google maps:" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </tr>

                </table>

                <table border="0" cellpadding="5" cellspacing="5" height="35px" style="width: 100%;">
                    <tr>
                        <div id="map_canvas" style="border-top: none; width: 100%; margin-top: -1px; height: 100%; background-color: #FAFAFA; margin-top: 0px;">
                            <asp:Label ID="lMapError" runat="server" Text=""></asp:Label>
                        </div>
                    </tr>
                </table>
            </td>--%>
            <td style="width: 100%;">
              
                <table border="0" cellpadding="5" cellspacing="5" height="35px" style="width: 100%;">
                    <tr>

                        <td style="width: 10%">
                             <asp:ImageButton ID="imgCalendar" runat="server" ImageUrl="~/images/questionmark.png" Height="15" Width="15" OnClientClick="return false;" />
                <asp:Panel runat="server" ID="pnlimgCalendar" Enabled="false">
                This is your calendar with all the job application moments and interview moments. This calendar is automatically synchronized with your job application forms. When you click on an item 
                    you go to the corresponding job application form. You can also choose to open items in the job application gridview (see the option: 'open job application in gridview').
                    </br>
                    <table>
                         <tr>
                                <td>
                                   - Job appl: .. = Job application apply date (see the job application form).
                                </td>
                            </tr>
                            <tr>
                                <td>
                                   - 1st IV: .. = First interview of a certain job application (see the job application form).
                                </td>
                            </tr>
                               <tr>
                                <td>
                                   - 2nd IV: .. = Second interview of a certain job application (see the job application form).
                                </td>
                            </tr>
                                <tr>
                                <td>
                                   - 3rd IV: .. = Third interview of a certain job application (see the job application form).
                                    </td>
                            </tr>
                        </table>    
                </asp:Panel>
                <ajaxToolkit:BalloonPopupExtender ID="BalloonPopupExtender3" runat="server"
                    TargetControlID="imgCalendar"
                    BalloonPopupControlID="pnlimgCalendar"
                    Position="TopRight"
                    BalloonStyle="Cloud"
                    BalloonSize="Large"
                    UseShadow="false"
                    ScrollBars="Auto"
                    DisplayOnMouseOver="false"
                    DisplayOnFocus="false"
                    DisplayOnClick="true" />

                            <asp:Image runat="server" ImageUrl="~/images/agenda.png" Height="35px" Width="35px"></asp:Image>
                        </td>
                        <td style="width: 90%">
                            <asp:Label ID="lAgenda" runat="server" Text="Calendar:" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                    <%-- <tr>
                        <td></td>
                        <td style="width: 100%"></td>
                    </tr>--%>
                </table>
                  <div id="Agenda" style="border-top: none; width: 100%; margin-top: -1px; height: 100%; background-color: #e6e6e6; margin-top: 0px; border-radius: 15px; background: #FFFFFF;">
                <table border="0" cellpadding="5" cellspacing="5" height="35px" style="width: 100%;">
                    <tr>
                        <asp:CheckBox ID="cbOpenJobAppl" runat="server" Checked="false" OnCheckedChanged="cbOpenJobAppl_CheckedChanged" AutoPostBack="true" Text=" Open job application in gridview." Font-Size="Small" />
                        <div id='calendar' style="border-top: none; width: 100%; margin-top: -1px; height: 100%; margin-top: 0px;">
                        </div>
                    </tr>
                </table>
               </div>
                <%-- <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>--%>
            </td>
        </tr>
    </table>

    <br />
    <br />
    <td style="width: 50%;">
       
        <table border="0" cellpadding="5" cellspacing="5" height="35px" style="width: 100%;">
            <tr>
                <td style="width: 10%">
                     <asp:ImageButton ID="imgJobApplGridview" runat="server" ImageUrl="~/images/questionmark.png" Height="15" Width="15" OnClientClick="return false;" />
                <asp:Panel runat="server" ID="pnlimgJobApplGridview" Enabled="false">
               This is a gridview with all your registered job applications. To go to the corresponding job application form of a certain job application click on edit or view.
                    When you click on edit the job application form opens and can be edited. If you click view the job application form opens and is read-only. 
                </asp:Panel>
                <ajaxToolkit:BalloonPopupExtender ID="BalloonPopupExtender2" runat="server"
                    TargetControlID="imgJobApplGridview"
                    BalloonPopupControlID="pnlimgJobApplGridview"
                    Position="TopRight"
                    BalloonStyle="Cloud"
                    BalloonSize="Large"
                    UseShadow="false"
                    ScrollBars="Auto"
                    DisplayOnMouseOver="false"
                    DisplayOnFocus="false"
                    DisplayOnClick="true" />

                    <asp:Image runat="server" ImageUrl="~/images/gridview.png" Height="35px" Width="35px"></asp:Image>
                </td>
                <td style="width: 90%">
                    <asp:Label ID="lJobApplications" runat="server" Text="My Job Applications:" Font-Bold="True" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
        </table>
            <div id="JobApplGridview" style="border-top: none; width: 100%; margin-top: -1px; height: 100%; background-color: #e6e6e6; margin-top: 0px;border-radius: 15px; background:#FFFFFF; overflow: scroll;">        
        <br />
         <br />
        <%-- <asp:Panel ID="DashBoardJobApplicationsPanel" runat="server" ScrollBars="Both" Height="500">--%>
       <%-- <div style="height: 700px;">--%>
          <%--  <asp:GridView ID="DashBoardJobApplicationsGV" runat="server" AutoGenerateColumns="false" AllowPaging="False" CssClass="DashBoardJobApplicationsGVcss">
            </asp:GridView>--%>
             <uc:UCJobApplications runat="server" ID="UCJobApplications" EnableViewState="True" />
        <%--</div>--%>
        <%--     </asp:Panel>--%>
      </div>
        <div style="text-align: left; padding-top: 18px;">
            <asp:ImageButton ID="ImageButtonExcell" runat="server"></asp:ImageButton>
        </div>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
     <script type="text/javascript" src="https://d3js.org/d3.v3.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="js/cloud.min.webforms.js"></script>

   <%-- <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDosSQDg_x8pTJMnz2DuvwzAyyfcydviRo" type="text/javascript"></script>
    <script type="text/javascript">--%>
<%--        //jQuery(document).ready(function () {

        //function GoogleMap() {

        //    var items = markers[0].length - 1;
        //    var mapOptions = {
        //        center: new google.maps.LatLng(markers[0][items].lat, markers[0][items].lng),
        //        zoom: 8,
        //        mapTypeId: google.maps.MapTypeId.ROADMAP
        //    };
        //    var infoWindow = new google.maps.InfoWindow();
        //    var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
        //    var jobImage = new google.maps.MarkerImage("http://www.googlemapsmarkers.com/v1/J/FC7119/");
        //    var homeImage = new google.maps.MarkerImage("http://www.googlemapsmarkers.com/v1/H/379CDF/");
        //    //var items = markers[0].length;

        //    for (i = 0; i < markers[0].length; i++) {
        //        var data = markers[0][i];

        //        // if we're not on the last iteration then:
        //        if (i != markers[0].length - 1) {
        //            var marker = new google.maps.Marker({
        //                position: new google.maps.LatLng(data.lat, data.lng),
        //                icon: jobImage,
        //                map: map
        //            });

        //        }
        //        else {
        //            var marker = new google.maps.Marker({
        //                position: new google.maps.LatLng(data.lat, data.lng),
        //                icon: homeImage,
        //                map: map
        //            });
        //        }
        //    }
        //    (function (marker, data) {
        //        google.maps.event.addListener(marker, "click", function (e) {
        //            infoWindow.setContent(data.description);
        //            infoWindow.open(map, marker);
        //        });
        //    })(marker, data);

        //}
        //});--%>

  <%--  </script>--%>
</asp:Content>



