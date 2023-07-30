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
}