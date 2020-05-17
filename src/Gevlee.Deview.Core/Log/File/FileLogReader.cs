using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Gevlee.Deview.Core.Log.File
{
    public class FileLogReader : IFileLogReader
    {
        private readonly IReadOnlyFileStreamProvider _fileStreamProvider;

        public FileLogReader(IReadOnlyFileStreamProvider fileStreamProvider)
        {
            _fileStreamProvider = fileStreamProvider;
        }

        public string Path { get; set; }

        public Encoding Encoding { get; set; } = Encoding.UTF8;

        public string NewLineSeparator { get; set; } = System.Environment.NewLine;

        public long Position { get; set; }

        public async IAsyncEnumerable<ILogEntry> ReadNextEntriesAsync()
        {
            using (var fileStream = _fileStreamProvider.GetStream(Path))
            using (var streamReader = new StreamReader(fileStream, Encoding, true))
            {
                if (Position > fileStream.Length)
                {
                    Position = 0;
                }

                fileStream.Position = Position;

                int logEntryPosition = 1;

                while (!streamReader.EndOfStream)
                {
                    var entryChars = new List<char>();

                    while (!streamReader.EndOfStream && !NewLineSeparatorReached(entryChars))
                    {
                        var buffer = new char[1];
                        Position = await streamReader.ReadAsync(buffer, 0, 1);

                        entryChars.AddRange(buffer);
                    }

                    yield return new LogEntry
                    {
                        Content = new string(entryChars.ToArray()).TrimEnd(NewLineSeparator.ToCharArray()),
                        PositionNumber = logEntryPosition,
                    };

                    logEntryPosition++;
                }
            }
        }

        private bool NewLineSeparatorReached(List<char> currentChars)
        {
            var charsToTake = NewLineSeparator.Length;

            if (currentChars.Count < charsToTake)
            {
                return false;
            }

            var charsToSkip = currentChars.Count - NewLineSeparator.Length;
            if (charsToSkip < 0)
            {
                charsToSkip = 0;
            }

            var charsToCompare = currentChars.Skip(charsToSkip).Take(charsToTake).ToArray();

            if (charsToCompare.Any())
            {
                return new string(charsToCompare).Equals(NewLineSeparator, System.StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }
    }
}
