using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Core
{

    public class Decode
    {
        private string _string;
        private byte[] _stringDecrypted;

        public Decode(string str)
        {
            _string = str;
        }

        public Decode FromBase64String()
        {
            _stringDecrypted = Convert.FromBase64String(_string);
            return this;
        }

        public string Solve()
        {
            return Encoding.UTF8.GetString(_stringDecrypted);
        }
    }

}
