using Dns.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dns
{
    /// <summary>
    /// (RFC1035 3.2.2/3)
    /// </summary>
    public interface IDnsType
    {
        int ToInt();
    }
}
