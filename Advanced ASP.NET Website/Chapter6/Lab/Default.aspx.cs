using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Chapter6_Lab_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GV_SelectedIndexChanged(object sender, EventArgs e)
    {  
   

        var ID = Convert.ToInt32(GV.SelectedDataKey.Value);

        using (var DS = new System.Web.UI.WebControls.SqlDataSource())
        {
            DS.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AdventureWorksConnectionString"].ConnectionString;                           
            DS.SelectCommand = "select * from SalesOrderHeader where SalesOrderID = " + GV.SelectedDataKey.Value;
            using (var result = (DS.Select(System.Web.UI.DataSourceSelectArguments.Empty) as System.Data.DataView).Table)
            {
                foreach (DataRow row in result.Rows)
                {                  

                    System.Text.StringBuilder s = new System.Text.StringBuilder("<h2>Invoice Details</h2><table border='1'><tr valign='top'><td>Address</td><td>Freight</td><td>Ship Date</td><td>Ship Method</td><td>Status</td><td>Items</td></tr>");
                    s.Append("<tr valign='top'><td>");          

                   
                    //get the address
                    using (var DS_Address = new System.Web.UI.WebControls.SqlDataSource())
                    {
                        DS_Address.ConnectionString = DS.ConnectionString;
                        DS_Address.SelectCommand = "select * from Address where AddressID = " + row["BillToAddressID"];

                        using (var result_Address = (DS_Address.Select(System.Web.UI.DataSourceSelectArguments.Empty) as System.Data.DataView).Table)
                        {
                            foreach (DataRow row_Address in result_Address.Rows)
                            {
                                s.Append(row_Address["AddressLine1"] + "<br />" + row_Address["AddressLine2"]); 	                        
                            }
                        }
                    }
                    s.Append("</td>");

                    //add in the other columns
                    s.Append("<td>" + row["Freight"] + "</td><td>" + row["ShipDate"] + "</td><td>" + row["ShipMethod"] + "</td><td>" + row["Status"] + "</td><td>");

                    //get the items and add to the string
                    using (var DS_Item = new System.Web.UI.WebControls.SqlDataSource())
                    {
                        DS_Item.ConnectionString = DS.ConnectionString;
                        DS_Item.SelectCommand = @"
select P.Name
from SalesOrderDetail S
inner join Product P on S.ProductID=P.ProductID
where S.SalesOrderID = " + row["SalesOrderID"] + " order by P.Name";

                        using (var result_Item = (DS_Item.Select(System.Web.UI.DataSourceSelectArguments.Empty) as System.Data.DataView).Table)
                        {
                            foreach (DataRow row_Item in result_Item.Rows)
                            {
                               s.Append(row_Item["Name"] + "<br />");
                            }
                        }
                      
                        s.Append("</td></tr>");
                        DS.Select(DataSourceSelectArguments.Empty);  //dispose of resources (cleaning)

                    }

                    s.Append("</table>");
                    String innerstring = s.ToString();
                    lbl.Text = innerstring;
                }
            }
        }
    }
}