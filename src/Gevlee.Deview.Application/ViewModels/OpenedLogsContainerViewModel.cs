using Gevlee.Deview.Application.Commands;
using Gevlee.Deview.Core.Log.File;
using ReactiveUI;
using Splat;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Gevlee.Deview.Application.ViewModels
{
    public class OpenedLogsContainerViewModel : ViewModelBase
    {
        private LogViewModel _currentLogModel;

        public OpenedLogsContainerViewModel()
        {
            this.WhenActivated((disposables) => 
            {
                MessageBus.Current.Listen<OpenFileLogCommandResponse>()
                .Where(x => x.FileWasSelected && !string.IsNullOrWhiteSpace(x.Path))
                .Subscribe(x => 
                {
                    var fileLogReader = Locator.Current.GetService<IFileLogReader>();
                    fileLogReader.Path = x.Path;
                    CurrentLogModel = new LogViewModel(fileLogReader);
                })
                .DisposeWith(disposables);
            });
        }

        public LogViewModel CurrentLogModel
        {
            get { return _currentLogModel; }
            set { this.RaiseAndSetIfChanged(ref _currentLogModel, value); }
        }
    }
}
