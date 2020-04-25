using Autofac;
using Gevlee.Deview.UI;
using System.Linq;

namespace Gevlee.Deview.Application.DependencyInjection
{
    public class ViewModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindow>();
            builder.RegisterAssemblyTypes(typeof(IShell).Assembly).Where(t => t.Namespace.Equals("Gevlee.Deview.UI.Views"));
        }
    }
}
