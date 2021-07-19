using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimulationInsight.ESMData.Models;

namespace SimulationInsight.ESMLibrary.Tests
{
    [TestClass]
    public class PulseDescriptorTests
    {
        [TestMethod]
        public void CheckFrequency()
        {
            // Arrange:
            var expectedFrequencyBandwidth = 40.0e6;

            // Act:
            var p = new PulseDescriptorDTO()
            {
                FrequencyStart = 9.0e9,
                FrequencyEnd = 8.96e9
            };

            // Assert:
            Assert.AreEqual(expectedFrequencyBandwidth, p.FrequencyBandwidth);
        }
    }
}