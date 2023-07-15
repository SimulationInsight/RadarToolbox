using static System.Math;

namespace SimulationInsight.RadarFunctions;

public static class RadarRangeEquationFunctions
{
    public static double CalculateSignalPower(double transmitPower, double pulseWidth, double rfFrequency, double transmitGain, double receiveGain, double targetRange, double targetRCS, double systemLosses)
    {
        var rfWavelength = 3e8 / rfFrequency;

        var numerator = transmitPower * pulseWidth * transmitGain * receiveGain * rfWavelength * rfWavelength * targetRCS;
        var denominator = Pow((4 * PI), 3) * Pow(targetRange, 4) * systemLosses;

        var signalPower = numerator / denominator;

        return signalPower;
    }

    public static double CalculateNoiseTemperature(double noiseFigure)
    {
        var standardTemperature = 290.0;

        var noiseTemperature = standardTemperature * noiseFigure;

        return noiseTemperature;
    }

    public static double CalculateNoisePower(double noiseBandwidth, double noiseFigure)
    {
        var k = 1.0;

        var standardTemperature = 290.0;

        var noisePower = k * standardTemperature * noiseFigure * noiseBandwidth;

        return noisePower;
    }
}