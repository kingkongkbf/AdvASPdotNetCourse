using System;
using System.Diagnostics;
using System.Text;

public class TimeOperation : IDisposable
{
    StringBuilder sb = null;
    Stopwatch sw = new Stopwatch();
    public TimeOperation()
    {
        Start();
    }

    public TimeOperation(StringBuilder SB, string Operation)
    {
        SB.Append("<br />" + Operation + "<br />");
        sb = SB;
        Start();
    }

    public void Start()
    {
        sw.Reset();
        sw.Start();
    }

    public long Stop()
    {
        return Stop(false);
    }
    public long Stop(bool showTicks)
    {
        sw.Stop();
        if (sb != null)
            sb.Append("<br />Duration: " + (sw.ElapsedMilliseconds * 1.0 / 1000) + " seconds");
        if (showTicks)
            return sw.ElapsedTicks;
        else
            return sw.ElapsedMilliseconds;
    }

    #region IDisposable Members

    void IDisposable.Dispose()
    {
        sw.Stop();
    }

    #endregion
}