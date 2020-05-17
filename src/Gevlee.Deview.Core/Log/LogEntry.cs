using System;

namespace Gevlee.Deview.Core.Log
{
    public class LogEntry : ILogEntry
    {
        public string Content { get; set; }
        public Range ContentRange { get; set; }
        public int PositionNumber { get; set; }
    }
}
