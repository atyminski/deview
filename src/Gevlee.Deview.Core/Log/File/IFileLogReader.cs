namespace Gevlee.Deview.Core.Log.File
{
    public interface IFileLogReader : ILogReader
    {
        string Path { get; set; }
    }
}