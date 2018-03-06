using System;

namespace ZplLabels.ZPL
{
    public class LabelPosition : ICloneable
    {
        public enum LabelAlignemnet
        {
            left, right
        }

        public LabelPosition(int xAxis, int yAxis)
        {
            X = xAxis;
            Y = yAxis;
            Alignment = LabelAlignemnet.left;
        }

        public LabelPosition(int xAxis, int yAxis, LabelAlignemnet alignment)
        {
            X = xAxis;
            Y = yAxis;
            Alignment = alignment;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public LabelAlignemnet Alignment { get; private set; }
        public override string ToString()
        {
            if (Alignment == LabelAlignemnet.right)
            {
                return string.Format("^FO{0},{1},1", X, Y);
            }
            return string.Format("^FO{0},{1}", X, Y);
        }

        public object Clone()
        {
            return new LabelPosition(X, Y);
        }
    }
}