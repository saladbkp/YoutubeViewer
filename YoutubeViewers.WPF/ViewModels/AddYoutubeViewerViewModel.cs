using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YoutubeViewers.WPF.Commands;
using YoutubeViewers.WPF.Models;
using YoutubeViewers.WPF.Stores;

namespace YoutubeViewers.WPF.ViewModels
{
    public class AddYoutubeViewerViewModel:ViewModelBase
    {
        public YoutubeViewerDetailsFormViewModel YoutubeViewerDetailsFormViewModel { get; }
        public AddYoutubeViewerViewModel(YoutubeViewerStore youtubeViewerStore,ModelNavigationStore modelNavigationStore)
        {
            ICommand submitCommand = new AddYoutubeViewerCommand(this,youtubeViewerStore,modelNavigationStore);
            ICommand cancelCommand = new CloseModelCommand(modelNavigationStore);
            YoutubeViewerDetailsFormViewModel = new YoutubeViewerDetailsFormViewModel(submitCommand,cancelCommand);
        }
    }
}
