using SimulationInsight.MathLibrary;

namespace SimulationInsight.ESMPulseDescriptorGenerator
{
    public static class ESMPulseDescriptorGeneratorInputsFactory
    {
        public static ESMPulseDescriptorGeneratorInputs Example_1()
        {
            var inputs = new ESMPulseDescriptorGeneratorInputs()
            {
                StartTime = 0.01,
                EndTime = 50.0,
                PulseWidth = new Vector(1.0e-6, 2.0e-6, 11.0e-6),
                FrequencyCentre = new Vector(9.1e9, 9.2e9, 9.16e9, 9.18e9),
                PulseRepetitionFrequency = new Vector(1000.0, 990.0, 1100.0)
            };

            return inputs;
        }
    }
}
