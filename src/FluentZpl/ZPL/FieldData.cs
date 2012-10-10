using System;

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
            return string.Format("^FD{0}^FS\r\n", _data);
        }
    }
}