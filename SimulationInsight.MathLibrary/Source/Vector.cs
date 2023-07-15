namespace SimulationInsight.MathLibrary;

public class Vector
{
    public int NumberOfElements => Data.Length;

    public double[] Data { get; set; }

    public Vector(int numberOfElements)
    {
        Data = new double[numberOfElements];
    }

    public Vector(params double[] data)
    {
        Data = data;
    }

    public double this[int index]
    {
        get => Data[index];
        set => Data[index] = value;
    }
}