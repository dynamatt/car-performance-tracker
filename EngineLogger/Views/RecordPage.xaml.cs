namespace EngineLogger.Views
{
	using Xamarin.Forms;
	using ViewModels;

    public partial class RecordPage : ContentPage
    {
        public RecordPage()
        {
            InitializeComponent();

            this.BindingContext = new RecordViewModel();
        }
    }
}
