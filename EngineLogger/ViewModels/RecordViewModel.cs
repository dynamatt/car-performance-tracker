namespace EngineLogger.ViewModels
{
    using System;
    using System.Windows.Input;

    using Xamarin.Forms;

    using Obd2Interface;
    using Obd2Logger;

    using Models;
    using Utilities;

    public class RecordViewModel : BaseViewModel
    {
		public PlotViewModel PlotViewModel { get; }

        private readonly Obd2Interface obd2interface;

        private TimedPoller poller;

        public RecordViewModel()
        {
            PlotViewModel = new PlotViewModel();

            StartPauseRecording = new DelegateCommand(StartRecording, () => this.state != RecordingState.Recording);
            FinishRecording = new DelegateCommand(CompleteRecording, () => this.state == RecordingState.Paused);

            IObd2Connection connection = DependencyService.Get<IObd2Connection>();
            this.obd2interface = new Obd2Interface(connection);

        }

        private RecordingState state = RecordingState.NotStarted;
        public RecordingState State
        {
            get => state;
            set => this.SetProperty(ref state, value);
        }

        public ICommand StartPauseRecording { get; }

        public ICommand FinishRecording { get; }

        public void StartRecording()
        {
            poller = new TimedPoller(this.obd2interface, TimeSpan.FromMilliseconds(500));

            PlotViewModel.ClearSeries();

            this.AddData(QueryFactory.GetEngineRpm, "RPM");
            this.AddData(QueryFactory.GetVehicleSpeed, "Speed");

            poller.Start();
            Console.WriteLine("Recording started");
        }

        public void PauseRecording()
        {
            poller?.Stop();
            Console.WriteLine("Recording paused");
        }

        public void ResumeRecording()
        {
            poller?.Start();
            Console.WriteLine("Recording resumed");
        }

        public void CompleteRecording()
        {
            
            Console.WriteLine("Recording completed");
        }

        private void AddData<ResponseType>(Query<ResponseType> command, string name)
            where ResponseType : SimpleValueResponse, new()
        {
            var plotSeries = PlotViewModel.AddPlotSeries(name);
            poller.AddQuery(command).ResponseReceived += (sender, e) =>
            {
                plotSeries.AddPoint(DateTime.Now, e.Value);
            };
        }
    }
}
