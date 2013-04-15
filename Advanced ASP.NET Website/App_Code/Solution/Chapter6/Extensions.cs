using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solution
{
    /// <summary>
    /// Summary description for Extensions
    /// </summary>
    public static class Extensions
    {
        public static void AppendBR(this System.Text.StringBuilder sb, string s)
        {
            sb.Append(s);
            sb.Append("<br />");
        }
    }
}