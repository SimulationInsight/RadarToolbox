using SimulationInsight.Ais.Database;

namespace SimulationInsight.Ais.Server;

[TestClass]
public class AisServerTests
{

    [TestMethod]
    public void GetAisData()
    {
        // Arrange:
        var aisServerSettings = new AisServerSettings()
        {
            DateTimeStart = new DateTime(2023, 07, 27, 10, 00, 00),
            DateTimeEnd = new DateTime(2023, 07, 27, 10, 30, 00),
            LatitudeMinDeg = 55.958753,
            LatitudeMaxDeg = 56.224782,
            LongitudeMinDeg = 10.105650,
            LongitudeMaxDeg = 10.794830
        };

        var expectedNumberOfAisSites = 104;

        var aisDataService = new AisDataService();

        var aisDataList = new AisDataList();

        var aisServer = new AisServer(aisServerSettings, aisDataService, aisDataList);

        // Act:
        aisServer.GetAisData();

        // Assert:
        Assert.AreEqual(expectedNumberOfAisSites, aisServer.AisDataList.NumberOfAisSites);
    }
}