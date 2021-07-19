using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMData.Entities
{
    [Table("PulseDescriptor")]
    public class PulseDescriptor
    {
        public int PulseDescriptorId { get; set; }

        public int PulseNumber { get; set; }

        public double PulseTimeStart { get; set; }

        public double PulseTimeEnd { get; set; }

        public double PulseWidth { get; set; }

        public double PulseModulationType { get; set; }

        public double FrequencyStart { get; set; }

        public double FrequencyEnd { get; set; }

        public double FrequencyRampRate { get; set; }

        public double SignalPower { get; set; }

        public double SignalToNoiseRatio { get; set; }

        public double AzimuthAngleDeg { get; set; }

        public double ElevationAngleDeg { get; set; }

        public List<IQSample> IQSamples { get; set; }

        public int TrackId { get; set; }
        public Track Track { get; set; }
    }
}
