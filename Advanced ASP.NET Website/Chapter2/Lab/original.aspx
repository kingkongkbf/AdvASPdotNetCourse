<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="original.aspx.cs" Inherits="Chapter2_Lab_original" Theme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <AjaxCTK:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
            <AjaxCTK:TabPanel ID="TabPanel1" runat="server" HeaderText="Product Listing">                         
                <ContentTemplate>
                   

            <asp:Panel ID="Panel_List" runat="server" GroupingText="List all products">
    <asp:GridView ID="GV" runat="server" AllowPaging="True" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ProductID" 
            DataSourceID="DS_AllProducts" ForeColor="#333333" GridLines="None" 
            onselectedindexchanged="GV_SelectedIndexChanged" 
            onpageindexchanged="GV_PageIndexChanged" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="ProductNumber" HeaderText="ProductNumber" 
                SortExpression="ProductNumber" />
            <asp:BoundField DataField="Color" HeaderText="Color" SortExpression="Color" />
            <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" 
                SortExpression="ModifiedDate" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        <asp:SqlDataSource ID="DS_AllProducts" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AdventureWorksConnectionString %>" 
            SelectCommand="SELECT [Name], [ProductNumber], [Color], [ModifiedDate], [ProductID] FROM [Product] ORDER BY [Name]">
        </asp:SqlDataSource>
        <asp:Literal ID="lbl_ListAllProductModel" runat="server" />
</asp:Panel>

</ContentTemplate>
</AjaxCTK:TabPanel>

              
                <AjaxCTK:TabPanel ID="TabPanel2" runat="server" HeaderText="Product Creation">
                <ContentTemplate>

                <asp:Panel ID="Panel_Create" runat="server" GroupingText="Create new Product">
    <table border="0" width="100%">
    <tr valign="top">
    <td width="5%">Name</td>
    <td width="*"><asp:TextBox ID="txt_Name" runat="server" MaxLength="100" />
    <asp:RequiredFieldValidator ID="Req_Name" runat="server" 
            ControlToValidate="txt_Name" Display="None" 
            ErrorMessage="<b>Required Field Missing</b><br />A product name is required." 
            SetFocusOnError="True" />

    </td>
    </tr>
    <tr valign="top">
    <td>Product Number</td>
    <td><asp:TextBox ID="txt_ProductNumber" runat="server" MaxLength="50" />
    <asp:RequiredFieldValidator ID="Req_PdtNo" runat="server" 
            ControlToValidate="txt_ProductNumber" Display="None" 
            ErrorMessage="<b>Required Field Missing</b><br />A product number is required." 
            SetFocusOnError="True" />
                    
    </td>
    </tr>
    <tr valign="top">
    <td>Color</td>
    <td><asp:TextBox ID="txt_Color" runat="server" MaxLength="30" />
    <asp:RequiredFieldValidator ID="Req_Color" runat="server" 
            ControlToValidate="txt_Color" Display="None" 
            ErrorMessage="<b>Required Field Missing</b><br />A product color is required." 
            SetFocusOnError="True" />
    </td>
    </tr>
    <tr valign="top">
    <td>Standard Cost</td>
    <td><asp:TextBox ID="txt_StandardCost" runat="server" MaxLength="20" />
    <asp:RequiredFieldValidator ID="Req_StandardCost" runat="server" 
            ControlToValidate="txt_StandardCost" Display="None" 
            ErrorMessage="<b>Required Field Missing</b><br />A product Standard Cost is required."  
            SetFocusOnError="True"/>
            
    </td>
    </tr>
    <tr valign="top">
    <td>List Price</td>
    <td><asp:TextBox ID="txt_ListPrice" runat="server" MaxLength="20" />
    <asp:RequiredFieldValidator ID="Req_ListPrice" runat="server" 
            ControlToValidate="txt_ListPrice" Display="None" 
            ErrorMessage="<b>Required Field Missing</b><br />A product List Price is required."  
            SetFocusOnError="True"/>
                   <asp:CompareValidator ID="cp_ListPrice" runat="server" 
            ControlToCompare="txt_StandardCost" ControlToValidate="txt_ListPrice" 
            Display="None" Operator="GreaterThan" SetFocusOnError="True" Type="Currency" ErrorMessage="<b>Invalid List Price</b><br />List price cannot be higher than standard cost" />

    </td>
    </tr>
    <tr valign="top">
    <td>Size</td>
    <td><asp:TextBox ID="txt_Size" runat="server" MaxLength="10" />
    <asp:RequiredFieldValidator ID="Req_Size" runat="server" 
            ControlToValidate="txt_Size" Display="None" 
            ErrorMessage="<b>Required Field Missing</b><br />A product size is required."  
            SetFocusOnError="True"/>
           
    </td>
    </tr>
    <tr valign="top">
    <td>Weight</td>
    <td><asp:TextBox ID="txt_Weight" runat="server" MaxLength="10" />
    <asp:RequiredFieldValidator ID="Req_Weight" runat="server" 
            ControlToValidate="txt_Weight" Display="None" 
            ErrorMessage="<b>Required Field Missing</b><br />A product weight is required."  
            SetFocusOnError="True"/>

    </td>
    </tr>
    
        <tr valign="top">
    <td>Category</td>
    <td><asp:DropDownList ID="ddl_Category" runat="server" DataSourceID="DS_Category" 
            DataTextField="Text" DataValueField="ID" EnableViewState="False" 
            AutoPostBack="True" 
            onselectedindexchanged="ddl_Category_SelectedIndexChanged" 
            AppendDataBoundItems="True" >
        <asp:ListItem Value="0">Choose a parent category</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="DS_Category" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AdventureWorksConnectionString %>" 
            SelectCommand="select ProductCategoryID as ID, Name as Text from ProductCategory where ParentProductCategoryID is null order by Name">
        </asp:SqlDataSource>
               
        
        <asp:DropDownList ID="ddl_Category2" runat="server" EnableViewState="False" />
            </td>
    </tr>

    </table>
    <asp:Button ID="btn_Submit" runat="server" Text="Submit" 
            onclick="btn_Submit_Click" />
</asp:Panel>

              <%--  </AjaxCTK:TabPanel>
            </AjaxCTK:TabContainer>--%>
              </ContentTemplate>
              </AjaxCTK:TabPanel>
              </AjaxCTK:TabContainer>
              </ContentTemplate>
    </asp:UpdatePanel>

    </form>
</body>
</html>




<%--<%To add to above. Javascript for updating the time%>
<%<script type="text/javascript" language="javascript">
            function updateTime()
            {
                var label = document.getElementById('ctl00_SampleContent_currentTime');
                if (label) {
                    var time = (new Date()).localeFormat("T");
                    label.innerHTML = time;
                }
            }
            updateTime();
            window.setInterval(updateTime, 1000);
        </script> %>

        <% %>--%>
