using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimulationInsight.RtsaLibrary.Tests
{
    [TestClass]
    public class RtsaReaderTests
    {
        [TestMethod]
        public void Run()
        {
            // Arrange:
            //var filePath = Path.Combine(Environment.CurrentDirectory, "IQ-Sample-Data-CW-Uncompressed.rtsa");

            var filePath = @"C:\Aaronia\IQ-Sample-Data-CW-Uncompressed.rtsa";

            var reader = new RtsaReader()
            {
                FilePath = filePath
            };

            // Act:
            reader.Run();

            // Assert:
            Assert.Inconclusive();
        }
    }
}