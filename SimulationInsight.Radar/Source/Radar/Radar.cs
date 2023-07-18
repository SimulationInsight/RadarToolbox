namespace SimulationInsight.Radar;

public class Radar : IRadar
{
    public IScanner Scanner { get; set; }

    public Radar(IScanner scanner)
    {
        Scanner = scanner;
    }

    public void Initialise(double time)
    {
        Scanner.Initialise(time);
    }

    public void Update(double time)
    {
        Scanner.Update(time);
    }

    public void Finalise(double time)
    {
        Scanner.Finalise(time);
    }
}