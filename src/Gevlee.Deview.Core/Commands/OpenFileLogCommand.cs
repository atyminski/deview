namespace Gevlee.Deview.Core.Commands
{
    public class OpenFileLogCommand
    {
    }

    public class OpenFileLogCommandResponse
    {
        public bool FileWasSelected { get; set; }

        public string Path { get; set; }
    }
}
