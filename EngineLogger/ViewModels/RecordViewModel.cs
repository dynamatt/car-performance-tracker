namespace EngineLogger.ViewModels
{
    using System;
    using System.Windows.Input;

    using Utilities;
    using System.Timers;

    using OxyPlot;

    public class RecordViewModel : BaseViewModel
    {
		public PlotViewModel PlotViewModel { get; }

        private readonly Timer timer;

        public RecordViewModel()
        {
            PlotViewModel = new PlotViewModel();

            StartPauseRecording = new DelegateCommand(StartRecording);

            this.timer = new Timer(500);
            timer.AutoReset = false;
			timer.Elapsed += (sender, e) =>
			{
				this.PlotViewModel.AddPoint(DateTime.Now.Second, DateTime.Now.Millisecond - DateTime.Now.Second);
                timer.Start();
			};

        }

        public ICommand StartPauseRecording { get; }

        public ICommand FinishRecording { get; }

        public void StartRecording()
        {
            timer.Start();
            Console.WriteLine("Recording started");
        }

        public void StopRecording()
        {
            timer.Stop();
            Console.WriteLine("Recording stopped");
        }
    }
}
