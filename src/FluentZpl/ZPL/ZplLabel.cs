namespace ZplLabels.ZPL
{
    public class ZplLabel
    {

        private string _script;
        private int _homeX;
        private int _homeY;

        public ZplLabel ()
        { 
        }

        public ZplLabel Load(params IFieldGenerator [] generators)
        { 
            foreach(IFieldGenerator gen in generators)
            {
                _script += gen.ToString();

            } 
            return this;
        }

        public override string ToString()
        {
            return getHeader() + getHome() + _script + getFooter();
        }

        private string getHome()
        {
            return string.Format("^LH{0},{1}\r\n", _homeX, _homeY);
        }

        public ZplLabel At(int fromLeft, int fromTop)
        {
            _homeX = fromLeft;
            _homeY = fromTop;
            return this;
        }
        private string getFooter()
        {
            return @"^XZ
";
        }

        private string getHeader()
        {
            return "^XA\r\n";
        }
    }
}
