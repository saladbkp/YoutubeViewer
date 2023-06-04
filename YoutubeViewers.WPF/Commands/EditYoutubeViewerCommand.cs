using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeViewers.WPF.Stores;

namespace YoutubeViewers.WPF.Commands
{
    public class EditYoutubeViewerCommand:AsyncCommandBase
    {
        private readonly ModelNavigationStore _modelNavigationStore;
        public EditYoutubeViewerCommand(ModelNavigationStore modelNavigationStore)
        {
            _modelNavigationStore = modelNavigationStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            // add command
            _modelNavigationStore.Close();

        }
    }
}
