using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimulationInsight.ScenarioGenerator;
using System;
using System.IO;

namespace SimulationInsight.SimdisLibrary.Tests
{
    [TestClass]
    public class SimdisExporterTests
    {
        [TestMethod]
        public void ExportAsiFile_Test_1()
        {
            // Arrange:
            var scenarioSettings = ScenarioSettingsExamples.Example_1();

            var scenario = new Scenario(scenarioSettings);

            scenario.GenerateScenario();

            var folder = Environment.CurrentDirectory;
            var asiFileName = Path.Combine(folder, "Example_1.asi");

            // Act:
            var s = new SimdisExporter()
            {
                AsiFileName = asiFileName,
                Scenario = scenario,
                PlatformIdOffset = 1000
            };

            s.ExportAsiFile();

            // Assert:
            Assert.IsTrue(true);
        }
    }
}
