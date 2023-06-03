using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeViewers.WPF.Models;
using YoutubeViewers.WPF.Stores;

namespace YoutubeViewers.WPF.ViewModels
{
    class YoutubeViewersDetailsViewModel:ViewModelBase
    {
        private readonly SelectedYoutubeViewerStore _selectedYoutubeViewerStore;
        private YoutubeViewer SelectedYoutubeViewer => _selectedYoutubeViewerStore.SelectedYoutubeViewer;
        public bool HasSelectedYouTubeViewer => SelectedYoutubeViewer != null;
        public string Username => _selectedYoutubeViewerStore.SelectedYoutubeViewer?.Username ?? "Unknown";
        public string IsSubscribedDisplay => (SelectedYoutubeViewer?.IsSubscribed ?? false) ? "Yes" : "No";
        public string IsMemberDisplay => (SelectedYoutubeViewer?.IsMember ?? false) ? "Yes" : "No";
        
        public YoutubeViewersDetailsViewModel(SelectedYoutubeViewerStore selectedYoutubeViewerStore) 
        {
            _selectedYoutubeViewerStore = selectedYoutubeViewerStore;
            _selectedYoutubeViewerStore.SelectedYoutubeViewerChanged += SelectedYoutubeViewerStore_SelectedYoutubeViewerChanged;
        }

        protected override void Dispose()
        {
            _selectedYoutubeViewerStore.SelectedYoutubeViewerChanged -= SelectedYoutubeViewerStore_SelectedYoutubeViewerChanged;

            base.Dispose();
        }

        private void SelectedYoutubeViewerStore_SelectedYoutubeViewerChanged()
        {
            OnPropertyChanged(nameof(HasSelectedYouTubeViewer));
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(IsSubscribedDisplay));
            OnPropertyChanged(nameof(IsMemberDisplay));

        }
    }
}
