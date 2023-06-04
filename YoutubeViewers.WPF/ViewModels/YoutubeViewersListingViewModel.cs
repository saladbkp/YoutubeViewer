using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YoutubeViewers.WPF.Commands;
using YoutubeViewers.WPF.Models;
using YoutubeViewers.WPF.Stores;

namespace YoutubeViewers.WPF.ViewModels
{
    public class YoutubeViewersListingViewModel:ViewModelBase
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
        public YoutubeViewerStore _youtubeViewerStore { get; }

        public SelectedYoutubeViewerStore _selectedYoutubeViewerStore { get; }
        public ModelNavigationStore _modelNavigationStore { get; }

        public YoutubeViewersListingViewModel(YoutubeViewerStore youtubeViewerStore,SelectedYoutubeViewerStore selectedYoutubeViewerStore,ModelNavigationStore modelNavigationStore)
        {
            _youtubeViewerStore = youtubeViewerStore;
            _selectedYoutubeViewerStore = selectedYoutubeViewerStore;
            _modelNavigationStore = modelNavigationStore;
            _youtubeViewersListingItemViewModels = new ObservableCollection<YoutubeViewersListingItemViewModel>();

            _youtubeViewerStore.YoutubeViewerAdded += YoutubeViewerStore_YoutubeViewerAdded;

            AddYoutubeViewer(new YoutubeViewer("MAYE", true, true)); 
            //AddYoutubeViewer(new YoutubeViewer("MAYE", true, true), modelNavigationStore);
            //AddYoutubeViewer(new YoutubeViewer("RAYE", false, false), modelNavigationStore);
            
            _selectedYoutubeViewerStore = selectedYoutubeViewerStore;
        }
        protected override void Dispose()
        {
            _youtubeViewerStore.YoutubeViewerAdded -= YoutubeViewerStore_YoutubeViewerAdded;

            base.Dispose();
        }
        private void YoutubeViewerStore_YoutubeViewerAdded(YoutubeViewer youtubeViewer)
        {
            AddYoutubeViewer(youtubeViewer);
        }

        private void AddYoutubeViewer(YoutubeViewer youtubeViewer)
        {
            ICommand editCommand = new OpenEditYoutubeViewerCommand(youtubeViewer,_modelNavigationStore);
            _youtubeViewersListingItemViewModels.Add(new YoutubeViewersListingItemViewModel(youtubeViewer, editCommand));
        }
    }
}
