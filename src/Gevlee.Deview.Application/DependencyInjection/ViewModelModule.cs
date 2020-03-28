using Autofac;

namespace Gevlee.Deview.Application.DependencyInjection
{
    public class ViewModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(GetType().Assembly)
                .Where(t => t.Name.EndsWith("ViewModel"));
        }
    }
}
