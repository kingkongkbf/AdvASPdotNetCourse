<%@ Page Language="C#" AutoEventWireup="true" CodeFile="generics_comparedto_collections.aspx.cs" Inherits="Chapter3_Generics_generics_comparedto_collections" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    This test inserts <%= MaxElements %> items to the collections, iterates thru the entire collection and does a seek to a fixed value in the collection. All results are in milliseconds.<br />
    <ul>
    <li>Duration_Insert: The time taken to insert <%= MaxElements %> items</li>
    <li>Duration_Iterate: The time taken to iterate thru the entire collection</li>
    <li>Duration_Search: The time taken to find a fixed value</li>
    </ul>
    <hr />
    <asp:GridView ID="GV" runat="server" />
    </form>
</body>
</html>
