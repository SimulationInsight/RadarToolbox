using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimulationInsight.ESMLibrary.Tests
{
    [TestClass]
    public class IQTests
    {
        [TestMethod]
        public void GenerateRectangularPulse()
        {
            // Arrange:
            var signal = IQSignalGenerator.GenerateRectangularPulse(100.0e6, 10e-6, 2.0);

            // Act:
            signal.CalculateInstantaneousFrequency();

            // Assert:
            Assert.Inconclusive();
        }

        public void GenerateLFMSignal()
        {
            // Arrange:
            var signal = IQSignalGenerator.GenerateLFMPulse(100.0e6, 10e-6, 2.0, 50.0e6, 20.0e6);

            // Act:
            signal.CalculateInstantaneousFrequency();

            // Assert:
            Assert.Inconclusive();
        }
    }
}