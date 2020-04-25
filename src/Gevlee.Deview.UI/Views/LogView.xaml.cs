using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Gevlee.Deview.Core.ViewModels;
using ReactiveUI;

namespace Gevlee.Deview.UI.Views
{
    public class LogView : ReactiveUserControl<LogViewModel>
    {
        public LogView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}
