using SimulationInsight.MathLibrary;

namespace SimulationInsight.ESMPulseDescriptorGenerator
{
    public static class ESMPulseDescriptorGeneratorInputsFactory
    {
        public static ESMPulseDescriptorGeneratorInputs Example_1()
        {
            var inputs = new ESMPulseDescriptorGeneratorInputs()
            {
                StartTime = 0.0,
                EndTime = 50.0,
                FrequencyOffset = 9.10e9,
                PulseWidth = new Vector(1.0e-6, 2.0e-6, 11.0e-6),
                FrequencyCentre = new Vector(9.14e9, 9.17e9, 9.15e9, 9.16e9),
                FrequencyBandwidth = new Vector(50.0e6, 30.0e6, 40.0e6),
                //FrequencyBandwidth = new Vector(20.0e6, 20.0e6, 20.0e6),
                PulseRepetitionFrequency = new Vector(1000.0, 990.0, 1100.0)
            };

            return inputs;
        }

        public static ESMPulseDescriptorGeneratorInputs Example_2()
        {
            var inputs = new ESMPulseDescriptorGeneratorInputs()
            {
                StartTime = 0.0,
                EndTime = 50.0,
                FrequencyOffset = 5.10e9,
                PulseWidth = new Vector(5.0e-6, 9.0e-6, 12.0e-6),
                FrequencyCentre = new Vector(5.16e9, 5.15e9, 5.17e9, 5.14e9),
                FrequencyBandwidth = new Vector(25.0e6, 26.0e6, 27.0e6),
                //FrequencyBandwidth = new Vector(15.0e6, 15.0e6, 15.0e6),
                PulseRepetitionFrequency = new Vector(2000.0, 1990.0, 2100.0), 
            };

            return inputs;
        }
    }
}