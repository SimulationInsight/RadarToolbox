namespace SimulationInsight.MathLibrary;

public static class SignalGenerator
{
    public static Signal RectangularPulsedSignal(double RFFrequencyCentre, double sampleRate, double pulseWidth, double endTime)
    {
        var nSamples = (int)(endTime * sampleRate);

        var nSamplesOn = (int)(pulseWidth * sampleRate);

        var I = new double[nSamples];
        var Q = new double[nSamples];

        for (int i = 0; i < nSamplesOn; i++)
        {
            I[i] = 1.0;
        }

        var signal = new Signal()
        {
            RFFrequencyCentre = RFFrequencyCentre,
            SampleRate = sampleRate,
            I = I,
            Q = Q
        };

        return signal;
    }
}