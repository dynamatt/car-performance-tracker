namespace Obd2Interface
{
    using System.Threading;
    using System.Threading.Tasks;

    public class Obd2Interface
    {
        private readonly IObd2Connection connection;
        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public Obd2Interface(IObd2Connection connection)
        {
            this.connection = connection;
        }

        public async Task<ResponseType> SendQuery<ResponseType>(Query<ResponseType> query)
            where ResponseType : Response, new()
        {
            await semaphore.WaitAsync();
            try
            {
                return query.Send(this.connection);
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
