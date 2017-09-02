namespace EngineLogger
{
	using System.Collections.Generic;

	using Xamarin.Forms;

    using Services;
    using Views;

    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";

        public static IDictionary<string, string> LoginParameters => null;

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
            {
                DependencyService.Register<Mocks.MockDataStore>();
                DependencyService.Register<Mocks.MockObd2Connection>();
            }
            else
            {
                DependencyService.Register<CloudDataStore>();
                DependencyService.Register<Obd2TcpConnection>();
            }

            SetMainPage();
        }

        public static void SetMainPage()
        {
            if (!UseMockDataStore && !Settings.IsLoggedIn)
            {
                Current.MainPage = new NavigationPage(new LoginPage())
                {
                    BarBackgroundColor = (Color)Current.Resources["Primary"],
                    BarTextColor = Color.White
                };
            }
            else
            {
                GoToMainPage();
            }
        }

        public static void GoToMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children = {
					new NavigationPage(new RecordPage())
					{
						Title = "Record",
					},
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Select Data",
                        Icon = "tab_feed.png"
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = "tab_about.png"
                    },
                }
            };
        }
    }
}
