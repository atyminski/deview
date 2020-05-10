using System.Collections.Generic;
using System.Text;

namespace Gevlee.Deview.Core.Log
{
    public interface ILog
    {
        public Encoding Encoding { get; set; }

        public IEnumerable<ILogEntry> Entries { get; }
    }
}
