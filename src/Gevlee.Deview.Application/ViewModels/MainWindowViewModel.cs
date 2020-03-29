using ReactiveUI;
using Splat;

namespace Gevlee.Deview.Application.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            MainMenuModel = Locator.Current.GetService<MainMenuViewModel>();
            OpenedLogsContainerModel = Locator.Current.GetService<OpenedLogsContainerViewModel>();
        }

        private MainMenuViewModel _mainMenuModel;
        private OpenedLogsContainerViewModel _openedLogsContainerModel;

        public MainMenuViewModel MainMenuModel
        {
            get { return _mainMenuModel; }
            set { this.RaiseAndSetIfChanged(ref _mainMenuModel, value); }
        }

        public OpenedLogsContainerViewModel OpenedLogsContainerModel
        {
            get { return _openedLogsContainerModel; }
            set { this.RaiseAndSetIfChanged(ref _openedLogsContainerModel, value); }
        }
    }
}
