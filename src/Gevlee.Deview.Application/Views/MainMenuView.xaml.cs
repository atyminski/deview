using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Gevlee.Deview.Application.ViewModels;
using ReactiveUI;

namespace Gevlee.Deview.Application.Views
{
    public class MainMenuView : ReactiveUserControl<MainMenuViewModel>
    {
        public MainMenuView()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}
