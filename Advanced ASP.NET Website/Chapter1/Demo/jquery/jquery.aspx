<%@ Page Title="" Language="C#" MasterPageFile="~/Chapter1/Demo/MasterPage.master" AutoEventWireup="true" CodeFile="jquery.aspx.cs" Inherits="Chapter1_Demo_jquery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<!-- Styles -->
<link href="jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
<link href="ui.jqgrid.css" rel="stylesheet" type="text/css" />
<link href="ui.multiselect.css" rel="stylesheet" type="text/css" />

<!-- Required scripts -->
<script language="javascript" src="jquery.js"></script>
<script language="javascript" src="jquery-ui-1.8.16.custom.min.js"></script>
<script language="javascript" src="jquery.layout.js"></script>
<script language="javascript" src="grid.locale-en.js"></script>
<script language="javascript" src="ui.multiselect.js"></script>
<script language="javascript" src="jquery.jqGrid.min.js"></script>
<script language="javascript" src="jquery.tablednd.js"></script>
<script language="javascript" src="jquery.contextmenu.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!-- this is the html table where the grid will be rendered -->
<table id="list2"></table>

<!-- this is where the pager will be -->
<div id="pager2"></div>

<script language="javascript">
jQuery("#list2").jqGrid({ 
    url:'jquery_data.ashx', 
    datatype: "json", 
    colNames:['Title','First Name', 'Middle Name', 'Last Name','Company Name'], 
    colModel:[ 
        {name:'Title',index:'title'}, 
        {name:'FirstName',index:'FirstName'},
        {name:'MiddleName',index:'MiddleName'}, 
        {name:'LastName',index:'LastName'}, 
        {name:'CompanyName',index:'CompanyName'}, 
    ], 
    rowNum:10, 
    rowList:[10,20,30], 
    pager: '#pager2', 
    sortname: 'id', 
    viewrecords: true, 
    sortorder: "desc", 
    caption:"" 
    }); 
    jQuery("#list2").jqGrid('navGrid','#pager2',{edit:false,add:false,del:false});
</script>
</asp:Content>

