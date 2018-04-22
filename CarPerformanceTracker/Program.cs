namespace CarPerformanceTracker
{
	using System;
    using System.Threading.Tasks;
	using Obd2Interface;
    using Obd2Logger;
    using Utilities;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Obd2Connector connector = new Obd2Connector();

            Obd2Interface car = new Obd2Interface(connector);


            //await TroubleCodes(car);
            Terminal(connector);


            //TimedPoller poller = new TimedPoller(car, TimeSpan.FromSeconds(1));

            //poller.AddQuery(QueryFactory.GetEngineRpm).ResponseReceived += (sender, e) => PrintSimpleValueResponse(e);
            //poller.AddQuery(QueryFactory.GetVehicleSpeed).ResponseReceived += (sender, e) => PrintSimpleValueResponse(e);
            //poller.Start();
            //Thread.Sleep(20000);
            //poller.Stop();
        }

        static void PrintSimpleValueResponse(SimpleValueResponse response)
        {
            Console.WriteLine($"{response.Value} {response.Units}");
        }

        static async Task TroubleCodes(Obd2Interface car)
        {
            do
            {

                Console.WriteLine("Stored trouble codes:");
                var codes = await car.SendQuery(QueryFactory.GetStoredDiagnosticTroubleCodes);
                foreach (var code in codes.TroubleCodes)
                {
                    Console.WriteLine(code);
                }

                Console.WriteLine("Pending trouble codes:");
                codes = await car.SendQuery(QueryFactory.GetPendingDiagnosticTroubleCodes);
                foreach (var code in codes.TroubleCodes)
                {
                    Console.WriteLine(code);
                }

                Console.WriteLine("Permanent trouble codes:");
                codes = await car.SendQuery(QueryFactory.GetPermanentDiagnosticTroubleCodes);
                foreach (var code in codes.TroubleCodes)
                {
                    Console.WriteLine(code);
                }

                var rpm = await car.SendQuery(QueryFactory.GetEngineRpm);
                Console.WriteLine($"RPM: {rpm.Value}");

                var speed = await car.SendQuery(QueryFactory.GetVehicleSpeed);
                Console.WriteLine($"Speed: {speed.Value}");


                Console.WriteLine("Press ESC to quit, any other key to continue.");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        static void Terminal(Obd2Connector connection)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            while(!string.IsNullOrEmpty(input))
            {
                byte[] bytes;
                //if (input.Substring(0, 2) == "AT")
                {
                    bytes = System.Text.Encoding.ASCII.GetBytes(input + "\n");
                }
                //else
                //{
                //    bytes = StringExtensions.ConvertHexStringToByteArray(input);
                //}

                connection.Write(bytes);

                bytes = connection.Read();
                Console.WriteLine(System.Text.Encoding.ASCII.GetString(bytes));
                Console.WriteLine(string.Join(",", bytes));

                Console.Write("> ");
                input = Console.ReadLine();
            }
        }


    }
}
