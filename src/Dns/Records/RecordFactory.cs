using Dns.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    internal static class RecordFactory
    {
        internal static IRecord Create(IDnsType type, Pointer pointer, ushort length)
        {
            switch(type.ToInt())
            {
                case 1:   return new IPv4AddressRecord(pointer);
                case 2:   return new NameServerRecord(pointer);
                case 3:   return new MailDestinationRecord(pointer);
                case 4:   return new MailForwarderRecord(pointer);
                case 5:   return new CanonicalNameRecord(pointer);
                case 6:   return new StateOfAuthorityRecord(pointer);
                case 7:   return new MailboxRecord(pointer);
                case 8:   return new MailGroupRecord(pointer);
                case 9:   return new MailboxRenameRecord(pointer);
                case 10:  return new NullRecord(pointer);
                case 11:  return new WellKnownServiceRecord(pointer);
                case 12:  return new PointerRecord(pointer);
                case 13:  return new HostInformationRecord(pointer);
                case 14:  return new MailboxInformationRecord(pointer);
                case 15:  return new MailExchangeRecord(pointer);
                case 16:  return new TextRecord(pointer, length);
                case 17:  return new ResponsiblePersonRecord(pointer);
                case 18:  return new AFSDatabaseServerRecord(pointer);
                case 19:  return new X25PointerRecord(pointer);
                case 20:  return new IntegratedServicesDigitalNetworkRecord(pointer);
                case 21:  return new RouteThroughRecord(pointer);
                case 22:  return new NetworkServiceAccessPointRecord(pointer);
                case 23:  return new NetworkServiceAccessPointReverseRecord(pointer);
                case 24:  return new SignatureRecord(pointer);
                case 25:  return new KeyRecord(pointer);
                case 26:  return new X400Pointer(pointer);
                case 27:  return new GeographicLocationInformationRecord(pointer);
                case 28:  return new IPv6HostAddressRecord(pointer);
                case 29:  return new LocationInformationRecord(pointer);
                case 30:  return new NextResourceRecord(pointer);
                case 31:  return new EndPointIdentifierRecord(pointer);
                case 32:  return new NimLocRecord(pointer);
                case 33:  return new ServiceRecord(pointer);
                case 34:  return new AsynchronousTransferModeAddressRecord(pointer);
                case 35:  return new NameAuthorityPointerRecord(pointer);
                case 36:  return new KeyExchangeRecord(pointer);
                case 37:  return new CertificateRecord(pointer);
                case 38:  return new IPv6AddressRecord(pointer);
                case 39:  return new DomainNameRecord(pointer);
                case 40:  return new KitchenSinkRecord(pointer);
                case 41:  return new OptionsCodesRecord(pointer);
                case 42:  return new AddressPrefixListRecord(pointer);
                case 43:  return new DelegationSignerRecord(pointer);
                case 44:  return new SecureShellFingerprintRecord(pointer);
                case 45:  return new IPSecKeyRecord(pointer);
                case 46:  return new ResourceRecordSignatureRecord(pointer);
                case 47:  return new NextSecureRecord(pointer);
                case 48:  return new DomainNameSystemKeyRecord(pointer);
                case 49:  return new DynamicHostConfigurationProtocolInformationRecord(pointer);
                case 50:  return new NextSecure3Record(pointer);
                case 51:  return new NextSecure3ParamteresRecord(pointer);
                case 55:  return new HostIndentityProtocolRecord(pointer);
                case 99:  return new SenderPolicyFrameworkRecord(pointer);
                case 249: return new TransactionKeyRecord(pointer);
                case 250: return new TransactionSignatureRecord(pointer);
                default: return default(IRecord);
            }
        }
    }
}
