using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

public partial class Chapter4_Lab_Default : System.Web.UI.Page
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
        using (var db = new Solution.AdventureWorksEntities())
        {
            var obj = new Solution.Product();
            obj.Color = txt_Color.Text;
            obj.ListPrice = Convert.ToDecimal(txt_ListPrice.Text);
            obj.ModifiedDate = DateTime.Now;
            obj.Name = txt_Name.Text;
            obj.ProductCategoryID = Convert.ToInt32(ddl_Category2.SelectedValue);
            obj.ProductNumber = txt_ProductNumber.Text;
            obj.SellStartDate = DateTime.Now;
            obj.Size = txt_Size.Text;
            obj.StandardCost = Convert.ToDecimal(txt_StandardCost.Text);
            obj.ThumbnailPhotoFileName = "";
            obj.ThumbNailPhoto = null;
            obj.rowguid = Guid.NewGuid();
            obj.Weight = Convert.ToDecimal(txt_Weight.Text);

            db.Products.AddObject(obj);
            db.SaveChanges();
            GV.SelectedIndex = -1;
            GV.DataBind();
            TC.ActiveTabIndex = 0;
        }
    }
    protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var lb_Select = (LinkButton)e.Row.FindControl("lb_Select");
            var lb_Delete = (LinkButton)e.Row.FindControl("lb_Delete");

            lb_Select.OnClientClick = Page.ClientScript.GetPostBackEventReference(GV, "Select$" + e.Row.RowIndex) + ";return false;";
            lb_Delete.OnClientClick = "if (confirm('Are you sure you want to delete this product?')) {" + Page.ClientScript.GetPostBackEventReference(GV, "Delete$" + e.Row.RowIndex) + ";}return false;";        

            var Trigger = new AsyncPostBackTrigger();
            Trigger.ControlID = GV.ID;
            Trigger.EventName = "";
            UP.Triggers.Add(Trigger);
        }
    }
    protected void DS_AllProducts_Deleted(object sender, LinqDataSourceStatusEventArgs e)
    {
        GV.DataBind();
    }
}
