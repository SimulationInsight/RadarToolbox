using static SimulationInsight.RadarLibrary.RadarDetectionModelFunctions;

namespace SimulationInsight.RadarLibrary;

public class RadarDetectionModel
{
    public RadarDetectionModelInputs Inputs
    {
        get; set;
    }

    public RadarDetectionModelOutputs Outputs
    {
        get; set;
    }

    public RadarDetectionModel()
    {
    }

    public void Run()
    {
        var signalPower = CalculateSignalPower(Inputs);

        var noisePower = CalculateNoisePower(Inputs);

        var signalToNoiseRatio = signalPower / noisePower;

        Outputs = new RadarDetectionModelOutputs()
        {
            SignalPower = signalPower,
            NoisePower = noisePower,
            SignalToNoiseRatio = signalToNoiseRatio
        };
    }
}