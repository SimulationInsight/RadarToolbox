namespace SimulationInsight.MathLibrary;

public class Matrix
{
    public int NumberOfRows => Data.GetLength(0);

    public int NumberOfColumns => Data.GetLength(1);

    public double[,] Data { get; set; }

    public Matrix(int numberOFRows, int numberOfColumns)
    {
        Data = new double[numberOFRows, numberOfColumns];
    }

    public Matrix(double[,] data)
    {
        Data = data;
    }

    public double this[int rowIndex, int columnIndex]
    {
        get => Data[rowIndex, columnIndex];
        set => Data[rowIndex, columnIndex] = value;
    }
}