namespace ZplLabels.ZPL
{
    public class BarWidth
    {
        private string _val
                       ;

        private int _width;

        public BarWidth(int width)
        {
            _width = width;
            _val = string.Format("^BY{0}\r\n", width);
        }

        public int Value
        {
            get { return _width; }
        }

        public override string ToString()
        {
            return _val;
        }
    }
}