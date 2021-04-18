namespace SimulationInsight.MathLibrary
{
    public record LLA
    {
        public double LatitudeDeg { get; init; }

        public double LongitudeDeg { get; init; }

        public double Altitude { get; init; }
    }
}