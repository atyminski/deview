using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Gevlee.Deview.Core.ViewModels;
using ReactiveUI;

namespace Gevlee.Deview.UI.Views
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
