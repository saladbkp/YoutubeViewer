using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YoutubeViewers.WPF.Stores;
using YoutubeViewers.WPF.ViewModels;

namespace YoutubeViewers.WPF.Commands
{
    public class OpenAddYoutubeViewerCommand : CommandBase
    {
        private readonly YoutubeViewerStore _youtubeViewerStore;
        private readonly ModelNavigationStore _modelNavigationStore;
        public OpenAddYoutubeViewerCommand(YoutubeViewerStore youtubeViewerStore, ModelNavigationStore modelNavigationStore)
        {
            _youtubeViewerStore = youtubeViewerStore;
            _modelNavigationStore = modelNavigationStore;
        }
        public override void Execute(object parameter)
        {
            AddYoutubeViewerViewModel addYoutubeViewerViewModel = new AddYoutubeViewerViewModel(_youtubeViewerStore,_modelNavigationStore);
            _modelNavigationStore.CurrentViewModel = addYoutubeViewerViewModel;
        }
    }
}
