using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

public static class CQ_LINQ
{
    /*
    public static Func<DataClassesDataContext, string, IQueryable<Address>> CQ_GetAddressesInCity = CompiledQuery.Compile<DataClassesDataContext, string, IQueryable<Address>>((dc, City) =>
         from U in dc.Addresses
         where U.City.Contains(City)
         select U
     );
     */

}

public partial class Chapter5_compiledlinq : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        using (var db = new DataClassesDataContext())
        {
            GV.DataSource = CQ_LINQ.CQ_GetAddressesInCity(db, "chi");
            GV.DataBind();
        }
         */
    }
}
