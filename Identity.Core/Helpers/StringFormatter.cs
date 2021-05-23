using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Core.Helpers
{
    public class StringFormatter
    {
        private string _str;

        //flags
        private bool _isNullOrWhiteSpace;

        public StringFormatter(string str)
        {
            _str = str;
        }

        public StringFormatter IsNullOrWhiteSpace()
        {
            if (string.IsNullOrWhiteSpace(_str))
                _isNullOrWhiteSpace = true;
            return this;
        }

        public StringFormatter ToLower()
        {
            if (_isNullOrWhiteSpace)
                return this;

            _str = _str.ToLower();
            return this;
        }

        public string GetString() => !_isNullOrWhiteSpace ? _str : null;
    }
}
