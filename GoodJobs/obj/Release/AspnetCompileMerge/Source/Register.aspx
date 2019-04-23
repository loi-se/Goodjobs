<%@ Page Language="C#" MasterPageFile="~/JobHunter.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="_Register" %>
<%@ Register TagPrefix="uc" TagName="UCUserAccount" Src="~/UserControls/UCUserAccount.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
      <%--<link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />--%>
      <link href="https://code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" rel="stylesheet" type="text/css">
      <link href="css/jquery-ui.min.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
   <uc:UCUserAccount runat="server" ID="UCUserAccount" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
    <script type="text/javascript" src="js/jquery-3.1.1.js"></script>
    <%--<script type="text/javascript" src="js/jquery-ui.js"></script>--%>
     <script type="text/javascript" src="js/jquery-ui.min.js"></script>

      <script type="text/javascript">
        $(document).ready(function () {
        $(function () {
            $("#ContentPlaceHolderMain_UCUserAccount_datepickerBirthDateText").datepicker({
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