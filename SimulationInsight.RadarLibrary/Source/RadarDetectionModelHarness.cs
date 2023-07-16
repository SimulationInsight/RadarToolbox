namespace SimulationInsight.RadarLibrary;

public class RadarDetectionModelHarness
{
    public RadarDetectionModelInputs DetectionModelInputs { get; set; }

    public RadarDetectionModel DetectionModel { get; set; }

    public double TargetRangeMin { get; set; }

    public double TargetRangeMax { get; set; }

    public double TargetRangeStep { get; set; }

    public List<RadarDetectionModelData> DetectionModelData { get; set; }

    public RadarDetectionModelHarness()
    {
    }

    public void Run()
    {
        DetectionModelData = new List<RadarDetectionModelData>();

        var range = TargetRangeMin;

        DetectionModel = new RadarDetectionModel();

        while (range <= TargetRangeMax)
        {
            var inputs = DetectionModelInputs with { TargetRange = range };

            DetectionModel.Inputs = inputs;

            DetectionModel.Run();

            var data = new RadarDetectionModelData()
            {
                Inputs = DetectionModel.Inputs,
                Outputs = DetectionModel.Outputs
            };

            DetectionModelData.Add(data);

            range += TargetRangeStep;
        }
    }
}