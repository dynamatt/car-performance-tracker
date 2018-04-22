namespace EngineLogger.Views
{
	using Xamarin.Forms;
	using ViewModels;
    using Obd2Interface;

    public partial class RecordPage : ContentPage
    {
        public RecordPage()
        {
            InitializeComponent();

            this.BindingContext = new RecordViewModel(DependencyService.Get<IObd2Connection>());
        }
    }
}
