using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimulationInsight.MathLibrary;
using System.Linq;

namespace SimulationInsight.RtsaLibrary.Tests
{
    [TestClass]
    public class RtsaDataGeneratorTests
    {
        [TestMethod]
        public void GenerateData()
        {
            // Arrange:
            var rfFrequencyCentre = 2.5e9;
            var sampleRate = 1.0e6;
            var pulseWidth = 3.0;
            var endTime = 10.0;

            var signal = SignalGenerator.RectangularPulsedSignal(rfFrequencyCentre, sampleRate, pulseWidth, endTime);

            var dataGenerator = new RtsaDataGenerator()
            {
                Signal = signal
            };

            // Act:
            dataGenerator.Run();

            // Assert:
            Assert.Inconclusive();
        }

        [TestMethod]
        public void GenerateDataAndWriteFile()
        {
            // Arrange:
            var rfFrequencyCentre = 2.5e9;
            var sampleRate = 1.0e6;
            var pulseWidth = 3.0e-3;
            var endTime = 10.0e-3;

            var signal = SignalGenerator.RectangularPulsedSignal(rfFrequencyCentre, sampleRate, pulseWidth, endTime);

            var dataGenerator = new RtsaDataGenerator()
            {
                Signal = signal
            };

            dataGenerator.Run();

            var outputFilePath = @"C:\Aaronia\Example_1_Raw.rtsa";

            var writer = new RtsaWriter()
            {
                FilePath = outputFilePath,
                RtsaData = dataGenerator.RtsaData,
            };

            // Act:
            writer.Run();

            // Assert:
            Assert.Inconclusive();
        }
    }
}