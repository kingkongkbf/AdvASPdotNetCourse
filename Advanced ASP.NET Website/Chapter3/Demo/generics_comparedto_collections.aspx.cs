using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class Chapter3_Generics_generics_comparedto_collections : System.Web.UI.Page
{
    public int MaxElements = 999999;
    public int MaxLoops = 10;

    protected void Page_Load(object sender, EventArgs e)
    {
        var oArrayList = new ArrayList();
        var oList = new List<int>();
        var oHashTable = new Hashtable();
        var oDictionary = new Dictionary<int, int>();

        var results = new List<ComparisonObj>();

        /*
         * Create a new Comparison Object
         * a Comparison object stores the various parameters which we want to monitor
         */

        var coArrayList = new ComparisonObj() { Description = "ArrayList"};
        results.Add(coArrayList);

        //ArrayList
        for (int Loop = 0; Loop < MaxLoops; Loop++)
        {
            oArrayList = new ArrayList();

            //Insert items to the array List
            using (var tOps = new TimeOperation())
            {
                for (int i = 0; i < MaxElements; i++)
                    oArrayList.Add(i);
                coArrayList.Duration_Insert += tOps.Stop();
            }

            //Iterate thru all items in the array list
            using (var tOps = new TimeOperation())
            {
                foreach (object o in oArrayList)
                {
                    int i = (int)o;
                }
                coArrayList.Duration_Iterate += tOps.Stop();
            }

            //Seek the middle number in the arraylist
            using (var tOps = new TimeOperation())
            {
                oArrayList.Contains(MaxElements / 2);
                coArrayList.Duration_Search += tOps.Stop();
            }

            oArrayList.Clear();
        }

        System.Threading.Thread.Sleep(5000);
        var coList = new ComparisonObj() { Description = "List"};
        results.Add(coList);
        for (int Loop = 0; Loop < MaxLoops; Loop++)
        {
            oList = new List<int>();

            using (var tOps = new TimeOperation())
            {
                for (int i = 0; i < MaxElements; i++)
                    oList.Add(i);
                coList.Duration_Insert += tOps.Stop();
            }

            using (var tOps = new TimeOperation())
            {
                foreach (var o in oList)
                {
                    int i = o;
                }
                coList.Duration_Iterate += tOps.Stop();
            }

            using (var tOps = new TimeOperation())
            {
                oList.Contains(MaxElements / 2);
                coList.Duration_Search += tOps.Stop();
            }

            oList.Clear();
        }
        System.Threading.Thread.Sleep(5000);
        var coHashTable = new ComparisonObj() { Description = "HashTable" };
        results.Add(coHashTable);
        for (int Loop = 0; Loop < MaxLoops; Loop++)
        {
            oHashTable = new Hashtable();

            using (var tOps = new TimeOperation())
            {
                for (int i = 0; i < MaxElements; i++)
                    oHashTable.Add(i, i);
                coHashTable.Duration_Insert += tOps.Stop();
            }

            using (var tOps = new TimeOperation())
            {
                foreach (object o in oHashTable.Keys)
                {
                    int i = (int)oHashTable[o];
                }
                coHashTable.Duration_Iterate += tOps.Stop();
            }

            using (var tOps = new TimeOperation())
            {
                oHashTable.ContainsKey(MaxElements / 2);
                coHashTable.Duration_Search += tOps.Stop();
            }

            oHashTable.Clear();
        }

        System.Threading.Thread.Sleep(5000);
        var coDictionary = new ComparisonObj() { Description = "Dictionary" };
        results.Add(coDictionary);
        for (int Loop = 0; Loop < MaxLoops; Loop++)
        {
            oDictionary = new Dictionary<int, int>();

            using (var tOps = new TimeOperation())
            {
                for (int i = 0; i < MaxElements; i++)
                    oDictionary.Add(i, i);
                coDictionary.Duration_Insert += tOps.Stop();
            }

            using (var tOps = new TimeOperation())
            {
                foreach (var o in oDictionary.Keys)
                {
                    int i = (int)oDictionary[o];
                }
                coDictionary.Duration_Iterate += tOps.Stop();
            }

            using (var tOps = new TimeOperation())
            {
                oDictionary.ContainsKey(MaxElements / 2);
                coDictionary.Duration_Search += tOps.Stop();
            }

            oHashTable.Clear();
        }


        System.Threading.Thread.Sleep(5000);
        foreach (var o in results)
        {
            o.Duration_Insert = o.Duration_Insert / MaxLoops;
            o.Duration_Iterate = o.Duration_Iterate / MaxLoops;
            o.Duration_Search = o.Duration_Search / MaxLoops;
        }

        GV.DataSource = results;
        GV.DataBind();
    }
}

class ComparisonObj
{
    public ComparisonObj() { }
    public string Description { get; set; }
    public long Duration_Insert { get; set; }
    public long Duration_Iterate { get; set; }
    public long Duration_Search { get; set; }
}
