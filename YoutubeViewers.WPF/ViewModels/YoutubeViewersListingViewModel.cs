using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeViewers.WPF.Models;
using YoutubeViewers.WPF.Stores;

namespace YoutubeViewers.WPF.ViewModels
{
    class YoutubeViewersListingViewModel:ViewModelBase
    {
        private readonly ObservableCollection<YoutubeViewersListingItemViewModel> _youtubeViewersListingItemViewModels;
        public IEnumerable<YoutubeViewersListingItemViewModel> YoutubeViewersListingItemViewModels => _youtubeViewersListingItemViewModels.ToList();
        
        private YoutubeViewersListingItemViewModel _selectedYoutubeViewerListingItemViewModel;
        public YoutubeViewersListingItemViewModel SelectedYoutubeViewerListingItemViewModel
        {
            get { return _selectedYoutubeViewerListingItemViewModel; }
            set
            {
                _selectedYoutubeViewerListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedYoutubeViewerListingItemViewModel));

                _selectedYoutubeViewerStore.SelectedYoutubeViewer = _selectedYoutubeViewerListingItemViewModel?.YoutubeViewer;
            }
        }

        public SelectedYoutubeViewerStore _selectedYoutubeViewerStore { get; }

        public YoutubeViewersListingViewModel(SelectedYoutubeViewerStore selectedYoutubeViewerStore)
        {
            _youtubeViewersListingItemViewModels = new ObservableCollection<YoutubeViewersListingItemViewModel>();

            _youtubeViewersListingItemViewModels.Add(new YoutubeViewersListingItemViewModel(new YoutubeViewer("SEAN",true,false)));
            _youtubeViewersListingItemViewModels.Add(new YoutubeViewersListingItemViewModel(new YoutubeViewer("MARY", false, false)));
            _youtubeViewersListingItemViewModels.Add(new YoutubeViewersListingItemViewModel(new YoutubeViewer("LAAN", true, false)));
            _selectedYoutubeViewerStore = selectedYoutubeViewerStore;
        }
    }
}
