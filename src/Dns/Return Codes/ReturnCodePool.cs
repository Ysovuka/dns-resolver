using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.ReturnCodes
{
    internal static class ReturnCodePool
    {
        private static readonly IDnsReturnCode _null = new NullReturnCode();
        private static IDictionary<int, IDnsReturnCode> _codes
            = new Dictionary<int, IDnsReturnCode>();

        internal static IDnsReturnCode Find(int code)
        {
            if (_codes.TryGetValue(code, out IDnsReturnCode op))
            {
                return op;
            }

            return _null;
        }

        internal static IDnsReturnCode Find<TDnsReturnCode>()
            where TDnsReturnCode : IDnsReturnCode
        {
            foreach (var code in _codes)
            {
                if (code.Value is TDnsReturnCode)
                {
                    return code.Value;
                }
            }

            return _null;
        }

        static ReturnCodePool()
        {
            _codes.Add(0, new Success());
            _codes.Add(1, new FormatError());
            _codes.Add(2, new ServerFailure());
            _codes.Add(3, new NameError());
            _codes.Add(4, new NotImplemented());
            _codes.Add(5, new Refused());
            _codes.Add(6, new Other());
        }
    }
}
