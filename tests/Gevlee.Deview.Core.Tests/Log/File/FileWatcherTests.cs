using Gevlee.Deview.Core.Log;
using Gevlee.Deview.Core.Log.File;
using System;
using System.IO;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Gevlee.Deview.Core.Tests.Watcher
{
    public class FileWatcherTests : IDisposable
    {
        public FileWatcherTests()
        {
            TestFilePath = Path.GetFullPath($"FileWatcherTests_TestFile_{Guid.NewGuid()}.log");
            File.WriteAllText(TestFilePath, "testContent");
        }

        public string TestFilePath { get; }

        public void Dispose()
        {
            if (File.Exists(TestFilePath))
                File.Delete(TestFilePath);
        }

        [Fact(Timeout = 5000)]
        public async Task ShouldDetect_FileUpdate()
        {
            var updateOccured = false;
            using var watcher = new FileWatcher(TestFilePath);

            watcher.Updates
                .Where(x => x == LogStateChangeType.Updated)
                .Subscribe(
                _ => updateOccured = true);
            await watcher.StartAsync();

            await File.AppendAllTextAsync(TestFilePath, "newText");

            while (!updateOccured) { }

            Assert.True(updateOccured);
        }

        [Fact(Timeout = 5000)]
        public async Task ShouldDetect_FileDelete()
        {
            var deleteOccured = false;
            using var watcher = new FileWatcher(TestFilePath);

            watcher.Updates
                .Where(x => x == LogStateChangeType.NotAvailable)
                .Subscribe(
                _ => deleteOccured = true);

            await watcher.StartAsync();

            File.Delete(TestFilePath);

            while (!deleteOccured) { }

            Assert.True(deleteOccured);
        }
    }
}
