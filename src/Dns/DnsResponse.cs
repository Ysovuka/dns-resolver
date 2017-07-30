using Dns.Records;
using Dns.Records.Resources;
using Dns.ReturnCodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dns
{
    public class DnsResponse
    {
        internal DnsResponse()
        {

        }

        internal DnsResponse(byte[] message)
        {
            byte flags1 = message[2];
            byte flags2 = message[3];

            // get return code from lowest 4 bits of second flag.
            int returnCode = flags2 & 15;

            if (returnCode > 6) returnCode = 6;
            ReturnCode = ReturnCodePool.Find(returnCode);

            // other bit flags
            AuthoritativeAnswer = ((flags1 & 4) != 0);
            RecursionAvailable = ((flags2 & 128) != 0);
            Truncated = ((flags1 & 2) != 0);

            // create the arrays of response objects
            int questionCount = GetShort(message, 4);
            int answerCount = GetShort(message, 6);
            int nameServerCount = GetShort(message, 8);
            int additionalRecordCount = GetShort(message, 10);

            Pointer pointer = new Pointer(message, 12);

            for (int index = 0; index < questionCount; index++)
            {
                try
                {
                    Questions.Add(new DnsQuestion(pointer));
                }
                catch(Exception ex)
                {
                    throw new InvalidResponseException(ex);
                }
            }

            for (int index = 0; index < answerCount; index++)
            {
                Answers.Add(new Answer(pointer));
            }

            for (int index = 0; index < nameServerCount; index++)
            {
                NameServers.Add(new NameServer(pointer));
            }

            for (int index = 0; index < additionalRecordCount; index++)
            {
                AdditionalRecords.Add(new AdditionalRecord(pointer));
            }
        }

        internal IDnsReturnCode ReturnCode { get; }
        internal bool AuthoritativeAnswer { get; }
        internal bool RecursionAvailable { get; }
        internal bool Truncated { get; }

        internal IList<DnsQuestion> Questions { get; } = new List<DnsQuestion>();
        internal IList<Answer> Answers { get; } = new List<Answer>();
        internal IList<NameServer> NameServers { get; } = new List<NameServer>();
        internal IList<AdditionalRecord> AdditionalRecords { get; } = new List<AdditionalRecord>();

        public IEnumerable<IRecord> GetRecords()
        {
            IList<IRecord> records = new List<IRecord>();

            foreach(var answer in Answers)
            {
                records.Add(answer.Record);
            }

            return records;
        }
        public IEnumerable<TRecord> GetRecords<TRecord>()
            where TRecord : IRecord
        {
            IList<TRecord> records = new List<TRecord>();

            foreach(var answer in Answers)
            {
                if (answer.Record is TRecord)
                {
                    records.Add((TRecord)answer.Record);
                }
            }

            return records;
        }

        /// <summary>
        /// Convert 2 bytes to a short. It would have been nice to use BitConverter for this,
        /// it however reads the bytes in the wrong order (at least on Windows)
        /// </summary>
        /// <param name="message">byte array to look in</param>
        /// <param name="position">position to look at</param>
        /// <returns>short representation of the two bytes</returns>
        private short GetShort(byte[] message, int position)
        {
            return (short)(message[position] << 8 | message[position + 1]);
        }
    }
}
