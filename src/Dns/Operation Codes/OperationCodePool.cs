using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.OperationCodes
{
    internal static class OperationCodePool
    {
        private static readonly IDnsOperationCode _null = new NullOperationCode();
        private static IDictionary<int, IDnsOperationCode> _codes
            = new Dictionary<int, IDnsOperationCode>();

        internal static IDnsOperationCode Find(int code)
        {
            if (_codes.TryGetValue(code, out IDnsOperationCode op))
            {
                return op;
            }

            return _null;
        }

        internal static IDnsOperationCode Find<TDnsOperationCode>()
            where TDnsOperationCode : IDnsOperationCode
        {
            foreach (var code in _codes)
            {
                if (code.Value is TDnsOperationCode)
                {
                    return code.Value;
                }
            }

            return _null;
        }

        static OperationCodePool()
        {
            _codes.Add(0, new StandardQuery());
            _codes.Add(1, new InverseQuery());
            _codes.Add(2, new StatusRequest());
            
            for (int i = 3; i < 15; i++)
            {
                _codes.Add(i, new Reserved(i));
            }           
        }
    }
}
