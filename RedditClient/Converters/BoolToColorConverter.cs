using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace RedditClient.Converters
{
    /// <summary>
    /// Converts a boolean value to a color representation value.
    /// Used for representing the post read state
    /// </summary>
    public class BoolToColorConverter : IValueConverter
    {
        /// <summary>
        /// Returns Black if value is true; otherwise, returns blue.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool read = (bool)value;
            return read ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.DodgerBlue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
