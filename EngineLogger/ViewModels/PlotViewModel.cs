namespace EngineLogger.ViewModels
{
    using System;
    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.Series;

    public class PlotViewModel
    {
        private readonly LineSeries series;

        public PlotViewModel()
        {
            this.PlotModel = new PlotModel()
            {
                Title = "Hello",
            };

            series = new LineSeries();
            this.PlotModel.Series.Add(series);
        }

        public PlotModel PlotModel { get; }

        public void AddPoint(double x, double y)
        {
            series.Points.Add(new DataPoint(x, y));
            try
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => this.PlotModel.InvalidatePlot(true));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }

            Console.WriteLine("Point added");
        }
    }
}
