﻿using SimulationInsight.RadarFunctions;

namespace SimulationInsight.RadarLibrary;

internal static class RadarDetectionModelFunctions
{
    public static double CalculateSignalPower(RadarDetectionModelInputs inputs)
    {
        var i = inputs;
        var w = inputs.WaveformParameters;

        var signalPower = RadarRangeEquationFunctions.CalculateSignalPower(w.RfFrequencyCentre, i.TransmitPeakPower, w.PulseWidth, i.TransmitGain, i.ReceiveGain, w.NumberOfPulses, i.TargetRange, i.TargetRadarCrossSection, i.SystemLosses);

        return signalPower;
    }

    public static double CalculateNoisePower(RadarDetectionModelInputs inputs)
    {
        var i = inputs;
        var w = inputs.WaveformParameters;

        var signalPower = RadarRangeEquationFunctions.CalculateNoisePower(w.PulseBandwidth, i.ReceiverNoiseFigure);

        return signalPower;
    }
}