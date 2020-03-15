using System.IO;

namespace Gevlee.Deview.Core.Log.File
{
    public interface IReadOnlyFileStreamProvider
    {
        Stream GetStream(string path);
    }
}
