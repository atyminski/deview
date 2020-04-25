using System;

namespace Gevlee.Deview.Core.Commands
{
    public interface ICommandHandler<in TCommand, out TResponse>
    {
        IObservable<TResponse> Execute(TCommand command);
    }
}
