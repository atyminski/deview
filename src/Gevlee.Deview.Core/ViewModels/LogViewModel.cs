using Gevlee.Deview.Core.Log;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;

namespace Gevlee.Deview.Core.ViewModels
{
    public class LogViewModel : ViewModelBase, ILog
    {
        private ObservableCollection<ILogEntry> _entries;
        private ILogReader logReader;

        public LogViewModel(ILogReader logReader)
        {
            _entries = new ObservableCollection<ILogEntry>();
            this.logReader = logReader;
            this.WhenActivated((disposables) => 
            {
                this.logReader.ReadNextEntriesAsync()
                .ToObservable()
                .Subscribe(_entries.Add)
                .DisposeWith(disposables);
            });
        }

        public Encoding Encoding { get; set; }

        IEnumerable<ILogEntry> ILog.Entries => _entries;
    }
}
