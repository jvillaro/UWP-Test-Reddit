using RedditClient.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

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
                    OnPropertyChanged(nameof(Posts));
                    OnPropertyChanged(nameof(SelectedPost));
                }
            }
        }

        #endregion


        #region --- Constructor ---

        /// <summary>
        /// Constructor
        /// </summary>
        public MainPageViewModel()
        {
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
            var listings = await HttpHelper.GetTop50Listings();

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
                    CreatedUtc = DateTimeOffset.FromUnixTimeSeconds(post.Created)
                });
            }

            Posts = posts;
        }

        #endregion
    }
}
