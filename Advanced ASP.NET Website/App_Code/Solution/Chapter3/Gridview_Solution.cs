using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Solution.Chapter3
{
    /// <summary>
    /// Summary description for Chapter3_ListProducts
    /// </summary>
    public class ListProducts : System.Web.UI.WebControls.GridView
    {
        private GridViewRow gvTopRow = new GridViewRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal);
        //define gridview row
        //impt: gridview consists of a hierarchy of controls.

        Literal lbl_QuickJump = new Literal();
        DropDownList ddl_QuickJump = new DropDownList();
        public ListProducts()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            this.Page.RegisterRequiresControlState(this);

            base.OnInit(e);

            //initialize the label
            lbl_QuickJump.Text = "Quickly jump to page: ";

            //initialize the drop down
            ddl_QuickJump.ID = ID + "_QJ";
            ddl_QuickJump.SelectedIndexChanged += new EventHandler(ddl_QuickJump_SelectedIndexChanged);
            ddl_QuickJump.AutoPostBack = true;

            //create a table cell to put these controls into. Row contains cells
            TableCell cell = new TableHeaderCell();
            cell.HorizontalAlign = HorizontalAlign.Right; //align the row to the right
            cell.ColumnSpan = this.Columns.Count;
            cell.Controls.Add(lbl_QuickJump);
            cell.Controls.Add(ddl_QuickJump);
            this.gvTopRow.Cells.Add(cell);
        }

        protected override void OnRowCreated(GridViewRowEventArgs e)
        {
            base.OnRowCreated(e);
            if ((e.Row != null) && (e.Row.RowType == DataControlRowType.Header))
            {
                Table table = (Table)this.Controls[0];
                table.Rows.AddAt(0, this.gvTopRow);  //insert row at the top
            }
        }

        protected override object SaveControlState() //versus view state. ControlState will maintain state for the drop down list.
        {
            var Items = new List<Pair<string, string>>();
            foreach (ListItem Item in ddl_QuickJump.Items)
                Items.Add(new Pair<string, string>(Item.Text, Item.Value));
            return new object[] { base.SaveControlState(), Items, ddl_QuickJump.SelectedIndex };
        }
        protected override void LoadControlState(object savedState)
        {
            object[] objArray = (object[])savedState;
            base.LoadControlState(objArray[0]);
            ddl_QuickJump.Items.Clear();
            foreach (var Item in (List<Pair<string, string>>)objArray[1])
            {
                ddl_QuickJump.Items.Add(new ListItem(Item.First, Item.Second));
            }
            ddl_QuickJump.SelectedIndex = (int)objArray[2];

        }

        
        protected override void OnDataBound(EventArgs e)
        {
            base.OnDataBound(e);
            ddl_QuickJump.Items.Clear();
            for (int i = 0; i < PageCount; i++) //shows how many pages available
            {
                ddl_QuickJump.Items.Add(new ListItem((i + 1).ToString(), i.ToString()));
            }
            ddl_QuickJump.SelectedIndex = PageIndex;  //if user selects pageIndex, drop down list will also change!
        }

        protected override void OnPageIndexChanged(EventArgs e)
        {
            base.OnPageIndexChanged(e);
            ddl_QuickJump.SelectedIndex = PageIndex;
        }

        void ddl_QuickJump_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageIndex = Convert.ToInt32(ddl_QuickJump.SelectedValue);
            ddl_QuickJump.SelectedIndex = PageIndex;
        }
   }
}