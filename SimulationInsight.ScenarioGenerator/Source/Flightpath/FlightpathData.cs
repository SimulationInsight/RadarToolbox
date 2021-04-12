namespace SimulationInsight.ScenarioGenerator
{
    public record FlightpathData
    {
        public int FlightpathId { get; init; }

        public int Time { get; init; }

        public int LatitudeDeg { get; init; }

        public int LongitudeDeg { get; init; }

        public int Altitude { get; init; }

        public int PositionNorth { get; init; }

        public int PositionEast { get; init; }

        public int PositionDown { get; init; }

        public int VelocityNorth { get; init; }

        public int VelocityEast { get; init; }

        public int VelocityDown { get; init; }

        public int TotalSpeed { get; init; }

        public int TotalSpeed_kts { get; init; }

        public int GroundSpeed { get; init; }

        public int GroundSpeed_kts { get; init; }

        public int AccelerationNorth { get; init; }

        public int AccelerationEast { get; init; }

        public int AccelerationDown { get; init; }

        public int AccelerationAxial { get; init; }

        public int AccelerationLateral { get; init; }

        public int AccelerationVetical { get; init; }

        public int HeadingAngleDeg { get; init; }

        public int PitchAngleDeg { get; init; }

        public int BankAngleDeg { get; init; }

        public int HeadingRateDeg { get; init; }

        public int PitchRateDeg { get; init; }

        public int BankRateDeg { get; init; }
    }
}