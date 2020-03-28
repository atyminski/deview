using Autofac;
using System.Linq;

namespace Gevlee.Deview.Application.DependencyInjection
{
    public class ViewModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(GetType().Assembly).Where(t => t.Namespace.Equals("Gevlee.Deview.Application.Views"));
        }
    }
}
