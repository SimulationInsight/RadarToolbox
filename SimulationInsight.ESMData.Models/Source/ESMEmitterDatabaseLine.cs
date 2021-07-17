using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMData.Models
{
    public class ESMEmitterDatabaseLine
    {
        public string EmitterName { get; set; }

        public string ProfileName { get; set; }

        public double FrequencyMin_MHz { get; set; }

        public double FrequencyMax_MHz { get; set; }

        public double PulseBandwidthMin_MHz { get; set; }

        public double PulseBandwidthMax_MHz { get; set; }

        public double PulseWidthMin_us { get; set; }

        public double PulseWidthMax_us { get; set; }

        public double PulseRepetitionFrequencyMin_Hz { get; set; }

        public double PulseRepetitionFrequencyMax_Hz { get; set; }

        public double ScanRateMin_RPM { get; set; }

        public double ScanRateMax_RPM { get; set; }
    }
}
