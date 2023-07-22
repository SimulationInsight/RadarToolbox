namespace SimulationInsight.Antenna;

public abstract class AntennaPattern
{
    public AntennaPatternType AntennaPatternType
    {
        get; init;
    }

    public abstract double GetAntennaGain_dB(double azimuthAngleDeg, double elevationAngleDeg);
}