using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimulationInsight.RadarFunctions.Tests;

[TestClass]
public class RadarFunctionsTests
{
    [DataTestMethod]
    [DataRow(-1, "HF")]
    [DataRow(0, "HF")]
    [DataRow(0.01, "HF")]
    [DataRow(8, "X")]
    [DataRow(9, "X")]
    [DataRow(12, "Ku")]
    [DataRow(17, "Ku")]
    [DataRow(10000000000, "Undefined")]
    public void GetIeeeRadarBand(double rfFrequency_GHz, string ieeeBandExpected)
    {
        // Arrange

        // Act
        var ieeeBand = RadarFunctions.GetIeeeRadarBand(rfFrequency_GHz);

        // Assert
        Assert.AreEqual(ieeeBandExpected, ieeeBand);
    }

    [DataTestMethod]
    [DataRow(-1, "A")]
    [DataRow(0, "A")]
    [DataRow(0.1, "A")]
    [DataRow(0.25, "B")]
    [DataRow(2, "E")]
    [DataRow(2.5, "E")]
    [DataRow(3, "F")]
    [DataRow(10000000000, "Undefined")]
    public void GetNatoRadarBand(double rfFrequency_GHz, string ieeeBandExpected)
    {
        // Arrange

        // Act
        var ieeeBand = RadarFunctions.GetNatoRadarBand(rfFrequency_GHz);

        // Assert
        Assert.AreEqual(ieeeBandExpected, ieeeBand);
    }
}