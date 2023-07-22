using CommunityToolkit.Mvvm.ComponentModel;
using SimulationInsight.Antenna;
using SimulationInsight.MathLibrary;
using SimulationInsight.RadarCalculator.ViewModels;
using SimulationInsight.RadarLibrary;

namespace SimulationInsight.RadarCalculator.Models;

public class WaveformModel : TransmitterModelBase
{
    public WaveformModel(TransmitterParameters transmitterParameters, WaveformParameters waveformParameters, AntennaParameters antennaParameters)
    {
        WaveformParameters = waveformParameters;
        TransmitterParameters = transmitterParameters;
        AntennaParameters = antennaParameters;
    }
}