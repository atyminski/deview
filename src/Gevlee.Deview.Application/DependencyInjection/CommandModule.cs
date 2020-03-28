using Autofac;
using Gevlee.Deview.Application.Commands;

namespace Gevlee.Deview.Application.DependencyInjection
{
    public class CommandModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OpenFileLogCommandHandler>().As<ICommandHandler<OpenFileLogCommand, OpenFileLogCommandResponse>>();
        }
    }
}
