using System.Reflection.Metadata.Ecma335;
using static System.Math;

namespace SimulationInsight.RadarFunctions
{
    public static class RadarRangeEquationFunctions
    {
        public static double CalculateSignalPower(double transmitPower, double pulseWidth, double rfFrequency, double transmitGain, double receiveGain, double targetRange, double targetRCS, double systemLosses)
        {
            var rfWavelength = 3e8 / rfFrequency;

            var numerator = transmitPower * pulseWidth * transmitGain * rfWavelength * rfWavelength * targetRCS;
            var denominator = Pow((4 * PI), 3) * Pow(targetRange, 4) * systemLosses;

            var signalPower = numerator / denominator;

            return signalPower;
        }
    }
}