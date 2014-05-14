using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckBoxList
{
    [ToolboxData("<{0}:CheckBoxList runat=server></{0}:CheckBoxList>")]
    public class CheckBoxList : System.Web.UI.WebControls.CheckBoxList
    {
        protected override void RenderItem(ListItemType itemType, int repeatIndex, RepeatInfo repeatInfo, HtmlTextWriter writer)
        {
            if (itemType == ListItemType.Item)
            {
                var item = Items[repeatIndex];

                writer.WriteBeginTag("div");
                writer.WriteAttribute("class", "checkbox");
                writer.Write(HtmlTextWriter.TagRightChar);

                writer.WriteBeginTag("label");
                writer.WriteAttribute("class", GetClassNames(item, repeatIndex));                
                writer.Write(HtmlTextWriter.TagRightChar);

                #region input
                writer.WriteBeginTag("input");
                writer.WriteAttribute("type", "checkbox");
                writer.WriteAttribute("name", UniqueID + IdSeparator + repeatIndex.ToString(NumberFormatInfo.InvariantInfo));
                writer.WriteAttribute("id", ClientID + ClientIDSeparator + repeatIndex.ToString(NumberFormatInfo.InvariantInfo));
                writer.WriteAttribute("value", item.Value);

                if (item.Selected) writer.WriteAttribute("checked", "checked");

                WriteItemAttributes(item, writer);

                writer.Write(HtmlTextWriter.SelfClosingTagEnd);
                #endregion

                writer.Write(item.Text);
                writer.WriteEndTag("label");
                writer.WriteEndTag("div");
            }
            else
            {
                base.RenderItem(itemType, repeatIndex, repeatInfo, writer);
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                RenderItem(ListItemType.Item, i, null, writer);
            }
        }

        protected string GetClassNames(ListItem item, int repeatIndex)
        {
            var classes = new List<string>();
            if (!String.IsNullOrEmpty(CssClass)) classes.Add(CssClass);
            if (!String.IsNullOrEmpty(item.Value)) classes.Add(ClientID + ClientIDSeparator + item.Value);
            if (!String.IsNullOrEmpty(item.Attributes["class"])) classes.Add(item.Attributes["class"]);
            if (repeatIndex == 0) classes.Add("first");
            else if (repeatIndex == Items.Count - 1) classes.Add("last");
            classes.Add(repeatIndex % 2 == 0 ? "odd" : "even");
            return string.Join(" ", classes.ToArray());
        }

        protected void WriteItemAttributes(ListItem item, HtmlTextWriter writer)
        {
            foreach (string key in item.Attributes.Keys)
            {
                if (key.ToLower() != "class")
                {
                    writer.WriteAttribute(key, item.Attributes[key]);
                }
            }
        }
    }
}