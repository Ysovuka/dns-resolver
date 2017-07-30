using Dns.Classes;
using Dns.Types;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Dns
{
    public class DnsRequest
    {
        private const int DNSPORT = 53;
        private const int RETRYATTEMPTS = 2;
        private static int _uniqueId;
        private readonly IPAddress dnsServer;
        private DnsResponse _response = new DnsResponse();

        public DnsRequest(string ipAddress = "8.8.8.8")
        {
            try
            {
                dnsServer = IPAddress.Parse(ipAddress);
            }
            catch
            {
                dnsServer = IPAddress.Parse("8.8.8.8");
            }
        }

        public DnsResponse Lookup(string domain)
        {
            if (string.IsNullOrEmpty(domain)) throw new ArgumentNullException(nameof(domain));

            Lookup<MailExchange>(domain)
                .Lookup<IPv4Address>(domain)
                .Lookup<IPv6HostAddress>(domain)
                .Lookup<NameServer>(domain)
                .Lookup<CanonicalName>(domain)
                .Lookup<Text>(domain)
                .Lookup<StateOfAuthority>(domain);

            return _response;
        }
        
        private DnsResponse Lookup(DnsQuestion question, IPAddress dnsServer)
        {
            if (question == null) throw new ArgumentNullException(nameof(question));

            IPEndPoint server = new IPEndPoint(dnsServer, DNSPORT);

            return new DnsResponse(UdpTransfer(server, question.GetMessage()));
        }

        private static byte[] UdpTransfer(IPEndPoint server, byte[] message)
        {
            // UDP can fail - if it does try again keeping track of how many attempts we've made
            int attempts = 0;

            // try repeatedly in case of failure
            while (attempts <= RETRYATTEMPTS)
            {
                // firstly, uniquely mark this request with an id
                unchecked
                {
                    // substitute in an id unique to this lookup, the request has no idea about this
                    message[0] = (byte)(_uniqueId >> 8);
                    message[1] = (byte)_uniqueId;
                }

                // we'll be send and receiving a UDP packet
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // we will wait at most 1 second for a dns reply
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1000);

                // send it off to the server
                socket.SendTo(message, message.Length, SocketFlags.None, server);

                // RFC1035 states that the maximum size of a UDP datagram is 512 octets (bytes)
                byte[] responseMessage = new byte[512];

                try
                {
                    // wait for a response upto 1 second
                    socket.Receive(responseMessage);

                    // make sure the message returned is ours
                    if (responseMessage[0] == message[0] && responseMessage[1] == message[1])
                    {
                        // its a valid response - return it, this is our successful exit point
                        return responseMessage;
                    }
                }
                catch (SocketException)
                {
                    // failure - we better try again, but remember how many attempts
                    attempts++;
                }
                finally
                {
                    // increase the unique id
                    _uniqueId++;

                    // close the socket
                    socket.Dispose();
                }
            }

            // the operation has failed, this is our unsuccessful exit point
            throw new NoResponseException();
        }

        public DnsRequest Lookup<TDnsType>(string domain)
            where TDnsType : IDnsType
        {
            DnsQuestion question = new DnsQuestion(domain, TypePool.Find<TDnsType>(), ClassPool.Find<Internet>());
            var response = Lookup(question, dnsServer);
            MergeResponses(_response, response);

            return this;
        }

        public DnsResponse GetResponse()
        {
            DnsResponse response = new DnsResponse();
            MergeResponses(response, _response);
            _response = new DnsResponse();
            return response;
        }

        private void MergeResponses(DnsResponse left, DnsResponse right)
        {
            foreach(var answer in right.Answers)
            {
                left.Answers.Add(answer);
            }

            foreach(var nameServer in right.NameServers)
            {
                left.NameServers.Add(nameServer);
            }

            foreach(var additionalRecord in right.AdditionalRecords)
            {
                left.AdditionalRecords.Add(additionalRecord);
            }
        }
    }
}
