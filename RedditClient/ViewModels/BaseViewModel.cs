using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RedditClient.ViewModels
{
    /// <summary>
    /// Base for other viewmodels
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Handle when the property changes it's value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Notify listeners that the value has changed
        /// </summary>
        /// <param name="propertyName">Name of the property used to notify listeners</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        /// <summary>
        /// Checks if a property already matches a desired value. Sets the property and
        /// notifies listeners only when necessary
        /// </summary>
        /// <typeparam name="T">Property type</typeparam>
        /// <param name="storage">Reference to a property with both getter and setter</param>
        /// <param name="value">New value.</param>
        /// <param name="propertyName">Name of the property used to notify listeners</param>
        /// <returns>True if the value was changed, false otherwise</returns>
        protected bool Set<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
