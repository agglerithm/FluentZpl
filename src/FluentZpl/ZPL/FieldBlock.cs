using System;

namespace ZplLabels.ZPL
{
    public class FieldBlock 
    {
        private readonly int _lines;
        private readonly FieldJustification _justification;
        private int _verticalSpace;

        public FieldBlock(int width, int lines, FieldJustification justification)
        {
            Width = width;
            _lines = lines;
            _justification = justification; 
            _verticalSpace = 0;
        }

        public int Width { get; private set; }

        public FieldBlock AddVerticalWhiteSpace(int dots)
        {
            _verticalSpace = dots;
            return this;
        }

        public override string ToString()
        {
            return string.Format("^FB{0},{1},{2},{3}\r\n", Width, _lines, _verticalSpace, _justification.Value);
        }
    }
}