namespace EngineLogger.Mocks
{
    using System;
    using Obd2Interface;

    public class MockObd2Connection : IObd2Connection
    {
        public byte[] Read(int count)
        {
            var bytes = new byte[count];
            var rand = new Random();
            rand.NextBytes(bytes);
            return bytes;
        }

        public void Write(byte[] bytes)
        {
            // do nothing
        }
    }
}
