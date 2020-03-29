using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Gevlee.Deview.Application.Views
{
    public class LogView : UserControl
    {
        public LogView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
