namespace EngineLogger.ViewModels
{
    using System;
    //using OxyPlot;
    //using OxyPlot.Axes;
    //using OxyPlot.Series;

    public class PlotSeries
    {
  //      private const int MaximumNumberOfPoints = 200;
  //      private readonly PlotViewModel plotViewModel;
  //      private readonly LineSeries series;

  //      internal PlotSeries(PlotViewModel plotViewModel, LineSeries series)
  //      {
  //          this.plotViewModel = plotViewModel;
  //          this.series = series;
  //      }

		public void AddPoint(double x, double y)
		{
			//series.Points.Add(new DataPoint(x, y));
            //while (series.Points.Count > MaximumNumberOfPoints)
            //{
            //    series.Points.RemoveAt(0);
            //}
            //this.plotViewModel.Refresh();
		}

        public void AddPoint(DateTime x, double y)
        {
            //this.AddPoint(DateTimeAxis.ToDouble(x), y);
        }
    }

    public class PlotViewModel
    {
        public PlotViewModel()
        {
            //this.PlotModel = new PlotModel()
            //{
            //    Title = "Hello",
            //};
        }

        //public PlotModel PlotModel { get; }

        public void Refresh()
        {
			try
			{
				//Xamarin.Forms.Device.BeginInvokeOnMainThread(() => this.PlotModel.InvalidatePlot(true));
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception: {ex}");
			}
        }

        public void ClearSeries()
        {
            //this.PlotModel.Series.Clear();
        }

        public PlotSeries AddPlotSeries(string title=null)
        {
            //var series = new LineSeries()
            //{
            //    Title = title
            //};
            //this.PlotModel.Series.Add(series);
            //var plotSeries = new PlotSeries(this, series);

            //return plotSeries;
            throw new NotImplementedException();
        }
    }
}
