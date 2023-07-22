using SimulationInsight.Core;

namespace SimulationInsight.Radar;

public interface IRadar : IExecutableModel
{
    IScanner Scanner
    {
        get; set;
    }
}