namespace Gevlee.Deview.Core.Log
{
    public interface ILogEntry
    {
        public string Content { get; }

        public int PositionNumber { get; set; }

        public Range ContentRange { get; }
    }
}
