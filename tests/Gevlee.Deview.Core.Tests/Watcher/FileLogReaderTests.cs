using Bogus;
using Gevlee.Deview.Core.Watcher.File;
using Moq;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Gevlee.Deview.Core.Tests.Watcher
{
    public class FileLogReaderTests
    {
        [InlineData("\r\n")]
        [InlineData("\n")]
        [InlineData(";")]
        [InlineData("\\")]
        [InlineData("\n;\n")]
        [Theory]
        public async void ReadNextEntryAsync_ShouldReturnValidNumberOfEntries(string lineSeparator)
        {
            var faker = new Faker();
            var testContent = faker.Lorem.Lines(2, lineSeparator);

            var stream = new MemoryStream();
            using (var streamWriter = new StreamWriter(stream, Encoding.UTF8, leaveOpen: true))
            {
                streamWriter.Write(testContent);
            }

            stream.Seek(0, SeekOrigin.Begin);

            var streamProviderMock = new Mock<IReadOnlyFileStreamProvider>();
            streamProviderMock.Setup(x => x.GetStream(It.IsAny<string>())).Returns(stream);

            var reader = new FileLogReader(streamProviderMock.Object);
            reader.NewLineSeparator = lineSeparator;

            var result = await reader.ReadNextEntriesAsync().ToArrayAsync();

            Assert.Equal(2, result.Length);
        }
    }
}
