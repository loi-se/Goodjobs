<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCJobApplications.ascx.cs" Inherits="Jobhunt.UserControls.UCJobApplications" EnableViewState="true" %>



<div style="text-align:center; width: 100%"> 
<asp:Panel ID="Psearch" runat="server" Visible ="false">
<table border="0" cellpadding="5" cellspacing="5">
    <tr>
        <td>
            <asp:TextBox ID="TSearch" runat="server" EnableViewState="True" Width="480" ></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="BSearch" runat="server" Text="Search" OnClick="SearchMyJobApplications" ValidationGroup="Search" CausesValidation="False"/>
        </td>
        <td>
            <asp:Label ID="lsearch" runat="server" Text=""></asp:Label>
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="At least 3 characters" ForeColor="Red" ValidationGroup="Search" ControlToValidate="TSearch" runat="server" EnableClientScript="True" />
        </td>
        <td>
            <asp:RegularExpressionValidator ValidationExpression="^[\S\s]{3,40}$" ValidationGroup="Search" ID="regTSearch" runat="server" ErrorMessage="At least 3 characters" ForeColor="Red" ControlToValidate="TSearch" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="BViewAll" runat="server" Text="View all" OnClick="ViewAllJobApplications" />
        </td>
    </tr>
</table>
</asp:Panel>
<asp:Panel ID="pPreviousNext" runat="server" style="display: block; text-align: center; margin: auto;" Height="50" Width="120">
    <asp:ImageButton ID="imgBPrevious" runat="server" OnClick="imgBPrevious_click" Height="40" Width="40" Visible="False" />
    <asp:ImageButton ID="imgBNext" runat="server" OnClick="imgBNext_click" Width="40" Height="40" Visible="False" />
</asp:Panel>
</div>
    <asp:GridView ID="DashBoardJobApplicationsGV" runat="server" AutoGenerateColumns="false" AllowPaging="False" CssClass="DashBoardJobApplicationsGVcss"
        AllowCustomPaging="True">
    </asp:GridView>
<asp:Panel ID="pnlCustomPager" runat="server">
    <asp:Label ID="lSelPageText" runat="server" Text="Selected page:" ForeColor="Black"></asp:Label>
    <asp:DropDownList ID="ddlCustomPager" runat="server" onselectedindexchanged="ddlCustomPagerItemSelected" AutoPostBack="True" EnableViewState="True"></asp:DropDownList>
    <asp:Label ID="lNofPagesText" runat="server" Text="(Total number of result pages:" ForeColor="Black" Font-Size="Small"></asp:Label>
    <asp:Label ID="lTotalPages" runat="server" Text="" ForeColor="Black" Font-Size="Small"></asp:Label>
</asp:Panel>
<asp:Label ID="lJobApplications" runat="server" Text="" Font-Bold="True"></asp:Label>
