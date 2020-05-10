using System;

namespace Gevlee.Deview.Core.Log
{
    public class LogEntry : ILogEntry
    {
        public string Content { get; set; }
        public Range PositionRange { get; set; }
    }
}
