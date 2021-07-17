using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimulationInsight.ESMData.Entities;
using System.Linq;
using System;
using System.Collections.Generic;

namespace SimulationInsight.ESMData.DAL.Tests
{
    [TestClass]
    public class ESMContextTests
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            using var context = new ESMContext();

            var missions = context.Missions.Where(s => s.MissionType == MissionType.Test);

            context.RemoveRange(missions);

            context.SaveChanges();

            var startDate = new DateTime(2021, 06, 01, 10, 20, 00, DateTimeKind.Utc);

            var track11 = new Track()
            {
                TrackNumber = 1,
                TrackName = "Track 1"
            };

            var track12 = new Track()
            {
                TrackNumber = 2,
                TrackName = "Track 2"
            };

            var track13 = new Track()
            {
                TrackNumber = 3,
                TrackName = "Track 3"
            };

            var track21 = new Track()
            {
                TrackNumber = 1,
                TrackName = "Track 1"
            };

            var track22 = new Track()
            {
                TrackNumber = 2,
                TrackName = "Track 2"
            };

            var mission1 = new Mission()
            {
                MissionNumber = 1,
                MissionType = MissionType.Test,
                StartDateTime = startDate,
                EndDateTime = startDate.AddHours(1),
                Description = "Mission 1",
                
                Tracks = new List<Track>() { track11, track12, track13 }
            };

            var mission2 = new Mission()
            {
                MissionNumber = 2,
                MissionType = MissionType.Test,
                StartDateTime = startDate.AddDays(1),
                EndDateTime = startDate.AddDays(1).AddHours(1),
                Description = "Mission 2",
                Tracks = new List<Track>() { track21, track22 }
            };

            context.Missions.AddRange(mission1, mission2);

            context.SaveChanges();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        [TestMethod]
        public void GetMissions_Test_1()
        {
            // Arrange:
            using var context = new ESMContext();

            // Act:
            var missions = context.Missions.Where(s => s.MissionType == MissionType.Test);

            // Assert:
            Assert.AreEqual(2, missions.Count());
        }
    }
}
