using SimulationInsight.ESMLibrary;

namespace SimulationInsight.ESMPulseDescriptorGenerator
{
    public interface IESMPulseDescriptorGenerator
    {
        ESMPulseDescriptorGeneratorInputs ESMPulseDescriptorGeneratorInputs { get; set; }

        PulseDescriptorData PulseDescriptorData { get; set; }

        void GeneratePulseDescriptorData();
    }
}