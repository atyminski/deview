using Autofac;
using Avalonia;
using Avalonia.Logging.Serilog;
using Avalonia.ReactiveUI;
using Gevlee.Deview.UI;
using Serilog;
using Splat;
using Splat.Autofac;
using Splat.Serilog;
using System.Runtime.InteropServices;

namespace Gevlee.Deview.Application
{
    class Program
    {
        public static void Main(string[] args) 
        {
            SetupLogging();
            SetupDependencyInjectionContainer();
            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);
        }

        public static AppBuilder BuildAvaloniaApp()
        {
            var result = AppBuilder.Configure<App>();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                result
                    .UseWin32()
                    .UseSkia();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                result.UsePlatformDetect();
                    //.UseManagedSystemDialogs<AppBuilder, WasabiWindow>();
            }
            else
            {
                result.UsePlatformDetect();
            }


            return result
                .With(new Win32PlatformOptions { AllowEglInitialization = true, UseDeferredRendering = true })
                .With(new X11PlatformOptions { UseGpu = true, WmClass = "Deview" })
                .With(new AvaloniaNativePlatformOptions { UseDeferredRendering = true, UseGpu = true })
                .With(new MacOSPlatformOptions { ShowInDock = true })
                .UseReactiveUI();
        }

        private static void SetupLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Debug()
                .WriteTo.Console()
#if DEBUG
                .WriteTo.Debug()
#endif
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
