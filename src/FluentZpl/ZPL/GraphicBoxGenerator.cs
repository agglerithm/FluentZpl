namespace ZplLabels.ZPL
{
    public class GraphicBoxGenerator : FieldGenerator
    {
        private int _width;
        private int _height;
        private int _lineThickness;
        private FieldColor _color = FieldColor.Black;
        public override string ToString()
        {
            return string.Format("{0}^GB{1},{2},{3},{4}^FS\r\n", _position, _width, _height, _lineThickness, _color);
        }

        /// <summary>
        /// Set Graphic Box position in pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public GraphicBoxGenerator At(int x, int y)
        {
            _position = new LabelPosition(x, y);
            return this;
        }

        /// <summary>
        /// Set Graphic Box position in milimeter
        /// </summary>
        /// <param name="dpiHelper"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public GraphicBoxGenerator At(ZplLabels.Utilities.DPIHelper dpiHelper, double x, double y)
        {
            _position = new LabelPosition(dpiHelper.mmToPx(x), dpiHelper.mmToPx(y));
            return this;
        }

        /// <summary>
        /// Set Graphic Box position in pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public GraphicBoxGenerator At(int x, int y, LabelPosition.LabelAlignemnet alignment)
        {
            _position = new LabelPosition(x, y, alignment);
            return this;
        }

        /// <summary>
        /// Set Graphic Box position in milimeter
        /// </summary>
        /// <param name="dpiHelper"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public GraphicBoxGenerator At(ZplLabels.Utilities.DPIHelper dpiHelper, double x, double y,
            LabelPosition.LabelAlignemnet alignment)
        {
            _position = new LabelPosition(dpiHelper.mmToPx(x), dpiHelper.mmToPx(y), alignment);
            return this;
        }

        public GraphicBoxGenerator HorizontalLine(int width, int lineThickness)
        {
            return this.Rectangle(width, 1, lineThickness);
        }
        public GraphicBoxGenerator VerticalLine(int height, int lineThickness)
        {
            return this.Rectangle(1, height, lineThickness);
        }

        public GraphicBoxGenerator Rectangle(int width, int height, int lineThickness)
        {
            _width = width;
            _lineThickness = lineThickness;
            _height = height;
            return this;
        }
    }
}