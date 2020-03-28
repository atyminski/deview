using Avalonia.Controls;
using System;
using System.Reactive.Linq;

namespace Gevlee.Deview.Application.Commands
{
    public class OpenFileLogCommand
    {
    }

    public class OpenFileLogCommandResponse
    {
        public bool FileWasSelected { get; set; }

        public string Path { get; set; }
    }

    internal class OpenFileLogCommandHandler : ICommandHandler<OpenFileLogCommand, OpenFileLogCommandResponse>
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
