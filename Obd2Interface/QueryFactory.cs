namespace Obd2Interface
{
    using Commands;

    public static class QueryFactory
    {
        public static GetEngineRpm GetEngineRpm => new GetEngineRpm();

        public static GetVehicleSpeed GetVehicleSpeed => new GetVehicleSpeed();
    }
}
