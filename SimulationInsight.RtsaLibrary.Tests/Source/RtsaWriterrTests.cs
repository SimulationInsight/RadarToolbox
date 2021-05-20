using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimulationInsight.MathLibrary;
using System.Collections.Generic;

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
            Assert.IsTrue(true);
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

            RtsaDataUtilities.RemoveSPRVData(rtsaData);

            var writer = new RtsaWriter()
            {
                FilePath = outputFilePath,
                RtsaData = rtsaData,
            };

            // Act:
            writer.Run();

            // Assert:
            Assert.IsTrue(true);
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
            Assert.IsTrue(true);
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
            Assert.IsTrue(true);
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
            Assert.IsTrue(true);
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
            Assert.IsTrue(true);
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
            Assert.IsTrue(true);
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
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void WriteBlankFileSmall()
        {
            // Arrange:
            var inputFilePath = @"C:\Aaronia\Example_1_Raw.rtsa";
            var outputFilePath = @"C:\Aaronia\Example_1_Blank_Small.rtsa";
            var numberOfSAMPPacketsToKeep = 10;

            var writer = GenerateWriter(inputFilePath, outputFilePath, numberOfSAMPPacketsToKeep);

            // Act:
            writer.Run();

            // Assert:
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void WriteBlankFileBig()
        {
            // Arrange:
            var inputFilePath = @"C:\Aaronia\Example_1_Raw.rtsa";
            var outputFilePath = @"C:\Aaronia\Example_1_Blank_Big.rtsa";
            var numberOfSAMPPacketsToKeep = 1000;

            var writer = GenerateWriter(inputFilePath, outputFilePath, numberOfSAMPPacketsToKeep);

            var rtsaData = writer.RtsaData;

            var signal = SignalGenerator.RectangularPulsedSignal(5.5e9, 1.0e6, 10.0e-3, 20.0e-3);

            RtsaDataUtilities.UpdateWithSignalData(rtsaData, signal);

            // Act:
            writer.Run();

            // Assert:
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void WriteBlankFileBig2()
        {
            // Arrange:
            var inputFilePath = @"C:\Aaronia\Example_1_Raw.rtsa";
            var outputFilePath = @"C:\Aaronia\Example_1_Blank_Big2.rtsa";
            var numberOfSAMPPacketsToKeep = 1000;

            var writer = GenerateWriter(inputFilePath, outputFilePath, numberOfSAMPPacketsToKeep);

            var rtsaData = writer.RtsaData;

            var signal1 = SignalGenerator.RectangularPulsedSignal(5.5e9, 1.0e6, 1.0e-3, 20.0e-3);
            var signal2 = SignalGenerator.RectangularPulsedSignal(5.5e9, 1.0e6, 0.0e-3, 20.0e-3);
            var signal3 = SignalGenerator.RectangularPulsedSignal(5.5e9, 1.0e6, 0.0e-3, 20.0e-3);
            var signal4 = SignalGenerator.RectangularPulsedSignal(5.5e9, 1.0e6, 0.0e-3, 20.0e-3);

            var signals = new List<Signal>() { signal1, signal2, signal3, signal4 };

            RtsaDataUtilities.UpdateWithSignalData(rtsaData, signals);

            // Act:
            writer.Run();

            // Assert:
            Assert.IsTrue(true);
        }

        public static RtsaWriter GenerateWriter(string inputFilePath, string outputFilePath, int numberOfSAMPPacketsToKeep)
        {
            var reader = new RtsaReader()
            {
                FilePath = inputFilePath
            };

            reader.Run();

            var rtsaData = reader.RtsaData;

            RtsaDataUtilities.PrepareFile(rtsaData, numberOfSAMPPacketsToKeep);

            var writer = new RtsaWriter()
            {
                FilePath = outputFilePath,
                RtsaData = rtsaData,
            };

            return writer;
        }
    }
}