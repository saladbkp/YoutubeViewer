using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeViewers.WPF.Stores;

namespace YoutubeViewers.WPF.Commands
{
    public class CloseModelCommand:CommandBase
    {
        private readonly ModelNavigationStore _modelNavigationStore;
        public CloseModelCommand(ModelNavigationStore modelNavigationStore)
        {
            _modelNavigationStore = modelNavigationStore;
        }
        public override void Execute(object parameter)
        {
            _modelNavigationStore.Close();
        }
    }
}
