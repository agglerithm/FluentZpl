namespace ZplLabels.ZPL
{
    public class FieldData
    {
        private string _data;
        public FieldData(string data)
        {
            _data = data;
        }

        public int Length 
        {
            get { return _data.Length; }
        }

        public override string ToString()
        {
            if (_data.Contains("ä") || _data.Contains("ö") || _data.Contains("ü") || _data.Contains("Ö") ||
                _data.Contains("Ä") || _data.Contains("Ü"))
            {
                _data = _data.Replace("ä", "_84")
               .Replace("ö", "_94")
               .Replace("ü", "_81")
               .Replace("Ä", "_8E")
               .Replace("Ö", "_99")
               .Replace("Ü", "_9A");
                return string.Format("^FH^FD{0}^FS\r\n", _data);
            }
            return string.Format("^FD{0}^FS\r\n", _data);
        }
    }
}