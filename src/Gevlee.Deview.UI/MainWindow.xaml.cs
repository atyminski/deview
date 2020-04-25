using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Gevlee.Deview.Core.ViewModels;

namespace Gevlee.Deview.UI
{
    public class MainWindow : ReactiveWindow<MainWindowViewModel>, IShell
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
