using SimulationInsight.ESMLibrary;
using SimulationInsight.ESMPulseDescriptorGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMTrackGenerator
{
    public static class ESMTrackListExamples
    {
        public static ESMTrackList GenerateESMTrackListSingle()
        {
            var inputs = ESMPulseDescriptorGeneratorInputsFactory.Example_1();

            inputs = inputs with { EndTime = 0.015 };

            var generator = new ESMTrackGenerator()
            {
                ESMPulseDescriptorGeneratorInputs = new() { inputs },
                IsGenerateIQSignals = true,
                SampleRate = 100.0e6
            };

            generator.GenerateESMTrackList();

            return generator.ESMTrackList;
        }

        public static ESMTrackList GenerateESMTrackListMultiple()
        {
            var inputs1 = ESMPulseDescriptorGeneratorInputsFactory.Example_1();
            var inputs2 = ESMPulseDescriptorGeneratorInputsFactory.Example_2();

            inputs1 = inputs1 with { EndTime = 0.015 };
            inputs2 = inputs2 with { EndTime = 0.015 };

            var generator = new ESMTrackGenerator()
            {
                ESMPulseDescriptorGeneratorInputs = new() { inputs1, inputs2 },
                IsGenerateIQSignals = true,
                SampleRate = 100.0e6
            };

            generator.GenerateESMTrackList();

            return generator.ESMTrackList;
        }
    }
}
