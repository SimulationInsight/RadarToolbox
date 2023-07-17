namespace SimulationInsight.MathLibrary;

public class Signal
{
    public double RFFrequencyCentre { get; set; }

    public double RFFrequencyMin => RFFrequencyCentre - SampleRate / 2.0;

    public double RFFrequencyMax => RFFrequencyCentre + SampleRate / 2.0;

    public double RFBandwidth => SampleRate;

    public double SampleRate { get; set; }

    public int NumberOfSamples => I.Length;

    public double StartTime => 0.0;

    public double EndTime => (NumberOfSamples - 1) / SampleRate;

    public double[] I { get; set; }

    public double[] Q { get; set; }

    public float[] GetSampleDataFloat()
    {
        var data = new float[NumberOfSamples * 2];

        for (int i = 0; i < NumberOfSamples; i++)
        {
            data[i * 2] = (float)I[i];
            data[i * 2 + 1] = (float)Q[i];
        }

        return data;
    }
}