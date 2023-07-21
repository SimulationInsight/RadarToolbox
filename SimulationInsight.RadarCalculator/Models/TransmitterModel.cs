
using CommunityToolkit.Mvvm.ComponentModel;
using SimulationInsight.RadarCalculator.ViewModels;
using SimulationInsight.RadarLibrary;

namespace SimulationInsight.RadarCalculator.Models;

public class TransmitterModel : ObservableObject
{
    private readonly WaveformParameters waveformParameters;

    public TransmitterViewModel ViewModel
    {
        get; set; 
    }

    public bool IsUpdateAll
    {
        get; set;
    }

    public TransmitterModel(WaveformParameters waveformParameters)
    {
        this.waveformParameters = waveformParameters;
    }

    public double RfFrequency
    {
        get => waveformParameters.RfFrequency;
        set
        {
            SetProperty(waveformParameters.RfFrequency, value, waveformParameters, (u, n) => u.RfFrequency = n);
            UpdateBindings();
        }
    }

    public double RfFrequency_GHz
    {
        get => waveformParameters.RfFrequency_GHz;
        set
        {
            SetProperty(waveformParameters.RfFrequency_GHz, value, waveformParameters, (u, n) => u.RfFrequency_GHz = n);
            UpdateBindings();
        }
    }

    public double RfFrequency_MHz
    {
        get => waveformParameters.RfFrequency_MHz;
        set
        {
            SetProperty(waveformParameters.RfFrequency_MHz, value, waveformParameters, (u, n) => u.RfFrequency_MHz = n);
            UpdateBindings();
        }
    }

    public double RfWavelength
    {
        get => waveformParameters.RfWavelength;
        set
        {
            SetProperty(waveformParameters.RfWavelength, value, waveformParameters, (u, n) => u.RfWavelength = n);
            UpdateBindings();
        }
    }

    public void UpdateBindings()
    {
        ViewModel.UpdateBindings();
    }
}