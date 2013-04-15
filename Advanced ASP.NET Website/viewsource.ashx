<%@ WebHandler Language="C#" Class="viewsource" %>

using System;
using System.Web;
using System.IO;

public class viewsource : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var Request = context.Request;
        var Response = context.Response;
        var Server = context.Server;
        Response.ContentType = "text/plain";
        try
        {
            string URL = Request.QueryString["url"];
            if (URL != null && URL.Length > 0)
            {
                string FileName = Server.MapPath("~" + URL);
                Response.Write("<!-- " + URL + " -->\n");
                if (File.Exists(FileName))
                    Response.Write(File.ReadAllText(FileName));
            }
        }
        catch
        {
        }
    }
 
    public bool IsReusable {
        get {
            return true;
        }
    }

}