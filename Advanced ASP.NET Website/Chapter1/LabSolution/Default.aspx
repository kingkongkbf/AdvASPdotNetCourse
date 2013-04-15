<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Chapter1_LabSolution_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="SM" runat="server" />
    <asp:UpdatePanel ID="UP" runat="server"><ContentTemplate>    
    <asp:Timer ID="TM" runat="server" Interval="5000" ontick="TM_Tick" />
    <asp:GridView ID="GV" runat="server" DataSourceID="SqlDataSource2" 
            EnableModelValidation="True" />
    <asp:Label ID="lbl" runat="server" />    
        <asp:SqlDataSource ID="DS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorksConnectionString %>" 
        SelectCommand="SELECT top 20 [Title], [FirstName], [MiddleName], [LastName], [CompanyName] FROM [Customer] ORDER BY newid()">
    </asp:SqlDataSource>    
    </ContentTemplate></asp:UpdatePanel>
    </form>
</body>
</html>
