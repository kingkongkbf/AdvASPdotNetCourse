using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Chapter5_stringbuilder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var results = new List<StringBuilderResults>();
        int MaxLoops = 5;
        int MaxIterations = 10000;

        var r1 = new StringBuilderResults() { Description = "StringBuilder", MemoryUsage = 0, Duration = 0, TotalExceptions = 0 };
        results.Add(r1);
        for (int Loop = 0; Loop < MaxLoops; Loop++)
        {
            long memoryStart = System.GC.GetTotalMemory(false);
            using (var tOp = new TimeOperation())
            {
                try
                {
                    var sb = new StringBuilder();
                    for (int i = 0; i < MaxIterations; i++)
                    {
                        sb.Append(i.ToString());
                    }
                }
                catch (Exception ex)
                {
                    r1.TotalExceptions++;
                    r1.AddException(ex);
                }
                r1.Duration += tOp.Stop();

            }
            long memoryEnd = System.GC.GetTotalMemory(false);
            r1.MemoryUsage += memoryEnd - memoryStart;
        }
        System.Threading.Thread.Sleep(5000);
        System.GC.Collect();
        System.Threading.Thread.Sleep(5000);

        var r2 = new StringBuilderResults() { Description = "String Concat", MemoryUsage = 0, Duration = 0, TotalExceptions = 0 };
        results.Add(r2);
        for (int Loop = 0; Loop < MaxLoops; Loop++)
        {
            long memoryStart = System.GC.GetTotalMemory(false);
            using (var tOp = new TimeOperation())
            {
                try
                {
                    var sb = "";
                    for (int i = 0; i < MaxIterations; i++)
                    {
                        sb = sb + i.ToString();
                    }
                }
                catch (Exception ex)
                {
                    r2.TotalExceptions++;
                    r2.AddException(ex);
                }
                r2.Duration += tOp.Stop();

            }
            long memoryEnd = System.GC.GetTotalMemory(false);
            r2.MemoryUsage += memoryEnd - memoryStart;
        }
        System.Threading.Thread.Sleep(5000);
        System.GC.Collect();

        results.ForEach(delegate(StringBuilderResults r) { r.Duration = r.Duration / MaxLoops; r.MemoryUsage = r.MemoryUsage / MaxLoops; });

        GV.DataSource = results;
        GV.DataBind();
    }
}

public class StringBuilderResults
{
    public StringBuilderResults() { }
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