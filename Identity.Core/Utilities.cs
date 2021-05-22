using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Core
{

    public class Decrypt
    {
        private string _string;
        private byte[] _stringDecrypted;

        public Decrypt(string str)
        {
            _string = str;
        }

        public Decrypt FromBase64String()
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
