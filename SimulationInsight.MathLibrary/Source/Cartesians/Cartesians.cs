namespace SimulationInsight.MathLibrary;

public record Cartesians
{
    public double PositionX { get; init; }

    public double PositionY { get; init; }

    public double PositionZ { get; init; }

    public double VelocityX { get; init; }

    public double VelocityY { get; init; }

    public double VelocityZ { get; init; }

    public Cartesians()
    {
    }

    public Cartesians(double positionX, double positionY, double positionZ, double velocityX, double velocityY, double velocityZ)
    {
        PositionX = positionX;
        PositionY = positionY;
        PositionZ = positionZ;
        VelocityX = velocityX;
        VelocityY = velocityY;
        VelocityZ = velocityZ;
    }

    public Cartesians(double[] x)
    {
        PositionX = x[0];
        PositionY = x[1];
        PositionZ = x[2];
        VelocityX = x[3];
        VelocityY = x[4];
        VelocityZ = x[5];
    }

    public Cartesians(Vector x) : this(x.Data)
    {
    }

    public Cartesians(XYZ position, XYZ velocity)
    {
        PositionX = position.X;
        PositionY = position.Y;
        PositionZ = position.Z;
        VelocityX = velocity.X;
        VelocityY = velocity.Y;
        VelocityZ = velocity.Z;
    }

    public static Cartesians operator +(Cartesians a, Cartesians b)
    {
        var positionX = a.PositionX + b.PositionX;
        var positionY = a.PositionY + b.PositionY;
        var positionZ = a.PositionZ + b.PositionZ;
        var velocityX = a.VelocityX + b.VelocityX;
        var velocityY = a.VelocityY + b.VelocityY;
        var velocityZ = a.VelocityZ + b.VelocityZ;

        var result = new Cartesians(positionX, positionY, positionZ, velocityX, velocityY, velocityZ);

        return result;
    }

    public static Cartesians operator -(Cartesians a, Cartesians b)
    {
        var positionX = a.PositionX - b.PositionX;
        var positionY = a.PositionY - b.PositionY;
        var positionZ = a.PositionZ - b.PositionZ;
        var velocityX = a.VelocityX - b.VelocityX;
        var velocityY = a.VelocityY - b.VelocityY;
        var velocityZ = a.VelocityZ - b.VelocityZ;

        var result = new Cartesians(positionX, positionY, positionZ, velocityX, velocityY, velocityZ);

        return result;
    }

    public double[] ToArray()
    {
        var array = new double[] { PositionX, PositionY, PositionZ, VelocityX, VelocityY, VelocityZ };

        return array;
    }

    public Vector ToVector()
    {
        var vector = new Vector(PositionX, PositionY, PositionZ, VelocityX, VelocityY, VelocityZ);

        return vector;
    }

    public Polars ToPolars()
    {
        var polars = CoordinateConversions.CartesiansToPolars(this);

        return polars;
    }

    public Matrix JacobianPolarsWrtCartesians()
    {
        var j = CoordinateConversions.JacobianPolarsWrtCartesians(this);

        return j;
    }
}