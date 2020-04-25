using Autofac;
using Gevlee.Deview.Core.Commands;
using Gevlee.Deview.UI.Commands;

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
