using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AjaxControlToolkit;
using System.Collections.Specialized;
using System.Data;

namespace Solution
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        public WebService()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

        [WebMethod]
        public CascadingDropDownNameValue[] GetSubCategories(string knownCategoryValues, string category)
        {
            StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            int ParentCategoryID = 0;
            foreach (string s in kv.Keys)
                ParentCategoryID = Convert.ToInt32(kv[s]);

            using (var DS = new System.Web.UI.WebControls.SqlDataSource())
            {
                DS.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AdventureWorksConnectionString"].ConnectionString;
                DS.SelectCommand = "select ProductCategoryID, Name from ProductCategory where ParentProductCategoryID = " + ParentCategoryID + " order by Name";
                using (var result = (DS.Select(System.Web.UI.DataSourceSelectArguments.Empty) as System.Data.DataView).Table)
                {
                    foreach (DataRow row in result.Rows)
                    {
                        values.Add(new CascadingDropDownNameValue(row["Name"].ToString(), row["ProductCategoryID"].ToString()));
                    }
                }
            }

            return values.ToArray();
        }
    }
}