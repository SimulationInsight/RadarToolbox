using SimulationInsight.ESMLibrary;
using SimulationInsight.ESMPulseDescriptorGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMDataGenerator
{
    public static class ESMDataGeneratorExamples
    {
        public static ESMData.Models.ESMData GenerateESMDataSingle()
        {
            var inputs = ESMPulseDescriptorGeneratorInputsFactory.Example_1();

            inputs = inputs with { EndTime = 0.015 };

            var generator = new ESMDataGenerator()
            {
                ESMPulseDescriptorGeneratorInputs = new() { inputs },
                IsGenerateIQSignals = true,
                SampleRate = 100.0e6
            };

            generator.GenerateESMData();

            return generator.ESMData;
        }

        public static ESMData.Models.ESMData GenerateESMDataMultiple()
        {
            var inputs1 = ESMPulseDescriptorGeneratorInputsFactory.Example_1();
            var inputs2 = ESMPulseDescriptorGeneratorInputsFactory.Example_2();

            inputs1 = inputs1 with { EndTime = 0.015 };
            inputs2 = inputs2 with { EndTime = 0.015 };

            var generator = new ESMDataGenerator()
            {
                ESMPulseDescriptorGeneratorInputs = new() { inputs1, inputs2 },
                IsGenerateIQSignals = true,
                SampleRate = 100.0e6
            };

            generator.GenerateESMData();

            return generator.ESMData;
        }
    }
}
