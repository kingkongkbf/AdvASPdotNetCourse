using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Chapter5_forloops : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var result = new List<ForLoopResourcesResult>();

        var theData = new List<string>();
        for (int i = 0; i < 9999999; i++)
            theData.Add("Item" + i);

        int MaxLoop = 5;

        var S1 = new ForLoopResourcesResult() { Description = "Storing the count in a variable", Duration = 0, MemoryUsage=0 };
        result.Add(S1);
        for (int Loop = 0; Loop < MaxLoop; Loop++)
        {
            using (var tOp = new TimeOperation())
            {
                long MemoryStart = System.GC.GetTotalMemory(false);
                var Count = theData.Count;
                for (int i = 0; i < Count; i++)
                {
                    string s = theData[i];
                }
                S1.Duration += tOp.Stop();
                long MemoryEnd = System.GC.GetTotalMemory(false);
                S1.MemoryUsage += MemoryEnd - MemoryStart;
            }
        }
        System.Threading.Thread.Sleep(5000);
        System.GC.Collect();
        System.Threading.Thread.Sleep(5000);

        var S2 = new ForLoopResourcesResult() { Description = "Normal For Loop", Duration = 0, MemoryUsage=0 };
        result.Add(S2);
        for (int Loop = 0; Loop < MaxLoop; Loop++)
        {
            using (var tOp = new TimeOperation())
            {
                long MemoryStart = System.GC.GetTotalMemory(false);
                for (int i = 0; i < theData.Count; i++)
                {
                    string s = theData[i];
                }
                S2.Duration += tOp.Stop();
                long MemoryEnd = System.GC.GetTotalMemory(false);
                S1.MemoryUsage += MemoryEnd - MemoryStart;

            }
        }
        System.Threading.Thread.Sleep(5000);
        System.GC.Collect();
        System.Threading.Thread.Sleep(5000);

        var S3 = new ForLoopResourcesResult() { Description = "Using List.ForEach", Duration = 0, MemoryUsage=0 };
        result.Add(S3);
        for (int Loop = 0; Loop < MaxLoop; Loop++)
        {
            using (var tOp = new TimeOperation())
            {
                long MemoryStart = System.GC.GetTotalMemory(false);
                theData.ForEach(delegate(string str) { string s = str; });
                long MemoryEnd = System.GC.GetTotalMemory(false);
                S1.MemoryUsage += MemoryEnd - MemoryStart;

                S3.Duration += tOp.Stop();
            }
        }
        System.Threading.Thread.Sleep(5000);
        System.GC.Collect();
        result.ForEach(delegate(ForLoopResourcesResult obj) { obj.Duration = obj.Duration / MaxLoop; });
        GV.DataSource = result;
        GV.DataBind();
    }
}

public class ForLoopResourcesResult
{
    public ForLoopResourcesResult() { }
    public string Description { get; set; }
    public long MemoryUsage = 0;
    public long Duration { get; set; }
}