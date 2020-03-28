using ReactiveUI;
using Splat;
using System;

namespace Gevlee.Deview.Application.Commands
{
    public static class CommandsRegistry
    {
        public static void LoadAllToApplicationLifecycle()
        {
            MessageBus.Current.Listen<OpenFileLogCommand>().Subscribe(command => 
            {
                Locator.Current.GetService<ICommandHandler<OpenFileLogCommand, OpenFileLogCommandResponse>>()
                .Execute(command)
                .Subscribe(response =>
                {
                    MessageBus.Current.SendMessage(response);
                });
            });

        }
    }
}
