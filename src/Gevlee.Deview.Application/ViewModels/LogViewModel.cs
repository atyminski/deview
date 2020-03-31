using Gevlee.Deview.Core.Log;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Gevlee.Deview.Application.ViewModels
{
    public class LogViewModel : ViewModelBase
    {
        private ILogReader logReader;

        public LogViewModel(ILogReader logReader)
        {
            LogLines = new ObservableCollection<string>();
            this.logReader = logReader;
            this.WhenActivated((disposables) => 
            {
                this.logReader.ReadNextEntriesAsync()
                .ToObservable()
                .Subscribe(LogLines.Add)
                .DisposeWith(disposables);
            });
        }

        public ObservableCollection<string> LogLines { get; set; }
    }
}
