using SimulationInsight.MathLibrary;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Math;

namespace SimulationInsight.ESMData.Models
{
    public class SpectrumSampleDTO
    {
        public int SampleNumber { get; set; }

        public double Frequency { get; set; }

        public double Frequency_MHz => Frequency / 1.0e6;

        public double Real { get; set; }

        public double Imag { get; set; }

        public double Amplitude => Sqrt(Power);

        public double Power => Real * Real + Imag * Imag;

        public double Power_dB => Power.ToDecibels();
    }
}
