using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Chapter1_LabSolution_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void TM_Tick(object sender, EventArgs e)
    {
        lbl.Text = "Last Update @ " + DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt");
        GV.DataBind();
    }
}
