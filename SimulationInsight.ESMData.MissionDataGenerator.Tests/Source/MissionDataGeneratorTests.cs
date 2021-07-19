using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimulationInsight.ESMData.MissionDataGenerator.Tests
{
    [TestClass]
    public class MissionDataGeneratorTests
    {
        [TestMethod]
        public void Run_Example_1()
        {
            // Arrange:
            var missionDataGenerator = MissionDataGeneratorExamples.Example_1();

            // Act:
            missionDataGenerator.Run();

            var mission = missionDataGenerator.Mission;

            // Assert:
            Assert.AreEqual(2, mission.Tracks.Count);
        }

        [TestMethod]
        public void Run_Example_1_WithSave()
        {
            // Arrange:
            var missionDataGenerator = MissionDataGeneratorExamples.Example_1();

            // Act:
            missionDataGenerator.Run();

            var mission = missionDataGenerator.Mission;

            //missionDataGenerator.SaveMissionToDatabase();

            // Assert:
            Assert.AreEqual(2, mission.Tracks.Count);
        }
    }
}
