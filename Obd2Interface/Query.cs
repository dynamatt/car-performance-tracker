namespace Obd2Interface
{
    using System.Diagnostics;

    /// <summary>
    /// An abstract class for an SAE Standard query.
    /// </summary>
    public abstract class Query<ResponseType>
        where ResponseType : Response, new()
    {
        private const int QueryNumberOfBytes = 8;

        private const byte NumberOfAdditionalDataBytes = 2;

        public abstract Mode Mode { get; }

        public abstract byte PidCode { get; }

        protected byte[] ToBytes()
        {
            byte[] bytes = new byte[QueryNumberOfBytes];
            bytes[0] = NumberOfAdditionalDataBytes;
            bytes[1] = (byte)Mode;
            bytes[2] = PidCode;

            return bytes;
        }

		public ResponseType Send(IObd2Connection connection)
		{
			byte[] query = this.ToBytes();
			connection.Write(query);

			byte[] response = connection.Read(Response.ResponseNumberOfBytes);
			ResponseType r = new ResponseType();
			r.Bytes = response;

            if (r.NumberOfAdditionalDataBytes != 0)
            {
                Debug.WriteLine("Need to read more bytes");
            }

			return r;
		}
    }

    public abstract class ShowCurrentDataQuery<ResponseType> : Query<ResponseType>
        where ResponseType : Response, new()
    {
        public override Mode Mode
        {
            get { return Mode.ShowCurrentData; }
        }
    }

    public class GetStoredTroubleCodesQuery : Query<TroubleCodesResponse>
    {
        public override Mode Mode
        {
            get { return Mode.ShowStoredDiagnosticTroubleCodes; }
        }

        /// <remarks>
        /// No PID code required.
        /// </remarks>
        public override byte PidCode
        {
            get { return 0; }
        }
    }

    public class GetPendingTroubleCodesQuery : Query<TroubleCodesResponse>
    {
        public override Mode Mode
        {
            get { return Mode.ShowPendingDiagnosticTroubleCodes; }
        }

        /// <remarks>
        /// No PID code required.
        /// </remarks>
        public override byte PidCode
        {
            get { return 0; }
        }
    }

    public class GetPermanentTroubleCodesQuery : Query<TroubleCodesResponse>
    {
        public override Mode Mode
        {
            get { return Mode.PermanentDiagnosticTroubleCodes; }
        }

        /// <remarks>
        /// No PID code required.
        /// </remarks>
        public override byte PidCode
        {
            get { return 0; }
        }
    }
}
