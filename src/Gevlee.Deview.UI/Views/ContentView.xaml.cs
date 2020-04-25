using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Gevlee.Deview.UI.Views
{
    public class ContentView : UserControl
    {
        public ContentView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
