namespace Gevlee.Deview.Core.Log
{
    public interface ILogEntry
    {
        public string Content { get; }

        public Range PositionRange { get; }
    }
}
