using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution;

public partial class Chapter6_Demo_extensions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var sb = new System.Text.StringBuilder();
        for (var i = 0; i < 100; i++)
            sb.AppendBR(i + ":");
        lbl.Text = sb.ToString();
    }
}