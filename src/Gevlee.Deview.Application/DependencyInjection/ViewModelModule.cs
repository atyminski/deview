using Autofac;
using Gevlee.Deview.Core.ViewModels;

namespace Gevlee.Deview.Application.DependencyInjection
{
    public class ViewModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ViewModelBase).Assembly)
                .Where(t => t.Name.EndsWith("ViewModel"));
        }
    }
}
