using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimulationInsight.ESMData.Entities;

namespace SimulationInsight.ESMData.Mappers.Tests
{
    [TestClass]
    public class ModelMapperTests
    {
        [TestMethod]
        public void ConvertToPulseDescriptorDTO()
        {
            // Arrange:
            var pulseDescriptor = new PulseDescriptor()
            {
                PulseNumber = 100,
                AzimuthAngleDeg = 20.0,
                SignalPower = 100.0,
                SignalToNoiseRatio = 10.0
            };

            // Act:
            var pulseDescriptorDTO = ModelMapper.ConvertToPulseDescriptorDTO(pulseDescriptor);

            // Assert:
            Assert.AreEqual(pulseDescriptor.AzimuthAngleDeg, pulseDescriptorDTO.AzimuthAngleDeg);
        }
    }
}
