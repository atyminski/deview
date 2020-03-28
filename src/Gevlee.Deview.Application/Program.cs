using Autofac;
using Avalonia;
using Avalonia.Logging.Serilog;
using Avalonia.ReactiveUI;
using Serilog;
using Splat;
using Splat.Autofac;
using Splat.Serilog;

namespace Gevlee.Deview.Application
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args) 
        {
            SetupLogging();
            SetupDependencyInjectionContainer();
            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .UseReactiveUI();
        }

        private static void SetupLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .CreateLogger();

            SerilogLogger.Initialize(Log.Logger);
            Locator.CurrentMutable.UseSerilogFullLogger();
        }

        private static void SetupDependencyInjectionContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(typeof(Program).Assembly);
            builder.UseAutofacDependencyResolver();
        }
    }
}
