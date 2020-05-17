using Gevlee.Deview.Core.Log;

namespace Gevlee.Deview.Core.ViewModels
{
    public class LogEntryViewModel : ViewModelBase
    {
        private readonly ILogEntry logEntry;

        public LogEntryViewModel(ILogEntry logEntry)
        {
            this.logEntry = logEntry;
        }

        public string Content => logEntry.Content;

        public int PositionNumber => logEntry.PositionNumber;

        public bool IsEven => PositionNumber % 2 == 0;
    }
}
