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

        public Vector(params double[] data)
        {
            Data = data;
        }

        public double this[int index]
        {
            get => Data[index];
            set => Data[index] = value;
        }

        public double GetCircularValue(int index)
        {
            var i = index % Data.Length;

            var x = Data[i];

            return x;
        }
    }
}