<%@ Page Language="C#" MasterPageFile="~/JobHunter.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
<div class="default1" style="height:500px;">
 <table border="0" cellpadding="5" cellspacing="5">
    <tr>
        <th colspan="3">
            Sign in:
        </th>
    </tr>
    <tr>
        <td width="150">
            E-mail:  <span style="color:red">*</span>
        </td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server" EnableViewState="True" Width="400px" />
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="Required" ValidationGroup="UserLogin" ForeColor="Red" ControlToValidate="txtEmail"
                runat="server" />
            <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ControlToValidate="txtEmail" ForeColor="Red"  ValidationGroup="UserLogin" ErrorMessage="Invalid email address." />
        </td>
    </tr>
    <tr>
        <td width="150">
            Password:  <span style="color:red">*</span>
        </td>
        <td>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"  Width="400px" />
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="Required" ValidationGroup="UserLogin" ForeColor="Red" ControlToValidate="txtPassword"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:Button ID="btnLogin" Text="Login" runat="server" ValidationGroup="UserLogin" OnClick="LoginUser" />
        </td>
        <td>
        </td>
    </tr>

       <tr>
        <td>
        </td>
        <td>
            <asp:Label ID="lblLoggedIn" runat="server" Text=""></asp:Label>
        </td>
    </tr>
     <tr>
        <td>
        </td>
        <td>
            <asp:LinkButton ID="lbtnForgotPassword" OnClick="ShowForgotPasswordPanel" runat="server" style="color:#0099FF">Forgot your password?</asp:LinkButton>
  <%--          <asp:HyperLink ID="hlForgotPassword" OnClick="ShowForgotPasswordPanel" runat="server">Forgot your password?</asp:HyperLink>--%>
        </td>
    </tr>
</table>
    <asp:Panel ID="pForgotPassword" runat="server" Visible="False">
        <table border="0" cellpadding="5" cellspacing="5">
            <tr>
                <td width="150">E-mail:  <span style="color: red">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtForgotPasswordEmail" runat="server" EnableViewState="True" Width="400px" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtForgotPasswordEmail"
                        runat="server" ValidationGroup="ForgottenPassword" />
                    <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ControlToValidate="txtForgotPasswordEmail" ValidationGroup="ForgottenPassword" ForeColor="Red" ErrorMessage="Invalid email address." />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnForgotPasswordSend" Text="Send" runat="server" ValidationGroup="ForgottenPassword" OnClick="SendForgottenPassword" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="lblForgotPassword" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
 </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>