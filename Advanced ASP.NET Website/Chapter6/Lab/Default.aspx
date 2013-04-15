<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Chapter6_Lab_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="frm" runat="server">
    <a href="Default.aspx">Refresh</a>
    <asp:ScriptManager ID="SM" runat="server" />
    <asp:UpdatePanel ID="UP" runat="server"><ContentTemplate>
    </ContentTemplate></asp:UpdatePanel>
    <asp:GridView ID="GV" runat="server" 
        AutoGenerateColumns="False" DataKeyNames="SalesOrderID" DataSourceID="DS" 
        onselectedindexchanged="GV_SelectedIndexChanged" AllowPaging="True" 
        CellPadding="4" ForeColor="#333333" GridLines="None" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                SortExpression="FirstName" />
            <asp:BoundField DataField="MiddleName" HeaderText="MiddleName" 
                SortExpression="MiddleName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" 
                SortExpression="LastName" />
            <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" 
                SortExpression="CompanyName" />
            <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" 
                SortExpression="OrderDate" />
            <asp:BoundField DataField="Status" HeaderText="Status" 
                SortExpression="Status" />
            <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" 
                SortExpression="SubTotal" />
            <asp:BoundField DataField="TotalDue" HeaderText="TotalDue" 
                SortExpression="TotalDue" />
            <asp:CommandField ButtonType="Button" SelectText="View Transactions" 
                ShowSelectButton="True" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <hr />
    <asp:Literal ID="lbl" runat="server" />
    <asp:SqlDataSource ID="DS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorksConnectionString %>" 
            
        SelectCommand="SELECT S.SalesOrderID, C.Title, C.FirstName, C.MiddleName, C.LastName, C.CompanyName, S.OrderDate, S.Status, S.SubTotal, S.TotalDue FROM SalesOrderHeader AS S INNER JOIN Customer AS C ON S.CustomerID = C.CustomerID ORDER BY S.ModifiedDate DESC">
    </asp:SqlDataSource>
    </form>
</body>
</html>
