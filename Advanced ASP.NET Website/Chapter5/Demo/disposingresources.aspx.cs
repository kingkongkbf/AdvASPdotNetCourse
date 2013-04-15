using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Chapter5_disposingresources : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var results = new List<DisposingResourcesResult>();
        var yDispose = new DisposingResourcesResult() { Description = "Disposing objects", MemoryUsage=0, Duration=0, TotalExceptions=0 };
        results.Add(yDispose);

        var cmd = new SqlCommand();
        cmd.CommandText = "select * from Address";
        int MaxLoops = 5;
        int MaxIterations = 100;
        for (int Loop = 0; Loop < MaxLoops; Loop++)
        {
            long memoryStart = System.GC.GetTotalMemory(false);
            using (var tOp = new TimeOperation())
            {
                try
                {
                    for (int i = 0; i < MaxIterations; i++)
                    {
                        using (var db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AdventureWorksConnectionString"].ConnectionString))
                        {
                            db.Open();
                            cmd.Connection = db;
                            using (var r = cmd.ExecuteReader())
                            {
                                while (r.Read())
                                {
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    yDispose.TotalExceptions++;
                    yDispose.AddException(ex);
                }
                    yDispose.Duration += tOp.Stop();

            }
            long memoryEnd = System.GC.GetTotalMemory(false);
            yDispose.MemoryUsage += memoryEnd - memoryStart;
        }
        System.GC.Collect();

        var nDispose = new DisposingResourcesResult() { Description = "NOT Disposing objects", MemoryUsage = 0, Duration = 0, TotalExceptions = 0 };
        results.Add(nDispose);
        for (int Loop = 0; Loop < MaxLoops; Loop++)
        {
            long memoryStart = System.GC.GetTotalMemory(false);
            using (var tOp = new TimeOperation())
            {
                for (int i = 0; i < MaxIterations; i++)
                {
                    try
                    {
                        var db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AdventureWorksConnectionString"].ConnectionString);
                        db.Open();
                        cmd.Connection = db;
                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        nDispose.TotalExceptions++;
                        nDispose.AddException(ex);
                    }
                }
                nDispose.Duration += tOp.Stop();
            }
            long memoryEnd = System.GC.GetTotalMemory(false);
            nDispose.MemoryUsage += memoryEnd - memoryStart;
        }
        System.GC.Collect();

        results.ForEach(delegate(DisposingResourcesResult r) { r.Duration = r.Duration / MaxLoops; r.MemoryUsage = r.MemoryUsage / MaxLoops; }); 

        GV.DataSource = results;
        GV.DataBind();
    }
}

public class DisposingResourcesResult
{
    public DisposingResourcesResult() { }
    public string Description { get; set; }
    public long MemoryUsage { get; set; }
    public long Duration { get; set; }
    public long TotalExceptions { get; set; }
    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    public string AllExceptions
    {
        get
        {
            return sb.ToString();
        }
    }
    public void AddException(Exception ex)
    {
        sb.Append(ex.Message + "<br>");
    }

}