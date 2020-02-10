using RedditClient.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditClient.ViewModels
{
    /// <summary>
    /// Main page viewmodel
    /// </summary>
    public class MainPageViewModel : BaseViewModel
    {
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
            var posts = await HttpHelper.GetTop50Listings();
        }

        #endregion
    }
}
