using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Chapter5_delegates : System.Web.UI.Page
{
    public delegate void ResponseWrite(string s);

    public void ResponseDotWrite(string s)
    {
        Response.Write(s);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        var rw = new ResponseWrite(ResponseDotWrite);
        rw("hello world");
    }
}
