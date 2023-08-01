namespace SimulationInsight.Ais.Database.Tests;

[TestClass]
public class AisDataServiceTests
{
    [TestMethod]
    public void GetMMSI()
    {
        // Arrange:
        var aisDataService = new AisDataService();

        // Act:
        var mmsis = aisDataService.GetMMSIs();

        // Assert:
        Assert.IsTrue(mmsis.Count > 0);
    }

    [TestMethod]
    public void GetMMSIFromName()
    {
        // Arrange:
        var aisDataService = new AisDataService();

        var name = "EXPRESS 2";

        // Act:
        var mmsi = aisDataService.GetMMSIFromName(name);

        // Assert:
        Assert.IsTrue(mmsi > 0);
    }

    [TestMethod]
    public void GetAisData()
    {
        // Arrange:
        var dateTimeStart = new DateTime(2023, 07, 27, 10, 00, 00);
        var dateTimeEnd = new DateTime(2023, 07, 27, 10, 30, 00);
        var latitudeMinDeg = 55.958753;
        var latitudeMaxDeg = 56.224782;
        var longitudeMinDeg = 10.105650;
        var longitudeMaxDeg = 10.794830;

        var aisDataService = new AisDataService();

        // Act:
        var aisData = aisDataService.GetAisData(dateTimeStart, dateTimeEnd, latitudeMinDeg, latitudeMaxDeg, longitudeMinDeg, longitudeMaxDeg);

        // Assert:
        Assert.IsTrue(aisData.Count > 0);
    }
}