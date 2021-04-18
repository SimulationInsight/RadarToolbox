namespace SimulationInsight.RadarLibrary
{
    public record ScanPatternData
    {
        public double RadarId { get; init; }

        public double ScanPatternType { get; init; }

        public double ScanId { get; init; }

        public double Time { get; init; }

        public double AzimuthAngleDemandDeg { get; init; }

        public double ElevationAngleDemandDeg { get; init; }

        public double AzimuthAngleDeg { get; init; }

        public double ElevationAngleDeg { get; init; }
    }
}