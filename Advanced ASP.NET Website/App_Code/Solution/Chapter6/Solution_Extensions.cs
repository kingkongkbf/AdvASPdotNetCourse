using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Solution
{
    /// <summary>
    /// Summary description for Solution_Extensions
    /// </summary>
    public static class Solution_Extensions
    {
        public static Guid ToGuid(this object o)
        {
            try
            {
                return new Guid(o.ToString());
            }
            catch
            {
            }

            return Guid.Empty;
        }

        public static int ToInt32(this object o)
        {
            try
            {
                return Convert.ToInt32(o);
            }
            catch
            {
            }

            return -1;
        }

        public static void AppendItemsToTable(this System.Text.StringBuilder sb, params object[] Items)
        {
            if (Items.Count() > 0)
            {
                var Server = HttpContext.Current.Server;
                sb.Append("<tr valign='top'>");
                foreach (var i in Items)
                {
                    sb.Append("<td>");
                    if (i == null)
                        sb.AppendItemsToTable(" ");
                    else
                        sb.Append(i.ToString());
                    sb.Append("</td>");
                }
                sb.Append("</tr>");
            }
        }
    }
}