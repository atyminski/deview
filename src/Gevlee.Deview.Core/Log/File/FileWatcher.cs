using System;
using System.IO;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Gevlee.Deview.Core.Log.File
{
    public class FileWatcher : IDisposable
    {
        private FileSystemWatcher _watcher;

        public FileWatcher(string path)
        {
            _watcher = new FileSystemWatcher(Path.GetDirectoryName(path), Path.GetFileName(path));
            InitializeUpdates();
        }

        public IObservable<LogStateChangeType> Updates { get; private set; }

        public void Dispose()
        {
            _watcher.Dispose();
        }

        public Task StartAsync()
        {
            return Task.Run(() =>
            {
                if (!_watcher.EnableRaisingEvents)
                {
                    _watcher.EnableRaisingEvents = true;
                }
            });
        }

        public Task StopAsync() => Task.Run(() => _watcher.EnableRaisingEvents = false);

        private void InitializeUpdates()
        {
            Updates = Observable.Merge(
                Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(h => _watcher.Changed += h, h => _watcher.Changed -= h).Select(_ => LogStateChangeType.Updated),
                Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(h => _watcher.Deleted += h, h => _watcher.Deleted -= h).Select(_ => LogStateChangeType.NotAvailable)
                );
        }
    }
}