namespace SimulationInsight.Core
{
    public interface ISystemClock
    {
        DateTime DateTimeOrigin { get; set; }

        DateTime CurrentDateTime { get; }

        double CurrentTime { get; set; }

        double TimeStep { get; set; }

        void Initialise(double time);

        void Update();
    }
}