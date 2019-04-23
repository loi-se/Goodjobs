<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCUserAccount.ascx.cs" Inherits="Jobhunt.UCUserAccount" %>
 <table border="0" cellpadding="5" cellspacing="5">
    <tr>
            <asp:Label ID="lHeader" runat="server" Text="" Font-Bold="True" Font-Size="Medium" ></asp:Label>
    </tr>
    <tr>
        <td>
            Username:  <span style="color:red">*</span>
        </td>
        <td>
            <asp:TextBox ID="txtUsername" runat="server" EnableViewState="True" Width="400px" />
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtUsername"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Password:  <span style="color:red">*</span>
        </td>
        <td>
            <asp:TextBox ID="txtPassword" runat="server" EnableViewState="True" Width="400px" />
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                runat="server" />
            <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,16}$"
                ControlToValidate="txtPassword" ForeColor="Red" ErrorMessage="Password must be at least 8 characters, no more than 16 characters, and must include at least one upper case letter, one lower case letter, and one numeric digit." />
        </td>
    </tr>
    <tr>
        <td>
            Confirm Password: <span style="color:red">*</span>
        </td>
        <td>
            <asp:TextBox ID="txtConfirmPassword" runat="server" EnableViewState="True" Width="400px" />
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                ControlToValidate="txtConfirmPassword" runat="server" />
            <asp:CompareValidator ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="txtPassword"
                ControlToValidate="txtConfirmPassword" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Email:  <span style="color:red">*</span>
        </td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server" EnableViewState="True" Width="400px" />
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                ControlToValidate="txtEmail" runat="server" />
            <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
        </td>
    </tr>

        <tr>
        <td>
          First name:
        </td>
        <td>
            <asp:TextBox ID="txtFirstName" runat="server" EnableViewState="True" Width="400px" />
        </td>
    </tr>

        <tr>
        <td>
          Last name:
        </td>
        <td>
            <asp:TextBox ID="txtLastName" runat="server" EnableViewState="True" Width="400px" />
        </td>
     </tr>

       <tr>
        <td>
          City:
        </td>
        <td>
            <asp:TextBox ID="txtCity" runat="server" EnableViewState="True" Width="400px" />
        </td>
    </tr>
    <tr>
        <td>
          Streetname:
        </td>
        <td>
            <asp:TextBox ID="txtStreetName" runat="server" EnableViewState="True" Width="400px" />
        </td>
    </tr>
    <tr>
        <td>
          Streetnumber:
        </td>
        <td>
            <asp:TextBox ID="txtStreetNumber" runat="server" EnableViewState="True" Width="400px" />
        </td>
    </tr>
    <tr>
        <td>
          Zipcode:
        </td>
        <td>
            <asp:TextBox ID="txtZipCode" runat="server" EnableViewState="True" Width="400px" />
        </td>
    </tr>

     <tr>
        <td>
          Country:
        </td>
        <td>
            <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" Width="400px"></asp:DropDownList>
        </td>
    </tr>

     <tr>
        <td>
          LinkedIn:
        </td>
        <td>
            <asp:TextBox ID="txtLinkedIn" runat="server" EnableViewState="True" Width="400px" />
        </td>
    </tr>

    <tr>
        <td>
            Birth date:  <span style="color:red">*</span>
        </td>
        <td>    
        <input style="visibility: hidden" id="datepickerBirthDateValue" name="datepickerBirthDateValue" value=""/>
            <p> <asp:TextBox ID="datepickerBirthDateText" runat="server" EnableViewState="True" Width="400px" /></p >
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="datepickerBirthDateText"
                runat="server" />
        </td>
    </tr>

    

    <tr>
        <td>
        </td>
        <td>    
        </td>
    </tr>

    <tr>
        <td>
            Search tags 
            <br /> 
            (please seperate tags by a comma):
        </td>
        <td>    
             <asp:TextBox ID="txtSearchTags" runat="server" EnableViewState="True" Width="400px" />
        </td>
    </tr>


      <tr>
        <td>
            Main career field:
        </td>
        <td>    
            <asp:DropDownList ID="ddlMainCareerField" onselectedindexchanged="itemSelected" runat="server" AutoPostBack="True" Width="400px"></asp:DropDownList>
        </td>
    </tr>

     <tr>
        <td>
            Sub career field:
        </td>
        <td>    
            <asp:DropDownList ID="ddlSubCareerField" runat="server" Width="400px"></asp:DropDownList>
        </td>
    </tr>

      <tr>
        <td>
        </td>
        <td>    
        </td>
    </tr>

    <tr runat="server" id=trHidetxtOldPassword>
        <td>
            Old Password:  <span style="color:red">*</span>
        </td>
        <td>
            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" EnableViewState="True"  Width="400px" Visible="False" />
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtOldPassword"
                runat="server" />
        </td>
    </tr>

    <tr>
        <td>
        </td>
        <td>
            <asp:Button Text="Submit" id="submitButton" runat="server" OnClick="CreateUser" />
        </td>
        <td>
        </td>
    </tr>

      <tr>
        <td>
        </td>
        <td>
            <asp:Label ID="labelCreateUser" runat="server" Text=""></asp:Label>
            <br>

            <asp:HyperLink ID="hLinkCreateUser" runat="server" style="color:#0099FF"></asp:HyperLink>
        </td>
    </tr>
</table>