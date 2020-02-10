using System;
using Windows.UI.Xaml.Data;

namespace RedditClient.Converters
{
    /// <summary>
    /// Converts a datetimeoffset value to a formated string with
    /// the amount of hours that have passed
    /// </summary>
    public class CreatedToHoursAgoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTimeOffset created = (DateTimeOffset)value;
            var hours = (int)(DateTimeOffset.UtcNow - created).TotalHours;
            return string.Format("{0} hours ago", hours);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
