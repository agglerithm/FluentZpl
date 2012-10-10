using System;

namespace ZplLabels.ZPL
{
    public class FontDefinition
    {
        private   FieldOrientation _orientation;
        private int _width = 0;

        public FontDefinition(string fontType,  int size)
        {
            Height = size;
            FontType = fontType;
            _orientation = FieldOrientation.Normal;
        }

        private int _height;
        public int Height
        {
            get { return _height; }
            private set { _height =  value;
                _width = (int) (_height/1.8);
            }
        }

        public int Width
        {
            get { return _width; }
        }
//        private int proportionalHeight(int value)
//        {
//            var multiplier = (int)value/18;
//            var remainder = value%18;
//            if (remainder > 9)
//                multiplier++; 
//            return multiplier*18;
//        }

        public string FontType { get; private set; }

        public FontDefinition SetOrientation(FieldOrientation orientation)
        {
            _orientation = orientation;
            return this;
        }

        public FontDefinition SetWidth(int width)
        {
            _width = width;
            return this;
        }

        public override string ToString()
        {
            var font = string.Format("^A{0}{1},{2}", FontType, _orientation.Value, Height);
            if (font.EndsWith(","))
                return font.Substring(0, font.Length - 1);
            return font;
        }
    }
}