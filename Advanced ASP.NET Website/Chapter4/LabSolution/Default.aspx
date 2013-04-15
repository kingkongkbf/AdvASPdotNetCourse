<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Chapter4_Lab_Default" Theme="default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type='text/javascript'>
        function cancelClick() {
            alert("Delete operation cancelled");
        }
</script>

</head>
<body>
    <form id="form1" runat="server">
    <AjaxCTK:ToolkitScriptManager runat="server" EnablePartialRendering="true" ID="ScriptManager1" />

    <!-- Show Current Time -->    
    <asp:Panel ID="timer" runat="server"
        Width="250px" BackColor="White" ForeColor="DarkBlue"
        BorderWidth="2" BorderStyle="solid" BorderColor="DarkBlue" style="z-index: 1;">
            <div style="width: 100%; height: 100%; vertical-align: middle; text-align: center;">
                <p>Current Time:</p>
                <span id="currentTime" runat="server" style="font-size:large;font-weight:bold;"/>
            </div>
    </asp:Panel>
    <AjaxCTK:AlwaysVisibleControlExtender ID="avce" runat="server"
        TargetControlID="timer"
        VerticalSide="Top"
        VerticalOffset="10"
        HorizontalSide="Right"
        HorizontalOffset="10"
        ScrollEffectDuration=".1" Enabled="True" />
    <!-- Show Current Time -->            
    
        <asp:UpdatePanel ID="UP" runat="server"><ContentTemplate>
    <AjaxCTK:TabContainer ID="TC" runat="server" ActiveTabIndex="0">
    <AjaxCTK:TabPanel ID="TP_ListAllProducts" runat="server" HeaderText="List All Products">
    <ContentTemplate>
    <asp:GridView ID="GV" runat="server" AllowPaging="True" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ProductID" 
            DataSourceID="DS_AllProducts" ForeColor="#333333" GridLines="None" 
            onselectedindexchanged="GV_SelectedIndexChanged" 
            onpageindexchanged="GV_PageIndexChanged" onrowdatabound="GV_RowDataBound" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                <ItemTemplate>
             <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>' Width="100%" />
                
<asp:Panel ID="DropPanel" runat="server" CssClass="ContextMenuPanel" Style="display :none; visibility: hidden;">
            <asp:LinkButton runat="server" CausesValidation="false" ID="lb_Select" Text="Select" CommandName="Select" CssClass="ContextMenuItem" />
            <asp:LinkButton runat="server" CausesValidation="false" ID="lb_Delete" Text="Delete" CommandName="Delete" CssClass="ContextMenuItem"/>
        </asp:Panel>

            
             <AjaxCTK:DropDownExtender runat="server" ID="DDE"
            TargetControlID="Label1"
            DropDownControlID="DropPanel" />


                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ProductNumber" HeaderText="ProductNumber" 
                            SortExpression="ProductNumber" />
            <asp:BoundField DataField="Color" HeaderText="Color" 
                SortExpression="Color" />
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
        <asp:LinqDataSource ID="DS_AllProducts" runat="server" 
            ContextTypeName="DataClassesDataContext" OrderBy="Name" 
            TableName="Products" EnableDelete="True" 
            ondeleted="DS_AllProducts_Deleted">
        </asp:LinqDataSource>
        <asp:Literal ID="lbl_ListAllProductModel" runat="server" />
    </ContentTemplate>
    </AjaxCTK:TabPanel>
    <AjaxCTK:TabPanel ID="TP_Create" runat="server" HeaderText="Create new Product">
    <ContentTemplate>
    <table border="0" width="100%">
    <tr valign="top">
    <td width="5%">Name</td>
    <td width="*"><asp:TextBox ID="txt_Name" runat="server" MaxLength="100" />
    <asp:RequiredFieldValidator ID="Req_Name" runat="server" 
            ControlToValidate="txt_Name" Display="None" 
            ErrorMessage="<b>Required Field Missing</b><br />A product name is required." 
            SetFocusOnError="True" />
        <AjaxCTK:ValidatorCalloutExtender runat="server" ID="vReq_Name"
            TargetControlID="Req_Name"
            HighlightCssClass="validatorCalloutHighlight" Enabled="True" 
            PopupPosition="BottomLeft" />

    <AjaxCTK:TextBoxWatermarkExtender ID="TBEW_Name" runat="server" 
            TargetControlID="txt_Name" WatermarkText="Enter the name of the product e.g Mountain Bike Socks, S" 
            Enabled="True" WatermarkCssClass="watermarked" />
    </td>
    </tr>
    <tr valign="top">
    <td>Product Number</td>
    <td><asp:TextBox ID="txt_ProductNumber" runat="server" MaxLength="50" />
    <AjaxCTK:TextBoxWatermarkExtender ID="TBEW_ProductNumber" runat="server" 
            TargetControlID="txt_ProductNumber" WatermarkText="Enter the product number e.g MBS-M" 
            Enabled="True" WatermarkCssClass="watermarked" />    
    <asp:RequiredFieldValidator ID="Req_PdtNo" runat="server" 
            ControlToValidate="txt_ProductNumber" Display="None" 
            ErrorMessage="<b>Required Field Missing</b><br />A product number is required." 
            SetFocusOnError="True" />
        <AjaxCTK:ValidatorCalloutExtender runat="server" ID="vReq_PdtNo"
            TargetControlID="Req_PdtNo"
            HighlightCssClass="validatorCalloutHighlight" Enabled="True" 
            PopupPosition="BottomLeft" />
            
    </td>
    </tr>
    <tr valign="top">
    <td>Color</td>
    <td><asp:TextBox ID="txt_Color" runat="server" MaxLength="30" /><AjaxCTK:TextBoxWatermarkExtender ID="TBEW_Color" runat="server" 
            TargetControlID="txt_Color" WatermarkText="Enter the color of the product e.g Black" 
            Enabled="True" WatermarkCssClass="watermarked" />
    <asp:RequiredFieldValidator ID="Req_Color" runat="server" 
            ControlToValidate="txt_Color" Display="None" 
            ErrorMessage="<b>Required Field Missing</b><br />A product color is required." 
            SetFocusOnError="True" />
        <AjaxCTK:ValidatorCalloutExtender runat="server" ID="vReq_Color"
            TargetControlID="Req_Color"
            HighlightCssClass="validatorCalloutHighlight" Enabled="True" 
            PopupPosition="BottomLeft" />
            
    </td>
    </tr>
    <tr valign="top">
    <td>Standard Cost</td>
    <td><asp:TextBox ID="txt_StandardCost" runat="server" MaxLength="20" /><AjaxCTK:TextBoxWatermarkExtender ID="TBEW_StandardCost" runat="server" 
            TargetControlID="txt_StandardCost" WatermarkText="Enter the cost of the product" 
            Enabled="True" WatermarkCssClass="watermarked" />
    <asp:RequiredFieldValidator ID="Req_StandardCost" runat="server" 
            ControlToValidate="txt_StandardCost" Display="None" 
            ErrorMessage="<b>Required Field Missing</b><br />A product Standard Cost is required."  
            SetFocusOnError="True"/>
        <AjaxCTK:ValidatorCalloutExtender runat="server" ID="vReq_StandardCost"
            TargetControlID="Req_StandardCost"
            HighlightCssClass="validatorCalloutHighlight" Enabled="True" 
            PopupPosition="BottomLeft" />
           
            <AjaxCTK:MaskedEditExtender ID="MEE_StandardCost" runat="server" 
            TargetControlID="txt_StandardCost" CultureAMPMPlaceholder="" 
            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
            CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
            Mask="9999.99" MaskType="Number" />
            
    </td>
    </tr>
    <tr valign="top">
    <td>List Price</td>
    <td><asp:TextBox ID="txt_ListPrice" runat="server" MaxLength="20" /><AjaxCTK:TextBoxWatermarkExtender ID="TBEW_ListPrice" runat="server" 
            TargetControlID="txt_ListPrice" WatermarkText="Enter the list price of the product, must be more than the standard cost" 
            Enabled="True" WatermarkCssClass="watermarked" />
    <asp:RequiredFieldValidator ID="Req_ListPrice" runat="server" 
            ControlToValidate="txt_ListPrice" Display="None" 
            ErrorMessage="<b>Required Field Missing</b><br />A product List Price is required."  
            SetFocusOnError="True"/>
        <AjaxCTK:ValidatorCalloutExtender runat="server" ID="vReq_ListPrice"
            TargetControlID="Req_ListPrice"
            HighlightCssClass="validatorCalloutHighlight" Enabled="True" 
            PopupPosition="BottomLeft" />
           
                   <asp:CompareValidator ID="cp_ListPrice" runat="server" 
            ControlToCompare="txt_StandardCost" ControlToValidate="txt_ListPrice" 
            Display="None" Operator="GreaterThan" SetFocusOnError="True" Type="Currency" ErrorMessage="<b>Invalid List Price</b><br />List price cannot be higher than standard cost" />
        <AjaxCTK:ValidatorCalloutExtender runat="server" ID="Vcp_ListPrice"
            TargetControlID="cp_ListPrice"
            HighlightCssClass="validatorCalloutHighlight" Enabled="True" 
            PopupPosition="BottomLeft" />            

                     
            <AjaxCTK:MaskedEditExtender ID="MEE_ListPrice" runat="server" 
            TargetControlID="txt_ListPrice" CultureAMPMPlaceholder="" 
            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
            CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
            Mask="9999.99" MaskType="Number" />
            
    </td>
    </tr>
    <tr valign="top">
    <td>Size</td>
    <td><asp:TextBox ID="txt_Size" runat="server" MaxLength="10" /><AjaxCTK:TextBoxWatermarkExtender ID="TBEW_Size" runat="server" 
            TargetControlID="txt_Size" WatermarkText="Enter the size of the product, e.g XL, or 62" 
            Enabled="True" WatermarkCssClass="watermarked" />
    <asp:RequiredFieldValidator ID="Req_Size" runat="server" 
            ControlToValidate="txt_Size" Display="None" 
            ErrorMessage="<b>Required Field Missing</b><br />A product size is required."  
            SetFocusOnError="True"/>
        <AjaxCTK:ValidatorCalloutExtender runat="server" ID="vReq_Size"
            TargetControlID="Req_Size"
            HighlightCssClass="validatorCalloutHighlight" Enabled="True" 
            PopupPosition="BottomLeft" />
            
    </td>
    </tr>
    <tr valign="top">
    <td>Weight</td>
    <td><asp:TextBox ID="txt_Weight" runat="server" MaxLength="10" /><AjaxCTK:TextBoxWatermarkExtender ID="TBEW_Weight" runat="server" 
            TargetControlID="txt_Weight" WatermarkText="Enter the weight of the product in kg" 
            Enabled="True" WatermarkCssClass="watermarked" />
            <AjaxCTK:MaskedEditExtender ID="MEE_Weight" runat="server" 
            TargetControlID="txt_Weight" CultureAMPMPlaceholder="" 
            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
            CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
            Mask="9999.99" MaskType="Number" />
    <asp:RequiredFieldValidator ID="Req_Weight" runat="server" 
            ControlToValidate="txt_Weight" Display="None" 
            ErrorMessage="<b>Required Field Missing</b><br />A product weight is required."  
            SetFocusOnError="True"/>
        <AjaxCTK:ValidatorCalloutExtender runat="server" ID="vReq_Weight"
            TargetControlID="Req_Weight"
            HighlightCssClass="validatorCalloutHighlight" Enabled="True" 
            PopupPosition="BottomLeft" />

    </td>
    </tr>
    
        <tr valign="top">
    <td>Category</td>
    <td><asp:DropDownList ID="ddl_Category" runat="server" DataSourceID="DS_Category" 
            DataTextField="Name" DataValueField="ProductCategoryID" 
            EnableViewState="False" />
        <asp:LinqDataSource ID="DS_Category" runat="server" 
            ContextTypeName="DataClassesDataContext" OrderBy="Name" 
            Select="new (ProductCategoryID, Name)" TableName="ProductCategories" 
            Where="!ParentProductCategoryID.hasValue">
        </asp:LinqDataSource>
               
        
        <asp:DropDownList ID="ddl_Category2" runat="server" EnableViewState="False" />
            <AjaxCTK:ListSearchExtender ID="LSE_ddl_Category" runat="server"
                TargetControlID="ddl_Category2" PromptCssClass="ListSearchExtenderPrompt"
                QueryTimeout="1000" Enabled="True" />       
                
                 <AjaxCTK:CascadingDropDown ID="CCE_category2" runat="server" 
            Enabled="True" ParentControlID="ddl_Category" Category="Category" 
            ServiceMethod="GetSubCategories" ServicePath="/WebService.asmx"
            TargetControlID="ddl_Category2" />     
            </td>
    </tr>

    </table>
    <asp:Button ID="btn_Submit" runat="server" Text="Submit" 
            onclick="btn_Submit_Click" />
    </ContentTemplate>
    </AjaxCTK:TabPanel>
    </AjaxCTK:TabContainer>
    </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UPP" runat="server" AssociatedUpdatePanelID="UP" DisplayAfter="0">
    <ProgressTemplate>
    <div style="border: 2px solid black; background-color: White; width: 250px; z-index: 1; left: 0; top: 0px; position: fixed;">        
    Updating please wait..
    </div>
    </ProgressTemplate>
    </asp:UpdateProgress>
                        
    <script type="text/javascript" language="javascript">
            function updateTime()
            {
                var label = document.getElementById('<%= currentTime.UniqueID %>');
                if (label) {
                    var time = (new Date()).localeFormat("T");
                    label.innerHTML = time;
                }
            }
            updateTime();
            window.setInterval(updateTime, 1000);
        </script>                        
    </form>
</body>
</html>
