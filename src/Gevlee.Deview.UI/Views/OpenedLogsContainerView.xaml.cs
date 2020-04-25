using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Gevlee.Deview.Core.ViewModels;
using ReactiveUI;

namespace Gevlee.Deview.UI.Views
{
    public class OpenedLogsContainerView : ReactiveUserControl<OpenedLogsContainerViewModel>
    {
        public OpenedLogsContainerView()
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
