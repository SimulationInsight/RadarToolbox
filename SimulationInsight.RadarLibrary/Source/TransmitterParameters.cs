using SimulationInsight.MathLibrary;

namespace SimulationInsight.RadarLibrary;

public class TransmitterParameters
{
    public double TransmitPower
    {
        get;
        set;
    }

    public double TransmitPower_dB
    {
        get => TransmitPower.PowerToDecibels();
        set => TransmitPower = value.DecibelsToPower();
    }

    public double TransmitPower_dBm
    {
        get => TransmitPower_dB.dBTodBm();
        set => TransmitPower_dB = value.dBmTodB();
    }
}