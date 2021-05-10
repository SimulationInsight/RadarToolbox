using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimulationInsight.RtsaLibrary.Tests
{
    [TestClass]
    public class RtsaWriterTests
    {
        [TestMethod]
        public void Run()
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
    }
}