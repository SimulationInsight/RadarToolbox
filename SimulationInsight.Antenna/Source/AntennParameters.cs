using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationInsight.MathLibrary;

namespace SimulationInsight.Antenna;

public class AntennaParameters
{
    public double Gain
    {
        get;
        set;
    }

    public double Gain_dB
    {
        get => Gain.PowerToDecibels();
        set => Gain = value.DecibelsToPower();
    }
}
