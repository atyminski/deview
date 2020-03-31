using System.IO;

namespace Gevlee.Deview.Core.Log.File
{
    public class FileStreamProvider : IReadOnlyFileStreamProvider
    {
        public Stream GetStream(string path) => System.IO.File.OpenRead(path);
    }
}
