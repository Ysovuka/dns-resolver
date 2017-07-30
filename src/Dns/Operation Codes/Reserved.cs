using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.OperationCodes
{
    internal class Reserved : IDnsOperationCode
    {
        private readonly int _code;
        public Reserved(int code)
        {
            _code = code;
        }

        public int ToInt() => _code;
    }
}
