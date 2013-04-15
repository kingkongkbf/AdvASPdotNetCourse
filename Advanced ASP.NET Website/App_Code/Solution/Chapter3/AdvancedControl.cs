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
    /// Then it renders a span tag with the specified color and text
    /// if there is a onclick event, it will render the javascript to trigger the postback as well
    /// </summary>
    public class AdvancedControl : System.Web.UI.WebControls.WebControl, IPostBackEventHandler
    {
        public AdvancedControl()
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

        //Stores the ClickEvent
        private readonly object EventClick1 = new object();

        //Internal Click function which calls the event handlers, if any
        protected virtual void OnClick1(EventArgs e)
        {
            EventHandler onClickHandler = (EventHandler)Events[EventClick1]; 
            if (onClickHandler != null)
                onClickHandler(this, e); 
        }

        //The event that is exposed in Design Mode
        [Category("Action"), Description("Raised when the text is clicked")]
        public event EventHandler Click1
        {
            add
            {
                Events.AddHandler(EventClick1, value);
            }
            remove
            {
                Events.RemoveHandler(EventClick1, value);
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            string txt = Text;

            //if there is no text and it is design mode, create a custom text so that it shows up in design mode
            if (txt.Length < 1)
                if (DesignMode)
                    txt = "AdvancedControl: " + ID;
                else
                    txt = "[AdvancedControl]";
            bool hasEvent = Events[EventClick1] != null;

            writer.Write("<span ");
            if (hasEvent && !DesignMode)
            {
                writer.Write("onclick=\"" + Page.ClientScript.GetPostBackEventReference(this, "Click") + "\";   ");
            }
            writer.Write("color='" + Color + "'>" + txt + "</span>");

            //ignore the original rendering
            //base.Render(writer);

        }


        #region IPostBackEventHandler Members

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            switch (eventArgument)
            {
                case "Click":
                    OnClick1(new EventArgs());
                    break;
            }
        }

        #endregion
    }
}