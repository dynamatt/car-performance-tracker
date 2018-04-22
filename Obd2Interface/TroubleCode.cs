namespace Obd2Interface
{
    using System.Text;

    public enum TroubleCodeCategory : byte
    {
        Powertrain = 0b00000000,
        Chassis = 0b01000000,
        Body = 0b10000000,
        Network = 0b11000000
    }

    public enum TroubleCodeType : byte
    {
        Generic = 0b00000000,
        ManufacturerSpecific = 0b00010000,
    }

    public class TroubleCode
    {
        private readonly byte[] bytes;

        public TroubleCode(byte[] bytes)
        {
            this.bytes = bytes;
        }

        public TroubleCodeCategory Category
        {
            get
            {
                return (TroubleCodeCategory)(bytes[0] & (byte)TroubleCodeCategory.Network);
            }
        }

        public TroubleCodeType Type
        {
            get
            {
                return (TroubleCodeType)(bytes[0] & 0b00110000);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            switch (this.Category)
            {
                case TroubleCodeCategory.Powertrain:
                    sb.Append("P");
                    break;
                case TroubleCodeCategory.Chassis:
                    sb.Append("C");
                    break;
                case TroubleCodeCategory.Body:
                    sb.Append("B");
                    break;
                case TroubleCodeCategory.Network:
                    sb.Append("U");
                    break;
            }

            sb.AppendFormat("{0:X}", (bytes[0] & 0b00110000) >> 4);
            sb.AppendFormat("{0:X}", (bytes[0] & 0b00001111));
            sb.AppendFormat("{0:X}", (bytes[1] & 0b11110000) >> 4);
            sb.AppendFormat("{0:X}", (bytes[1] & 0b00001111));

            sb.Append($"Raw: {string.Join(",", bytes)}");

            return sb.ToString();
        }
    }
}
