using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YoutubeViewers.WPF.Commands;
using YoutubeViewers.WPF.Stores;

namespace YoutubeViewers.WPF.ViewModels
{
    public class YoutubeViewersViewModel:ViewModelBase
    {
        public YoutubeViewersListingViewModel YoutubeViewersListingViewModel { get;}
        public YoutubeViewersDetailsViewModel YoutubeViewersDetailsViewModel { get;}

        public ICommand AddYoutubeViewersCommand { get; }
        public YoutubeViewersViewModel(YoutubeViewerStore youtubeViewerStore,SelectedYoutubeViewerStore _selectedYoutubeViewerStore,ModelNavigationStore modelNavigationStore) 
        {
            YoutubeViewersListingViewModel = new YoutubeViewersListingViewModel(youtubeViewerStore,_selectedYoutubeViewerStore,modelNavigationStore);
            YoutubeViewersDetailsViewModel = new YoutubeViewersDetailsViewModel(_selectedYoutubeViewerStore);

            AddYoutubeViewersCommand = new OpenAddYoutubeViewerCommand(youtubeViewerStore,modelNavigationStore);
        }

    }
}
