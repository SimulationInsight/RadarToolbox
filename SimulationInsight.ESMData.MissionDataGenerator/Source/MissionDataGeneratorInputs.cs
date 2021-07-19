using SimulationInsight.ESMPulseDescriptorGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMData.MissionDataGenerator
{
    public class MissionDataGeneratorInputs
    {
        public int MissionNumber { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public List<ESMPulseDescriptorGeneratorInputs> PulseDescriptorGeneratorInputs { get; set; }

        public bool IsGenerateIQSignals { get; set; }

        public double SampleRate { get; set; }

        public bool IsSaveMissionToDatabase { get; set; }
    }
}
