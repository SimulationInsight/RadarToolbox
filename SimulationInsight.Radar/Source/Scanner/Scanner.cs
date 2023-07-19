using SimulationInsight.MathLibrary;
using SimulationInsight.SystemMessages;
using Wolverine;
using Wolverine.Attributes;

namespace SimulationInsight.Radar;

public class Scanner : IScanner
{
    public double MaximumAzimuthAccelerationDeg { get; set; }

    public double AzimuthAccelerationConstant { get; set; }

    public ScanPattern ScanPattern { get; set; }

    public ScanData ScanData { get; set; }

    public IMessageBus Bus { get; set; }

    public int MessageId { get; set; }

    public Scanner(IMessageBus bus)
    {
        MaximumAzimuthAccelerationDeg = 10.0;
        AzimuthAccelerationConstant = 5.0;

        Bus = bus;
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

        SendScanDataMessage();
    }

    public void SendScanDataMessage()
    {
        MessageId++;

        var scanDataMessage = new ScanDataMessage()
        {
            MessageId = MessageId,
            MessageTime = ScanData.Time,
            ScanData = ScanData
        };

        Bus.PublishAsync(scanDataMessage);
    }

    public void Finalise(double time)
    {
    }
}