using System;

namespace ZplLabels.ZPL
{
    using ZplLabels.Common;

    public class FieldOrientation : EnumerationOfString<FieldOrientation>
    {
        public static FieldOrientation Normal = new FieldOrientation("N", "Normal");
        public static FieldOrientation Rotated = new FieldOrientation("R", "Rotated");
        public static FieldOrientation Inverted = new FieldOrientation("I", "Inverted");
        public static FieldOrientation BottomUp = new FieldOrientation("B", "BottomUp");

        private FieldOrientation(string parameter, string displayName):base(parameter, displayName)
        {
            
        }

        public FieldOrientation()
        { 
        }
    }
}