namespace SimulationInsight.MathLibrary
{
    public record Vector
    {
        public int NumberOfElements => Data.Length;

        public double[] Data { get; init; }

        public Vector(int numberOfElements)
        {
            Data = new double[numberOfElements];
        }
    }
}