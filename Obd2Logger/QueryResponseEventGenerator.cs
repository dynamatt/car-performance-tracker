namespace Obd2Logger
{
    using System;
    using Obd2Interface;

    public abstract class QueryResponseEventGenerator
	{
		internal abstract void SendQuery();
	}

	public class QueryResponseEventGenerator<ResponseType> : QueryResponseEventGenerator
		where ResponseType : Response, new()
	{
		private readonly Query<ResponseType> query;

		private readonly Obd2Interface obd2Interface;

		internal QueryResponseEventGenerator(Obd2Interface obd2Interface, Query<ResponseType> query)
		{
			this.query = query;
			this.obd2Interface = obd2Interface;
		}

		internal override void SendQuery()
		{
			ResponseType response = obd2Interface.SendQuery(this.query);
			this.ResponseReceived?.Invoke(this, response);
		}

		public event EventHandler<ResponseType> ResponseReceived;
	}
}
