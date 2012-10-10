namespace ZplLabels.ZPL
{
    public class FieldGenerator : IFieldGenerator
    {
        protected const int LABELWIDTH = 1200;
        protected LabelPosition _position;
        protected FieldData _data;
        protected FieldBlock _block;
        protected string _script = "";
    }
}