using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Gevlee.Deview.Application.ViewModels;

namespace Gevlee.Deview.Application.Views
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
