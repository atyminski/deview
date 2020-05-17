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
    public class LogViewModel : ViewModelBase
    {
        private ObservableCollection<LogEntryViewModel> _entries = new ObservableCollection<LogEntryViewModel>();
        private ILogReader logReader;

        public LogViewModel(ILogReader logReader)
        {
            this.logReader = logReader;
            this.WhenActivated((disposables) => 
            {
                this.logReader.ReadNextEntriesAsync()
                .ToObservable()
                .Subscribe(AddEntry)
                .DisposeWith(disposables);
            });
        }

        private void AddEntry(ILogEntry entry)
        {
            _entries.Add(CreateViewModelForEntry(entry));
        }

        private LogEntryViewModel CreateViewModelForEntry(ILogEntry entry)
        {
            return new LogEntryViewModel(entry);
        }

        public Encoding Encoding { get; set; }

        public IEnumerable<LogEntryViewModel> Entries => _entries;
    }
}
