using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Classes
{
    internal static class ClassPool
    {
        private static readonly IDnsClass _null = new NullClass();
        private static IDictionary<int, IDnsClass> _codes
            = new Dictionary<int, IDnsClass>();

        internal static IDnsClass Find(int code)
        {
            if (_codes.TryGetValue(code, out IDnsClass op))
            {
                return op;
            }

            return _null;
        }

        internal static IDnsClass Find<TDnsClass>()
            where TDnsClass : IDnsClass
        {
            foreach(var code in _codes)
            {
                if (code.Value is TDnsClass)
                {
                    return code.Value;
                }
            }

            return _null;
        }

        static ClassPool()
        {
            _codes.Add(1, new Internet());
        }
    }
}
