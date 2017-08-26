namespace Obd2Interface.Commands
{
    public class EngineRpm : SimpleValueResponse
    {
        public override double Value
        {
            get { return (256 * this.Bytes[3] + this.Bytes[4]) / 4.0; }
        }

        public override string Units { get { return "rpm"; } }
    }

    public class GetEngineRpm : ShowCurrentDataQuery<EngineRpm>
    {
        public override byte PidCode => (byte)StandardPids.EngineRPM;
    }

    public class VehicleSpeed : SimpleValueResponse
    {
        public override double Value
        {
            get { return this.Bytes[3]; }
        }

        public override string Units { get { return "km/h"; } }
    }

    public class GetVehicleSpeed : ShowCurrentDataQuery<VehicleSpeed>
    {
        public override byte PidCode => (byte)StandardPids.VehicleSpeed;
    }
}