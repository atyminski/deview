using Avalonia.Controls;
using Gevlee.Deview.Core.Commands;
using System;
using System.Reactive.Linq;

namespace Gevlee.Deview.UI.Commands
{
    public class OpenFileLogCommandHandler : ICommandHandler<OpenFileLogCommand, OpenFileLogCommandResponse>
    {
        private readonly Window _parent;

        public OpenFileLogCommandHandler(IShell parent)
        {
            _parent = parent as Window;
        }

        public IObservable<OpenFileLogCommandResponse> Execute(OpenFileLogCommand command)
        {
            return Observable.FromAsync(async () =>
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.AllowMultiple = false;

                var result = await dialog.ShowAsync(_parent);

                if(result == null)
                {
                    return new OpenFileLogCommandResponse
                    {
                        FileWasSelected = false
                    };
                }

                return new OpenFileLogCommandResponse { Path = result[0], FileWasSelected = true };
            });
        }
    }
}
