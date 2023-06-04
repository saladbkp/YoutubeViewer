using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeViewers.WPF.Stores;

namespace YoutubeViewers.WPF.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private readonly ModelNavigationStore _modelNavigationStore;
        public ViewModelBase CurrentModelViewModel => _modelNavigationStore.CurrentViewModel;
        public bool IsModelOpen => _modelNavigationStore.IsOpen;
        public YoutubeViewersViewModel YoutubeViewersViewModel { get; }
        public MainViewModel(ModelNavigationStore modelNavigationStore, YoutubeViewersViewModel youtubeViewersViewModel)
        {
            _modelNavigationStore = modelNavigationStore;
            YoutubeViewersViewModel = youtubeViewersViewModel;

            _modelNavigationStore.CurrentViewModelChanged += ModelNavigationStore_CurrentViewModelChanged;
            //_modelNavigationStore.CurrentViewModel = new AddYoutubeViewerViewModel();
        }
        protected override void Dispose()
        {
            _modelNavigationStore.CurrentViewModelChanged -= ModelNavigationStore_CurrentViewModelChanged;

            base.Dispose();
        }
        private void ModelNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModelViewModel));
            OnPropertyChanged(nameof(IsModelOpen));
        }
    }
}
