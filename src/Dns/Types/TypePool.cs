using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    internal static class TypePool
    {
        private static readonly IDnsType _null = new NullType();
        private static IDictionary<int, IDnsType> _codes
            = new Dictionary<int, IDnsType>();

        internal static IDnsType Find(int code)
        {
            if (_codes.TryGetValue(code, out IDnsType op))
            {
                return op;
            }

            return _null;
        }

        internal static IDnsType Find<TDnsType>()
            where TDnsType : IDnsType
        {
            foreach (var code in _codes)
            {
                if (code.Value is TDnsType)
                {
                    return code.Value;
                }
            }

            return _null;
        }

        static TypePool()
        {
            _codes.Add(1, new IPv4Address());
            _codes.Add(2, new NameServer());
            _codes.Add(3, new MailDestination());
            _codes.Add(4, new MailForwarder());
            _codes.Add(5, new CanonicalName());
            _codes.Add(6, new StateOfAuthority());
            _codes.Add(7, new Mailbox());
            _codes.Add(8, new MailGroup());
            _codes.Add(9, new MailboxRename());
            _codes.Add(10, new Null());
            _codes.Add(11, new WellKnownService());
            _codes.Add(12, new Pointer());
            _codes.Add(13, new HostInformation());
            _codes.Add(14, new MailboxInformation());
            _codes.Add(15, new MailExchange());
            _codes.Add(16, new Text());
            _codes.Add(17, new ResponsiblePerson());
            _codes.Add(18, new AFSDatabaseServer());
            _codes.Add(19, new X25Pointer());
            _codes.Add(20, new IntegratedServicesDigitalNetwork());
            _codes.Add(21, new RouteThrough());
            _codes.Add(22, new NetworkServiceAccessPoint());
            _codes.Add(23, new NetworkServiceAccessPointReverse());
            _codes.Add(24, new Signature());
            _codes.Add(25, new Key());
            _codes.Add(26, new X400Pointer());
            _codes.Add(27, new GeographicLocationInformation());
            _codes.Add(28, new IPv6HostAddress());
            _codes.Add(29, new LocationInformation());
            _codes.Add(30, new NextResource());
            _codes.Add(31, new EndpointIdentifier());
            _codes.Add(32, new NimLoc());
            _codes.Add(33, new Service());
            _codes.Add(34, new AsynchronousTransferModeAddress());
            _codes.Add(35, new NameAuthorityPointer());
            _codes.Add(36, new KeyExchange());
            _codes.Add(37, new Certificate());
            _codes.Add(38, new IPv6Address());
            _codes.Add(39, new DomainName());
            _codes.Add(40, new KitchenSink());
            _codes.Add(41, new OptionCodes());
            _codes.Add(42, new AddressPrefixList());
            _codes.Add(43, new DelegationSigner());
            _codes.Add(44, new SecureShellFingerprint());
            _codes.Add(45, new IPSecKey());
            _codes.Add(46, new ResourceRecordSignature());
            _codes.Add(47, new NextSecure());
            _codes.Add(48, new DomainNameSystemKey());
            _codes.Add(49, new DynamicHostConfigurationProtocolInformation());
            _codes.Add(50, new NextSecure3());
            _codes.Add(51, new NextSecure3Paramaters());
            _codes.Add(55, new HostIdentityProtocol());
            _codes.Add(99, new SenderPolicyFramework());
            _codes.Add(249, new TransactionKey());
            _codes.Add(250, new TransactionSignature());
        }
    }
}
