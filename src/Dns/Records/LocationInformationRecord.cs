using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class LocationInformationRecord : IRecord
    {
        public byte Version { get; }
        public byte Size { get; }
        public byte HorizontalPrecision { get; }
        public byte VerticalPrecision { get; }
        public int Latitude { get; }
        public int Longitude { get; }
        public int Altitude { get; }

        internal LocationInformationRecord(Pointer pointer)
        {
            Version = pointer.ReadByte();
            Size = pointer.ReadByte();
            HorizontalPrecision = pointer.ReadByte();
            VerticalPrecision = pointer.ReadByte();
            Latitude = pointer.ReadInt();
            Longitude = pointer.ReadInt();
            Altitude = pointer.ReadInt();
        }

        public override string ToString()
        {
            return $@"Latitude: {ToTime((uint)Latitude, 'S',  'N')}
Longitude: {ToTime((uint)Longitude, 'W', 'E')}
Altitude: {ToAltitude((uint)Altitude)}
Size: {SizeToString(Size)}
Horizontal Precision: {SizeToString(HorizontalPrecision)}
Vertical Precision: {SizeToString(VerticalPrecision)}";
        }

        private string ToTime(uint reading, char below, char above)
        {
            uint mid = 2147483648;
            char direction = '?';
            if (reading > mid)
            {
                direction = above;
                reading -= mid;
            }
            else
            {
                direction = below;
                reading = mid - reading;
            }
            double hour = reading / (360000.0 * 10.0);
            double minute = 60.0 * (hour - (int)hour);
            double second = 60.0 * (minute - (int)minute);
            return string.Format("{0} {1} {2:0.000} {3}", (int)hour, (int)minute, second, direction);
        }

        private string ToAltitude(uint altitude)
        {
            double alt = (altitude / 100.0) - 100000.00;
            return string.Format("{0:0.00}m", alt);
        }

        private string SizeToString(byte s)
        {
            string unit = "cm";
            int @base = s >> 4;
            int power = s & 0x0f;
            if (power >= 2)
            {
                power -= 2;
                unit = "m";
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("{0}", @base);
            for(; power > 0; power--)
            {
                stringBuilder.Append('0');
            }
            stringBuilder.Append(unit);
            return stringBuilder.ToString();
        }
    }
}
