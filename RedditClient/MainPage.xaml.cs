using RedditClient.ViewModels;
using Windows.UI.Xaml.Controls;

namespace RedditClient
{
    /// <summary>
    /// App's main page.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPageViewModel ViewModel { get; set; }


        /// <summary>
        /// Constructor
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();

            ViewModel = new MainPageViewModel();
        }
    }
}
