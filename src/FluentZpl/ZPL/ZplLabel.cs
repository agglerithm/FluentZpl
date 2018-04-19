using System;

namespace ZplLabels.ZPL
{
    public class ZplLabel
    {

        private string _script;
        private int _homeX;
        private int _homeY;
        private int _offsetX = 0;
        private int _offsetY = 0;
        private int _customCutOffset;
        private string _customZPL = "";
        private double? _darkness = null;
        private int _length = 0;
        private PrintMode _mode = PrintMode.tearOff;

        public ZplLabel()
        {
        }

        /// <summary>
        /// Load ZPl Label Data
        /// </summary>
        /// <param name="generators"></param>
        /// <returns></returns>
        public ZplLabel Load(params IFieldGenerator[] generators)
        {
            foreach (IFieldGenerator gen in generators)
            {
                _script += gen.ToString();

            }
            return this;
        }

        /// <summary>
        /// returns ZPL Code
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return getHeader() + getLength() + getDarkness() + getLabelOffset() + getHome() +
                _customZPL + _script + getFooter();
        }

        private string getHome()
        {
            return string.Format("^LH{0},{1}\r\n", _homeX, _homeY);
        }

        /// <summary>
        /// Sets Homeposition of Label in Pixel
        /// </summary>
        /// <param name="fromLeft"></param>
        /// <param name="fromTop"></param>
        /// <returns></returns>
        public ZplLabel At(int fromLeft, int fromTop)
        {
            _homeX = fromLeft;
            _homeY = fromTop;
            return this;
        }
        /// <summary>
        /// Sets Homeposition of Label in mm
        /// </summary>
        /// <param name="dpiHelper"></param>
        /// <param name="fromLeft"></param>
        /// <param name="fromTop"></param>
        /// <returns></returns>
        public ZplLabel At(ZplLabels.Utilities.DPIHelper dpiHelper, double fromLeft, double fromTop)
        {
            ;
            _homeX = dpiHelper.mmToPx(fromLeft);
            _homeY = dpiHelper.mmToPx(fromTop);
            return this;
        }

        /// <summary>
        /// Cut Offset in Pixel
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public ZplLabel CutOffset(int offset)
        {
            _customCutOffset = offset;
            return this;
        }

        /// <summary>
        /// Sets Label Offset
        /// </summary>
        /// <param name="xOffset">x Offset in dots</param>
        /// <param name="yOffset">y Offset in dot rows</param>
        /// <returns></returns>
        public ZplLabel LabelOffset(int xOffset, int yOffset)
        {
            _offsetX = xOffset;
            _offsetY = yOffset;
            return this;
        }

        public ZplLabel Length(int length)
        {
            _length = length;
            return this;
        }

        public ZplLabel Length(ZplLabels.Utilities.DPIHelper dpiHelper, double length)
        {
            _length = dpiHelper.mmToPx(length);
            return this;
        }

        /// <summary>
        /// Cut Offset in milimeter
        /// </summary>
        /// <param name="dpiHelper"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public ZplLabel CutOffset(ZplLabels.Utilities.DPIHelper dpiHelper, double offset)
        {
            _customCutOffset = dpiHelper.mmToPx(offset);
            return this;
        }

        /// <summary>
        /// Sets Mode of the Printer
        /// Tear Off
        /// Peel Off
        /// Cut
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public ZplLabel Mode(PrintMode mode)
        {
            _mode = mode;
            return this;
        }


        public ZplLabel Darkness(double darkness)
        {
            if (darkness > 30)
            {
                darkness = 30;
            }
            else if (darkness < 0)
            {
                darkness = 0;
            }
            _darkness = darkness;
            return this;
        }

        /// <summary>
        /// Insert Custom ZPL Code inside Label
        /// </summary>
        /// <param name="customZPL"></param>
        /// <returns></returns>
        public ZplLabel customZPLCommand(string customZPL)
        {
            _customZPL = customZPL;
            return this;
        }

        private string getFooter()
        {
            return @"^XZ\r\n";
        }

        private string getHeader()
        {
            var mode = "";
            switch (_mode)
            {
                case PrintMode.peelOff:
                    mode = "^MMP,N";
                    break;
                case PrintMode.cut:
                    mode = "^MMC,N";
                    break;
                case PrintMode.tearOff:
                    mode = "^MMT,N";
                    break;
            }

            return "^XA" + mode + "~TA" + _customCutOffset.ToString("000") + "\r\n";
        }

        private string getDarkness()
        {
            if (_darkness == null)
            {
                return "";
            }

            return "~SD" + Math.Round((double)_darkness, 1).ToString("00.0");
        }

        private string getLabelOffset()
        {
            if (_offsetY > 120)
            {
                _offsetY = 120;
            }
            else if (_offsetY < -120)
            {
                _offsetY = -120;
            }
            return "^LT" + _offsetY + "^LS" + _offsetX;
        }

        private string getLength()
        {
            if (_length < 1 || _length > 32000)
            {
                return "";
            }
            return "^LL" + _length.ToString();
        }
    }
}
