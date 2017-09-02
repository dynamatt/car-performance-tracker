namespace Obd2Logger
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Obd2Interface;

    public abstract class Poller
    {
        private readonly Obd2Interface obd2Interface;

        private readonly List<QueryResponseEventGenerator> queries = new List<QueryResponseEventGenerator>();

        public Poller(Obd2Interface obd2Interface)
        {
            this.obd2Interface = obd2Interface;
        }

        public QueryResponseEventGenerator<ResponseType> AddQuery<ResponseType>(Query<ResponseType> query)
            where ResponseType : Response, new()
        {
            var queryResponseEventGenerator = new QueryResponseEventGenerator<ResponseType>(this.obd2Interface, query);

            this.queries.Add(queryResponseEventGenerator);

            return queryResponseEventGenerator;
        }

        public bool RemoveQuery(QueryResponseEventGenerator query)
        {
            return this.queries.Remove(query);
        }

        protected void SendAllQueries()
        {
            foreach (QueryResponseEventGenerator query in this.queries)
            {
                query.SendQuery();
            }
        }
    }

    public class TimedPoller : Poller
    {
        private readonly Timer timer;

        private readonly TimeSpan period;

        private readonly SemaphoreSlim semaphore;

        public TimedPoller(Obd2Interface obd2Interface, TimeSpan period)
            : base(obd2Interface)
        {
            this.period = period;
            this.timer = new Timer(s => this.SendQueries(), null, Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
            this.semaphore = new SemaphoreSlim(1);
        }

        public void Start()
        {
            this.timer.Change(TimeSpan.Zero, this.period);
        }

        public void Stop()
        {
            this.timer.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
        }

        private void SendQueries()
        {
            if (this.semaphore.CurrentCount < 1)
            {
                return;
            }
            this.semaphore.Wait();
            this.SendAllQueries();
            this.semaphore.Release();
        }
    }
}
