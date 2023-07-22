using CommunityToolkit.Mvvm.ComponentModel;
using SimulationInsight.Antenna;
using SimulationInsight.MathLibrary;
using SimulationInsight.RadarCalculator.ViewModels;
using SimulationInsight.RadarLibrary;

namespace SimulationInsight.RadarCalculator.Models;

public class WaveformModel : ObservableObject
{
    public TransmitterParameters TransmitterParameters
    {
        get; set;
    }

    public WaveformParameters WaveformParameters
    {
        get; set;
    }

    public AntennaParameters AntennaParameters
    {
        get; set;
    }

    public WaveformViewModel ViewModel
    {
        get; set;
    }

    public WaveformModel(TransmitterParameters transmitterParameters, WaveformParameters waveformParameters, AntennaParameters antennaParameters)
    {
        WaveformParameters = waveformParameters;
        TransmitterParameters = transmitterParameters;
        AntennaParameters = antennaParameters;
    }

    public string IeeeBand => RadarFunctions.RadarFunctions.GetIeeeRadarBand(RfFrequency_GHz);

    public string NatoBand => RadarFunctions.RadarFunctions.GetNatoRadarBand(RfFrequency_GHz);

    public double RfFrequency
    {
        get => WaveformParameters.RfFrequency;
        set
        {
            SetProperty(WaveformParameters.RfFrequency, value, WaveformParameters, (u, n) => u.RfFrequency = n);
            UpdateBindings();
        }
    }

    public double RfFrequency_GHz
    {
        get => WaveformParameters.RfFrequency_GHz;
        set
        {
            SetProperty(WaveformParameters.RfFrequency_GHz, value, WaveformParameters, (u, n) => u.RfFrequency_GHz = n);
            UpdateBindings();
        }
    }

    public double RfFrequency_MHz
    {
        get => WaveformParameters.RfFrequency_MHz;
        set
        {
            SetProperty(WaveformParameters.RfFrequency_MHz, value, WaveformParameters, (u, n) => u.RfFrequency_MHz = n);
            UpdateBindings();
        }
    }

    public double RfFrequency_kHz
    {
        get => WaveformParameters.RfFrequency_kHz;
        set
        {
            SetProperty(WaveformParameters.RfFrequency_kHz, value, WaveformParameters, (u, n) => u.RfFrequency_kHz = n);
            UpdateBindings();
        }
    }

    public double RfWavelength
    {
        get => WaveformParameters.RfWavelength;
        set
        {
            SetProperty(WaveformParameters.RfWavelength, value, WaveformParameters, (u, n) => u.RfWavelength = n);
            UpdateBindings();
        }
    }

    public double RfWavelength_cm
    {
        get => WaveformParameters.RfWavelength_cm;
        set
        {
            SetProperty(WaveformParameters.RfWavelength_cm, value, WaveformParameters, (u, n) => u.RfWavelength_cm = n);
            UpdateBindings();
        }
    }

    public double RfWavelength_mm
    {
        get => WaveformParameters.RfWavelength_mm;
        set
        {
            SetProperty(WaveformParameters.RfWavelength_mm, value, WaveformParameters, (u, n) => u.RfWavelength_mm = n);
            UpdateBindings();
        }
    }

    public double TransmitPower
    {
        get => TransmitterParameters.TransmitPower;
        set
        {
            SetProperty(TransmitterParameters.TransmitPower, value, TransmitterParameters, (u, n) => u.TransmitPower = n);
            UpdateBindings();
        }
    }

    public double TransmitPower_dB
    {
        get => TransmitterParameters.TransmitPower_dB;
        set
        {
            SetProperty(TransmitterParameters.TransmitPower_dB, value, TransmitterParameters, (u, n) => u.TransmitPower_dB = n);
            UpdateBindings();
        }
    }

    public double TransmitPower_dBm
    {
        get => TransmitterParameters.TransmitPower_dBm;
        set
        {
            SetProperty(TransmitterParameters.TransmitPower_dBm, value, TransmitterParameters, (u, n) => u.TransmitPower_dBm = n);
            UpdateBindings();
        }
    }

    public double AntennaGain
    {
        get => AntennaParameters.Gain;
        set
        {
            SetProperty(AntennaParameters.Gain, value, AntennaParameters, (u, n) => u.Gain = n);
            UpdateBindings();
        }
    }

    public double AntennaGain_dB
    {
        get => AntennaParameters.Gain_dB;
        set
        {
            SetProperty(AntennaParameters.Gain_dB, value, AntennaParameters, (u, n) => u.Gain_dB = n);
            UpdateBindings();
        }
    }

    public double Eirp => TransmitPower * AntennaGain;

    public double Eirp_dB => Eirp.PowerToDecibels();

    public double Eirp_dBm => Eirp_dB.dBTodBm();

    public void UpdateBindings()
    {
        ViewModel.UpdateBindings();
    }
}