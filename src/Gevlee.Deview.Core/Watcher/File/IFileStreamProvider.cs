using System.IO;

namespace Gevlee.Deview.Core.Watcher.File
{
    public interface IReadOnlyFileStreamProvider
    {
        Stream GetStream(string path);
    }
}
