namespace Obd2Interface
{
    public interface IObd2Connection
    {
        void Write(byte[] bytes);

        byte[] Read(int count);
    }
}
