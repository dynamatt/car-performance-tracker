using System;
using System.Collections.Generic;

namespace Obd2Logger
{
    public interface ILoggingSession
    {
        DataSeries AddDataSeries();

        DataSeries this[string key] { get; }

        IEnumerable<string> GetDataSeriesNames();
    }

    public interface IDataStorage
    {
        ILoggingSession CreateNewLoggingSession(string name);

        ILoggingSession RetrieveLoggingSession(string name);

        IEnumerable<string> GetStoredLoggingSessionNames();
    }
}
