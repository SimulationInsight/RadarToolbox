using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace SimulationInsight.RtsaLibrary.Tests
{
    [TestClass]
    public class RtsaWriterTests
    {
        [TestMethod]
        public void WriteExactCopy()
        {
            // Arrange:
            var inputFilePath = @"C:\Aaronia\IQ-Sample-Data-CW-Uncompressed.rtsa";
            var outputFilePath = @"C:\Aaronia\IQ-Sample-Data-CW-Uncompressed_Output.rtsa";

            var reader = new RtsaReader()
            {
                FilePath = inputFilePath
            };

            reader.Run();

            var writer = new RtsaWriter()
            {
                FilePath = outputFilePath,
                RtsaData = reader.RtsaData,
            };

            // Act:
            writer.Run();

            // Assert:
            Assert.Inconclusive();
        }

        [TestMethod]
        public void WriteReducedFile()
        {
            // Arrange:
            var inputFilePath = @"C:\Aaronia\IQ-Sample-Data-CW-Uncompressed.rtsa";
            var outputFilePath = @"C:\Aaronia\IQ-Sample-Data-CW-Uncompressed_Output2.rtsa";

            var reader = new RtsaReader()
            {
                FilePath = inputFilePath
            };

            reader.Run();

            var rtsaData = reader.RtsaData;

            rtsaData.PacketData.RemoveAll(s => s.PacketHeader.PacketString == "SPRV");

            var index = 403;
            var count = rtsaData.PacketData.Count - index - 2;

            rtsaData.PacketData.RemoveRange(index, count);

            var p = (DSPStreamFileChunkSubStream)rtsaData.PacketData[2];

            p.FrequencyStart = 4.5e9;
            p.FrequencySpan = 20000000.0;
            p.FrequencyStep = 20000000.0;

            var writer = new RtsaWriter()
            {
                FilePath = outputFilePath,
                RtsaData = reader.RtsaData,
            };

            // Act:
            writer.Run();

            // Assert:
            Assert.Inconclusive();
        }
    }
}