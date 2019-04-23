<%@ Page Language="C#" MasterPageFile="~/JobHunter.Master" AutoEventWireup="true" CodeBehind="Faq.aspx.cs" Inherits="_Faq" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
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

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="divGeneral" style="height: 500px;">
         <asp:Label ID="lFaq" runat="server" Text="FAQ" Font-Bold="True" Font-Size="Medium"></asp:Label>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <ajaxToolkit:Accordion ID="Accordion1" runat="server" CssClass="accordion" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" RequireOpenedPane="False" SelectedIndex="-1">
            <Panes>
                <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane1">
                    <Header><asp:Image runat="server" ImageUrl="~/images/questionmark.png" Height="25px" Width="25px"></asp:Image>Why would I use this web application to register my job applications instead of an Excel file?</Header>
                    <Content>
                          <table>
                            <tr>
                                <td>
                                   - In the longer term you gain far more insight into all your job application data through the clear dashboard and job application form.
                                    You can see statistics of all your job application data and all your data is easily searchable and navigable.
                                </td>
                            </tr>
                               <tr>
                                <td>
                                   - The application provides a blueprint of which job application data is useful to keep track of. 
                                </td>
                            </tr>
                                <tr>
                                <td>
                                   - This web application can give you far more overview over all your job application details (including vacancy texts and job application letters) then an Excel file can give you. 
                                </td>
                            </tr>
                                <tr>
                                <td>
                                   - The job application form is quick to fill in and this saves you time. We strive for a high degree of user-friendliness and for a job application registration process that is as optimized as possible.
                                </td>
                            </tr>
                            <tr>
                                <td>
                                   - The ability to share your job application forms with others and see the job application forms of other users. 
                                </td>
                            </tr>
                            <tr>
                                <td>
                                   - You can always export your job applications to an Excell file (to store everything local) so the one does not exclude the other.
                                </td>
                            </tr>
                        </table>               
                    </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane2">
                    <Header><asp:Image runat="server" ImageUrl="~/images/questionmark.png" Height="25px" Width="25px"></asp:Image> Is my data private and safe?</Header>
                    <Content>
                          We do the following to guarantee your data is safe and private:
                        <table>
                            <tr>
                                <td>
                                   - Strong password policy (password must be at least 8 characters and must include at least one upper case letter, one lower case letter, and one numeric digit).
                                </td>
                            </tr>
                            <tr>
                                <td>
                                   - ASP.NET Forms Authentication is used for the authentication of users.  
                                </td>
                            </tr>
                           
                               <tr>
                                <td>
                                   - We use SSL to encrypt communication between the server and the client (HTTPS).
                                </td>
                            </tr>
                            <tr>
                                <td>
                                   - All your data is stored encrypted using modern encryption algorithms.
                                </td>
                            </tr>
                            <tr>
                                <td>
                                   - Daily database backups ensure that the data is not lost.
                                </td>
                            </tr>
                        </table>            
                    </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane3">
                    <Header><asp:Image runat="server" ImageUrl="~/images/questionmark.png" Height="25px" Width="25px"></asp:Image>Do I have to pay for this service?</Header>
                    <Content>
                        No this is a free web application.          
                    </Content>
                </ajaxToolkit:AccordionPane>               
                 <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane4">
                    <Header><asp:Image runat="server" ImageUrl="~/images/questionmark.png" Height="25px" Width="25px"></asp:Image>Does this web application also work on my tablet or mobile phone?</Header>
                    <Content>
                        This web application is optimized and developed for standard web browsers on desktop PC's and laptops (Chrome, Firefox, Internet Explorer, Microsoft Edge, and Opera).
                        You have the best user experience by using the web browser: Chrome. This web application also works on tablets (Ipads) and mobile phones but a 100% good operation of the web application on these devices can not be guaranteed.       
                    </Content>
                </ajaxToolkit:AccordionPane>
            </Panes>
        </ajaxToolkit:Accordion>
        <%--</form>--%>
        <asp:TreeView ID="TreeView1" runat="server"></asp:TreeView>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>