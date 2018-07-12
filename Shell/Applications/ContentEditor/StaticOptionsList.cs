using Sitecore.Diagnostics;
using System.Web.UI;

namespace Sitecore.Foundation.Extension.FieldType.Shell.Applications.ContentEditor
{
    public class StaticOptionsList : Web.UI.HtmlControls.Control
    {
        public bool HasPostData { get; set; }
        public string Source { get; set; }

        public StaticOptionsList()
        {
            Class = "scContentControl";
            Activation = true;
        }

        protected override void DoRender(HtmlTextWriter output)
        {
            string err = null;
            output.Write("<select" + GetControlAttributes() + ">");
            output.Write("<option value=\"\"></option>");

            if (string.IsNullOrEmpty(Source))
            {
                err = "No source property specified for field.";
            }
            else
            {
                string[] kvPairs = Source.Split('|');
                Assert.IsTrue(kvPairs != null && kvPairs.Length > 0, "kvPairs");

                bool valueFound = string.IsNullOrEmpty(Value);

                foreach (string kvPair in kvPairs)
                {
                    int i = kvPair.IndexOf(":");
                    string key;
                    string value;

                    if (i < 0)
                    {
                        key = kvPair;
                        value = kvPair;
                    }
                    else
                    {
                        key = kvPair.Substring(0, i);
                        value = kvPair.Substring(i + 1);
                    }

                    value = Globalization.Translate.Text(value);
                    valueFound = valueFound || key == Value;
                    output.Write(string.Format(@"<option value=""{0}"" {1}>{2}</option>", key, Value == key ? " selected=\"selected\"" : string.Empty, value));
                }

                if (!valueFound)
                {
                    err = Globalization.Translate.Text("Value not in the select list.");
                }
            }

            if (err != null)
            {
                output.Write("<optgroup label=\"" + err + "\">");
                output.Write("<option value=\"" + Value + "\" selected=\"selected\">" + Value + "</option>");
                output.Write("</optgroup>");
            }

            output.Write("</select>");

            if (err != null)
            {
                output.Write("<div style=\"color: #999; padding: 2px 0 0 0;\">{0}</div>", err);
            }
        }

        protected override bool LoadPostData(string value)
        {
            HasPostData = true;

            if (value == null)
            {
                return false;
            }

            if (GetViewStateString("Value") != value)
            {
                SetModified();
            }

            SetViewStateString("Value", value);
            return true;
        }

        private static void SetModified()
        {
            Sitecore.Context.ClientPage.Modified = true;
        }
    }
}