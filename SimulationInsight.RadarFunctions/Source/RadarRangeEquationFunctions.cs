﻿using SimulationInsight.MathLibrary;
using static SimulationInsight.MathLibrary.PhysicalConstants;
using static System.Math;

namespace SimulationInsight.RadarFunctions;

public static class RadarRangeEquationFunctions
{
    public static double CalculateSignalPower(double transmitPower, double pulseWidth, double rfFrequency, double transmitGain, double receiveGain, double targetRange, double targetRcs, double systemLosses)
    {
        var rfWavelength = 3e8 / rfFrequency;

        var numerator = transmitPower * pulseWidth * transmitGain * receiveGain * rfWavelength * rfWavelength * targetRcs;
        var denominator = Pow((4 * PI), 3) * Pow(targetRange, 4) * systemLosses;

        var signalPower = numerator / denominator;

        return signalPower;
    }

    public static double CalculateSignalPower_dB(double transmitPower, double pulseWidth, double rfFrequency, double transmitGain_dB, double receiveGain_dB, double targetRange, double targetRcs, double systemLosses_dB)
    {
        var transmitGain = transmitGain_dB.DecibelsToPower();
        var receiveGain = receiveGain_dB.DecibelsToPower();
        var systemLosses = systemLosses_dB.DecibelsToPower();

        var signalPower = CalculateSignalPower(transmitPower, pulseWidth, rfFrequency, transmitGain, receiveGain, targetRange, targetRcs, systemLosses);
    
        var signalPower_dB = signalPower.PowerToDecibels();

        return signalPower_dB;
    }

    public static double CalculateSignalPower_dBm(double transmitPower, double pulseWidth, double rfFrequency, double transmitGain_dB, double receiveGain_dB, double targetRange, double targetRcs, double systemLosses_dB)
    {
        var transmitGain = transmitGain_dB.DecibelsToPower();
        var receiveGain = receiveGain_dB.DecibelsToPower();
        var systemLosses = systemLosses_dB.DecibelsToPower();

        var signalPower = CalculateSignalPower(transmitPower, pulseWidth, rfFrequency, transmitGain, receiveGain, targetRange, targetRcs, systemLosses);

        var signalPower_dBm = signalPower.PowerToDecibels().dBTodBm();

        return signalPower_dBm;
    }

    public static double CalculateNoiseTemperature(double noiseFigure)
    {
        var noiseTemperature = NoiseReferenceTemperature * noiseFigure;

        return noiseTemperature;
    }

    public static double CalculateNoisePower(double noiseBandwidth, double noiseFigure)
    {
        var noisePower = BoltzmannConstant * NoiseReferenceTemperature * noiseFigure * noiseBandwidth;

        return noisePower;
    }

    public static double CalculateNoisePower_dB(double noiseBandwidth, double noiseFigure_dB)
    {
        var noiseFigure = noiseFigure_dB.DecibelsToPower();

        var noisePower = BoltzmannConstant * NoiseReferenceTemperature * noiseBandwidth * noiseFigure;

        var noisePower_dB = noisePower.PowerToDecibels();

        return noisePower_dB;
    }

    public static double CalculateNoisePower_dBm(double noiseBandwidth, double noiseFigure_dB)
    {
        var noisePower_dB = CalculateNoisePower_dB(noiseBandwidth, noiseFigure_dB);

        var noisePower_dBm = noisePower_dB.dBTodBm();

        return noisePower_dBm;
    }

    public static double CalculateAtmosphericLoss_dB(double atmosphericLoss_dBPerKm, double targetRange)
    {
        var atmosphericLoss_dB = atmosphericLoss_dBPerKm * targetRange;

        return atmosphericLoss_dB;
    }
}