using SimulationInsight.ESMData.DAL;
using SimulationInsight.ESMData.Entities;
using SimulationInsight.ESMData.Mappers;
using SimulationInsight.ESMData.Service;
using SimulationInsight.ESMPulseDescriptorGenerator;
using System;
using System.Collections.Generic;

namespace SimulationInsight.ESMData.MissionDataGenerator
{
    public class MissionDataGenerator
    {
        public IESMDataService ESMDataService { get; set; }

        public MissionDataGeneratorInputs Inputs { get; set; }

        public Models.ESMDataDTO ESMData { get; set; }

        public List<Track> Tracks { get; set; }

        public Mission Mission { get; set; }

        public object ModelMappers { get; private set; }

        public MissionDataGenerator(IESMDataService esmDataService)
        {
            ESMDataService = esmDataService;
        }

        public void Run()
        {
            GenerateESMDataDTO();

            GenerateMission();
        }

        public void GenerateESMDataDTO()
        {
            var generator = new ESMDataGenerator.ESMDataGenerator()
            {
                ESMPulseDescriptorGeneratorInputs = Inputs.PulseDescriptorGeneratorInputs,
                IsGenerateIQSignals = Inputs.IsGenerateIQSignals,
                SampleRate = Inputs.SampleRate
            };

            generator.GenerateESMData();

            ESMData = generator.ESMData;
        }

        public void GenerateMission()
        {
            Tracks = new List<Track>();

            foreach (var trackDTO in ESMData.Tracks)
            {
                var track = ModelMapper.ConvertToTrack(trackDTO);

                Tracks.Add(track);
            }

            Mission = new Mission()
            {
                MissionNumber = Inputs.MissionNumber,
                StartDateTime = Inputs.StartDateTime,
                EndDateTime = Inputs.EndDateTime,
                MissionType = MissionType.Simulated,
                Tracks = Tracks,
            };
        }

        public void SaveMissionToDatabase()
        {
            ESMDataService.SaveMission(Mission);
        }
    }
}
