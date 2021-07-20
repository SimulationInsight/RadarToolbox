using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;
using SimulationInsight.MathLibrary;
using static System.Math;
using Vector = SimulationInsight.MathLibrary.Vector;

namespace SimulationInsight.ESMData.Models
{
    public record IQSignal
    {
        public List<IQSampleDTO> Samples { get; set; }

        public List<SpectrumSampleDTO> SpectrumSamples { get; set; }

        public int NumberOfSamples => Samples.Count;

        public double StartTime => Samples[0].Time;

        public double EndTime => Samples[^1].Time;

        public double TimeSpan => EndTime - StartTime;

        public double SampleInterval => GetSampleInterval();

        public double SampleRate => 1.0 / SampleInterval;

        public double RFFrequencyOffset { get; set; }

        public IQSignal()
        { 
        }

        public IQSignal(Vector time, Vector I, Vector Q) : this(time.Data, I.Data, Q.Data)
        { 
        }

        public IQSignal(double[] time, double[] I, double[] Q)
        {
            Samples = new List<IQSampleDTO>();

            for (int i = 0; i < time.Length; i++)
            {
                var s = new IQSampleDTO() 
                { 
                    SampleNumber = i,
                    Time = time[i], 
                    I = I[i], 
                    Q = Q[i] 
                };

                Samples.Add(s);
            }
        }

        public double GetSampleInterval()
        {
            var result = TimeSpan / (NumberOfSamples - 1);

            return result;
        }

        public void CalculatePhaseUnwrapped()
        {
            var phaseOffset = 0.0;

            Samples[0].PhaseUnwrapped = Samples[0].Phase;

            for (int i = 0; i < Samples.Count - 1; i++)
            {
                var phaseDiff = Samples[i + 1].Phase - Samples[i].Phase;

                if (phaseDiff < -PI)
                {
                    phaseOffset += 2.0 * PI;
                }

                Samples[i + 1].PhaseUnwrapped = Samples[i + 1].Phase + phaseOffset;
            }
        }

        public void CalculateInstantaneousFrequency()
        {
            CalculatePhaseUnwrapped();

            for (int i = 0; i < Samples.Count - 1; i++)
            {
                var phaseDiff = Samples[i + 1].PhaseUnwrapped - Samples[i].PhaseUnwrapped;

                var frequency = phaseDiff / SampleInterval / (2 * PI);

                frequency += RFFrequencyOffset;

                Samples[i].InstantaneousFrequency = frequency;
            }

            Samples[^1].InstantaneousFrequency = Samples[^2].InstantaneousFrequency;
        }

        public void CalculateFrequencySpectrum()
        {
            SpectrumSamples = new List<SpectrumSampleDTO>();

            var samples = Samples.Select(s => new Complex(s.I, s.Q)).ToArray();

            Fourier.Forward(samples);

            var frequency = Vector.LinearlySpacedVector(0.0, SampleRate, SampleRate / samples.Count());

            frequency += RFFrequencyOffset;

            for (int i = 0; i < samples.Length; i++)
            {
                var spectrumSample = new SpectrumSampleDTO()
                {
                    SampleNumber = i,
                    Frequency = frequency[i],
                    Real = samples[i].Real,
                    Imag = samples[i].Imaginary
                };

                SpectrumSamples.Add(spectrumSample);
            }
        }

        public static IQSignal operator +(IQSignal x, IQSignal y)
        {
            var time = x.GetTimeVector();
            var Ix = x.GetIVector();
            var Iy = y.GetIVector();
            var Qx = x.GetQVector();
            var Qy = y.GetQVector();

            var I = Ix + Iy;
            var Q = Qx + Qy;

            var signal = new IQSignal(time, I, Q);

            signal.RFFrequencyOffset = x.RFFrequencyOffset;

            return signal;
        }

        public static IQSignal operator *(IQSignal x, double y)
        {
            var samples = x.Samples.Select(s => s with { I = s.I * y, Q = s.Q * y }).ToList();

            var iqSignal = x with { Samples = samples };

            return iqSignal;
        }

        public Vector GetTimeVector()
        {
            var time = Samples.Select(s => s.Time).ToArray();

            var timeVector = new Vector(time);

            return timeVector;
        }

        public Vector GetIVector()
        {
            var I = Samples.Select(s => s.I).ToArray();

            var IVector = new Vector(I);

            return IVector;
        }

        public Vector GetQVector()
        {
            var Q = Samples.Select(s => s.Q).ToArray();

            var QVector = new Vector(Q);

            return QVector;
        }
    }
}