using SimulationInsight.MathLibrary;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Math;

namespace SimulationInsight.ESMData.Entities
{
    [Table("SpectrumSample")]
    public class SpectrumSample
    {
        public int SpectrumSampleId { get; set; }

        public int SampleNumber { get; set; }

        public double Frequency { get; set; }

        public double Real { get; set; }

        public double Imag { get; set; }

        public double Amplitude { get; set; }

        public double Power { get; set; }

        public double Power_dB { get; set; }

        public int PulseDescriptorId { get; set; }
        public PulseDescriptor PulseDescriptor { get; set; }
    }
}
