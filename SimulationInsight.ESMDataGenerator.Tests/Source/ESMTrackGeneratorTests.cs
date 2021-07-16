using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimulationInsight.ESMPulseDescriptorGenerator;
using System;
using System.Collections.Generic;

namespace SimulationInsight.ESMDataGenerator.Tests
{
    [TestClass]
    public class ESMDataGeneratorTests
    {
        [TestMethod]
        public void GenerateESMTrackListSingle_Test_1()
        {
            // Arrange:

            // Act:
            var esmData = ESMDataGeneratorExamples.GenerateESMDataSingle();

            // Assert:
            Assert.AreEqual(1, esmData.NumberOfTracks);
        }

        [TestMethod]
        public void GenerateESMTrackListMultiple_Test_1()
        {
            // Arrange:

            // Act:
            var esmData = ESMDataGeneratorExamples.GenerateESMDataMultiple();

            // Assert:
            Assert.AreEqual(2, esmData.NumberOfTracks);
        }
    }
}
