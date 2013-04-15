using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Solution;

public partial class Chapter6_LabSolution_Default : System.Web.UI.Page
{
    //Using sessionstate to store the pagestate rather than viewstate
    protected override PageStatePersister PageStatePersister
    {
        get
        {
            return new SessionPageStatePersister(this);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GV_SelectedIndexChanged(object sender, EventArgs e)
    {
        //reduction in lines of codes to make it more readable

        //Extension to convert the datakey object to int32
        var ID = GV.SelectedDataKey.Value.ToInt32();

        //using LINQ rather than normal SQL
        using (var db = new AdventureWorksEntities())
        {
            //Expression trees rather than using normal SQL
            var Invoices = from p in db.SalesOrderHeaders
                           where p.SalesOrderID == ID
                           orderby p.SalesOrderNumber
                           select new { p, p.SalesOrderDetails };


            if (Invoices.Count() > 0)
            {
                var sb = new StringBuilder("<h2>Invoice Details</h2><table border='1'><tr valign='top'><td>Address</td><td>Freight</td><td>Ship Date</td><td>Ship Method</td><td>Status</td><td>Items</td></tr>");
                
                //using foreach to improve performance
                foreach (var Invoice in Invoices)
                {
                    var sb_Items = new StringBuilder();

                    //inline expression
                    foreach (var Item in Invoice.SalesOrderDetails.Select(p => p.Product.Name).OrderBy(p => p))
                    {
                        sb_Items.AppendBR(Item);
                    }

                    //AppendItemsToTable is an extension to promote reuse
                    sb.AppendItemsToTable(Invoice.p.Address.AddressLine1 + "<br />" + Invoice.p.Address.AddressLine2,
                        Invoice.p.Freight, Invoice.p.ShipDate, Invoice.p.ShipMethod, Invoice.p.Status, sb_Items);

                }

                sb.Append("</table>");
                lbl.Text = sb.ToString();
            }
            else
            {
                lbl.Text = "No Invoices";
            }
        }
    }
}