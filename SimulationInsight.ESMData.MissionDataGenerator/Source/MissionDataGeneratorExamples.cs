using SimulationInsight.ESMData.Entities;
using SimulationInsight.ESMData.Service;
using SimulationInsight.ESMPulseDescriptorGenerator;
using System;
using System.Collections.Generic;

namespace SimulationInsight.ESMData.MissionDataGenerator
{
    public static class MissionDataGeneratorExamples
    {
        public static MissionDataGenerator Example_1()
        {
            var inputs1 = ESMPulseDescriptorGeneratorInputsFactory.Example_1();
            var inputs2 = ESMPulseDescriptorGeneratorInputsFactory.Example_2();

            inputs1 = inputs1 with { EndTime = 0.015 };
            inputs2 = inputs2 with { EndTime = 0.015 };

            var inputs = new List<ESMPulseDescriptorGeneratorInputs>() { inputs1, inputs2 };

            var startDateTime = new DateTime(2021, 06, 01, 10, 30, 00);

            var missionInputs = new MissionDataGeneratorInputs()
            {
                MissionNumber = 1,
                StartDateTime = startDateTime,
                EndDateTime = startDateTime.AddMinutes(30),
                IsGenerateIQSignals = true,
                SampleRate = 100e6,
                IsSaveMissionToDatabase = true,
                PulseDescriptorGeneratorInputs = inputs
            };

            var esmDataService = new ESMDataService();

            var missionDataGenerator = new MissionDataGenerator(esmDataService)
            {
                Inputs = missionInputs
            };

            return missionDataGenerator;
        }
    }
}
