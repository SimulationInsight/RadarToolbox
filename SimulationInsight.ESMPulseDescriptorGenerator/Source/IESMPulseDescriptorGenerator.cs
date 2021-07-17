using SimulationInsight.ESMData.Models;
using SimulationInsight.ESMLibrary;

namespace SimulationInsight.ESMPulseDescriptorGenerator
{
    public interface IESMPulseDescriptorGenerator
    {
        ESMPulseDescriptorGeneratorInputs Inputs { get; set; }

        ESMPulseDescriptorData PulseDescriptorData { get; set; }

        void GeneratePulseDescriptorData();

        void WritePulseDescriptorData(string fileName);
    }
}