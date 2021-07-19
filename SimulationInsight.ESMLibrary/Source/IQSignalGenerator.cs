using SimulationInsight.ESMData.Models;
using SimulationInsight.MathLibrary;
using static SimulationInsight.MathLibrary.Vector;

namespace SimulationInsight.ESMLibrary
{
    public static class IQSignalGenerator
    {
        public static IQSignal GenerateRectangularPulse(double sampleRate, double pulseWidth, double amplitude)
        {
            var sampleInterval = 1.0 / sampleRate;

            var time = Vector.LinearlySpacedVector(0.0, pulseWidth, sampleInterval);

            var I = new Vector(time.NumberOfElements, amplitude);
            var Q = new Vector(time.NumberOfElements);

            var signal = new IQSignal(time, I, Q);

            return signal;
        }

        public static IQSignal GenerateLFMPulse(double sampleRate, double pulseWidth, double amplitude, double frequencyStart, double frequencyBandwidth)
        {
            var sampleInterval = 1.0 / sampleRate;

            var f0 = frequencyStart;
            var beta = frequencyBandwidth / pulseWidth;

            var time = LinearlySpacedVector(0.0, pulseWidth, sampleInterval);

            var timeSquared = time * time;

            var r = new Vector(time.NumberOfElements, amplitude);
            var theta = beta * timeSquared + f0 * time;

            var I = r * Cos(theta);
            var Q = r * Sin(theta);

            var signal = new IQSignal(time, I, Q);

            return signal;
        }

        public static IQSignal GenerateSignalFromPulseDescriptor(PulseDescriptorDTO p, double sampleRate)
        {
            var frequencyStart = 0.0;

            var signal = GenerateLFMPulse(sampleRate, p.PulseWidth, p.SignalAmplitude, frequencyStart, p.FrequencyBandwidth);

            return signal;
        }
    }
}
