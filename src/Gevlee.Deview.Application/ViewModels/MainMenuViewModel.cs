using Gevlee.Deview.Application.Commands;
using Gevlee.Deview.Application.ViewModels.MainMenu;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;

namespace Gevlee.Deview.Application.ViewModels
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
