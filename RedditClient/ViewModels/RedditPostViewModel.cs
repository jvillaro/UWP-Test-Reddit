using System;
using System.Windows.Input;

namespace RedditClient.ViewModels
{
    /// <summary>
    /// Viewmodel representing a reddit post 
    /// </summary>
    public class RedditPostViewModel : BaseViewModel
    {
        private bool read;

        /// <summary>
        /// Post ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Post title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Post author
        /// </summary>
        public string Author { get; set; }
        
        /// <summary>
        /// Number of comments
        /// </summary>
        public int CommentsCount { get; set; }

        /// <summary>
        /// Thumbnail URL
        /// </summary>
        public string Thumbnail { get; set; }

        /// <summary>
        /// Full image URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Creation date in Unix format
        /// </summary>
        public long Created { get; set; }

        /// <summary>
        /// Creation date in UTC format
        /// </summary>
        public DateTimeOffset CreatedUtc { get; set; }

        /// <summary>
        /// Indicates if the post was read or not
        /// </summary>
        public bool Read { get { return read; } set { Set(ref read, value); } }

        /// <summary>
        /// Returns a formated string with the amount of comments
        /// </summary>
        public string Comments => $"{CommentsCount} comments";// string.Format("{0} comments", CommentsCount);
    }
}
