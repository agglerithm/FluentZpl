using System;

namespace ZplLabels.ZPL
{
    public class LabelTextGenerator : FieldGenerator
    {
        private FontDefinition _font;
        private bool _underline;


        public LabelTextGenerator At(int fromLeft, int fromTop)
        {
            _position = new LabelPosition(fromLeft, fromTop);
            return this;
        }

        public LabelTextGenerator InBlock(int width, int lines, FieldJustification justification)
        {
            _block = new FieldBlock(width, lines, justification);
            return this;
        }

        public LabelTextGenerator Centered(int width)
        {
            _block = new FieldBlock(width,1,FieldJustification.Center);
            return this;
        }

        public LabelTextGenerator SetFont(string type, FieldOrientation orientation, int size)
        {
            _font = new FontDefinition(type, size);
            _font.SetOrientation(orientation); 
            return this;
        }

        public LabelTextGenerator Underline()
        {
            _underline = true;
            return this;
        }
        public override string ToString()
        {
            if (_position == null) throw new ApplicationException("Field position must be set for text generator");
            if (_data == null) throw new ApplicationException("Field data must be set for text generator");
              
            return _position + getFont() + getBlock() + _script + _data + getUnderline();
        }

        private string getUnderline()
        {
            if (!_underline) return "";
            var ulPosition = new LabelPosition(_position.X, _position.Y + 3);
            return ulPosition + "^FD".PadRight(_data.Length, '_') + "^FS";
        }

        private string getFont()
        {
            return _font == null ? "" : _font.ToString();
        }

        private string getBlock()
        {
            return _block == null ? "" : _block.ToString();
        }

        public LabelTextGenerator WithData(string value)
        {
            _data = new FieldData(value);
            return this;
        }
    }
}