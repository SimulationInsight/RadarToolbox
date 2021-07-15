using System.Collections.Generic;
using SimulationInsight.MathLibrary;

namespace SimulationInsight.ESMLibrary
{
    public class IQSignal
    {
        public List<IQSample> Samples { get; set; }

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
            Samples = new List<IQSample>();

            for (int i = 0; i < time.Length; i++)
            {
                var s = new IQSample() 
                { 
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

        public void CalculateInstantaneousFrequency()
        {
            for (int i = 0; i < Samples.Count-1; i++)
            {
                var phaseDiff = Samples[i + 1].Phase - Samples[i].Phase;

                var frequency = phaseDiff / SampleInterval;

                frequency += RFFrequencyOffset;

                Samples[i].InstantaneousFrequency = frequency;
            }
        }
    }
}