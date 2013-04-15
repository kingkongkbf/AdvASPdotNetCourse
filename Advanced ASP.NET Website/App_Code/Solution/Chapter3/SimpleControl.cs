using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.ComponentModel;

namespace Solution.CustomControls
{
    /// <summary>
    /// This control has 2 properties, text and color. 
    /// Then it renders a simple font tag with the specified color and text
    /// </summary>
    public class SimpleControl : System.Web.UI.WebControls.WebControl
    {
        public SimpleControl()
        {

        }
        
        [BindableAttribute(true), Category("UI"), DefaultValue("")]
        public string Text
        {
            get
            {
                object obj = this.ViewState["Text"];

                //if viewstate does not contain anything, return empty
                if (obj == null)
                    return "";

                else
                    return obj.ToString();

            }

            set
            {
                //store the value in viewstate so that it is available on postback
                this.ViewState["Text"] = value;
            }

        }

        [BindableAttribute(true), Category("UI"), DefaultValue("")]
        public string Color
        {

            get
            {
                object obj = this.ViewState["Color"];

                //if viewstate does not contain anything, return empty
                if (obj == null)
                    return "";

                else
                    return obj.ToString();

            }

            set
            {
                //store the value in viewstate so that it is available on postback
                this.ViewState["Color"] = value;
            }

        }

        protected override void Render(HtmlTextWriter writer)
        {
            string txt = Text;

            //if there is no text and it is design mode, create a custom text so that it shows up in design mode
            if (txt.Length < 1)
                if (DesignMode)
                    txt = "SimpleControl: " + ID;
                else
                    txt = "[SimpleControl]";
            writer.Write("<font color='" + Color + "'>" + txt + "</font>");

            //ignore the original rendering
            //base.Render(writer);

        }

    }
}