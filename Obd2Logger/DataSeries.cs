namespace Obd2Logger
{
    using System.Collections.Generic;

    public class DataSeries
    {
        public DataSeries()
        {
        }

        public string Description { get; }

        public List<DataPoint> Data { get; }
    }
}
