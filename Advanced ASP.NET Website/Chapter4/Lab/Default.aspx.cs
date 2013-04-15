using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Chapter3_Lab_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void GV_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_ListAllProductModel.Text = "Selected " + GV.Rows[GV.SelectedIndex].Cells[1].Text;
    }
    protected void GV_PageIndexChanged(object sender, EventArgs e)
    {
        lbl_ListAllProductModel.Text = "Viewing page " + (GV.PageIndex+1) + " of " + GV.PageCount;
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(5000);
    }
}
