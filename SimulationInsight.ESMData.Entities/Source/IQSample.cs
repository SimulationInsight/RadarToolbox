using SimulationInsight.MathLibrary;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Math;

namespace SimulationInsight.ESMData.Entities
{
    [Table("IQSample")]
    public class IQSample
    {
        public int IQSampleId { get; set; }

        public int SampleNumber { get; set; }

        public double TimeStamp { get; set; }

        public double Time { get; set; }

        public double I { get; set; }

        public double Q { get; set; }

        public double Amplitude { get; set; }

        public double Power { get; set; }

        public double Phase { get; set; }

        public double PhaseUnwrapped { get; set; }

        public double PhaseDeg => Phase.ToDegrees();

        public double PhaseUnwrappedDeg => PhaseUnwrapped.ToDegrees();

        public double Power_dB { get; set; }

        public double InstantaneousFrequency { get; set; }

        public int PulseDescriptorId { get; set; }
        public PulseDescriptor PulseDescriptor { get; set; }
    }
}
