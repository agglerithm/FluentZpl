namespace ZplLabels.ZPL
{
    public class FieldGenerator : IFieldGenerator
    {
        protected const int LABELWIDTH = 1200;
        protected LabelPosition _position;
        protected FieldData _data;
        protected FieldBlock _block;
        protected string _script = "";

        public IFieldGenerator At(ZplLabels.Utilities.DPIHelper dpiHelper, double fromLeft, double fromTop)
        {
            _position = new LabelPosition(dpiHelper.mmToPx(fromLeft), dpiHelper.mmToPx(fromTop));
            return this;
        }

        public IFieldGenerator At(int fromLeft, int fromTop)
        {
            _position = new LabelPosition(fromLeft, fromTop);
            return this;
        }

        public IFieldGenerator At(ZplLabels.Utilities.DPIHelper dpiHelper, double fromLeft, double fromTop,
            LabelPosition.LabelAlignemnet alignment)
        {
            _position = new LabelPosition(dpiHelper.mmToPx(fromLeft), dpiHelper.mmToPx(fromTop), alignment);
            return this;
        }

        public IFieldGenerator At(int fromLeft, int fromTop, LabelPosition.LabelAlignemnet alignment)
        {
            _position = new LabelPosition(fromLeft, fromTop, alignment);
            return this;
        }

        public IFieldGenerator Move(int fromLeft, int fromTop)
        {
            _position = new LabelPosition(_position.X + fromLeft, _position.Y + fromTop, _position.Alignment);
            return this;
        }

        public IFieldGenerator Move(ZplLabels.Utilities.DPIHelper dpiHelper, double fromLeft, double fromTop)
        {
            _position = new LabelPosition(_position.X + dpiHelper.mmToPx(fromLeft), _position.Y + dpiHelper.mmToPx(fromTop),
                _position.Alignment);
            return this;
        }
    }
}