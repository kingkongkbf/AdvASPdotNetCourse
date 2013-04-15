<%@ Page Title="Chapter 1 : Demo 1 : Before Ajax" Language="C#" MasterPageFile="~/Chapter1/Demo/MasterPage.master" AutoEventWireup="true" CodeFile="before.aspx.cs" Inherits="Chapter1_Demo1_before" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="swfobject.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:GridView ID="GV" runat="server" AllowPaging="True" AllowSorting="True" 
        AutoGenerateColumns="False" DataSourceID="DS" CellPadding="4" 
        ForeColor="#333333" GridLines="None" >
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
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
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>        
    <asp:SqlDataSource ID="DS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorksConnectionString %>" 
        SelectCommand="SELECT [Title], [FirstName], [MiddleName], [LastName], [CompanyName] FROM [Customer] ORDER BY [FirstName], [MiddleName], [LastName]">
    </asp:SqlDataSource>
        <hr />
    <ol>
    <li>Notice how the the whole page refreshes itself after each postback when only the grid is changing</li>
    <li>Pressing F5 gives you a prompt to resend data, not very nice, and potentially very damaging</li>
    </ol>
</asp:Content>

