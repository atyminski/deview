using System;

namespace Gevlee.Deview.Application.Commands
{
    public interface ICommandHandler<in TCommand, out TResponse>
    {
        IObservable<TResponse> Execute(TCommand command);
    }
}
