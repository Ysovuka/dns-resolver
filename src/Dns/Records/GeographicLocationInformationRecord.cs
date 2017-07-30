using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class GeographicLocationInformationRecord : IRecord
    {
        public string Longitude { get; }
        public string Latitude { get; }
        public string Altitude { get; }

        internal GeographicLocationInformationRecord(Pointer pointer)
        {
            Longitude = pointer.ReadString();
            Latitude = pointer.ReadString();
            Altitude = pointer.ReadString();
        }

        public override string ToString()
        {
            return $@"Longitude: {Longitude}
Latitude: {Latitude}
Altitude: {Altitude}";
        }
    }
}
