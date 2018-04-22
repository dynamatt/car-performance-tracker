namespace EngineLogger.ViewModels
{
    using System;
    using System.Windows.Input;

    using Obd2Interface;
    using Obd2Logger;

    using Prism.Commands;
    using Prism.Mvvm;

    public class RecordViewModel : BindableBase
    {
		public PlotViewModel PlotViewModel { get; }

        private readonly Obd2Interface obd2interface;

        private TimedPoller poller;

        public RecordViewModel(IObd2Connection connection)
        {
            PlotViewModel = new PlotViewModel();

            Start = new DelegateCommand(StartRecording, () => this.state == RecordingState.NotStarted).ObservesProperty(() => State);
            Pause = new DelegateCommand(PauseRecording, () => this.state == RecordingState.Recording).ObservesProperty(() => State);
            Resume = new DelegateCommand(ResumeRecording, () => this.state == RecordingState.Paused).ObservesProperty(() => State);
            Finish = new DelegateCommand(CompleteRecording, () => this.state == RecordingState.Paused).ObservesProperty(() => State);

            this.obd2interface = new Obd2Interface(connection);

        }

        private RecordingState state = RecordingState.NotStarted;
        public RecordingState State
        {
            get => state;
            set => this.SetProperty(ref state, value);
        }

        public ICommand Start { get; }
        public ICommand Pause { get; }
        public ICommand Resume { get; }
        public ICommand Finish { get; }

        public void StartRecording()
        {
            poller = new TimedPoller(this.obd2interface, TimeSpan.FromMilliseconds(500));

            PlotViewModel.ClearSeries();

            this.AddData(QueryFactory.GetEngineRpm, "RPM");
            this.AddData(QueryFactory.GetVehicleSpeed, "Speed");

            poller.Start();

            this.State = RecordingState.Recording;
            Console.WriteLine("Recording started");
        }

        public void PauseRecording()
        {
            poller?.Stop();

            this.State = RecordingState.Paused;
            Console.WriteLine("Recording paused");
        }

        public void ResumeRecording()
        {
            poller?.Start();

            this.State = RecordingState.Recording;
            Console.WriteLine("Recording resumed");
        }

        public void CompleteRecording()
        {

            this.State = RecordingState.Finished;
            Console.WriteLine("Recording completed");

            this.State = RecordingState.NotStarted;
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
