using System;
using System.Collections.Generic;
using System.Text;

namespace Dns
{
    /// <summary>
    /// (RFC1035 4.1.1)
    /// </summary>
    internal interface IDnsOperationCode
    {
        int ToInt();
    }
}
