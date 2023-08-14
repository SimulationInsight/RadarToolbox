namespace SimulationInsight.MathLibrary.Tests
{
    [TestClass]
    public class SignalGeneratorTests
    {
        [DataTestMethod]
        [DataRow(1000.0e6, 92.0e6, 10.0e-6, 100.0e-6)]
        [DataRow(2000.0e6, 92.0e6, 10.0e-6, 100.0e-6)]
        [DataRow(2400.0e6, 50.0e6, 10.0e-6, 100.0e-6)]
        [DataRow(2400.0e6, 55.7e6, 20.6e-6, 145.1e-6)]
           public void RectangularPulsedSignal(double rfFrequencyCentre, double sampleRate, double pulseWidth, double endTime)
        {
            // Arrange:

            // Act:
            var x = SignalGenerator.RectangularPulsedSignal(rfFrequencyCentre, sampleRate, pulseWidth, endTime);

            // Assert:
            Assert.Inconclusive();
        }
    }
}