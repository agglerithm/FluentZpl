using System.Xml.Linq;

namespace ZplLabels.Common.Extensions
{
#pragma warning disable 1591
    public static class XElementExtensions
    { 
        public static void SafeRemove(this XElement el)
        {
            if(el != null && el.Parent != null) el.Remove();
        }

        public static void SafeRemove(this XAttribute attr)
        {
            if (attr != null) attr.Remove();
        }

        public static string GetSafeValue(this XElement el)
        {
            return el == null ? null : el.Value;
        }

        public static string GetSafeValue(this XAttribute attr)
        {
            return attr == null ? null : attr.Value;
        }

        public static string GetTextOfNodeNamed(this XElement el, string name)
        {
            var textEl = el.Elements().Find(e => e.Name.LocalName == name);
            return textEl == null ? "" : textEl.Value;
        }
    }
}