namespace CarPerformanceTracker
{
	using System;
    using System.Threading;
	using Obd2Interface;
    using Obd2Logger;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Obd2Connector connector = new Obd2Connector();

            Obd2Interface car = new Obd2Interface(connector);

            TimedPoller poller = new TimedPoller(car, TimeSpan.FromSeconds(1));

            poller.AddQuery(QueryFactory.GetEngineRpm).ResponseReceived += (sender, e) => PrintSimpleValueResponse(e);
            poller.AddQuery(QueryFactory.GetVehicleSpeed).ResponseReceived += (sender, e) => PrintSimpleValueResponse(e);
            poller.Start();
            Thread.Sleep(20000);
            poller.Stop();
        }

        static void PrintSimpleValueResponse(SimpleValueResponse response)
        {
            Console.WriteLine($"{response.Value} {response.Units}");
        }
    }
}
