namespace Obd2Interface
{
    public class Obd2Interface
    {
        private readonly IObd2Connection connection;

        public Obd2Interface(IObd2Connection connection)
        {
            this.connection = connection;
        }

        public ResponseType SendQuery<ResponseType>(Query<ResponseType> query)
            where ResponseType : Response, new()
        {
            return query.Send(this.connection);
        }
    }
}
