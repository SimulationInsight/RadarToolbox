using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.SimdisInterface;

public record SimdisPlatformData
{
    public double Time
    {
        get;
        set;
    }

    public double LatitudeDeg
    {
        get;
        set;
    }

    public double LongitudeDeg
    {
        get;
        set;
    }

    public double Altitude
    {
        get;
        set;
    }

    public double HeadingAngleDeg
    {
        get;
        set;
    }

    public double PitchAngleDeg
    {
        get;
        set;
    }

    public double RollAngleDeg
    {
        get;
        set;
    }

    public double VelocityNorth
    {
        get;
        set;
    }

    public double VelocityEast
    {
        get;
        set;
    }

    public double VelocityDown
    {
        get;
        set;
    }
}
