namespace EngineLogger.ViewModels
{
    using System.Collections.Generic;
    using Obd2Interface;
    using Obd2Interface.Commands;

    public class LogItemListViewModel
    {
        public LogItemListViewModel()
        {
            this.LogItems = new List<LogItemSelectionViewModel>();
            this.LoadLogItemsList();
        }

        public List<LogItemSelectionViewModel> LogItems { get; }

        private void LoadLogItemsList()
        {
            this.LogItems.Add(

                new SimpleValueLogItemSelectionViewModel<GetVehicleSpeed, VehicleSpeed>
                {
                    Name = "Speed",
                    Description = "Vehicle speed in km/h",
                    Query = QueryFactory.GetVehicleSpeed
                });
            this.LogItems.Add(
                new SimpleValueLogItemSelectionViewModel<GetEngineRpm, EngineRpm>
                {
                    Name = "RPM",
                    Description = "Engine revolutions per minute",
                    Query = QueryFactory.GetEngineRpm
                });
        }
    }
}
