namespace SimulationInsight.RadarLibrary.Tests;

[TestClass]
public class RadarDetectionModelHarnessTests
{
    [TestMethod]
    public void Test_1()
    {
        // Arrange:
        var w = new WaveformParameters()
        {
            WaveformName = "Waveform_1",
            RfFrequency = 9.0e9,
            PulseWidth = 10.0e-6,
            PulseBandwidth = 50.0e6,
            PulseRepetitionFrequency = 1000.0,
            NumberOfPulses = 10
        };

        var inputs = new RadarDetectionModelInputs()
        {
            RfSystemType = RfSystemType.MonostaticRadar,
            WaveformParameters = w,
            TransmitPeakPower = 500.0,
            TransmitGain_dB = 32.0,
            ReceiveGain_dB = 32.0,
            ReceiverNoiseFigure_dB = 3.0,
            SystemLosses_dB = 5.0,
            TargetRange = 1.0,
            TargetRadarCrossSection = 10.0
        };

        var harnessInputs = new RadarDetectionModelHarnessInputs()
        {
            RadarDetectionModelInputs = inputs,
            TargetRangeMin = 100.0,
            TargetRangeMax = 100000.0,
            TargetRangeStep = 100.0
        };

        var harness = new RadarDetectionModelHarness()
        {
            RadarDetectionModelHarnessInputs = harnessInputs
        };

        // Act:
        harness.Run();

        // Assert:
        Assert.AreEqual(harness.RadarDetectionModelData.Count, 1000);
    }
}