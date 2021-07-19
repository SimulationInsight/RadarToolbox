using SimulationInsight.ESMData.Entities;
using System.Collections.Generic;

namespace SimulationInsight.ESMData.Service
{
    public interface IESMDataService
    {
        List<Mission> GetAllMissions();

        Mission GetMissionById(int missionId);

        void SaveMission(Mission mission);
    }
}