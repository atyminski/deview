using Gevlee.Deview.Core.Commands;
using Gevlee.Deview.Core.ViewModels.MainMenu;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;

namespace Gevlee.Deview.Core.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        private ObservableCollection<MainMenuItem> _items;

        public MainMenuViewModel()
        {
            this.WhenActivated(disposables =>
            {
                Items = new ObservableCollection<MainMenuItem>(
                    new MainMenuItem[]
                    {
                        new MainMenuItem
                        {
                            Name = "Open",
                            Command = ReactiveCommand.Create(() => MessageBus.Current.SendMessage(new OpenFileLogCommand()))
                        }
                    }
                );

                Disposable.Empty.DisposeWith(disposables);
            });
        }

        public ObservableCollection<MainMenuItem> Items
        {
            get { return _items; }
            set { this.RaiseAndSetIfChanged(ref _items, value); }
        }
    }
}
