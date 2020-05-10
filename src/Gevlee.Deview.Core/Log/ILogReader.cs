using System.Collections.Generic;
using System.Text;

namespace Gevlee.Deview.Core.Log
{
    public interface ILogReader
    {
        Encoding Encoding { get; set; }

        string NewLineSeparator { get; set; }

        long Position { get; set; }

        IAsyncEnumerable<ILogEntry> ReadNextEntriesAsync();
    }
}
