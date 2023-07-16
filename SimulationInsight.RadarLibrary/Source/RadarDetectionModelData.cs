namespace SimulationInsight.RadarLibrary;

public record RadarDetectionModelData
{
    public RadarDetectionModelInputs Inputs { get; set; }

    public RadarDetectionModelOutputs Outputs { get; set; }
}