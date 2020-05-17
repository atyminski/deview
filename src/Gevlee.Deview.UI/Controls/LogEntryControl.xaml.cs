using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Gevlee.Deview.UI.Controls
{
    public class LogEntryControl : UserControl
    {
        public LogEntryControl()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
