<%@ Page Language="C#" MasterPageFile="~/JobHunter.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="_About" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="divGeneral" style="height: 500px;">
        <table border="0" cellpadding="5" cellspacing="5" style="width: 50%; position: relative">
            <tr>
                <td style="width: 100%">
                    <asp:Label ID="lAbout" runat="server" Text="About:" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100%">
                    <asp:Label ID="lAboutUs" runat="server" Text="The mission of GoodJobs is to make the life of a job searcher easier.
                        In a long job search it is important to stay organized and have all your data readily available.
                        GoodJobs offers a free web application in which you can do just that: stay organized in your job search and have all your data available in one place.

                        Goodjobs gives you the big picture over your job search and helps 
                            you to connect the dots. Sometimes a job search can be a tedious process with a lot of 
                            data you need to keep track of. Most people then use an Excell sheet to organize their job search. But this doesn't really
                            give you the big picture over your job search like GoodJobs can give you. GoodJobs will make your job search a lot easier.
                         "></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>