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
            var inputFilePath = @"C:\Aaronia\Example_1_Raw.rtsa";
            var outputFilePath = @"C:\Aaronia\Example_1_Copy.rtsa";

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
        public void WriteFileWithoutPreview()
        {
            // Arrange:
            var inputFilePath = @"C:\Aaronia\Example_1_Raw.rtsa";
            var outputFilePath = @"C:\Aaronia\Example_1_NoPreview.rtsa";

            var reader = new RtsaReader()
            {
                FilePath = inputFilePath
            };

            reader.Run();

            var rtsaData = reader.RtsaData;

            rtsaData = RtsaDataUtilities.RemoveSPRVData(rtsaData);

            var writer = new RtsaWriter()
            {
                FilePath = outputFilePath,
                RtsaData = rtsaData,
            };

            // Act:
            writer.Run();

            // Assert:
            Assert.Inconclusive();
        }

        [TestMethod]
        public void WriteReducedFileSAMP1()
        {
            // Arrange:
            var inputFilePath = @"C:\Aaronia\Example_1_Raw.rtsa";
            var outputFilePath = @"C:\Aaronia\Example_1_SAMP1.rtsa";
            var numberOfSAMPPacketsToKeep = 1;

            var writer = GenerateWriter(inputFilePath, outputFilePath, numberOfSAMPPacketsToKeep);

            // Act:
            writer.Run();

            // Assert:
            Assert.Inconclusive();
        }

        [TestMethod]
        public void WriteReducedFileSAMP2()
        {
            // Arrange:
            var inputFilePath = @"C:\Aaronia\Example_1_Raw.rtsa";
            var outputFilePath = @"C:\Aaronia\Example_1_SAMP2.rtsa";
            var numberOfSAMPPacketsToKeep = 2;

            var writer = GenerateWriter(inputFilePath, outputFilePath, numberOfSAMPPacketsToKeep);

            // Act:
            writer.Run();

            // Assert:
            Assert.Inconclusive();
        }

        [TestMethod]
        public void WriteReducedFileSAMP5()
        {
            // Arrange:
            var inputFilePath = @"C:\Aaronia\Example_1_Raw.rtsa";
            var outputFilePath = @"C:\Aaronia\Example_1_SAMP5.rtsa";
            var numberOfSAMPPacketsToKeep = 5;

            var writer = GenerateWriter(inputFilePath, outputFilePath, numberOfSAMPPacketsToKeep);

            // Act:
            writer.Run();

            // Assert:
            Assert.Inconclusive();
        }

        [TestMethod]
        public void WriteReducedFileSAMP20()
        {
            // Arrange:
            var inputFilePath = @"C:\Aaronia\Example_1_Raw.rtsa";
            var outputFilePath = @"C:\Aaronia\Example_1_SAMP20.rtsa";
            var numberOfSAMPPacketsToKeep = 20;

            var writer = GenerateWriter(inputFilePath, outputFilePath, numberOfSAMPPacketsToKeep);

            // Act:
            writer.Run();

            // Assert:
            Assert.Inconclusive();
        }

        [TestMethod]
        public void WriteReducedFileSAMP100()
        {
            // Arrange:
            var inputFilePath = @"C:\Aaronia\Example_1_Raw.rtsa";
            var outputFilePath = @"C:\Aaronia\Example_1_SAMP100.rtsa";
            var numberOfSAMPPacketsToKeep = 100;

            var writer = GenerateWriter(inputFilePath, outputFilePath, numberOfSAMPPacketsToKeep);

            // Act:
            writer.Run();

            // Assert:
            Assert.Inconclusive();
        }

        [TestMethod]
        public void WriteReducedFileSAMP600()
        {
            // Arrange:
            var inputFilePath = @"C:\Aaronia\Example_1_Raw.rtsa";
            var outputFilePath = @"C:\Aaronia\Example_1_SAMP600.rtsa";
            var numberOfSAMPPacketsToKeep = 600;

            var writer = GenerateWriter(inputFilePath, outputFilePath, numberOfSAMPPacketsToKeep);

            // Act:
            writer.Run();

            // Assert:
            Assert.Inconclusive();
        }

        [TestMethod]
        public void WriteBlankFileSmall()
        {
            // Arrange:
            var inputFilePath = @"C:\Aaronia\Example_1_Raw.rtsa";
            var outputFilePath = @"C:\Aaronia\Example_1_Blank_Small.rtsa";

            var reader = new RtsaReader()
            {
                FilePath = inputFilePath
            };

            reader.Run();

            var numberOfSAMPPacketsToKeep = 1;

            var rtsaData = RtsaDataUtilities.PrepareFile(reader.RtsaData, numberOfSAMPPacketsToKeep);

            var writer = new RtsaWriter()
            {
                FilePath = outputFilePath,
                RtsaData = rtsaData,
            };

            // Act:
            writer.Run();

            // Assert:
            Assert.Inconclusive();
        }

        [TestMethod]
        public void WriteBlankFileBig()
        {
            // Arrange:
            var inputFilePath = @"C:\Aaronia\Example_1_Raw.rtsa";
            var outputFilePath = @"C:\Aaronia\Example_1_Blank_Big.rtsa";

            var reader = new RtsaReader()
            {
                FilePath = inputFilePath
            };

            reader.Run();

            var numberOfSAMPPacketsToKeep = 1;

            var rtsaData = RtsaDataUtilities.PrepareFile(reader.RtsaData, numberOfSAMPPacketsToKeep);

            var writer = new RtsaWriter()
            {
                FilePath = outputFilePath,
                RtsaData = rtsaData,
            };

            // Act:
            writer.Run();

            // Assert:
            Assert.Inconclusive();
        }

        public static RtsaWriter GenerateWriter(string inputFilePath, string outputFilePath, int numberOfSAMPPacketsToKeep)
        {
            var reader = new RtsaReader()
            {
                FilePath = inputFilePath
            };

            reader.Run();

            var rtsaData = RtsaDataUtilities.PrepareFile(reader.RtsaData, numberOfSAMPPacketsToKeep);

            var writer = new RtsaWriter()
            {
                FilePath = outputFilePath,
                RtsaData = rtsaData,
            };

            return writer;
        }
    }
}