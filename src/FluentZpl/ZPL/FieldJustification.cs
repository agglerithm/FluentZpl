namespace ZplLabels.ZPL
{
    using ZplLabels.Common;

    public class FieldJustification : EnumerationOfString<FieldJustification>
    {

        public static FieldJustification Left = new FieldJustification("L", "Left");
        public static FieldJustification Center = new FieldJustification("C", "Center");
        public static FieldJustification MarginToMargin = new FieldJustification("J", "MarginToMargin");
        public static FieldJustification Right = new FieldJustification("R", "Right");

        private FieldJustification(string parameter, string displayName):base(parameter, displayName)
        {
            
        }

        public FieldJustification()
        { 
        }
    }
}