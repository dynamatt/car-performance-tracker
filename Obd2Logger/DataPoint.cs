﻿namespace Obd2Logger
{
    using System;

    public class DataPoint
    {
        public DataPoint()
        {
        }

        public DateTime Timestamp { get; set; }

        public double Value { get; set; }
    }
}
