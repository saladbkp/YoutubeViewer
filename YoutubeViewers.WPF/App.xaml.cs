using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using YoutubeViewers.WPF.Stores;
using YoutubeViewers.WPF.ViewModels;

namespace YoutubeViewers.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly SelectedYoutubeViewerStore _selectedYoutubeViewerStore;
        private readonly ModelNavigationStore _modelNavigationStore;
        private readonly YoutubeViewerStore _youtubeViewerStore;

        public App()
        {
            _youtubeViewerStore = new YoutubeViewerStore();
            _selectedYoutubeViewerStore = new SelectedYoutubeViewerStore();
            _modelNavigationStore = new ModelNavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            YoutubeViewersViewModel youtubeViewersViewModel = new YoutubeViewersViewModel(_youtubeViewerStore,_selectedYoutubeViewerStore,_modelNavigationStore);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modelNavigationStore,youtubeViewersViewModel)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
