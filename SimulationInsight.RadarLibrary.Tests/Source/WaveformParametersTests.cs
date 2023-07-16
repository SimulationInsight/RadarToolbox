namespace SimulationInsight.RadarLibrary.Tests;

[TestClass]
public class WaveformParametersTests
{
    [TestMethod]
    public void CreateWaveformParameters()
    {
        // Arrange:

        // Act:
        var w = new WaveformParameters()
        {
            WaveformName = "Waveform_1",
            RfFrequencyCentre = 9.0e9,
            PulseWidth = 10.0e-6,
            PulseBandwidth = 50.0e6,
            PulseRepetitionFrequency = 1000.0,
            NumberOfPulses = 10
        };

        // Assert:
        Assert.AreEqual(w.PulseCompressionRatio, 500.0, 0.0001);
    }

    [TestMethod]
    public void CreateWaveformParameters2()
    {
        // Arrange:

        // Act:
        var w = new WaveformParameters()
        {
            WaveformName = "Waveform_1",
            RfFrequencyCentre = 9.0e9,
            PulseWidth = 10.0e-6,
            PulseBandwidth = 50.0e6,
            PulseRepetitionFrequency = 1000.0,
            NumberOfPulses = 10
        };

        // Assert:
        Assert.AreEqual(w.PulseCompressionRatio, 500.0, 0.0001);
    }

    [TestMethod]
    public void CreateWaveformParameters3()
    {
        // Arrange:

        // Act:
        var w = new WaveformParameters()
        {
            WaveformName = "Waveform_1",
            RfFrequencyCentre = 9.0e9,
            PulseWidth = 10.0e-6,
            PulseBandwidth = 50.0e6,
            PulseRepetitionFrequency = 1000.0,
            NumberOfPulses = 10
        };

        // Assert:
        Assert.AreEqual(w.PulseCompressionRatio, 550.0, 0.0001);
    }
}