using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class TextRecord : IRecord
    {
        public List<string> Text { get; } = new List<string>();

        internal TextRecord(Pointer pointer, int length)
        {
            int pos = pointer.Position;
            while((pointer.Position - pos) < length)
            {
                Text.Add(pointer.ReadString());
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(string text in Text)
            {
                stringBuilder.AppendFormat("\"{0}\" ", text);
            }
            return stringBuilder.ToString();
        }
    }
}
