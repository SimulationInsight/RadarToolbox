using SimulationInsight.ESMLibrary;

namespace SimulationInsight.ESMPulseDescriptorGenerator
{
    public interface IESMPulseDescriptorGenerator
    {
        ESMPulseDescriptorGeneratorInputs Inputs { get; set; }

        PulseDescriptorData PulseDescriptorData { get; set; }

        void GeneratePulseDescriptorData();

        void WritePulseDescriptorData(string fileName);
    }
}