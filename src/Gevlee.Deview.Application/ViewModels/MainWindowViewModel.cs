using ReactiveUI;

namespace Gevlee.Deview.Application.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            MainMenuModel = new MainMenuViewModel();
        }

        private MainMenuViewModel _mainMenuModel;

        public MainMenuViewModel MainMenuModel
        {
            get { return _mainMenuModel; }
            set { this.RaiseAndSetIfChanged(ref _mainMenuModel, value); }
        }
    }
}
