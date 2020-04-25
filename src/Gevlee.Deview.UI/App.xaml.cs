using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Gevlee.Deview.Core.Commands;
using Gevlee.Deview.Core.ViewModels;
using Splat;
using System.Linq;

namespace Gevlee.Deview.UI
{
    public class App : Avalonia.Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public ViewLocator ViewLocator => DataTemplates.FirstOrDefault(x => x is ViewLocator) as ViewLocator;

        public override void OnFrameworkInitializationCompleted()
        {
            CommandsRegistry.LoadAllToApplicationLifecycle();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var vm = Locator.Current.GetService<MainWindowViewModel>();
                var mainWindow = ViewLocator.Build(vm);
                mainWindow.DataContext = vm;
                desktop.MainWindow = (Window)mainWindow;

                Locator.CurrentMutable.Register(() => desktop.MainWindow as IShell);
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
