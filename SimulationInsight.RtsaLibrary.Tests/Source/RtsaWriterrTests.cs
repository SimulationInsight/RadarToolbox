using Microsoft.VisualStudio.TestPlatform.ObjectModel.Host;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        [TestMethod]
        public void WriteMinimumFile()
        {
            // Arrange:
            var inputFilePath = @"C:\Aaronia\IQ-Sample-Data-CW-Uncompressed.rtsa";
            var outputFilePath = @"C:\Aaronia\IQ-Sample-Data-CW-Uncompressed_Blank.rtsa";

            var reader = new RtsaReader()
            {
                FilePath = inputFilePath
            };

            reader.Run();

            var rtsaData = reader.RtsaData;

            rtsaData.PacketData.RemoveAll(s => s.PacketHeader.PacketString == "SPRV");

            var index = 103;
            var count = rtsaData.PacketData.Count - index - 2;

            rtsaData.PacketData.RemoveRange(index, count);

            var p = (DSPStreamFileChunkSubStream)rtsaData.PacketData[2];

            p.FrequencyStart = 4.5e9;

            var p2 = (DSPStreamFileChunkStreamTail)rtsaData.PacketData[^2];

            p2.NumSamples = 20000 * 100;
            p2.PayloadSize = p2.NumSamples * 8;

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
        public void WriteMinimumFile2()
        {
            // Arrange:
            var inputFilePath = @"C:\Aaronia\IQ-Sample-Data-CW-Uncompressed.rtsa";
            var outputFilePath = @"C:\Aaronia\IQ-Sample-Data-CW-Uncompressed_Blank2.rtsa";

            var reader = new RtsaReader()
            {
                FilePath = inputFilePath
            };

            reader.Run();

            var rtsaData = reader.RtsaData;

            rtsaData.PacketData.RemoveAll(s => s.PacketHeader.PacketString == "SPRV");

            var index = 4;
            var count = rtsaData.PacketData.Count - index - 2;

            rtsaData.PacketData.RemoveRange(index, count);

            var p = (DSPStreamFileChunkSubStream)rtsaData.PacketData[2];

            p.FrequencyStart = 6.5e9;
            p.FrequencySpan = 200000.0;
            p.FrequencyStep = 200000.0;

            var p3 = (DSPStreamFileChunkSamples)rtsaData.PacketData[3];

            p3.NumSamples = 4000000;
            p3.Samples = new float[p3.NumSamples * 2];

            var sampleLength = p3.NumSamples / p.FrequencyStep;

            p3.PacketEndTime = p3.PacketStartTime + sampleLength;

            var p2 = (DSPStreamFileChunkStreamTail)rtsaData.PacketData[^2];

            p2.NumSamples = p3.NumSamples;
            p2.PayloadSize = p2.NumSamples * 8;

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