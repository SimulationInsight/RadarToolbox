using SimulationInsight.MathLibrary;

namespace SimulationInsight.Radar;

public class Scanner : IScanner
{
    public double MaximumAzimuthAccelerationDeg { get; set; }

    public double AzimuthAccelerationConstant { get; set; }

    public ScanPattern ScanPattern { get; set; }

    public ScanData ScanData { get; set; }

    public Scanner()
    {
        MaximumAzimuthAccelerationDeg = 10.0;
    }

    public void SetScanPattern(ScanPattern scanPattern)
    {
        ScanPattern = scanPattern;
    }

    public void Initialise(double time)
    {
        ScanData = ScanData with { Time = time };
    }

    public void Update(double time)
    {
        var dt = time - ScanData.Time;

        var azimuthScanRateError = ScanPattern.AzimuthScanRateDeg - ScanData.AzimuthAngleRateDeg;

        var azimuthScanAcceleration = azimuthScanRateError * AzimuthAccelerationConstant;

        azimuthScanAcceleration = azimuthScanAcceleration.LimitAbsoluteValue(MaximumAzimuthAccelerationDeg);

        var azimuthAngleRateDeg = ScanData.AzimuthAngleRateDeg + azimuthScanAcceleration * dt;

        var azimuthAngleDeg = ScanData.AzimuthAngleDeg + azimuthAngleRateDeg * dt;

        azimuthAngleDeg = azimuthAngleDeg.ConstrainAngleDegTo0To360();

        ScanData = ScanData with { Time = time, AzimuthAngleDeg = azimuthAngleDeg, AzimuthAngleRateDeg = azimuthAngleRateDeg };
    }

    public void Finalise(double time)
    {
    }
}
