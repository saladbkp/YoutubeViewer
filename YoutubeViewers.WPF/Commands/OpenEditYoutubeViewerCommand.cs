using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeViewers.WPF.Models;
using YoutubeViewers.WPF.Stores;
using YoutubeViewers.WPF.ViewModels;

namespace YoutubeViewers.WPF.Commands
{
    public class OpenEditYoutubeViewerCommand:CommandBase
    {
        private readonly ModelNavigationStore _modelNavigationStore;
        private readonly YoutubeViewer _youtubeViewer;
        public OpenEditYoutubeViewerCommand(YoutubeViewer youtubeViewer,ModelNavigationStore modelNavigationStore)
        {
            _youtubeViewer = youtubeViewer;
            _modelNavigationStore = modelNavigationStore;
        }
        public override void Execute(object parameter)
        {
            EditYoutubeViewerViewModel editYoutubeViewerViewModel = new EditYoutubeViewerViewModel(_youtubeViewer,_modelNavigationStore);
            _modelNavigationStore.CurrentViewModel = editYoutubeViewerViewModel;
        }
    }
}
