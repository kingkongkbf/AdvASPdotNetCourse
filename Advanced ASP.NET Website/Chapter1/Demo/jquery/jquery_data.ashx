<%@ WebHandler Language="C#" Class="data" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

public class data : IHttpHandler {

    int GetValue(HttpRequest Request, string Key)
    {
        var val = Request.QueryString[Key];
        if (val == null)
            return -1;
        try
        {
            return Convert.ToInt32(val);
        }
        catch
        {
            return -1;
        }
    }
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "application/json";
        
        var Request = context.Request;
        var Response = context.Response;

        var page = GetValue(Request, "page"); //get the requested page
        var rows = GetValue(Request, "rows"); //get how many rows we want to have in a grid
        var sidx = GetValue(Request, "sidx"); //get row index ie user click to sort
        var sord = GetValue(Request, "sord"); //get the sort direction

        using (var db = new Solution.AdventureWorksEntities())
        {
            var records = from p in db.Customers
                          orderby p.FirstName
                          select new { p.CustomerID, p.Title, p.FirstName, p.LastName, p.MiddleName, p.CompanyName };

            var totalRecords = records.Count();

            var l = new theResponse()
            {
                page = page,
                records = totalRecords,
                total = page+1
            };

            if (totalRecords > 0)
            {
                l.total = Convert.ToInt32(Math.Ceiling(totalRecords * 1.0 / rows));
            }
            else
            {
                l.total = 0;
            }

            records = records.Skip(rows * page - rows).Take(rows);
            
            foreach (var r in records)
            {
                var d = new List<object>();
                d.Add(r.Title);
                d.Add(r.FirstName);
                d.Add(r.MiddleName);
                d.Add(r.LastName);
                d.Add(r.CompanyName);

                l.rows.Add(new theRows()
                {
                    id = r.CustomerID.ToString(),
                    cell = d.ToArray()
                });
            }
            
            var js = new JavaScriptSerializer();
            context.Response.Write(js.Serialize(l));
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}

public class theResponse
{
    public int page { get; set; }
    public int total { get; set; }
    public int records { get; set; }
    public List<theRows> rows { get; set; }
    public theResponse() { rows = new List<theRows>(); }
}
public class theRows
{
    public string id {get;set;}
    public object[] cell {get;set;}
}