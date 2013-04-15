using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Chapter2_Lab_original : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddl_Category.DataBind();
            ddl_Category_SelectedIndexChanged(null, null);
        }
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
    protected void ddl_Category_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_Category2.Items.Clear();

        using (var DS = new System.Web.UI.WebControls.SqlDataSource())
        {
            DS.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AdventureWorksConnectionString"].ConnectionString;
            DS.SelectCommand = "select ProductCategoryID, Name from ProductCategory where ParentProductCategoryID = " + ddl_Category.SelectedValue + " order by Name";
            using (var result = (DS.Select(System.Web.UI.DataSourceSelectArguments.Empty) as System.Data.DataView).Table)
            {
                foreach (DataRow row in result.Rows)
                {
                    ddl_Category2.Items.Add(new ListItem(row["Name"].ToString(), row["ProductCategoryID"].ToString()));
                }
            }
        }
    }
}
