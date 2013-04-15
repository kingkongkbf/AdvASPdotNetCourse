<%@ Page Title="Chapter 1 : Demo 1 : After Ajax" Language="C#" MasterPageFile="~/Chapter1/Demo/MasterPage.master" AutoEventWireup="true" CodeFile="after.aspx.cs" Inherits="Chapter1_Demo1_after" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!-- 
ScriptManager needs to to appear before any ASP.NET Ajax controls, otherwise you will encounter an error

This is the main control that enables all other controls to have ajax like functionality.
-->
<asp:ScriptManager ID="SM" runat="server" />
<!--
Here's the updatepanel.

The code inside ContentTemplate is the same as before. but now that they are inside ContentTemplate, their behaviour becomes ajax like 
-->
        <asp:UpdatePanel ID="UP" runat="server"><ContentTemplate>
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
    </ContentTemplate></asp:UpdatePanel>
    <asp:SqlDataSource ID="DS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorksConnectionString %>" 
        SelectCommand="SELECT [Title], [FirstName], [MiddleName], [LastName], [CompanyName] FROM [Customer] ORDER BY [FirstName], [MiddleName], [LastName]">
    </asp:SqlDataSource>
        <hr />
    <ol>
    <li>Notice now only the grid refreshes its data while the rest of the page stays the same</li>
    <li>Pressing F5 does not cause any problems now</li>
    </ol>
</asp:Content>

