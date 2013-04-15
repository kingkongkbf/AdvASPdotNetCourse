using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Chapter4_linqtosql : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindData();
    }
    void BindData()
    {
        using (var db = new Solution.AdventureWorksEntities())
        {
            //var records = from p in db.ProductCategories
            //              where p.ParentProductCategoryID==null
            //              orderby p.Name                                                    
            //              select p;

            var records = from p in db.Products
                          orderby p.Name
                          select p.Name p.ProductNumber  p.Color  p.ModifiedDate  p.ProductID;

                          

            //select ProductCategoryID as ID, Name as Text from ProductCategory 
            //where ParentProductCategoryID is null order by Name





//SELECT [Name], [ProductNumber], [Color], [ModifiedDate], [ProductID] FROM [Product] ORDER BY [Name]
          

            GV.DataSource = records;
            GV.DataBind();
        }
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        using (var db = new Solution.AdventureWorksEntities())
        {
            //var records = from p in db.Addresses
            //              where p.City.Contains("chi")
            //              select p;

            var records = from p in db.ProductCategories
                          where p.ParentProductCategoryID == null
                          orderby p.Name
                          select p;

            foreach (var r in records)
                r.ModifiedDate = DateTime.Now;

            db.SaveChanges();
        }
        BindData();
    }
    protected void btn_SQLInjection_Click(object sender, EventArgs e)
    {
        using (var db = new Solution.AdventureWorksEntities())
        {
            var records = (from p in db.Addresses
                           where p.City.Contains("chi")
                           select p).FirstOrDefault();

            records.AddressLine2 = "' where Address like '%' --" + DateTime.Now.ToString("dd MMM yyyy HH:mm:sss");
            //sql statement to terminate/overwrite existing sql script. 

            db.SaveChanges();
        }
        BindData();
    }
}
