﻿using SimulationInsight.MathLibrary;
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

    public int ScanIndex { get; set; }

    public Scanner(IMessageBus bus)
    {
        Bus = bus;

        MaximumAzimuthAccelerationDeg = 10.0;
        AzimuthAccelerationConstant = 5.0;

        ScanIndex = 1;
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

        if (azimuthAngleDeg > 360.0)
        {
            ScanIndex++;
            azimuthAngleDeg = azimuthAngleDeg.ConstrainAngleDegTo0To360();

            SendAzimuthChangePulseMessage();
        }

        ScanData = ScanData with { Time = time, ScanIndex = ScanIndex, AzimuthAngleDeg = azimuthAngleDeg, AzimuthAngleRateDeg = azimuthAngleRateDeg };

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

    public void SendAzimuthChangePulseMessage()
    {

    }

    public void Finalise(double time)
    {
    }
}