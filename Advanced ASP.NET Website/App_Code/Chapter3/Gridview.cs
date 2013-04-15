using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Chapter3
{
    /// <summary>
    /// Summary description for Chapter3_ListProducts
    /// </summary>
    public class ListProducts : System.Web.UI.WebControls.GridView
    {
        Literal lbl_QuickJump = new Literal();
        DropDownList ddl_QuickJump = new DropDownList();
        public ListProducts()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            this.Page.RegisterRequiresControlState(this);

            base.OnInit(e);
            lbl_QuickJump.Text = "Quickly jump to page: ";
            ddl_QuickJump.ID = ID + "_QJ";

            ddl_QuickJump.SelectedIndexChanged += new EventHandler(ddl_QuickJump_SelectedIndexChanged);
            ddl_QuickJump.AutoPostBack = true;
        }

        protected override void OnRowCreated(GridViewRowEventArgs e)
        {
            base.OnRowCreated(e);
        }

        protected override object SaveControlState()
        {
            return base.SaveControlState();
        }
        protected override void LoadControlState(object savedState)
        {
            base.LoadControlState(savedState);
        }
        protected override void OnDataBound(EventArgs e)
        {
            base.OnDataBound(e);
        }

        protected override void OnPageIndexChanged(EventArgs e)
        {
            base.OnPageIndexChanged(e);
        }

        void ddl_QuickJump_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
   }
}