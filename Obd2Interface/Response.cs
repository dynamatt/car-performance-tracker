namespace Obd2Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public override string ToString()
        {
            return string.Format("[Response: Bytes={0}, NumberOfAdditionalDataBytes={1}, CustomMode={2}, PidCode={3}]", string.Join(",", Bytes), NumberOfAdditionalDataBytes, CustomMode, PidCode);
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

    public class TroubleCodesResponse : Response
    {
        public List<TroubleCode> TroubleCodes 
        { 
            get
            {

                return ReadTroubleCodes(this.Bytes);
            } 
        }

        private List<TroubleCode> ReadTroubleCodes(byte[] response)
        {
            var fetchedCodes = new List<TroubleCode>();

            for (int i = 1; i < response.Length-1; i += 2) // each error code got a size of 3 bytes
            {
                byte[] troubleCode = new byte[2];
                Array.Copy(response, i, troubleCode, 0, 2);

                if (!troubleCode.All(b => b == default(byte))) // if the byte array is not entirely empty, add the error code to the parsed list
                {
                    fetchedCodes.Add(new TroubleCode(troubleCode));
                }
            }

            return fetchedCodes;
        }
    }
}
