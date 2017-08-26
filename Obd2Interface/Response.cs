namespace Obd2Interface
{
    /// <summary>
    /// An abstract class for the SAE Standard response.
    /// </summary>
    public abstract class Response
    {
        public const int ResponseNumberOfBytes = 8;

        public byte[] Bytes { get; internal set; }

        public byte NumberOfAdditionalDataBytes
        {
            get
            {
                return this.Bytes[0];
            }
        }

        public byte CustomMode
        {
            get 
            { 
                return this.Bytes[1]; 
            }
        }

        public byte PidCode
        {
            get
            {
                return this.Bytes[2];
            }
        }
    }

    public abstract class SimpleValueResponse : Response
    {
        public abstract double Value { get; }

        public abstract string Units { get; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Value, Units);
        }
    }
}
