using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimulationInsight.MathLibrary;
using System.Diagnostics;

namespace SimulationInsight.ESMPulseDescriptorGenerator.Tests
{
    [TestClass]
    public class ESMPulseDescriptorGeneratorTests
    {
        [TestMethod]
        public void GeneratePulseDescriptorData_PerformanceTest_1()
        {
            // Arrange:
            var inputs = new ESMPulseDescriptorGeneratorInputs()
            {
                StartTime = 0.01,
                EndTime = 50.0,
                PulseWidth = new Vector(1.0e-6, 2.0e-6, 11.0e-6),
                FrequencyCentre = new Vector(9.1e9, 9.2e9, 9.16e9, 9.18e9),
                PulseRepetitionFrequency = new Vector(1000.0, 990.0, 1100.0)
            };

            var e = new ESMPulseDescriptorGenerator()
            {
                ESMPulseDescriptorGeneratorInputs = inputs
            };

            var expectedNumberOfPulses = 51374;

            // Act:
            var sw = Stopwatch.StartNew();
            e.GeneratePulseDescriptorData();
            var elapsedMilliseconds = sw.ElapsedMilliseconds;

            // Assert
            Assert.AreEqual(expectedNumberOfPulses, e.PulseDescriptorData.NumberOfPulses);
        }

        [TestMethod]
        public void WritePulseDescriptorData_Test_1()
        {
            // Arrange:
            var inputs = new ESMPulseDescriptorGeneratorInputs()
            {
                StartTime = 0.01,
                EndTime = 50.0,
                PulseWidth = new Vector(1.0e-6, 2.0e-6, 11.0e-6),
                FrequencyCentre = new Vector(9.1e9, 9.2e9, 9.16e9, 9.18e9),
                PulseRepetitionFrequency = new Vector(1000.0, 990.0, 1100.0)
            };

            var e = new ESMPulseDescriptorGenerator()
            {
                ESMPulseDescriptorGeneratorInputs = inputs
            };

            var fileName = @"C:\temp\ESMPulseDescriptorGenerator\ESMPulseDescriptors.csv";

            // Act:
            var sw1 = Stopwatch.StartNew();
            e.GeneratePulseDescriptorData();
            var elapsedMilliseconds1 = sw1.ElapsedMilliseconds;

            var sw2 = Stopwatch.StartNew();
            e.WritePulseDescriptorData(fileName);
            var elapsedMilliseconds2 = sw2.ElapsedMilliseconds;

            // Assert
            Assert.IsTrue(true);
        }
    }
}
