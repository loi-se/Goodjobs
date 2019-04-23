<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCContactsInvitations.ascx.cs" Inherits="Jobhunt.UserControls.UCContactsInvitations" EnableViewState="true"  %>
<asp:GridView ID="ApplicantsGV" runat="server" AutoGenerateColumns="false" CssClass="DashBoardJobApplicationsGVcss"
   style="width:100%">
</asp:GridView>
<asp:Panel ID="pnlCustomPager" runat="server">
    <asp:Label ID="lSelPageText" runat="server" Text="Selected page:" ForeColor="Black"></asp:Label>
    <asp:DropDownList ID="ddlCustomPager" runat="server" onselectedindexchanged="ddlCustomPagerItemSelected" AutoPostBack="True" EnableViewState="True"></asp:DropDownList>
    <asp:Label ID="lNofPagesText" runat="server" Text="(Total number of result pages:" ForeColor="Black" Font-Size="Small"></asp:Label>
    <asp:Label ID="lTotalPages" runat="server" Text="" ForeColor="Black" Font-Size="Small"></asp:Label>
</asp:Panel>
<asp:Label ID="lContactsInvitations" runat="server" Text="" Font-Bold="True"></asp:Label>