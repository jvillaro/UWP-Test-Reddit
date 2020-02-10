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


        /// <summary>
        /// Handle the click on open image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.SelectedPost.OpenImageCommand.Execute(null);
        }


        /// <summary>
        /// Handle click on save image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveHyperlinkButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.SelectedPost.SaveImageCommand.Execute(null);
        }

        private void RefreshContainer_RefreshRequested(RefreshContainer sender, RefreshRequestedEventArgs args)
        {
            ViewModel.LoadData();
        }
    }
}
