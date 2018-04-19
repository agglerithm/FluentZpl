using System;

namespace ZplLabels.ZPL
{
    using ZplLabels.ZPL;

    public class LabelBarcodeGenerator : FieldGenerator
    {
        private BarcodeType _barcodeType = BarcodeType.Code128;
        private FieldOrientation _orientation = FieldOrientation.Normal;
        private FontDefinition _font;
        private BarWidth _width = new BarWidth(3);
        private int _height;
        private int _totalDots;
        private bool _barcodeTextLabel = false;
        private bool _upperASCIIChar = false;

        public LabelBarcodeGenerator SetBarcodeType(BarcodeType type)
        {
            _barcodeType = type;
            return this;
        }

        public LabelBarcodeGenerator InBlock(int width, int lines, FieldJustification justification)
        {
            _block = new FieldBlock(width, lines, justification);
            return this;
        }

        /// <summary>
        /// Set Barcode position in pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public LabelBarcodeGenerator At(int x, int y)
        {
            _position = new LabelPosition(x, y);
            return this;
        }

        /// <summary>
        /// Set Barcode Position in milimeter
        /// </summary>
        /// <param name="dpiHelper"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public LabelBarcodeGenerator At(ZplLabels.Utilities.DPIHelper dpiHelper, double x, double y)
        {
            _position = new LabelPosition(dpiHelper.mmToPx(x), dpiHelper.mmToPx(y));
            return this;
        }

        /// <summary>
        /// Set Barcode position in pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public LabelBarcodeGenerator At(int x, int y, LabelPosition.LabelAlignemnet alignment)
        {
            _position = new LabelPosition(x, y, alignment);
            return this;
        }

        /// <summary>
        /// Set Barcode Position in milimeter
        /// </summary>
        /// <param name="dpiHelper"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public LabelBarcodeGenerator At(ZplLabels.Utilities.DPIHelper dpiHelper, double x, double y,
            LabelPosition.LabelAlignemnet alignment)
        {
            _position = new LabelPosition(dpiHelper.mmToPx(x), dpiHelper.mmToPx(y), alignment);
            return this;
        }

        public LabelBarcodeGenerator Centered(int width)
        {
            _totalDots = width;
            _block = new FieldBlock(width, 1, FieldJustification.Center);
            return this;
        }

        public LabelBarcodeGenerator Height(int height)
        {
            _height = height;
            return this;
        }

        public LabelBarcodeGenerator BarWidth(int width)
        {
            _width = new BarWidth(width);
            return this;
        }
        public LabelBarcodeGenerator WithData(string value)
        {
            if (value.Contains("�") || value.Contains("�") || value.Contains("�") || value.Contains("�") || value.Contains("�") || value.Contains("�"))
            {
                _upperASCIIChar = true;
            }
            _data = new FieldData(value);
            return this;
        }

        public LabelBarcodeGenerator SetFont(string type, FieldOrientation orientation, int size)
        {
            _font = new FontDefinition(type, size);
            _font.SetOrientation(orientation);
            return this;
        }

        public LabelBarcodeGenerator printTextLabel(bool barcodeTextLabel)
        {
            _barcodeTextLabel = barcodeTextLabel;
            return this;
        }

        public override string ToString()
        {
            if (_position == null) throw new ApplicationException("Field position must be set for barcode generator");
            if (_data == null) throw new ApplicationException("Field data must be set for barcode generator");
            var barcodePosition = getBarcodePosition();
            var textPosition = new LabelPosition(_position.X, _position.Y + getHeights());
            if (_barcodeTextLabel == true)
            {
                return barcodePosition + _barcodeType.Value + paramList() + _width + _data + textPosition + getBlock() + getFont() + _data;
            }
            return barcodePosition + _barcodeType.Value + paramList() + _width + _data;
        }

        private LabelPosition getBarcodePosition()
        {
            if (_totalDots == 0) return _position;
            var x = _totalDots / 2;
            var barWidth = getBarWidthPerCharacter() * 2 + getBarWidthPerCharacter() * _data.Length + getBarWidthPerCharacter() * 2 + 2;
            return new LabelPosition(x - barWidth / 2, _position.Y);
        }

        private int getBarWidthPerCharacter()
        {
            return _width.Value * 11;
        }
        private int getHeights()
        {
            var fontHeight = 0;
            if (_font != null)
                fontHeight = _font.Height;
            return _height + fontHeight;
        }

        private string getFont()
        {
            if (_font == null) return "";
            //            var maxLength = LABELWIDTH / _font.Width - (((LABELWIDTH / _font.Width) / 2) -1);
            //            if(maxLength < _data.Length)
            //            {
            //                _font = getAdjustedFont(_data.Length, LABELWIDTH, _font.FontType);
            //            }

            return _font.ToString();
        }

        private static FontDefinition getAdjustedFont(int length, int totalWidth, string fontType)
        {
            var fontSize = (int)(length * 1.8 / totalWidth);
            return new FontDefinition(fontType, fontSize);
        }

        private string getBlock()
        {
            if (_block == null) return "";
            return _block.ToString();
        }

        private string paramList()
        {
            if (_upperASCIIChar == true)
            {
                return _orientation.Value + "," + _height + ",200,N,N,6\r\n";
            }
            return _orientation.Value + "," + _height + ",200,N,N,3\r\n";
        }
    }
}