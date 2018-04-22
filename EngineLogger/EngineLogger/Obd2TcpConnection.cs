namespace EngineLogger.Services
{
    using System;
    using System.Net;
	using System.Net.Sockets;
    using Obd2Interface;

    public class Obd2TcpConnection : IObd2Connection, IDisposable
    {
		private readonly TcpClient tcpClient;

		public Obd2TcpConnection()
		{
			this.tcpClient = new TcpClient();
			IPAddress ipAddress = new IPAddress(new byte[] { 192, 168, 0, 10 });
			this.tcpClient.Client.Connect(ipAddress, 35000);
		}

		public void Dispose()
		{
			this.tcpClient.Dispose();
		}

		public void Write(byte[] bytes)
		{
			NetworkStream stream = this.tcpClient.GetStream();
			stream.Write(bytes, 0, bytes.Length);
		}

		public byte[] Read(int count)
		{
			NetworkStream stream = this.tcpClient.GetStream();
			byte[] buffer = new byte[count];
			stream.Read(buffer, 0, count);
			return buffer;
		}
    }
}
