using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimulationInsight.ESMPulseDescriptorGenerator;
using System;
using System.Collections.Generic;

namespace SimulationInsight.ESMTrackGenerator.Tests
{
    [TestClass]
    public class ESMTrackGeneratorTests
    {
        [TestMethod]
        public void GenerateESMTrackListSingle_Test_1()
        {
            // Arrange:

            // Act:
            var esmTrackList = ESMTrackListExamples.GenerateESMTrackListSingle();

            // Assert:
            Assert.AreEqual(1, esmTrackList.NumberOfTracks);
        }

        [TestMethod]
        public void GenerateESMTrackListMultiple_Test_1()
        {
            // Arrange:

            // Act:
            var esmTrackList = ESMTrackListExamples.GenerateESMTrackListMultiple();

            // Assert:
            Assert.AreEqual(2, esmTrackList.NumberOfTracks);
        }
    }
}
