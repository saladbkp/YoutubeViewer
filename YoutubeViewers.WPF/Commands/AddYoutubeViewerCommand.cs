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
    public class AddYoutubeViewerCommand:AsyncCommandBase
    {
        private readonly AddYoutubeViewerViewModel _addYoutubeViewerViewModel;
        private readonly YoutubeViewerStore _youtubeViewerStore;
        private readonly ModelNavigationStore _modelNavigationStore;
        public AddYoutubeViewerCommand(AddYoutubeViewerViewModel addYoutubeViewerViewModel,YoutubeViewerStore youtubeViewerStore,ModelNavigationStore modelNavigationStore)
        {
            _addYoutubeViewerViewModel = addYoutubeViewerViewModel;
            _youtubeViewerStore = youtubeViewerStore;
            _modelNavigationStore = modelNavigationStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            YoutubeViewerDetailsFormViewModel formViewModel = _addYoutubeViewerViewModel.YoutubeViewerDetailsFormViewModel;

            // add command
            YoutubeViewer youtubeViewer = new YoutubeViewer(
                formViewModel.Username,
                formViewModel.IsSubscribed,
                formViewModel.IsMember
                );

            try
            {
                await _youtubeViewerStore.Add(youtubeViewer);

                _modelNavigationStore.Close();
            }
            catch (Exception ex) { }

        }
    }
}
