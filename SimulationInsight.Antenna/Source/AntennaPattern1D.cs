using SimulationInsight.MathLibrary;

namespace SimulationInsight.Antenna;

public class AntennaPattern1D : AntennaPattern
{
    public Vector AzimuthDeg { get; set; }
    public Vector AzimuthGain_dB { get; set; }

    public Vector ElevationDeg { get; set; }
    public Vector ElevationGain_dB { get; set; }

    public Interpolation1D AzimuthInterpolant { get; set; }
    public Interpolation1D ElevationInterpolant { get; set; }

    public AntennaPattern1D()
    {
        AntennaPatternType = AntennaPatternType.AzimuthElevation1D;
    }

    public void Initialise()
    {
        AzimuthInterpolant = new Interpolation1D(AzimuthDeg, AzimuthGain_dB);
        ElevationInterpolant = new Interpolation1D(ElevationDeg, ElevationGain_dB);
    }

    public override double GetAntennaGain_dB(double azimuthAngleDeg, double elevationAngleDeg)
    {
        var azimuthGain_dB = AzimuthInterpolant.Interpolate(azimuthAngleDeg);
        var elevationGain_dB = ElevationInterpolant.Interpolate(elevationAngleDeg);

        var gain_dB = azimuthGain_dB + elevationGain_dB;

        return gain_dB;
    }
}