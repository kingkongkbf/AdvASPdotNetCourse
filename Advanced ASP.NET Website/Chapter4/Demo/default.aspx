<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="Chapter4_linqtosql" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    This grid shows all the Addresses containing the charcters "chi"
    <asp:GridView ID="GV" runat="server" />
    <table border="1" cellspacing="4" cellpadding="4">
    <tr valign="top"><td>
    Click this button to update the last modified column<br />
    <asp:Button ID="btn_Update" runat="server" Text="Update Some Data" 
        onclick="btn_Update_Click" />
    </td>
    <td>
    Click this button to attempt a fake "SQL injection"<br />
        <asp:Button ID="btn_SQLInjection" runat="server" Text="Attempt SQL Injection" 
        onclick="btn_SQLInjection_Click" />
    </td>
    </tr>
    </table>
        
    </form>
</body>
</html>
