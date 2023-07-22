using CommunityToolkit.Mvvm.ComponentModel;
using SimulationInsight.Antenna;
using SimulationInsight.MathLibrary;
using SimulationInsight.RadarCalculator.ViewModels;
using SimulationInsight.RadarLibrary;

namespace SimulationInsight.RadarCalculator.Models;

public class TransmitterModel : TransmitterModelBase
{
    public TransmitterModel(TransmitterParameters transmitterParameters, WaveformParameters waveformParameters, AntennaParameters antennaParameters)
    {
        WaveformParameters = waveformParameters;
        TransmitterParameters = transmitterParameters;
        AntennaParameters = antennaParameters;
    }
}