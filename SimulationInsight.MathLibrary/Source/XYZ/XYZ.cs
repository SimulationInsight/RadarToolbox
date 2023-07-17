using static System.Math;

namespace SimulationInsight.MathLibrary;

public record XYZ
{
    public double X { get; init; }

    public double Y { get; init; }

    public double Z { get; init; }

    public XYZ()
    {
    }

    public XYZ(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public XYZ(double[] xyz)
    {
        X = xyz[0];
        Y = xyz[1];
        Z = xyz[2];
    }

    public XYZ(Vector xyz) : this(xyz.Data)
    {
    }

    public double Magnitude()
    {
        var magnitudeSquared = (X * X + Y * Y + Z * Z);

        var magnitude = Sqrt(magnitudeSquared);

        return magnitude;
    }

    public XYZ UnitVector()
    {
        var magnitude = Magnitude();

        var unitVector = new XYZ()
        {
            X = X / magnitude,
            Y = Y / magnitude,
            Z = Z / magnitude
        };

        return unitVector;
    }

    public Vector ToVector()
    {
        var result = new Vector(X, Y, Z);

        return result;
    }

    public RAE ToRAE()
    {
        var rae = CoordinateConversions.XYZToRAE(this);

        return rae;
    }

    public LLA ToLLA(LLA positionOrigin)
    {
        var lla = LLAConversions.ConvertXYZToLLA(this, positionOrigin);
        return lla;
    }

    public static XYZ operator *(XYZ xyz, double x)
    {
        var result = new XYZ()
        {
            X = xyz.X * x,
            Y = xyz.Y * x,
            Z = xyz.Z * x
        };

        return result;
    }

    public static XYZ operator *(double x, XYZ xyz)
    {
        var result = xyz * x;

        return result;
    }

    public static XYZ operator *(Matrix a, XYZ xyz)
    {
        var x = xyz.ToVector();
        var b = a * x;
        var y = new XYZ(b);

        return y;
    }

    public static XYZ operator +(XYZ xyz1, XYZ xyz2)
    {
        var result = new XYZ()
        {
            X = xyz1.X + xyz2.X,
            Y = xyz1.Y + xyz2.Y,
            Z = xyz1.Z + xyz2.Z
        };

        return result;
    }
}