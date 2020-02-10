using RedditClient.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Input;

namespace RedditClient.ViewModels
{
    /// <summary>
    /// Main page viewmodel
    /// </summary>
    public class MainPageViewModel : BaseViewModel
    {
        #region --- Variables ---

        private ObservableCollection<RedditPostViewModel> posts;
        private RedditPostViewModel selectedPost;

        #endregion


        #region --- Properties ---

        public bool ShowPostContent { get; set; }

        public ICommand RefreshCommand { get; set; }

        public ICommand DismissAllCommand { get; set; }

        /// <summary>
        /// Reddit posts collection
        /// </summary>
        public ObservableCollection<RedditPostViewModel> Posts
        {
            get => posts;
            set
            {
                Set(ref posts, value);
            }
        }


        /// <summary>
        /// Selected post
        /// </summary>
        public RedditPostViewModel SelectedPost
        {
            get => selectedPost;
            set
            {
                if (Set(ref selectedPost, value))
                {
                    selectedPost = value;
                    selectedPost.Read = true;
                    ShowPostContent = true;
                    OnPropertyChanged(nameof(Posts));
                    OnPropertyChanged(nameof(SelectedPost));
                    OnPropertyChanged(nameof(ShowPostContent));
                }
            }
        }

        #endregion


        #region --- Commands ---

        /// <summary>
        /// Command for handling the dismissal of a post
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void DismissCommand_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
        {
            if (args.Parameter != null)
            {
                try
                {
                    SelectedPost = null;

                    var id = (string)args.Parameter;
                    Posts.Remove(Posts.FirstOrDefault(x => x.Id == id));

                    OnPropertyChanged(nameof(Posts));
                    OnPropertyChanged(nameof(SelectedPost));

                    if (!Posts.Any())
                    {
                        ShowPostContent = false;
                        OnPropertyChanged(nameof(ShowPostContent));
                    }
                }
                catch (Exception)
                {
                    // Todo: implement error handling
                }
            }
        }


        /// <summary>
        /// Command for handling the dismissal of all posts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void DismissAllCommand_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
        {
            try
            {
                SelectedPost = null;
                OnPropertyChanged(nameof(SelectedPost));

                while (Posts.Count > 0)
                {
                    Posts.Remove(Posts.Last());
                }
                OnPropertyChanged(nameof(Posts));

                ShowPostContent = false;
                OnPropertyChanged(nameof(ShowPostContent));

            }
            catch (Exception ex)
            {
                // Todo: implement error handling
            }
        }


        /// <summary>
        /// Command for handling the refresh of posts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void RefreshCommand_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                // Todo: implement error handling
            }
        }


        /// <summary>
        /// Handle opening the full image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OpenImageCommand_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
        {
            try
            {
                if (args.Parameter != null)
                {
                    var uri = new Uri((string)args.Parameter);
                    Task.Run(async () => await Windows.System.Launcher.LaunchUriAsync(uri));
                }
            }
            catch (Exception ex)
            {
                // Todo: implement error handling
                throw;
            }
        }


        /// <summary>
        /// Handle saving the full image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void SaveImageCommand_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
        {
            try
            {
                if (args.Parameter != null)
                {

                }
            }
            catch (Exception ex)
            {
                // Todo: implement error handling
                throw;
            }
        }

        #endregion


        #region --- Constructor ---

        /// <summary>
        /// Constructor
        /// </summary>
        public MainPageViewModel()
        {
            // Create the dismiss all command
            var dismissAllCommand = new XamlUICommand();
            dismissAllCommand.ExecuteRequested += DismissAllCommand_ExecuteRequested;
            DismissAllCommand = dismissAllCommand;

            // Create the refresh command
            var refreshCommand = new XamlUICommand();
            refreshCommand.ExecuteRequested += RefreshCommand_ExecuteRequested;
            RefreshCommand = refreshCommand;

            LoadData(); // Todo: make this really async
        }

        #endregion


        #region --- LoadData ---

        /// <summary>
        /// Load data through an API call
        /// </summary>
        /// <returns></returns>
        public async Task LoadData()
        {
            // Create commands
            var dismissCommand = new XamlUICommand();
            dismissCommand.ExecuteRequested += DismissCommand_ExecuteRequested;

            var openImageCommand = new XamlUICommand();
            openImageCommand.ExecuteRequested += OpenImageCommand_ExecuteRequested;

            var saveImageCommand = new XamlUICommand();
            saveImageCommand.ExecuteRequested += SaveImageCommand_ExecuteRequested;

            // Get listings
            var listings = await HttpHelper.GetTop50Listings();

            // Create collection of posts with additional properties
            var posts = new ObservableCollection<RedditPostViewModel>();
            foreach (var post in listings)
            {
                posts.Add(new RedditPostViewModel
                {
                    Id = post.Id,
                    Author = post.Author,
                    Title = post.Title,
                    CommentsCount = post.CommentsCount,
                    Created = post.Created,
                    Thumbnail = post.Thumbnail,
                    Url = post.Url,
                    Read = false,
                    CreatedUtc = DateTimeOffset.FromUnixTimeSeconds(post.Created),
                    DismissCommand = dismissCommand,
                    OpenImageCommand = openImageCommand,
                    SaveImageCommand = saveImageCommand
                });
            }

            Posts = posts;
        }

        #endregion
    }
}
