namespace EngineLogger.ViewModels
{
    using System.Windows.Input;

    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
        }

        ICommand CreateNewDataSeries { get; }
    }
}
