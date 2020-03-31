using System.Collections.Generic;
using System.Text;

namespace Gevlee.Deview.Core.Log
{
    public interface ILogReader
    {
        Encoding Encoding { get; set; }

        string NewLineSeparator { get; set; }

        long Offset { get; set; }

        IAsyncEnumerable<string> ReadNextEntriesAsync();
    }
}
