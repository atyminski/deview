using Autofac;
using Gevlee.Deview.Core.Log.File;

namespace Gevlee.Deview.Application.DependencyInjection
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileLogReader>().As<IFileLogReader>();
            builder.RegisterType<FileStreamProvider>().As<IReadOnlyFileStreamProvider>();
        }
    }
}
