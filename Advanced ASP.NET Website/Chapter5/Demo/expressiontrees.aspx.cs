using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Chapter5_expressiontrees : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var theData = new List<string>();

        Random rand = new Random();
        Response.Write("<br><br>Adding items to the list, ");
        for (int i = 0; i < 999; i++)
            theData.Add("Item" + (i + rand.Next(100)).ToString("0000"));

        Response.Write("<br><br>Finding " + theData[theData.Count / 2]);
        var findItem = from p in theData
                       where p == theData[theData.Count / 2]
                          select p;

        Response.Write(" : Found Total " + findItem.Count());

        Response.Write("<br><br>Listing First 10 Items: ");
        for (int i = 0; i < 10; i++)
            Response.Write(theData[i] + ", ");

        theData.Sort();
        Response.Write("<br><br>Listing First 10 Items after sort: ");
        for (int i = 0; i < 10; i++)
            Response.Write(theData[i] + ", ");
    }
}
