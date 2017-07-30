using Dns.Records;
using Dns.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;

namespace Dns.UnitTests
{
    public class ExpectedBehaviour
    {
        [Fact]
        public void CorrectMxLookupForCodeProject()
        {
            DnsRequest request = new DnsRequest();
            DnsResponse response = request.Lookup<MailExchange>("codeproject.com").GetResponse();

            Assert.NotNull(response);
            Assert.Equal(7, response.GetRecords<MailExchangeRecord>().Count());
            Assert.Equal("alt1.aspmx.l.google.com", response.GetRecords<MailExchangeRecord>().OrderBy(r => r.Domain).FirstOrDefault()?.Domain);
            Assert.Equal(10, response.GetRecords<MailExchangeRecord>().OrderBy(r => r.Preference).FirstOrDefault()?.Preference);
        }

        [Fact]
        public void CorrectIpv4AddressForCodeProject()
        {
            DnsRequest request = new DnsRequest();
            DnsResponse response = request.Lookup<IPv4Address>("codeproject.com").GetResponse();

            Assert.NotNull(response);
            Assert.Equal(1, response.GetRecords<IPv4AddressRecord>().Count());
            Assert.Equal(IPAddress.Parse("76.74.234.210"), response.GetRecords<IPv4AddressRecord>().FirstOrDefault()?.IPAddress);
        }

        [Fact]
        public void CorrectNameServerForCodeProject()
        {
            DnsRequest request = new DnsRequest();
            DnsResponse response = request.Lookup<NameServer>("codeproject.com").GetResponse();

            Assert.NotNull(response);
            Assert.Equal(4, response.GetRecords<NameServerRecord>().Count());
            Assert.Equal("ns1.easydns.com", response.GetRecords<NameServerRecord>().OrderBy(r => r.Domain).FirstOrDefault()?.Domain);
        }
    }
}
