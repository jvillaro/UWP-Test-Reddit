using Windows.UI.Xaml;

namespace RedditClient.Converters
{
    /// <summary>
    /// Converts a boolean value to a visibility value
    /// </summary>
    public static class BoolToVisibilityConverter
    {
        /// <summary>
        /// Returns Visibility.Collapsed if value is true; otherwise, returns Visibility.Visible.
        /// </summary>
        public static Visibility Collapsed(bool value) =>
            value ? Visibility.Collapsed : Visibility.Visible;

        /// <summary>
        /// Returns Visibility.Visible if value is true; otherwise, returns Visibility.Collapsed.
        /// </summary>
        public static Visibility Visible(bool value) =>
            value ? Visibility.Visible : Visibility.Collapsed;
    }
}
