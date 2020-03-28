using ReactiveUI;
using System.Windows.Input;

namespace Gevlee.Deview.Application.ViewModels.MainMenu
{
    public class MainMenuItem : ReactiveObject
    {
        private string _name;
        private ICommand _command;
        private string _hotkey;

        public string Name
        {
            get { return _name; }
            set { this.RaiseAndSetIfChanged(ref _name, value); }
        }

        public ICommand Command
        {
            get { return _command; }
            set { this.RaiseAndSetIfChanged(ref _command, value); }
        }

        public string Hotkey
        {
            get { return _hotkey; }
            set { this.RaiseAndSetIfChanged(ref _hotkey, value); }
        }
    }
}
