using static System.Math;

namespace SimulationInsight.MathLibrary;

public record NED
{
    public double N { get; init; }

    public double E { get; init; }

    public double D { get; init; }

    public NED()
    {
    }

    public NED(double n, double e, double d)
    {
        N = n;
        E = e;
        D = d;
    }

    public double Magnitude()
    {
        var magnitudeSquared = N * N + E * E + D * D;

        var magnitude = Sqrt(magnitudeSquared);

        return magnitude;
    }

    public static NED operator +(NED x, NED y)
    {
        var result = new NED()
        {
            N = x.N + y.N,
            E = x.E + y.E,
            D = x.D + y.D
        };

        return result;
    }

    public static NED operator -(NED x, NED y)
    {
        var result = new NED()
        {
            N = x.N - y.N,
            E = x.E - y.E,
            D = x.D - y.D
        };

        return result;
    }

    public static NED operator *(NED x, double y)
    {
        var result = new NED()
        {
            N = x.N * y,
            E = x.E * y,
            D = x.D * y
        };

        return result;
    }

    public static NED operator /(NED x, double y)
    {
        var result = x * 1.0 / y;

        return result;
    }
}