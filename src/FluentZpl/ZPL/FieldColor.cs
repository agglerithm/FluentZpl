namespace ZplLabels.ZPL
{
    using ZplLabels.Common;

    public class FieldColor : EnumerationOfString<FieldColor>
    {

        public static FieldColor Black = new FieldColor("B", "Black");
        public static FieldColor White = new FieldColor("W", "White"); 

        private FieldColor(string parameter, string displayName)
            : base(parameter, displayName)
        {

        }

        public FieldColor()
        {
        }
    }
}