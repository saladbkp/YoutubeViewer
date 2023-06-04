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
    public class EditYoutubeViewerViewModel:ViewModelBase
    {
        public YoutubeViewerDetailsFormViewModel YoutubeViewerDetailsFormViewModel { get; }
        public EditYoutubeViewerViewModel(YoutubeViewer youtubeViewers,ModelNavigationStore modelNavigationStore)
        {
            ICommand submitCommand = new EditYoutubeViewerCommand(modelNavigationStore);
            ICommand cancelCommand = new CloseModelCommand(modelNavigationStore);
            YoutubeViewerDetailsFormViewModel = new YoutubeViewerDetailsFormViewModel(submitCommand, cancelCommand)
            {
                Username = youtubeViewers.Username,
                IsSubscribed = youtubeViewers.IsSubscribed,
                IsMember = youtubeViewers.IsMember
            };
        }
    }
}
