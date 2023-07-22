namespace SimulationInsight.MathLibrary;

public record RAE
{
    public double R
    {
        get; init;
    }

    public double A
    {
        get; init;
    }

    public double E
    {
        get; init;
    }

    public RAE()
    {
    }

    public RAE(double a, double e)
    {
        R = 1.0;
        A = a;
        E = e;
    }

    public RAE(double r, double a, double e)
    {
        R = r;
        A = a;
        E = e;
    }

    public RAE(double[] rae)
    {
        R = rae[0];
        A = rae[1];
        E = rae[2];
    }

    public RAE(Vector rae) : this(rae.Data)
    {
    }

    public double Magnitude()
    {
        return R;
    }

    public RAE UnitVector()
    {
        var unitVector = new RAE()
        {
            R = 1.0,
            A = A,
            E = E
        };

        return unitVector;
    }

    public XYZ ToXYZ()
    {
        var xyz = CoordinateConversions.RAEToXYZ(this);

        return xyz;
    }
}