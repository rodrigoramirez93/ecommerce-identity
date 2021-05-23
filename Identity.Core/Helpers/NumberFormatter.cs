using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Core.Helpers
{
    public class NumberFormatter
    {
        private string _number = null;
        private decimal _parsedNumber = 0;

        //flags
        private bool _canBeParsed;
        private bool _isNullOrWhiteSpace;

        public NumberFormatter(string number)
        {
            _number = number;
        }

        public NumberFormatter IsNullOrWhiteSpace()
        {
            if (string.IsNullOrWhiteSpace(_number))
                _isNullOrWhiteSpace = true;
            return this;
        }

        public NumberFormatter CanBeParsed()
        {
            if (decimal.TryParse(_number, out _parsedNumber))
                _canBeParsed = true;
            return this;
        }

        public int? GetInteger(bool zeroIfNull = false)
        {
            if (_isNullOrWhiteSpace && zeroIfNull)
                return 0;

            return !_isNullOrWhiteSpace && _canBeParsed ? (int?)Convert.ToInt32(_parsedNumber) : null;
        }
    }
}
