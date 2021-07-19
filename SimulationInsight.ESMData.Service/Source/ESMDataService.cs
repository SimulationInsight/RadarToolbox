using SimulationInsight.ESMData.DAL;
using SimulationInsight.ESMData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulationInsight.ESMData.Service
{
    public class ESMDataService : IESMDataService
    {
        public List<Mission> GetAllMissions()
        {
            using var context = new ESMContext();

            var missions = context.Missions.ToList();

            return missions;
        }

        public Mission GetMissionById(int missionId)
        {
            using var context = new ESMContext();

            var mission = context.Missions.Where(s => s.MissionId == missionId).FirstOrDefault();

            return mission;
        }

        public void SaveMission(Mission mission)
        {
            using var context = new ESMContext();

            context.Missions.Add(mission);

            context.SaveChanges();
        }
    }
}
